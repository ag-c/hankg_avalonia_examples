using System;
using System.ComponentModel;
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
        private CompositeDisposable _disposables = new CompositeDisposable();

        private CompositeDisposable _scrollViewerDisposables;

        private double _verticalHeightMax = 0.0;

        public MainWindow()
        {
            InitializeComponent();

            var listBox = this.FindControl<ListBox>("ListOfItems");
            listBox.GetObservable(ListBox.ScrollProperty)
                .OfType<ScrollViewer>()
                .Take(1)
                .Subscribe(sv =>
                {
                    _scrollViewerDisposables?.Dispose();
                    _scrollViewerDisposables = new CompositeDisposable();

                    sv.GetObservable(ScrollViewer.VerticalScrollBarMaximumProperty)
                        .Subscribe(newMax => _verticalHeightMax = newMax)
                        .DisposeWith(_scrollViewerDisposables);


                    sv.GetObservable(ScrollViewer.OffsetProperty)
                        .Subscribe(offset =>
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
                        }).DisposeWith(_disposables);
                }).DisposeWith(_disposables);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _scrollViewerDisposables.Dispose();
            _disposables.Dispose();
        }
    }
}