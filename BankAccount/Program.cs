using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Account userAccount = new Account();
            userAccount.ChangeAccountState(new ActiveStatë(userAccount));
            userAccount.Balance = 1000;
            userAccount.ActiveBalance = 2000;
            userAccount.ODLimit = 1000;
            userAccount.Deposit(1000);
            userAccount.Withdraw(2000);
            userAccount.Withdraw(500);
            userAccount.Deposit(1000);
            userAccount.Withdraw(1400);
            Console.WriteLine(userAccount.ActiveBalance);
            Console.ReadLine();
        }
    }
    public interface IAccountState
    {
        void Withdraw(int amount);
        void Deposit(int amount);
    }
    public class ActiveStatë : IAccountState
    {
        private readonly Account account;
        public ActiveStatë(Account account)
        {
            this.account = account;
            this.account.IsAtmServiceActive = true;
            this.account.IsOnlineServicesActive = true;
            this.account.IsChequeCollectionActive = true;
        }
        public void Deposit(int amount)
        {
            account.Balance += amount;
            account.ActiveBalance += amount;
        }

        public void Withdraw(int amount)
        {
            if(amount>=account.Balance && amount<= account.ActiveBalance)
            {
                account.Balance = 0;
                account.ActiveBalance -= amount;
                account.ChangeAccountState(new ODStatë(account));
            }
            else if(amount > account.ActiveBalance)
            {
                Console.WriteLine("Limit Exceeds");
            }
            else
            {
                account.Balance -= amount;
                account.ActiveBalance -= amount;
            }

        }
    }
    public class ODStatë : IAccountState
    {
        private readonly Account account;
        private readonly int fineAmount = 100;
        public ODStatë(Account account)
        {
            this.account = account;
            this.account.IsAtmServiceActive = true;
            this.account.IsOnlineServicesActive = true;
            this.account.IsChequeCollectionActive = false;
        }
        public void Deposit(int amount)
        {
            if(amount>account.MinBalance)
            {
                account.ODLimit = account.MinBalance - fineAmount;
                account.ActiveBalance += amount - fineAmount;
                account.Balance = amount - account.ODLimit ;
                account.ChangeAccountState(new ActiveStatë(account));
            }
            else
            {
                account.ActiveBalance += amount;
            }
        }

        public void Withdraw(int amount)
        {
            if (amount < account.ActiveBalance)
            {
                account.ActiveBalance -= amount;
            }
            else if (amount == account.ActiveBalance)
            {
                account.ActiveBalance = 0;
                account.ChangeAccountState(new SuspendedStatë(account));
            }
            else
            {
                Console.WriteLine("Limit Exceeds");
            }
        }
    }
    public class SuspendedStatë : IAccountState
    {
        private readonly Account account;
        private readonly int fineAmount = 1000;
        public SuspendedStatë(Account account)
        {
            this.account = account;
            this.account.IsAtmServiceActive = false;
            this.account.IsOnlineServicesActive = false;
            this.account.IsChequeCollectionActive = false;
        }
        public void Deposit(int amount)
        {
            if (amount > account.MinBalance)
            {
                account.ODLimit = account.MinBalance - fineAmount;
                account.ActiveBalance += amount - fineAmount;
                account.Balance = amount - account.ODLimit;
                account.ChangeAccountState(new ActiveStatë(account));
            }
            else
            {
                account.ODLimit += amount - fineAmount;
                account.ActiveBalance = account.ODLimit;
                account.ChangeAccountState(new ODStatë(account));
            }
        }

        public void Withdraw(int amount)
        {
            Console.WriteLine("Limit Exceeds");
        }
    }
    public class Account
    {
        public int MinBalance { get; set; } = 1000;
        public int ActiveBalance { get; set; }
        public int ODLimit { get; set; }
        public int Balance { get; set; }
        public bool IsAtmServiceActive { get; set; }
        public bool IsOnlineServicesActive { get; set; }
        public bool IsChequeCollectionActive { get; set; }
        IAccountState accountState;
        public void ChangeAccountState(IAccountState accountState)
        {
            this.accountState = accountState;
        }
        public void Deposit(int amount)
        {
            this.accountState.Deposit(amount);
        }
        public void Withdraw(int amount)
        {
            this.accountState.Deposit(amount);
        }
    }
}
