// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace StreamAnalytics.Tests
{
    public class PrivateEndpointTests : TestBase
    {
        [Fact]
        public async Task PrivateEndpointOperationsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string clusterName = TestUtilities.GenerateName("sj");
                string privateEndpointName = TestUtilities.GenerateName("testpe");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);
                string expectedClusterResourceId = TestHelper.GetClusterResourceId(
                   streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, clusterName);
                string expectedPrivateEndpointResourceId = TestHelper.GetPrivateEndpointResourceId(
                    streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, clusterName, privateEndpointName);
                string expectedPrivateLinkServiceId = "/subscriptions/113d0adc-1017-40e9-84ff-763f52896cc2/resourceGroups/sjrg5830/providers/Microsoft.EventHub/namespaces/testeventhub4asacluster";
                
                Cluster exceptedCluster = new Cluster()
                {
                    Location = TestHelper.DefaultLocation,
                    Sku = new ClusterSku()
                    {
                        Name = ClusterSkuName.Default,
                        Capacity = 36
                    }
                };

                // Create Resource Group
                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                PrivateLinkServiceConnection privateLinkServiceConnection = new PrivateLinkServiceConnection()
                {
                    PrivateLinkServiceId = expectedPrivateLinkServiceId,
                    GroupIds = new string[] { "namespace"}
                };

                PrivateEndpoint exceptedPrivateEndpoint = new PrivateEndpoint()
                {
                    Properties = new PrivateEndpointProperties()
                    {
                        ManualPrivateLinkServiceConnections = new List<PrivateLinkServiceConnection> { 
                            privateLinkServiceConnection 
                        }
                    }
                };

                // PUT cluster
                var putCluster = await streamAnalyticsManagementClient.Clusters.CreateOrUpdateWithHttpMessagesAsync(exceptedCluster, resourceGroupName, clusterName); ;

                // PUT privateendpoint
                var putPrivateEndpoint = await streamAnalyticsManagementClient.PrivateEndpoints.CreateOrUpdateWithHttpMessagesAsync(exceptedPrivateEndpoint, resourceGroupName, clusterName, privateEndpointName); ;

                // Null out because secrets are not returned in responses
                Assert.Equal(expectedClusterResourceId, putCluster.Body.Id);
                Assert.Equal(clusterName, putCluster.Body.Name);
                Assert.Equal(TestHelper.ClusterFullResourceType, putCluster.Body.Type);
                Assert.Equal("Succeeded", putCluster.Body.Properties.ProvisioningState);

                Assert.Equal(privateEndpointName, putPrivateEndpoint.Body.Name);
                Assert.Equal(expectedPrivateLinkServiceId, putPrivateEndpoint.Body.Properties.ManualPrivateLinkServiceConnections[0].PrivateLinkServiceId);
                Assert.Equal(TestHelper.PrivateEndpointFullResourceType, putPrivateEndpoint.Body.Type);
                Assert.Equal("PendingCreation", putPrivateEndpoint.Body.Properties.ManualPrivateLinkServiceConnections[0].PrivateLinkServiceConnectionState.Status);

                // Verify GET request returns expected private endpoint
                var getPrivateEndpoint = await streamAnalyticsManagementClient.PrivateEndpoints.GetWithHttpMessagesAsync(resourceGroupName, clusterName, privateEndpointName);
                Assert.Equal(putPrivateEndpoint.Body.Etag, getPrivateEndpoint.Body.Etag);

                // List private endpoints
                var listByCluster = streamAnalyticsManagementClient.PrivateEndpoints.ListByCluster(resourceGroupName, clusterName);
                Assert.Single(listByCluster);

                // Delete private endpoints
                streamAnalyticsManagementClient.PrivateEndpoints.Delete(resourceGroupName, clusterName, privateEndpointName);

                // Verify that list operation returns an empty list after deleting the job
                listByCluster = streamAnalyticsManagementClient.PrivateEndpoints.ListByCluster(resourceGroupName, clusterName);
                Assert.Empty(listByCluster);
            }
        }
    }
}
