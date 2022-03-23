using System;
using System.Collections.ObjectModel;
using lab6.Models;
using ReactiveUI;

namespace lab6.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        public ObservableCollection<Note> AllNotes { get; }
        public ObservableCollection<Note> VisibleNotes { get; }
        DateTimeOffset date;
        public DateTimeOffset Date
        {
            get => date;
            set
            {
                this.RaiseAndSetIfChanged(ref date, value);
                VisibleNotes.Clear();
                foreach(Note note in AllNotes)
                {
                    if(note.Date.Date == value.Date)
                    {
                        VisibleNotes.Add(note);
                    }
                }
            }
        }
        public FirstViewModel()
        {
            AllNotes = new ObservableCollection<Note>();
            VisibleNotes = new ObservableCollection<Note>();
            Date = DateTimeOffset.Now;
        }
        
    }
}
