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
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window 

    {
        public Info()
        {
            InitializeComponent();
            
                int op = InfoPlace.id;
                string q = string.Format("/TravelNew;component/places/{0}.jpg", op);
                top.Source = new BitmapImage(new Uri(q, UriKind.RelativeOrAbsolute));

                place.Text = InfoPlace.placename;
                country.Text = InfoPlace.country;
                capital.Text = InfoPlace.capital;
                information.Text = InfoPlace.info;
                dangerous_info.Text = InfoPlace.info_dangerous;
                visa_info.Text = InfoPlace.info_visa;
                if (visa_info.Text == "")
                    visa_info.Text = "Для въезда в эту страну виза обязательна.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Weather weath = new Weather();
                weath.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Отсутствиет связь с интернетом!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Currency cur = new Currency();
                cur.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Отсутствиет связь с интернетом!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Map map = new Map();
                map.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Отсутствиет связь с интернетом!");
            }
        }
    }
}
