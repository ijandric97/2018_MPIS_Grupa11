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
    public partial class AllSignalsWindow : DockContent
    {
        public AllSignalsWindow()
        {
            InitializeComponent();
        }

        //TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "neusmjerena zemljospojna", "kvar signal", Color.Red);
        public void DodajSignal(string Postrojenje, string Napon, string Uredaj, string Varijabla, string Stanje, Color Boja, string Dodatno = "")
        {
            ListViewItem TempItem = new ListViewItem
            {
                ForeColor = Boja,
                Text = DateTime.Now.ToString(@"dd.MM.yyyy. - HH:mm:ss")
            };
            TempItem.SubItems.Add(Postrojenje);
            TempItem.SubItems.Add(Napon);
            TempItem.SubItems.Add(Uredaj);
            TempItem.SubItems.Add(Varijabla);
            TempItem.SubItems.Add(Stanje);
            TempItem.SubItems.Add(Dodatno);
            SignalListView.Items.Insert(0, TempItem);
        }
    }
}
