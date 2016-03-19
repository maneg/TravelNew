using System;
using System.Collections.Generic;
using System.Globalization;
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
            double exam = double.Parse(s, CultureInfo.InvariantCulture);
            
            name_curr.Text = string.Format("Валюта страны {0} - {1}", InfoPlace.country, InfoPlace.currency_foreign);
            if (exam != -2)
                name_curr2.Text = string.Format("В 1 {0} - {1} рублей", InfoPlace.currency_foreign, s);
            else
                name_curr2.Text = string.Format("К сожалению, информация о курсе данной валюты отсутствует.");
            
        }
    }
}
