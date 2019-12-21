using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;

namespace MenusExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _status;

        public string Status
        {
            get => _status;
            set => this.RaiseAndSetIfChanged(ref _status, value);
        }
        
        public void OnOpenClicked()
        {
            Status = $"Open clicked at {DateTime.Now}";
        }
        
        public MainWindowViewModel()
        {
            Status = $"Application started at {DateTime.Now}";
        }
    }
    
}
