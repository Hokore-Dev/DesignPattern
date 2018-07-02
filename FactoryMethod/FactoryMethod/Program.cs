using System;

namespace FactoryMethod
{
    public abstract class Pizza
    {
        public abstract float GetPrice();

        public enum EPizzaType
        {
            HamMushroom, Deluxe, Seafood
        }

        public static Pizza PizzaFactory(EPizzaType inPizzaType)
        {
            Pizza pizza = null;
            switch (inPizzaType)
            {
                case EPizzaType.HamMushroom:
                    pizza = new HamAndMushroomPizza();
                    break;
                case EPizzaType.Deluxe:
                    pizza = new DeluxePizza();
                    break;
                case EPizzaType.Seafood:
                    pizza = new SeafoodPizza();
                    break;
                default:
                    break;
            }
            return pizza;
        }
    }

    public class HamAndMushroomPizza : Pizza
    {
        private float price = 8.5f;
        public override float GetPrice() { return price; }
    }

    public class DeluxePizza : Pizza
    {
        private float price = 10.5f;
        public override float GetPrice() { return price; }
    }

    public class SeafoodPizza : Pizza
    {
        private float price = 11.5f;
        public override float GetPrice() { return price; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Pizza.PizzaFactory(Pizza.EPizzaType.Deluxe).GetPrice().ToString());
        }
    }
}
