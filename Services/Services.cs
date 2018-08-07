
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace Services
{
    public static class HttpTrigger
    {
        [FunctionName("services")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            string json;
            using (StreamReader r = File.OpenText("Services.json"))
            {
                json = r.ReadToEnd();
               
            }

            //  string orgTypes = JsonConvert.DeserializeObject("Services.json");

            return (ActionResult)new OkObjectResult(json);
                       }
    }
}
