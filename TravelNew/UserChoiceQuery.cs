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
    public class UserChoiceQuery
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelData.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public void Choice(string sqlnature, string sqlsea, string sqlmountains,
               string sqlresort, string sqlskiresort, string sqlactive, string sqlhistorical,
               string sqldangerous, string sqlexotic, string sqlvisa, string sqlcountry)
        {
            Results res = new Results();
            InfoPlace.cparray.Clear();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Place.Name, Place.IdPlace FROM Place " +
                              "JOIN Country ON Place.Idcountry = Country.Idcountry " +
                              "JOIN Continent ON Country.Idcontinent = Continent.Idcontinent WHERE (Place.Nature =" + sqlnature +
                              "AND (Place.Sea =" + sqlsea +
                              "AND (Place.Mountains =" + sqlmountains +
                              "AND (Place.Resort =" + sqlresort +
                              "AND (Place.Skiresort =" + sqlskiresort +
                              "AND (Place.Active =" + sqlactive +
                              "AND (Place.Historical =" + sqlhistorical +
                              "AND (Country.Dangerous =" + sqldangerous +
                              "AND (Country.Exotic =" + sqlexotic +
                              "AND (" + sqlvisa +
                              "AND (" + sqlcountry + " Continent.Idcontinent = 7)";

            sqlcountry = "";

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ChosenP cp = new ChosenP(int.Parse(dr[1].ToString()), dr[0].ToString());
                    InfoPlace.cparray.Add(cp);
                    res.listresults.Items.Add(dr[0].ToString());
                }

            }
            int amount=res.listresults.Items.Count; 
            res.titlr.Text = string.Format("Найдено {0} мест", amount.ToString());
            if (amount == 0)
            {
                MessageBox.Show("Измените критерии выбора!");
                con.Close();
            }
            else
            {
                con.Close();
                res.ShowDialog();
            }
        }

        public void DBPath()
        {
            string str = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            str = str.Substring(6, str.Length - 15);
            AppDomain.CurrentDomain.SetData("DataDirectory", str);
        }
    }
}
