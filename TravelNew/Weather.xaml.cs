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
            speed1.Text = speed.ToString();
           
           InfoPlace.WeatherInfo(city2, out lat, out longi, out speed, out temp, out pressure, out himidity);

           temp2.Text = temp.ToString();
           press2.Text = pressure.ToString();
           himi2.Text = himidity.ToString();
           speed2.Text = speed.ToString();
        }

        private void temp1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
