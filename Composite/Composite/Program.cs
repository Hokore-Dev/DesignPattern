using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public interface Component
    {
        void Add(Component inComponent);
        void Remove(Component inComponent);
        Component GetChild(int i);
        string GetName();
        string Exec();
    }

    public class Leaf : Component
    {
        string name;
        public Leaf(string inName)
        {
            this.name = inName;
        }

        public void Add(Component inComponent)
        {
        }

        public string Exec()
        {
            return "hello";
        }

        public Component GetChild(int i)
        {
            return this;
        }

        public string GetName()
        {
            return "leaf";
        }

        public void Remove(Component inComponent)
        {
        }
    }

    public class Composite : Component
    {
        List<Component> compositeList = new List<Component>();
        string name;

        public void Add(Component inComponent)
        {
            this.Add(inComponent);
        }

        public string Exec()
        {
            return "hi";
        }

        public Component GetChild(int i)
        {
            return compositeList.ElementAt(i);
        }

        public string GetName()
        {
            return "composite";
        }

        public void Remove(Component inComponent)
        {
            compositeList.Remove(inComponent);
        }
    }

    public class Client
    {
        Component component;
        public Client(Component inComponent)
        {
            this.component = inComponent;
        }
        public void Exec()
        {
            component.Exec();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Component com1 = new Leaf("111");
            Component com2 = new Leaf("222");
            Component com3 = new Leaf("333");
            Component all = new Leaf("all");

            all.Add(com1);
            all.Add(com2);
            all.Add(com3);

            com2.Add(new Leaf("444"));

            Client c = new Client(all);
            c.Exec();
        }
    }
}
