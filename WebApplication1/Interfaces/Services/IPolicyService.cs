using System.Collections.Generic;
using System.Threading.Tasks;
using WTW.App.Domain;

namespace WTW.App.Web.Api.Interfaces.Services
{
    public interface IPolicyService
    {
        Task<IEnumerable<Policy>> Get();
        Task<Policy> GetByPolicyNumber(int policyNumber);
        Task Add(Policy policy);
        Task Update(Policy policy);
        Task Remove(int policyNumber);
    }
}