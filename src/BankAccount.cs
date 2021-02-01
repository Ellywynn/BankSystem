using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

// действия аккаунта:
// положить деньги, вывести(взять) деньги, взять кредит, выплатить кредит  

namespace BankSystem
{
	public class BankAccount
	{
		decimal balance;
		decimal deposite;
		Person person;
		string number;
		string bankName;
		string historyFilePath;

		public decimal Balance { get; }
		public decimal Number { get; }
		public Person Owner { get; }

		public BankAccount(string name, string surname, string bankName)
		{
			person = new Person(name, surname);
			number = Convert.ToString(Bank.NumberOfAccounts + 1);
			this.bankName = bankName;
			historyFilePath = $@"{Directory.GetCurrentDirectory()}/history/{bankName}_{name}_{surname}.txt";
			balance = 0m;
			deposite = 0m;


		}

		public string GetInfo()
		{
			string info = $"Account #{number}: {person.Name} {person.Surname}; " +
				$"Balance: ${balance}; Bank: {bankName}";
			return info;
		}

		public void PutMoney(decimal amount, string note = "")
		{
			try
			{
				if (amount <= 0)
				{
					throw new ArgumentOutOfRangeException(nameof(amount), "Amount of money to put must be positive.");
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}

			balance += amount;
			SaveAccountTransaction(new Transaction(amount, DateTime.Now, Bank.Operation.PutMoney, note));
		}

		public void Deposite(decimal amount)
		{
			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of money to deposite must be positive.");
			}
		}

		private void SaveAccountTransaction(Transaction transaction)
		{
			string fileDir = $@"{Directory.GetCurrentDirectory()}/history";

			if (!Directory.Exists(fileDir))
			{
				Directory.CreateDirectory(fileDir);
			}
			if(!File.Exists(historyFilePath))
			{
				File.WriteAllText(historyFilePath, "ID:\t\tDate:\t\t\tOperation type:\t\tAmount:\t\tNote:\n\n");
			}

			File.AppendAllText(historyFilePath, transaction.InfoTable());
		}

		private void SaveBankTransaction(Transaction transaction)
		{

		}
	}
}
