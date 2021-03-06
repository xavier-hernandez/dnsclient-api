/*
 * DnsApi
 *
 * This API will provide information for multiple record types.
 *
 * OpenAPI spec version: 1.0
 * Contact: dns@xavier.cc
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using X.DnsClient.Attributes;
using X.DnsClient.Security;
using Microsoft.AspNetCore.Authorization;
using X.DnsClient.Models;
using System.Security.Claims;
using Rollbar;

namespace X.DnsClient.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DnsApiController : ControllerBase
    { 
        /// <summary>
        /// Get A Record(s)
        /// </summary>
        /// <remarks>Retrieve A record(s) for a hostname.</remarks>
        /// <param name="hostname">host/domain name</param>
        /// <response code="200">OK</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Domain Not Found</response>
        /// <response code="429">Too Many Requests</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("/dns/ARecord")]
        [Authorize(AuthenticationSchemes = ApiKeyAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("GetARecord")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<AResult>), description: "OK")]
        public virtual IActionResult GetARecord([FromQuery][Required()]string hostname)
        {
            try
            {
                ObjectResult objectResult = Key.Result(HttpContext);

                if (objectResult.StatusCode == 200)
                {
                    Business.DnsLogic dnsLogic = new Business.DnsLogic();
                    var result = dnsLogic.ARecordResult(hostname, objectResult.Value.ToString());
                    
                    return new ObjectResult(result);
                }
                else
                {
                    return objectResult;
                }
            }
            catch (Exception ex)
            {
                Security.Rollbar.LogError(ex);
                return new ObjectResult("") { StatusCode = 500 };
            }
        }

        /// <summary>
        /// Get MX Record(s)
        /// </summary>
        /// <remarks>Retrieve MX record(s) for a hostname.</remarks>
        /// <param name="hostname">host/domain name</param>
        /// <response code="200">OK</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Domain Not Found</response>
        /// <response code="429">Too Many Requests</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("/dns/MXRecord")]
        [Authorize(AuthenticationSchemes = ApiKeyAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("GetMxRecord")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<MXResult>), description: "OK")]
        public virtual IActionResult GetMxRecord([FromQuery][Required()] string hostname)
        {
            try
            {
                ObjectResult objectResult = Key.Result(HttpContext);

                if (objectResult.StatusCode == 200)
                {
                    Business.DnsLogic dnsLogic = new Business.DnsLogic();
                    var result = dnsLogic.MXRecordResult(hostname, objectResult.Value.ToString());

                    return new ObjectResult(result);
                }
                else
                {
                    return objectResult;
                }
            }
            catch (Exception ex)
            {
                Security.Rollbar.LogError(ex);
                return new ObjectResult("") { StatusCode = 500 };
            }
        }

        /// <summary>
        /// Get TXT Record(s)
        /// </summary>
        /// <remarks>Retrieve TXT record(s) for a hostname.</remarks>
        /// <param name="hostname">host/domain name</param>
        /// <response code="200">OK</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Domain Not Found</response>
        /// <response code="429">Too Many Requests</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("/dns/TXTRecord")]
        [Authorize(AuthenticationSchemes = ApiKeyAuthenticationHandler.SchemeName)]
        [ValidateModelState]
        [SwaggerOperation("GetTxtRecord")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<TXTResult>), description: "OK")]
        public virtual IActionResult GetTxtRecord([FromQuery][Required()] string hostname)
        {
            try
            {
                ObjectResult objectResult = Key.Result(HttpContext);

                if (objectResult.StatusCode == 200)
                {
                    Business.DnsLogic dnsLogic = new Business.DnsLogic();
                    var result = dnsLogic.TXTRecordResult(hostname, objectResult.Value.ToString());

                    return new ObjectResult(result);
                }
                else
                {
                    return objectResult;
                }
            }
            catch (Exception ex)
            {
                Security.Rollbar.LogError(ex);
                return new ObjectResult("") { StatusCode = 500 };
            }

        }
    }
}
