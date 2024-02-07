using ItamarNewTest.Logging;
using ItamarNewTest.Policies;

namespace ItamarNewTest
{
    public class RatingEngine
    {
        private ILogger _logger;

        public RatingEngine(ILogger logger)
        {
            _logger = logger;
        }

        public decimal Rate()
        {
            _logger.LogMessage("Starting rate.");

            _logger.LogMessage("Loading policy.");

            IPolicyService service = PolicyFactory.GetPolicyService("policy.json", _logger);

            decimal rating = service.Rate();

            _logger.LogMessage("Rating completed.");

            return rating;
        }
    }
}
