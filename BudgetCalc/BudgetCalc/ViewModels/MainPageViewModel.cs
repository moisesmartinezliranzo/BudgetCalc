using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BudgetCalc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Realms;

namespace BudgetCalc.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly Realm _realm;
        public MainPageViewModel(INavigationService navigationService, Realm realm) 
            : base (navigationService)
        {
            Title = "Budget Calc";
            _realm = realm;
            AddCommand = new DelegateCommand(ExecuteAddView);
            Transaction = new ObservableCollection<MyTransactionx>();
            LoadMyTransactionFromLocalDB();

            Balance = Income - Spending;
        }

        private int balance;
        public int Balance
        {
            get { return balance; }
            set { SetProperty(ref balance, value); }
        }

        private int income;
        public int Income
        {
            get { return income; }
            set { SetProperty(ref income, value); }
        }

        private int spending;
        public int Spending
        {
            get { return spending; }
            set { SetProperty(ref spending, value); }
        }

        public ICommand AddCommand
        {
            get;
            private set;
        }

        private void ExecuteAddView()
        {
            NavigationService.NavigateAsync("AddPage");
        }

        private void LoadMyTransactionFromLocalDB()
        {
            var allMytransactions = _realm.All<MyTransactionx>();
            var totalSpending = _realm.All<MyTransactionx>().Where(ttype => ttype.TransactionType  == "Spending");
            var totalIncome = _realm.All<MyTransactionx>().Where(ttype => ttype.TransactionType == "Income");
            
            foreach (var item in allMytransactions)
            {
                Transaction.Add(item);
                //Spending += item.Amount;
            }

            foreach(var item in totalSpending)
            {
                Spending += item.Amount;
            }

            foreach (var item in totalIncome)
            {
                Income += item.Amount;
            }
        }


        private ObservableCollection<MyTransactionx> transaction;
        public ObservableCollection<MyTransactionx> Transaction
        {
            get { return transaction; }
            set { SetProperty(ref transaction, value); }
        }

    }
}
