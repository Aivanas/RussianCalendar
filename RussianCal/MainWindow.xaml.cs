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
using MaterialDesignThemes.Wpf;

namespace RussianCal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PagesFrame.Content = new CalPage();
            /*
            DateSelectorControl dateSelectorControl = new DateSelectorControl();
            dateSelectorControl.DateTextBox.Text = "20е абупа 2023";
            ToolBar.Children.Add(dateSelectorControl);
            Grid.SetColumn(dateSelectorControl, 1);*/
            
            
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {

            
            

        }
    }


   
    

}
