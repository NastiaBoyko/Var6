using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ExpenseList.Commands;

namespace ExpenseList
{
    class AddExpenseViewModel : INotifyPropertyChanged
    {
        public AddExpenseViewModel(AddExpenseWindow w)
        {
            window = w;
        }
        private AddExpenseWindow window;
        private Expense expense = new Expense("", DateTime.Now, "", "", 0);

        public Expense Expense
        {
            get { return expense; }
            set 
            {
                expense = value;
                OnPropertyChanged();
            }
        }

        public bool? DialogResult { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ICommand addNewExpenseCommand;

        public ICommand AddNewExpenseCommand
        {
            get
            {
                if (addNewExpenseCommand == null)
                {
                    addNewExpenseCommand = new DelegateCommand(AddNewExpense);
                }

                return addNewExpenseCommand;
            }
        }
        private bool Check()
        {
            if(string.IsNullOrWhiteSpace(Expense.PurchaseName))
            {
                MessageBox.Show("Введіть назву покупки!");
                return false;
            }
            if (Expense.Price < 0)
            {
                MessageBox.Show("Ціна покупки не може бути від'ємною!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(Expense.ShopName))
            {
                MessageBox.Show("Введіть місце витрати!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(Expense.TicketNumber))
            {
                MessageBox.Show("Введіть номер чека!");
                return false;
            }
            if(!int.TryParse(Seconds, out int seconds) || !int.TryParse(Minutes, out int minutes) || !int.TryParse(Hours, out int hours))
            {
                MessageBox.Show("Некоректний формат часу!");
                return false;
            }
            if (seconds < 0 || seconds > 60 || minutes < 0 || minutes > 60 || hours < 0 || hours > 24) 
            {
                MessageBox.Show("Некоректний формат часу!");
                return false;
            }
            int day = Expense.PurchaseTime.Day;
            int month = Expense.PurchaseTime.Month;
            int year = Expense.PurchaseTime.Year;
            Expense.PurchaseTime = new DateTime(year, month, day, hours, minutes, seconds);


            return true;
        }

        private void AddNewExpense()
        {
            if (!Check())
                return;
            window.DialogResult = true;
            window.Close();
        }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private string hours = "0";

        public string Hours { get => hours; set => SetProperty(ref hours, value); }

        private string minutes = "0";

        public string Minutes { get => minutes; set => SetProperty(ref minutes, value); }

        private string seconds = "0";

        public string Seconds { get => seconds; set => SetProperty(ref seconds, value); }
    }
}
