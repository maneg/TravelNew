using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Reflection;

namespace TravelNew
{
    /// <summary>
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelData.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr, dr2;

        public Results()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            int selectedindex = listresults.SelectedIndex;
            int selectedid = InfoPlace.cparray[selectedindex].Id;


            cmd.Connection = con;
            con.Open();
            cmd.CommandText =
            "SELECT * FROM Place WHERE Place.idplace =" + selectedid;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    InfoPlace.placename = dr[1].ToString();
                    InfoPlace.info=dr[10].ToString();
                    InfoPlace.id=int.Parse(dr[0].ToString());
                    InfoPlace.idcountry = int.Parse(dr[2].ToString());
                }
            }
            con.Close();

            cmd.Connection = con;
            con.Open();
            cmd.CommandText =
            "SELECT * FROM Country WHERE Country.IdCountry =" + InfoPlace.idcountry;
            dr2 = cmd.ExecuteReader();
            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    InfoPlace.info_dangerous = dr2[4].ToString();
                    InfoPlace.capital = dr2[2].ToString();
                    InfoPlace.country = dr2[1].ToString();
                    InfoPlace.info_visa = dr2[10].ToString();
                    InfoPlace.currency_foreign=dr2[8].ToString();
                }
            }

            con.Close();
            Info inf = new Info();
            
            inf.ShowDialog();
        }
    }
}
