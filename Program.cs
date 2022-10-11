using System;

public class cardHolder
{
    string cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;
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
    public void setBalancePlus(double newBalance)
    {
        balance += newBalance;
    }
    public void setBalanceMinus(double newBalance)
    {
        balance -= newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrat");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalancePlus(deposit);
            Console.WriteLine("Thank you for your ##. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would like to withdraw?");
            double withdrawal = Double.Parse(Console.ReadLine());
            if(currentUser.getBalance() > withdrawal)
            {
                Console.WriteLine("Not enough money :(");
            }
            else
            {
                currentUser.setBalanceMinus(withdrawal);
                Console.WriteLine("Your new balance is: " + currentUser.getBalance());

            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("12345678987654321", 1234, "Yuval", "Levi", 150.31));
        cardHolders.Add(new cardHolder("99999999999999999", 4321, "Simo", "vaknin", 1050.31));
        cardHolders.Add(new cardHolder("11111111111111111", 1616, "Ronit", "Levi", 1506.31));
        cardHolders.Add(new cardHolder("12312312312312312", 2424, "Amit", "Ohana", 15.31));


        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized, please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized, please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
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
            else if (option == 2 ) { withdraw(currentUser); }
            else if (option == 3 ) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you, Have aa nice day");

    }
}