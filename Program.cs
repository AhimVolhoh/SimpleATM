using System;

public class cardHolder
{
	String cardNum;
	int pin;
	String firstName;
	String lastName;
	double balance;

	//Konstruktor
	public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
	{
		this.cardNum = cardNum;
		this.pin = pin;
		this.firstName = firstName;
		this.lastName = lastName;
		this.balance = balance;
	}

	public String getNum() 
	{
		return cardNum;
	}

	public int getPin()
	{
		return pin;
	}

	public String getFirstName()
	{
		return firstName;
	}

	public String getLastName()
	{
		return lastName;
	}

	public double getBalance()
	{
		return balance;
	}

	public void setNum(String newCardNum)
	{
		cardNum = newCardNum;
	}

	public void setPin(int newPin) 
	{
		pin = newPin;
	}

	public void setFirstName(String newFirstName)
	{
		firstName = newFirstName;
	}

	public void setLastName(String newLastName)
	{
		lastName = newLastName;
	}

	public void setBalance(double newBalance)
	{
		balance = newBalance;
	}


	public static void Main(String[] args)
	{
		void printOptions()
		{
			Console.WriteLine("Please choose one of the following options ...");
			Console.WriteLine("1. Deposit");
			Console.WriteLine("2. Withdraw");
			Console.WriteLine("3. Show Balance");
			Console.WriteLine("4. Exit");
		}

		void deposite(cardHolder currentUser)
		{
			Console.WriteLine("How much $$ would you like to deposite? ");
			double deposite = Double.Parse(Console.ReadLine());
			currentUser.setBalance(currentUser.getBalance() + deposite);
			Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
		}

		void withdraw(cardHolder currentUser)
		{
			Console.WriteLine("How much $$ would you like to withdraw? ");
			double withdrawl = Double.Parse(Console.ReadLine());
			if(currentUser.getBalance() < withdrawl)
			{
				Console.WriteLine("Insufficient balance: ");
			}
			else
			{
				currentUser.setBalance(currentUser.getBalance() - withdrawl);
				Console.WriteLine("You are good to go! Thank you :)");
			}
		}

		void balance(cardHolder currentUser)
		{
			Console.WriteLine("Current balance: " + currentUser.getBalance());
		}

		List<cardHolder> cardHolder = new List<cardHolder>();
		cardHolder.Add(new cardHolder("456789624573", 1244, "Erika", "Knos", 3000));
		cardHolder.Add(new cardHolder("753159852465", 5721, "Sima", "Lunger", 520));
		cardHolder.Add(new cardHolder("741258963208", 9513, "Bogdan", "Rost", 2000));
		cardHolder.Add(new cardHolder("951035147621", 2574, "Timofej", "Bolt", 50500));
		cardHolder.Add(new cardHolder("751236985204", 6570, "Stefani", "Skot", 5000));

		Console.WriteLine("Welocome to SimpleATM");
		Console.WriteLine("Please insert your debit card: ");
		String debitCardNum = "";
		cardHolder currentUser;

		while (true)
		{
			try
			{
				debitCardNum= Console.ReadLine();
				currentUser = cardHolder.FirstOrDefault(a => a.cardNum == debitCardNum);
				if(currentUser != null) { break; }
				else { Console.WriteLine("Card not recognized. Please try again.");}

			}
			catch
			{
				Console.WriteLine("Card not recognized. Please try again.");
			}
		}

		Console.WriteLine("Please enter your pin: ");
		int userPin = 0;
		while (true)
		{
			try
			{
				userPin = int.Parse(Console.ReadLine());
				if (currentUser.getPin() == userPin) { break; }
				else { Console.WriteLine("Incorrect pin. Please try again."); }

			}
			catch
			{
				Console.WriteLine("Incorrect pin. Please try again.");
			}
		}

		Console.WriteLine("Welcome " + currentUser.getFirstName() + " :) ");
		int option = 0;
		do
		{
			printOptions();
			try
			{
				option = int.Parse(Console.ReadLine());
			}
			catch { }
			if(option == 1) { deposite(currentUser); }
			else if(option == 2) { withdraw(currentUser); }
			else if(option ==3) { balance(currentUser); }
			else if(option == 4) { break; }
			else { option = 0; }
		}
		while (option != 4);
		Console.WriteLine("Thank you! Have a nice day :)");
	}
}