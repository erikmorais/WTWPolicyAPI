using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WTW.App.Domain;
using WTW.App.Web.Api.Interfaces.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class PolicyController : Controller
    {
        private readonly IPolicyService _policyRepository;

        public PolicyController(IPolicyService policyRepository)
        {
            _policyRepository = policyRepository;
        }


        //TODO add methods to get/create/update/delete data from _repository
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Policy>> Get()
        {
            return await _policyRepository.Get();
        }

        [HttpGet]
        [Route("{policyNumber}", Name = "GetByPolicyNumber")]
        public async Task<ActionResult<Policy>> GetByPolicyNumber(int policyNumber)
        {
            var policy = await _policyRepository.GetByPolicyNumber(policyNumber);

            if (policy == null)
            {
                var message = string.Format("Policy with PolicyNumber = {0} not found", policyNumber);
                return StatusCode(StatusCodes.Status404NotFound, message);
            }

            return policy;
        }


       // [Route("edit")]
        [Route("")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Policy>> Update([FromBody]  Policy policy)
        {
           // var policy = new Policy();
            var policyFound = await _policyRepository.GetByPolicyNumber(policy.PolicyNumber);

            if (policyFound == null)
            {
                var message = string.Format("Policy with PolicyNumber = {0} not found", policy.PolicyNumber);
                return StatusCode(StatusCodes.Status404NotFound, message);
            }
            else
            {
                try
                {
                    await _policyRepository.Update(policy);
                    return CreatedAtRoute("GetByPolicyNumber", new {policy.PolicyNumber }, policy);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.ToString());
                }

            }
        }

        // [Route("add")
        [Route("add")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Policy>> Create([FromBody] Policy policy)
        {
            try
            {   if (policy is null) throw new ArgumentNullException("wrong policy data received");

                await _policyRepository.Add(policy);
                return CreatedAtRoute("GetByPolicyNumber", new { policy.PolicyNumber }, policy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a specific Policy.
        /// </summary>
        /// <param name="id"></param>      
      //  [HttpDelete("delete/{policyNumber}")]
        [HttpDelete("{policyNumber}")]
        public async Task<IActionResult> Delete(int policyNumber)
        {
            var policy = await _policyRepository.GetByPolicyNumber(policyNumber);

            if (policy == null)
            {
                var message = string.Format("Policy with PolicyNumber = {0} not found", policyNumber);
                return StatusCode(StatusCodes.Status404NotFound, message);
            }
            try
            {
                await _policyRepository.Remove(policyNumber);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

    }
}
