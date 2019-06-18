using System.Collections.ObjectModel;

namespace TreeViewTutorial.Models
{
    public class Conference
    {
        public string ConferenceName { get; set; }

        public ObservableCollection<Team> Teams { get; }

        public Conference()
        {
            Teams = new ObservableCollection<Team>();
        }
        
    }
}