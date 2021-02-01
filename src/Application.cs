using System;
using System.IO;

namespace BankSystem
{
	sealed internal class Application
	{
		static void Main(string[] args)
		{
			//Bank bank = new Bank("Tinkoff", 1000000);

			string[] lines = File.ReadAllLines($@"Directory.GetCurrentDirectory()/test.txt");
			

			Console.ReadKey();
		}
	}
}
