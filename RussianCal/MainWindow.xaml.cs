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
    /// 

    
    public partial class MainWindow : Window
    {
      
        CalPage calPage;
        public MainWindow()
        {
            InitializeComponent();
            NotesList.ReadNotes();
            DatePickerName.SelectedDate = DateTime.Now;
            PagesFrame.Content = new CalPage(this);
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime oldDateTime = (DateTime)DatePickerName.SelectedDate;
            if (oldDateTime.Month == 12)
            {
                DateTime newDateTime = new DateTime((oldDateTime.Year + 1), 1, oldDateTime.Day);
                DatePickerName.SelectedDate = newDateTime;
            }
            else
            {
                DateTime newDateTime = new DateTime(oldDateTime.Year, (oldDateTime.Month + 1), oldDateTime.Day);
                DatePickerName.SelectedDate = newDateTime;
            }
        }


        private void DatePickerName_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            PagesFrame.Content = new CalPage(this);
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime oldDateTime = (DateTime)DatePickerName.SelectedDate;
            if(oldDateTime.Month == 1) {
                DateTime newDateTime = new DateTime((oldDateTime.Year-1), 12, oldDateTime.Day);
                DatePickerName.SelectedDate = newDateTime;
            }
            else
            {
                DateTime newDateTime = new DateTime(oldDateTime.Year, (oldDateTime.Month - 1), oldDateTime.Day);
                DatePickerName.SelectedDate = newDateTime;
            }

            
        }

        private void LeftSubButton_Click(object sender, RoutedEventArgs e)
        {
            if (PagesFrame.NavigationService.CanGoBack)
            {
                PagesFrame.NavigationService.GoBack();
            }
            DatePickerName.Visibility = Visibility.Visible;
            MiddleTextBlock.Visibility = Visibility.Hidden;
            RightButton.Visibility = Visibility.Visible;
            LeftButton.Visibility = Visibility.Visible;
        }
    }


   
    

}
