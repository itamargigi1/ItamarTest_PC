using System;
using System.IO;
using System.Linq;
using ItamarNewTest.Enums;
using ItamarNewTest.Utils;
using ItamarNewTest.Logging;

namespace ItamarNewTest.Policies
{
    internal class PolicyFactory
    {
        public static IPolicyService GetPolicyService(string fileName, ILogger logger)
        {
            string policyJson = File.ReadAllText(fileName);

            PolicyType policyType = Enum.GetValues(typeof(PolicyType))
                .Cast<PolicyType>().First(type => policyJson.Contains(type.ToString()));

            Policy pl = JsonDeserializer.DeserializePolicy(policyType, policyJson);

            string serviceTypeName = string.Format("{0}.{1}PolicyService", typeof(Policy).Namespace, policyType.ToString());
            Type serviceType = Type.GetType(serviceTypeName);
            var service = (IPolicyService)Activator.CreateInstance(serviceType, pl, logger);

            return service;
        }
    }
}
