using BankingApp.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Banking.Tests.Models
{
    public class BankAccountTransactionTest
    {
        private static string _bankAccountNumber = "123-4567890-02";
        private BankAccount _bankAccount;
        private DateTime _yesterday = DateTime.Today.AddDays(-1);
        private DateTime _tomorrow = DateTime.Today.AddDays(1);

        public BankAccountTransactionTest()
        {
            _bankAccount = new BankAccount(_bankAccountNumber);
        }

        [Fact]
        public void NewAccount_HasZeroTransactions()
        {
            Assert.Equal(0, _bankAccount.NumberOfTransactions);
        }

        [Fact]
        public void Deposit_Amount_AddsTransaction()
        {
            _bankAccount.Deposit(100);
            Assert.Equal(1, _bankAccount.NumberOfTransactions);
        }

        [Fact]
        public void WithDraw_Amount_AddsTransaction()
        {
            _bankAccount.Withdraw(100);
            Assert.Equal(1, _bankAccount.NumberOfTransactions);
        }


        [Fact]
        public void GetTransactions_NoParameters_ReturnsAllTransactions()
        {
            _bankAccount.Deposit(100);
            _bankAccount.Deposit(100);
            Assert.Equal(2, _bankAccount.GetTransactions().Count);
        }

        [Fact]
        public void GetTransactions_NoTransactions_ReturnsEmptyList()
        {
            List<Transaction> transLijst =_bankAccount.GetTransactions() as List<Transaction>;
            Assert.Empty(transLijst);
        }

        [Fact]
        public void GetTransactions_WithinAPeriodThatHasTransactions_ReturnsTransactions()
        {
            _bankAccount.Deposit(100);
            _bankAccount.Deposit(100);
            List<Transaction> transLijst = _bankAccount.GetTransactions(DateTime.Now.AddDays(-1),DateTime.Now.AddDays(2)) as List<Transaction>;
            Assert.Equal(2, transLijst.Count);
        }

        [Fact]
        public void GetTransactions_WithinAPeriodThatHasNoTransactions_ReturnsNoTransactions()
        {
            _bankAccount.Deposit(100);
            _bankAccount.Deposit(100);
            List<Transaction> transLijst = _bankAccount.GetTransactions(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)) as List<Transaction>;
            Assert.Empty(transLijst);
        }

        [Fact]
        public void GetTransactions_BeforeADateWithTransactions_ReturnsTransactions()
        {
            _bankAccount.Deposit(100);
            _bankAccount.Deposit(100);
            List<Transaction> transLijst = _bankAccount.GetTransactions(DateTime.Now.AddDays(-1)) as List<Transaction>;
            Assert.Equal(2, transLijst.Count);
        }

        [Fact]
        public void GetTransactions_BeforeADateWithoutTransactions_ReturnsNoTransactions()
        {
            _bankAccount.Deposit(100);
            _bankAccount.Deposit(100);
            List<Transaction> transLijst = _bankAccount.GetTransactions(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1)) as List<Transaction>;
            Assert.Empty(transLijst);
        }

        [Fact]
        public void GetTransactions_AfterADateWithTransactions_ReturnsTransactions()
        {
            _bankAccount.Deposit(100);
            _bankAccount.Deposit(100);
            List<Transaction> transLijst = _bankAccount.GetTransactions(null, DateTime.Now.AddDays(2)) as List<Transaction>;
            Assert.Equal(2, transLijst.Count);
        }

        [Fact]
        public void GetTransactions_AfterADateWithoutTransactions_ReturnsNoTransactions()
        {
            _bankAccount.Deposit(100);
            _bankAccount.Deposit(100);
            List<Transaction> transLijst = _bankAccount.GetTransactions(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)) as List<Transaction>;
            Assert.Empty(transLijst);
        }


    }
}