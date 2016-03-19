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
    /// Логика взаимодействия для Currency.xaml
    /// </summary>
    public partial class Currency : Window
    {
        public Currency()
        {
            InitializeComponent();
            string s;
            InfoPlace.CurrencyInfo(out s);
            country.Text = InfoPlace.country;
            amount.Text = s;
            name_curr.Text = InfoPlace.currency_foreign;
            name_curr2.Text = InfoPlace.currency_foreign;

        }
    }
}
