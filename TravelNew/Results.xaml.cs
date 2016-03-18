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
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        ShowQuery sq = new ShowQuery();

        public Results()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listresults.SelectedIndex == 1)
            {
                int selectedindex = listresults.SelectedIndex;
                int selectedid = InfoPlace.cparray[selectedindex].Id;

                sq.ShowPlace(selectedid);
            }
            else
            {
                MessageBox.Show("Выберите место!");
            }
        }
    }
}
