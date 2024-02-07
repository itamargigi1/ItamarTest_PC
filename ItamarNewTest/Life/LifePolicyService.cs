using System;
using ItamarNewTest.Utils;
using ItamarNewTest.Logging;
using System.Collections.Generic;

namespace ItamarNewTest.Policies
{
    public class LifePolicyService : ValidatorService, IPolicyService
    {
        private ILogger _logger;
        private LifePolicy _lifePolicy;

        public LifePolicyService(LifePolicy lifePolicy, ILogger logger)
        {
            _logger = logger;
            _lifePolicy = lifePolicy;

            AddValidations(new KeyValuePair<Predicate<Policy>, string>(x => ((LifePolicy)x).DateOfBirth == DateTime.MinValue, "Life policy must include Date of Birth."),
                        new KeyValuePair<Predicate<Policy>, string>(x => ((LifePolicy)x).DateOfBirth < DateTime.Today.AddYears(-100), "Max eligible age for coverage is 100 years."),
                        new KeyValuePair<Predicate<Policy>, string>(x => ((LifePolicy)x).Amount == 0, "Life policy must include an Amount."));
        }

        public decimal Rate()
        {
            decimal rating;
            _logger.LogMessage("Rating LIFE policy...");
            _logger.LogMessage("Validating policy.");

            if (!IsValidatePolicy(_lifePolicy))
            {
                _logger.LogMessage(_validators);
                return 0;
            }

            int age = DateTime.Today.Year - _lifePolicy.DateOfBirth.Year;
            if (_lifePolicy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < _lifePolicy.DateOfBirth.Day ||
                DateTime.Today.Month < _lifePolicy.DateOfBirth.Month)
            {
                age--;
            }

            decimal baseRate = _lifePolicy.Amount * age / 200;
            rating = _lifePolicy.IsSmoker ? baseRate * 2 : baseRate;
            return rating;
        }
    }
}
