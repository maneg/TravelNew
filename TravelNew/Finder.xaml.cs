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
        SqlDataReader dr;

        ShowQuery sq = new ShowQuery();

        public Find()
        {
            InitializeComponent();

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Country.IdCountry, Country.CountryName FROM Country";

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    InfoPlace.ccarray.Add(new ChosenP(int.Parse(dr[0].ToString()), dr[1].ToString()));
                    country.Items.Add(dr[1].ToString());
                }
            }
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (place.SelectedIndex == 1)
            {
                int selectedindex = place.SelectedIndex;
                int selectedid = InfoPlace.cparray[selectedindex].Id;
                sq.ShowPlace(selectedid);
            }
            else
            {
                MessageBox.Show("Выберите место!");
            }
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
            "SELECT Place.Idplace,Place.Name FROM Place JOIN Country ON Country.Idcountry = Place.Idcountry WHERE Country.Idcountry =" + selectedid;
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
