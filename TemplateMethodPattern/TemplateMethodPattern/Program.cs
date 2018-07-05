using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    public abstract class Person
    {
        void ReadyToBattle()
        {
            StartBodyTraining();
            PrepareWeapon();
            PrepareArmor();
            if (isUsingPrepareOther())
            {
                prepareOther();
            }
        }

        void StartBodyTraining()
        {
            Console.WriteLine("체력을 단련합니다.");
        }

        protected virtual void PrepareWeapon() { }

        protected virtual void PrepareArmor() { }

        bool isUsingPrepareOther()
        {
            return false;
        }

        void prepareOther() { }
    }

    public class Warrior : Person
    {
	    protected override void PrepareWeapon() {
            Console.WriteLine("검을 닦습니다.");
        }

        protected override void PrepareArmor()
        {
            Console.WriteLine("갑옷을 입습니다.");
        }
    }

    public class Wizard : Person
    {
        protected override void PrepareWeapon()
        {
            Console.WriteLine("지팡이를 준비합니다.");
        }

        protected override void PrepareArmor()
        {
            Console.WriteLine("로브를 입습니다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
