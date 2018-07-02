namespace Adapter
{
    public class Volt
    {
        private int volts;

        public Volt(int v)
        {
            this.volts = v;
        }

        public int getVolts()
        {
            return this.volts;
        }

        public void setVolts(int volts)
        {
            this.volts = volts;
        }
    }

    public class Socket
    {
        public Volt getVolt()
        {
            return new Volt(120);
        }
    }

    public interface SocketAdapter
    {
        Volt get120Volt();
        Volt get12Volt();
        Volt get3Volt();
    }

    public class SocketClassAdapterImpl : Socket, SocketAdapter
    {
        public Volt get120Volt()
        {
            return getVolt();
        }

        public Volt get12Volt()
        {
            Volt v = getVolt();
            return convertVolt(v, 10);
        }

        public Volt get3Volt()
        {
            Volt v = getVolt();
            return convertVolt(v, 40);
        }

        public Volt convertVolt(Volt v, int i)
        {
            return new Volt(v.getVolts() / i);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
