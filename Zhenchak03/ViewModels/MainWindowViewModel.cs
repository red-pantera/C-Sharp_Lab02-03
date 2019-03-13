using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zhenchak03.Models;


namespace Zhenchak03.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        #region binding properties
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public ICommand PersonDataSubmitCommand { get; }
        #endregion

        readonly Grid _personInfoGrid;

        internal MainWindowViewModel(Grid personInfoGrid)
        {
            _personInfoGrid = personInfoGrid ?? throw new ArgumentNullException(nameof(personInfoGrid));
            PersonDataSubmitCommand = new DelegateCommandAsync(CreateAndShowPersonFromInputedData, _ =>
                _personInfoGrid.Visibility != Visibility.Visible && AllFieldsHaveBeenSet());
        }

        #region command delegates

        bool AllFieldsHaveBeenSet()
        {
            return !(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname) ||
                string.IsNullOrEmpty(Email)); // date time always has default value 
        }

        async Task CreateAndShowPersonFromInputedData(object o)
        {

            Console.WriteLine(DateOfBirth);
            if (BirthDataUtils.IsValidBirthDate(DateOfBirth) == false)
            {
                MessageBox.Show("Invalid date", "error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
            if (BirthDataUtils.IsBirthday(DateOfBirth))
            {
                MessageBox.Show("Happy Birth Day To You!", "Don't worry be happy)",
                    MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

            if (!EmailValidator.IsValidFormat(Email))
            {
                MessageBox.Show("Email is incorrect", "error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }


            var person = new Person(Name, Surname, Email, DateOfBirth);
            var personInfoVM = new PersonInfoViewModel(person);
            _personInfoGrid.DataContext = personInfoVM;

            _personInfoGrid.Visibility = Visibility.Visible;

        }
        #endregion

    }
}

