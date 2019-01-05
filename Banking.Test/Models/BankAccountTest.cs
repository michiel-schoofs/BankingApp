using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Banking.Tests.Models {
    public class BankAccountTest {
        private string _accountNumber;
        private BankAccount _bankAccount;

        public BankAccountTest() {
            _accountNumber = "123-4567890-02";
            _bankAccount = new BankAccount(_accountNumber);
        }

        [Fact]
        public void NewAccount_BalanceZero() {
            Assert.Equal(0M, _bankAccount.Balance);
        }

        [Fact]
        public void NewAccount_AccountNumberSet() {
            Assert.Equal(_bankAccount.AccountNumber, _accountNumber);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("133-4567890-0333")]
        [InlineData("063-1547563@60")]
        [InlineData("133-4567890-03")]
        public void NewAccount_EmptyString_Fails(string accountNumber) {
            Assert.Throws<ArgumentException>(() => new BankAccount(accountNumber));
        }

        [Fact]
        public void Withdraw_Amount_ChangesBalance() {
            _bankAccount.Deposit(200);
            _bankAccount.Withdraw(100);
            Assert.Equal(100M, _bankAccount.Balance);
        }

        [Fact]
        public void Deposit_Amount_ChangesBalance() {
            _bankAccount.Deposit(100);
            Assert.Equal(100M, _bankAccount.Balance);
        }

        [Fact]
        public void Withdraw_NegativeBalance_Allowed() {
            _bankAccount.Withdraw(100);
            Assert.Equal(-100M, _bankAccount.Balance);
        }

        [Fact]
        public void Withdraw_NegativeAmount_Fails() {
            Assert.Throws<ArgumentException>(() => _bankAccount.Withdraw(-100));
        }

        [Fact]
        public void Deposit_NegativeAmount_Fails() {
            Assert.Throws<ArgumentException>(() => _bankAccount.Deposit(-100));
        }
    }
}
