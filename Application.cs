using System;
using System.IO;

namespace BankSystem
{
	sealed internal class Application
	{
		static void Main(string[] args)
		{
			Bank bank = new Bank("Tinkoff", 1000000);
			var a1 = bank.CreateAccount("Ivan", "Ivanov");
			a1.PutMoney(413241234, "TEST!");
			Console.ReadKey();
		}
	}
}
