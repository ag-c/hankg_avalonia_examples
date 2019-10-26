using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using DataGridExample.Models;
using ReactiveUI;

namespace DataGridExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Person> People { get; }

        public ReactiveCommand<Unit, Unit> AddNewPerson { get; }

        public MainWindowViewModel()
        {
            People = new ObservableCollection<Person>(GenerateMockPeopleTable());
            AddNewPerson = ReactiveCommand.Create(() =>
            {
                People.Add(
                    new Person()
                    {
                        FirstName = "New First Name", 
                        LastName = "New Last Name"
                    });
            });
        }

        private IEnumerable<Person> GenerateMockPeopleTable()
        {
            var defaultPeople = new List<Person>()
            {
                new Person()
                {
                    FirstName = "Pat", 
                    LastName = "Patterson", 
                    EmployeeNumber = 1010,
                    DepartmentNumber = 100, 
                    DeskLocation = "B3F3R5T7"
                },
                new Person()
                {
                    FirstName = "Jean", 
                    LastName = "Jones", 
                    EmployeeNumber = 973,
                    DepartmentNumber = 200, 
                    DeskLocation = "B1F1R2T3"
                },
                new Person()
                {
                    FirstName = "Terry", 
                    LastName = "Tompson", 
                    EmployeeNumber = 300,
                    DepartmentNumber = 100, 
                    DeskLocation = "B3F2R10T1"
                }
            };

            return defaultPeople;
        }
    }
}
