using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MenusExample.ViewModels;

namespace MenusExample.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        public void OnOpenClicked(object sender, EventArgs args)
        {
            var vm = DataContext as MainWindowViewModel;
            if (vm == null)
            {
                return;
            }
            vm.Status = $"Open clicked at {DateTime.Now}";
        }

        public void OnCloseClicked(object sender, EventArgs args)
        {
            Close();
        }

    }
}