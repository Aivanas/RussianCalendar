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

namespace RussianCal
{
    /// <summary>
    /// Логика взаимодействия для SelectionPage.xaml
    /// </summary>
    public partial class SelectionPage : Page
    {
        List<SelectControl> list = new List<SelectControl>();
        public SelectionPage()
        {
            InitializeComponent();
            
            SelectControl selectControl = new SelectControl();
            selectControl.CardTextBlock.Text = "Шаман";
            selectControl.ArtistImage.Source = new BitmapImage(new Uri("/shaman.png", UriKind.RelativeOrAbsolute));
            list.Add(selectControl);

            SelectControl selectControl1 = new SelectControl();
            selectControl1.CardTextBlock.Text = "Газманов";
            selectControl1.ArtistImage.Source = new BitmapImage(new Uri("/gazmanov.png", UriKind.RelativeOrAbsolute));
            list.Add(selectControl1);

            SelectControl selectControl2 = new SelectControl();
            selectControl2.CardTextBlock.Text = "Расторгуев";
            selectControl2.ArtistImage.Source = new BitmapImage(new Uri(("/Rastorguev.png"), UriKind.Relative));
            list.Add(selectControl2);



            ArtistList.ItemsSource = list;
        }
    }
}
