using System;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;

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
            UpdateTextFromReactiveCommand = ReactiveCommand.Create(SelectFolderAsync);
        }

        public void UpdateFromSimpleMethod()
        {
            //UpdateTextStatus("Simple Method Button");
            SelectFolderAsync();
        }

        public void UpdateTextStatus(string nameOfUpdater)
        {
            ClickStatusUpdate = $"{nameOfUpdater} updated me at {DateTime.Now}";
        }
        
        public ReactiveCommand<Unit, Unit> UpdateTextFromReactiveCommand { get; }
        
        public async void SelectFolderAsync()
        {
            var dialog = new OpenFolderDialog()
            {
                Title = "Select Folder...",
                Directory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            };

            var desktop = Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
            var result = await dialog.ShowAsync(desktop.MainWindow);
            if (result == null)
            {
                ClickStatusUpdate = "User canceled request";
            }
            else
            {
                ClickStatusUpdate = $"User Selected: {result}";
            }
        }
    }
}
