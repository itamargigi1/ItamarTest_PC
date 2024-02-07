using System;
using ItamarNewTest.Utils;
using ItamarNewTest.Logging;
using System.Collections.Generic;

namespace ItamarNewTest.Policies
{
    internal class TravelPolicyService : ValidatorService, IPolicyService
    {
        private ILogger _logger;
        private TravelPolicy _travelPolicy;

        public TravelPolicyService(TravelPolicy travelPolicy, ILogger logger)
        {
            _logger = logger;
            _travelPolicy = travelPolicy;

            AddValidations(new KeyValuePair<Predicate<Policy>, string>(x => ((TravelPolicy)x).Days <= 0, "Travel policy must specify Days."),
                        new KeyValuePair<Predicate<Policy>, string>(x => ((TravelPolicy)x).Days > 180, "Travel policy cannot be more then 180 Days."),
                        new KeyValuePair<Predicate<Policy>, string>(x => string.IsNullOrEmpty(((TravelPolicy)x).Country), "Travel policy must specify country."));
        }

        public decimal Rate()
        {
            decimal rating;

            _logger.LogMessage("Rating TRAVEL policy...");
            _logger.LogMessage("Validating policy.");

            if (!IsValidatePolicy(_travelPolicy))
            {
                _logger.LogMessage(_validators);
                return 0;
            }

            rating = _travelPolicy.Days * 2.5m;
            if (_travelPolicy.Country == "Italy")
            {
                rating *= 3;
            }

            return rating;
        }
    }
}
