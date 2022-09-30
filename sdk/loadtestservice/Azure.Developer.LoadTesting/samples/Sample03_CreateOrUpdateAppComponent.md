# Create or Update App Component

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/README.md#getting-started) for details.

You can create a LoadTestclient and call the `CreateOrUpdateAppComponents` method from SubClient `LoadTestAdministrationClient`

```csharp
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

            // <testid> to be replaced with unqiue testid of your test
            // supply a unique <appcomponentid> for your appcomonent
            Response response = CreateOrUpdateAppComponents(appcomponentid, RequestContent.Create(
                new
                    {
                        testid = testid,
                        name = "New App Component",
                        value = new
                        {
                            appComponentConnectionString = new
                            {
                                resourceId = appComponentConnectionString,
                                resourceName = "App-Service-Sample-Demo",
                                resourceType = "Microsoft.Web/sites",
                                subscriptionId = "7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a"
                            }
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