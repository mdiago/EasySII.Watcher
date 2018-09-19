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

using EasySII.Business;
using EasySII.Xml.Soap;
using System;
using System.Collections.Generic;

namespace EasySII.Watcher.Xml.SIICreators
{
    /// <summary>
    /// Se encarga de las tareas necesarias para el SII en 
    /// operaciones intracomunitarias.
    /// </summary>
    public class OIIvaBaseBD : ISIICreator
	{

		internal List<string[]> _InnerDocDataSet;
		

		/// <summary>
		/// Número de documento.
		/// </summary>
		public virtual string DocumentNumber
		{
			get
			{				

				return _InnerDocDataSet[0][1];

			}
		}

		/// <summary>
		/// Razón social contraparte.
		/// </summary>
		public string PartyName
		{
			get
			{
				return _InnerDocDataSet[0][6];
			}
		}

		/// <summary>
		/// NIF de la contraparte.
		/// </summary>
		public virtual string PartyTaxId
		{
			get
			{
				return GetTaxId();
			}
		}

		/// <summary>
		/// Pais.
		/// </summary>
		public string CountryCode
		{
			get
			{
				return _InnerDocDataSet[0][17];
			}
		}
	
		/// <summary>
		/// Importe bruto.
		/// </summary>
		public virtual decimal GrossAmount
		{
			get
			{
				return GetGrossAmount();
			}
		}

		/// <summary>
		/// Construye una nueva instancia de la clase OIIvaBase.
		/// </summary>
		public OIIvaBaseBD()
		{
		}

		/// <summary>
		/// Devuelve un objeto de la capa de negocio de EasySII preparado
		/// para agregar al lote correspondiente.
		/// </summary>
		/// <returns>Un objeto APInvoice, ARInvoice ...</returns>
		public virtual object GetBusinessObj()
		{
			return GetITInvoice();
		}

		/// <summary>
		/// Establece el conjunto de datos de SAP con los cuales
		/// se realizaran las operaciones de composición del objeto de negocio.
		/// </summary>
		/// <param name="docDataSet"> Conjunto de datos de SAP.</param>
		public virtual void SetDocDataSet(List<string[]> docDataSet)
		{
			_InnerDocDataSet = docDataSet;
		}

		/// <summary>
		/// Obtiene un objeto Envelope listo para enviar al SII.
		/// </summary>
		/// <returns>Envelope listo para transmitir al SII.</returns>
		public Envelope GetEnvelope()
		{
			// Creamos al titular del envío
			Party titular = new Party()
			{
				TaxIdentificationNumber = Settings.Current.CompanyTaxID,
				PartyName = Settings.Current.CompanyName
			};

			ITInvoicesBatch loteOperIntracom = new ITInvoicesBatch();
			loteOperIntracom.Titular = titular;
			loteOperIntracom.CommunicationType = CommunicationType.A0;

			loteOperIntracom.ITInvoices.Add(GetITInvoice());

			return loteOperIntracom.GetEnvelope();

		}

		/// <summary>
		/// Obtiene un objeto Envelope listo para enviar una petición de baja al SII.
		/// </summary>
		/// <returns> nvelope listo para enviar una petición de baja al SII.</returns>
		public virtual Envelope GetDeleteEnvelope()
		{
			// Creamos al titular del envío
			throw new NotImplementedException("No implementado borrado de operaciones intracoumnitarias.");
		}

		/// <summary>
		/// Obtiene un objeto Envelope listo para enviar un cobro al SII.
		/// </summary>
		/// <returns>Envelope listo para enviar un cobro al SII.</returns>
		public virtual Envelope GetPaymentEnvelope()
		{
			// Sólo implementado en serializadores ECC
			throw new InvalidOperationException($"No se pueden realizar operaciones de pago para el documento {_InnerDocDataSet[1]} emitido el {_InnerDocDataSet[2]}. Sólo regímen especial criterio de caja.");

		}

		#region Métodos privados

		/// <summary>
		/// Devuelve una factura recibida representada por un objeto ITInvoice.
		/// </summary>
		/// <returns>Devuelve un obejero APInvoice conformado con los 
		/// datos provenientes de SAP.</returns>
		internal virtual ITInvoice GetITInvoice()
		{
			ITInvoice facturaEmitida = new ITInvoice(); // Factura emitida

			SetInvoiceIssueDate(facturaEmitida);

			facturaEmitida.InvoiceNumber = DocumentNumber; // El número de factura			

			facturaEmitida.InvoiceText = GetOpText();

			facturaEmitida.SellerParty = new Party()
			{
				TaxIdentificationNumber = Settings.Current.CompanyTaxID,
				PartyName = Settings.Current.CompanyName
			};

			facturaEmitida.BuyerParty = GetParty();

			facturaEmitida.IDOtroType = IDOtroType.NifIva;

			facturaEmitida.CountryCode = CountryCode;
			facturaEmitida.OperationType = OperationType.B;
			facturaEmitida.ClaveDeclarado = ClaveDeclarado.D;
			facturaEmitida.EstadoMiembro = CountryCode;
			facturaEmitida.DescripcionBienes = _InnerDocDataSet[0][7];
			facturaEmitida.DireccionOperador = _InnerDocDataSet[0][16];

			return facturaEmitida;

		}

		/// <summary>
		/// Establece el estatus del documento.
		/// </summary>
		internal virtual void SetInvoiceIssueDate(ITInvoice facturaEmitida)
		{

			DateTime dateFra = Convert.ToDateTime(_InnerDocDataSet[0][2]);
			DateTime dateImp = Convert.ToDateTime(_InnerDocDataSet[0][2]);

			facturaEmitida.IssueDate = (dateImp > dateFra) ? dateImp : dateFra;  // Fecha factura: La más alta de fecha asiento o fecha impuesto
		}
	

		/// <summary>
		/// Devuelve la parte compradora de la factura emitida, es decir,
		/// el cliente.
		/// </summary>
		/// <returns>Cliente en su caso.</returns>
		internal virtual Party GetParty()
		{
			return new Party()
			{
				TaxIdentificationNumber = GetTaxId(),
				PartyName = GetName()
			};
		}
	

		/// <summary>
		/// Carga las líneas de impuesto en el objeto factura facilitado como parametro.
		/// </summary>
		internal virtual decimal GetGrossAmount()
		{

			decimal grossAmount = 0;

			foreach (var row in _InnerDocDataSet)
			{
				decimal taxBase = (string.IsNullOrEmpty(_InnerDocDataSet[0][8])) ? 0 :Convert.ToDecimal(row[8]);
				decimal taxAmount = 0;

				if (!string.IsNullOrEmpty($"{row[10]}"))
					taxAmount = Convert.ToDecimal(row[10]);

				grossAmount += taxBase + taxAmount;
			}

			return grossAmount;
		}

		/// <summary>
		/// Devuelve un texto como descripción de la operación.
		/// </summary>
		/// <returns> Si encuentra una linea en el asiento con texto, ese texto.
		/// Si no enctra otro texto devuelve el nombre del proveedor.</returns>
		internal virtual string GetOpText()
		{
			return _InnerDocDataSet[0][7];
		}

		/// <summary>
		/// Devuelve el identificador fiscal de la contraparte.
		/// </summary>
		/// <returns>Identificador fiscal de la contraparte.</returns>
		internal virtual string GetTaxId()
		{
			return _InnerDocDataSet[0][5];
		}

		/// <summary>
		/// Nombre de la contraparte.
		/// </summary>
		/// <returns>Nombre de la contraparte.</returns>
		internal virtual string GetName()
		{

			return _InnerDocDataSet[0][6];
		}

		#endregion


	}
}
