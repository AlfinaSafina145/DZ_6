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
        private string account_number;
        private decimal balance;
        private AccountType type;

        public string AccountNumber
        {
            get { return account_number; }
            set { account_number = value;}
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
                BankAccount account = new BankAccount();

                account.AccountNumber = "1234567890000";
                account.Balance = 2345.05m;
                account.Type = AccountType.Savings;

                account.PrintInfo();


            }
        }
    }

}