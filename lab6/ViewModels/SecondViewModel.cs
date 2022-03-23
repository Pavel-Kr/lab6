using ReactiveUI;
using System.Reactive;
using lab6.Models;

namespace lab6.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Note> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
        string title;
        string text;
        public string Title
        {
            get => title;
            set => this.RaiseAndSetIfChanged(ref title, value);
        }
        public string Text
        {
            get => text;
            set => this.RaiseAndSetIfChanged(ref text, value);
        }
        public SecondViewModel()
        {
            var okEnabled = this.WhenAnyValue(
                x => x.Title,
                x => !string.IsNullOrWhiteSpace(x)
                );
            Ok = ReactiveCommand.Create(() => new Note { Title = Title, Description = Text }, okEnabled);
            Cancel = ReactiveCommand.Create(() => { });
        }
    }
}
