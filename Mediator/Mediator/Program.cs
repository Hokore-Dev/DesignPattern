using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public interface IMediator
    {
        void SendEvent(string inName, string inEvent);
    }

    class Mediator : IMediator
    {
        private List<Colleague> colleague = new List<Colleague>();

        public Mediator()
        {

        }

        public void AddColleague(Colleague a)
        {
            a.SetMediator(this);
            colleague.Add(a);
        }

        public void SendEvent(string inName, string inEvent)
        {
            foreach (var c in colleague)
            {
                if (c.GetName() == inName)
                {
                    c.ReceiveEvent(inName, inEvent);
                }
            }
        }
    }

    class A : Colleague
    {
        string name = "A";

        public override void FireEvent(string inEvent)
        {
            mediator.SendEvent(name, inEvent);
        }

        public override void ReceiveEvent(string inName, string inEvent)
        {
            Console.Write("Receive event from " + name);
        }

        public override string GetName()
        {
            return name;
        }
    }

    class B : Colleague
    {
        string name = "B";

        public override void FireEvent(string inEvent)
        {
            mediator.SendEvent(name, inEvent);
        }

        public override void ReceiveEvent(string inName, string inEvent)
        {
            Console.Write("Receive event from " + name);
        }

        public override string GetName()
        {
            return name;
        }
    }

    class C : Colleague
    {
        string name = "C";

        public override void FireEvent(string inEvent)
        {
            mediator.SendEvent(name, inEvent);
        }

        public override void ReceiveEvent(string inName, string inEvent)
        {
            Console.Write("Receive event from " + name);
        }

        public override string GetName()
        {
            return name;
        }
    }

    abstract class Colleague
    {
        public IMediator mediator;

        public void SetMediator(IMediator im)
        {
            this.mediator = im;
        }

        public void SendEvent(string inName, string inEvent)
        {
            mediator.SendEvent(inName, inEvent);
        }

        abstract public void FireEvent(string inEvent);

        abstract public void ReceiveEvent(string inName, string inEvent);

        abstract public string GetName();
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();

            Mediator m = new Mediator();
            m.AddColleague(a);
            m.AddColleague(b);
            m.AddColleague(c);

            m.SendEvent("B", "Hello");
            a.FireEvent("ReceiveMail");
        }
    }
}
