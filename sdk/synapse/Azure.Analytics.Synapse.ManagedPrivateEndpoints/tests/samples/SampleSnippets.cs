// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints.Samples
{
    public partial class Snippets : SampleFixture
    {
#pragma warning disable IDE1006 // Naming Styles
        private ManagedPrivateEndpointsClient client;
#pragma warning restore IDE1006 // Naming Styles

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            #region Snippet:CreateClient
            // Create a new monitoring client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            ManagedPrivateEndpointsClient client = new ManagedPrivateEndpointsClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential(includeInteractiveCredentials: true));
            #endregion

            this.client = client;
        }

        [Test]
        public void TestManagedPrivateEndpoints()
        {
            #region Snippet:GetSparkJobList
            //string workspaceUrl = TestEnvironment.WorkspaceUrl;
            //string managedVnetName = "default";
            //string managedPrivateEndpointName = "myPrivateEndpoint" + new Random().Next(1000, 10000);
            //string privateLinkResourceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Storage/accounts/{TestEnvironment.StorageAccountName}";
            //string groupId = "blob";
            //ManagedPrivateEndpoint managedPrivateEndpoint =  client.Create(managedVnetName, managedPrivateEndpointName, new ManagedPrivateEndpointProperties
            //{
            //    PrivateLinkResourceId = privateLinkResourceId,
            //    GroupId = groupId
            //});
            //Assert.NotNull(managedPrivateEndpoint);
            //Assert.AreEqual(managedPrivateEndpointName, managedPrivateEndpoint.Name);
            //Assert.AreEqual(privateLinkResourceId, managedPrivateEndpoint.Properties.PrivateLinkResourceId);
            //Assert.AreEqual(groupId, managedPrivateEndpoint.Properties.GroupId);
            ////SparkJobListViewResponse sparkJobList = client.GetSparkJobList();
            #endregion
        }
    }
}
