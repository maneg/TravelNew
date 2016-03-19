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
    //true проект
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Find finder = new Find();
            finder.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChoiceUser ch = new ChoiceUser();
            ch.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedid = rnd.Next(1, 122);
            
            ShowQuery sq = new ShowQuery();
            sq.ShowPlace(selectedid);
        }
    }
}
