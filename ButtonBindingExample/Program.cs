﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using ButtonBindingExample.ViewModels;
using ButtonBindingExample.Views;

namespace ButtonBindingExample
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp() 
            => AppBuilder.Configure<App>()
                .UseReactiveUI()
                .UsePlatformDetect();

        // Your application's entry point. Here you can initialize your MVVM framework, DI
        // container, etc.
     }
}
