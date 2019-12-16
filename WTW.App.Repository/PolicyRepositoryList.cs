using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WTW.App.Domain;
using WTW.App.Repository.Contracts;

namespace WTW.App.Repository
{
    public class PolicyRepositoryListStorage: IPolicyRepository
    {
        private readonly IList<Policy> _policies;

        public PolicyRepositoryListStorage()
        {

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

        public async Task<IQueryable<Policy>> Get()
        {
            return await Task.FromResult<IQueryable<Policy>>(_policies.AsQueryable());
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

        public async Task<IQueryable<Policy>> Get(Expression<Func<Policy, bool>> expression)
        {
            var policies = _policies.AsQueryable().Where(expression);
            return await Task.FromResult(policies);
        }


        //public async Task<Policy> GetSingle(Expression<Func<Policy, bool>> expression)
        //{
        //    var policy = _policies.AsQueryable().FirstOrDefault(expression);
        //    return await Task.FromResult<Policy>(policy);
        //}

        //public Task<IEnumerable<Policy>> GetMany(Expression<Func<Policy, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}

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

