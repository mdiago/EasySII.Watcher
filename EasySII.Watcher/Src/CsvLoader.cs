/*
    This file is part of the EasySII (R) project.
    Copyright (c) 2017-2018 Irene Solutions SL
    Authors: Irene Solutions SL.

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License version 3
    as published by the Free Software Foundation with the addition of the
    following permission added to Section 15 as permitted in Section 7(a):
    FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
    IRENE SOLUTIONS SL. IRENE SOLUTIONS SL DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
    OF THIRD PARTY RIGHTS
    
    This program is distributed in the hope that it will be useful, but
    WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
    or FITNESS FOR A PARTICULAR PURPOSE.
    See the GNU Affero General Public License for more details.
    You should have received a copy of the GNU Affero General Public License
    along with this program; if not, see http://www.gnu.org/licenses or write to
    the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
    Boston, MA, 02110-1301 USA, or download the license from the following URL:
        http://www.irenesolutions.com/terms-of-use.pdf
    
    The interactive user interfaces in modified source and object code versions
    of this program must display Appropriate Legal Notices, as required under
    Section 5 of the GNU Affero General Public License.
    
    You can be released from the requirements of the license by purchasing
    a commercial license. Buying such a license is mandatory as soon as you
    develop commercial activities involving the EasySII software without
    disclosing the source code of your own applications.
    These activities include: offering paid services to customers as an ASP,
    serving sii XML data on the fly in a web application, shipping EasySII
    with a closed source product.
    
    For more information, please contact Irene Solutions SL. at this
    address: info@irenesolutions.com
 */

