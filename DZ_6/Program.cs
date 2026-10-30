using System;
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
            set {  type = value; }
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
                Console.WriteLine("Создаем первый счет:");
                BankAccount acc1 = new BankAccount(1000m, AccountType.Savings);
                acc1.PrintInfo();

                Console.WriteLine("\nСоздаем второй счет:");
                BankAccount acc2 = new BankAccount(5000m, AccountType.Current);
                acc2.PrintInfo();

                Console.WriteLine("\nСоздаем третий счет:");
                BankAccount acc3 = new BankAccount(0m, AccountType.Savings);
                acc3.PrintInfo();


            }
        }
    }

}