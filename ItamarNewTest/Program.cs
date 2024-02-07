using System;
using ItamarNewTest.Logging;

namespace ItamarNewTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger consoleLogger = new ConsoleLogger();

            consoleLogger.LogMessage("Insurance Rating System Starting...");

            var engine = new RatingEngine(consoleLogger);
            decimal rating = engine.Rate();

            string msg = rating > 0 ? $"Rating: {rating}" : "No rating produced.";
            consoleLogger.LogMessage(msg);

            Console.ReadLine();
        }
    }
}
