using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNew
{
    public class ShowQuery
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelData.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader drplace, drcountry;

        public  void ShowPlace(int selectedid)
        {
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
                    InfoPlace.city = drplace[12].ToString();
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
                    InfoPlace.currency_foreign_code = drcountry[8].ToString();
                    InfoPlace.currency_foreign = drcountry[7].ToString();
                }
            }
            con.Close();

            Info inf = new Info();
            inf.ShowDialog();
        }

    }
}
