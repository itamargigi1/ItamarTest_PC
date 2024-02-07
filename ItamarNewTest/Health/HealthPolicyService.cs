using System;
using ItamarNewTest.Utils;
using ItamarNewTest.Logging;
using ItamarNewTest.Policies;
using System.Collections.Generic;

namespace ItamarNewTest.Health
{
    internal class HealthPolicyService : ValidatorService, IPolicyService
    {
        private ILogger _logger;
        private HealthPolicy _healthPolicy;

        public HealthPolicyService(HealthPolicy healthPolicy, ILogger logger)
        {
            _healthPolicy = healthPolicy;
            _logger = logger;

            AddValidations(new KeyValuePair<Predicate<Policy>, string>(x => string.IsNullOrEmpty(((HealthPolicy)x).Gender), "Health policy must specify Gender"));
        }

        public decimal Rate()
        {
            decimal rating;
            _logger.LogMessage("Rating HEALTH policy...");
            _logger.LogMessage("Validating policy.");

            if (!IsValidatePolicy(_healthPolicy))
            {
                _logger.LogMessage(_validators);
                return 0;
            }

            if (_healthPolicy.Gender == "Male")
            {
                if (_healthPolicy.Deductible < 500)
                {
                    rating = 1000m;
                }

                rating = 900m;
            }
            else
            {
                if (_healthPolicy.Deductible < 800)
                {
                    rating = 1100m;
                }

                rating = 1000m;
            }

            return rating;
        }
    }
}
