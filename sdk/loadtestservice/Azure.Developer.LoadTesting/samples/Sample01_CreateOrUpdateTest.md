# Create or Update Load Test

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

You can create a LoadTestclient and call the `CreateOrUpdateTest` method from SubClient `LoadTestAdministration`

```
using System;
using System.IO;
using Azure;
using Azure.Core;
using Azure.Developer.LoadTesting;
using Azure.Identity;

namespace SampleCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // need to set this Enviornment Variable to set up Authentication and other required parameters
            string endpoint = Environment.GetEnvironmentVariable("ENDPOINT");
            string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            string tenantId = Environment.GetEnvironmentVariable("TENANT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");

            // ref: https://learn.microsoft.com/en-us/dotnet/api/azure.core.tokencredential?view=azure-dotnet to know more about TokenCredential based authentication
            TokenCredential credential = new ClientSecretCredential(tenantId: tenantId, clientId: clientId, clientSecret: clientSecret);

            // Creating main client
            LoadTestingClient client = new LoadTestingClient(endpoint, credential);

            // getting the Administration Sub Client
            LoadTestAdministrationClient loadTestAdministration = client.getLoadTestAdministration();

            Response response = loadTestAdministration.CreateOrUpdateTest(testid, RequestContent.Create(
                   new
                   {
                       description = "This is created using SDK",
                       displayName = "SDK's LoadTest",
                       loadTestConfig = new
                       {
                           engineInstances = 1,
                           splitAllCSVs = false,
                       },
                       secrets = new { },
                       enviornmentVariables = new { },
                       passFailCriteria = new
                       {
                           passFailMetrics = new { },
                       }
                   }
                ));
                
            Console.WriteLine("Response Status : " + response.Status);
            Console.WriteLine("Is Error : " + response.IsError);
            Console.WriteLine("Reason Phrase : " + response.ReasonPhrase);
            Console.WriteLine("Response Content : " + response.Content);
        }
    }
}
```