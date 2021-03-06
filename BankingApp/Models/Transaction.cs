﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Models {
    public class Transaction {
        #region Fields
        private decimal _amount; 
        #endregion

        #region Properties
        public decimal Amount {
            get {
                return _amount;
            }
            private set {
                if (value < 0)
                    throw new ArgumentException("Amount of a transaction can't be less then zero");
                _amount = value;
            }
        }
        public DateTime DateOfTrans { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public bool IsDeposit { get {
                return !IsWithdraw;
            }
        }
        public bool IsWithdraw { get {
                return TransactionType == TransactionType.Withdraw;
            }
        }
        #endregion

        #region Constructors
        public Transaction(decimal amount, TransactionType type) {
            Amount = amount;
            TransactionType = type;
            DateOfTrans = DateTime.Today;
        } 
        #endregion
    }
}
