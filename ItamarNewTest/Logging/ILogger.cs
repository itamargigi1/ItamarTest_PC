using System.Collections.Generic;

namespace ItamarNewTest.Logging
{
    public interface ILogger
    {
        void LogMessage(string msg);
        void LogMessage(List<string> messages);
    }
}
