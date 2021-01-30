using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
	public class Bank
	{
		static int numberOfAccounts = 0;
		static decimal balance;

		List<BankAccount> accounts = new List<BankAccount>();

		public static int NumberOfAccounts { get; }
		public static decimal Balance { get; }
		public string Name { get; set; }

		public Bank(string name, decimal initialBalance)
		{
			Name = name;
			balance = initialBalance;
		}

		public void CreateAccount(string name, string surname, int age)
		{
			accounts.Add(new BankAccount(name, surname, age));
		}

		public static void TakeLoan(decimal amount)
		{
			try
			{
				if (balance < amount)
				{
					throw new ArgumentOutOfRangeException(nameof(amount), "Too much amount to borrow.");
				}
				if (balance <= 0)
				{
					throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive number.");
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}

			balance -= amount;
		}
	}
}
