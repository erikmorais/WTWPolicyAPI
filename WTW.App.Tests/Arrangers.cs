using System;
using System.Collections.Generic;
using System.Text;
using WTW.App.Domain;

namespace WTW.App.Tests
{
    public class Arrangers
    {

        public static List<Policy> GetPolicies()
        {

            return new List<Policy>
            {
                new Policy
                {
                    PolicyNumber = 739562,
                    PolicyHolder = _policyHolder1
                },
                new Policy
                {
                    PolicyNumber = 383002,
                    PolicyHolder = _policyHolder1
                },
                new Policy
                {
                    PolicyNumber = 462946,
                    PolicyHolder = _policyHolder2
                },
                new Policy
                {
                    PolicyNumber = 355679,
                    PolicyHolder = _policyHolder3
                },
                new Policy
                {
                    PolicyNumber = 589881,
                    PolicyHolder = _policyHolder3
                },
                new Policy
                {
                    PolicyNumber = 998256,
                    PolicyHolder = _policyHolder3
                },
                new Policy
                {
                    PolicyNumber = 100374,
                    PolicyHolder = _policyHolder3
                }
            };
        }

        private static readonly PolicyHolder _policyHolder1 = new PolicyHolder
        {
            Id = 1,
            Name = "Dwayne Johnson",
            Age = 44,
            Gender = Gender.Male
        };

        private static readonly PolicyHolder _policyHolder2 = new PolicyHolder
        {
            Id = 2,
            Name = "John Cena",
            Age = 38,
            Gender = Gender.Male
        };

        private static readonly PolicyHolder _policyHolder3 = new PolicyHolder
        {
            Id = 3,
            Name = "Trish Stratus",
            Age = 42,
            Gender = Gender.Female
        };
    }
}
