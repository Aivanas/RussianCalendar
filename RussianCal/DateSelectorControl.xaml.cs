﻿using System;
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
    /// Логика взаимодействия для DateSelectorControl.xaml
    /// </summary>
    public partial class DateSelectorControl : UserControl
    {
        public DateSelectorControl()
        {
            InitializeComponent();
        }

        private void DateSelectButton_Click(object sender, RoutedEventArgs e)
        {
            DatePicker.IsDropDownOpen = true;
        }
    }
}
