using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Company.Function
{
    public static class Counter
    {
        [FunctionName("Counter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"AzureCounter", collectionName: "Counter", ConnectionStringSetting = "AzureCounterConnectionString", PartitionKey = "1", Id = "1")] CounterClass counter,
            [CosmosDB(databaseName:"AzureCounter", collectionName: "Counter", ConnectionStringSetting = "AzureCounterConnectionString", PartitionKey = "1", Id = "1")] out CounterClass updatedCounter,

            ILogger log)
        {

            updatedCounter = counter;
            log.LogInformation($"C# HTTP trigger function processed a request. {counter.Count}, {updatedCounter.Count}" );
            updatedCounter.Count = updatedCounter.Count + 1;

            var jsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}
