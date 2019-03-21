using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MPIS_Grupa11
{
    public partial class MainForm : Form
    {
        DrawingWindow JednopolnaShema;
        SignalsWindow TrenutniTSA;
        SignalsWindow TrenutniTSB;
        SignalsWindow SviTSA;
        SignalsWindow SviTSB;

        Rastavljac TSA_SG_Rastavljac;
        Rastavljac TSA_SP_Rastavljac;
        Prekidac TSA_Prekidac;
        Rastavljac TSA_IzlazniRastavljac;
        Rastavljac TSA_UzemljenjaRastavljac;
        APU TSA_APU;
        Zastita TSA_Nadstrujna;

        Rastavljac TSB_S1_Rastavljac;
        Prekidac TSB_Prekidac;
        Rastavljac TSB_IzlazniRastavljac;
        Rastavljac TSB_UzemljenjaRastavljac;
        APU TSB_APU;
        Zastita TSB_Nadstrujna;

        Dalekovod DV;

        public MainForm()
        {
            InitializeComponent();

            TSA_SG_Rastavljac = new Rastavljac();
            TSA_SP_Rastavljac = new Rastavljac();
            TSA_Prekidac = new Prekidac();
            TSA_IzlazniRastavljac = new Rastavljac();
            TSA_UzemljenjaRastavljac = new Rastavljac();
            TSA_APU = new APU();
            TSA_Nadstrujna = new Zastita();

            TSB_S1_Rastavljac = new Rastavljac();
            TSB_Prekidac = new Prekidac();
            TSB_IzlazniRastavljac = new Rastavljac();
            TSB_UzemljenjaRastavljac = new Rastavljac();
            TSB_APU = new APU();
            TSB_Nadstrujna = new Zastita();

            DV = new Dalekovod();

            MainDockPanel.Theme = VS2015BlueTheme;
            MainToolStripExtender.SetStyle(this.MainToolStrip, VisualStudioToolStripExtender.VsVersion.Vs2015, VS2015BlueTheme);

            TrenutniTSA = new SignalsWindow
            {
                Text = "Trenutni Signali TS-A"
            };

            TrenutniTSB = new SignalsWindow
            {
                Text = "Trenutni Signali TS-B"
            };

            SviTSA = new SignalsWindow
            {
                Text = "Svi Signali TS-A"
            };

            SviTSB = new SignalsWindow
            {
                Text = "Svi Signali TS-B"
            };

            JednopolnaShema = new DrawingWindow
            {
                Text = "Jednopolna shema / Kontrola",
                TSA_SG_Rastavljac = TSA_SG_Rastavljac,
                TSA_SP_Rastavljac = TSA_SP_Rastavljac,
                TSA_Prekidac = TSA_Prekidac,
                TSA_IzlazniRastavljac = TSA_IzlazniRastavljac,
                TSA_UzemljenjaRastavljac = TSA_UzemljenjaRastavljac,
                TSA_APU = TSA_APU,
                TSA_Nadstrujna = TSA_Nadstrujna,

                TSB_S1_Rastavljac = TSB_S1_Rastavljac,
                TSB_Prekidac = TSB_Prekidac,
                TSB_IzlazniRastavljac = TSB_IzlazniRastavljac,
                TSB_UzemljenjaRastavljac = TSB_UzemljenjaRastavljac,
                TSB_APU = TSB_APU,
                TSB_Nadstrujna = TSB_Nadstrujna,

                DV = DV,

                TrenutniTSA = TrenutniTSA,
                TrenutniTSB = TrenutniTSB,
                SviTSA = SviTSA,
                SviTSB = SviTSB
            };
            
            JednopolnaShema.Show(MainDockPanel, DockState.Document);
            TrenutniTSA.Show(JednopolnaShema.Pane, DockAlignment.Right, 0.5);
            TrenutniTSB.Show(TrenutniTSA.Pane, DockAlignment.Bottom, 0.5);
            SviTSA.Show(TrenutniTSA.Pane, null);
            SviTSB.Show(TrenutniTSB.Pane, null);
        }

        private void DrawingWindowToolStrip_Click(object sender, EventArgs e)
        {
            JednopolnaShema.Show(MainDockPanel);
        }

        private void TrenutniSignaliTSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrenutniTSA.Show(MainDockPanel);
        }

        private void TrenutniSignaliTSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrenutniTSB.Show(MainDockPanel);
        }

        private void SviSignaliTSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SviTSA.Show(MainDockPanel);
        }

        private void SviSignaliTSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SviTSB.Show(MainDockPanel);
        }

        private void OProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Postrojenje V0.1\n\nIzradili:\nIvan Jandrić\nErnest Subotić\nNikolas Škrlj", "O Programu",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show(DV.GetStanje().ToString());
        }

        private void IzlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
