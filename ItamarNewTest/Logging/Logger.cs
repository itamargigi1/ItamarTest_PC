namespace ItamarNewTest.Logging
{
    public class Logger
    {
        // Declare a delegate for logging methods
        public delegate void LogHandler(string message);

        // Register a method to be called when logging
        public LogHandler Log;

        // Log a message using the registered method
        public void LogMessage(string message)
        {
            Log?.Invoke(message);
        }
    }
}