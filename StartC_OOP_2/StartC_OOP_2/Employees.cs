using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartC_OOP_2
{
    internal class Employees : INotifyPropertyChanged
    {
        private string _Name;
        private string _Surname;
        private string _Patronymic;
        private string _numberPassport;
        private string _numberPhone;
        public string numberPassportHidden { get; } = "**********";
        private string _change;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(" Фамилия");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }

        public string Surname
        {
            get { return _Surname; }
            set
            {
                _Surname = value;
                OnPropertyChanged(" Имя");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Surname)));
            }
        }
        public string Patronymic
        {
            get { return _Patronymic; }
            set
            {
                _Patronymic = value;
                OnPropertyChanged(" Отчество");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Patronymic)));
            }
        }
        public string numberPhone
        {
            get { return _numberPhone; }
            set
            {
                _numberPhone = value;
                OnPropertyChanged(" Номер телефона");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.numberPhone)));
            }
        }
        public string numberPassport
        {
            get { return _numberPassport; }
            set
            {
                _numberPassport = value;
                OnPropertyChanged(" Номер паспорта");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.numberPassport)));
            }
        }

        public string change
        {
            get { return _change; }
            set
            {
                _change = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.change)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                change = String.Empty;
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
                change += prop;
            }
        }


    }

    internal class Departament
    {
        public string Name { get; set; }
        public ICollection<Employees> Employees { get; set; }
        public string Description { get; set; }
    }
}