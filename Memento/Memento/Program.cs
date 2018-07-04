using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class Memento
    {
        private string state;

        public Memento(string inState)
        {
            this.state = inState;
        }

        public string GetState()
        {
            return state;
        }
    }

    public class Originator
    {
        private string state;

        public void SetState(string inState)
        {
            this.state = inState;
        }

        public string GetState()
        {
            return state;
        }

        public Memento SaveStateToMemento()
        {
            return new Memento(state);
        }

        public void GetStateFromMemento(Memento inMemento)
        {
            state = inMemento.GetState();
        }
    }

    public class CareTaker
    {
        private List<Memento> mementoList = new List<Memento>();

        public void Add(Memento inState)
        {
            mementoList.Add(inState);
        }

        public Memento Get(int inIndex)
        {
            return mementoList[inIndex];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            CareTaker careTaker = new CareTaker();

            originator.SetState("State #1");
            originator.SetState("State #2");
            careTaker.Add(originator.SaveStateToMemento());

            originator.SetState("State #3");
            careTaker.Add(originator.SaveStateToMemento());

            originator.SetState("State #4");
            Console.Write("Current STate: " + originator.GetState());

            originator.GetStateFromMemento(careTaker.Get(0));
            Console.Write("First saved State: " + originator.GetState());

            originator.GetStateFromMemento(careTaker.Get(1));
            Console.Write("Second saved STate: " + originator.GetState());
        }
    }
}
