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

namespace EasySII.Watcher.Admin
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tbGeneral = new System.Windows.Forms.TabPage();
            this.btLogPathOpen = new System.Windows.Forms.Button();
            this.btHistoryPathOpen = new System.Windows.Forms.Button();
            this.btXmlPathOpen = new System.Windows.Forms.Button();
            this.btInboxOpen = new System.Windows.Forms.Button();
            this.btOutboxOpen = new System.Windows.Forms.Button();
            this.btLogPath = new System.Windows.Forms.Button();
            this.txLogPath = new System.Windows.Forms.TextBox();
            this.lbLogPath = new System.Windows.Forms.Label();
            this.btHistoryPath = new System.Windows.Forms.Button();
            this.txHistoryPath = new System.Windows.Forms.TextBox();
            this.lbHistoryPath = new System.Windows.Forms.Label();
            this.btXmlPath = new System.Windows.Forms.Button();
            this.txXmlPath = new System.Windows.Forms.TextBox();
            this.lbXmlPath = new System.Windows.Forms.Label();
            this.ckTest = new System.Windows.Forms.CheckBox();
            this.btInbox = new System.Windows.Forms.Button();
            this.txInbox = new System.Windows.Forms.TextBox();
            this.lbInbox = new System.Windows.Forms.Label();
            this.btOutbox = new System.Windows.Forms.Button();
            this.txOutbox = new System.Windows.Forms.TextBox();
            this.lbOutbox = new System.Windows.Forms.Label();
            this.tbOptions = new System.Windows.Forms.TabPage();
            this.lblInfoCertStore = new System.Windows.Forms.Label();
            this.grdCertificates = new System.Windows.Forms.DataGridView();
            this.Thumbprint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssuerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlgOpenDir = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.txTaxID = new System.Windows.Forms.TextBox();
            this.txName = new System.Windows.Forms.TextBox();
            this.lbTaxID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMain.SuspendLayout();
            this.tbGeneral.SuspendLayout();
            this.tbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCertificates)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tbGeneral);
            this.tbMain.Controls.Add(this.tbOptions);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(621, 387);
            this.tbMain.TabIndex = 0;
            // 
            // tbGeneral
            // 
            this.tbGeneral.Controls.Add(this.label1);
            this.tbGeneral.Controls.Add(this.lbTaxID);
            this.tbGeneral.Controls.Add(this.txName);
            this.tbGeneral.Controls.Add(this.txTaxID);
            this.tbGeneral.Controls.Add(this.btLogPathOpen);
            this.tbGeneral.Controls.Add(this.btHistoryPathOpen);
            this.tbGeneral.Controls.Add(this.btXmlPathOpen);
            this.tbGeneral.Controls.Add(this.btInboxOpen);
            this.tbGeneral.Controls.Add(this.btOutboxOpen);
            this.tbGeneral.Controls.Add(this.btLogPath);
            this.tbGeneral.Controls.Add(this.txLogPath);
            this.tbGeneral.Controls.Add(this.lbLogPath);
            this.tbGeneral.Controls.Add(this.btHistoryPath);
            this.tbGeneral.Controls.Add(this.txHistoryPath);
            this.tbGeneral.Controls.Add(this.lbHistoryPath);
            this.tbGeneral.Controls.Add(this.btXmlPath);
            this.tbGeneral.Controls.Add(this.txXmlPath);
            this.tbGeneral.Controls.Add(this.lbXmlPath);
            this.tbGeneral.Controls.Add(this.ckTest);
            this.tbGeneral.Controls.Add(this.btInbox);
            this.tbGeneral.Controls.Add(this.txInbox);
            this.tbGeneral.Controls.Add(this.lbInbox);
            this.tbGeneral.Controls.Add(this.btOutbox);
            this.tbGeneral.Controls.Add(this.txOutbox);
            this.tbGeneral.Controls.Add(this.lbOutbox);
            this.tbGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbGeneral.Size = new System.Drawing.Size(613, 361);
            this.tbGeneral.TabIndex = 0;
            this.tbGeneral.Text = "General";
            this.tbGeneral.UseVisualStyleBackColor = true;
            // 
            // btLogPathOpen
            // 
            this.btLogPathOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btLogPathOpen.BackgroundImage")));
            this.btLogPathOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btLogPathOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogPathOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogPathOpen.Location = new System.Drawing.Point(563, 323);
            this.btLogPathOpen.Name = "btLogPathOpen";
            this.btLogPathOpen.Size = new System.Drawing.Size(36, 20);
            this.btLogPathOpen.TabIndex = 20;
            this.btLogPathOpen.UseVisualStyleBackColor = true;
            this.btLogPathOpen.Click += new System.EventHandler(this.btLogPathOpen_Click);
            // 
            // btHistoryPathOpen
            // 
            this.btHistoryPathOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btHistoryPathOpen.BackgroundImage")));
            this.btHistoryPathOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btHistoryPathOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHistoryPathOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHistoryPathOpen.Location = new System.Drawing.Point(563, 273);
            this.btHistoryPathOpen.Name = "btHistoryPathOpen";
            this.btHistoryPathOpen.Size = new System.Drawing.Size(36, 20);
            this.btHistoryPathOpen.TabIndex = 19;
            this.btHistoryPathOpen.UseVisualStyleBackColor = true;
            this.btHistoryPathOpen.Click += new System.EventHandler(this.btHistoryPathOpen_Click);
            // 
            // btXmlPathOpen
            // 
            this.btXmlPathOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btXmlPathOpen.BackgroundImage")));
            this.btXmlPathOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btXmlPathOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXmlPathOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXmlPathOpen.Location = new System.Drawing.Point(563, 219);
            this.btXmlPathOpen.Name = "btXmlPathOpen";
            this.btXmlPathOpen.Size = new System.Drawing.Size(36, 20);
            this.btXmlPathOpen.TabIndex = 18;
            this.btXmlPathOpen.UseVisualStyleBackColor = true;
            this.btXmlPathOpen.Click += new System.EventHandler(this.btXmlPathOpen_Click);
            // 
            // btInboxOpen
            // 
            this.btInboxOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btInboxOpen.BackgroundImage")));
            this.btInboxOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btInboxOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInboxOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInboxOpen.Location = new System.Drawing.Point(563, 118);
            this.btInboxOpen.Name = "btInboxOpen";
            this.btInboxOpen.Size = new System.Drawing.Size(36, 20);
            this.btInboxOpen.TabIndex = 17;
            this.btInboxOpen.UseVisualStyleBackColor = true;
            this.btInboxOpen.Click += new System.EventHandler(this.btInboxOpen_Click);
            // 
            // btOutboxOpen
            // 
            this.btOutboxOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btOutboxOpen.BackgroundImage")));
            this.btOutboxOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btOutboxOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOutboxOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOutboxOpen.Location = new System.Drawing.Point(563, 75);
            this.btOutboxOpen.Name = "btOutboxOpen";
            this.btOutboxOpen.Size = new System.Drawing.Size(36, 20);
            this.btOutboxOpen.TabIndex = 16;
            this.btOutboxOpen.UseVisualStyleBackColor = true;
            this.btOutboxOpen.Click += new System.EventHandler(this.btOutboxOpen_Click);
            // 
            // btLogPath
            // 
            this.btLogPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btLogPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogPath.Location = new System.Drawing.Point(522, 323);
            this.btLogPath.Name = "btLogPath";
            this.btLogPath.Size = new System.Drawing.Size(36, 20);
            this.btLogPath.TabIndex = 15;
            this.btLogPath.Text = ". . .";
            this.btLogPath.UseVisualStyleBackColor = true;
            this.btLogPath.Click += new System.EventHandler(this.btLogPath_Click);
            // 
            // txLogPath
            // 
            this.txLogPath.Enabled = false;
            this.txLogPath.Location = new System.Drawing.Point(15, 323);
            this.txLogPath.Name = "txLogPath";
            this.txLogPath.Size = new System.Drawing.Size(502, 20);
            this.txLogPath.TabIndex = 14;
            // 
            // lbLogPath
            // 
            this.lbLogPath.AutoSize = true;
            this.lbLogPath.Location = new System.Drawing.Point(15, 305);
            this.lbLogPath.Name = "lbLogPath";
            this.lbLogPath.Size = new System.Drawing.Size(258, 13);
            this.lbLogPath.TabIndex = 13;
            this.lbLogPath.Text = "Los archivos del Log de errores se almacenarán aquí";
            // 
            // btHistoryPath
            // 
            this.btHistoryPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btHistoryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHistoryPath.Location = new System.Drawing.Point(522, 273);
            this.btHistoryPath.Name = "btHistoryPath";
            this.btHistoryPath.Size = new System.Drawing.Size(36, 20);
            this.btHistoryPath.TabIndex = 12;
            this.btHistoryPath.Text = ". . .";
            this.btHistoryPath.UseVisualStyleBackColor = true;
            this.btHistoryPath.Click += new System.EventHandler(this.btHistoryPath_Click);
            // 
            // txHistoryPath
            // 
            this.txHistoryPath.Enabled = false;
            this.txHistoryPath.Location = new System.Drawing.Point(15, 273);
            this.txHistoryPath.Name = "txHistoryPath";
            this.txHistoryPath.Size = new System.Drawing.Size(502, 20);
            this.txHistoryPath.TabIndex = 11;
            // 
            // lbHistoryPath
            // 
            this.lbHistoryPath.AutoSize = true;
            this.lbHistoryPath.Location = new System.Drawing.Point(15, 255);
            this.lbHistoryPath.Name = "lbHistoryPath";
            this.lbHistoryPath.Size = new System.Drawing.Size(414, 13);
            this.lbHistoryPath.TabIndex = 10;
            this.lbHistoryPath.Text = "Los archivos creados en en la carpeta de transmisión pasan aquí una vez procesado" +
    "s";
            // 
            // btXmlPath
            // 
            this.btXmlPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btXmlPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXmlPath.Location = new System.Drawing.Point(522, 219);
            this.btXmlPath.Name = "btXmlPath";
            this.btXmlPath.Size = new System.Drawing.Size(36, 20);
            this.btXmlPath.TabIndex = 9;
            this.btXmlPath.Text = ". . .";
            this.btXmlPath.UseVisualStyleBackColor = true;
            this.btXmlPath.Click += new System.EventHandler(this.btXmlPath_Click);
            // 
            // txXmlPath
            // 
            this.txXmlPath.Enabled = false;
            this.txXmlPath.Location = new System.Drawing.Point(15, 219);
            this.txXmlPath.Name = "txXmlPath";
            this.txXmlPath.Size = new System.Drawing.Size(502, 20);
            this.txXmlPath.TabIndex = 8;
            // 
            // lbXmlPath
            // 
            this.lbXmlPath.AutoSize = true;
            this.lbXmlPath.Location = new System.Drawing.Point(15, 201);
            this.lbXmlPath.Name = "lbXmlPath";
            this.lbXmlPath.Size = new System.Drawing.Size(488, 13);
            this.lbXmlPath.TabIndex = 7;
            this.lbXmlPath.Text = "Copia de los XML generados a partir de un CSV y envíados a la AEAT se almacenará " +
    "en esta carpeta";
            // 
            // ckTest
            // 
            this.ckTest.AutoSize = true;
            this.ckTest.Location = new System.Drawing.Point(20, 163);
            this.ckTest.Name = "ckTest";
            this.ckTest.Size = new System.Drawing.Size(422, 17);
            this.ckTest.TabIndex = 6;
            this.ckTest.Text = "Modo pruebas de la AEAT activado. Los envíos se harán en el entorno de pruebas.";
            this.ckTest.UseVisualStyleBackColor = true;
            // 
            // btInbox
            // 
            this.btInbox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btInbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInbox.Location = new System.Drawing.Point(522, 118);
            this.btInbox.Name = "btInbox";
            this.btInbox.Size = new System.Drawing.Size(36, 20);
            this.btInbox.TabIndex = 5;
            this.btInbox.Text = ". . .";
            this.btInbox.UseVisualStyleBackColor = true;
            this.btInbox.Click += new System.EventHandler(this.btInbox_Click);
            // 
            // txInbox
            // 
            this.txInbox.Enabled = false;
            this.txInbox.Location = new System.Drawing.Point(15, 118);
            this.txInbox.Name = "txInbox";
            this.txInbox.Size = new System.Drawing.Size(502, 20);
            this.txInbox.TabIndex = 4;
            // 
            // lbInbox
            // 
            this.lbInbox.AutoSize = true;
            this.lbInbox.Location = new System.Drawing.Point(12, 101);
            this.lbInbox.Name = "lbInbox";
            this.lbInbox.Size = new System.Drawing.Size(482, 13);
            this.lbInbox.TabIndex = 3;
            this.lbInbox.Text = "Las respuestas de la AEAT a los envíos y los resumenes de resultados se guardarán" +
    " en esta carpeta";
            // 
            // btOutbox
            // 
            this.btOutbox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOutbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOutbox.Location = new System.Drawing.Point(522, 75);
            this.btOutbox.Name = "btOutbox";
            this.btOutbox.Size = new System.Drawing.Size(36, 20);
            this.btOutbox.TabIndex = 2;
            this.btOutbox.Text = ". . .";
            this.btOutbox.UseVisualStyleBackColor = true;
            this.btOutbox.Click += new System.EventHandler(this.btOutbox_Click);
            // 
            // txOutbox
            // 
            this.txOutbox.Enabled = false;
            this.txOutbox.Location = new System.Drawing.Point(15, 75);
            this.txOutbox.Name = "txOutbox";
            this.txOutbox.Size = new System.Drawing.Size(502, 20);
            this.txOutbox.TabIndex = 3;
            // 
            // lbOutbox
            // 
            this.lbOutbox.AutoSize = true;
            this.lbOutbox.Location = new System.Drawing.Point(12, 57);
            this.lbOutbox.Name = "lbOutbox";
            this.lbOutbox.Size = new System.Drawing.Size(417, 13);
            this.lbOutbox.TabIndex = 99;
            this.lbOutbox.Text = "Los archivos XML o CSV que se guarden en esta carpeta serán transmitidos a la AEA" +
    "T";
            // 
            // tbOptions
            // 
            this.tbOptions.Controls.Add(this.lblInfoCertStore);
            this.tbOptions.Controls.Add(this.grdCertificates);
            this.tbOptions.Location = new System.Drawing.Point(4, 22);
            this.tbOptions.Name = "tbOptions";
            this.tbOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tbOptions.Size = new System.Drawing.Size(613, 361);
            this.tbOptions.TabIndex = 1;
            this.tbOptions.Text = "Certificado almacén de windows";
            this.tbOptions.UseVisualStyleBackColor = true;
            // 
            // lblInfoCertStore
            // 
            this.lblInfoCertStore.BackColor = System.Drawing.Color.White;
            this.lblInfoCertStore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfoCertStore.Location = new System.Drawing.Point(9, 7);
            this.lblInfoCertStore.Name = "lblInfoCertStore";
            this.lblInfoCertStore.Padding = new System.Windows.Forms.Padding(5);
            this.lblInfoCertStore.Size = new System.Drawing.Size(592, 46);
            this.lblInfoCertStore.TabIndex = 9;
            this.lblInfoCertStore.Text = resources.GetString("lblInfoCertStore.Text");
            // 
            // grdCertificates
            // 
            this.grdCertificates.AllowUserToAddRows = false;
            this.grdCertificates.AllowUserToDeleteRows = false;
            this.grdCertificates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCertificates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Thumbprint,
            this.SubjectName,
            this.IssuerName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCertificates.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdCertificates.Location = new System.Drawing.Point(9, 68);
            this.grdCertificates.MultiSelect = false;
            this.grdCertificates.Name = "grdCertificates";
            this.grdCertificates.RowHeadersVisible = false;
            this.grdCertificates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCertificates.Size = new System.Drawing.Size(592, 252);
            this.grdCertificates.TabIndex = 0;
            // 
            // Thumbprint
            // 
            this.Thumbprint.HeaderText = "Thumbprint";
            this.Thumbprint.Name = "Thumbprint";
            this.Thumbprint.Visible = false;
            this.Thumbprint.Width = 200;
            // 
            // SubjectName
            // 
            this.SubjectName.HeaderText = "SubjectName";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.Width = 275;
            // 
            // IssuerName
            // 
            this.IssuerName.HeaderText = "IssuerName";
            this.IssuerName.Name = "IssuerName";
            this.IssuerName.Width = 275;
            // 
            // txTaxID
            // 
            this.txTaxID.Location = new System.Drawing.Point(15, 30);
            this.txTaxID.Name = "txTaxID";
            this.txTaxID.Size = new System.Drawing.Size(113, 20);
            this.txTaxID.TabIndex = 21;
            this.txTaxID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txTaxID_KeyDown);
            // 
            // txName
            // 
            this.txName.Location = new System.Drawing.Point(134, 30);
            this.txName.Name = "txName";
            this.txName.Size = new System.Drawing.Size(465, 20);
            this.txName.TabIndex = 1;
            // 
            // lbTaxID
            // 
            this.lbTaxID.AutoSize = true;
            this.lbTaxID.Location = new System.Drawing.Point(17, 14);
            this.lbTaxID.Name = "lbTaxID";
            this.lbTaxID.Size = new System.Drawing.Size(103, 13);
            this.lbTaxID.TabIndex = 0;
            this.lbTaxID.Text = "NIF empresa envíos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Nombre empresa envíos";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 387);
            this.Controls.Add(this.tbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MONITOR COMUNICACIONES SII AEAT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.Shown += new System.EventHandler(this.formMain_Shown);
            this.tbMain.ResumeLayout(false);
            this.tbGeneral.ResumeLayout(false);
            this.tbGeneral.PerformLayout();
            this.tbOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCertificates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tbGeneral;
        private System.Windows.Forms.Button btOutbox;
        private System.Windows.Forms.TextBox txOutbox;
        private System.Windows.Forms.Label lbOutbox;
        private System.Windows.Forms.TabPage tbOptions;
        private System.Windows.Forms.Button btInbox;
        private System.Windows.Forms.TextBox txInbox;
        private System.Windows.Forms.Label lbInbox;
        private System.Windows.Forms.CheckBox ckTest;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenDir;
        private System.Windows.Forms.Button btXmlPath;
        private System.Windows.Forms.TextBox txXmlPath;
        private System.Windows.Forms.Label lbXmlPath;
        private System.Windows.Forms.Button btHistoryPath;
        private System.Windows.Forms.TextBox txHistoryPath;
        private System.Windows.Forms.Label lbHistoryPath;
        private System.Windows.Forms.Button btLogPath;
        private System.Windows.Forms.TextBox txLogPath;
        private System.Windows.Forms.Label lbLogPath;
        private System.Windows.Forms.DataGridView grdCertificates;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thumbprint;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssuerName;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.Label lblInfoCertStore;
        private System.Windows.Forms.Button btOutboxOpen;
        private System.Windows.Forms.Button btLogPathOpen;
        private System.Windows.Forms.Button btHistoryPathOpen;
        private System.Windows.Forms.Button btXmlPathOpen;
        private System.Windows.Forms.Button btInboxOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTaxID;
        private System.Windows.Forms.TextBox txName;
        private System.Windows.Forms.TextBox txTaxID;
    }
}