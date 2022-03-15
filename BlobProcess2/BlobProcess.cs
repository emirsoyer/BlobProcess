using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BlobProcess2
{
    public static class BlobProcess
    {
        [FunctionName("BlobProcess")]
        public static void Run([BlobTrigger("demo/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob,
            [Blob("output/{name}",FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream outputBlob,
            string name, 
            ILogger log)
        {
            var len = myBlob.Length;
            myBlob.CopyTo(outputBlob);
            log.LogInformation($"Blob was processed\n Name: {name} \n Size: {len} Bytes");

        }
    }
}
