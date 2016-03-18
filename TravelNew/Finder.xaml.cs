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
using System.Windows.Shapes;

namespace TravelNew
{
    /// <summary>
    /// Логика взаимодействия для Find.xaml
    /// </summary>
    public partial class Find : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelData.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr, dr1, drplace, drcountry;

        public Find()
        {
            InitializeComponent();

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Country.IdCountry, Country.CountryName FROM Country";

            dr1 = cmd.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    InfoPlace.ccarray.Add(new ChosenP(int.Parse(dr1[0].ToString()), dr1[1].ToString()));
                    country.Items.Add(dr1[1].ToString());
                }
            }
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedindex = place.SelectedIndex;
            int selectedid = InfoPlace.cparray[selectedindex].Id;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText =
            "SELECT * FROM Place WHERE Place.Idplace =" + selectedid;
            drplace = cmd.ExecuteReader();
            if (drplace.HasRows)
            {
                while (drplace.Read())
                {
                    InfoPlace.placename = drplace[1].ToString();
                    InfoPlace.info = drplace[10].ToString();
                    InfoPlace.id = int.Parse(drplace[0].ToString());
                    InfoPlace.idcountry = int.Parse(drplace[2].ToString());
                }
            }
            con.Close();

            cmd.Connection = con;
            con.Open();
            cmd.CommandText =
            "SELECT * FROM Country WHERE Country.IdCountry =" + InfoPlace.idcountry;
            drcountry = cmd.ExecuteReader();
            if (drcountry.HasRows)
            {
                while (drcountry.Read())
                {
                    InfoPlace.info_dangerous = drcountry[4].ToString();
                    InfoPlace.capital = drcountry[2].ToString();
                    InfoPlace.country = drcountry[1].ToString();
                    InfoPlace.info_visa = drcountry[10].ToString();
                    InfoPlace.currency_foreign = drcountry[8].ToString();
                }
            }
            con.Close();
            Info inf = new Info();
            inf.ShowDialog();
        }

        private void country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoPlace.cparray.Clear();
            int selectedindex = country.SelectedIndex;
            int selectedid = InfoPlace.ccarray[selectedindex].Id;

            cmd.Connection = con;
            place.Items.Clear();
            con.Open();
            cmd.CommandText =
            "SELECT place.idplace,Place.Name FROM Place JOIN Country ON Country.Idcountry = Place.Idcountry WHERE Country.idcountry =" + selectedid;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    place.Items.Add(dr[1].ToString());
                    InfoPlace.cparray.Add(new ChosenP(int.Parse(dr[0].ToString()), dr[1].ToString()));
                }
            }
            con.Close();
        }
    }
}
