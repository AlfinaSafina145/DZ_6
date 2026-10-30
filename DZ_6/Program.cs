using System;
using System.Security.Principal;
namespace BankApp
{
    public enum AccountType
    {
        Current,
        Savings
    }
    public class BankAccount
    {
        private static int lastAccountNumber = 0;
        private static int GenerateAccountNumber()
        {
            lastAccountNumber++;
            return lastAccountNumber;
        }
        private string account_number;
        private decimal balance;
        private AccountType type;
        public BankAccount(decimal initialBalance, AccountType accType)
        {
            account_number = GenerateAccountNumber().ToString();

            Balance = initialBalance;
            Type = accType;
        }

        public string AccountNumber
        {
            get { return account_number; }
        }
        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                    balance = value;
                else
                    Console.WriteLine("Ошибка: баланс не может быть отрицательным!");
            }
        }
        public AccountType Type
        {
            get { return type; }
            set { type = value; }
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Счет пополнен на {amount} руб.");
            }
            else
            {
                Console.WriteLine("Ошибка: сумма пополнения должна быть больше нуля.");
            }
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Ошибка: сумма снятия должна быть больше нуля.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Ошибка: недостаточно средств на счете.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Успешно снято {amount} руб.");
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Информация о счете");
            Console.WriteLine($"Номер счета: {AccountNumber}");
            Console.WriteLine($"Баланс: {Balance} руб.");
            Console.WriteLine($"Тип счета: {Type}");
        }
        class Program
        {
            static void Main(string[] args)
            {
                BankAccount myAccount = new BankAccount(1000m, AccountType.Savings);

                Console.WriteLine("Начальное состояние:");
                myAccount.PrintInfo();

                Console.WriteLine("\nПытаемся положить 500 руб:");
                myAccount.Deposit(500m);
                myAccount.PrintInfo();

                Console.WriteLine("\nПытаемся снять 300 руб:");
                myAccount.Withdraw(300m);
                myAccount.PrintInfo();

                Console.WriteLine("\nПытаемся снять 5000 руб (больше, чем есть):");
                myAccount.Withdraw(5000m);
                myAccount.PrintInfo();
            }
        }
    }

}