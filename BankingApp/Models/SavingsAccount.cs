using System;


namespace BankingApp.Models {
    public class SavingsAccount : BankAccount{
        #region Fields
        protected const decimal _withdrawCost = 0.25M;
        #endregion

        #region Properties
        public decimal InterestRate { get; private set; }
        #endregion
        
        #region Constructor
        public SavingsAccount(string bankAccountNumber, decimal interestRate) : base(bankAccountNumber) {
            InterestRate = interestRate;
        }
        #endregion

        #region Methods
        public void AddInterest() {
            base.Deposit(Balance * InterestRate);
        }

        public override void Withdraw(decimal amount) {
            if (Balance - (amount + _withdrawCost) < 0)
                throw new InvalidOperationException();

            base.Withdraw(amount);
            base.Withdraw(_withdrawCost);
        } 
        #endregion
    }
}
