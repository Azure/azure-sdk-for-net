using System;
using Azure;
using Azure.Core;
using Azure.Developer.LoadTesting;
using Azure.Identity;

class Test
{
    public string Id { get; set; }

    public Test()
    {
        this.Id = Guid.NewGuid().ToString();
    }

    public Response Create(string endpoint, TokenCredential credentials)
    {
        //TestClient testClient = new TestClient(");
        //test

        //var data = new[]
        //{
        //    new
        //    {
        //        description = "New Description",
        //        displayName = "New Display Name",
        //        loadTestConfig = new
        //        {
        //            engineSize = "m",
        //            engineInstances = 1,
        //            splitAllCSVs = false
        //        },
        //        secret = new
        //        {

        //        },
        //        enviornmentVariable = new
        //        {

        //        },
        //        passFailCriteria = new {
        //        passFailMetrics = new
        //        {

        //        }
        //        },
        //        keyvaultReferenceIdentityType = "SystemAssigned"
        //    }
        //};


        //TestClient testClient = new TestClient(endpoint, credentials, new AzureLoadTestingClientOptions());
        //RequestContent content = RequestContent.Create(data);
        //RequestContent content = RequestContent.Create(
        //       "{}"
        //    );
        //Response response = testClient.CreateOrUpdateTest(this.Id, content);
        //Console.WriteLine(response.Status);
        //Console.WriteLine(response.IsError);
        //Console.WriteLine(response.ReasonPhrase);
        //Console.WriteLine(response.Content);
        //return response;
    }
}


namespace SampleCodes
{
    internal class Program
    {
        static string endpoint = "eccdc9b7-7603-402b-879d-bde2b637db56.eus.cnt-prod.loadtesting.azure.com";
        static string clientId = "747dd2f6-45bb-43db-9286-1a701def44a1";
        static string tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        static string clientSecret = "3Nw7Q~8Q_qSx_3o-c~4uw2J78rsiZ3dWjinzY";
        
        static void Main(string[] args)
        {
            Console.WriteLine("Code Starting . . . . . . . ");

            TokenCredential credential = new ClientSecretCredential(tenantId: tenantId, clientId: clientId, clientSecret: clientSecret);

            Test test = new Test();
            test.Create(endpoint, credential);
        }
    }
}
