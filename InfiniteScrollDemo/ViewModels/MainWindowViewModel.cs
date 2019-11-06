using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using ReactiveUI;

namespace InfiniteScrollDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<string> Items { get; }

        public ReactiveCommand<Unit, Unit> AddItemsCmd { get; }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<string>(GenerateItems(1));
            AddItemsCmd = ReactiveCommand.Create(() => AddItems());
        }

        public void AddItems(int count = 10)
        {
            GenerateItems(count).ForEach(item => Items.Add(item));
            Items.Add("Last Item from this Addition");
        }

        private List<string> GenerateItems(int count)
        {
            var list = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                list.Add($"New String @{++Counter}");
            }

            return list;
        }

        private int Counter { get; set; }
    }
}
