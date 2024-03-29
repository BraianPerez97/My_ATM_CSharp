﻿using System;
using System.Runtime.Serialization.Formatters;

public class cardHolder
{
    String cardnum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardnum, int pin, String firstName, String lastName, double balance)
    {
        this.cardnum = cardnum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardnum;
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

    public double getBalance()      //returns balance
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardnum = newCardNum;
    }

    public void setPin(String newPin)
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
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: + currentUser.getBalance()");
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw? ");
            double withdraw = Double.Parse(Console.ReadLine());
            //Check if the user has money
            if(currentUser.getBalance() > withdraw)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("Thank YOU" :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your balance is: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1234567890", 1234, "Braian", "Perez", 200.99)); 
        cardHolders.Add(new cardHolder("1234567890", 4321, "Nashalys", "Fernandez", 700.99)); 
        cardHolders.Add(new cardHolder("1234567890", 1423, "Ale", "Holbie", 900.99)); 
        cardHolders.Add(new cardHolder("1234567890", 1243, "Random", "NPC", 10000.99)); 

        // Prompt user
        Console.WriteLine("Welcome to My ATM Machine");
        Console.WriteLine("Please enter your card number: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try{
                debitCardNum = Console.ReadLine();
                // check against our db (NO DB ADDED YET)
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) {break; }
                else { Console.WriteLine("Card not recognized. Please try again");}
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true)
        {
            try{
                userPin = int.Parse(Console.ReadLine());
                if(currentUser.getPin() == userPin) {break; }
                else { Console.WriteLine("Wrong PIN. Please try again");}
            }
            catch { Console.WriteLine("Wrong PIN. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " " + currentUser.getLastName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option =0; }
        }
        while(option != 4);
        Console.WriteLine("Thank you come again! :)");
    }
}