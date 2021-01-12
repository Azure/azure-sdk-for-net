// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints.Samples
{
    public partial class Sample1_HelloManangedPrivateEndpoint : SampleFixture
    {
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17455")]
        [Test]
        public void TestManagedPrivateEndpoint()
        {
            #region Snippet:CreateManagedPrivateClient
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;
            ManagedPrivateEndpointsClient client = new ManagedPrivateEndpointsClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential(includeInteractiveCredentials: true));
            #endregion

            #region Snippet:CreateManagedPrivateEndpoint
            string managedVnetName = "default";
            string managedPrivateEndpointName = "myPrivateEndpoint";
            string fakedStorageAccountName = "myStorageAccount";
            string privateLinkResourceId = $"/subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/myResourceGroup/providers/Microsoft.Storage/accounts/{fakedStorageAccountName}";
            string groupId = "blob";
            client.Create(managedVnetName, managedPrivateEndpointName, new ManagedPrivateEndpoint
            {
                Properties = new ManagedPrivateEndpointProperties
                {
                    PrivateLinkResourceId = privateLinkResourceId,
                    GroupId = groupId
                }
            });
            #endregion

            #region Snippet:ListManagedPrivateEndpoints
            List<ManagedPrivateEndpoint> privateEndpoints = client.List(managedVnetName).ToList();
            foreach (ManagedPrivateEndpoint privateEndpoint in privateEndpoints)
            {
                Console.WriteLine(privateEndpoint.Id);
            }
            #endregion

            #region Snippet:RetrieveManagedPrivateEndpoint
            ManagedPrivateEndpoint retrievedPrivateEndpoint = client.Get(managedVnetName, managedPrivateEndpointName);
            Console.WriteLine(retrievedPrivateEndpoint.Id);
            #endregion

            #region Snippet:DeleteManagedPrivateEndpoint
            client.Delete(managedVnetName, managedPrivateEndpointName);
            #endregion
        }
    }
}
