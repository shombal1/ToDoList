using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.IO;

namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<Model> modelList;
        string path = $"{Environment.CurrentDirectory}\\data.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void datalist_Loaded(object sender, RoutedEventArgs e)
        {
            modelList = new BindingList<Model>();
            bool Valib = File.Exists(path);
            if (Valib)
            {
                StreamReader reader= File.OpenText(path);
                string ret= reader.ReadToEnd();
                modelList= JsonConvert.DeserializeObject<BindingList<Model>>(ret);
                reader.Dispose();
            }
            else
            {
                File.CreateText(path).Dispose();
            }
            datalist.ItemsSource = modelList;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            StreamWriter stream = File.CreateText(path);
            string output = JsonConvert.SerializeObject(modelList);
            stream.Write(output);
            stream.Dispose();
        }
    }
}
