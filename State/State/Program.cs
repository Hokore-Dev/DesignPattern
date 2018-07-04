using System;

namespace State
{
    public interface IState
    {
        void Attack();
        void Jump();
    }

    public class Idle : IState
    {
        public void Attack()
        {
            Console.WriteLine("idle attack");
        }

        public void Jump()
        {
            Console.WriteLine("idle jump");
        }
    }

    public class Run : IState
    {
        public void Attack()
        {
            Console.WriteLine("run attack");
        }

        public void Jump()
        {
            Console.WriteLine("run jump");
        }
    }

    public class Character
    {
        IState state;

        public void SetState(IState inState)
        {
            state = inState;
        }

        public void Action()
        {
            state.Attack();
            state.Jump();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Character character = new Character();
            character.SetState(new Run());

            character.Action();

            character.SetState(new Idle());

            character.Action();
        }
    }
}
