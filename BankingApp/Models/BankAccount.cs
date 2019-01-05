using System;
using System.Collections.Generic;

namespace BankingApp.Models {
    public class BankAccount {
        #region Fields
        private string _accountNumber;
        private IList<Transaction> _transactions;
        #endregion

        #region Properties
        public string AccountNumber {
            get { return _accountNumber; }
            private set { _accountNumber = value; }
        }
        public int NumberOfTransactions { get {
                return _transactions.Count;
            }
        }
        public decimal Balance { get; set; } = 0M;
        #endregion

        #region Constructors
        public BankAccount(string accountNumber) {
            AccountNumber = accountNumber;
            _transactions = new List<Transaction>();
        }
        #endregion

        #region Methods
        public void Deposit(decimal amount) {
            Balance += amount;
            _transactions.Add(new Transaction(amount, TransactionType.Deposit));
        }

        public virtual void Withdraw(decimal amount) {
            Balance -= amount;
            _transactions.Add(new Transaction(amount, TransactionType.Withdraw));
        } 

        public ICollection<Transaction> GetTransactions(DateTime? from, DateTime? to) {
            IList<Transaction> transList = new List<Transaction>();

            foreach(Transaction t in _transactions) {
                if (t.DateOfTrans.CompareTo(from) >= 0 && t.DateOfTrans.CompareTo(to) <= 1)
                    transList.Add(t);
            }

            return transList;
        }

        public override string ToString() {
            return $"{AccountNumber} - {Balance}";
        }

        public override bool Equals(object obj) {
            BankAccount ba = obj as BankAccount;
            if (ba == null)
                return false;
            return ba.AccountNumber == AccountNumber;
        }

        public override int GetHashCode() {
            return AccountNumber?.GetHashCode() ?? 0;
        }
        #endregion
    }
}
