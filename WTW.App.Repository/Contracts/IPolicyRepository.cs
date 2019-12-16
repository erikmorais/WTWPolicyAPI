using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WTW.App.Domain;

namespace WTW.App.Repository.Contracts
{
    public interface IPolicyRepository
    {
        Task<IQueryable<Policy>> Get();
        Task<IQueryable<Policy>> Get(Expression<Func<Policy, bool>> expression);
        Task Add(Policy policy);
        Task Update(Policy policy);
        Task Remove(int policyNumber);
    }
}
