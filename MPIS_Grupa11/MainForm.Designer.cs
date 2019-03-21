namespace MPIS_Grupa11
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.MainDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.VS2015BlueTheme = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            this.MainToolStripExtender = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.MainToolStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izlazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawingWindowToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.trenutniSignaliTSAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trenutniSignaliTSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sviSignaliTSAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sviSignaliTSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainDockPanel
            // 
            this.MainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDockPanel.Location = new System.Drawing.Point(0, 24);
            this.MainDockPanel.Name = "MainDockPanel";
            this.MainDockPanel.Size = new System.Drawing.Size(1350, 705);
            this.MainDockPanel.TabIndex = 4;
            // 
            // MainToolStripExtender
            // 
            this.MainToolStripExtender.DefaultRenderer = null;
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ViewToolStripMenuItem});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(1350, 24);
            this.MainToolStrip.TabIndex = 10;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramuToolStripMenuItem,
            this.izlazToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.FileToolStripMenuItem.Text = "Polazno";
            // 
            // oProgramuToolStripMenuItem
            // 
            this.oProgramuToolStripMenuItem.Name = "oProgramuToolStripMenuItem";
            this.oProgramuToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.oProgramuToolStripMenuItem.Text = "O Programu";
            this.oProgramuToolStripMenuItem.Click += new System.EventHandler(this.OProgramuToolStripMenuItem_Click);
            // 
            // izlazToolStripMenuItem
            // 
            this.izlazToolStripMenuItem.Name = "izlazToolStripMenuItem";
            this.izlazToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.izlazToolStripMenuItem.Text = "Izlaz";
            this.izlazToolStripMenuItem.Click += new System.EventHandler(this.IzlazToolStripMenuItem_Click);
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DrawingWindowToolStrip,
            this.trenutniSignaliTSAToolStripMenuItem,
            this.trenutniSignaliTSBToolStripMenuItem,
            this.sviSignaliTSAToolStripMenuItem,
            this.sviSignaliTSBToolStripMenuItem});
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ViewToolStripMenuItem.Text = "Prikaz";
            // 
            // DrawingWindowToolStrip
            // 
            this.DrawingWindowToolStrip.Name = "DrawingWindowToolStrip";
            this.DrawingWindowToolStrip.Size = new System.Drawing.Size(186, 22);
            this.DrawingWindowToolStrip.Text = "Jednopolna Shema";
            this.DrawingWindowToolStrip.Click += new System.EventHandler(this.DrawingWindowToolStrip_Click);
            // 
            // trenutniSignaliTSAToolStripMenuItem
            // 
            this.trenutniSignaliTSAToolStripMenuItem.Name = "trenutniSignaliTSAToolStripMenuItem";
            this.trenutniSignaliTSAToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.trenutniSignaliTSAToolStripMenuItem.Text = "Trenutni Signali TS-A";
            this.trenutniSignaliTSAToolStripMenuItem.Click += new System.EventHandler(this.TrenutniSignaliTSAToolStripMenuItem_Click);
            // 
            // trenutniSignaliTSBToolStripMenuItem
            // 
            this.trenutniSignaliTSBToolStripMenuItem.Name = "trenutniSignaliTSBToolStripMenuItem";
            this.trenutniSignaliTSBToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.trenutniSignaliTSBToolStripMenuItem.Text = "Trenutni Signali TS-B";
            this.trenutniSignaliTSBToolStripMenuItem.Click += new System.EventHandler(this.TrenutniSignaliTSBToolStripMenuItem_Click);
            // 
            // sviSignaliTSAToolStripMenuItem
            // 
            this.sviSignaliTSAToolStripMenuItem.Name = "sviSignaliTSAToolStripMenuItem";
            this.sviSignaliTSAToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.sviSignaliTSAToolStripMenuItem.Text = "Svi Signali TS-A";
            this.sviSignaliTSAToolStripMenuItem.Click += new System.EventHandler(this.SviSignaliTSAToolStripMenuItem_Click);
            // 
            // sviSignaliTSBToolStripMenuItem
            // 
            this.sviSignaliTSBToolStripMenuItem.Name = "sviSignaliTSBToolStripMenuItem";
            this.sviSignaliTSBToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.sviSignaliTSBToolStripMenuItem.Text = "Svi Signali TS-B";
            this.sviSignaliTSBToolStripMenuItem.Click += new System.EventHandler(this.SviSignaliTSBToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.MainDockPanel);
            this.Controls.Add(this.MainToolStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainToolStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postrojenje";
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private WeifenLuo.WinFormsUI.Docking.DockPanel MainDockPanel;
        private WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme VS2015BlueTheme;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender MainToolStripExtender;
        private System.Windows.Forms.MenuStrip MainToolStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DrawingWindowToolStrip;
        private System.Windows.Forms.ToolStripMenuItem trenutniSignaliTSAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trenutniSignaliTSBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sviSignaliTSAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sviSignaliTSBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izlazToolStripMenuItem;
    }
}

