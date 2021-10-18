namespace CosmosDB.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading;
    using global::CosmosDB.Tests;
    using Microsoft.Azure.Management.CosmosDB;
    using Microsoft.Azure.Management.CosmosDB.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;
    using Xunit.Abstractions;

    public class ManagedCassandraResourcesOperationsTests
    {
        private const string VnetDeploymentName = "vnet-deployment";

        private ITestOutputHelper output;

        public ManagedCassandraResourcesOperationsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ManagedCassandraCRUDTests()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};
            var handler2 = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                CosmosDBManagementClient cosmosDBManagementClient =
                    CosmosDBTestUtilities.GetCosmosDBClient(context, handler);
                ResourceManagementClient resourcesClient =
                    CosmosDBTestUtilities.GetResourceManagementClient(context, handler2);

                string resourceGroupName = CosmosDBTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    string clusterName = TestUtilities.GenerateName("managedcluster");
                    string dcName = TestUtilities.GenerateName("managedDC");
                    this.output.WriteLine($"Creating cluster {clusterName} in resource group {resourceGroupName}.");

                    string subnetId = CreateVirtualNetwork(resourcesClient, resourceGroupName);
                    this.output.WriteLine($"Created subnet {subnetId}.");

                    var clusterProperties = new ClusterResourceProperties
                    {
                        DelegatedManagementSubnetId = subnetId, InitialCassandraAdminPassword = "password",
                        ExternalSeedNodes = new List<SeedNode>
                        {
                            new SeedNode { IpAddress = "10.0.1.1" }
                        }
                    };
                    var clusterPutResource = new ClusterResource
                    {
                        Location = "East US 2", Properties = clusterProperties
                    };
                    this.output.WriteLine($"Cluster create request body:");
                    this.output.WriteLine(JsonConvert.SerializeObject(clusterPutResource, Formatting.Indented));

                    ClusterResource clusterResource = cosmosDBManagementClient.CassandraClusters
                        .CreateUpdateWithHttpMessagesAsync(resourceGroupName: resourceGroupName,
                            clusterName: clusterName, body: clusterPutResource).GetAwaiter().GetResult().Body;

                    this.output.WriteLine($"Cluster create response:");
                    this.output.WriteLine(JsonConvert.SerializeObject(clusterResource, Formatting.Indented));

                    Assert.Equal(subnetId, clusterResource.Properties.DelegatedManagementSubnetId);
                    Assert.Null(clusterResource.Properties.InitialCassandraAdminPassword);
                    Assert.Equal("Cassandra", clusterResource.Properties.AuthenticationMethod);
                    Assert.Equal("Succeeded", clusterResource.Properties.ProvisioningState);
                    Assert.NotNull(clusterResource.Properties.ExternalSeedNodes);
                    Assert.Equal(1, clusterResource.Properties.ExternalSeedNodes.Count);
                    Assert.Equal("10.0.1.1", clusterResource.Properties.ExternalSeedNodes[0].IpAddress);

                    clusterPutResource.Properties.ExternalSeedNodes = new List<SeedNode>
                    {
                        new SeedNode {IpAddress = "192.168.12.1"}
                    };
                    this.output.WriteLine("");
                    this.output.WriteLine("Updating cluster. Put body:");
                    this.output.WriteLine(JsonConvert.SerializeObject(clusterPutResource, Formatting.Indented));

                    ClusterResource clusterResource2 = cosmosDBManagementClient.CassandraClusters
                        .CreateUpdateWithHttpMessagesAsync(resourceGroupName: resourceGroupName,
                            clusterName: clusterName, body: clusterPutResource).GetAwaiter().GetResult().Body;

                    this.output.WriteLine("Response:");
                    this.output.WriteLine(JsonConvert.SerializeObject(clusterResource2, Formatting.Indented));

                    Assert.Equal(clusterName, clusterResource2.Name);
                    Assert.Equal("East US 2", clusterResource2.Location);
                    Assert.Equal(subnetId, clusterResource2.Properties.DelegatedManagementSubnetId);
                    Assert.Null(clusterResource2.Properties.InitialCassandraAdminPassword);
                    Assert.Equal("Cassandra", clusterResource2.Properties.AuthenticationMethod);
                    Assert.Null(clusterResource2.Properties.CassandraVersion);
                    Assert.Equal("Succeeded", clusterResource2.Properties.ProvisioningState);
                    Assert.NotNull(clusterResource2.Properties.ExternalSeedNodes);
                    Assert.NotEmpty(clusterResource2.Properties.ExternalSeedNodes);

                    DataCenterResource dataCenterPutResource = new DataCenterResource
                    {
                        Properties = new DataCenterResourceProperties
                        {
                            DataCenterLocation = "East US 2", DelegatedSubnetId = subnetId, NodeCount = 3,
                        }
                    };
                    this.output.WriteLine($"Creating data center {dcName}. Put request:");
                    this.output.WriteLine(JsonConvert.SerializeObject(dataCenterPutResource, Formatting.Indented));
                    DataCenterResource dcResource = cosmosDBManagementClient.CassandraDataCenters
                        .CreateUpdateWithHttpMessagesAsync(resourceGroupName, clusterName, dcName,
                            dataCenterPutResource).GetAwaiter().GetResult().Body;
                    this.output.WriteLine("Response:");
                    this.output.WriteLine(JsonConvert.SerializeObject(dcResource, Formatting.Indented));

                    Assert.Equal("East US 2", dcResource.Properties.DataCenterLocation);
                    Assert.Equal(subnetId, dcResource.Properties.DelegatedSubnetId);
                    Assert.Equal(3, dcResource.Properties.NodeCount);
                    Assert.Equal(3, dcResource.Properties.SeedNodes.Count);

                    this.output.WriteLine($"Deleting data center {dcName}.");
                    cosmosDBManagementClient.CassandraDataCenters
                        .DeleteWithHttpMessagesAsync(resourceGroupName, clusterName, dcName).GetAwaiter().GetResult();

                    this.output.WriteLine($"Deleting cluster {clusterName}.");
                    cosmosDBManagementClient.CassandraClusters
                        .DeleteWithHttpMessagesAsync(resourceGroupName, clusterName).GetAwaiter().GetResult();

                    this.output.WriteLine("Deleting deployment of vnets.");
                    cosmosDBManagementClient.CassandraClusters
                        .DeleteWithHttpMessagesAsync(resourceGroupName, clusterName).GetAwaiter().GetResult();
                }
                finally
                {
                    this.output.WriteLine("Deleting resource group.");
                    resourcesClient.Deployments.Delete(resourceGroupName,
                        ManagedCassandraResourcesOperationsTests.VnetDeploymentName);
                    resourcesClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        public static string CreateVirtualNetwork(ResourceManagementClient client, string resourceGroupName)
        {
            const string testPrefix = "CosmosDBVirtualNetwork";
            var vnetName = TestUtilities.GenerateName(testPrefix);

            var templateParameters = new Dictionary<string, Dictionary<string, object>>
            {
                {"vnetName", new Dictionary<string, object> {{"value", vnetName}}}
            };

            var deploymentProperties = new DeploymentProperties
            {
                Template = JObject.Parse(File.ReadAllText("TestData/ManagedCassandraVnetTemplate.azrm.json")),
                Parameters = templateParameters,
                Mode = DeploymentMode.Incremental
            };
            var deploymentModel = new Deployment(deploymentProperties);

            var deployment = client.Deployments.CreateOrUpdate(resourceGroupName,
                ManagedCassandraResourcesOperationsTests.VnetDeploymentName, deploymentModel);

            var outputs = (JObject) deployment.Properties.Outputs;
            var subnetId = ((JObject) outputs.GetValue("subnetId")).GetValue("value").ToString();
            return subnetId;
        }
    }
}
