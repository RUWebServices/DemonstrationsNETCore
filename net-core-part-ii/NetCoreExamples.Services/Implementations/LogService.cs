using System;
using System.IO;
using NetCoreExamples.Services.Interfaces;

namespace NetCoreExamples.Services.Implementations
{
    public class LogService : ILogService
    {
        public void LogToFile(string message)
        {
            using (var file = new StreamWriter("log.txt", true))
            {
                file.WriteLine($"{DateTime.Now} - {message}");
            }
        }
    }
}