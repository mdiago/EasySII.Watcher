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
using System.Security.Cryptography.X509Certificates;
using System.ServiceProcess;

namespace EasySII.Watcher.Service
{
    /// <summary>
    /// Web service para monitorizar carpeta de salida en el sistema.
    /// Vigila la entrada de archivos en la carpeta configuradas e intenta
    /// el envío al SII de la AEAT con los mismos, devolviendo la respuesta
    /// de la AEAT en la otra carpeta configurada.
    /// </summary>
    public partial class EasySIIW : ServiceBase
	{

		Watcher _Watcher;

		/// <summary>
		/// Contruye una nueva instancia del servicio de windows.
		/// </summary>
		public EasySIIW()
		{
			InitializeComponent();

			eventLogEasySIIW = new System.Diagnostics.EventLog();
			if (!System.Diagnostics.EventLog.SourceExists("EasySIIW"))
			{
				System.Diagnostics.EventLog.CreateEventSource(
					"EasySIIW", "EasySIIwLog");
			}
			eventLogEasySIIW.Source = "EasySIIW";
			eventLogEasySIIW.Log = "EasySIIWLog";

		}

		/// <summary>
		/// Se ejecuta al iniciar el servicio.
		/// </summary>
		/// <param name="args">Argumento de entrada.</param>
		protected override void OnStart(string[] args)
		{
            try
            {

                X509Store store = new X509Store();
                store.Open(OpenFlags.ReadOnly);

                Settings.Current.Certificates.Clear();

                foreach (X509Certificate2 cert in store.Certificates)
                    Settings.Current.Certificates.Add(new Certificado() {
                        Thumbprint = cert.Thumbprint,
                        SubjectName = cert.SubjectName.Format(true),
                        IssuerName = cert.IssuerName.Format(true),
                        SerialNumber = cert.SerialNumber
                    });   

                // Probamos en LocalMachine
                X509Store storeLM = new X509Store(StoreLocation.LocalMachine);
                storeLM.Open(OpenFlags.ReadOnly);

                foreach (X509Certificate2 cert in storeLM.Certificates)
                    Settings.Current.Certificates.Add(new Certificado()
                    {
                        Thumbprint = cert.Thumbprint,
                        SubjectName = cert.SubjectName.Format(true),
                        IssuerName = cert.IssuerName.Format(true),
                        SerialNumber = cert.SerialNumber
                    });

                Settings.Save();               
            }
            catch (Exception ex)
            {
                eventLogEasySIIW.WriteEntry($"EasySIIW error on Settings.Save(): {ex}");
            }

            try
            {
                EasySII.Settings.Save();
            }
            catch (Exception ex)
            {
                eventLogEasySIIW.WriteEntry($"EasySIIW error on EasySII.Settings.Save(): {ex}");
            }

            eventLogEasySIIW.WriteEntry($"EasySIIW watching for file input in dir: {EasySII.Watcher.Settings.Current.InboxPath}");

			_Watcher = new Watcher();
            _Watcher.Start();

        }

		/// <summary>
		/// Se ejecuta al finalizar el servicio de windows.
		/// </summary>
		protected override void OnStop()
		{
			eventLogEasySIIW.WriteEntry($"EasySIIW detenido: {DateTime.Now.ToLocalTime()}");
			_Watcher.End();
		}
	}
}
