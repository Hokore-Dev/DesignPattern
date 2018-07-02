namespace AbstractFactory
{
    interface IGUIFactory
    {
        IButton CreateButton();
        IToggle CreateToggle();
    }

    class WinFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }

        public IToggle CreateToggle()
        {
            return new WinToggle();
        }
    }

    class OSXFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new OSXButton();
        }

        public IToggle CreateToggle()
        {
            return new OSXToggle();
        }
    }

    interface IButton
    {
        void Paint();
    }

    class WinButton : IButton
    {
        public void Paint()
        {
        }
    }

    class OSXButton : IButton
    {
        public void Paint()
        {

        }
    }

    interface IToggle
    {
        void On();
    }

    class WinToggle : IToggle
    {
        public void On()
        {

        }
    }

    class OSXToggle : IToggle
    {
        public void On()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IGUIFactory factory = new WinFactory();
            var button = factory.CreateButton();
            button.Paint();
        }
    }
}
