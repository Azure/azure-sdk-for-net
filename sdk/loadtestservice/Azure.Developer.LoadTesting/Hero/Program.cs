using System;
using System.IO;
using System.Reflection;
using Azure;
using Azure.Core;
using Azure.Developer.LoadTesting;
using Azure.Identity;

namespace Hero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creating TokenCredential
            // Environment.GetEnvironmentVariable
            TokenCredentialOptions tokenCredentialOptions = new TokenCredentialOptions();
            tokenCredentialOptions.AuthorityHost = new Uri("https://login.windows-ppe.net");
            
            TokenCredential credential = new ClientSecretCredential(
                    tenantId: Environment.GetEnvironmentVariable("AZURE_TENANT_ID"),
                    clientId: Environment.GetEnvironmentVariable("AZURE_CLIENT_ID"),
                    clientSecret: Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET"),
                    options: tokenCredentialOptions
                );


            // creating Loadtesting client
            LoadTestingClient loadTestingClient = new LoadTestingClient(
                endpoint: "https://4c58f20e-52a9-4e22-8593-33938c025b6b.northeurope.cnt-dev.loadtesting.azure.com",
                credential: credential
            );


            // getting subclients
            LoadTestAdministrationClient loadTestAdministrationClient = loadTestingClient.getLoadTestAdministration();
            LoadTestRunClient loadTestRunClient = loadTestingClient.getLoadTestRun();


            // setting few important variables
            string testId = "my-dotnet-test-id";
            string testRunId = "my-dotnet-test-run-id";
            string fileName = "my-dotnet-file-name.jmx";
            string subscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID");
            string appComponentConnectionString = "/subscriptions/" + subscriptionId + "/resourceGroups/App-Service-Sample-Demo-rg/providers/Microsoft.Web/sites/App-Service-Sample-Demo";

            // create loadtest
            try
            {
                Response response = loadTestAdministrationClient.CreateOrUpdateTest(testId, RequestContent.Create(
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
                   }));

                Console.WriteLine("Loadtest created successfully");
                Console.WriteLine(response.Content.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            // upload file
            try
            {
                Response response = loadTestAdministrationClient.UploadTestFile(testId, fileName, RequestContent.Create(
                        File.OpenRead(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sample.jmx"))
                    ));

                Console.WriteLine("File uploaded successfully");
                Console.WriteLine(response.Content.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error : ", e.Message));
            }


            // wait for file to complete Validation
            try
            {
                TestFileValidationStatus testFileValidationStatus = loadTestAdministrationClient.BeginGetTestScriptValidationStatus(testId);

                Console.WriteLine(testFileValidationStatus.ToString());

                if(testFileValidationStatus != TestFileValidationStatus.ValidationSuccess)
                {
                    // if file validaion failed, then stop the process
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error : ", e.Message));
            }


            // connecting app component
            try
            {
                var data = new
                {
                    testid = testId,
                    name = "New App Component",
                    value = new
                    {
                        appComponentConnectionString = new
                        {
                            resourceId = appComponentConnectionString,
                            resourceName = "App-Service-Sample-Demo",
                            resourceType = "Microsoft.Web/sites",
                            subscriptionId = subscriptionId
                        }
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error : ", e.Message));
            }


            // running test
            try
            {
                var data = new
                {
                    testid = testId,
                    displayName = "Some display name"
                };

                Response response = loadTestRunClient.CreateOrUpdateTestRun(testRunId, RequestContent.Create(data));
            }
            catch(Exception e)
            {
                Console.WriteLine(String.Format("Error : ", e.Message));
            }


            // waiting for test to complete
            try
            {
                TestRunStatus testRunStatus = loadTestRunClient.BeginTestRunStatus(testRunId);
                Console.WriteLine(testRunStatus.ToString());

                if(testRunStatus!= TestRunStatus.ValidationSuccess)
                {
                    return;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(String.Format("Error : ", e.Message));
            }

            // getting matrics from loadtest
            try
            {
                Response responseGetTestRun = loadTestRunClient.GetTestRun(testRunId);
                JsonDocument responseGetTestRunJson = JsonDocument.Parse(responseGetTestRun.Content.ToString());

                Response metricNamespaces = loadTestRunClient.GetMetricNamespaces(testRunId);
                Console.WriteLine("Metric Namespaces : ", metricNamespaces.Content.ToString());
                JsonDocument metricNamespacesJson = JsonDocument.Parse(metricNamespaces.Content.ToString());

                Response metricDefinitions = loadTestRunClient.GetMetricDefinitions(
                    testRunId,
                    metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString()
                );
                JsonDocument metricDefinitionsJson = JsonDocument.Parse(metricDefinitions.Content.ToString());

                Response metricValues = loadTestRunClient.GetMetrics(
                    testRunId,
                    metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
                    metricDefinitionsJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
                    responseGetTestRunJson.RootElement.GetProperty("startDateTime").GetString() + "/" + responseGetTestRunJson.RootElement.GetProperty("endDateTime").GetString()
                );
                
            }
            catch(Exception e)
            {
                Console.WriteLine(String.Format("Error : ", e.Message));
            }
        }
    }
}
