using jsonParser.Functions;
using jsonParser.Model;

namespace jsonParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        restApi api = new restApi();
        parseJson parse1 = new parseJson();
        String Data = @"D:\js\fgd.json";
        private void btnParse_Click(object sender, EventArgs e)
        {
            using (var contex = new context())
            {
                foreach (clsOsosModel i in parse1.parseJsonData(Data))
                {
                    contex.tblOsosVeri.Add(i);                    
                }
                contex.SaveChanges();
            }
        }

        private void btnApiTest_Click(object sender, EventArgs e)
        {
            using (var contex = new context())
            {
                foreach(clsDagitimModel i in api.getDagitimBolgesi())
                {
                    contex.tblDagitimBolgeleri.Add(i);
                }
                contex.SaveChanges();
            }            
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            

            using (var contex = new context())
            {
                foreach (clsPiyasaFiyatlariModel i in api.getPtfSmf(dateTimePicker1.Value, dateTimePicker2.Value))
                {
                    if (i.SistemYonu == "ENERGY_DEFICIT")
                    {
                        i.SistemYonu = "YAL";
                    }
                    else if (i.SistemYonu == "IN_BALANCE")
                    {
                        i.SistemYonu = "DENGEDE";
                    }
                    else
                    {
                        i.SistemYonu = "YAT";
                    }
                    contex.tblPiyasaFiyatlari.Add(i);
                }
                contex.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var contex = new context())
            {
                foreach (clsDgpTalimatOzet i in api.dgpTalimatOzet(dateTimePicker1.Value, dateTimePicker2.Value))
                {
                    if (i.SistemYonu == "ENERGY_DEFICIT")
                    {
                        i.SistemYonu = "YAL";
                    }
                    else if (i.SistemYonu == "IN_BALANCE")
                    {
                        i.SistemYonu = "DENGEDE";
                    }
                    else
                    {
                        i.SistemYonu = "YAT";
                    }
                    contex.tblDgpOzet.Add(i);
                }
                contex.SaveChanges();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var contex = new context())
            {
                foreach (clsGercekZamanliUretim i in api.gercekZamanliUretim(dateTimePicker1.Value, dateTimePicker2.Value))
                {                   
                    contex.tblGercekZamanliUretimler.Add(i);
                }
                contex.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var contex = new context())
            {
                foreach (clsAuf i in api.getAuf(dateTimePicker1.Value, dateTimePicker2.Value))
                {
                    contex.tblAuf.Add(i);
                }
                contex.SaveChanges();
            }
        }
    }
}