using LAB5_Varian5_OOP__;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        IWillHaveOrder manager = new IWillHaveOrder();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Система керування доставкою замовлень у ресторані ---");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Додати замовлення на страву");
            Console.WriteLine("2. Додати замовлення на напій");
            Console.WriteLine("3. Показати всі замовлення");
            Console.WriteLine("4. Показати деталі замовлення за номером");
            Console.WriteLine("5. Показати деталі замовлення за назвою");
            Console.WriteLine("6. Зберегти замовлення у файл");
            Console.WriteLine("7. Завантажити замовлення з файлу");
            Console.WriteLine("8. Доставити замовлення за номером");
            Console.WriteLine("9. Подати страву");
            Console.WriteLine("10. Подати напій");
            Console.WriteLine("0. Вихід");
            Console.ResetColor();

            Console.Write("Оберіть опцію: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Невірний формат введення. Будь ласка, введіть число.");
                Console.ResetColor();
                continue;
            }

            switch (choice)
            {
                case 1:
                    string foodName = OrderValidator.ValidateName("Введіть назву страви: ");
                    decimal foodPrice = OrderValidator.ValidatePrice("Введіть ціну: ");
                    string foodAddress = OrderValidator.ValidateAddress("Введіть адресу доставки (натисніть Enter, щоб пропустити): ");
                    Food foodOrder = new Food(foodName, foodPrice, foodAddress);
                    manager.AddOrder(foodOrder);
                    break;

                case 2:
                    string drinkName = OrderValidator.ValidateName("Введіть назву напою: ");
                    decimal drinkPrice = OrderValidator.ValidatePrice("Введіть ціну: ");
                    string drinkAddress = OrderValidator.ValidateAddress("Введіть адресу доставки (натисніть Enter, щоб пропустити): ");
                    Drink drinkOrder = new Drink(drinkName, drinkPrice, drinkAddress);
                    manager.AddOrder(drinkOrder);
                    break;

                case 3:
                    manager.DisplayAllOrders();
                    break;

                case 4:
                    int orderNumber = OrderValidator.ValidateOrderNumber("Введіть номер замовлення: ");
                    manager.DisplayOrderDetails(orderNumber);
                    break;

                case 5:
                    Console.Write("Введіть назву замовлення: ");
                    string orderName = Console.ReadLine();
                    manager.DisplayOrderDetailsByName(orderName);
                    break;

                case 6:
                    Console.Write("Введіть назву файлу: ");
                    string saveFile = Console.ReadLine();
                    manager.SaveOrdersToFile(saveFile);
                    break;

                case 7:
                    Console.Write("Введіть назву файлу: ");
                    string loadFile = Console.ReadLine();
                    manager.LoadOrdersFromFile(loadFile);
                    break;

                case 8:
                    int orderToSend = OrderValidator.ValidateOrderNumber("Введіть номер замовлення для відправлення: ");
                    manager.DeliverOrder(orderToSend);
                    break;

                case 9:
                    int foodServeNumber = OrderValidator.ValidateOrderNumber("Введіть номер замовлення для подачі страви: ");
                    if (manager.orders[foodServeNumber - 1] is Food food)
                    {
                        food.ServeFood();
                    }
                    else
                    {
                        Console.WriteLine("Це замовлення не є напоєм.");
                    }
                    manager.ServeOrder(foodServeNumber);
                    break;

                case 10:
                    int drinkServeNumber = OrderValidator.ValidateOrderNumber("Введіть номер замовлення для подачі напою: ");
                    if (manager.orders[drinkServeNumber - 1] is Drink drink)
                    {
                        drink.ServeDrink();
                    }
                    else
                    {
                        Console.WriteLine("Це замовлення не є напоєм.");
                    }
                    manager.ServeOrder(drinkServeNumber);
                    break;

                case 0:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вихід з програми...");
                    Console.ResetColor();
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
