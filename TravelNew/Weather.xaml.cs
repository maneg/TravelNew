using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Weather.xaml
    /// </summary>
    public partial class Weather : Window
    {
        public Weather()
        {
            InitializeComponent();
            
            WeatherDoing();
            
        }

        public void WeatherDoing()
        {
            string city1 = "Moscow";
            string city2 = InfoPlace.city;
            double lat;
            double longi;
            double speed;
            double temp;
            double pressure;
            double himidity;
            
            InfoPlace.WeatherInfo(city1, out lat, out longi, out speed, out temp, out pressure, out himidity);

            temp1.Text = temp.ToString();
            press1.Text = pressure.ToString();
            himi1.Text = himidity.ToString();

            //double lat2;
            //double longi2;
            //double speed2;
            //double temp0;
            //double pressure2;
            //double himidity2;
            //InfoPlace.WeatherInfo(city2, out lat2, out longi2, out speed2, out temp2, out pressure2, out himidity2);

            //temp2.Text = temp2.ToString();
            //press2.Text = pressure2.ToString();
            //himi2.Text = himidity2.ToString();
            
        }

        private void temp1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
