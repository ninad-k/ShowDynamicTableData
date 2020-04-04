using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ShowDynamicData.Models;
using Xamarin.Forms;

namespace ShowDynamicData.ViewModels
{
    public class EmployeeDetailsViewModel : BindableObject
    {
        private List<Employee> employees;
        public ObservableCollection<Group> Groups { get; private set; }

        public EmployeeDetailsViewModel()
        {
            this.SetUpContacts();
            this.SetEmployee(0);
        }

        private void SetUpContacts()
        {
            this.employees = new List<Employee>
            {
                new Employee
                {
                    FirstName = "Ninad",
                    LastName = "Kulkarni",
                    Company = "Google",
                    Height = 183,
                    Notes = "First contact note\nSecond line",
                    YearOfBirth = 1988
                },
                new Employee
                {
                    FirstName = "Rohan",
                    LastName = "Bomle",
                },
                new Employee
                {
                    FirstName = "Srijesh",
                    LastName = "Pathak",
                    Company = "Google",
                    Height = 183,
                    YearOfBirth = 1987
                },
                new Employee
                {
                    Company = "Google"
                }
            };
        }

        private void SetEmployee(int index)
        {
            var employee = this.employees[index];

            var basicGroup = new Group { Header = "Basic Information" };
            var personalGroup = new Group { Header = "Personal Details" };
            var notesGroup = new Group { Header = "Notes" };
            var buttonGroup = new Group { Header = "Actions" };

            // basic information
            this.AddTextRowIfNotEmpty(basicGroup.Rows, "First Name", employee.FirstName);
            this.AddTextRowIfNotEmpty(basicGroup.Rows, "Last Name", employee.LastName);
            this.AddTextRowIfNotEmpty(basicGroup.Rows, "Company", employee.Company);

            // personal details
            this.AddTextRowIfNotEmpty(personalGroup.Rows, "Year of Birth", employee.YearOfBirth?.ToString());
            this.AddTextRowIfNotEmpty(personalGroup.Rows, "Height", employee.Height?.ToString());

            // notes
            if (!string.IsNullOrEmpty(employee.Notes))
            {
                personalGroup.Rows.Add(new EditorRow { Text = employee.Notes });
            }

            // actions
            buttonGroup.Rows.Add(new ButtonRow 
            { 
                Title = "Next Contact",
                OnClickAction = () => this.SetEmployee((index + 1) % this.employees.Count)
            });

            var groups = new List<Group>
            {
                basicGroup,
                personalGroup,
                notesGroup,
                buttonGroup
            };

            var nonEmptyGroups = groups.Where(x => x.Rows.Any());
            this.Groups = new ObservableCollection<Group>(nonEmptyGroups);

            // notify view, that sections have been changed
            this.OnPropertyChanged(nameof(this.Groups));
        }

        private void AddTextRowIfNotEmpty(IList<IGroupRow> rows, string title, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                rows.Add(new TextValueRow { Title = title, Value = text });
            }
        }
    }
}
