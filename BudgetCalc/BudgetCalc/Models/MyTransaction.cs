using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetCalc.Models
{
    public class MyTransactionx : RealmObject
    {
        public string Name { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }

        public MyTransactionx()
        {
            Amount = 0;
        }
    }
}
