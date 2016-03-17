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
    /// Логика взаимодействия для ChoiceUser.xaml
    /// </summary>
    public partial class ChoiceUser : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelData.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public ChoiceUser()
        {
            InitializeComponent();
        }

        string sqlnature,
            sqlsea,
            sqlmountains,
            sqlresort,
            sqlskiresort,
            sqlactive,
            sqlhistorical,
            sqldangerous,
            sqlexotic,
            sqlvisa;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Results res = new Results();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText =
                "SELECT Place.Name FROM Place JOIN Country ON Country.Idcountry = Place.Idcountry WHERE Place.Nature =" + sqlnature +
            "AND Place.Sea =" + sqlsea +
            "AND Place.Mountains =" + sqlmountains +
            "AND Place.Resort =" + sqlresort +
            "AND Place.Skiresort =" + sqlskiresort +
            "AND Place.Active =" + sqlactive +
            "AND Place.Historical =" + sqlhistorical+
            "AND Country.Dangerous =" + sqldangerous +
            "AND Country.Exotic =" + sqlexotic +
            "AND Country.Visa =" + sqlvisa;

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    res.listresults.Items.Add(dr[0].ToString());
                }
            }

            con.Close();
            res.ShowDialog();
        }

        

        public void DBPath()
        {
            string str = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            str = str.Substring(6, str.Length - 15);
            AppDomain.CurrentDomain.SetData("DataDirectory", str);
        }

        

        private void yes2_Checked(object sender, RoutedEventArgs e)
        {
            sqlsea = "1";
        }

        private void no2_Checked(object sender, RoutedEventArgs e)
        {
            sqlsea = "0";
        }

        private void yes3_Checked(object sender, RoutedEventArgs e)
        {
            sqlmountains = "1";
        }

        private void no3_Checked(object sender, RoutedEventArgs e)
        {
            sqlmountains = "0";
        }

        private void yes4_Checked(object sender, RoutedEventArgs e)
        {
            sqlresort = "1";
        }

        private void no4_Checked(object sender, RoutedEventArgs e)
        {
            sqlresort = "0";
        }

        private void yes5_Checked(object sender, RoutedEventArgs e)
        {
            sqlhistorical = "1";
        }

        private void no5_Checked(object sender, RoutedEventArgs e)
        {
            sqlhistorical = "0";
        }

        private void yes6_Checked(object sender, RoutedEventArgs e)
        {
            sqlskiresort = "1";
        }

        private void no6_Checked(object sender, RoutedEventArgs e)
        {
            sqlskiresort = "0";
        }

        private void yes7_Checked(object sender, RoutedEventArgs e)
        {
            sqlactive = "1";
        }

        private void no7_Checked(object sender, RoutedEventArgs e)
        {
            sqlactive = "0";
        }

        private void yes8_Checked(object sender, RoutedEventArgs e)
        {
            sqldangerous = "1";
        }

        private void no8_Checked(object sender, RoutedEventArgs e)
        {
            sqldangerous = "0";
        }

        private void yes9_Checked(object sender, RoutedEventArgs e)
        {
            sqlexotic = "1";
        }

        private void no9_Checked(object sender, RoutedEventArgs e)
        {
            sqlexotic = "0";
        }

        private void yes10_Checked(object sender, RoutedEventArgs e)
        {
            sqlvisa = "1";
        }

        private void no10_Checked(object sender, RoutedEventArgs e)
        {
            sqlvisa = "0";
        }

        private void yes1_Checked(object sender, RoutedEventArgs e)
        {
            sqlnature = "1";
        }

        private void no1_Checked(object sender, RoutedEventArgs e)
        {
            sqlnature = "0";
        }

        
    }
}
