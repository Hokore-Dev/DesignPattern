using System;

namespace Visitor
{
    interface CarElementVisitor
    {
        void visit(Wheel wheel);
        void visit(Engine engine);
        void visit(Body body);
        void visit(Car car);
    }

    interface CarElement
    {
        void accept(CarElementVisitor visitor); // CarElements have to provide accept().
    }

    class Wheel : CarElement
    {
        private String name;

        public Wheel(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }

        public void accept(CarElementVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    class Engine : CarElement
    {
        public void accept(CarElementVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    class Body : CarElement
    {
        public void accept(CarElementVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    class Car : CarElement
    {
        CarElement[]
        elements;


        public CarElement[] getElements()
        {
            return elements.Clone() as CarElement[];
        }

        public Car()
        {
            this.elements = new CarElement[]
              { new Wheel("front left"), new Wheel("front right"),
            new Wheel("back left") , new Wheel("back right"),
            new Body(), new Engine() };
        }

        public void accept(CarElementVisitor visitor)
        {
            foreach (var element in this.getElements())
            {
                element.accept(visitor);
            }
            visitor.visit(this);
        }
    }

    class CarElementPrintVisitor : CarElementVisitor
    {
        public void visit(Wheel wheel)
        {
            Console.WriteLine("Visiting " + wheel.getName() + " wheel");
        }

        public void visit(Engine engine)
        {
            Console.WriteLine("Visiting engine");
        }

        public void visit(Body body)
        {
            Console.WriteLine("Visiting body");
        }

        public void visit(Car car)
        {
            Console.WriteLine("Visiting car");
        }
    }

    class CarElementDoVisitor : CarElementVisitor
    {
        public void visit(Wheel wheel)
        {
            Console.WriteLine("Kicking my " + wheel.getName() + " wheel");
        }

        public void visit(Engine engine)
        {
            Console.WriteLine("Starting my engine");
        }

        public void visit(Body body)
        {
            Console.WriteLine("Moving my body");
        }

        public void visit(Car car)
        {
            Console.WriteLine("Starting my car");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
