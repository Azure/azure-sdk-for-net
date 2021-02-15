// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabricManagedClusters.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.ServiceFabricManagedClusters;
    using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using ServiceFabricManagedClusters.Tests.TestHelper;
    using Xunit;

    public class ServiceFabricManagedTestBase
    {
        protected string clusterIdFormat = "/subscriptions/{0}/resourcegroups/{1}/providers/Microsoft.ServiceFabric/managedClusters/{2}";

        protected ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(
            handlers: new RecordedDelegatingHandler()
            {
                StatusCodeToReturn = HttpStatusCode.OK,
                IsPassThrough = true
            });
        }

        protected ServiceFabricManagedClustersManagementClient GetServiceFabricMcClient(MockContext context)
        {
            return context.GetServiceClient<ServiceFabricManagedClustersManagementClient>(
            handlers: new RecordedDelegatingHandler()
            {
                StatusCodeToReturn = HttpStatusCode.OK,
                IsPassThrough = true
            });
        }

        protected ManagedCluster CreateManagedCluster(
            ResourceManagementClient resouceClient,
            ServiceFabricManagedClustersManagementClient serviceFabricMcClient,
            string rg,
            string rgLocation,
            string clusterName,
            string sku)
        {
            var newCluster = new ManagedCluster(
                location: rgLocation,
                sku: new Sku()
                {
                    Name = sku
                },
                dnsName: clusterName,
                adminPassword: "Password123!@#",
                adminUserName: "vmadmin",
                clientConnectionPort: 19000,
                httpGatewayConnectionPort: 19080,
                clients: new List<ClientCertificate>()
                {
                    new ClientCertificate()
                    {
                        IsAdmin = true,
                        Thumbprint = "123BDACDCDFB2C7B250192C6078E47D1E1DB119B"
                    }
                });

            resouceClient.ResourceGroups.CreateOrUpdate(
                rg,
                new ResourceGroup(rgLocation));

            var cluster = serviceFabricMcClient.ManagedClusters.CreateOrUpdate(rg, clusterName, newCluster);
            Assert.NotNull(cluster);
            return cluster;
        }

        protected NodeType CreateNodeType(
            ServiceFabricManagedClustersManagementClient serviceFabricMcClient,
            string rg,
            string clusterName,
            string nodeTypeName,
            bool isPrimary,
            int vmInstanceCount)
        {
            var newNodeType = new NodeType(
                isPrimary: isPrimary,
                vmInstanceCount: vmInstanceCount,
                dataDiskSizeGB: 100,
                vmSize: "Standard_D2",
                vmImagePublisher: "MicrosoftWindowsServer",
                vmImageOffer: "WindowsServer",
                vmImageSku: "2019-Datacenter",
                vmImageVersion: "latest"
                );

            var nodeType = serviceFabricMcClient.NodeTypes.CreateOrUpdate(rg, clusterName, nodeTypeName, newNodeType);
            Assert.NotNull(nodeType);
            return nodeType;
        }

        protected void WaitForClusterReadyState(
            ServiceFabricManagedClustersManagementClient serviceFabricMcClient,
            string resourceGroupName,
            string clusterName)
        {
            var timeout = TimeSpan.FromMinutes(10);
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            while (true)
            {
                var cluster = serviceFabricMcClient.ManagedClusters.Get(resourceGroupName, clusterName);
                if (cluster.ClusterState == "Ready")
                {
                    break;
                }

                if (stopWatch.Elapsed >= timeout)
                    throw new TimeoutException($"Timeout waiting for cluster to be ready. Current state: {cluster.ClusterState}");

                TestUtilities.Wait(TimeSpan.FromSeconds(30));
            }
        }
    }
}

