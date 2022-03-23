using System;
using ReactiveUI;
using System.Reactive.Linq;
using lab6.Models;

namespace lab6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        public ViewModelBase Content
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }
        public FirstViewModel Fv { get; }
        public MainWindowViewModel()
        {
            Content = Fv = new FirstViewModel();
        }
        public void AddNote()
        {
            var vm = new SecondViewModel();
            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (Note)null)).Take(1).Subscribe(
                model =>
                {
                    if (model != null)
                    {
                        model.Date = Fv.Date;
                        Fv.AllNotes.Add(model);
                        Fv.VisibleNotes.Add(model);
                    }
                    Content = Fv;
                });
            Content = vm;
        }
        public void EditNote(string title)
        {
            Note note = null;
            foreach(Note n in Fv.VisibleNotes)
            {
                if (n.Title == title)
                {
                    note = n;
                    break;
                }
            }
            var vm = new SecondViewModel();
            vm.Title = note.Title;
            vm.Text = note.Description;
            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (Note)null)).Take(1).Subscribe(
                model =>
                {
                    if (model != null)
                    {
                        note.Title = model.Title;
                        note.Description = model.Description;
                    }
                    Content = Fv;
                });
            Content = vm;
        }
        public void Delete(string title)
        {
            foreach (Note note in Fv.VisibleNotes)
            {
                if (note.Title == title)
                {
                    Fv.VisibleNotes.Remove(note);
                    Fv.AllNotes.Remove(note);
                    break;
                }
            }
        }
    }
}
