using BankingApp.Models;
using System;

namespace BankingApp {
    class Program {
        static void Main(string[] args) {
            BankAccount myAccount = new BankAccount("123-123123-12");
            Console.WriteLine($"AccountNumber: {myAccount.AccountNumber}");
            Console.WriteLine($"Balance: {myAccount.Balance}");

            myAccount.Deposit(200M);
            Console.WriteLine($"Balance after depositing 200 euros:{myAccount.Balance}");
            myAccount.Withdraw(100M);
            Console.WriteLine($"Balance after withdrawing 100 euros:{myAccount.Balance}");
            Console.ReadKey();
        }
    }
}
