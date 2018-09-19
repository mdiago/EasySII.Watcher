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
    /// Se encarga de las tareas necesarias para el SII en facturas emitidas
    /// con iva exportación.
    /// 
    /// FAQ 1.0
    /// 3.7. ¿Cómo se registra una Exportación?
    /// 
    /// La operación se anota en el Libro Registro de Facturas Expedidas.
    /// En el campo “Clave Régimen especial o Trascendencia” se consignará el valor 02.
    /// Por otra parte, la base imponible de la factura se incluirá en el campo de tipo de 
    /// operación “Exenta” dentro del bloque “Entrega”. 
    /// Como causa de exención se consignará la clave E2 “Exenta por el artículo 21”..
    /// </summary>
    public class FEIvaExportacion : FEIvaBase
	{

		/// <summary>
		/// Construye una nueva instancia de la clase FRIvaNacionalNormal.
		/// </summary>
		public FEIvaExportacion() : base()
		{
		}

		#region Métodos privados

		/// <summary>
		/// Carga las líneas de impuesto en el objeto factura facilitado como parametro.
		/// </summary>
		/// <param name="facturaEmitida"> Factura a actualizar con las líneas de IVA.</param>
		internal override void LoadTaxes(ARInvoice facturaEmitida)
		{
			facturaEmitida.GrossAmount = GrossAmount;
		}

		/// <summary>
		/// Devuelve una factura emitida representada por un objeto ARinvoice.
		/// </summary>
		/// <returns>Devuelve un obejero ARInvoice conformado con los 
		/// datos provenientes de SAP.</returns>
		internal override ARInvoice GetARInvoice()
		{

			ARInvoice facturaEmitida = base.GetARInvoice();

			facturaEmitida.ClaveRegimenEspecialOTrascendencia = ClaveRegimenEspecialOTrascendencia.ExportacionREAGYP;
			facturaEmitida.CausaExencion = CausaExencion.E2;
			facturaEmitida.CountryCode = CountryCode;



			return facturaEmitida;
		}

		#endregion
	}
}
