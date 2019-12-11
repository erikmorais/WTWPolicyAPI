using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WTW.App.Domain;
using WTW.App.Web.Api.Interfaces.Factories;

namespace WTW.App.Web.Api.Factories
{
    public class PolicyExpressionFactory : IPolicyExpressionFactory
    {
        public Expression<Func<Policy, bool>> PolicyByPolicynumber(int policyNumber) => policy => policy.PolicyNumber== policyNumber;
    }
}
