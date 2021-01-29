using System;
using System.Collections.Generic;
using System.Text;

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

		}

		public void Info()
		{
			string output = $"Account #{number}: {person.Name} {person.Surname}; age: {person.Age}; " +
				$"Balance: ${balance}";
			Console.WriteLine(output);
		}

		public string GetAccountHistory()
		{
			StringBuilder builder = new StringBuilder();

			foreach (var item in allTransactions)
			{
				builder.Append($"#{item.Number}\t\t{item.Date}\t\t{item.Note}");
			}

			return builder.ToString();
		}
	}
}
