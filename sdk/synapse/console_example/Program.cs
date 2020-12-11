using System;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;
using Azure.Identity;

namespace test_samples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var workspace = new Uri("https://workspacechhamosynapse.dev.azuresynapse.net");
            string sparkPoolName = "sparkchhamosyna";

            {
                Console.WriteLine("Test 1 - TestCreateTrigger()");

                var client = new TriggerClient(workspace, new DefaultAzureCredential());
                {
                    TriggerCreateOrUpdateTriggerOperation operation = await client.StartCreateOrUpdateTriggerAsync("TestTrigger-asdf", new TriggerResource(new Trigger()));
                    TriggerResource trigger = await operation.WaitForCompletionAsync();
                    Console.WriteLine("This next line should be non-null...");
                    Console.WriteLine("Name: " + trigger.Name);
                    // !FAILURE: This returns null not TestTrigger-asdf
                    Console.WriteLine();
                }

                {
                    // But this works 
                    TriggerCreateOrUpdateTriggerOperation operation = await client.StartCreateOrUpdateTriggerAsync("TestTrigger-asdf", new TriggerResource(new ScheduleTrigger(new ScheduleTriggerRecurrence())));
                    TriggerResource trigger = await operation.WaitForCompletionAsync();
                    Console.WriteLine("This next line is non-null...");
                    Console.WriteLine("Name: " + trigger.Name);
                }

                Console.WriteLine();
            }

            {
                Console.WriteLine("Test 2 - Execute Spark ()");

                SparkSessionClient client = new SparkSessionClient(workspace, sparkPoolName, new DefaultAzureCredential());

                SparkSessionOptions request = new SparkSessionOptions(name: $"session-{Guid.NewGuid()}")
                {
                    DriverMemory = "28g",
                    DriverCores = 4,
                    ExecutorMemory = "28g",
                    ExecutorCores = 4,
                    ExecutorCount = 2
                };

                SparkSession sessionCreated = client.CreateSparkSession(request);

                SparkStatementOptions sparkStatementRequest = new SparkStatementOptions
                {
                    Kind = SparkStatementLanguageType.Spark,
                    Code = @"print(""Hello world\n"")"
                };

                try
                {
                    SparkStatement statementCreated = client.CreateSparkStatement(sessionCreated.Id, sparkStatementRequest);
                }
                catch (Azure.RequestFailedException e)
                {
                    // !FAILURE: This exception
                    Console.WriteLine("Unexpected Exception:");
                    Console.WriteLine(e);
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            {
                Console.WriteLine("Test 3 - TestManagedPrivateEndpoints");

                var client = new ManagedPrivateEndpointsClient(workspace, new DefaultAzureCredential());

                string managedVnetName = "default";
                string managedPrivateEndpointName = $"myPrivateEndpoint-{Guid.NewGuid()}";
                string fakedStorageAccountName = "myStorageAccount";
                string privateLinkResourceId = $"/subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/myResourceGroup/providers/Microsoft.Storage/accounts/{fakedStorageAccountName}";
                string groupId = "blob";
                Console.WriteLine();
                Console.WriteLine(managedVnetName);
                Console.WriteLine(managedPrivateEndpointName);
                Console.WriteLine(privateLinkResourceId);
                Console.WriteLine(groupId);
                Console.WriteLine();
                ManagedPrivateEndpoint managedPrivateEndpoint = await client.CreateAsync(managedVnetName, managedPrivateEndpointName, new ManagedPrivateEndpoint
                {
                    Properties = new ManagedPrivateEndpointProperties
                    {
                        PrivateLinkResourceId = privateLinkResourceId,
                        GroupId = groupId
                    }
                });

                try
                {
                    await client.DeleteAsync(managedVnetName, managedPrivateEndpointName);
                }
                catch (Azure.RequestFailedException e)
                {
                    // !FAILURE: This exception
                    Console.WriteLine("Unexpected Exception:");
                    Console.WriteLine(e);
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Tests failed as expected...");
        }
    }
}
