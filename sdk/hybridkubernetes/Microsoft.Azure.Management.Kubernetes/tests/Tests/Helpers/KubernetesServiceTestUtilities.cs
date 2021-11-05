// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using KubernetesService.Tests;
using Microsoft.Kubernetes.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Resources.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Kubernetes;

namespace KubernetesService.Tests
{
    public static class KubernetesServiceTestUtilities
    {
        internal const string ResourceGroupPrefix = "k8s-dotnet-sdk-RG-";

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ResourceManagementClient resourceManagementClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return resourceManagementClient;
        }

        internal static ConnectedKubernetesClient GetKubernetesServiceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ConnectedKubernetesClient kubernetesServiceClient = context.GetServiceClient<ConnectedKubernetesClient>(handlers: handler);
            return kubernetesServiceClient;
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
            const string DefaultResourceGroupName = "K8sTests";

            var resourceGroup = resourceManagementClient.ResourceGroups
                    .List().Where(group => string.IsNullOrWhiteSpace(location) || group.Location.Equals(location.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault(group => group.Name.Contains(DefaultResourceGroupName));

            return resourceGroup != null
                ? resourceGroup.Name
                : string.Empty;
        }

        /// <summary>
        /// CreateConnectedCluster creates a connected cluster
        /// </summary>
        /// <param name="resourceManagementClient"></param>
        /// <param name="kubernetesServiceClient"></param>
        /// <param name="location"></param>
        /// <param name="clusterName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        internal async static Task<ConnectedCluster> CreateConnectedCluster(
            MockContext context,
            ResourceManagementClient resourceManagementClient,
            ConnectedKubernetesClient kubernetesServiceClient,
            string location,
            string clusterName,
            string resourceGroupName)
        {

            TestEnvironment testEnvironment = TestEnvironmentFactory.GetTestEnvironment();

            var connectedClusterIdentity = new ConnectedClusterIdentity();
            connectedClusterIdentity.Type = ResourceIdentityType.SystemAssigned;

            ConnectedCluster desiredConnectedCluster = new ConnectedCluster
            {
                Location = location,
                Identity = connectedClusterIdentity,
                AgentPublicKeyCertificate = "testpubkey",
                Distribution = "generic",
                Infrastructure = "generic"
            };

            var cluster = await kubernetesServiceClient.ConnectedCluster.CreateAsync(resourceGroupName, clusterName, desiredConnectedCluster);

            return cluster;
        }
    }
}
