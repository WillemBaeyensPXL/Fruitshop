using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Fruitshop.Application;
using Fruitshop.Domain;

namespace Fruitshop.Presentation
{
    /// <summary>
    /// Interaction logic for OverviewWindow.xaml
    /// </summary>
    public partial class OverviewWindow : Window
    {
        private FruitService _fruitService;

        public OverviewWindow()
        {
            InitializeComponent();

            _fruitService = new FruitService();

            RefreshListBox();
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            if(fruitListBox.SelectedItem is Fruit selectedFruit)
            {
                _fruitService.Delete(selectedFruit);
                RefreshListBox();
            }
        }

        private void OnCreate(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshListBox()
        {
            fruitListBox.ItemsSource = _fruitService.GetAllFruits();

        }

        private void OnListBoxDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
