using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
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
                x => this.Greeting,
                x => (nameToCheck, greetingToCheck) => !string.IsNullOrWhiteSpace(nameToCheck) && string.IsNullOrWhiteSpace(greetingToCheck)); 
            WriteGreetingReactiveCommand = ReactiveCommand.Create<string>(
                name => { WriteGreeting(name); }, 
                buttonEnabled);
        }

        public ReactiveCommand WriteGreetingReactiveCommand { get; }

        public void WriteGreeting(string personsName)
        {
            Greeting = $"Hello {personsName}!";   
        }
    }
}
