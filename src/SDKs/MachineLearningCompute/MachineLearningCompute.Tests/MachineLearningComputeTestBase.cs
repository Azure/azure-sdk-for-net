using Microsoft.Azure.Management.MachineLearningCompute;
using Microsoft.Azure.Management.MachineLearningCompute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachineLearningCompute.Tests
{
    public class MachineLearningComputeTestBase : TestBase
    {
        public const string PreferredLocation = "East US 2";
        public const string ProviderName = "Microsoft.MachineLearningCompute";
        public const string ResourceType = "operationalizationClusters";

        public MachineLearningComputeManagementClient Client { get; set; }
        public ResourceManagementClient ResourcesClient { get; set; }
        public string Location { get; set; }
        public string TestName { get; set; }
        public string ResourceGroupName { get; set; }
        public string ClusterName { get; set; }

        public MachineLearningComputeTestBase(MockContext context, string testName)
        {
            Client = context.GetServiceClient<MachineLearningComputeManagementClient>();
            ResourcesClient = context.GetServiceClient<ResourceManagementClient>();

            var provider = ResourcesClient.Providers.Get(ProviderName);
            var possibleLocations = provider.ResourceTypes.Where(
                (resourceType) =>
                {
                    if (resourceType.ResourceType == ResourceType)
                        return true;
                    else
                        return false;
                }
                ).First().Locations;

            Location = possibleLocations.Contains(PreferredLocation) ? PreferredLocation : possibleLocations.FirstOrDefault();
            TestName = testName;

            ResourceGroupName = TestUtilities.GenerateName(TestName);
            ClusterName = TestUtilities.GenerateName(TestName);
        }

        public ResourceGroup CreateResourceGroup()
        {
            return ResourcesClient.ResourceGroups.CreateOrUpdate(
                ResourceGroupName,
                new ResourceGroup
                {
                    Location = this.Location
                });
        }

        public OperationalizationCluster CreateCluster(string description = "Test cluster", string clusterType = ClusterType.ACS, 
            string orchestratorType = OrchestratorType.Kubernetes)
        {
            var newCluster = new OperationalizationCluster
            {
                Location = Location,
                ClusterType = clusterType,
                Description = description,
                ContainerService = new AcsClusterProperties
                {
                    OrchestratorType = orchestratorType,
                    OrchestratorProperties = new KubernetesClusterProperties
                    {
                        ServicePrincipal = new ServicePrincipalProperties
                        {
                            ClientId = GetServicePrincipalId(),
                            Secret = GetServicePrincipalSecret()
                        }
                    }
                }
            };

            return Client.OperationalizationClusters.CreateOrUpdate(ResourceGroupName, ClusterName, newCluster);
        }

        private string GetServicePrincipalId()
        {
            string servicePrincipalId = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey] = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.ServicePrincipalKey);
                servicePrincipalId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                servicePrincipalId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];
            }
            return servicePrincipalId;
        }

        private string GetServicePrincipalSecret()
        {
            string servicePrincipalSecret = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                servicePrincipalSecret = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.ServicePrincipalSecretKey);
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                servicePrincipalSecret = "abcde";
            }
            return servicePrincipalSecret;
        }
    }
}
