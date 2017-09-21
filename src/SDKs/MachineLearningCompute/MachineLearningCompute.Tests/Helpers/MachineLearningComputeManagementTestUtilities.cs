using Microsoft.Azure.Management.MachineLearningCompute;
using Microsoft.Azure.Management.MachineLearningCompute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MachineLearningCompute.Tests.Helpers
{
    public static class MachineLearningComputeManagementTestUtilities
    {
        public static MachineLearningComputeManagementClient GetMachineLearningComputeManagementClient(MockContext context)
        {
            MachineLearningComputeManagementClient client = context.GetServiceClient<MachineLearningComputeManagementClient>();

            return client;
        }

        public static ResourceGroup CreateResourceGroup(MockContext context, string resourceGroupName, string location)
        {
            ResourceManagementClient client = context.GetServiceClient<ResourceManagementClient>();

            return client.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = location
                });
        }

        public static OperationalizationCluster CreateCluster(MachineLearningComputeManagementClient client, string resourceGroupName, 
            string name, string location = "East US 2 EUAP", string description = "Test cluster", string clusterType = ClusterType.ACS, 
            string orchestratorType = OrchestratorType.Kubernetes)
        {
            var newCluster = new OperationalizationCluster
            {
                Location = location,
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

            return client.OperationalizationClusters.CreateOrUpdate(resourceGroupName, name, newCluster);
        }

        public static string GetServicePrincipalId()
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

        public static string GetServicePrincipalSecret()
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
