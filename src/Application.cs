using System;
using System.IO;

namespace BankSystem
{
	sealed internal class Application
	{
		static void Main(string[] args)
		{
			Bank bank = new Bank("Tinkoff", 1000000000);
			var ac1 = bank.CreateAccount("Ivan", "Ivanov");
			var ac2 = bank.CreateAccount("Petr", "Petrov");

			ac1.PutMoney(1000, "For Xbox");
			ac2.PutMoney(100000, "Wanna buy AUDI");

			Console.WriteLine($"{ac1.Owner} balance: {ac1.Balance}");
			Console.WriteLine($"{ac2.Owner} balance: {ac2.Balance}");

			Console.ReadKey();
		}
	}
}
