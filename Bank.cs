using System;
using System.Collections.Generic;
using System.IO;

namespace BankSystem
{
	public class Bank
	{
		public enum Operation
		{
			PutMoney,
			GetMoney,
			Deposite,
			Credit
		}

		static int numberOfAccounts = 0;
		decimal balance;

		List<BankAccount> accounts = new List<BankAccount>();

		public static int NumberOfAccounts { get; }
		public static decimal Balance { get; }
		public string Name { get; set; }

		public string HistoryFileName { get; }

		public Bank(string name, decimal initialBalance)
		{
			Name = name;
			balance = initialBalance;
			HistoryFileName = $@"{Directory.GetCurrentDirectory()}/history/bank_{name}_history.txt";
		}

		public void CreateAccount(string name, string surname)
		{
			accounts.Add(new BankAccount(name, surname, Name));
		}
	}
}
