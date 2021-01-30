using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BankSystem
{
	public class BankAccount
	{
		decimal balance;
		Person person;
		string number;
		List<Transaction> allTransactions = new List<Transaction>();

		public decimal Balance { get; }
		public decimal Number { get; }
		public Person Owner { get; }

		public BankAccount(string name, string surname, int age)
		{
			person = new Person(name, surname, age);
			number = Convert.ToString(Bank.NumberOfAccounts + 1);
			balance = 0m;
		}

		public void TakeLoan(decimal amount, string note)
		{
			Bank.TakeLoan(amount);
			allTransactions.Add(new Transaction(amount, DateTime.Now, note));

			string dir_name = Directory.GetCurrentDirectory();
			string file_name = $"{person.Name}_{person.Surname}.log";

			using (StreamWriter file =
			new StreamWriter($"{dir_name}\\{file_name}.log", true))
			{
				file.WriteLine();
			}
		}

		public void GetInfo()
		{
			string output = $"Account #{number}: {person.Name} {person.Surname}; age: {person.Age}; " +
				$"Balance: ${balance}";
			Console.WriteLine(output);
		}

		public List<string> GetTransactionHistory()
		{
			List<string> transactions = new List<string>();

			foreach (var item in allTransactions)
			{
				transactions.Add($"#{item.Number}\t\t{item.Date}\t\t{item.Note}");
			}

			return transactions;
		}

		public void SaveHistoryInfoFile()
		{
			string dir_name = Directory.GetCurrentDirectory();
			string file_name = $"{person.Name}_{person.Surname}.log";

			File.WriteAllLines(dir_name + @"/" + file_name,
				GetTransactionHistory().ToArray());
		}
	}
}
