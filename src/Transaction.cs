using System;
using System.IO;

namespace BankSystem
{
	public class Transaction
	{
		private static long id = 0;
		private long transactionID;
		private Bank.Operation operation;
		public static long Count { 
			get => id;
			set
			{
				if (value > 0)
					id = value;
			}
		}
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public string Note { get; set; }
		public long ID { get => transactionID; }

		public Transaction(decimal amount, DateTime date, Bank.Operation type, string note = "")
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
				+ $"Operation: {operation}\n" + $"Amount: {Amount}\n";

			if(Note != "")
			{
				info += $"Note: {Note}";
			}

			return info;
		}

		public string InfoTable()
		{
			string info = $"#{String.Format("{0:000000}", ID)}\t\t"
				+ $"{String.Format("{0:00}", Date.Day)}." +
				$"{String.Format("{0:00}", Date.Month)}." +
				$"{String.Format("{0:0000}",Date.Year)}|" +
				$"{String.Format("{0:00}", Date.Hour)}:" +
				$"{String.Format("{0:00}", Date.Minute)}:" +
				$"{String.Format("{0:00}", Date.Second)}\t"
				+ $"{operation}\t\t" + $"{String.Format("{0:0000000000}", Amount)}\t";

			if (Note != "")
				info += $"{Note}\n";
			else info += '\n';

			return info;
		}
	}
}
