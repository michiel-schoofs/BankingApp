using System;
using System.Collections.Generic;

namespace BankingApp.Models {
    public interface IBankAccount {
        #region Properties
        string AccountNumber { get; }
        decimal Balance { get; set; }
        int NumberOfTransactions { get; }
        #endregion

        #region Methods
        void Deposit(decimal amount);
        ICollection<Transaction> GetTransactions(DateTime? from, DateTime? to);
        void Withdraw(decimal amount); 
        #endregion
    }
}