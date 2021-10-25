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

    [Collection("TestCollection")]
    public class ManagedCassandraResourcesOperationsTests
    {
        public readonly TestFixture fixture;
        private ITestOutputHelper output;

        public ManagedCassandraResourcesOperationsTests(TestFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.output = output;
        }

        [Fact]
        public void ManagedCassandraCRUDTests()
        {
            var clusterClient = this.fixture.CosmosDBManagementClient.CassandraClusters;
            var dcClient = this.fixture.CosmosDBManagementClient.CassandraDataCenters;

            string clusterName = TestUtilities.GenerateName("managedcluster");
            string dcName = TestUtilities.GenerateName("managedDC");
            this.output.WriteLine($"Creating cluster {clusterName} in resource group {this.fixture.ResourceGroupName}.");

            string subnetId = CreateVirtualNetwork();
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
                Location = this.fixture.Location,
                Properties = clusterProperties
            };
            this.output.WriteLine($"Cluster create request body:");
            this.output.WriteLine(JsonConvert.SerializeObject(clusterPutResource, Formatting.Indented));

            ClusterResource clusterResource = clusterClient
                .CreateUpdateWithHttpMessagesAsync(resourceGroupName: this.fixture.ResourceGroupName,
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

            ClusterResource clusterResource2 = clusterClient
                .CreateUpdateWithHttpMessagesAsync(resourceGroupName: this.fixture.ResourceGroupName,
                    clusterName: clusterName, body: clusterPutResource).GetAwaiter().GetResult().Body;

            this.output.WriteLine("Response:");
            this.output.WriteLine(JsonConvert.SerializeObject(clusterResource2, Formatting.Indented));

            Assert.Equal(clusterName, clusterResource2.Name);
            Assert.Equal(this.fixture.Location.ToLower(), clusterResource2.Location.ToLower());
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
                    DataCenterLocation = this.fixture.Location,
                    DelegatedSubnetId = subnetId,
                    NodeCount = 3,
                    Sku = "Standard_E8s_v4"
                }
            };
            this.output.WriteLine($"Creating data center {dcName}. Put request:");
            this.output.WriteLine(JsonConvert.SerializeObject(dataCenterPutResource, Formatting.Indented));
            DataCenterResource dcResource = dcClient
                .CreateUpdateWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName, dcName,
                    dataCenterPutResource).GetAwaiter().GetResult().Body;
            this.output.WriteLine("Response:");
            this.output.WriteLine(JsonConvert.SerializeObject(dcResource, Formatting.Indented));

            Assert.Equal(this.fixture.Location.ToLower(), dcResource.Properties.DataCenterLocation.ToLower());
            Assert.Equal(subnetId, dcResource.Properties.DelegatedSubnetId);
            Assert.Equal(3, dcResource.Properties.NodeCount);
            Assert.Equal(3, dcResource.Properties.SeedNodes.Count);

            clusterClient.DeallocateWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName).GetAwaiter().GetResult();
            ClusterResource clusterResource3 = clusterClient.GetAsync(this.fixture.ResourceGroupName, clusterName).GetAwaiter().GetResult();
            Assert.True(clusterResource3.Properties.Deallocated);

            clusterClient.StartWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName).GetAwaiter().GetResult();
            ClusterResource clusterResource4 = clusterClient.GetAsync(this.fixture.ResourceGroupName, clusterName).GetAwaiter().GetResult();
            Assert.True(clusterResource4.Properties.Deallocated);

            CommandOutput commandOutput = clusterClient.BeginInvokeCommandWithHttpMessagesAsync(
                this.fixture.ResourceGroupName,
                clusterName,
                new CommandPostBody
                {
                    Host = dcResource.Properties.SeedNodes[0].IpAddress,
                    Command = "nodetool",
                    Arguments = new Dictionary<string, string>
                    {
                        { "status", "" }
                    }
                }
            ).GetAwaiter().GetResult().Body;
            Assert.NotEmpty(commandOutput.CommandOutputProperty);

            this.output.WriteLine($"Deleting data center {dcName}.");
            dcClient
                .DeleteWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName, dcName).GetAwaiter().GetResult();

            this.output.WriteLine($"Deleting cluster {clusterName}.");
            clusterClient
                .DeleteWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName).GetAwaiter().GetResult();

            this.output.WriteLine("Deleting deployment of vnets.");
            clusterClient
                .DeleteWithHttpMessagesAsync(this.fixture.ResourceGroupName, clusterName).GetAwaiter().GetResult();
        }


        public string CreateVirtualNetwork()
        {
            var vnetName = TestUtilities.GenerateName("CosmosDBVirtualNetwork");

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
