using System;


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
            if (Balance - (amount + _withdrawCost) < 0)
                throw new InvalidOperationException();

            base.Withdraw(amount);
            base.Withdraw(_withdrawCost);
        }
    }
}
