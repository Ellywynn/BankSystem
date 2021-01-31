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
			historyFilePath = $@"{Directory.GetCurrentDirectory()}/history/{bankName}_{number}_history.txt";
			balance = 0m;
			deposite = 0m;
		}

		public string GetInfo()
		{
			string info = $"Account #{number}: {person.Name} {person.Surname}; " +
				$"Balance: ${balance}; Bank: {bankName}";
			return info;
		}

		public void PutMoney(decimal amount, string note)
		{
			if(amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of money to put must be positive.");
			}

			Console.WriteLine("HELLO!");
			balance += amount;
			Transaction tr = new Transaction(amount, DateTime.Now, Bank.Operation.PutMoney, note);

			using StreamWriter sw = new StreamWriter(historyFilePath, true);
				sw.WriteLine(tr.Info());
		}

		public void Deposite(decimal amount)
		{
			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of money to deposite must be positive.");
			}
		}

		private void SaveAccountTransaction(Transaction transaction, Bank.Operation operation)
		{

		}

		private void SaveBankTransaction(Transaction transaction, Bank.Operation operation)
		{

		}
	}
}
