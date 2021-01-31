using System;
using System.IO;

namespace BankSystem
{
	public class Transaction
	{
		private static long id = 0;
		private long transactionID;
		private Bank.Operation operation;
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public string Note { get; set; }
		public long ID { get => transactionID; }

		public Transaction(decimal amount, DateTime date, Bank.Operation type, string note)
		{
			Amount = amount;
			Date = date;
			this.operation = type;
			Note = note;
			transactionID = ++id;
		}

		public string Info()
		{
			string info = $"Transaction #{ID}:\n"
				+ $"Date: [{Date.Day}.{Date.Month}.{Date.Year}|{Date.Hour}:{Date.Minute}:{Date.Second}]\n"
				+ $"Operation: {operation}\n" + $"Amount: {Amount}\n" + $"Note: {Note}";

			return info;
		}
	}
}
