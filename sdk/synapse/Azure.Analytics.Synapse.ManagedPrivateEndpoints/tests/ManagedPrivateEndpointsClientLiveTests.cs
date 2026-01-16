// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints;
using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="ManagedPrivateEndpointsClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class ManagedPrivateEndpointsClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public ManagedPrivateEndpointsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private ManagedPrivateEndpointsClient CreateClient()
        {
            return InstrumentClient(new ManagedPrivateEndpointsClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ManagedPrivateEndpointsClientOptions())
            ));
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17455")]
        [RecordedTest]
        public async Task TestManagedPrivateEndpoints()
        {
            ManagedPrivateEndpointsClient client = CreateClient();

            // Create a managed private endpoint
            string managedVnetName = "default";
            string managedPrivateEndpointName = Recording.GenerateId("myPrivateEndpoint", 21);
            string fakedStorageAccountName = Recording.GenerateId("myStorageAccount", 21);
            string privateLinkResourceId = $"/subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/myResourceGroup/providers/Microsoft.Storage/accounts/{fakedStorageAccountName}";
            string groupId = "blob";
            ManagedPrivateEndpoint managedPrivateEndpoint = await client.CreateAsync("default", managedVnetName, new ManagedPrivateEndpoint
            {
                Properties = new ManagedPrivateEndpointProperties
                {
                    PrivateLinkResourceId = privateLinkResourceId,
                    GroupId = groupId
                }
            });
            Assert.That(managedPrivateEndpoint, Is.Not.Null);
            Assert.That(managedPrivateEndpoint.Name, Is.EqualTo(managedPrivateEndpointName));
            Assert.That(managedPrivateEndpoint.Properties.PrivateLinkResourceId, Is.EqualTo(privateLinkResourceId));
            Assert.That(managedPrivateEndpoint.Properties.GroupId, Is.EqualTo(groupId));

            // List managed private endpoints
            List<ManagedPrivateEndpoint> privateEndpoints = await client.ListAsync(managedVnetName).ToEnumerableAsync();
            Assert.That(privateEndpoints, Is.Not.Null);
            Assert.That(privateEndpoints, Is.Not.Empty);
            Assert.That(privateEndpoints.Any(pe => pe.Name == managedPrivateEndpointName), Is.True);

            // Get managed private endpoint
            ManagedPrivateEndpoint privateEndpoint = await client.GetAsync(managedVnetName, managedPrivateEndpointName);
            Assert.That(privateEndpoint.Name, Is.EqualTo(managedPrivateEndpointName));

            // Delete managed private endpoint
            await client.DeleteAsync(managedVnetName, managedPrivateEndpointName);
            privateEndpoints = await client.ListAsync(managedVnetName).ToEnumerableAsync();
            Assert.That(privateEndpoints.Any(pe => pe.Name == managedPrivateEndpointName), Is.False);
        }
    }
}
