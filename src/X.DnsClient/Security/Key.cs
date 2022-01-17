using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace X.DnsClient.Security
{
    public static class Key
    {
        public static ObjectResult Result(HttpContext ctx)
        {
            ctx.Request.Headers.TryGetValue("x-api-key", out var extractedApiKey);

            //check for valid key
            if (extractedApiKey == "1")
            {
                return new ObjectResult("") { StatusCode = 200, Value = extractedApiKey };
            }
            else
            {
                return new ObjectResult("Bad API Key: Please email dns@xavier.cc for help.") { StatusCode = 403 };
            }
        }
    }
}
