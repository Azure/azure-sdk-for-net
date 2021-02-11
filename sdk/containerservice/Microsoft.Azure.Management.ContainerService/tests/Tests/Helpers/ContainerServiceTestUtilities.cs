// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using ContainerService.Tests;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Resources.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Management.ContainerService;

namespace ContainerService.Tests
{
    public static class ContainerServiceTestUtilities
    {
        internal const string DnsPrefix = "aksdotnetsdk";
        internal const string ResourceGroupPrefix = "aks-dotnet-sdk-RG-";
        internal const string AgentPoolProfileName = "aksagent";
        internal const string VMSize = "Standard_D2s_v3";

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ResourceManagementClient resourceManagementClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return resourceManagementClient;
        }

        internal static ContainerServiceClient GetContainerServiceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ContainerServiceClient containerServiceClient = context.GetServiceClient<ContainerServiceClient>(handlers: handler);
            return containerServiceClient;
        }

        public static string GetLocationFromProvider(this ResourceManagementClient resourceManagementClient)
        {
            return "westus2";
        }

        public static void TryRegisterResourceGroup(this ResourceManagementClient resourceManagementClient, string location, string resourceGroupName)
        {
            resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location));
        }

        public static string TryGetResourceGroup(this ResourceManagementClient resourceManagementClient, string location)
        {
            const string DefaultResourceGroupName = "AKSTests";

            var resourceGroup = resourceManagementClient.ResourceGroups
                    .List().Where(group => string.IsNullOrWhiteSpace(location) || group.Location.Equals(location.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault(group => group.Name.Contains(DefaultResourceGroupName));

            return resourceGroup != null
                ? resourceGroup.Name
                : string.Empty;
        }

        /// <summary>
        /// CreateManagedCluster creates an AKS managed cluster
        /// </summary>
        /// <param name="resourceManagementClient"></param>
        /// <param name="containerServiceClient"></param>
        /// <param name="location"></param>
        /// <param name="clusterName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        internal async static Task<ManagedCluster> CreateManagedCluster(
            MockContext context,
            ResourceManagementClient resourceManagementClient,
            ContainerServiceClient containerServiceClient,
            string location,
            string clusterName,
            string resourceGroupName)
        {

            TestEnvironment testEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            string authClientId = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey];
            string authSecret = testEnvironment.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalSecretKey];

            var agentPoolProfiles = new List<ManagedClusterAgentPoolProfile>
            {
                new ManagedClusterAgentPoolProfile
                {
                    Name = AgentPoolProfileName,
                    VmSize = VMSize,
                    Count = 1,
                    Mode = "System"
                }
            };

            ManagedCluster desiredManagedCluster = new ManagedCluster
            {
                DnsPrefix = DnsPrefix,
                Location = location,
                AgentPoolProfiles = agentPoolProfiles,
                ServicePrincipalProfile = new ManagedClusterServicePrincipalProfile
                {
                    ClientId = authClientId,
                    Secret = authSecret
                }
            };

            var cluster = await containerServiceClient.ManagedClusters.CreateOrUpdateAsync(resourceGroupName, clusterName, desiredManagedCluster);

            return cluster;
        }
    }
}
