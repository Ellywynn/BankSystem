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

		private static int numberOfAccounts = 0;
		private decimal balance = 0;

		private string bankInfoFilePath;
		private string bankAccountsFilePath;

		List<BankAccount> accounts = new List<BankAccount>();

		public static int NumberOfAccounts { get; }
		public static decimal Balance { get; }
		public string Name { get; set; }

		public string HistoryFileName { get; }
		
		public Bank(string name, decimal initialBalance)
		{
			Name = name;
			balance = initialBalance;
			string dir = Directory.GetCurrentDirectory();

			HistoryFileName = $@"{dir}/history/banks/{name}_history.txt";
			bankInfoFilePath = $@"{dir}/banks/{Name}/bank_{Name}.txt";
			bankAccountsFilePath = $@"{dir}/banks/{Name}accounts.txt";

			InitBank();
			LoadBankAccounts();
		}

		// destructor for saving bank info
		~Bank()
		{ 
			// write baml characteristics into the file
			string str =
				"Number of accounts: " + 0 + '\n' +
				"Balance: " + Balance + '\n';

			File.WriteAllText(bankInfoFilePath, str);
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
		private void InitBank()
		{
			// check to null strings
			string dir = $@"{Directory.GetCurrentDirectory()}/banks/{Name}";

			// if dir for bank info doesn't exist, create it
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}

			// if file info doesn't exist, create it and save
			if (!File.Exists(bankInfoFilePath))
			{
				File.Create(bankInfoFilePath);

				SaveBankInfo();
				return;
			}

			// if file does exists(bank already created), load info
			LoadBankInfo();
		}

		private void SaveNewAccount(BankAccount account)
		{
			// if file does not exist, create it and write tablet columns
			if (!File.Exists(bankAccountsFilePath))
			{
				File.Create(bankAccountsFilePath);
				File.WriteAllText(bankAccountsFilePath, "Account number:\tPerson:\t\tBalance:\tBank:\n");
			}

			// write account info(id/name surname/balance/bank name)
			string str =
				$"{String.Format("{0:000000}",account.Number)}\t" +
				$"{account.Owner.Name} {account.Owner.Surname}\t" +
				$"{String.Format("{0:000000000000}", account.Balance)}\t" +
				$"{Name}\n";

			File.WriteAllText(bankAccountsFilePath, str);
		}

		private void LoadBankInfo()
		{
			string[] lines = File.ReadAllLines(bankInfoFilePath);

			if (lines.Length > 0)
			{
				numberOfAccounts = int.Parse(lines[0]);
				balance = decimal.Parse(lines[1]);
			}
			else
			{
				Console.WriteLine($"File {bankInfoFilePath} is empty.");
			}
		}

		private void SaveBankInfo()
		{
			string[] str = { 
				$"Number of accounts: {numberOfAccounts}",
				$"Balance: {balance}"
			};
			File.WriteAllLines(bankInfoFilePath, str);
		}

		private void SaveBankAccounts()
		{
			
		}

		private void LoadBankAccounts()
		{
			string[] lines = File.ReadAllLines(bankAccountsFilePath);

			for(int i = 1; i < lines.Length; i++)
			{
				string[] str = lines[i].Split(' ', 5);

				string num = str[0];
				string name = str[1];
				string surname = str[2];
				decimal bal = decimal.Parse(str[3]);
				string bankname = str[4];

				Console.WriteLine($"STR = {str}");

				//accounts.Add(lines[i]);
			}
		}
	}
}
