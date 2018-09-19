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
using EasySII.Xml.Soap;
using System;
using System.IO;
using System.Threading;

namespace EasySII.Watcher
{
    /// <summary>
    /// Carga archivos xml a enviar al SII.
    /// </summary>
    public class XmlLoader
	{
		/// <summary>
		/// Gestiona los trabajos para los archivos xml entrados en el directorio.
		/// </summary>
		/// <param name="path"></param>
		public static void Load(string path)
		{
			try
			{
				Thread.Sleep(1000);
				// Cargamos el archivo en una nueva instancia de la clase Envelope
				Envelope envelope = new Envelope(path);
				// Realizamos el envío y guardamos la respuesta de la AEAT
				string xmlResponse = Wsd.Send(envelope);
                // Guardo la respuesta en un archivo
                string xmlName = Path.GetFileName(path);
                File.WriteAllText($"{Settings.Current.InboxPath}{xmlName}", xmlResponse);
                // Pasamos el fichero envíado al histórico
                string pathHistory = $"{Settings.Current.HistoryPath}{xmlName}";
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
	}
}
