using System;
using ReactiveUI;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace ButtonBindingExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string clickStatusUpdate;
        public string ClickStatusUpdate
        {
            get => clickStatusUpdate;
            set => this.RaiseAndSetIfChanged(ref clickStatusUpdate, value);
        }

        public MainWindowViewModel()
        {
            UpdateTextFromReactiveCommand = ReactiveCommand.Create(
                () => { UpdateTextStatus("Reactive Command Button"); });
        }

        public void UpdateFromSimpleMethod()
        {
            UpdateTextStatus("Simple Method Button");
        }

        public void UpdateTextStatus(string nameOfUpdater)
        {
            ClickStatusUpdate = $"{nameOfUpdater} updated me at {DateTime.Now}";
        }
        
        public ReactiveCommand<Unit, Unit> UpdateTextFromReactiveCommand { get; }
        
    }
}
