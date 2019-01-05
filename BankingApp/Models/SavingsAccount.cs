using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Models {
    public class SavingsAccount : BankAccount{
        protected const decimal _withdrawCost=0.25M;

        public decimal InterestRate { get; private set; }

        public SavingsAccount(string bankAccountNumber, decimal interestRate):base(bankAccountNumber) {
            InterestRate = interestRate;
        }

        public void AddInterest() {
            base.Deposit(Balance * InterestRate);
        }

        public override void Withdraw(decimal amount) {
            base.Withdraw(amount + _withdrawCost);
        }
    }
}
