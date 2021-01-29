﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
	public class Bank
	{
		static int numberOfAccounts = 0;
		decimal balance;

		List<BankAccount> accounts = new List<BankAccount>();

		public static int NumberOfAccounts { get; }
		public static decimal Balance { get; }

		public Bank(decimal initialBalance)
		{
			balance = initialBalance;
		}

		public void CreateAccount(string name, string surname, int age)
		{
			accounts.Add(new BankAccount(name, surname, age));
		}

		public void TakeLoan(decimal amount)
		{
			if(balance < amount)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Too much amount to borrow.");
			}
			if(balance <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive number.");
			}
		
			balance -= amount;
		}
	}
}