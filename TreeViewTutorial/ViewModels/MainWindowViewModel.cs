using System.Collections.Generic;
using System.Collections.ObjectModel;
using TreeViewTutorial.Models;

namespace TreeViewTutorial.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Conference> League { get; }

        public MainWindowViewModel()
        {
            League = new ObservableCollection<Conference>(FillLeague());
        }

        private List<Conference> FillLeague()
        {
            return new List<Conference>()
            {
                new Conference()
                {
                    ConferenceName = "Eastern",
                    Teams =
                    {
                        new Team()
                        {
                            TeamName = "Eastern Team A"
                        },
                        new Team()
                        {
                            TeamName = "Eastern Team B",
                            Roster =
                            {
                                new Player() { Name = "Player 1", Positions = { "1st Base", "Short Stop"}},
                                new Player() { Name = "Player 2", Positions = { "Left Field", "Center Field"}},
                                new Player() { Name = "Player 3"},
                                new Coach() {Title = "Head Coach", Name = "Coach 1"},
                                new Coach() {Title= "Assistant Coach", Name = "Coach 2"}
                            }
                        },
                        new Team()
                        {
                            TeamName = "Eastern Team C"
                        }
                    }
                },
                new Conference()
                {
                    ConferenceName = "Western",
                    Teams =
                    {
                        new Team()
                        {
                            TeamName = "Western Team A"
                        },
                        new Team()
                        {
                            TeamName = "Western Team B"
                        },
                        new Team()
                        {
                            TeamName = "Western Team C"
                        }
                    }
                }
            };
        }
    }
}
