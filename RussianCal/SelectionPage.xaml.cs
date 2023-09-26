using RussianCal.JSON;
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
        private DateTime _date;
        SelectControl selectControl;
        SelectControl selectControl1;
        SelectControl selectControl2;
        public SelectionPage(DateTime date)
        {
            InitializeComponent();
            _date = date;

            selectControl = new SelectControl();
            selectControl.CardTextBlock.Text = "Шаман";
            selectControl.ArtistImage.Source = new BitmapImage(new Uri("/shaman.png", UriKind.RelativeOrAbsolute));
            list.Add(selectControl);

            selectControl1 = new SelectControl();
            selectControl1.CardTextBlock.Text = "Газманов";
            selectControl1.ArtistImage.Source = new BitmapImage(new Uri("/gazmanov.png", UriKind.RelativeOrAbsolute));
            list.Add(selectControl1);

            selectControl2 = new SelectControl();
            selectControl2.CardTextBlock.Text = "Расторгуев";
            selectControl2.ArtistImage.Source = new BitmapImage(new Uri(("/Rastorguev.png"), UriKind.Relative));
            list.Add(selectControl2);

            int noteIndex = NotesList.FindNote(date);
            if (noteIndex != -1)
            {
                Note note = NotesList.notesList[noteIndex];
                selectControl.isSelected.IsChecked = note.isShaman;
                selectControl1.isSelected.IsChecked = note.isGazmanov;
                selectControl2.isSelected.IsChecked = note.isRastorguev;
                note.date = date;
            }
            ArtistList.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note();
            note.date = _date;
            int noteIndex = NotesList.FindNote(note.date);
            if (noteIndex != -1)
            {
                Note listNote = NotesList.notesList[noteIndex];
                listNote.date = _date;
                listNote.isShaman =(bool) selectControl.isSelected.IsChecked;
                listNote.isGazmanov = (bool)selectControl1.isSelected.IsChecked;
                listNote.isRastorguev = (bool)selectControl2.isSelected.IsChecked;
            }
            else
            {
                Note listNote = new Note();
                listNote.date = _date;
                listNote.isShaman = (bool)selectControl.isSelected.IsChecked;
                listNote.isGazmanov = (bool)selectControl1.isSelected.IsChecked;
                listNote.isRastorguev = (bool)selectControl2.isSelected.IsChecked;
                NotesList.notesList.Add(listNote);
            }
            JSONEditor.Serialize(NotesList.notesList);
        }
    }
}
