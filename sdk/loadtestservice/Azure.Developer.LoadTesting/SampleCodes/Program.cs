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
        static string endpoint = Environment.GetEnvironmentVariable("ENDPOINT");
        static string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
        static string tenantId = Environment.GetEnvironmentVariable("TENANT_ID");
        static string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");


        static void PrintResults(Response response)
        {
            Console.WriteLine("Response Status : " + response.Status);
            Console.WriteLine("Is Error : " + response.IsError);
            Console.WriteLine("Reason Phrase : " + response.ReasonPhrase);
            Console.WriteLine("Response Content : " + response.Content);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Code Starting . . . . . . . ");

            TokenCredential credential = new ClientSecretCredential(tenantId: tenantId, clientId: clientId, clientSecret: clientSecret);

            LoadTestingClient client = new LoadTestingClient(endpoint, credential);

            string testid = "d7c68e2a-bcd8-423f-b9ce-fe9cccd00f1c";
            string fileid = "1c2ccb7b-8f62-4f70-812e-70df2c3df314";
            string testrunid = "df697300-dd3d-4654-bddf-e83d70f71af8";
            string appcomponentid = "ff0be495-eb8b-43f7-b18b-7877d33d98e7";
            string JMXPath = "/mnt/c/Users/niveditjain/Desktop/csharp/sdk/loadtestservice/Azure.Developer.LoadTesting/SampleCodes/sample.jmx";
            string appComponentConnectionString = "/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourceGroups/App-Service-Sample-Demo-rg/providers/Microsoft.Web/sites/App-Service-Sample-Demo";

            // getting clients for LoadTestAdministration and LoadTestRun
            LoadTestAdministrationClient loadTestAdministration = client.getLoadTestAdministration();
            TestRunClient loadTestRun = client.getLoadTestRun();

            // CreateOrUpateTest
            // Creating a loadtest resource
            PrintResults(loadTestAdministration.CreateOrUpdateTest(testid, RequestContent.Create(
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
                )));

            // UploadTestFile
            // Attaching a file to a loadtest resource
            PrintResults(loadTestAdministration.UploadTestFile(testid, fileid, File.OpenRead(JMXPath)));

            // CreateOrUpdateAppComponents
            // Attaching a app component to a loadtest resource
            PrintResults(loadTestAdministration.CreateOrUpdateAppComponents(appcomponentid,
                    RequestContent.Create(new
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
                )));

            // CreateAndUpdateTest
            // Creating loadtest run and starting it
            PrintResults(loadTestRun.CreateAndUpdateTest(testrunid, RequestContent.Create(
                    new
                    {
                        testId = testid,
                        displayName = "This is a display name",
                    }
                )));

        }
    }
}
