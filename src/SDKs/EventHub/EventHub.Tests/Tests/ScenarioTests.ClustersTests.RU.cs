// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void ClusterGetUpdate()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = "EventHubClusterRG";
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var clusterName = "FirstEverEHCluster";

                // Get Cluster by Resourcegroup 
                var ListByResourceGroupResponse = this.EventHubManagementClient.Clusters.ListByResourceGroup(resourceGroup);
                Assert.NotEmpty(ListByResourceGroupResponse);
                Assert.Contains(ListByResourceGroupResponse, cl => cl.Name.Equals(clusterName));
                

                //Get particular cluster
                var GetclusterResponse = this.EventHubManagementClient.Clusters.Get(resourceGroup, clusterName);
                Assert.True(GetclusterResponse != null);
                Assert.Equal(clusterName, GetclusterResponse.Name);

                // Get all the tags and remove 

                Dictionary<string, string> tagstoRemove = new Dictionary<string, string>(GetclusterResponse.Tags);

                foreach (string strKey in tagstoRemove.Keys)
                {
                    GetclusterResponse.Tags.Remove(strKey);
                }
                
                //add the Tags the cluster 
                GetclusterResponse.Tags.Add(TestUtilities.GenerateName("Tags_"), TestUtilities.GenerateName("Value"));
                GetclusterResponse.Tags.Add(TestUtilities.GenerateName("Tags_"), TestUtilities.GenerateName("Value"));
                
                //update the Cluster
                var PatchclusterResponse = this.EventHubManagementClient.Clusters.Patch(resourceGroup, clusterName, GetclusterResponse);
                Assert.Equal(GetclusterResponse.Tags.Count, PatchclusterResponse.Tags.Count);


            }
        }
    }
}
