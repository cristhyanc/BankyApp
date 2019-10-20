using BankyApp.Entities;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BankyApp
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class AccountTransactionsPageModel: FreshBasePageModel
    {
        
        Account account;
        public Account Account
        {
            get { return this.account; }
            set { this.account = value; }
        }

        ObservableCollection<Transaction> transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get { return this.transactions; }
            set { this.transactions = value; }
        }

        decimal totalCredit;
        public decimal TotalCredit
        {
            get { return this.totalCredit; }
            set { this.totalCredit = value; }
        }

        decimal totalDebit;
        public decimal TotalDebit
        {
            get { return this.totalDebit; }
            set { this.totalDebit = value; }
        }

        decimal totalAmount;
        public decimal TotalAmount
        {
            get { return this.totalAmount; }
            set { this.totalAmount = value; }
        }


        public AccountTransactionsPageModel()
        {
            Transactions = new ObservableCollection<Transaction>();
            var trans = new Transaction { Amount = -12, Description = "Gloria Jeans", OccurrenceDate = DateTime.Now.AddDays(-30) };
            Transactions.Add(trans);

            trans = new Transaction { Amount = -200, Description = "Dropbox", OccurrenceDate = DateTime.Now.AddDays(-90) };
            Transactions.Add(trans);

            trans = new Transaction { Amount = -5, Description = "Coffe", OccurrenceDate = DateTime.Now.AddDays(-1) };
            Transactions.Add(trans);

            trans = new Transaction { Amount = 1500, Description = "Salary", OccurrenceDate = DateTime.Now.AddDays(0) };
            Transactions.Add(trans);

            trans = new Transaction { Amount = -350, Description = "Virgin Tickes", OccurrenceDate = DateTime.Now.AddDays(-5) };
            Transactions.Add(trans);

            trans = new Transaction { Amount = decimal.Parse("-0.8"), Description = "International Fee", OccurrenceDate = DateTime.Now.AddDays(-4) };
            Transactions.Add(trans);

            trans = new Transaction { Amount = -24, Description = "Netflix", OccurrenceDate = DateTime.Now.AddDays(30) };
            Transactions.Add(trans);
                     

            TotalDebit = Transactions.Where(x => x.Amount < 0).Sum(x => x.Amount);
            TotalCredit = Transactions.Where(x => x.Amount > 0).Sum(x => x.Amount);
            TotalAmount = TotalCredit + TotalDebit;
        }
    }
}
