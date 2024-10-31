using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5_Varian5_OOP__
{
    // Клас Drink, успадковує Order та реалізує інтерфейси IDrinkOrder і IDeliverable
    public class Drink : Order, IDrinkOrder, IDeliverable
    {
        public Drink() { }

        public Drink(string name, decimal price, string deliveryAddress = null)
            : base(name, price, deliveryAddress) { }

        public void ServeDrink()  // Метод для подачі напою
        {
            Console.WriteLine($"Подання напою: {Name}.");
        }

        public void DeliverOrder()
        {
            Console.WriteLine(DeliveryAddress == null
                ? "Адреса доставки не вказана."
                : $"Доставка напою '{Name}' за адресою: {DeliveryAddress}.");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Замовлення на напій: {Name}, Ціна: {Price:C}, Адреса доставки: {(DeliveryAddress ?? "немає")}");
        }
    }
}