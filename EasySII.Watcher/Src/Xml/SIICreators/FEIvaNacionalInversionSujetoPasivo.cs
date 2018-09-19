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
using EasySII.Xml.Sii;

namespace EasySII.Watcher.Xml.SIICreators
{

	/// <summary>
	/// NoExenta (tipo no exenta: con inversión sujeto pasivo S2) 
	/// Los campos “tipo impositivo” “cuota repercutida” se informarán 
	/// con importe cero. FAQ 1.0 en el punto 3.5.
	/// </summary>
	public class FEIvaNacionalInversionSujetoPasivo : FEIvaBase
	{

		/// <summary>
		/// Construye una nueva instancia de la clase FRIvaNacionalNormal.
		/// </summary>
		public FEIvaNacionalInversionSujetoPasivo() : base()
		{
		}

		#region Métodos privados

		/// <summary>
		/// Devuelve una factura emitida representada por un objeto ARinvoice.
		/// </summary>
		/// <returns>Devuelve un obejero ARInvoice conformado con los 
		/// datos provenientes de SAP.</returns>
		internal override ARInvoice GetARInvoice()
		{

			ARInvoice facturaEmitida = base.GetARInvoice();

			facturaEmitida.ToSII(true);

            string taxBase = "";

            if (EasySII.Settings.Current.IDVersionSii.CompareTo("1.1") < 0)
                taxBase = facturaEmitida.InnerSII.FacturaExpedida.TipoDesglose.DesgloseFactura.Sujeta.Exenta.BaseImponible;
            else
                taxBase = facturaEmitida.InnerSII.FacturaExpedida.TipoDesglose.DesgloseFactura.Sujeta.Exenta.DetalleExenta[0].BaseImponible;

            facturaEmitida.InnerSII.FacturaExpedida.TipoDesglose.DesgloseFactura.Sujeta.Exenta = null;
            facturaEmitida.InnerSII.FacturaExpedida.TipoDesglose.DesgloseFactura.Sujeta.NoExenta = new NoExenta();
            facturaEmitida.InnerSII.FacturaExpedida.TipoDesglose.DesgloseFactura.Sujeta.NoExenta.TipoNoExenta = SujetaType.S2.ToString();
            facturaEmitida.InnerSII.FacturaExpedida.TipoDesglose.DesgloseFactura.Sujeta.NoExenta.DesgloseIVA = new DesgloseIVA();
            facturaEmitida.InnerSII.FacturaExpedida.TipoDesglose.DesgloseFactura.Sujeta.NoExenta.DesgloseIVA.DetalleIVA.Add(new DetalleIVA()
            {
                BaseImponible = taxBase,
                CuotaRepercutida = "0",
                TipoImpositivo = "0"
            });      

            return facturaEmitida;
		}

		#endregion
	}
}
