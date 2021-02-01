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
		decimal balance = 0;

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
			InitBankFromFile();
		}

		// destructor for saving bank info
		~Bank()
		{
			string dir = $@"{Directory.GetCurrentDirectory()}/banks";
			string filePath = dir + @$"/bank_{Name}.txt";

			// write baml characteristics into the file
			string str =
				"Number of accounts: " + 0 + '\n' +
				"Balance: " + Balance + '\n';

			File.WriteAllText(filePath, str);
		}

		// creates bank account
		public BankAccount CreateAccount(string name, string surname)
		{
			BankAccount account = new BankAccount(name, surname, Name);
			accounts.Add(account);
			SaveNewAccount(account);

			return account;
		}

		// load bank info from file
		private void InitBankFromFile()
		{
			// check to null strings
			string dir = $@"{Directory.GetCurrentDirectory()}/banks";
			string filePath = dir + @$"/bank_{Name}.txt";

			// if dir for bank info doesn't exist, create it
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}

			// if file info doesn't exist, create it and save
			if (!File.Exists(filePath))
			{
				File.Create(filePath);

				SaveBankInfo(filePath);
				return;
			}

			// if file does exists(bank already created), load info
			LoadBankInfo(filePath);
		}

		private void SaveNewAccount(BankAccount account)
		{
			string filePath = $@"{Directory.GetCurrentDirectory()}/account.txt";

			// if file does not exist, create it and write tablet columns
			if (!File.Exists(filePath))
			{
				File.Create(filePath);
				File.WriteAllText(filePath, "Account number:\tPerson:\t\tBalance:\tBank:\n");
			}

			// write account info(id/name surname/balance/bank name)
			string str =
				$"{String.Format("{0:000000}",account.Number)}\t" +
				$"{account.Owner.Name} {account.Owner.Surname}\t" +
				$"{String.Format("{0:000000000000}", account.Balance)}\t" +
				$"{Name}\n";

			File.WriteAllText(filePath, str);
		}

		private void LoadBankInfo(string filePath)
		{
			string[] lines = File.ReadAllLines(filePath);

			numberOfAccounts = int.Parse(lines[0]);
			balance = decimal.Parse(lines[1]);
		}

		private void SaveBankInfo(string filePath)
		{
			string[] str = { 
				$"Number of accounts: {numberOfAccounts}",
				$"Balance: {balance}"
			};
			File.WriteAllLines(filePath, str);
		}

		private void SaveBankAccounts()
		{
			string path = $@"";
		}
	}
}
