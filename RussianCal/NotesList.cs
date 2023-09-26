using RussianCal.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianCal
{
    internal class NotesList
    {
        public static List<Note> notesList = new List<Note>();

        public static int FindNote(DateTime date)
        {
            foreach (var note in notesList)
            {
                if (note.date == date)
                {
                    return notesList.IndexOf(note);
                }
            }
            return -1;
        }

        public static void ReadNotes()
        {
            notesList = JSONEditor.Deserialize<List<Note>>("../../Notes.json");
        }

    }
}
