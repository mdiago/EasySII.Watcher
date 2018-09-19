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
	/// Se encarga de las tareas necesarias para el SII en facturas recibidas
	/// con IVA que no están incluidas en el Artículo 84.Uno 2º f de la ley del IVA . 
	/// FAQ 1.0 punto 4.4. Se anotará la factura recibida del proveedor comunitario en el 
	/// Libro registro de Facturas Recibidas procediendo a su identificación mediante 
	/// la clave 2 en el campo de tipos de Identificación en el país de residencia “IDType” 
	/// y su Número de Operador Intracomunitario en el campo "ID". El campo “Código País” 
	/// no será obligatorio.
	///	En el campo “Clave Régimen especial o Trascendencia” se consignará el valor 09. 
	///	Por otra parte, se deberá calcular y consignar la cuota soportada correspondiente 
	///	a la citada factura así como cumplimentar el campo “Cuota Deducible”.
	///	En estos casos no se debe informar con el campo “Inversión Sujeto Pasivo” 
	///	que sólo se utiliza cuando el declarante sea sujeto pasivo del Impuesto de 
	///	acuerdo con lo dispuesto en los artículos 84.Uno.2º y 4º de la Ley del IVA 
	///	siempre que tengan su origen en operaciones distintas a las adquisiciones 
	///	intracomunitarias de bienes y servicios.
	/// </summary>
	public class FRIvaIntracom : FRIvaBase
	{

		/// <summary>
		/// Construye una nueva instancia de la clase FRIvaNacionalNormal.
		/// </summary>
		public FRIvaIntracom() : base()
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

			facturaRecibida.ClaveRegimenEspecialOTrascendencia =
				ClaveRegimenEspecialOTrascendencia.AgenciasViajeCuentaAjenaAdqIntracom;
			facturaRecibida.IDOtroType = IDOtroType.NifIva;

			return facturaRecibida;
		}

		#endregion

	}
}
