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


namespace EasySII.Watcher.Xml.SIICreators
{
	/// <summary>
	///<para> Se encarga de las tareas necesarias para el SII en facturas recibidas
	/// con IVA de importación.</para>
	/// 
	/// <para>4.5. ¿Cómo se registra una Importación?</para>
	/// 
	/// <para>La operación se anota en el Libro Registro de Facturas Recibidas con la
	/// clave tipo de factura “F5”. Deberán consignarse, como número de factura 
	/// y fecha de expedición, el número de referencia que figura en el propio DUA y 
	/// la fecha de su admisión por la Administración Aduanera respectivamente.</para>
	/// 
	///<para> Por otra parte, se deberá consignar el detalle de la factura 
	/// (tipo, base imponible y cuota soportada) así como cumplimentar 
	/// el campo “Cuota Deducible”.</para>
	/// 
	///<para> En los datos identificativos correspondientes al proveedor se consignaran 
	/// los del importador y titular del libro registro.</para>
	/// 
	/// <para>En el suministro de los datos correspondientes a las importaciones se deben 
	/// tener en cuenta las siguientes precisiones:
	/// Como “Base Imponible” se indicará el Valor en Aduana de la mercancía, más los 
	/// demás gravámenes que se devenguen fuera del territorio de aplicación, más los 
	/// gravámenes a la importación y más los gastos accesorios que no formen parte del 
	/// Valor en Aduana y que se produzcan hasta el primer lugar de destino en el 
	/// interior de la comunidad (Base Imponible, casilla 47 DUA).
	/// Como “Cuota Tributaria” se consignará el importe a pagar.</para>
	/// 
	///<para> Los gastos posteriores a la admisión del DUA no incluidos en la base imponible
	/// del IVA a la importación darán lugar al registro de facturas separadas. De la 
	/// factura del transitario, sólo se registrará la parte que corresponda a la 
	/// prestación de su servicio (no la cuantía del IVA a la importación que se le 
	/// exige al cliente en concepto de suplido).</para>
	/// 
	/// 
	/// </summary>
	public class FRIvaImportacion : FRIvaBase
	{

		/// <summary>
		/// Razón social contraparte.
		/// </summary>
		public override string PartyName
		{
			get
			{
				return Settings.Current.CompanyName;
			}
		}

		/// <summary>
		/// NIF de la contraparte.
		/// </summary>
		public override string PartyTaxId
		{
			get
			{
				return Settings.Current.CompanyTaxID;
			}
		}


		/// <summary>
		/// Construye una nueva instancia de la clase FRIvaImportacion.
		/// </summary>
		public FRIvaImportacion() : base()
		{
		}


		#region Métodos privados

		/// <summary>
		/// Devuelve una factura recibida representada por un objeto APinvoice.
		/// </summary>
		/// <returns>Devuelve un obejero APInvoice conformado con los 
		/// datos provenientes de SAP.</returns>
		internal override APInvoice GetAPInvoice()
		{

			APInvoice facturaRecibida = base.GetAPInvoice();

			facturaRecibida.CausaExencion = CausaExencion.E2;
			facturaRecibida.InvoiceType = InvoiceType.F5;
			facturaRecibida.SellerParty = facturaRecibida.BuyerParty;


			return facturaRecibida;
		}

		/// <summary>
		/// Devuelve al acreedor de la factura de compra.
		/// </summary>
		/// <returns> Acreedor de la factura de compra.</returns>
		internal override Party GetParty()
		{
			return null;
		}

		#endregion

	}
}
