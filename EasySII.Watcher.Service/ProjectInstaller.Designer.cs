namespace EasySII.Watcher.Service
{
	/// <summary>
	/// Instalador del servicio de windows.
	/// </summary>
	partial class ProjectInstaller
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.EasySIIWProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.EasySIIWInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // EasySIIWProcessInstaller
            // 
            this.EasySIIWProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.EasySIIWProcessInstaller.Password = null;
            this.EasySIIWProcessInstaller.Username = null;
            // 
            // EasySIIWInstaller
            // 
            this.EasySIIWInstaller.Description = "Monitor de directorios de EasySII";
            this.EasySIIWInstaller.DisplayName = "Monitor de directorios de EasySII";
            this.EasySIIWInstaller.ServiceName = "Monitor de carpetas de EasySII";
            this.EasySIIWInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.EasySIIWInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.EasySIIWInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.EasySIIWProcessInstaller,
            this.EasySIIWInstaller});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller EasySIIWProcessInstaller;
		private System.ServiceProcess.ServiceInstaller EasySIIWInstaller;
	}
}