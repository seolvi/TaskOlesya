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

namespace TechnicalShop.Components
{
    /// <summary>
    /// Логика взаимодействия для ItemUserControl.xaml
    /// </summary>
    public partial class MeUserControl : UserControl
    {
        public MeUserControl(Product product)
        {
            InitializeComponent();
            //if(product.MainImagePath == null)

            if(product.MainImage == null)
                MainImage.Source = new BitmapImage(new Uri(@"/Resources/id_114593.1.jpg", UriKind.Relative));
            else
                MainImage.Source = GetImage(product.MainImage);
            TitleTb.Text = product.Title;
            NewPrice.Text = product.CostDiscount;
            OldPrice.Visibility = product.CostVisibility;
            EvalutionTb.Text = product.OverrideFeedback;
            OldPrice.Text = product.Cost.ToString("N0");
            BasketBt.Source = new BitmapImage(new Uri(@"/Resources/Basket.png", UriKind.Relative));
            LikeBt.Source = new BitmapImage(new Uri(@"/Resources/Heart.png", UriKind.Relative));
            StatisticBt.Source = new BitmapImage(new Uri(@"/Resources/Statistik.png", UriKind.Relative));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private BitmapImage GetImage(byte[] byteImage)
        {
            if (byteImage != null)
            {
                MemoryStream byteStream = new MemoryStream(byteImage);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                return image;
            }
            return null;
        }
    }
}
