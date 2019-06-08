using System;
using ReactiveUI;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Text;
using Avalonia;
using Avalonia.Controls;

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
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            };

            var result = await dialog.ShowAsync(Application.Current.MainWindow);
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
