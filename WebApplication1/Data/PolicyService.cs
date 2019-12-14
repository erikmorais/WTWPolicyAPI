using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTW.App.Domain;
using WTW.App.Web.Api.Interfaces.Factories;
using WTW.App.Web.Api.Interfaces.Services;

namespace WebApplication1.Data
{
    public class PolicyService : IPolicyService
    {
        private readonly IList<Policy> _policies;
        private readonly IPolicyExpressionFactory _expressionFactory;

        public PolicyService(IPolicyExpressionFactory policyExpressionFactory)
        {
            _expressionFactory = policyExpressionFactory;

            _policies = new List<Policy>
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

        public async Task Add(Policy policy)
        {
            await Task.Run(() => _policies.Add(policy));

        }

        public async Task Update(Policy policy)
        {
            await Remove(policy.PolicyNumber);
            await Task.Run(() =>
            {
                _policies.Add(policy);
            });
        }

        public async Task<IEnumerable<Policy>> Get()
        {
            return await Task.FromResult<IEnumerable<Policy>>(_policies);
        }

        public async Task Remove(int policyNumber)
        {

            var policy = _policies.SingleOrDefault(p => p.PolicyNumber == policyNumber);

            if (policy != null)
            {
                await Task.Run(() =>
                {
                    _policies.Remove(policy);
                });
            }

        }

        public async Task<Policy> GetByPolicyNumber(int policyNumber)
        {
            //_expressionFactory
            //var policy = _policies.SingleOrDefault(p => p.PolicyNumber == policyNumber);
            var policy = _policies.AsQueryable().FirstOrDefault(_expressionFactory.PolicyByPolicynumber(policyNumber));
            return await Task.FromResult<Policy>(policy);
        }

        private readonly PolicyHolder _policyHolder1 = new PolicyHolder
        {
            Id = 1,
            Name = "Dwayne Johnson",
            Age = 44,
            Gender = Gender.Male
        };

        private readonly PolicyHolder _policyHolder2 = new PolicyHolder
        {
            Id = 2,
            Name = "John Cena",
            Age = 38,
            Gender = Gender.Male
        };

        private readonly PolicyHolder _policyHolder3 = new PolicyHolder
        {
            Id = 3,
            Name = "Trish Stratus",
            Age = 42,
            Gender = Gender.Female
        };
    }
}