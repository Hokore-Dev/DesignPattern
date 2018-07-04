using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_responsibility
{
    public abstract class AbstractLogger
    {
        public static int INFO = 1;
        public static int DEBUG = 2;
        public static int ERROR = 3;

        protected int level;

        protected AbstractLogger nextLogger;

        public void SetNextLogger(AbstractLogger inNextLogger)
        {
            this.nextLogger = inNextLogger;
        }

        public void LogMessage(int inLevel, string inMessage)
        {
            if (this.level <= inLevel)
            {
                Write(inMessage);
            }
            if (nextLogger != null)
            {
                nextLogger.LogMessage(inLevel, inMessage);
            }
        }

        abstract protected void Write(string message);
    }

    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger(int inLevel)
        {
            this.level = inLevel;
        }

        protected override void Write(string inMessage)
        {
            Console.WriteLine("Console Logger " + inMessage);
        }
    }

    public class ErrorLogger : AbstractLogger
    {
        public ErrorLogger(int inLevel)
        {
            this.level = inLevel;
        }

        protected override void Write(string inMessage)
        {
            Console.WriteLine("Error Logger " + inMessage);
        }
    }

    public class FileLogger : AbstractLogger
    {
        public FileLogger(int inLevel)
        {
            this.level = inLevel;
        }

        protected override void Write(string inMessage)
        {
            Console.WriteLine("File Logger " + inMessage);
        }
    }

    class Program
    {
        private static AbstractLogger GetChainOfLogger()
        {
            AbstractLogger errorLogger = new ErrorLogger(AbstractLogger.ERROR);
            AbstractLogger fileLogger = new FileLogger(AbstractLogger.DEBUG);
            AbstractLogger consoleLogger = new ConsoleLogger(AbstractLogger.INFO);

            errorLogger.SetNextLogger(fileLogger);
            fileLogger.SetNextLogger(consoleLogger);

            return errorLogger;
        }

        static void Main(string[] args)
        {
            AbstractLogger loggerChain = GetChainOfLogger();

            loggerChain.LogMessage(AbstractLogger.INFO, "information");
            loggerChain.LogMessage(AbstractLogger.DEBUG, "debug information");
            loggerChain.LogMessage(AbstractLogger.ERROR, "error information");
        }
    }
}
