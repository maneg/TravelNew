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
           
            place.Text = InfoPlace.placename;
            country.Text = InfoPlace.country;
            capital.Text = InfoPlace.capital;
            information.Text = InfoPlace.info;
            
            int op = InfoPlace.id;
            string q = string.Format("/WpfApplication1;component/ert/{0}.jpg", op);
           // poi.Source = new BitmapImage(new Uri(q, UriKind.RelativeOrAbsolute));
           
           
            
        }
    }
}
