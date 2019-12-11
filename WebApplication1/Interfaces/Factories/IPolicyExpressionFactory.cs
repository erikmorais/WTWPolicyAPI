using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WTW.App.Domain;

namespace WTW.App.Web.Api.Interfaces.Factories
{
    public interface IPolicyExpressionFactory
    {
        Expression<Func<Policy, bool>>  PolicyByPolicynumber(int policyNumber);
    }
}
