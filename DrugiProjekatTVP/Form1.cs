using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace DrugiProjekatTVP
{
    public partial class Form1 : Form
    {
        static object locker = new object();

        OleDbDataAdapter dataadapter;
        DataTable datatable;
        DataSet dataset;
        OleDbConnection connect;
        OleDbCommand cmd;
        string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Prodavnica.mdb";
        List<RadSaRacunom> listaRacun;
        List<Artikal> listaArtikla;
        List<Grupa> listaGrupa;
        List<Racun> lr;
        List<Grupa> lg;
        List<Artikal> la;
        public Form1()
        {
            InitializeComponent();
            //Otvaranje konekcije
            connect = new OleDbConnection(connectString);

            //Liste
            listaRacun = new List<RadSaRacunom>();
            listaArtikla = new List<Artikal>();
            listaGrupa = new List<Grupa>();

            lg = new List<Grupa>();
            la = new List<Artikal>();
            lr = new List<Racun>();

            //Funkcije
            this.Load += ucitavanjeGrupa;
            btnDodajNaRacun.Click += racunajCenu;
            btnStornirajOznaceni.Click += racunajCenu;
            btnStornirajSveSaRacuna.Click += racunajCenu;
            lbPrikazArtiklaPoGrupi.SelectedIndexChanged += cenaZaOdabrano;
            nudKolicinaArtikala.ValueChanged += cenaZaOdabrano;

            //Datumi
            dtpDatumOd.Format = DateTimePickerFormat.Custom;
            dtpDatumOd.CustomFormat = "dd.MM.yyyy. HH:mm:ss";
            dtpDatumDo.Format = DateTimePickerFormat.Custom;
            dtpDatumDo.CustomFormat = "dd.MM.yyyy. HH:mm:ss";
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            listaArtikla.Clear();
            try
            {
                connect.Open();
                string upit = "SELECT * FROM Artikal";
                cmd = new OleDbCommand(upit, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaArtikla.Add(new Artikal(Convert.ToInt32(reader["id_artikla"]), reader["naziv"].ToString(),
                        Convert.ToDouble(reader["cena"]), Convert.ToInt32(reader["popust"]), Convert.ToInt32(reader["id_grupe"])));
                }
            }
            catch
            {
                MessageBox.Show("Greška pri radu sa Bazom Podataka!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                connect.Close();
            }
            lblDatumTrenutni.Text = DateTime.Now.ToLongDateString();
        }
        public void ucitajArtikle()
        {
            OleDbConnection conn1 = new OleDbConnection(connectString);
            la.Clear();
            try
            {
                conn1.Open();
                string upit = "SELECT * FROM Artikal";
                cmd = new OleDbCommand(upit, conn1);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    la.Add(new Artikal(Convert.ToInt32(reader["id_artikla"]), reader["naziv"].ToString(),
                        Convert.ToDouble(reader["cena"]), Convert.ToInt32(reader["popust"]), Convert.ToInt32(reader["id_grupe"])));
                }
            }
            catch
            {
                MessageBox.Show("Greška pri radu sa Bazom Podataka!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn1.Close();
            }
        }
        public void ucitajGrupe()
        {
            OleDbConnection conn2 = new OleDbConnection(connectString);
            lg.Clear();
            try
            {
                conn2.Open();
                string upit = "SELECT * FROM grupa";
                cmd = new OleDbCommand(upit, conn2);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Grupa grupa = new Grupa(Convert.ToInt32(reader["id_grupe"]), reader["naziv_grupe"].ToString());
                    lg.Add(grupa);
                }
            }
            catch
            {
                MessageBox.Show("Greška pri radu sa Bazom Podataka!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn2.Close();
            }
        }
        public void napuniListe(int i)
        {
            if (i == 0)
            {
                ucitajArtikle();
            }
            else if (i == 1)
            {
                ucitajGrupe();
            }
            MessageBox.Show("USPELO!");
        }
        public void ucitavanjeGrupa(Object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string upit = "SELECT * FROM grupa";
                cmd = new OleDbCommand(upit, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                cbGrupaArtiklaZaDodavanje.Items.Clear();
                cbGrupaArtiklaPromene.Items.Clear();
                int br = 0, x = 0, y = 5;
                while (reader.Read())
                {
                    Grupa grupa = new Grupa(Convert.ToInt32(reader["id_grupe"]),reader["naziv_grupe"].ToString());
                    listaGrupa.Add(grupa);
                    cbGrupaArtiklaZaDodavanje.Items.Add(grupa);
                    cbGrupaArtiklaPromene.Items.Add(grupa);
                    Button button = addButton(br++, grupa.Naziv_grupe, grupa,x,y);
                    button.Click += prikazArtikalaPoGrupi;
                    pnlDugmici.Controls.Add(button);
                    x += 130;
                    if (br % 4 == 0)
                    {
                        x = 0;
                        y += 60;
                    }
                }                
            }
            catch
            {
                MessageBox.Show("Greška pri radu sa Bazom Podataka!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                connect.Close();
            }            
        }
        Button addButton(int i,string nazivGrupe,Grupa grupa,int x,int y)
        {
            Button button = new Button();
            button.Name = "btn" + nazivGrupe;
            button.Text = grupa + "";
            button.ForeColor = Color.Black;
            button.BackColor = Color.LightGray;
            button.Font = new Font(button.Font.FontFamily, 10, FontStyle.Bold);
            button.Width = 120;
            button.Height = 50;
            button.Location = new Point(x,y);
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.Margin = new Padding(5);
            return button;
        }
        private void prikazArtikalaPoGrupi(object sender, EventArgs e)
        {
            txtPrikazPoNazivu.Text = "";
            txtCenaOdabira.Text = "0.00";
            nudKolicinaArtikala.Value = 1;
            int broj = 0;
            try
            {
                connect.Open();
                Button button = sender as Button;
                Grupa pom = null;
                for (int i = 0; i < listaGrupa.Count; i++)
                {
                    if (button.Text == listaGrupa[i].Naziv_grupe)
                        pom = listaGrupa[i];
                }                
                string upit = "SELECT * FROM artikal WHERE id_grupe IN(SELECT id_grupe FROM grupa WHERE naziv_grupe='" + pom.Naziv_grupe + "')";
                cmd = new OleDbCommand(upit, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                lbPrikazArtiklaPoGrupi.Items.Clear();
                int brojac = 0;
                broj = pom.Id_grupe;
                while (reader.Read())
                {
                    Artikal artikal = new Artikal(Convert.ToInt32(reader["id_artikla"]), reader["naziv"].ToString(),
                        Convert.ToDouble(reader["cena"]), Convert.ToInt32(reader["popust"]));
                    lbPrikazArtiklaPoGrupi.Items.Add(artikal);
                    brojac++;
                }                
                if (brojac == 0) lbPrikazArtiklaPoGrupi.Items.Add("Trenutno nemamo artikala za traženu grupu!");
            }
            catch
            {
                MessageBox.Show("Greška pri radu sa Bazom Podataka!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {                
                connect.Close();
                if (broj > 0 && broj < 9)
                {
                    pbSlikeGrupa.Image = Image.FromFile(@"slike\" + broj + ".png");
                }
            }            
        }
        private void txtPrikazPoNazivu_TextChanged(object sender, EventArgs e)
        {
            pbSlikeGrupa.Image = null;
            txtCenaOdabira.Text = "0.00";
            nudKolicinaArtikala.Value = 1;
            var upit1 = from a in listaArtikla
                        where a.Naziv_artikla.Contains(txtPrikazPoNazivu.Text)
                        select a;
            lbPrikazArtiklaPoGrupi.Items.Clear();
            foreach (Artikal artikal in upit1)
            {
                lbPrikazArtiklaPoGrupi.Items.Add(artikal);
            }
            if (txtPrikazPoNazivu.Text == "") lbPrikazArtiklaPoGrupi.Items.Clear();
        }
        private void btnArtikliSaPopustom_Click(object sender, EventArgs e)
        {
            pbSlikeGrupa.Image = null;
            txtCenaOdabira.Text = "0.00";
            nudKolicinaArtikala.Value = 1;
            var upit1 = from a in listaArtikla
                        where a.Popust > 0
                        select a;
            lbPrikazArtiklaPoGrupi.Items.Clear();
            if (upit1.Count() > 0)
            {
                foreach (Artikal artikal in upit1)
                {
                    lbPrikazArtiklaPoGrupi.Items.Add(artikal);
                }
            }
            else
            {
                lbPrikazArtiklaPoGrupi.Items.Add("Trenutno nemamo Artikle na Popustu!");
            }
        }

        private void btnDodajNaRacun_Click(object sender, EventArgs e)
        {
            Object o = lbPrikazArtiklaPoGrupi.SelectedItem;            
            Boolean provera = false;
            if (o == null || !(o is Artikal))
            {
                MessageBox.Show("Da bi ste dodali Artikal na Račun morate ga prvobitno odabrati!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Artikal artikal = o as Artikal;   
                for (int i = 0; i < listaRacun.Count; i++)
                {
                    if (artikal.Id_artikla == listaRacun[i].Artikal.Id_artikla)
                    {
                        listaRacun[i].Kolicina += (int)nudKolicinaArtikala.Value;
                        provera = true;
                        break;
                    }
                }
                if (provera == false)
                {
                    RadSaRacunom rsr = new RadSaRacunom(artikal, (int)nudKolicinaArtikala.Value);
                    lbPrikazRacuna.Items.Add(rsr);
                    listaRacun.Add(rsr);
                }
                else
                {
                    lbPrikazRacuna.Items.Clear();
                    for (int i = 0; i < listaRacun.Count; i++)
                    {
                        lbPrikazRacuna.Items.Add(listaRacun[i]);
                    }
                }
                nudKolicinaArtikala.Value = 1;
            }
        }

        private void btnStornirajSveSaRacuna_Click(object sender, EventArgs e)
        {
            if (lbPrikazRacuna.Items.Count > 0)
            {
                Form2 frmUpitnik = new Form2("Da li ste sigurni da hoćete da stornirate ceo račun?");
                if (frmUpitnik.ShowDialog() == DialogResult.Yes)
                {
                    lbPrikazRacuna.Items.Clear();
                    listaRacun.Clear();
                }
            }
            else
            {
                MessageBox.Show("Račun je trenutno prazan i nemamo šta da storniramo!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStornirajOznaceni_Click(object sender, EventArgs e)
        {
            Object o = lbPrikazRacuna.SelectedItem;
            if (o == null)
            {
                MessageBox.Show("Da bi ste stornirali Artikal sa Računa morate ga prvobitno odabrati!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                RadSaRacunom rsr = o as RadSaRacunom;
                lbPrikazRacuna.Items.Clear();
                for (int i = 0; i < listaRacun.Count; i++)
                {
                    if (listaRacun[i] == rsr)
                    {
                        listaRacun.RemoveAt(i);
                        --i;
                    }
                    else
                        lbPrikazRacuna.Items.Add(listaRacun[i]);
                }
                MessageBox.Show("Uspešno ste stornirali traženi Artikal sa Računa!");
            }
        }
        public void racunajCenu(Object sender, EventArgs e)
        {
            double ukupnaCena = 0.0;
            Artikal artikal;
            for (int i = 0; i < listaRacun.Count; i++)
            {
                artikal = listaRacun[i].Artikal;
                ukupnaCena += (artikal.Cena * (1.0 - artikal.Popust / 100.0)) * listaRacun[i].Kolicina;
            }
            txtUkupnaCena.Text = ukupnaCena.ToString("N2");
        }
        public void cenaZaOdabrano(Object sender, EventArgs e)
        {
            double cenaOdabranog = 0.0;
            Object o = lbPrikazArtiklaPoGrupi.SelectedItem;
            if (o != null)
            {
                Artikal artikal = o as Artikal;
                cenaOdabranog += (artikal.Cena * (1.0 - artikal.Popust / 100.0)) * (int)nudKolicinaArtikala.Value;
                txtCenaOdabira.Text = cenaOdabranog.ToString("N2");
            }
        }
        private void btnIzdajRacun_Click(object sender, EventArgs e)
        {

            if (lbPrikazRacuna.Items.Count > 0)
            {
                
                Form2 frmUpitnik = new Form2("Da li je to sve što ste hteli da kupite?");
                if (frmUpitnik.ShowDialog() == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        string upit = "INSERT INTO racun(cena,datum,vreme) VALUES('" + Convert.ToDouble(txtUkupnaCena.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd") +
                            "','" + DateTime.Now.ToString("HH:mm:ss") + "')";
                        cmd = new OleDbCommand(upit, connect);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Uspešno ste izdali Račun koji je upisan u Bazu Podataka!");
                        txtUkupnaCena.Text = "0.00";
                        lbPrikazRacuna.Items.Clear();
                        listaRacun.Clear();
                    }
                    catch
                    {
                        MessageBox.Show("Greška pri radu sa Bazom Podataka!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Račun je još uvek prazan i ne možemo ga izdati!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void procitajArtikleUTasku()
        {
            lock (locker)
            {
                listaArtikla.Clear();
                try
                {
                    connect.Open();
                    string upit = "SELECT * FROM artikal";
                    cmd = new OleDbCommand(upit, connect);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listaArtikla.Add(new Artikal(Convert.ToInt32(reader["id_artikla"]), reader["naziv"].ToString(),
                            Convert.ToDouble(reader["cena"]), Convert.ToInt32(reader["popust"]), Convert.ToInt32(reader["id_grupe"])));
                    }
                    //MessageBox.Show("" + listaArtikla.Count);
                }
                catch
                {
                    MessageBox.Show("Greška pri radu sa Bazom Podataka!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        //FUNKCIJA SA TASKOM
        private void btnDodajNoviArtikal_Click(object sender, EventArgs e)
        {
            Object o = cbGrupaArtiklaPromene.SelectedItem;
            Grupa grupa = o as Grupa;
            string pattern1 = @"^[a-zA-Z0-9ćĆčČšŠžŽđĐ ]{1,50}$";
            Match result1 = Regex.Match(txtNazivArtikla.Text, pattern1);
            if (!result1.Success) { txtNazivArtikla.Text = ""; txtNazivArtikla.Focus(); }
            double cena;
            bool proveraCene = double.TryParse(txtCenaArtikla.Text.Replace(".", ","), out cena);
            if (proveraCene == false) { txtCenaArtikla.Text = ""; txtCenaArtikla.Focus(); }
            Boolean proveraStanja = false;
            for (int i = 0; i < listaArtikla.Count; i++)
            {
                if (txtNazivArtikla.Text == listaArtikla[i].Naziv_artikla)
                {
                    proveraStanja = true;
                    break;
                }
            }
            if (result1.Success && proveraCene == true && proveraStanja == false && grupa != null)
            {
                try
                {
                    connect.Open();
                    string upit = "INSERT INTO artikal(naziv,cena,popust,id_grupe) " +
                        "VALUES('" + txtNazivArtikla.Text + "','" +Convert.ToDouble(txtCenaArtikla.Text.Replace(".",",")) + "'," + Convert.ToInt32(nudPopust.Value) + "," +
                        Convert.ToInt32(grupa.Id_grupe) + ")";
                    cmd = new OleDbCommand(upit, connect);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Uspešno ste dodali novi Artikal u Bazu Podataka!");
                    txtCenaArtikla.Text = ""; txtNazivArtikla.Text = ""; nudPopust.Value = 0; cbGrupaArtiklaPromene.SelectedIndex = -1;
                    cbGrupaArtiklaZaDodavanje.SelectedIndex = -1; lbPrikazPostojecihArtikala.Items.Clear(); 
                }
                catch
                {
                    MessageBox.Show("Greška pri radu sa Bazom Podataka!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    connect.Close();
                }
                Task t = new Task(procitajArtikleUTasku);
                t.Start();
            }
            else
            {
                MessageBox.Show("Podaci koje unosite za artikal nisu validni ili Artikal već postoji u Bazi Podataka!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbGrupaArtiklaZaDodavanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGrupaArtiklaZaDodavanje.SelectedIndex != -1)
            {
                lbPrikazPostojecihArtikala.Items.Clear();
                Object o = cbGrupaArtiklaZaDodavanje.SelectedItem;
                Grupa grupa = o as Grupa;
                var upit1 = from a in listaArtikla
                            where a.Id_grupe == grupa.Id_grupe
                            select a;
                if (upit1.Count() > 0)
                {
                    foreach (Artikal artikal in upit1)
                    {
                        lbPrikazPostojecihArtikala.Items.Add(artikal);
                    }
                }
                else
                {
                    lbPrikazPostojecihArtikala.Items.Add("Trenutno nemamo Artikala za traženu grupu!");
                }
            }
        }

        private void btnIzlistajRacune_Click(object sender, EventArgs e)
        {
            //Rad sa DataAdapterom
            dataadapter = new OleDbDataAdapter("select * from Racun", connectString);
            datatable = new DataTable("Racun");
            dataadapter.Fill(datatable);
            DataTable dtRez = new DataTable();

            if ((dtpDatumOd.Value.Date < dtpDatumDo.Value.Date) || ((dtpDatumOd.Value.Date == dtpDatumDo.Value.Date && ((dtpDatumOd.Value.TimeOfDay.Hours < dtpDatumDo.Value.TimeOfDay.Hours) ||
                (dtpDatumOd.Value.TimeOfDay.Hours == dtpDatumDo.Value.TimeOfDay.Hours && dtpDatumOd.Value.TimeOfDay.Minutes < dtpDatumDo.Value.TimeOfDay.Minutes) ||
                (dtpDatumOd.Value.TimeOfDay.Hours == dtpDatumDo.Value.TimeOfDay.Hours && dtpDatumOd.Value.TimeOfDay.Minutes == dtpDatumDo.Value.TimeOfDay.Minutes && dtpDatumOd.Value.TimeOfDay.Seconds < dtpDatumDo.Value.TimeOfDay.Seconds) ||
                (dtpDatumOd.Value.TimeOfDay.Hours == dtpDatumDo.Value.TimeOfDay.Hours && dtpDatumOd.Value.TimeOfDay.Minutes == dtpDatumDo.Value.TimeOfDay.Minutes && dtpDatumOd.Value.TimeOfDay.Seconds == dtpDatumDo.Value.TimeOfDay.Seconds)))))
            {                
                IEnumerable<DataRow> rows = datatable.Rows.Cast<DataRow>();
                IEnumerable<DataRow> rez = rows.Where(x => ((Convert.ToDateTime(Convert.ToDateTime(x["datum"]).ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(x["vreme"]).ToString("HH:mm:ss"))) >= dtpDatumOd.Value) &&
                                                           ((Convert.ToDateTime(Convert.ToDateTime(x["datum"]).ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(x["vreme"]).ToString("HH:mm:ss"))) <= dtpDatumDo.Value));

                if (rez.Count() > 0)
                {
                    datatable = rez.CopyToDataTable();
                    dgvPrikazDatuma.DataSource = datatable;
                    dgvPrikazDatuma.Columns[3].DefaultCellStyle.Format = "HH:mm:ss";
                }
                else
                {
                    dgvPrikazDatuma.DataSource = dtRez;
                    MessageBox.Show("U izabranom opsegu nema ni jednog Računa!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                dgvPrikazDatuma.DataSource = dtRez;
                MessageBox.Show("Datumi koje ste zadali nisu u dozvoljenom opsegu! Proverite i datum i vreme!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
