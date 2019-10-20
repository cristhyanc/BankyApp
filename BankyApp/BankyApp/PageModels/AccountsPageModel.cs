using BankyApp.Entities;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankyApp
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class AccountsPageModel: FreshBasePageModel
    {
        ObservableCollection<Account> accounts;
        public ObservableCollection<Account> Accounts {
            get { return this.accounts; }
            set { this.accounts = value; }
        }
        
        Account accountSelected;
        public Account AccountSelected
        {
            get { return this.accountSelected; }
            set
            {
                if(value!=this.accountSelected && value!= null)
                {
                    this.accountSelected = value;
                    NavigateToTransactions();
                }               
            }
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



        public AccountsPageModel()
        {
            try
            {
                Accounts = new ObservableCollection<Account>();
                var account = new Account { AccountName = "Account 1", TotalAmount = 2000, AccountNumber = "44-158-6457" };
                Accounts.Add(account);

                account = new Account { AccountName = "Account 2", TotalAmount = 20, AccountNumber = "15-363-8494" };
                Accounts.Add(account);

                account = new Account { AccountName = "Account 3", TotalAmount = -100, AccountNumber = "15-580-8290" };
                Accounts.Add(account);

                account = new Account { AccountName = "Account 4", TotalAmount = -456, AccountNumber = "44-160-6243" };
                Accounts.Add(account);

                account = new Account { AccountName = "Account 5", TotalAmount = 3, AccountNumber = "15-363-8494" };
                Accounts.Add(account);


                TotalDebit = Accounts.Where(x => x.TotalAmount < 0).Sum(x => x.TotalAmount);
                TotalCredit = Accounts.Where(x => x.TotalAmount > 0).Sum(x => x.TotalAmount);
                TotalAmount = TotalCredit + TotalDebit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private async Task NavigateToTransactions()
        {
            try
            {
                await CoreMethods.PushPageModel<AccountTransactionsPageModel>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
