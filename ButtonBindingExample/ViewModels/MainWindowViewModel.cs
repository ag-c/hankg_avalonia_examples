using System;
using ReactiveUI;
using System.Collections.Generic;
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

        public void UpdateTextStatus(string nameOfUpdater)
        {
            ClickStatusUpdate = $"{nameOfUpdater} ${DateTime.Now}";
        }
    }
}
