using System.Collections.ObjectModel;

namespace TreeViewTutorial.Models
{
    public class Player : Person
    {
        public ObservableCollection<string> Positions { get; }

        public Player()
        {
            Positions = new ObservableCollection<string>();
        }
    }
}