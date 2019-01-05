using System;

namespace BankingApp.Models {
    public class BankAccount {
        #region Fields
        private string _accountNumber; 
        #endregion

        #region Properties
        public string AccountNumber {
            get { return _accountNumber; }
            private set { _accountNumber = value; }
        }

        public decimal Balance { get; set; } = 0M;
        #endregion

        #region Constructors
        public BankAccount(string accountNumber) {
            AccountNumber = accountNumber;
        }
        #endregion

        #region Methods
        public void Deposit(decimal amount) {
            Balance += amount;
        }

        public void Withdraw(decimal amount) {
            Balance -= amount;
        } 
        #endregion
    }
}
