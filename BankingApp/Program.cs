using BankingApp.Models;
using System;

namespace BankingApp {
    class Program {
        static void Main(string[] args) {
            BankAccount myAccount = new SavingsAccount("123-123123-12",0.01M);
            Console.WriteLine($"AccountNumber: {myAccount.AccountNumber}");
            Console.WriteLine($"Balance: {myAccount.Balance}");

            myAccount.Deposit(200M);
            (myAccount as SavingsAccount).AddInterest();
            Console.WriteLine($"Balance after depositing 200 euros:{myAccount.Balance}");
            Console.WriteLine($"Number of transactions={myAccount.NumberOfTransactions}");
            myAccount.Withdraw(100M);
            Console.WriteLine($"Balance after withdrawing 100 euros:{myAccount.Balance}");
            Console.WriteLine($"Number of transactions={myAccount.NumberOfTransactions}");
            int aantal = myAccount.GetTransactions(DateTime.Today.AddDays(-2), DateTime.Today).Count;
            Console.WriteLine($"Total transactions: {aantal}");

            Console.WriteLine(myAccount);
            Console.ReadKey();
        }
    }
}
