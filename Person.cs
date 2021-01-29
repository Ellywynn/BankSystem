using System;

namespace BankSystem
{
	public class Person
	{
		string name;
		string surname;
		int age;

		public string Name { get; set; }
		public string Surname { get; set; }
		public int Age
		{ 
			get => age;
			set 
			{
				if(value <= 0)
				{
					throw new ArgumentOutOfRangeException("Age must be positive.");
				}
				else
				{
					age = value;
				}
			}
		}

		public Person(string name, string surname, int age)
		{
			Name = name;
			Surname = surname;
			Age = age;
		}

		public override string ToString()
		{
			return $"{name} {surname} Age: {age}";
		}
	}
}
