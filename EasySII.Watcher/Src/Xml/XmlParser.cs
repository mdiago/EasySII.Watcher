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

using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasySII.Watcher.Xml
{

    /// <summary>
    /// Clase responsable de la serialización xml.
    /// </summary>
    public class XmlParser
		{

			/// <summary>
			/// Mapa de configuración según el indicador de impuestos, en el que
			/// se determina el creador de objetos de serialización correspondiente.
			/// </summary>
			public static Dictionary<string, string> IICreatorMap { get; private set; }

			/// <summary>
			/// Devuelve un wrapper con un objeto de negocio subyacente
			/// calculado en función de los datos del SAPDocDataSet
			/// </summary>
			/// <param name="docdDataSet">Conjuto de datos de SAP.</param>
			/// <returns></returns>
			public static ISIICreator GetCreator(List<string[]> docdDataSet)
			{

				if (docdDataSet.Count == 0)
					throw new ArgumentException($"No se puede determinar un generador xml" +
                        $" para un conjunto de datos.\nSin datos de impuestos:" +
                        $" Documento = {docdDataSet[1]}, Fecha = {docdDataSet[2]}.");

				string[] ueCountries = Settings.Current.UECountries.Split(',');
                string country = docdDataSet[0][17].Trim().ToUpper();
                bool isUeCountry = (Array.IndexOf(ueCountries, country) != -1);

                string tokenCountry = (isUeCountry && country!= "ES") ? "UE" : "";

				if (!string.IsNullOrEmpty(docdDataSet[0][17]) && !isUeCountry)
					if (country != "ES")
						tokenCountry = "EX";

				string token = $"{docdDataSet[0][0]}.{docdDataSet[0][11]}." +
                $"{docdDataSet[0][12]}.{docdDataSet[0][13]}.{tokenCountry}." +
                $"{docdDataSet[0][18]}".ToUpper();

				if(!IICreatorMap.ContainsKey(token))
					throw new NotSupportedException($"No se ha encontrado serializador xml para la clave '{token}'.");

				string creatorKey = IICreatorMap[token];

				Assembly assembly = Assembly.GetExecutingAssembly();
				Type creatorType = assembly.GetType(creatorKey);

				if (creatorType == null)
					throw new NotSupportedException($"No se ha podido crear la instancia de {creatorKey}.");

				object creator = Activator.CreateInstance(creatorType);

				if (creator == null)
					throw new NotSupportedException($"No se ha podido crear la instancia de {creatorKey}.");

				ISIICreator isiicreator = creator as ISIICreator;

				isiicreator.SetDocDataSet(docdDataSet);

				return isiicreator;

			}


			/// <summary>
			/// Constructor estático.
			/// </summary>
			static XmlParser()
			{
				LoadIICreatorMap();
			}

			/// <summary>
			/// Carga mapeo entre indicadores de impuestos y serializadores
			/// xml.
			/// </summary>
			public static void LoadIICreatorMap()
			{

				IICreatorMap = new Dictionary<string, string>()
				{
					{ "FE.....",            "EasySII.Watcher.Xml.SIICreators.FEIvaBase"},
                    { "FE.X....",           "EasySII.Watcher.Xml.SIICreators.FEIvaBase"},
                    { "FE.....X",           "EasySII.Watcher.Xml.SIICreators.FEIvaNacionalNormalYAlquileresRetencion"},
					{ "FE....UE.",          "EasySII.Watcher.Xml.SIICreators.FEIvaIntracomEntrega"},
					{ "FE....EX.",          "EasySII.Watcher.Xml.SIICreators.FEIvaExportacion"},
					{ "FE.X...UE.",         "EasySII.Watcher.Xml.SIICreators.FEIvaIntracomPrestServicios"},
					{ "FE.X...EX.",         "EasySII.Watcher.Xml.SIICreators.FEIvaExportacionPrestSerivicios"},
					{ "FE..X...",           "EasySII.Watcher.Xml.SIICreators.FEIvaNacionalInversionSujetoPasivo"},
					{ "OI....UE.",          "EasySII.Watcher.Xml.SIICreators.OIIvaBaseBD"},
					{ "FR.....",            "EasySII.Watcher.Xml.SIICreators.FRIvaBase"},
					{ "FR.X....",           "EasySII.Watcher.Xml.SIICreators.FRIvaBase"},
					{ "FR...X.EX.",         "EasySII.Watcher.Xml.SIICreators.FRIvaImportacion"},
                    { "FR.X...EX.",         "EasySII.Watcher.Xml.SIICreators.FRIvaImportacion" },
					{ "FR...X..",           "EasySII.Watcher.Xml.SIICreators.FRIvaImportacion"},
                    { "FR...C.EX.",           "EasySII.Watcher.Xml.SIICreators.FRIvaImportacionAduanasLC"},
                    { "FR....EX.",          "EasySII.Watcher.Xml.SIICreators.FRIvaBase"},
                    { "FR....UE.",          "EasySII.Watcher.Xml.SIICreators.FRIvaIntracom"},
                    { "FR..X..UE.",         "EasySII.Watcher.Xml.SIICreators.FRIvaIntracom"},
                    { "FR..X...",           "EasySII.Watcher.Xml.SIICreators.FRIvaNacionalInversionSujetoPasivo"},
                    { "FR.X.X..UE.",        "EasySII.Watcher.Xml.SIICreators.FRIvaIntracomInversionSujetoPasivo"},
                };

			}

		
	}
}
