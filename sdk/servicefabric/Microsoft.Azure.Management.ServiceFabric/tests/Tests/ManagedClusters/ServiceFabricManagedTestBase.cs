// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabric.Tests.Managed
{
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.ServiceFabric;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using System.Net;
    using Microsoft.Azure.Management.ServiceFabric.Models;
    using System.Collections.Generic;
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

        protected ServiceFabricManagementClient GetServiceFabricClient(MockContext context)
        {
            return context.GetServiceClient<ServiceFabricManagementClient>(
            handlers: new RecordedDelegatingHandler()
            {
                StatusCodeToReturn = HttpStatusCode.OK,
                IsPassThrough = true
            });
        }

        protected ManagedCluster CreateManagedCluster(
            ResourceManagementClient resouceClient,
            ServiceFabricManagementClient serviceFabricClient,
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

            var cluster = serviceFabricClient.ManagedClusters.CreateOrUpdate(rg, clusterName, newCluster);
            Assert.NotNull(cluster);
            return cluster;
        }

        protected NodeType CreateNodeType(
            ServiceFabricManagementClient serviceFabricClient,
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

            var nodeType = serviceFabricClient.NodeTypes.CreateOrUpdate(rg, clusterName, nodeTypeName, newNodeType);
            Assert.NotNull(nodeType);
            return nodeType;
        }
    }
}

