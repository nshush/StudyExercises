using System;
using System.Collections.Generic;

namespace StudyExercises
{
    // Класс адреса
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public override string ToString()
        {
            return $"{Street}, {City}, {ZipCode}";
        }
    }

    // Абстрактный класс доставки
    public abstract class Delivery
    {
        public Address Address { get; set; }

        public abstract void PrepareDelivery();
    }

    // Доставка на дом
    public class HomeDelivery : Delivery
    {
        public string CourierName { get; set; }

        public override void PrepareDelivery()
        {
            Console.WriteLine($"Подготовка доставки на дом с курьером {CourierName}");
        }
    }

    // Доставка в пункт выдачи
    public class PickPointDelivery : Delivery
    {
        public string PickupPointName { get; set; }

        public override void PrepareDelivery()
        {
            Console.WriteLine($"Доставка в пункт выдачи {PickupPointName}");
        }
    }

    // Доставка в магазин
    public class ShopDelivery : Delivery
    {
        public string ShopName { get; set; }

        public override void PrepareDelivery()
        {
            Console.WriteLine($"Доставка в магазин {ShopName}");
        }
    }

    // Класс продукта
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Price:C}";
        }
    }

    // Заказ с обобщениями
    public class Order<TDelivery> where TDelivery : Delivery
    {
        private List<Product> products = new List<Product>();

        public TDelivery Delivery { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }

        // Индексатор для доступа к продуктам
        public Product this[int index]
        {
            get => products[index];
            set => products[index] = value;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }
            return total;
        }

        public void ShowOrderDetails()
        {
            Console.WriteLine($"Заказ #{Number}: {Description}");
            Console.WriteLine("Товары в заказе:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine($"Итого: {CalculateTotalPrice():C}");
            DisplayAddress();
        }

        // Перегрузка оператора ==
        public static bool operator ==(Order<TDelivery> order1, Order<TDelivery> order2)
        {
            return order1.Number == order2.Number;
        }

        // Перегрузка оператора !=
        public static bool operator !=(Order<TDelivery> order1, Order<TDelivery> order2)
        {
            return !(order1 == order2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Order<TDelivery> otherOrder)
            {
                return this == otherOrder;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }

    // Методы расширения для вывода информации о заказе
    public static class OrderExtensions
    {
        public static void PrintTotalPrice<TDelivery>(this Order<TDelivery> order) where TDelivery : Delivery
        {
            Console.WriteLine($"Общая стоимость заказа #{order.Number}: {order.CalculateTotalPrice():C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order<HomeDelivery>
            {
                Number = 1,
                Description = "Заказ на домашнюю доставку",
                Delivery = new HomeDelivery
                {
                    Address = new Address { Street = "Ленина 20", City = "Москва", ZipCode = "101000" },
                    CourierName = "Иван"
                }
            };

            order.AddProduct(new Product { Name = "Хлеб", Price = 50 });
            order.AddProduct(new Product { Name = "Молоко", Price = 80 });

            order.ShowOrderDetails();
            order.Delivery.PrepareDelivery();
            // Использование метода расширения
            order.PrintTotalPrice();

            // Проверка перегрузки операторов
            var anotherOrder = new Order<HomeDelivery> { Number = 1 };
            Console.WriteLine(order == anotherOrder ? "Заказы равны." : "Заказы не равны.");

            Console.ReadKey();
        }
    }
}