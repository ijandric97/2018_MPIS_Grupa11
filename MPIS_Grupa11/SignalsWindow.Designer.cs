namespace MPIS_Grupa11
{
    partial class SignalsWindow
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
            this.SignalListView = new System.Windows.Forms.ListView();
            this.Vrijeme = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Postrojenje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Napon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Uredaj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Varijabla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stanje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dodatno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // SignalListView
            // 
            this.SignalListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Vrijeme,
            this.Postrojenje,
            this.Napon,
            this.Uredaj,
            this.Varijabla,
            this.Stanje,
            this.Dodatno});
            this.SignalListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SignalListView.Location = new System.Drawing.Point(0, 0);
            this.SignalListView.Name = "SignalListView";
            this.SignalListView.Size = new System.Drawing.Size(971, 261);
            this.SignalListView.TabIndex = 0;
            this.SignalListView.UseCompatibleStateImageBehavior = false;
            this.SignalListView.View = System.Windows.Forms.View.Details;
            // 
            // Vrijeme
            // 
            this.Vrijeme.Text = "Vrijeme";
            this.Vrijeme.Width = 119;
            // 
            // Postrojenje
            // 
            this.Postrojenje.Text = "Postrojenje";
            this.Postrojenje.Width = 64;
            // 
            // Napon
            // 
            this.Napon.Text = "Napon [kV]";
            this.Napon.Width = 66;
            // 
            // Uredaj
            // 
            this.Uredaj.Text = "Uređaj";
            this.Uredaj.Width = 122;
            // 
            // Varijabla
            // 
            this.Varijabla.Text = "Naziv Varijable";
            this.Varijabla.Width = 85;
            // 
            // Stanje
            // 
            this.Stanje.Text = "Stanje Varijable";
            this.Stanje.Width = 92;
            // 
            // Dodatno
            // 
            this.Dodatno.Text = "Dodatno";
            this.Dodatno.Width = 169;
            // 
            // SignalsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 261);
            this.Controls.Add(this.SignalListView);
            this.HideOnClose = true;
            this.Name = "SignalsWindow";
            this.Text = "Signali";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView SignalListView;
        private System.Windows.Forms.ColumnHeader Vrijeme;
        private System.Windows.Forms.ColumnHeader Postrojenje;
        private System.Windows.Forms.ColumnHeader Napon;
        private System.Windows.Forms.ColumnHeader Uredaj;
        private System.Windows.Forms.ColumnHeader Varijabla;
        private System.Windows.Forms.ColumnHeader Stanje;
        private System.Windows.Forms.ColumnHeader Dodatno;
    }
}