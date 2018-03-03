using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioc
{
    public interface ILogger
    {
        void Log(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    class DateLogger : ILogger
    {
        public void Log(string message)
        {
            string filePath = "test.log";
            File.AppendAllText(filePath, message + " " + DateTime.Now + "\r\n");
        }
    }
}
