using System.Reactive;
using ReactiveUI;

namespace AdvancedButtonBinding.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string greeting;
        public string Greeting
        {
            get => greeting;
            set => this.RaiseAndSetIfChanged(ref greeting, value);
        }
        
        private string name;
        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        public MainWindowViewModel()
        {
            var buttonEnabled = this.WhenAnyValue(
                x => x.Name,
                (nameToCheck) => !string.IsNullOrWhiteSpace(nameToCheck) ); 
           
            WriteGreetingReactiveCommand = ReactiveCommand.Create<string>(
                (name) => { WriteGreeting(name); }, 
                buttonEnabled);
        }

        public ReactiveCommand<string,Unit> WriteGreetingReactiveCommand { get; }

        public void WriteGreeting(string personsName)
        {
            Greeting = $"Hello {personsName}!";   
        }
    }
}
