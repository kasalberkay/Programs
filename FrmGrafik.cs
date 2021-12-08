using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayıt
{
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-16RHD47\\;Initial Catalog=Personel_Veri_Tabani;Integrated Security=True");

        private void chart1_Click(object sender, EventArgs e)
        {
            //Şehir Grafik
            baglanti.Open();
            SqlCommand komutgr1 = new SqlCommand("Select PerSehir, Count(*) from Tbl_Per Group By PerSehir", baglanti);
            SqlDataReader dr1 = komutgr1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //Maaş Grafik

            baglanti.Open();
            SqlCommand komutgr2 = new SqlCommand("Select PerMeslek, AVG(PerMaas) from Tbl_Per Group By PerMeslek", baglanti);
            SqlDataReader dr2 = komutgr2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
