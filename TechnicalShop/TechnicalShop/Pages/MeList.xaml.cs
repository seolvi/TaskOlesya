using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для ItemList.xaml
    /// </summary>
    public partial class ItemList : Page
    {
        public ItemList()
        {
            InitializeComponent();
            IEnumerable<Product> productSortList = App.db.Product;
            string OnePath = "C:\\Users\\222122\\Desktop\\Магазин техники\\";
            foreach (var product in productSortList)
            {
                product.MainImage = File.ReadAllBytes(OnePath + product.MainImagePath);
                MainWp.Children.Add(new MeUserControl(product));
            }
            App.db.SaveChanges();
        }
    }
}
