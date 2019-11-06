using System;
using System.Net;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DynamicData.Binding;
using InfiniteScrollDemo.ViewModels;
using JetBrains.Annotations;
using ReactiveUI;
using SharpDX.DirectWrite;

namespace InfiniteScrollDemo.Views
{
    public class MainWindow : Window
    {

        private double _verticalHeightMax = 0.0;

        public MainWindow()
        {
            InitializeComponent();

            var listBox = this.FindControl<ListBox>("ListOfItems");
            listBox.WhenAnyValue(lb => lb.Scroll.Offset)
                .ForEachAsync(offset =>
                {
                    if (offset.Y <= Double.Epsilon)
                    {
                        Console.WriteLine("At Top");
                    }

                    var delta = Math.Abs(_verticalHeightMax - offset.Y);
                    if (delta <= Double.Epsilon)
                    {
                        Console.WriteLine("At Bottom");
                        var vm = DataContext as MainWindowViewModel;
                        vm?.AddItems();
                    }
                });
            
            listBox.PropertyChanged += (sender, args) =>
            {
                if (args.Property != ListBox.ScrollProperty)
                {
                    return;
                }

                var scroll = listBox.Scroll as ScrollViewer;
                scroll.PropertyChanged += (o, eventArgs) =>
                {
                    if (eventArgs.Property == ScrollViewer.VerticalScrollBarMaximumProperty)
                    {
                        if (eventArgs.NewValue is double value)
                        {
                            this._verticalHeightMax = value;
                        }
                    }
                };
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
    }
}