namespace CosmosDB.Tests.ScenarioTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using global::CosmosDB.Tests;
    using Microsoft.Azure.Management.CosmosDB;
    using Microsoft.Azure.Management.CosmosDB.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class ManagedCassandraResourcesOperationsTests
    {
        private const string VnetDeploymentName = "vnet-deployment";

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
                string clusterName = TestUtilities.GenerateName("managedcluster");
                string dcName = TestUtilities.GenerateName("managedDC");

                string subnetId = CreateVirtualNetwork(resourcesClient, resourceGroupName);

                var clusterProperties = new ClusterResourceProperties
                {
                    DelegatedManagementSubnetId = subnetId,
                    InitialCassandraAdminPassword = "password"
                };
                var clusterPutResource = new ClusterResource
                {
                    Location = "East US 2",
                    Properties = clusterProperties
                };
                ClusterResource clusterResource =
                    cosmosDBManagementClient.CassandraClusters.CreateUpdateWithHttpMessagesAsync(
                    resourceGroupName: resourceGroupName, clusterName: clusterName, body: clusterPutResource)
                    .GetAwaiter().GetResult().Body;

                Assert.Equal(subnetId, clusterResource.Properties.DelegatedManagementSubnetId);
                Assert.Null(clusterResource.Properties.InitialCassandraAdminPassword);
                Assert.Equal("Cassandra", clusterResource.Properties.AuthenticationMethod);
                Assert.Equal("Succeeded", clusterResource.Properties.ProvisioningState);
                Assert.Null(clusterResource.Properties.ExternalSeedNodes);

                clusterPutResource.Properties.ExternalSeedNodes = new List<SeedNode>
                {
                    new SeedNode {IpAddress = "192.168.12.1"}
                };
                ClusterResource clusterResource2 = cosmosDBManagementClient.CassandraClusters
                    .CreateUpdateWithHttpMessagesAsync(resourceGroupName: resourceGroupName, clusterName: clusterName,
                        body: clusterPutResource).GetAwaiter().GetResult().Body;

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
                DataCenterResource dcResource = cosmosDBManagementClient.CassandraDataCenters
                    .CreateUpdateWithHttpMessagesAsync(resourceGroupName, clusterName, dcName, dataCenterPutResource)
                    .GetAwaiter().GetResult().Body;

                Assert.Equal("East US 2", dcResource.Properties.DataCenterLocation);
                Assert.Equal(subnetId, dcResource.Properties.DelegatedSubnetId);
                Assert.Equal(3, dcResource.Properties.NodeCount);
                Assert.Equal(3, dcResource.Properties.SeedNodes.Count);

                // TODO: Update data center
                // TODO: Verify data center

                // TODO: Delete data center
                // TODO: Delete cluster

                cosmosDBManagementClient.CassandraClusters.DeleteWithHttpMessagesAsync(
                    resourceGroupName, clusterName);
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
                Template = JObject.Parse(File.ReadAllText(@"TestData\ManagedCassandraVnetTemplate.json")),
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
