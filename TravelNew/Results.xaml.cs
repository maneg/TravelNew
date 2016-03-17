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
        SqlDataReader dr;

        public Results()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Info inf = new Info();
            object item_select = listresults.SelectedItem;
            InfoPlace.a = item_select;


            cmd.Connection = con;
            con.Open();
            cmd.CommandText =
            "SELECT Place.Name FROM Place JOIN Country ON Country.Idcountry = Place.Idcountry WHERE Place.Name =" + item_select.ToString();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    inf.information.Text = dr[0].ToString();
                }
            }

            inf.information.Text = InfoPlace.info;
            inf.ShowDialog();
        }
    }
}
