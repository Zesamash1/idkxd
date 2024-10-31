using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace LAB5_Varian5_OOP__
{
    public class IWillHaveOrder      // Клас для управління списком замовлень
    {
        public List<Order> orders = new List<Order>(); // Список для зберігання замовлень

        public void AddOrder(Order order)  // Додати замовлення до списку
        {
            orders.Add(order);
            Console.WriteLine($"Додано замовлення: {order.Name}.");
        }

        public void DisplayAllOrders()  // Вивести всі замовлення із нумерацією
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("Замовлень не знайдено.");
                return;
            }

            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {orders[i].Name}");
            }
        }
        public void ServeOrder(int orderNumber)
        {
            if (orderNumber > 0 && orderNumber <= orders.Count)
            {
                Order order = orders[orderNumber - 1];

                // Виконання подачі їжі
                if (order is IFoodOrder foodOrder)
                {
                    foodOrder.ServeFood();
                    orders.RemoveAt(orderNumber - 1); // Видаляємо зі списку
                    Console.WriteLine("Замовлення подано і видалено зі списку.");
                }
                // Виконання подачі напою
                else if (order is IDrinkOrder drinkOrder)
                {
                    drinkOrder.ServeDrink();
                    orders.RemoveAt(orderNumber - 1); // Видаляємо зі списку
                    Console.WriteLine("Замовлення подано і видалено зі списку.");
                }
            }
            else
            {
                Console.WriteLine("Невірний номер замовлення.");
            }
        }
        public void DeliverOrder(int orderNumber)
        {
            if (orderNumber > 0 && orderNumber <= orders.Count)
            {
                Order order = orders[orderNumber - 1];

                // Перевірка наявності адреси доставки
                if (string.IsNullOrWhiteSpace(order.DeliveryAddress) || order.DeliveryAddress == "Немає")
                {
                    Console.WriteLine("У даного замовлення немає адреси доставки.");
                    return;
                }

                // Виконання доставки
                if (order is IDeliverable deliverableOrder)
                {
                    deliverableOrder.DeliverOrder();
                    orders.RemoveAt(orderNumber - 1); // Видаляємо замовлення зі списку після доставки
                    Console.WriteLine("Замовлення доставлено і видалено зі списку.");
                }
            }
            else
            {
                Console.WriteLine("Невірний номер замовлення.");
            }
        }
      

        public void DisplayOrderDetails(int orderNumber) // Вивести деталі замовлення за номером
        {
            if (orderNumber > 0 && orderNumber <= orders.Count)
            {
                Order order = orders[orderNumber - 1];

                // Виводимо деталі замовлення
                order.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Невірний номер замовлення.");
            }
        }

        public void DisplayOrderDetailsByName(string name) // Вивести деталі замовлення за назвою
        {
            Order foundOrder = null;
            foreach (var order in orders)
            {
                if (string.Equals(order.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    foundOrder = order;
                    break;
                }
            }

            if (foundOrder != null)
            {
                foundOrder.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Замовлення з такою назвою не знайдено.");
            }

        }

        public void SaveOrdersToFile(string fileName)  // Зберегти всі замовлення у файл у форматі XML
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("Немає замовлень для збереження.");
                return;
            }
            // Створюємо серіалізатор для перетворення списку замовлень у XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>), new Type[] { typeof(Food), typeof(Drink) });
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, orders);
            }
            Console.WriteLine("Замовлення збережено у файл.");
        }

        public void LoadOrdersFromFile(string fileName)  // Завантажити замовлення з файлу у форматі XML
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine(" Файл не знайдено.");
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>), new Type[] { typeof(Food), typeof(Drink) });
            using (StreamReader reader = new StreamReader(fileName))
            {
                orders = (List<Order>)serializer.Deserialize(reader);
            }
            Console.WriteLine("Замовлення завантажено з файлу.");
        }
    }
}
