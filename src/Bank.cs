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

		static int numberOfAccounts;
		decimal balance;

		List<BankAccount> accounts = new List<BankAccount>();

		public static int NumberOfAccounts { get; }
		public static decimal Balance { get; }
		public string Name { get; set; }

		public string HistoryFileName { get; }

		public Bank()
		{
			InitBankFromFile();
		}

		public Bank(string name, decimal initialBalance)
		{
			Name = name;
			balance = initialBalance;
			HistoryFileName = $@"{Directory.GetCurrentDirectory()}/history/bank_{name}_history.txt";
			InitBankFromFile();
		}

		public BankAccount CreateAccount(string name, string surname)
		{
			BankAccount account = new BankAccount(name, surname, Name);
			accounts.Add(account);
			SaveNewAccount(account);

			return account;
		}

		private void InitBankFromFile()
		{
			// check to null strings

			string dir = $@"{Directory.GetCurrentDirectory()}/banks";
			string filePath = dir + @$"/bank_{Name}.txt";
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			if (!File.Exists(filePath))
			{
				File.Create(filePath);

				// initial characteristics(balance/name)

				File.WriteAllText(filePath, "Number of accounts: " + 0 + "\n");
				return;
			}

			// load accounts from file
		}

		private void SaveNewAccount(BankAccount account)
		{
			string filePath = $@"{Directory.GetCurrentDirectory()}/account.txt";

			if (!File.Exists(filePath))
			{
				File.Create(filePath);
				File.WriteAllText(filePath, "Account number:\tPerson:\t\tBalance:\tBank:\n");
			}

			string str = $"{String.Format("{0:000000}",account.Number)}\t" +
				$"{account.Owner.Name} {account.Owner.Surname}\t" +
				$"{String.Format("{0:000000000000}", account.Balance)}\t" +
				$"{Name}\n";

			File.WriteAllText(filePath, str);
		}
	}
}
