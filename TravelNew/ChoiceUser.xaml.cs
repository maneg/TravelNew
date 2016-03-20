﻿using System;
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
               sqlvisa,
               sqlcountry = " ";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Results res = new Results();
            InfoPlace.cparray.Clear();
            if (eu.IsChecked == true)
                sqlcountry += " Continent.Idcontinent = 1 OR ";
            if (sam.IsChecked == true)
                sqlcountry += " Continent.Idcontinent = 2 OR ";
            if (austr.IsChecked == true)
                sqlcountry += " Continent.Idcontinent = 3 OR ";
            if (nam.IsChecked == true) 
                sqlcountry += " Continent.Idcontinent = 4 OR ";
            if (af.IsChecked == true)
                sqlcountry += " Continent.Idcontinent = 5 OR ";
            if (asia.IsChecked == true)
                sqlcountry += " Continent.Idcontinent = 6 OR ";
         //   if (eu.IsChecked == false && sam.IsChecked == false && austr.IsChecked == false && nam.IsChecked == false && af.IsChecked == false && asia.IsChecked == false)
           // MessageBox.Show("Выберите континет!");
           
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Place.Name, Place.IdPlace FROM Place " +
                                   "JOIN Country ON Place.Idcountry = Country.Idcountry " +
                                   "JOIN Continent ON Country.Idcontinent = Continent.Idcontinent WHERE (Place.Nature =" + sqlnature +
                //"AND (Place.Sea =" + sqlsea +
                //"AND (Place.Mountains =" + sqlmountains +
                //"AND (Place.Resort =" + sqlresort +
                //"AND (Place.Skiresort =" + sqlskiresort +
                //"AND (Place.Active =" + sqlactive +
                //"AND (Place.Historical =" + sqlhistorical +
                //"AND (Country.Dangerous =" + sqldangerous +
                //"AND (Country.Exotic =" + sqlexotic;
                //"AND (" + sqlvisa +
                     " AND (" + sqlcountry + " Continent.Idcontinent = 7)";

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
            res.titlr.Text=string.Format("Найдено {0} мест", res.listresults.Items.Count.ToString() );
            
            con.Close();
            res.ShowDialog();
        }

        public void DBPath()
        {
            string str = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            str = str.Substring(6, str.Length - 15);
            AppDomain.CurrentDomain.SetData("DataDirectory", str);
        }

        private void yes1_Checked(object sender, RoutedEventArgs e)
        {
            sqlnature = "1)";
        }

        private void no1_Checked(object sender, RoutedEventArgs e)
        {
            sqlnature = "0)";
        }

        private void yn1_Checked(object sender, RoutedEventArgs e)
        {
            sqlnature = "1 OR Place.Nature = 0)";
        }

        private void yes2_Checked(object sender, RoutedEventArgs e)
        {
            sqlsea = "1)";
        }

        private void no2_Checked(object sender, RoutedEventArgs e)
        {
            sqlsea = "0)";
        }

        private void yn2_Checked(object sender, RoutedEventArgs e)
        {
            sqlsea = "1 OR Place.Sea = 0)";
        }

        private void yes3_Checked(object sender, RoutedEventArgs e)
        {
            sqlmountains = "1)";
        }

        private void no3_Checked(object sender, RoutedEventArgs e)
        {
            sqlmountains = "0)";
        }

        private void yn3_Checked(object sender, RoutedEventArgs e)
        {
            sqlmountains = "1 OR Place.Mountains = 0)";
        }

        private void yes4_Checked(object sender, RoutedEventArgs e)
        {
            sqlresort = "1)";
        }

        private void no4_Checked(object sender, RoutedEventArgs e)
        {
            sqlresort = "0)";
        }

        private void yn4_Checked(object sender, RoutedEventArgs e)
        {
            sqlresort = "1 OR Place.Resort = 0)";
        }

        private void yes5_Checked(object sender, RoutedEventArgs e)
        {
            sqlhistorical = "1)";
        }

        private void no5_Checked(object sender, RoutedEventArgs e)
        {
            sqlhistorical = "0)";
        }

        private void yn5_Checked(object sender, RoutedEventArgs e)
        {
            sqlhistorical = "1 OR Place.Historical = 0)";
        }

        private void yes6_Checked(object sender, RoutedEventArgs e)
        {
            sqlskiresort = "1)";
        }

        private void no6_Checked(object sender, RoutedEventArgs e)
        {
            sqlskiresort = "0)";
        }

        private void yn6_Checked(object sender, RoutedEventArgs e)
        {
            sqlskiresort = "1 OR Place.Skiresort = 0)";
        }

        private void yes7_Checked(object sender, RoutedEventArgs e)
        {
            sqlactive = "1)";
        }

        private void no7_Checked(object sender, RoutedEventArgs e)
        {
            sqlactive = "0)";
        }

        private void yn7_Checked(object sender, RoutedEventArgs e)
        {
            sqlactive = "1 OR Place.Active = 0)";
        }

        private void yes8_Checked(object sender, RoutedEventArgs e)
        {
            sqldangerous = "1)";
        }

        private void no8_Checked(object sender, RoutedEventArgs e)
        {
            sqldangerous = "0)";
        }

        private void yn8_Checked(object sender, RoutedEventArgs e)
        {
            sqldangerous = "1 OR Country.Dangerous = 0)";
        }

        private void yes9_Checked(object sender, RoutedEventArgs e)
        {
            sqlexotic = "1)";
        }

        private void no9_Checked(object sender, RoutedEventArgs e)
        {
            sqlexotic = "0)";
        }

        private void yn9_Checked(object sender, RoutedEventArgs e)
        {
            sqlexotic = "1 OR Country.Exotic = 0)";
        }

        private void yes10_Checked(object sender, RoutedEventArgs e)
        {
            sqlvisa = "Country.Visa is not NULL)";
        }

        private void no10_Checked(object sender, RoutedEventArgs e)
        {
            sqlvisa = "Country.Visa > " + int.Parse(infotext.Text) + ")";       
        }

        private void yn10_Checked(object sender, RoutedEventArgs e)
        {
            sqlvisa = "Country.Visa is not NULL)";
        }

        
            private void infotext_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int iValue = -1;

            if (Int32.TryParse(textBox.Text, out iValue) == false)
            {
                TextChange textChange = e.Changes.ElementAt<TextChange>(0);
                int iAddedLength = textChange.AddedLength;
                int iOffset = textChange.Offset;

                textBox.Text = textBox.Text.Remove(iOffset, iAddedLength);
            } 
        }

            private void infotext_KeyDown(object sender, KeyEventArgs e)
            {

            }
        
    }
}
