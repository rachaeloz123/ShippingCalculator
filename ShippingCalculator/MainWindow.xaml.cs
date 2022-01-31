using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace ShippingCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<HotelProducts> MasterList = new List<HotelProducts>();
        public List<List<string>> TempMasterList = new List<List<string>>();
        public MainWindow()
        {
            var masterListRaw = File.ReadAllText("C:\\dev\\CalculatorTool\\1.csv");
            var removeN = masterListRaw.Replace("\n","");
            string[] split = removeN.Split('\r');

            var splitList = split.Select(var => var.Split(',')).Select(tempArray => tempArray.ToList()).ToList();
            TempMasterList = splitList;
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow popup = new AddProductWindow(TempMasterList);
            popup.ShowDialog();
        }
    }
}
