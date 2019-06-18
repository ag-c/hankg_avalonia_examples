using System.Collections.ObjectModel;

namespace TreeViewTutorial.Models
{
    public class Team
    {
        public string TeamName { get; set; }
        
        public ObservableCollection<Person> Roster { get; }

        public Team()
        {
            Roster = new ObservableCollection<Person>();
        }
    }
}