using EasySII.Net;
using EasySII.Watcher.Xml;
using EasySII.Xml;
using EasySII.Xml.SiiR;
using EasySII.Xml.Soap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasySII.Watcher
{
    /// <summary>
    /// Carga archivos csv a enviar al SII.
    /// </summary>
    public class CsvLoader
	{

		/// <summary>
		/// Gestiona los trabajos para los archivos csv entrados en el directorio.
		/// Campos del CSV: Tipo doc ('FR', 'FE', 'OI'), Numero Factura, Fecha Emisión,	Fecha registro,
		/// Fecha contabilidad,	NIF contraparte,	
		/// Nombre contraparte,	Descripción, Operación,
		/// Base imponible,	Tipo impositivo,	Cuota impuesto,	Servicio,
		/// Inversion sujeto pasivo,	Importación,	Numero Factura rectificada,	
		/// Fecha Emisión, Factura rectificada, Dirección Operador, Autofactura.
		/// </summary>
		/// <param name="path">Ruta a un archivo CSV.</param>
		public static void Load(string path)
		{
			try
			{

				int WIN_1252_CP = 1252; // Windows ANSI codepage 1252
				string[] invoices = File.ReadAllLines(path, Encoding.GetEncoding(WIN_1252_CP));

                StringBuilder sbCsv = new StringBuilder();
                StringBuilder sbCsvErr = new StringBuilder();
                StringBuilder sbLog = new StringBuilder();

                string additionalFields = "";
                string[] additionalFieldsValues = null;

                int count = 0;
                int curLine = 1;

				List<string[]> invoiceLines = new List<string[]>();
				
				foreach (var invoice in invoices)
				{
					string[] invoiceValues = Clear(invoice.Split(';'));

                    if (invoiceValues.Length == 21)
                    {

                        if (invoiceLines.Count > 0 && 
                            invoiceLines[invoiceLines.Count - 1][1] == invoiceValues[1])
                        {
                            // Continúo con la factura anterior
                            invoiceLines.Add(invoiceValues);
                        }
                        else
                        {
                            // Cierro factura
                            if (invoiceLines.Count > 0)
                            {

                                additionalFields = ProcessInvoice(invoiceLines, path, curLine);
                                additionalFieldsValues = additionalFields.Split(';');

                                if (additionalFieldsValues[2] != "Correcto" &&
                                    !string.IsNullOrEmpty(additionalFieldsValues[2]))
                                    sbLog.AppendLine($"Error en la línea {curLine} con la factura {invoiceLines[0][1]}: {additionalFieldsValues[2]} {additionalFieldsValues[3]} {additionalFieldsValues[4]}");
                               

                                foreach (var invoiceLine in invoiceLines)
                                {

                                    string invLine = GetInvoiceLine(invoiceLine);

                                    sbCsv.AppendLine($"{invLine}{additionalFields}");

                                    if (additionalFieldsValues[2] != "Correcto" &&
                                     !string.IsNullOrEmpty(additionalFieldsValues[2]))
                                        sbCsvErr.AppendLine($"{invLine}{additionalFields}");
                                }


                            }

                            invoiceLines = new List<string[]>
                            {
                                invoiceValues
                            };
                        }

                        count++;

                        if (count == invoices.Length && invoiceLines.Count > 0)
                        {

                            additionalFields = ProcessInvoice(invoiceLines, path, curLine);
                            additionalFieldsValues = additionalFields.Split(';');

                            if (additionalFieldsValues[2] != "Correcto" &&
                                !string.IsNullOrEmpty(additionalFieldsValues[2]))
                                sbLog.AppendLine($"Error en la línea {curLine} con la factura {invoiceLines[0][1]}: {additionalFieldsValues[2]} {additionalFieldsValues[3]} {additionalFieldsValues[4]}");


                            foreach (var invoiceLine in invoiceLines)
                            {

                                string invLine = GetInvoiceLine(invoiceLine);

                                sbCsv.AppendLine($"{invLine}{additionalFields}");

                                if (additionalFieldsValues[2] != "Correcto" &&
                                 !string.IsNullOrEmpty(additionalFieldsValues[2]))
                                    sbCsvErr.AppendLine($"{invLine}{additionalFields}");
                            }


                        }
                    }
                    else
                    {
                        sbCsv.AppendLine($"{invoice};;;Error número de columnas;");
                    }

                    curLine++;

                }

                string pathCsvResult = $"{Settings.Current.InboxPath}{Path.GetFileName(path)}";
                string pathCsvErr = $"{Settings.Current.ErrPath}{Path.GetFileName(path)}";
                File.WriteAllText(pathCsvResult, sbCsv.ToString());
                File.WriteAllText(pathCsvErr, sbCsvErr.ToString());
                File.WriteAllText(pathCsvResult.Replace("csv", "txt").Replace("CSV","txt"), sbLog.ToString());


                string pathHistory = $"{Settings.Current.HistoryPath}{Path.GetFileName(path)}";

                File.Copy(path, pathHistory);

                // Elimina el archivo de la bandeja de entrada
                File.Delete(path);


            }
			catch (Exception ex)
			{
				File.WriteAllText($"{Settings.Current.LogPath}{Path.GetRandomFileName()}.txt",
						ex.Message);
			}
		}

        /// <summary>
        /// Devuelve un string de campos separados por punto y coma.
        /// </summary>
        /// <param name="values">Valore para componer la linea.</param>
        /// <returns>String de campos separados por punto y coma.</returns>
        private static string GetInvoiceLine(string[] values)
        {

            string ret = "";

            foreach (var val in values)
                ret += $"{val};";

            return ret.Substring(0, ret.Length - 1);
        }


        /// <summary>
        /// Procesa una factura.
        /// </summary>
        /// <param name="invoiceLines">Lineas de factura.</param>
        /// <param name="path">Path al csv que contiene las lineas.</param>
        /// <param name="line">Línea en curso.</param>
        /// <returns></returns>
        private static string ProcessInvoice(List<string[]> invoiceLines, string path, int line)
        {

            string additionalFields= $";;;;"; 

            ISIICreator creator = null;

            string msg = "";

            try
            {
                creator = XmlParser.GetCreator(invoiceLines);

                if (creator != null)
                {
                    Envelope envelope = creator.GetEnvelope();

                    string requestPath = $"{Settings.Current.XmlPath}{Path.GetFileName(path)}.{line.ToString().PadLeft(10, '0')}.xml";
                    SIIParser.GetXml(envelope, requestPath);

                    string response = Wsd.Send(envelope);
                    string responsePath = $"{Settings.Current.InboxPath}{Path.GetFileName(path)}.{line.ToString().PadLeft(10, '0')}.xml";
                    File.WriteAllText(responsePath, response);

                    additionalFields = ProcessResponse(responsePath, invoiceLines[0][0]);


                }
                else
                {

                    msg = $"Error en la línea {line} con la factura {invoiceLines[0][1]}: ISIICreator es nulo.";

                    File.WriteAllText($"{Settings.Current.LogPath}{Path.GetRandomFileName()}.txt",
                    msg);

                    additionalFields = $";;;;{msg}";
                }

            }
            catch (Exception ex)
            {

                msg = $"Error en la línea {line} con la factura {invoiceLines[0][1]}: {ex.Message}";

                File.WriteAllText($"{Settings.Current.LogPath}{Path.GetRandomFileName()}.txt",
                    $"Error en la línea {line} con la factura {invoiceLines[0][1]}: {ex.Message}");

                additionalFields = $";;;;{msg}";
            }

            return additionalFields;
        }


        /// <summary>
        /// Procesado de la respuesta recibida
        /// </summary>
        /// <param name="responsePath">Path a archivo xml de respuesta de la AEAT.</param>
        /// <param name="docType">Tipo de documento: FE, FR o OI.</param>
        private static string ProcessResponse(string responsePath, string docType)
        {
            Envelope responseEnvelope = new Envelope(responsePath);

            RespuestaLRF respuesta = null;

            switch (docType)
            {
                case "FE":
                    respuesta = responseEnvelope.Body.RespuestaLRFacturasEmitidas;
                    break;
                case "FR":
                    respuesta = responseEnvelope.Body.RespuestaLRFacturasRecibidas;
                    break;
                case "OI":
                    respuesta = responseEnvelope.Body.RespuestaLRDetOperacionesIntracomunitarias;
                    break;
                default:
                    throw new NotImplementedException($"No implementado ProcessResponse para docType='{docType}'");
            }


            string csv = "";
            string status = "";
            string fault = "";
            string msg = "";

            if (respuesta != null)
            {
                csv = respuesta.CSV ?? "";
                status = respuesta.EstadoEnvio ?? "";
                if (respuesta.RespuestaLinea.Count > 0)
                    msg = $"({respuesta.RespuestaLinea[0].CodigoErrorRegistro}) {respuesta.RespuestaLinea[0].DescripcionErrorRegistro}";
            }
            else
            {
                // Error en fault
                SoapFault msgError = responseEnvelope.Body.RespuestaError;
                fault = msgError.FaultDescription ?? "";
            }

            return $";{csv};{status};{fault};{msg}";

        }

        /// <summary>
        /// Quita espacios y comillas.
        /// </summary>
        /// <param name="values">Matriz a limpiar.</param>
        /// <returns>Matriz limpia.</returns>
        private static string[] Clear(string[] values)
        {
            string[] ret = new string[values.Length];

            for (int s = 0; s < values.Length; s++)
            {
                ret[s] = values[s].Replace("\"", "").Trim();
            }


            return ret;
        }

	}
}
