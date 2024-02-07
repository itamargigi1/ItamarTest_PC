using System;
using System.Collections.Generic;

namespace ItamarNewTest.Logging
{
    public class ConsoleLogger : ILogger
    {
        private Logger _logger;

        public ConsoleLogger()
        {
            _logger = new Logger();
            _logger.Log += LogMessage;
        }

        public void LogMessage(string message)
        {
            Console.WriteLine($"Custom Logger: {message}");
        }

        public void LogMessage(List<string> messages)
        {
            messages.ForEach(m => Console.WriteLine($"Custom Logger: {m}"));
        }
    }
}
