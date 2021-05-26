using ExpenseList.Commands;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExpenseList
{
    class MainViewModel : INotifyPropertyChanged
    {
        AddExpenseViewModel childViewModel;
        AddExpenseWindow aew;

        ObservableCollection<Expense> expenses = new ObservableCollection<Expense>();
        ObservableCollection<Expense> top5Expenses = new ObservableCollection<Expense>();
        public IEnumerable<Expense> Expenses => top5Expenses;

        private Expense selectedExpense;

        void GetTop5Expenses()
        {
            top5Expenses.Clear();
            foreach (var item in expenses.OrderByDescending(e => e.Price).Take(5))
            {
                top5Expenses.Add(item);
            }
        }

        public void AddExpense(Expense exp)
        {
            expenses.Add(exp);
        }

        public Expense SelectedExpense
        {
            get
            {
                return selectedExpense;
            }
            set
            {
                selectedExpense = value;
                OnPropertyChanged();
            }
        }
        
        private void AddExpense()
        {
            aew = new AddExpenseWindow();
            childViewModel = new AddExpenseViewModel(aew);

            aew.DataContext = childViewModel;

            aew.ShowDialog();
            if (aew.DialogResult == true)
            {
                expenses.Add(childViewModel.Expense);
                GetTop5Expenses();
            }
        }

        private ICommand addExpenseCommand;

        public ICommand AddExpenseCommand
        {
            get
            {
                if (addExpenseCommand == null)
                {
                    addExpenseCommand = new DelegateCommand(AddExpense);
                }

                return addExpenseCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
