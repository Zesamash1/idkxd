using System;

namespace LAB5_Varian5_OOP__
{
    public static class OrderValidator
    {
        // Метод для перевірки назви замовлення
        public static string ValidateName(string prompt)
        {
            string name;
            do
            {
                Console.Write(prompt);
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Назва не може бути порожньою. Будь ласка, введіть коректну назву.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        // Метод для перевірки ціни
        public static decimal ValidatePrice(string prompt)
        {
            decimal price;
            Console.Write(prompt);
            while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неправильне значення. Введіть коректну ціну більше нуля.");
                Console.ResetColor();
                Console.Write(prompt);
            }

            return price;
        }

        // Метод для перевірки адреси доставки
        public static string ValidateAddress(string prompt)
        {
            Console.Write(prompt);
            string address = Console.ReadLine();
            return string.IsNullOrWhiteSpace(address) ? null : address;
        }

        // Метод для перевірки номерів замовлення
        public static int ValidateOrderNumber(string prompt)
        {
            int orderNumber;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out orderNumber) || orderNumber <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Невірний формат введення. Будь ласка, введіть правильний номер.");
                Console.ResetColor();
                Console.Write(prompt);
            }
            return orderNumber;
        }
    }
}
