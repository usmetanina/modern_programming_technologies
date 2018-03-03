using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Export(typeof(ILogger))]
public class DateLogger : ILogger
{
    public void Log(string message)
    {
        string path = Environment.ExpandEnvironmentVariables("%TEMP%\\test.log");
        File.AppendAllText(path, message + " " + DateTime.Now + "\r\n");
    }
}