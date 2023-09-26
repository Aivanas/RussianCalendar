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
    /// Логика взаимодействия для CalPage.xaml
    /// </summary>
    /// 


    public partial class CalPage : Page
    {
        public static DateTime date;
        private MainWindow _mainWindow;


        public CalPage(MainWindow mainWindow)
        {
            InitializeComponent();
            MakeCal((DateTime)mainWindow.DatePickerName.SelectedDate);
            _mainWindow = mainWindow;
        }


        public void MakeCal(DateTime date)
        {

            int[] monthDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int row = 0;
            int column = 0;
            for (int i = 0; i < monthDays[date.Month - 1]; i++)
            {
                Button button = new Button();
                ButtonControl buttonControl = new ButtonControl();
                buttonControl.DateTextBlock.Text = (i + 1).ToString();
                button.Content = buttonControl;
                button.Tag = new DateTime(date.Year, date.Month, i+1); 
                button.Padding = new Thickness(0, 0, 0, 1);
                button.Margin = new Thickness(1);
                button.Name = "Button" + (i+1);
                button.Style = (Style)Application.Current.Resources["MaterialDesignPaperSecondaryDarkButton"];
                button.Height = button.Width;
                button.Click += DateButton_OnClick;
                Note listNote = NotesList.notesList.FirstOrDefault(note => note.date == (DateTime)button.Tag);
                if (listNote != null)
                {
                    if (listNote.isRastorguev)
                    buttonControl.ButtonImage.Source = new BitmapImage(new Uri("/Rastorguev.png", UriKind.Relative));

                    if(listNote.isGazmanov)
                        buttonControl.ButtonImage.Source = new BitmapImage(new Uri("/gazmanov.png", UriKind.Relative));

                    if(listNote.isShaman)
                        buttonControl.ButtonImage.Source = new BitmapImage(new Uri("/shaman.png", UriKind.Relative));
                }
 

                DatesGrid.Children.Add(button);
                if (column <= 6)
                {
                    Grid.SetColumn(button, column);
                    Grid.SetRow(button, row);
                    column++;
                }
                else
                {
                    column = 0;
                    row++;
                    Grid.SetColumn(button, column);
                    Grid.SetRow(button, row);
                    column++;
                }

            }
        }
        private void DateButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonControl buttonControl = clickedButton.Content as ButtonControl;
            _mainWindow.DatePickerName.Visibility = Visibility.Hidden;
            _mainWindow.MiddleTextBlock.Visibility = Visibility.Visible;
            _mainWindow.MiddleTextBlock.Text = ((DateTime) clickedButton.Tag).ToString("dd MMMM yyyy");
            _mainWindow.PagesFrame.Content = new SelectionPage((DateTime)clickedButton.Tag);
            _mainWindow.RightButton.Visibility = Visibility.Hidden;
            _mainWindow.LeftButton.Visibility = Visibility.Hidden;
            _mainWindow.LeftSubButton.Visibility = Visibility.Visible;



        }

       



    }
}
