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
        
        public CalPage()
        {
            InitializeComponent();
            MakeCal(DateTime.Now.Month);
            //MakeCal(2);
        }


        public void MakeCal(int month)
        {

            int[] monthDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int row = 0;
            int column = 0;
            for (int i = 0; i < monthDays[month - 1]; i++)
            {
                Button button = new Button();
                ButtonControl buttonControl = new ButtonControl();
                buttonControl.DateTextBlock.Text = (i + 1).ToString();
                button.Content = buttonControl;
                button.Padding = new Thickness(0);

                //button.Content = (i + 1).ToString();



                button.Margin = new Thickness(1);
                button.Name = "Button" + (i+1);
                button.Style = (Style)Application.Current.Resources["MaterialDesignPaperSecondaryDarkButton"];
                button.Height = button.Width;
                button.Click += DateButton_OnClick;


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
            //Button clickedButton = (Button)sender;
            //MessageBox.Show(clickedButton.Name.ToString());

            //PagesFrame.Content = new SelectionPage();
        }



    }
}
