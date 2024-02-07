using System;
using Newtonsoft.Json;
using ItamarNewTest.Enums;
using ItamarNewTest.Policies;

namespace ItamarNewTest.Utils
{
    internal class JsonDeserializer
    {
        public static Policy DeserializePolicy(PolicyType policyType, string policyJson)
        {
            string typeName = string.Format("{0}.{1}Policy", typeof(Policy).Namespace, policyType.ToString());
            Type type = Type.GetType(typeName);
            return (Policy)JsonConvert.DeserializeObject(policyJson, type);
        }
    }
}
