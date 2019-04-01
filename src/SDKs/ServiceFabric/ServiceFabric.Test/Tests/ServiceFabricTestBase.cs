// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabric.Tests.Tests
{
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.ServiceFabric;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using System.Net;
    using Microsoft.Azure.Management.ServiceFabric.Models;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class ServiceFabricTestBase
    {
        protected string clusterIdFormat = "/subscriptions/{0}/resourcegroups/{1}/providers/Microsoft.ServiceFabric/clusters/{2}";

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

        protected IPage<GenericResource> GetAllServiceFabricClusterResources(
            MockContext context,
            ResourceGroup rg)
        {
            var resouceClient = GetResourceManagementClient(context);

            var query = new Microsoft.Rest.Azure.OData.ODataQuery<
                GenericResourceFilter>();
            query.SetFilter(
                f => f.ResourceType == "Microsoft.ServiceFabric/clusters");

            return resouceClient.ResourceGroups.ListResources(rg.Name, query);
        }

        protected Cluster CreateCluster(
            ResourceManagementClient resouceClient,
            ServiceFabricManagementClient serviceFabricClient,
            string rg,
            string rgLocation,
            string clusterName)
        {
            var clusterId = string.Format(
                clusterIdFormat,
                resouceClient.SubscriptionId,
                rg,
                clusterName);

            var newCluster = new Cluster(
                  location: rgLocation,
                  reliabilityLevel: "Silver",
                  managementEndpoint: "http://testCluster.southcentralus.cloudapp.azure.com:19080",
                  nodeTypes: new List<NodeTypeDescription>()
                   {
                      new NodeTypeDescription()
                      {
                          ApplicationPorts = new EndpointRangeDescription()
                          {
                              StartPort = 1000,
                              EndPort = 3000
                          },
                          DurabilityLevel = "Bronze",
                          EphemeralPorts = new EndpointRangeDescription()
                          {
                              StartPort = 4000,
                              EndPort = 6000
                          },
                          IsPrimary = true,
                          Name = "n1",
                          ClientConnectionEndpointPort = 19000,
                          Capacities =null,
                          HttpGatewayEndpointPort = 19080,
                          PlacementProperties = null,
                          VmInstanceCount = 5,
                          ReverseProxyEndpointPort = null
                      }
                   },
                  clusterId: clusterId,
                  name: clusterName,
                  type: "Microsoft.ServiceFabric/clusters",
                  vmImage: "Windows"
                  )
            {
            };

            resouceClient.ResourceGroups.CreateOrUpdate(
                rg,
                new ResourceGroup(rgLocation));

            var cluster = serviceFabricClient.Clusters.Create(rg, clusterName, newCluster);
            Assert.NotNull(cluster);

            cluster = serviceFabricClient.Clusters.Get(rg, clusterName);
            Assert.NotNull(cluster);
            return cluster;
        }
    }
}
