using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WTW.App.Domain;

namespace WTW.App.Repository.Contracts
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> Get();
        Task<Policy> GetSingle(Expression<Func<Policy, bool>> expression );
        Task<IEnumerable<Policy>> GetMany(Expression<Func<Policy, bool>> expression);
        Task Add(Policy policy);
        Task Update(Policy policy);
        Task Remove(int policyNumber);
    }
}
