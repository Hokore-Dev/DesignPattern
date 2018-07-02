namespace Bridge
{
    interface Weapon
    {
        void attack();
        void repair();
    }

    class Bow : Weapon
    {
        public void attack()
        {
        }
        public void repair()
        {
        }
    }

    class Sword : Weapon
    {
        public void attack()
        {
        }
        public void repair()
        {
        }
    }

    interface WeaponHandler
    {
        void handle();
    }

    class Warrior : WeaponHandler
    {
        public void handle()
        {

        }
    }

    class Smith : WeaponHandler
    {
        public void handle()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
