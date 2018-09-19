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
using System.IO;
using System.Xml.Serialization;

namespace EasySII.Watcher
{
    /// <summary>
    /// Configuración.
    /// </summary>
    [Serializable]
	[XmlRoot("EasySIIWatcherSettings")]
	public class Settings
	{
		/// <summary>
		/// Configuración actual.
		/// </summary>
		static Settings _Current;
	

		/// <summary>
		/// Ruta al directorio de configuración.
		/// </summary>
		internal static string Path = System.Environment.GetFolderPath(
			Environment.SpecialFolder.CommonApplicationData) + "\\EasySIIWatcher\\";


		/// <summary>
		/// Nombre del fichero de configuración.
		/// </summary>
		internal static string FileName = "settings.xml";



		/// <summary>
		/// Configuración en curso.
		/// </summary>
		public static Settings Current
		{
			get
			{
				return _Current;
			}
			set
			{
				_Current = value;
			}
		}

		/// <summary>
		/// Ruta al directorio que actuará como bandeja de entrada.
		/// En este directorio se almacenarán todos los mensajes
		/// recibidos de la AEAT mediante el SII.
		/// </summary>
		[XmlElement("InboxPath")]
		public string InboxPath { get; set; }

		/// <summary>
		/// Ruta al directorio que actuará como bandeja de salida.
		/// En este directorio se almacenará una copia de cualquier
		/// envío realizado a la AEAT mediante el SII.
		/// </summary>
		[XmlElement("OutboxPath")]
		public string OutboxPath { get; set; }

        /// <summary>
        /// Ruta al directorio que actuará como historial.
        /// En este directorio se almacenará una copia de cualquier
        /// csv envíado a la AEAT mediante el SII.
        /// </summary>
        [XmlElement("HistoryPath")]
        public string HistoryPath { get; set; }

        /// <summary>
        /// Ruta al directorio que actuará como historial.
        /// En este directorio se almacenará una copia de cualquier
        /// xml envíado a la AEAT mediante el SII.
        /// </summary>
        [XmlElement("XmlPath")]
        public string XmlPath { get; set; }

        /// <summary>
        /// Log.
        /// </summary>
        [XmlElement("LogPath")]
		public string LogPath { get; set; }

        /// <summary>
        /// Errores.
        /// </summary>
        [XmlElement("ErrPath")]
        public string ErrPath { get; set; }

        /// <summary>
        /// Company TaxID.
        /// </summary>
        [XmlElement("CompanyTaxID")]
		public string CompanyTaxID { get; set; }

		/// <summary>
		/// Company Name.
		/// </summary>
		[XmlElement("CompanyName")]
		public string CompanyName { get; set; }

		/// <summary>
		/// Texto facturas emitidas.
		/// </summary>
		[XmlElement("CompanyARInvoiceText")]
		public string CompanyARInvoiceText { get; set; }

        /// <summary>
        /// Separador de campos del CSV.
        /// </summary>
        [XmlElement("CsvFieldSeparator")]
        public string CsvFieldSeparator { get; set; }

        /// <summary>
        /// Paises unión europea.
        /// </summary>
        [XmlElement("UECountries")]
		public string UECountries { get; set; }

        /// <summary>
        /// Almacena la lista de certificados a los que tiene acceso la cuenta
        /// que ejecuta el proceso.
        /// </summary>
        public List<Certificado> Certificates{ get; set; }

        /// <summary>
        /// Constructor estático de la clase Settings.
        /// </summary>
        static Settings()
		{
			Get();
		}

		/// <summary>
		/// Guarda la configuración en curso actual.
		/// </summary>
		public static void Save()
		{

			CheckDirectories();

			string FullPath = Path + "\\" + FileName;

			XmlSerializer serializer = new XmlSerializer(Current.GetType());

			using (StreamWriter w = new StreamWriter(FullPath))
			{
				serializer.Serialize(w, Current);
			}

		}

		/// <summary>
		/// Esteblece el archivo de configuración con el cual trabajar.
		/// </summary>
		/// <param name="fileName">Nombre del archivo de configuración a utilizar.</param>
		public static void SetConfigFileName(string fileName)
		{
			FileName = fileName;
			Get();
		}

		/// <summary>
		/// Inicia estaticos.
		/// </summary>
		/// <returns></returns>
		internal static Settings Get()
		{

			_Current = new Settings();


			string FullPath = Path + "\\" + FileName;

			XmlSerializer serializer = new XmlSerializer(_Current.GetType());
			if (File.Exists(FullPath))
			{
				using (StreamReader r = new StreamReader(FullPath))
				{
					_Current = serializer.Deserialize(r) as Settings;
				}
			}
			else
			{
				_Current.InboxPath = Path + "Inbox\\";
				_Current.OutboxPath = Path + "Outbox\\";
                _Current.HistoryPath = Path + "History\\";
                _Current.XmlPath = Path + "XmlPath\\";
                _Current.LogPath = Path + "Log\\";
                _Current.ErrPath = Path + "Err\\";
                _Current.CompanyTaxID = "B12959755";
				_Current.CompanyName = "IRENE SOLUTIONS SL";
				_Current.CompanyARInvoiceText = "ACERO INOXIDABLE";
                _Current.CsvFieldSeparator = ";";
				_Current.UECountries = "DE,AT,BE,BG,CY,HR,DK,SK,SI,ES,EE,FI,FR,GR,HU,IE,IT,LV,LT,LU,MT,NL,PL,PT,GB,CZ,RO,SE";
			}

			CheckDirectories();

			return _Current;
		}

		/// <summary>
		/// Aseguro existencia de directorios de trabajo.
		/// </summary>
		private static void CheckDirectories()
		{
			if (!Directory.Exists(Path))
				Directory.CreateDirectory(Path);

			if (!Directory.Exists(_Current.InboxPath))
				Directory.CreateDirectory(_Current.InboxPath);

			if (!Directory.Exists(_Current.OutboxPath))
				Directory.CreateDirectory(_Current.OutboxPath);

            if (!Directory.Exists(_Current.HistoryPath))
                Directory.CreateDirectory(_Current.HistoryPath);

            if (!Directory.Exists(_Current.XmlPath))
                Directory.CreateDirectory(_Current.XmlPath);

            if (!Directory.Exists(_Current.LogPath))
				Directory.CreateDirectory(_Current.LogPath);

            if (!Directory.Exists(_Current.ErrPath))
                Directory.CreateDirectory(_Current.ErrPath);

        }

	}
}
