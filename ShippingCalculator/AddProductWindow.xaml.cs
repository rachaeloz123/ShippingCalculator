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

namespace ShippingCalculator
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window 
    {
        public List<string> HotelsList = new List<string>();
        public List<List<string>> MasterList = new List<List<string>>();
        
        public AddProductWindow(List<List<string>> tempMasterList)
        {
            MasterList = tempMasterList;
            string currentHotel = "";
            string oldHotel = "";
            foreach (var row in tempMasterList)
            {
                currentHotel = row[0];
                if (currentHotel != oldHotel)
                {
                    HotelsList.Add(row[0]);
                }
                oldHotel = row[0];
            }
            InitializeComponent();
            HOTELS.ItemsSource = HotelsList;

            //What to do next
            //Write the code for the HOTELS_SelectionChanged to filter only by the selected hotel's products
            //Then double click the next combo box to create a function for it and filter down by the sizes.
            //Size data should be included in the masterList row or it can be looked up later so don't worry too much there.
            //Work on getting the lists to populate in sequence. You will need to make them blank then populate based off the previous combobox
            //Don't forget to remove the hard coded xaml values
            //P.s. I love you bebs
        }


        private HotelProducts Button_Click(object sender, RoutedEventArgs e)
        {
            string selectedHotel = HOTELS.SelectedValue.ToString();
            string selectedProduct = PRODUCT.SelectedValue.ToString();
            string selectedSize = SIZE.SelectedValue.ToString();
            int selectedQuantity = Int32.Parse(QUANTITY.Text);

            HotelProducts Product = new HotelProducts();

            foreach (var row in MasterList)
            {
                if (row[0] == selectedHotel)
                {
                    if (row[1] == selectedProduct)
                    {
                        if (row[2] == selectedSize)
                        {
                            Product.Hotel = row[0];
                            Product.Name = row[1];
                            Product.Size = row[2];
                            Product.WeightPerBox = float.Parse(row[3]);
                            Product.Length = float.Parse(row[4]);
                            Product.Width = float.Parse(row[5]);
                            Product.Height = float.Parse(row[6]);
                            Product.WeightPerItem = float.Parse(row[7]);
                            Product.QuantityInBox = int.Parse(row[8]);
                            Product.BoxesPerSkid = int.Parse(row[9]);
                            Product.BoxesPerRow = int.Parse(row[10]);
                            Product.Quantity = selectedQuantity;
                        }
                    }
                }
            }

            return Product;
        }

        private void HOTELS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedHotel = HOTELS.SelectedValue.ToString();
            var selectedProductList = new List<string>();
            string currentProduct = "";
            string oldProduct = "";

            foreach (var row in MasterList)
            {
                currentProduct = row[1];
                if (row[0] == selectedHotel)
                {
                    if (currentProduct != oldProduct)
                    {
                        selectedProductList.Add(row[1]);
                    }
                }
                oldProduct = row[1];
            }

            PRODUCT.ItemsSource = selectedProductList;

        }

        private void PRODUCT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = PRODUCT.SelectedValue.ToString();
            var selectedHotel = HOTELS.SelectedValue.ToString();
            var selectedSizeList = new List<string>();

            foreach (var row in MasterList)
            {
                if (selectedHotel == row[0])
                {
                    if (row[1] == selectedProduct)
                    {
                        selectedSizeList.Add(row[2]);
                    }
                }
            }

            SIZE.ItemsSource = selectedSizeList;
        }
    }
}
