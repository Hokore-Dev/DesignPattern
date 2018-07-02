namespace Singleton
{
    public class Singleton
    {
        private static Singleton instance;
        public int A = 0;

        private Singleton() { }

        public static Singleton getInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton.getInstance().A = 4;
        }
    }
}
