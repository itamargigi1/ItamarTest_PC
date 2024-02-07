using System;
using System.Linq;
using ItamarNewTest.Policies;
using System.Collections.Generic;

namespace ItamarNewTest.Utils
{
    public class ValidatorService
    {
        private Dictionary<Predicate<Policy>, string> _list1;
        protected List<string> _validators;

        public ValidatorService()
        {
            _validators = new List<string>();
            _list1 = new Dictionary<Predicate<Policy>, string>();
        }

        protected void AddValidations(params KeyValuePair<Predicate<Policy>, string>[] validations)
        {
            validations.ToList().ForEach(v =>
            {
                _list1.Add(v.Key, v.Value);
            });
        }

        protected bool IsValidatePolicy(Policy policy)
        {
            _list1.ToList().ForEach(func =>
            {
                if (func.Key(policy))
                {
                    _validators.Add(func.Value);
                }
            });

            bool isValid = !_validators.Any();
            return isValid;
        }
    }
}
