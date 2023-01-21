using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StartC_OOP_2.ViewModels.Base;
using System.Windows;
using StartC_OOP_2.Infrastructure.Commands;
using System.Windows.Controls;

namespace StartC_OOP_2.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public ObservableCollection<Departament> Departaments { get; }
       
        private Departament _SelectedDep;
        public Departament SelectedDep 
        {
            get => _SelectedDep; 
            set => Set(ref _SelectedDep, value); 
        }

        public ICommand CreateDepCommand { get; }
        private bool CanCreateDepCommandExecute(object p) => true;
        private void OnCreateDepCommandExecute(object p)
        {
            var dep_max_index = Departaments.Count + 1;
            var new_dep = new Departament
            {
                Name = $"Департамент {dep_max_index}",
                Employees = new ObservableCollection<Employees>()
            };
            Departaments.Add(new_dep);
        }
        
        public ICommand DeleteDepCommand { get; }
        private bool CanDeleteDepCommandExecute(object p) => p is Departament dep && Departaments.Contains(dep);
        private void OnDeleteDepCommandExecute(object p)
        {
            if (!(p is Departament dep)) return;
            var dep_index = Departaments.IndexOf(dep);
            Departaments.Remove(dep);
            if (dep_index < Departaments.Count)
            {
                SelectedDep = Departaments[dep_index];
            }        
        }
        
        public MainWindowViewModel() 
        {
            CreateDepCommand = new LambdaCommand(OnCreateDepCommandExecute, CanCreateDepCommandExecute);
            DeleteDepCommand = new LambdaCommand(OnDeleteDepCommandExecute, CanDeleteDepCommandExecute);
            
            var employees = Enumerable.Range(1, 10).Select(i => new Employees
            {
                Name = Faker.Name.First(),
                Surname = Faker.Name.Middle(),
                Patronymic = Faker.Name.Last(),
                numberPassport = Faker.RandomNumber.Next().ToString(),
                numberPhone = Faker.Phone.Number()
            }); 
            
            var deps = Enumerable.Range(1, 20).Select(i => new Departament
            {
                Name = $"Департамент {i}",
                Employees = new ObservableCollection<Employees>(employees)
            });
            Departaments = new ObservableCollection<Departament>(deps);
        }
    }
}