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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechnicalShop.Baseы;
using TechnicalShop.Components;

namespace TechnicalShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            if (App.IsAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            var ProductList = App.db.Product.ToList();
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Product> ProductSortList = App.db.Product;
            if (SortCb.SelectedIndex > 0)
            {
                if (SortCb.SelectedIndex == 1)
                {
                    ProductSortList = ProductSortList.OrderBy(x => x.Cost);
                }
                else
                {
                    ProductSortList = ProductSortList.OrderByDescending(x => x.Cost);
                }
            }
            if (FilterDiscountCb.SelectedIndex != 0)
            {
                if (FilterDiscountCb.SelectedIndex == 1)
                    ProductSortList = ProductSortList.Where(x => x.Discount >= 0 && x.Discount < 5);
                else if (FilterDiscountCb.SelectedIndex == 2)
                    ProductSortList = ProductSortList.Where(x => x.Discount >= 5 && x.Discount < 15);
                else if (FilterDiscountCb.SelectedIndex == 3)
                    ProductSortList = ProductSortList.Where(x => x.Discount >= 15 && x.Discount < 30);
                else if (FilterDiscountCb.SelectedIndex == 4)
                    ProductSortList = ProductSortList.Where(x => x.Discount >= 30 && x.Discount < 70);
                else if (FilterDiscountCb.SelectedIndex == 5)
                    ProductSortList = ProductSortList.Where(x => x.Discount >= 70 && x.Discount <= 100);

            }

            if (SearchTb.Text != null)
            {
                ProductSortList = ProductSortList.Where(x => x.Title.ToLower().Contains
                (SearchTb.Text.ToLower()) || x.Description.ToLower().Contains
                (SearchTb.Text.ToLower()));
            }
            CountDataTb.Text = ProductSortList.Count() + " из " + App.db.Product.Count();
            ServicesWp.Children.Clear();
            foreach (var Product in ProductSortList)
            {
                ServicesWp.Children.Add(new MeUserControl(Product));
            }
        }

            private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void FilterDiscountCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
