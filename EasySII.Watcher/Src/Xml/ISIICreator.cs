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

using EasySII.Xml.Soap;
using System.Collections.Generic;

namespace EasySII.Watcher.Xml
{
    /// <summary>
    /// Objeto con funcionalidad de serialización del SII.
    /// </summary>
    public interface ISIICreator
	{
	
		/// <summary>
		/// Número de documento.
		/// </summary>
		string DocumentNumber { get; }

		/// <summary>
		/// Razón social contraparte.
		/// </summary>
		string PartyName { get; }

		/// <summary>
		/// Pais.
		/// </summary>
		string CountryCode { get; }

		/// <summary>
		/// NIF de la contraparte.
		/// </summary>
		string PartyTaxId { get; }
	
		/// <summary>
		/// Devuelve un objeto de la capa de negocio de EasySII preparado
		/// para agregar al lote correspondiente.
		/// </summary>
		/// <returns></returns>
		object GetBusinessObj();

		/// <summary>
		/// Establece el conjunto de datos de SAP con los cuales
		/// se realizaran las operaciones de composición del objeto de negocio.
		/// </summary>
		/// <param name="docDataSet"> Conjunto de datos externos.</param>
		void SetDocDataSet(List<string[]> docDataSet);

		/// <summary>
		/// Obtiene un objeto Envelope listo para enviar al SII.
		/// </summary>
		/// <returns> Envelope de alta en el SII.</returns>
		Envelope GetEnvelope();

		/// <summary>
		/// Obtiene un objeto Envelope listo para enviar una petición de baja al SII.
		/// </summary>
		/// <returns> Envelope listo para enviar una petición de baja al SII.</returns>
		Envelope GetDeleteEnvelope();

		/// <summary>
		/// Obtiene un objeto Envelope listo para enviar un pago/cobro al SII.
		/// </summary>
		/// <returns> Envelope listo para enviar un envío de pago/cobro al SII.</returns>
		Envelope GetPaymentEnvelope();
	}
}
