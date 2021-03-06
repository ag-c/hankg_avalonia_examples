using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ButtonBindingExample.ViewModels;
using SharpDX;

namespace ButtonBindingExample.Views
{
    public class MainWindow : Window
    {
        private MainWindowViewModel SpecificViewModel => DataContext as MainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
            var clickCodeButton = this.Find<Button>("ClickCodeButton");
            clickCodeButton.Click += delegate
            {
                //SpecificViewModel.UpdateTextStatus("On Click Code Button");
                SpecificViewModel.SelectFolderAsync();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            //SpecificViewModel.UpdateTextStatus("On Click XAML Button");
            SpecificViewModel.SelectFolderAsync();
        }

        private void OnPointerEnter(object sender, PointerEventArgs e)
        {
            SpecificViewModel.UpdateTextStatus("On Pointer Entered Button");
        }
    }
}