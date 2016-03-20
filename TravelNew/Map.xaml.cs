using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        public Map()
        {
            InitializeComponent();
            string destination = InfoPlace.city;
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8888/connection/");
            listener.Start();
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            string responseStr = string.Format("<html><head><meta charset='utf8'></head><body><iframe width=\"600\" height=\"450\" frameborder=\"0\" style=\"border:0\" src=\"https://www.google.com/maps/embed/v1/directions?key=AIzaSyDsbNIjE-pBjQwmK1Wjkv25csvxu-r5f4E&origin=Moscow&destination={0}&avoid=tolls|highways\" allowfullscreen></iframe></body></html>", destination);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            listener.Stop();
        }
    }
}
