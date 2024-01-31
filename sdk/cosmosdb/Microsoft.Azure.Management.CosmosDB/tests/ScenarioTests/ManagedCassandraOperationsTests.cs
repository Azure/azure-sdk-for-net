namespace CosmosDB.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
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

    public class ManagedCassandraResourcesOperationsTests : IClassFixture<TestFixture>
    {
        public readonly TestFixture fixture;
        private ITestOutputHelper output;

        public ManagedCassandraResourcesOperationsTests(TestFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.fixture.Location = "central us";
            this.output = output;
        }

        [Fact(Skip = "True")]
        public async Task ManagedCassandraCRUDTests()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var location = this.fixture.Location;

                fixture.Init(context);
                var clusterClient = this.fixture.CosmosDBManagementClient.CassandraClusters;
                var dcClient = this.fixture.CosmosDBManagementClient.CassandraDataCenters;

                string clusterName = TestUtilities.GenerateName("managedcluster");
                string dcName = TestUtilities.GenerateName("managedDC");
                this.output.WriteLine($"Creating cluster {clusterName} in resource group {this.fixture.ResourceGroupName}.");

                string subnetId = CreateVirtualNetwork(location);
                this.output.WriteLine($"Created subnet {subnetId}.");

                var clusterProperties = new ClusterResourceProperties
                {
                    DelegatedManagementSubnetId = subnetId,
                    InitialCassandraAdminPassword = "password",
                    ExternalSeedNodes = new List<SeedNode>
                {
                    new SeedNode { IpAddress = "10.0.1.1" }
                }
                };
                var clusterPutResource = new ClusterResource
                {
                    Location = location,
                    Properties = clusterProperties
                };
                this.output.WriteLine($"Cluster create request body:");
                this.output.WriteLine(JsonConvert.SerializeObject(clusterPutResource, Formatting.Indented));

                ClusterResource clusterResource = (await clusterClient
                    .CreateUpdateWithHttpMessagesAsync(resourceGroupName: this.fixture.ResourceGroupName,
                        clusterName: clusterName, body: clusterPutResource)).Body;

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

                ClusterResource clusterResource2 = (await clusterClient
                    .CreateUpdateWithHttpMessagesAsync(resourceGroupName: this.fixture.ResourceGroupName,
                        clusterName: clusterName, body: clusterPutResource)).Body;

                this.output.WriteLine("Response:");
                this.output.WriteLine(JsonConvert.SerializeObject(clusterResource2, Formatting.Indented));

                Assert.Equal(clusterName, clusterResource2.Name);
                Assert.Equal(location.ToLower(), clusterResource2.Location.ToLower());
                Assert.Equal(subnetId, clusterResource2.Properties.DelegatedManagementSubnetId);
                Assert.Null(clusterResource2.Properties.InitialCassandraAdminPassword);
                Assert.Equal("Cassandra", clusterResource2.Properties.AuthenticationMethod);
                Assert.Equal("3.11", clusterResource2.Properties.CassandraVersion);
                Assert.Equal("Succeeded", clusterResource2.Properties.ProvisioningState);
                Assert.NotNull(clusterResource2.Properties.ExternalSeedNodes);
                Assert.NotEmpty(clusterResource2.Properties.ExternalSeedNodes);
                Assert.False(clusterResource2.Properties.Deallocated);

                DataCenterResource dataCenterPutResource = new DataCenterResource
                {
                    Properties = new DataCenterResourceProperties
                    {
                        DataCenterLocation = location,
                        DelegatedSubnetId = subnetId,
                        NodeCount = 3
                    }
                };
                this.output.WriteLine($"Creating data center {dcName}. Put request:");
                this.output.WriteLine(JsonConvert.SerializeObject(dataCenterPutResource, Formatting.Indented));
                DataCenterResource dcResource = (await dcClient
                    .CreateUpdateWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName, dcName,
                        dataCenterPutResource)).Body;
                this.output.WriteLine("Response:");
                this.output.WriteLine(JsonConvert.SerializeObject(dcResource, Formatting.Indented));

                Assert.Equal(location.ToLower(), dcResource.Properties.DataCenterLocation.ToLower());
                Assert.Equal(subnetId, dcResource.Properties.DelegatedSubnetId);
                Assert.Equal(3, dcResource.Properties.NodeCount);
                Assert.Equal(3, dcResource.Properties.SeedNodes.Count);

                await clusterClient.DeallocateWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName);
                ClusterResource clusterResource3 = await clusterClient.GetAsync(this.fixture.ResourceGroupName, clusterName);
                Assert.True(clusterResource3.Properties.Deallocated);

                await clusterClient.StartWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName);
                ClusterResource clusterResource4 = await clusterClient.GetAsync(this.fixture.ResourceGroupName, clusterName);
                Assert.False(clusterResource4.Properties.Deallocated);

                this.output.WriteLine($"Deleting data center {dcName}.");
                await dcClient.DeleteWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName, dcName);

                this.output.WriteLine($"Deleting cluster {clusterName}.");
                await clusterClient.DeleteWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName);
            }
        }


        public string CreateVirtualNetwork(string location)
        {
            var vnetName = TestUtilities.GenerateName("CosmosDBVirtualNetwork");

            var templateParameters = new Dictionary<string, Dictionary<string, object>>
            {
                {"vnetName", new Dictionary<string, object> {{"value", vnetName}}},
                {"location", new Dictionary<string, object> {{"value", location}}}
            };

            var deploymentProperties = new DeploymentProperties
            {
                Template = JObject.Parse(File.ReadAllText("TestData/ManagedCassandraVnetTemplate.azrm.json")),
                Parameters = templateParameters,
                Mode = DeploymentMode.Incremental
            };
            var deploymentModel = new Deployment(deploymentProperties);

            var deployment = this.fixture.ResourceManagementClient.Deployments.CreateOrUpdate(
                this.fixture.ResourceGroupName,
                TestUtilities.GenerateName("vnet-deployment"),
                deploymentModel
            );

            var outputs = (JObject)deployment.Properties.Outputs;
            var subnetId = ((JObject)outputs.GetValue("subnetId")).GetValue("value").ToString();
            return subnetId;
        }
    }
}
