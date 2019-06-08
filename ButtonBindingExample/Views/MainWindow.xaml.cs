using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SharpDX;

namespace ButtonBindingExample.Views
{
    public class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = "hello";
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}