using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
	public class Transaction
	{
		private static long id = 0;
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public string Note { get; set; }
		public long Number { get => id; }

		public Transaction(decimal amount, DateTime date, string note)
		{
			Amount = amount;
			Date = date;
			Note = note;
			id++;
		}
	}
}
