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
    public class ClusterTests : TestBase
    {
        [Fact]
        public async Task ClusterOperationsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string clusterName = TestUtilities.GenerateName("sj");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);
                string expectedClusterResourceId = TestHelper.GetClusterResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, clusterName);

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

                // PUT cluster
                var putResponse = await streamAnalyticsManagementClient.Clusters.CreateOrUpdateWithHttpMessagesAsync(exceptedCluster, resourceGroupName, clusterName); ;

                // Null out because secrets are not returned in responses
                Assert.Equal(expectedClusterResourceId, putResponse.Body.Id);
                Assert.Equal(clusterName, putResponse.Body.Name);
                Assert.Equal(TestHelper.ClusterFullResourceType, putResponse.Body.Type);
                Assert.Equal("Succeeded", putResponse.Body.Properties.ProvisioningState);

                // Verify GET request returns expected job
                var getResponse = await streamAnalyticsManagementClient.Clusters.GetWithHttpMessagesAsync(resourceGroupName, clusterName);
                Assert.Equal(putResponse.Response.Headers.ETag, getResponse.Response.Headers.ETag);

                // List cluster
                var listByRgResponse = streamAnalyticsManagementClient.Clusters.ListByResourceGroup(resourceGroupName);
                Assert.Single(listByRgResponse);

                // Delete cluster
                streamAnalyticsManagementClient.Clusters.Delete(resourceGroupName, clusterName);

                // Verify that list operation returns an empty list after deleting the job
                listByRgResponse = streamAnalyticsManagementClient.Clusters.ListByResourceGroup(resourceGroupName);
                Assert.Empty(listByRgResponse);
            }
        }
    }
}
