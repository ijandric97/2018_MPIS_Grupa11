using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MPIS_Grupa11
{
    public partial class DrawingWindow : DockContent
    {
        internal Prekidac TSA_Prekidac { get; set; }
        internal APU TSA_APU { get; set; }
        internal Rastavljac TSA_SG_Rastavljac { get; set; }
        internal Rastavljac TSA_SP_Rastavljac { get; set; }
        internal Rastavljac TSA_IzlazniRastavljac { get; set; }
        internal Rastavljac TSA_UzemljenjaRastavljac { get; set; }
        internal Rastavljac TSB_S1_Rastavljac { get; set; }
        public Prekidac TSB_Prekidac { get; internal set; }
        internal Rastavljac TSB_IzlazniRastavljac { get; set; }
        internal Rastavljac TSB_UzemljenjaRastavljac { get; set; }
        internal APU TSB_APU { get; set; }
        internal Dalekovod DV { get; set; }
        internal Zastita TSB_Nadstrujna { get; set; }
        internal Zastita TSA_Nadstrujna { get; set; }
        public SignalsWindow TrenutniTSA { get; internal set; }
        public SignalsWindow TrenutniTSB { get; internal set; }
        public SignalsWindow SviTSA { get; internal set; }
        public SignalsWindow SviTSB { get; internal set; }

        public DrawingWindow()
        {
            InitializeComponent();

            BGWorker.RunWorkerAsync();
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            Graphics g = e.Graphics;

            //Boje za Linije
            Pen GreenPen = new Pen(Color.Green, 4);
            Pen DarkRedPen = new Pen(Color.DarkRed, 4);

            //Boje za Elemente
            Pen LimePen = new Pen(Color.Lime, 4);
            Pen RedPen = new Pen(Color.Red, 4);
            Pen OrangePen = new Pen(Color.Orange, 4);

            //Boje i Font za Tekst
            Font Font = new Font("Terminal", 16);
            SolidBrush DodgerBlue = new SolidBrush(Color.DodgerBlue);
            SolidBrush CrimsonBrush = new SolidBrush(Color.Crimson);
            SolidBrush LimeGreenBrush = new SolidBrush(Color.LimeGreen);

            #region Crtanje TS-A
            g.DrawString("TS-A", Font, DodgerBlue, 155, 5); //Crtanje imena TS-A
            g.DrawString("SG",   Font, DodgerBlue, 10, 25); //Crtanje SG teksta
            g.DrawString("SP",   Font, DodgerBlue, 10, 45); //Crtanje SP teksta 
            
            g.DrawLine(GreenPen, 50, 35, 300, 35); //Crtanje SG linije
            g.DrawLine(GreenPen, 50, 55, 300, 55); //Crtanje SP linije

            //Crtanje SG linije do Prekidaca ovisno o SG rastavljacu
            if (TSA_SG_Rastavljac.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 100, 35, 100, 95); //Crtanje SG linije do prekidaca
                g.DrawLine(GreenPen, 100, 95, 100, 155); //SG
                g.DrawLine(GreenPen, 100, 155, 175, 155);
            }
            else
            {
                g.DrawLine(DarkRedPen, 100, 35, 100, 95); //Crtanje SG linije do prekidaca
                g.DrawLine(DarkRedPen, 100, 95, 100, 155); //SG
                g.DrawLine(DarkRedPen, 100, 155, 175, 155);
            }
            //Crtanje SP linije do Prekidaca ovisno o SP rastavljacu
            if (TSA_SP_Rastavljac.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 250, 55, 250, 95); //Crtanje SP linije do prekidaca
                g.DrawLine(GreenPen, 250, 95, 250, 155); //SP
                g.DrawLine(GreenPen, 175, 155, 250, 155);
            }
            else
            {
                g.DrawLine(DarkRedPen, 250, 55, 250, 95); //Crtanje SP linije do prekidaca
                g.DrawLine(DarkRedPen, 250, 95, 250, 155); //SP
                g.DrawLine(DarkRedPen, 175, 155, 250, 155);
            }
            //Crtanje srednje linije SP/SG do prekidaca
            if (TSA_SG_Rastavljac.GetStanje() == 1 || TSA_SP_Rastavljac.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 175, 155, 175, 200); //Srednja Linija
            }
            else
            {
                g.DrawLine(DarkRedPen, 175, 155, 175, 200); //Srednja Linija
            }
            //Crtanje Linije do Izlaznog rastavljača
            if (TSA_Prekidac.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 175, 200, 175, 270);
            }
            else
            {
                g.DrawLine(DarkRedPen, 175, 200, 175, 270);
            }
            //Crtanje linije ispod Rastavljaca uzemljenja
            if (TSA_IzlazniRastavljac.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 175, 270, 175, 320); //Dolje1
            }
            else
            {
                g.DrawLine(DarkRedPen, 175, 270, 175, 320); //Dolje1
            }  
            //Crtanje linije do Rastavljaca uzemljenja
            if (TSA_UzemljenjaRastavljac.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 175, 320, 230, 320); //Desno1
                g.DrawLine(GreenPen, 230, 320, 280, 320); //Desno2
            }
            else
            {
                g.DrawLine(DarkRedPen, 175, 320, 230, 320); //Desno1
                g.DrawLine(DarkRedPen, 230, 320, 280, 320); //Desno2
            }    

            //Crtanje Rastavljaca SG
            switch (TSA_SG_Rastavljac.GetStanje())
            {
                case 0:
                    g.DrawLine(RedPen, 100 - 25, 95 + 10, 100 + 25, 95 - 10);
                    break;
                case 1:
                    g.DrawLine(LimePen, 100 - 25, 95 + 10, 100 + 25, 95 - 10);
                    break;
                default:
                    g.DrawLine(OrangePen, 100 - 25, 95 + 10, 100 + 25, 95 - 10);
                    break;
            }
            //Crtanje Rastavljaca SP
            switch (TSA_SP_Rastavljac.GetStanje())
            {
                case 0:
                    g.DrawLine(RedPen, 250 - 25, 95 + 10, 250 + 25, 95 - 10);
                    break;
                case 1:
                    g.DrawLine(LimePen, 250 - 25, 95 + 10, 250 + 25, 95 - 10);
                    break;
                default:
                    g.DrawLine(OrangePen, 250 - 25, 95 + 10, 250 + 25, 95 - 10);
                    break;
            }
            //Crtanje Prekidaca TS-A
            switch (TSA_Prekidac.GetStanje())
            {
                case 0:
                    g.DrawLine(RedPen, 175 - 25, 200 + 10, 175 + 25, 200 - 10);
                    g.DrawLine(RedPen, 175 - 25, 200 - 10, 175 + 25, 200 + 10);
                    break;
                case 1:
                    g.DrawLine(LimePen, 175 - 25, 200 + 10, 175 + 25, 200 - 10);
                    g.DrawLine(LimePen, 175 - 25, 200 - 10, 175 + 25, 200 + 10);
                    break;
                default:
                    g.DrawLine(OrangePen, 175 - 25, 200 + 10, 175 + 25, 200 - 10);
                    g.DrawLine(OrangePen, 175 - 25, 200 - 10, 175 + 25, 200 + 10);
                    break;
            }
            //Crtanje Izlaznog Rastavljaca
            switch (TSA_IzlazniRastavljac.GetStanje())
            {
                case 0:
                    g.DrawLine(RedPen, 175 - 25, 270 + 10, 175 + 25, 270 - 10);
                    break;
                case 1:
                    g.DrawLine(LimePen, 175 - 25, 270 + 10, 175 + 25, 270 - 10);
                    break;
                default:
                    g.DrawLine(OrangePen, 175 - 25, 270 + 10, 175 + 25, 270 - 10);
                    break;
            }         
            //Crtanje Rastavljaca Uzemljenja
            switch (TSA_UzemljenjaRastavljac.GetStanje())
            {
                case 0:
                    g.DrawLine(RedPen, 230 - 10, 320 - 25, 230 + 10, 320 + 25);
                    g.DrawLine(RedPen, 280, 320 - 25, 280, 320 + 25);
                    g.DrawLine(RedPen, 287, 320 - 15, 287, 320 + 15);
                    g.DrawLine(RedPen, 294, 320 - 5, 294, 320 + 5);
                    break;
                case 1:
                    g.DrawLine(LimePen, 230 - 10, 320 - 25, 230 + 10, 320 + 25);
                    g.DrawLine(LimePen, 280, 320 - 25, 280, 320 + 25);
                    g.DrawLine(LimePen, 287, 320 - 15, 287, 320 + 15);
                    g.DrawLine(LimePen, 294, 320 - 5, 294, 320 + 5);
                    break;
                default:
                    g.DrawLine(OrangePen, 230 - 10, 320 - 25, 230 + 10, 320 + 25);
                    g.DrawLine(OrangePen, 280, 320 - 25, 280, 320 + 25);
                    g.DrawLine(OrangePen, 287, 320 - 15, 287, 320 + 15);
                    g.DrawLine(OrangePen, 294, 320 - 5, 294, 320 + 5);
                    break;
            }
            //Crtanje APU
            if (TSA_APU.GetStanje() == 1)
            {
                g.DrawString("APU", Font, LimeGreenBrush, 50, 190); //Crtanje APU
            }
            else
            {
                g.DrawString("APU", Font, CrimsonBrush, 50, 190); //Crtanje APU
            }
            //Crtanje zastite
            if (TSA_Nadstrujna.GetStanje() == 1)
            {
                g.DrawString("Nadstrujna", Font, LimeGreenBrush, 20, 210); //Crtanje Zastite
            }
            else
            {
                g.DrawString("Nadstrujna", Font, CrimsonBrush, 20, 210); //Crtanje Zastite
            }
            #endregion

            #region Crtanje TS-B
            g.DrawString("TS-B", Font, DodgerBlue, 455, 5); //Crtanje imena TS-B
            g.DrawString("S1",   Font, DodgerBlue, 612, 25); //Crtanje S1 teksta  

            g.DrawLine(GreenPen, 360, 35, 610, 35); //Crtanje S1 Linije

            //Crtanje S1 linije do prekidaca
            if (TSB_S1_Rastavljac.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 485, 35, 485, 200);
            }
            else
            {
                g.DrawLine(DarkRedPen, 485, 35, 485, 200);
            }
            //Crtanje Linije do Izlaznog rastavljača
            if (TSB_Prekidac.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 485, 200, 485, 270);
            }
            else
            {
                g.DrawLine(DarkRedPen, 485, 200, 485, 270);
            }
            //Crtanje linije ispod Rastavljaca uzemljenja
            if (TSB_IzlazniRastavljac.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 485, 270, 485, 320); //Dolje1
            }
            else
            {
                g.DrawLine(DarkRedPen, 485, 270, 485, 320); //Dolje1
            }
            //Crtanje linije do Rastavljaca uzemljenja
            if (TSB_UzemljenjaRastavljac.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 430, 320, 485, 320); //Lijevo1
                g.DrawLine(GreenPen, 380, 320, 430, 320); //Lijevo2
            }
            else
            {
                g.DrawLine(DarkRedPen, 430, 320, 485, 320); //Lijevo1
                g.DrawLine(DarkRedPen, 380, 320, 430, 320); //Lijevo2
            }

            //Crtanje Rastavljaca S1
            switch (TSB_S1_Rastavljac.GetStanje())
            {
                case 0:
                    g.DrawLine(RedPen, 485 - 25, 95 + 10, 485 + 25, 95 - 10);
                    break;
                case 1:
                    g.DrawLine(LimePen, 485 - 25, 95 + 10, 485 + 25, 95 - 10);
                    break;
                default:
                    g.DrawLine(OrangePen, 485 - 25, 95 + 10, 485 + 25, 95 - 10);
                    break;
            }
            //Crtanje Prekidaca TS-B
            switch (TSB_Prekidac.GetStanje())
            {
                case 0:
                    g.DrawLine(RedPen, 485 - 25, 200 + 10, 485 + 25, 200 - 10);
                    g.DrawLine(RedPen, 485 - 25, 200 - 10, 485 + 25, 200 + 10);
                    break;
                case 1:
                    g.DrawLine(LimePen, 485 - 25, 200 + 10, 485 + 25, 200 - 10);
                    g.DrawLine(LimePen, 485 - 25, 200 - 10, 485 + 25, 200 + 10);
                    break;
                default:
                    g.DrawLine(OrangePen, 485 - 25, 200 + 10, 485 + 25, 200 - 10);
                    g.DrawLine(OrangePen, 485 - 25, 200 - 10, 485 + 25, 200 + 10);
                    break;
            }
            //Crtanje Izlaznog Rastavljaca
            switch (TSB_IzlazniRastavljac.GetStanje())
            {
                case 0:
                    g.DrawLine(RedPen, 485 - 25, 270 + 10, 485 + 25, 270 - 10);
                    break;
                case 1:
                    g.DrawLine(LimePen, 485 - 25, 270 + 10, 485 + 25, 270 - 10);
                    break;
                default:
                    g.DrawLine(OrangePen, 485 - 25, 270 + 10, 485 + 25, 270 - 10);
                    break;
            }
            //Crtanje Rastavljaca Uzemljenja
            switch (TSB_UzemljenjaRastavljac.GetStanje())
            {
                case 0:
                    g.DrawLine(RedPen, 430 - 10, 320 - 25, 430 + 10, 320 + 25);
                    g.DrawLine(RedPen, 380, 320 - 25, 380, 320 + 25);
                    g.DrawLine(RedPen, 373, 320 - 15, 373, 320 + 15);
                    g.DrawLine(RedPen, 366, 320 - 5, 366, 320 + 5);
                    break;
                case 1:
                    g.DrawLine(LimePen, 430 - 10, 320 - 25, 430 + 10, 320 + 25);
                    g.DrawLine(LimePen, 380, 320 - 25, 380, 320 + 25);
                    g.DrawLine(LimePen, 373, 320 - 15, 373, 320 + 15);
                    g.DrawLine(LimePen, 366, 320 - 5, 366, 320 + 5);
                    break;
                default:
                    g.DrawLine(OrangePen, 430 - 10, 320 - 25, 430 + 10, 320 + 25);
                    g.DrawLine(OrangePen, 380, 320 - 25, 380, 320 + 25);
                    g.DrawLine(OrangePen, 373, 320 - 15, 373, 320 + 15);
                    g.DrawLine(OrangePen, 366, 320 - 5, 366, 320 + 5);
                    break;
            }
            //Crtanje APU
            if (TSB_APU.GetStanje() == 1)
            {
                g.DrawString("APU", Font, LimeGreenBrush, 560, 190); //Crtanje APU
            }
            else
            {
                g.DrawString("APU", Font, CrimsonBrush, 560, 190); //Crtanje APU
            }
            //Crtanje zastite
            if (TSB_Nadstrujna.GetStanje() == 1)
            {
                g.DrawString("Nadstrujna", Font, LimeGreenBrush, 530, 210); //Crtanje Zastite
            }
            else
            {
                g.DrawString("Nadstrujna", Font, CrimsonBrush, 530, 210); //Crtanje Zastite
            }
            #endregion

            #region Crtanje DV
            if ((TSA_SG_Rastavljac.GetStanje() == 1 || TSA_SP_Rastavljac.GetStanje() == 1)
                    && TSA_Prekidac.GetStanje() == 1 && TSA_IzlazniRastavljac.GetStanje() == 1
                    && TSB_IzlazniRastavljac.GetStanje() == 1 && TSB_Prekidac.GetStanje() == 1
                    && TSB_S1_Rastavljac.GetStanje() == 1)
            {
                if (DV.GetStanje() == 0)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "DV-JSŠ", "stanje", "uključen", Color.Green, "");
                    TrenutniTSB.DodajSignal("TS-B", "220", "DV-JSŠ", "stanje", "uključen", Color.Green, "");
                }
                DV.Uklop();
            }
            else
            {
                if (DV.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "DV-JSŠ", "stanje", "isključen", Color.Red, "");
                    TrenutniTSB.DodajSignal("TS-B", "220", "DV-JSŠ", "stanje", "isključen", Color.Red, "");
                }
                DV.Isklop();
            }

            if (DV.GetStanje() == 1)
            {
                g.DrawLine(GreenPen, 175, 320, 175, 420); //Dolje2 tsa
                g.DrawLine(GreenPen, 485, 320, 485, 420); //Dolje2 tsb
                g.DrawString("DV-JSŠ", Font, LimeGreenBrush, 290, 425); //Crtanje imena DV-JSŠ
                g.DrawLine(GreenPen, 175, 420, 485, 420);
            }
            else
            {
                g.DrawLine(DarkRedPen, 175, 320, 175, 420); //Dolje2 tsa
                g.DrawLine(DarkRedPen, 485, 320, 485, 420); //Dolje2 tsb
                g.DrawString("DV-JSŠ", Font, CrimsonBrush, 290, 425); //Crtanje imena DV-JSŠ
                g.DrawLine(DarkRedPen, 175, 420, 485, 420);
            }
            #endregion
            SviSignali();
        }

        private void SviSignali()
        {
            SviTSA.ObrisiSignale();
            if (TSA_SG_Rastavljac.GetStanje() == 1)
            {
                SviTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "komanda", "uklop", Color.Black);
                SviTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "komanda", "isklop", Color.Black);
                SviTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "stanje", "isključeno", Color.Black, "");
            }
            if (TSA_SP_Rastavljac.GetStanje() == 1)
            {
                SviTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "komanda", "uklop", Color.Black);
                SviTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "komanda", "isklop", Color.Black);
                SviTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "stanje", "isključeno", Color.Black, "");
            }
            if (TSA_Prekidac.GetStanje() == 1)
            {
                SviTSA.DodajSignal("TS-A", "220", "prekidač", "komanda", "uklop", Color.Black, "");
                SviTSA.DodajSignal("TS-A", "220", "prekidač", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSA.DodajSignal("TS-A", "220", "prekidač", "komanda", "isklop", Color.Black, "");
                SviTSA.DodajSignal("TS-A", "220", "prekidač", "stanje", "isključeno", Color.Black, "");
            }
            if (TSA_IzlazniRastavljac.GetStanje() == 1)
            {
                SviTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "komanda", "uklop", Color.Black);
                SviTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "komanda", "isklop", Color.Black);
                SviTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "stanje", "isključeno", Color.Black, "");
            }
            if (TSA_UzemljenjaRastavljac.GetStanje() == 1)
            {
                SviTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "komanda", "uklop", Color.Black);
                SviTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "komanda", "isklop", Color.Black);
                SviTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "stanje", "isključeno", Color.Black, "");
            }
            if (TSA_APU.GetStanje() == 1)
            {
                SviTSA.DodajSignal("TS-A", "220", "APU", "komanda", "uklop", Color.Black, "");
                SviTSA.DodajSignal("TS-A", "220", "APU", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSA.DodajSignal("TS-A", "220", "APU", "komanda", "isklop", Color.Black, "");
                SviTSA.DodajSignal("TS-A", "220", "APU", "stanje", "isključen", Color.Black, "");
            }
            if (TSA_Nadstrujna.GetStanje() == 1)
            {
                SviTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "komanda", "uklop", Color.Black, "");
                SviTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "komanda", "isklop", Color.Black, "");
                SviTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "stanje", "isključen", Color.Black, "");
            }

            if (DV.GetStanje() == 1)
            {
                SviTSA.DodajSignal("TS-A", "220", "DV-JSŠ", "stanje", "uključen", Color.Black, "");
                SviTSB.DodajSignal("TS-B", "220", "DV-JSŠ", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSA.DodajSignal("TS-A", "220", "DV-JSŠ", "stanje", "uključen", Color.Black, "");
                SviTSB.DodajSignal("TS-B", "220", "DV-JSŠ", "stanje", "uključen", Color.Black, "");
            }

            if (TSB_Nadstrujna.GetStanje() == 1)
            {
                SviTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "komanda", "uklop", Color.Black, "");
                SviTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "komanda", "isklop", Color.Black, "");
                SviTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "stanje", "isključen", Color.Black, "");
            }
            if (TSB_APU.GetStanje() == 1)
            {
                SviTSB.DodajSignal("TS-B", "220", "APU", "komanda", "uklop", Color.Black, "");
                SviTSB.DodajSignal("TS-B", "220", "APU", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSB.DodajSignal("TS-B", "220", "APU", "komanda", "isklop", Color.Black, "");
                SviTSB.DodajSignal("TS-B", "220", "APU", "stanje", "isključen", Color.Black, "");
            }
            if (TSB_IzlazniRastavljac.GetStanje() == 1)
            {
                SviTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "komanda", "uklop", Color.Black);
                SviTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "komanda", "isklop", Color.Black);
                SviTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "stanje", "isključeno", Color.Black, "");
            }
            if (TSB_UzemljenjaRastavljac.GetStanje() == 1)
            {
                SviTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "komanda", "uklop", Color.Black);
                SviTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "komanda", "isklop", Color.Black);
                SviTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "stanje", "isključeno", Color.Black, "");
            }
            if (TSB_S1_Rastavljac.GetStanje() == 1)
            {
                SviTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "komanda", "uklop", Color.Black);
                SviTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "komanda", "isklop", Color.Black);
                SviTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "stanje", "isključeno", Color.Black, "");
            }
            if (TSB_Prekidac.GetStanje() == 1)
            {
                SviTSB.DodajSignal("TS-B", "220", "prekidač", "komanda", "uklop", Color.Black, "");
                SviTSB.DodajSignal("TS-B", "220", "prekidač", "stanje", "uključen", Color.Black, "");
            }
            else
            {
                SviTSB.DodajSignal("TS-B", "220", "prekidač", "komanda", "isklop", Color.Black, "");
                SviTSB.DodajSignal("TS-B", "220", "prekidač", "stanje", "isključeno", Color.Black, "");
            }
        }

        private void DVPolje()
        {
            if (DV.GetStanje() == 1) //isključujemo
            {
                //Gasimo APU
                if (TSA_APU.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "APU", "komanda", "isklop", Color.Orange, "");
                    TSA_APU.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "APU", "stanje", "isključen", Color.Green, "");
                }
                if (TSB_APU.GetStanje() == 1)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "APU", "komanda", "isklop", Color.Orange, "");
                    TSB_APU.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "APU", "stanje", "isključen", Color.Green, "");
                }

                //Gasimo prekidače
                if (TSA_Prekidac.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "komanda", "isklop", Color.Orange, "");
                    TSA_Prekidac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "stanje", "isključen", Color.Green, "");
                }
                if (TSB_Prekidac.GetStanje() == 1)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "komanda", "isklop", Color.Orange, "");
                    TSB_Prekidac.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "stanje", "isključen", Color.Green, "");
                }
                

                //Gasimo SG i SP i S1 rastavljace
                if (TSA_SG_Rastavljac.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "komanda", "isklop", Color.Orange, "");
                    TSA_SG_Rastavljac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "stanje", "isključen", Color.Green, "");
                }
                if (TSA_SP_Rastavljac.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "komanda", "isklop", Color.Orange, "");
                    TSA_SP_Rastavljac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "stanje", "isključen", Color.Green, "");
                }
                if (TSB_S1_Rastavljac.GetStanje() == 1)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "komanda", "isklop", Color.Orange, "");
                    TSB_S1_Rastavljac.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "stanje", "isključen", Color.Green, "");
                }

                //gasim izlazni
                if (TSA_IzlazniRastavljac.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "komanda", "isklop", Color.Orange, "");
                    TSA_IzlazniRastavljac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "stanje", "isključen", Color.Green, "");
                }
                if (TSB_IzlazniRastavljac.GetStanje() == 1)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "komanda", "isklop", Color.Orange, "");
                    TSB_IzlazniRastavljac.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "stanje", "isključen", Color.Green, "");
                }

                //palim rastavljac uzemljenja
                if (TSA_UzemljenjaRastavljac.GetStanje() == 0)
                {               
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "komanda", "uklop", Color.Orange, "");
                    TSA_UzemljenjaRastavljac.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "stanje", "uključen", Color.Green, "");
                }
                if (TSB_UzemljenjaRastavljac.GetStanje() == 0)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "komanda", "uklop", Color.Orange, "");
                    TSB_UzemljenjaRastavljac.Uklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "stanje", "uključen", Color.Green, "");
                }

                TrenutniTSA.DodajSignal("TS-A", "220", "DV-JSŠ", "stanje", "isključen", Color.Red, "");
                TrenutniTSB.DodajSignal("TS-B", "220", "DV-JSŠ", "stanje", "isključen", Color.Red, "");
                DV.Isklop();
            }
            else if (DV.GetStanje() == 0) //uključujemo
            {
                //gasim rastavljac uzemljenja
                if (TSA_UzemljenjaRastavljac.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "komanda", "isklop", Color.Orange, "");
                    TSA_UzemljenjaRastavljac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "stanje", "isključen", Color.Green, "");
                }
                if (TSB_UzemljenjaRastavljac.GetStanje() == 1)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "komanda", "isklop", Color.Orange, "");
                    TSB_UzemljenjaRastavljac.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "stanje", "isključen", Color.Green, "");
                }

                //palim sabirnicke na SG se spajam
                if (TSA_SP_Rastavljac.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "komanda", "isklop", Color.Orange, "");
                    TSA_SP_Rastavljac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "stanje", "isključen", Color.Green, "");
                }
                if (TSA_SG_Rastavljac.GetStanje() == 0)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "komanda", "uklop", Color.Orange, "");
                    TSA_SG_Rastavljac.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "stanje", "uključen", Color.Green, "");
                }
                if (TSB_S1_Rastavljac.GetStanje() == 0)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "komanda", "uklop", Color.Orange, "");
                    TSB_S1_Rastavljac.Uklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "stanje", "uključen", Color.Green, "");
                }

                //palim izlazni
                if (TSA_IzlazniRastavljac.GetStanje() == 0)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "komanda", "uklop", Color.Orange, "");
                    TSA_IzlazniRastavljac.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "stanje", "uključen", Color.Green, "");
                }
                if (TSB_IzlazniRastavljac.GetStanje() == 0)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "komanda", "uklop", Color.Orange, "");
                    TSB_IzlazniRastavljac.Uklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "stanje", "uključen", Color.Green, "");
                }

                //uključujemo prekidače
                if (TSA_Prekidac.GetStanje() == 0)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "komanda", "uklop", Color.Orange, "");
                    TSA_Prekidac.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "stanje", "uključen", Color.Green, "");
                }
                if (TSB_Prekidac.GetStanje() == 0)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "komanda", "uklop", Color.Orange, "");
                    TSB_Prekidac.Uklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "stanje", "uključen", Color.Green, "");
                }

                TrenutniTSA.DodajSignal("TS-A", "220", "DV-JSŠ", "stanje", "uključen", Color.Green, "");
                TrenutniTSB.DodajSignal("TS-B", "220", "DV-JSŠ", "stanje", "uključen", Color.Green, "");
                DV.Uklop();
            }
        }

        private void DrawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //Rastavljac SG kliknut
            if (e.X >= 75 && e.X <= 125 && e.Y >= 80 && e.Y <= 110)
            {
                if (TSA_SG_Rastavljac.GetStanje() == 1 && TSA_Prekidac.GetStanje() == 1) //iskljucenje a prekidac je ukljucen
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "komanda", "isklop", Color.Red, "isključiti prekidač");
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "stanje", "uključen", Color.Green, "");
                    return;
                }
                else if (TSA_SG_Rastavljac.GetStanje() == 0 && TSA_Prekidac.GetStanje() == 1) //ukljucenje a prekidac je ukljucen
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "komanda", "isklop", Color.Red, "isključiti prekidač");
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "stanje", "isključen", Color.Green, "");
                    return;
                }
                else if (TSA_SG_Rastavljac.GetStanje() == 1 && TSA_Prekidac.GetStanje() == 0) //iskljucenje prekidac iskljucen
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSA_SG_Rastavljac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "stanje", "isključen", Color.Green, "");
                }
                else if (TSA_SG_Rastavljac.GetStanje() == 0 && TSA_Prekidac.GetStanje() == 0) //ukljucenje prekidac iskljucen
                {
                    if (TSA_SP_Rastavljac.GetStanje() == 1) //Pokusavamo ukljuciti ali je vec ukljucen pomocni
                    {
                        TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "komanda", "uklop", Color.Red, "isključiti drugi rastavljač");
                        TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "stanje", "isključen", Color.Green, "");
                        return;
                    }
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSA_SG_Rastavljac.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SG", "stanje", "uključen", Color.Green, "");
                }  
            }
            //Rastavljac SP kliknut
            if (e.X >= 225 && e.X <= 275 && e.Y >= 80 && e.Y <= 110)
            {
                if (TSA_SP_Rastavljac.GetStanje() == 1 && TSA_Prekidac.GetStanje() == 1) //iskljucenje a prekidac je ukljucen
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "komanda", "isklop", Color.Red, "isključiti prekidač");
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "stanje", "uključen", Color.Green, "");
                    return;
                }
                else if (TSA_SP_Rastavljac.GetStanje() == 0 && TSA_Prekidac.GetStanje() == 1) //ukljucenje a prekidac je ukljucen
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "komanda", "isklop", Color.Red, "isključiti prekidač");
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "stanje", "isključen", Color.Green, "");
                    return;
                }
                else if (TSA_SP_Rastavljac.GetStanje() == 1 && TSA_Prekidac.GetStanje() == 0) //iskljucenje prekidac iskljucen
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSA_SP_Rastavljac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "stanje", "isključen", Color.Green, "");
                }
                else if (TSA_SP_Rastavljac.GetStanje() == 0 && TSA_Prekidac.GetStanje() == 0) //ukljucenje prekidac iskljucen
                {
                    if (TSA_SG_Rastavljac.GetStanje() == 1) //Pokusavamo ukljuciti ali je vec ukljucen glavni
                    {
                        TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "komanda", "uklop", Color.Red, "isključiti drugi rastavljač");
                        TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "stanje", "isključen", Color.Green, "");
                        return;
                    }
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "komanda", "uklop", Color.Green, "prihvaćeno"); 
                    TSA_SP_Rastavljac.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "sabirnički rastavljač SP", "stanje", "uključen", Color.Green, "");
                }
            }
            //Prekidac TS-A kliknut
            if (e.X >= 150 && e.X <= 200 && e.Y >= 190 && e.Y <= 210)
            {
                if (TSA_Prekidac.GetStanje() == 1) //iskljucenje
                {
                    if (TSA_APU.GetStanje() == 1) //apu je ukljucen i ne dozvoljava iskljucenje
                    {
                        TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "komanda", "isklop", Color.Red, "APU ukljucen");
                        TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "stanje", "uključen", Color.Green, "");
                        return;
                    }
                    TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "komanda", "isklop", Color.Green, "prihvaćeno");        
                    TSA_Prekidac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "stanje", "isključen", Color.Green, "");
                }
                else if (TSA_Prekidac.GetStanje() == 0) //ukljucenje
                {
                    //uzmljenje je ukjluceno
                    if ((TSA_SG_Rastavljac.GetStanje() == 0 && TSA_SP_Rastavljac.GetStanje() == 0)
                        || TSA_IzlazniRastavljac.GetStanje() == 0
                        || TSA_UzemljenjaRastavljac.GetStanje() == 1)
                    {
                        if (TSA_UzemljenjaRastavljac.GetStanje() == 1)
                        {
                            TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "komanda", "uklop", Color.Red, "iskljuciti uzemljenje");
                        } else
                        {
                            TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "komanda", "uklop", Color.Red, "ukljuciti rastavljace");
                        }  
                        TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "stanje", "isključen", Color.Green, "");
                        return;
                    }
                    TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSA_Prekidac.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "stanje", "uključen", Color.Green, "");
                }
            }
            //Izlazni rastavljac TS-A kliknut
            if (e.X >= 150 && e.X <= 200 && e.Y >= 260 && e.Y <= 280)
            {
                if (TSA_IzlazniRastavljac.GetStanje() == 0 && TSA_Prekidac.GetStanje() == 0)
                { 
                    if (TSA_UzemljenjaRastavljac.GetStanje() == 1) //blokada:uzemljenje mora biti isključenao
                    {
                        TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "komanda", "uklop", Color.Red, "iskljuciti uzemljenje");
                        TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "stanje", "isključen", Color.Green, "");
                        return;
                    }
                    TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSA_IzlazniRastavljac.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "stanje", "uključen", Color.Green, "");
                } //blokada:ne mozemo izlazni r. iskljucit ako je prekidac ukljucen
                else if (TSA_IzlazniRastavljac.GetStanje() == 1 && TSA_Prekidac.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "komanda", "isklop", Color.Red, "iskljuciti prekidac");
                    TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "stanje", "uključen", Color.Green, "");
                    return;
                }
                //da bi iskljucili rastavljac prekidac mora biti iskljucen
                else if (TSA_IzlazniRastavljac.GetStanje() == 1 && TSA_Prekidac.GetStanje() == 0)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSA_IzlazniRastavljac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "izlazni rastavljač", "stanje", "isključen", Color.Green, "");
                }
            }
            //Rastavljac uzemljenja TS-A kliknut
            if (e.X >= 220 && e.X <= 240 && e.Y >= 295 && e.Y <= 345)
            {
                if (TSA_UzemljenjaRastavljac.GetStanje() == 0 && TSA_Prekidac.GetStanje() == 0)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSA_UzemljenjaRastavljac.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "stanje", "uključen", Color.Green, "");
                }
                else if (TSA_UzemljenjaRastavljac.GetStanje() == 0 && TSA_Prekidac.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "komanda", "uklop", Color.Red, "iskljuciti prekidac");
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "stanje", "isključen", Color.Green, "");
                    return;
                }
                else if (TSA_UzemljenjaRastavljac.GetStanje() == 1 && TSA_Prekidac.GetStanje() == 0)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSA_UzemljenjaRastavljac.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "stanje", "isključen", Color.Green, "");
                }
                else if (TSA_UzemljenjaRastavljac.GetStanje() == 1 && TSA_Prekidac.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "komanda", "isklop", Color.Red, "iskljuciti prekidac");
                    TrenutniTSA.DodajSignal("TS-A", "220", "rastavljač uzemljenja", "stanje", "uključen", Color.Green, "");
                    return;
                }
            }

            //APU TS-A kliknut
            if (e.X >= 55 && e.X <= 95 && e.Y >= 195 && e.Y <= 210)
            {
                if (TSA_APU.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "APU", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSA_APU.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "APU", "stanje", "isključen", Color.Green, "");
                }
                else
                {
                    if ((TSA_SG_Rastavljac.GetStanje() == 0 && TSA_SP_Rastavljac.GetStanje() == 0) || TSA_IzlazniRastavljac.GetStanje() == 0)
                    {
                        TrenutniTSA.DodajSignal("TS-A", "220", "APU", "komanda", "uklop", Color.Red, "ukljuciti rastavljace");
                        TrenutniTSA.DodajSignal("TS-A", "220", "APU", "stanje", "isključen", Color.Green, "");
                        return;
                    }
                    TrenutniTSA.DodajSignal("TS-A", "220", "APU", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSA_APU.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "APU", "stanje", "uključen", Color.Green, "");
                    if (TSA_Prekidac.GetStanje() == 0)
                    {
                        TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "komanda", "uklop", Color.Green, "prihvaćeno");
                        TSA_Prekidac.Uklop();
                        TrenutniTSA.DodajSignal("TS-A", "220", "prekidač", "stanje", "uključen", Color.Green, "");
                    }
                }
            }
            //Nadstrujna TS-A kliknut
            if (e.X >= 25 && e.X <= 125 && e.Y >= 215 && e.Y <= 235)
            {
                if (TSA_Nadstrujna.GetStanje() == 0)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "nadstrujna zaštita", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSA_Nadstrujna.Uklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "nadstrujna zaštita", "stanje", "uključen", Color.Green, "");              
                }
                else if (TSA_Nadstrujna.GetStanje() == 1)
                {
                    TrenutniTSA.DodajSignal("TS-A", "220", "nadstrujna zaštita", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSA_Nadstrujna.Isklop();
                    TrenutniTSA.DodajSignal("TS-A", "220", "nadstrujna zaštita", "stanje", "isključen", Color.Green, "");
                }
            }

            //DV-JSŠ kliknuto
            if (e.X >= 295 && e.X <= 370 && e.Y >= 430 && e.Y <= 445)
            {
                DVPolje();
            }

            //Nadstrujna TS-B kliknut
            if (e.X >= 535 && e.X <= 635 && e.Y >= 215 && e.Y <= 235)
            {
                if (TSB_Nadstrujna.GetStanje() == 0)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "nadstrujna zaštita", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSB_Nadstrujna.Uklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "nadstrujna zaštita", "stanje", "uključen", Color.Green, "");
                }
                else
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "nadstrujna zaštita", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSB_Nadstrujna.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "nadstrujna zaštita", "stanje", "isključen", Color.Green, "");
                }
            }
            //APU TS-B kliknut
            if (e.X >= 565 && e.X <= 605 && e.Y >= 195 && e.Y <= 210)
            {
                if (TSB_APU.GetStanje() == 1)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "APU", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSB_APU.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "APU", "stanje", "isključen", Color.Green, "");
                }
                else
                {
                    if (TSB_S1_Rastavljac.GetStanje() == 0 || TSB_IzlazniRastavljac.GetStanje() == 0)
                    {
                        TrenutniTSB.DodajSignal("TS-B", "220", "APU", "komanda", "uklop", Color.Red, "ukljuciti rastavljace");
                        TrenutniTSB.DodajSignal("TS-B", "220", "APU", "stanje", "isključen", Color.Green, "");
                        return;
                    }
                    TrenutniTSB.DodajSignal("TS-B", "220", "APU", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSB_APU.Uklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "APU", "stanje", "uključen", Color.Green, "");
                    if (TSB_Prekidac.GetStanje() == 0)
                    {
                        TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "komanda", "uklop", Color.Green, "prihvaćeno");
                        TSB_Prekidac.Uklop();
                        TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "stanje", "uključen", Color.Green, "");
                    }
                }
            }
            //Rastavljac uzemljenja TS-A kliknut
            if (e.X >= 420 && e.X <= 440 && e.Y >= 295 && e.Y <= 345)
            {
                if (TSB_UzemljenjaRastavljac.GetStanje() == 0 && TSB_Prekidac.GetStanje() == 0)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSB_UzemljenjaRastavljac.Uklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "stanje", "uključen", Color.Green, "");
                }
                else if (TSB_UzemljenjaRastavljac.GetStanje() == 0 && TSB_Prekidac.GetStanje() == 1)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "komanda", "uklop", Color.Red, "iskljuciti prekidac");
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "stanje", "isključen", Color.Green, "");
                    return;
                }
                else if (TSB_UzemljenjaRastavljac.GetStanje() == 1 && TSB_Prekidac.GetStanje() == 0)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSB_UzemljenjaRastavljac.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "stanje", "isključen", Color.Green, "");
                }
                else if (TSB_UzemljenjaRastavljac.GetStanje() == 1 && TSB_Prekidac.GetStanje() == 1)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "komanda", "isklop", Color.Red, "iskljuciti prekidac");
                    TrenutniTSB.DodajSignal("TS-B", "220", "rastavljač uzemljenja", "stanje", "uključen", Color.Green, "");
                    return;
                }
            }
            //Izlazni rastavljac TS-B kliknut
            if (e.X >= 460 && e.X <= 510 && e.Y >= 260 && e.Y <= 280)
            {
                if (TSB_IzlazniRastavljac.GetStanje() == 0 && TSB_Prekidac.GetStanje() == 0)
                {
                    if (TSB_UzemljenjaRastavljac.GetStanje() == 1)
                    {
                        TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "komanda", "uklop", Color.Red, "iskljuciti uzemljenje");
                        TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "stanje", "isključen", Color.Green, "");
                        return;
                    }
                    TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSB_IzlazniRastavljac.Uklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "stanje", "uključen", Color.Green, "");
                }
                //blokada:ne mozemo izlazni r. iskljucit ako je prekidac ukljucen
                else if (TSB_IzlazniRastavljac.GetStanje() == 1 && TSB_Prekidac.GetStanje() == 1)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "komanda", "isklop", Color.Red, "iskljuciti prekidac");
                    TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "stanje", "uključen", Color.Green, "");
                    return;
                }
                else if (TSB_IzlazniRastavljac.GetStanje() == 1 && TSB_Prekidac.GetStanje() == 0)
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSB_IzlazniRastavljac.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "izlazni rastavljač", "stanje", "isključen", Color.Green, "");
                }
            }
            //Prekidac TS-B kliknut
            if (e.X >= 460 && e.X <= 510 && e.Y >= 190 && e.Y <= 210)
            {
                if (TSB_Prekidac.GetStanje() == 1)
                {
                    if (TSB_APU.GetStanje() == 1)
                    {
                        TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "komanda", "isklop", Color.Red, "APU ukljucen");
                        TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "stanje", "uključen", Color.Green, "");
                        return;
                    }
                    TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSB_Prekidac.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "stanje", "isključen", Color.Green, "");
                }
                else if (TSB_Prekidac.GetStanje() == 0)
                {
                    if (TSB_S1_Rastavljac.GetStanje() == 0
                        || TSB_IzlazniRastavljac.GetStanje() == 0
                        || TSB_UzemljenjaRastavljac.GetStanje() == 1)
                    {
                        if (TSB_UzemljenjaRastavljac.GetStanje() == 1)
                        {
                            TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "komanda", "uklop", Color.Red, "iskljuciti uzemljenje");
                        }
                        else
                        {
                            TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "komanda", "uklop", Color.Red, "ukljuciti rastavljace");
                        }
                        TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "stanje", "isključen", Color.Green, "");
                        return;
                    }
                    TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSB_Prekidac.Uklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "prekidač", "stanje", "uključen", Color.Green, "");
                }
            }
            //Rastavljac S1 kliknut
            if (e.X >= 460 && e.X <= 510 && e.Y >= 80 && e.Y <= 110)
            {
                if (TSB_S1_Rastavljac.GetStanje() == 1 && TSB_Prekidac.GetStanje() == 1) //Prekidac ukljucen i SG ukljucen
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "komanda", "isklop", Color.Red, "isključiti prekidač");
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "stanje", "uključen", Color.Green, "");
                    return;
                }
                else if (TSB_S1_Rastavljac.GetStanje() == 0 && TSB_Prekidac.GetStanje() == 1) //ukljucenje a prekidac je ukljucen
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "komanda", "isklop", Color.Red, "isključiti prekidač");
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "stanje", "isključen", Color.Green, "");
                    return;
                }
                else if (TSB_S1_Rastavljac.GetStanje() == 1 && TSB_Prekidac.GetStanje() == 0) //Dok je prekidac iskljucen
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "komanda", "isklop", Color.Green, "prihvaćeno");
                    TSB_S1_Rastavljac.Isklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "stanje", "isključen", Color.Green, "");
                }
                else if (TSB_S1_Rastavljac.GetStanje() == 0 && TSB_Prekidac.GetStanje() == 0) //ukljucenje a prekidac je iskljucen
                {
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "komanda", "uklop", Color.Green, "prihvaćeno");
                    TSB_S1_Rastavljac.Uklop();
                    TrenutniTSB.DodajSignal("TS-B", "220", "sabirnički rastavljač S1", "stanje", "uključen", Color.Green, "");
                }
            }

            DrawPanel.Invalidate();
            //MessageBox.Show("X:"+e.X.ToString() + "\nY:" + e.Y.ToString());
        }

        private void DrawingWindow_Load(object sender, System.EventArgs e)
        {
            DVPolje();
        }

        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(500);
                //Invoke((MethodInvoker)delegate { this.Update(); });
                Invalidate();
            }
        }
    }
}
