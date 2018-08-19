using Prism.Navigation;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;
using BudgetCalc.Models;
using System.Windows.Input;
using Prism.Commands;

namespace BudgetCalc.ViewModels
{
    class AddPageViewModel : ViewModelBase
    {

        private readonly Realm _realm;

        public AddPageViewModel(INavigationService navigationService, Realm realm)
             : base(navigationService)
        {
            Title = "Add Transaction";
            _realm = realm;
            SaveCommand = new DelegateCommand(ExecuteSaveTransaction);
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string transactionType;
        public string TransactionType
        {
            get { return transactionType; }
            set { SetProperty(ref transactionType, value); }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        public ICommand SaveCommand
        {
            get;
            private set;
        }

        void ExecuteSaveTransaction()
        {
            _realm.Write(() =>
            {
                _realm.Add( new MyTransactionx { Name = Name, TransactionType = TransactionType, Amount = Amount});
            });

     
            NavigationService.NavigateAsync("MainPage");
        }
    }
}
