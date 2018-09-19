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
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;

namespace EasySII.Watcher.Admin
{

    /// <summary>
    /// Formulario principal de la aplicación.
    /// </summary>
    public partial class formMain : Form
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public formMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Abre el explorador de directorios y
        /// devuelve el resultado.
        /// </summary>
        /// <returns>String con la ruta del directorio.</returns>
        public string GetFolder()
        {
            dlgOpenDir.ShowDialog();
            return dlgOpenDir.SelectedPath;
        }

        /// <summary>
        /// Guarda la configuración.
        /// </summary>
        private void SaveSettings()
        {

            if (Directory.Exists(txOutbox.Text))
                EasySII.Watcher.Settings.Current.OutboxPath = txOutbox.Text;

            if (Directory.Exists(txInbox.Text))
                EasySII.Watcher.Settings.Current.InboxPath = txInbox.Text;       

            if (Directory.Exists(txXmlPath.Text))
                EasySII.Watcher.Settings.Current.XmlPath = txXmlPath.Text;

            if (Directory.Exists(txHistoryPath.Text))
                EasySII.Watcher.Settings.Current.HistoryPath = txHistoryPath.Text;

            if (Directory.Exists(txLogPath.Text))
                EasySII.Watcher.Settings.Current.LogPath = txLogPath.Text;

            EasySII.Settings.Current.SiiEndPointPrefix = (ckTest.Checked) ?
                SiiEndPointPrefixes.Test : SiiEndPointPrefixes.Prod;

            EasySII.Settings.Current.CertificateThumbprint = GetSelectedCertificateThumbprint();

            EasySII.Settings.Save();
            EasySII.Watcher.Settings.Save();

        }

        /// <summary>
        /// Carga la configuración.
        /// </summary>
        private void LoadSettings()
        {

            if (Directory.Exists(EasySII.Watcher.Settings.Current.OutboxPath))
                txOutbox.Text = EasySII.Watcher.Settings.Current.OutboxPath;

            if (Directory.Exists(EasySII.Watcher.Settings.Current.InboxPath))
                txInbox.Text = EasySII.Watcher.Settings.Current.InboxPath;

            if (Directory.Exists(EasySII.Watcher.Settings.Current.XmlPath))
                txXmlPath.Text = EasySII.Watcher.Settings.Current.XmlPath;

            if (Directory.Exists(EasySII.Watcher.Settings.Current.HistoryPath))
                txHistoryPath.Text = EasySII.Watcher.Settings.Current.HistoryPath;

            if (Directory.Exists(EasySII.Watcher.Settings.Current.LogPath))
                txLogPath.Text = EasySII.Watcher.Settings.Current.LogPath;

            ckTest.Checked = (EasySII.Settings.Current.SiiEndPointPrefix == 
                SiiEndPointPrefixes.Test);            

        }

        /// <summary>
        /// Llena el grid de certificados.
        /// </summary>
        private void FillCertificates()
        {
            try
            {

                grdCertificates.Rows.Clear();

                int index = 0;
                int selectedIndex = -1;

                if (Settings.Current.Certificates != null)
                {
                    foreach (var cert in Settings.Current.Certificates)
                    {
                        grdCertificates.Rows.Add(cert.Thumbprint,
                            cert.SubjectName, cert.IssuerName);

                        if (cert.Thumbprint.ToUpper() == EasySII.Settings.Current.CertificateThumbprint.ToUpper())
                            selectedIndex = index;

                        index++;

                    }

                    grdCertificates.ClearSelection();

                    if (selectedIndex > -1)
                    {
                        grdCertificates.Rows[selectedIndex].Selected = true;
                        grdCertificates.CurrentCell = grdCertificates.Rows[selectedIndex].Cells[1];
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Devuelve la huella del certificado seleccionado.
        /// </summary>
        /// <returns>Huella del certificado seleccionado o null.</returns>
        private string GetSelectedCertificateThumbprint()
        {
            if (grdCertificates.SelectedRows.Count == 0)
                return "";

            return $"{grdCertificates.SelectedRows[0].Cells[0].Value}";
        }

        private void btOutbox_Click(object sender, EventArgs e)
        {
            txOutbox.Text = $"{GetFolder()}\\";
        }

        private void btInbox_Click(object sender, EventArgs e)
        {
            txInbox.Text = $"{GetFolder()}\\";
        }

        private void btXmlPath_Click(object sender, EventArgs e)
        {
            txXmlPath.Text = $"{GetFolder()}\\";
        }

        private void btHistoryPath_Click(object sender, EventArgs e)
        {
            txHistoryPath.Text = $"{GetFolder()}\\";
        }

        private void btLogPath_Click(object sender, EventArgs e)
        {
            txLogPath.Text = $"{GetFolder()}\\";
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            try
            {

                if (ApplicationDeployment.IsNetworkDeployed)
                    Text += " - V " + ApplicationDeployment.CurrentDeployment.CurrentVersion;
                else
                    Text += " - V " + Application.ProductVersion.ToString();

                LoadSettings();
                FillCertificates();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                var serviceController = new ServiceController("Monitor de carpetas de EasySII");

                bool start = false;

                if (serviceController.Status ==
                    ServiceControllerStatus.Running)
                {
                    serviceController.Stop();
                    start = true;
                }

                SaveSettings();

                if (start)
                    serviceController.Start();
            }
            catch
            {
            }

        }

        private void btOutboxOpen_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(txOutbox.Text))
                Process.Start("explorer.exe", txOutbox.Text);
        }

        private void btInboxOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txInbox.Text))
                Process.Start("explorer.exe", txInbox.Text);
        }

        private void btXmlPathOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txXmlPath.Text))
                Process.Start("explorer.exe", txXmlPath.Text);
        }

        private void btHistoryPathOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txHistoryPath.Text))
                Process.Start("explorer.exe", txHistoryPath.Text);
        }

        private void btLogPathOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txLogPath.Text))
                Process.Start("explorer.exe", txLogPath.Text);
        }
    }
}
