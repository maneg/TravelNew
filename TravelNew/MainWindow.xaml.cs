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
        public MainWindow()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\TravelData.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
        }
        public void DBpath()
        {
            string str = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            str = str.Substring(6, str.Length - 15);
            AppDomain.CurrentDomain.SetData("DataDirectory", str);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChoiceUser ch = new ChoiceUser();
            ch.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("короче тут пока пусто");
        }
    }
}
