using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5_Varian5_OOP__
{
    // Клас Food, успадковує Order та реалізує інтерфейси IFoodOrder і IDeliverable
    public class Food : Order, IFoodOrder, IDeliverable
    {
        public Food() { }

        public Food(string name, decimal price, string deliveryAddress = null)
            : base(name, price, deliveryAddress) { }

        public void ServeFood()
        {
            Console.WriteLine($"Подання їжі: {Name}.");
        }
        public void DeliverOrder() // Метод для доставки страви
        {
            Console.WriteLine(DeliveryAddress == null
                ? "Адреса доставки не вказана."
                : $"Доставка страви '{Name}' за адресою {DeliveryAddress}.");
        }

        public override void DisplayInfo()  // Вивід інформації про замовлення на страву
        {
            Console.WriteLine($"Замовлення на їжу: {Name}, Ціна: {Price:C}, Адреса доставки: {(DeliveryAddress ?? "немає")}");
        }
    }
}
