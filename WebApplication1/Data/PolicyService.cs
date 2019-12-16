using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTW.App.Domain;
using WTW.App.Repository.Contracts;
using WTW.App.Web.Api.Interfaces.Factories;
using WTW.App.Web.Api.Interfaces.Services;

namespace WebApplication1.Data
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyExpressionFactory _expressionFactory;
        private readonly IPolicyRepository _policyRepositor;

        public PolicyService(IPolicyExpressionFactory policyExpressionFactory, IPolicyRepository policyRepository)
        {
            _expressionFactory = policyExpressionFactory;
            _policyRepositor = policyRepository;

        }

        public async Task Add(Policy policy)
        {
            await _policyRepositor.Add(policy);

        }

        public async Task Update(Policy policy)
        {
            await _policyRepositor.Remove(policy.PolicyNumber);
            await _policyRepositor.Add(policy);

        }

        public async Task<IEnumerable<Policy>> Get()
        {
           return await _policyRepositor.Get();
        }

        public async Task Remove(int policyNumber)
        {

            var policy = await _policyRepositor.Get(_expressionFactory.PolicyByPolicynumber(policyNumber));

            if (policy != null)
            {
                await _policyRepositor.Remove(policyNumber);
            }

        }

        public async Task<Policy> GetByPolicyNumber(int policyNumber)
        {
            var policy = await _policyRepositor.Get(_expressionFactory.PolicyByPolicynumber(policyNumber));
            return policy.SingleOrDefault();
        }

    }
}