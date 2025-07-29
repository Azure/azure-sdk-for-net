// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridTopicPrivateEndpointTests : EventGridManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventGridTopicCollection _topicCollection;

        public EventGridTopicPrivateEndpointTests(bool isAsync) : base(isAsync) { }

        [SetUp]
        public async Task SetUpResourceGroupAndCollection()
        {
            // This test relies on the existence of the 'DevExpRg' resource group within the subscription, ensuring that system topics and related resources (such as Key Vault) are deployed within the same resource group for validation
            // Subscription: 5b4b650e-28b9-4790-b3ab-ddbd88d727c4 (Azure Event Grid SDK Subscription)
            // Use shared DevExpRg resource group
            _resourceGroup = await GetResourceGroupAsync(DefaultSubscription, "DevExpRg");
            _topicCollection = _resourceGroup.GetEventGridTopics();
        }

        [Test]
        public async Task TopicPrivateEndpointConnectionCollectionTest()
        {
            const string existingTopicName = "securedwebhooktopic";

            // Retrieve the Event Grid topic
            var getTopicResponse = await _topicCollection.GetAsync(existingTopicName);
            Assert.NotNull(getTopicResponse.Value, "Expected to find the Event Grid topic.");

            // Grab its Private Endpoint Connection collection
            var pecCollection = getTopicResponse.Value.GetEventGridTopicPrivateEndpointConnections();

            // List all PECs
            var privateEndpointConnections = await pecCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(privateEndpointConnections, "No Private Endpoint Connections found for the topic.");

            // Find the test PEC
            var testPec = privateEndpointConnections
                .FirstOrDefault(conn => conn.Data.Name.Contains("sdk-eventgrid-test-pec"));
            Assert.NotNull(testPec, "Expected to find a PEC named 'sdk-eventgrid-test-pec'.");

            // Verify key fields on the retrieved PEC
            Assert.NotNull(testPec.Data.PrivateEndpoint, "PEC must reference a Private Endpoint.");
            Assert.IsNotEmpty(testPec.Data.PrivateEndpoint.Id.ToString(), "PEC's PrivateEndpoint.Id should not be empty.");

            // Retrieve that one PEC directly
            var getSpecificPecResponse = await pecCollection.GetAsync(testPec.Data.Name);
            Assert.AreEqual(testPec.Data.Name, getSpecificPecResponse.Value.Data.Name, "Fetched PEC name mismatch.");

            // Check its ConnectionState details
            var connectionState = getSpecificPecResponse.Value.Data.ConnectionState;
            Assert.NotNull(connectionState, "ConnectionState should be populated on a PEC.");
            Assert.IsNotEmpty(connectionState.Status.ToString(), "ConnectionState.Status should not be empty.");
        }

        [Test]
        public async Task TopicPrivateEndpointConnectionResourceTest()
        {
            const string existingTopicName = "securedwebhooktopic";

            // Retrieve the topic
            var getTopicResponse = await _topicCollection.GetAsync(existingTopicName);
            Assert.NotNull(getTopicResponse.Value, "Expected to find the Event Grid topic.");

            // Grab its PEC collection
            var pecCollection = getTopicResponse.Value.GetEventGridTopicPrivateEndpointConnections();

            // List them
            var allPecs = await pecCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(allPecs, "Expected at least one Private Endpoint Connection.");

            // Pick the one we want to update
            var targetPec = allPecs
                .FirstOrDefault(conn => conn.Data.PrivateEndpoint.Id.ToString().Contains("sdk-eventgrid-test-pec"));
            Assert.NotNull(targetPec, "PEC 'sdk-eventgrid-test-pec' not found.");

            // Fetch it by name
            var getPecResponse = await pecCollection.GetAsync(targetPec.Data.Name);
            Assert.AreEqual(targetPec.Data.Name, getPecResponse.Value.Data.Name, "Fetched PEC name mismatch.");

            // Prepare the update payload (approve)
            var approvePayload = new EventGridPrivateEndpointConnectionData
            {
                ConnectionState = new EventGridPrivateEndpointConnectionState
                {
                    Status = EventGridPrivateEndpointPersistedConnectionStatus.Approved,
                    Description = "Re-approved via SDK test"
                }
            };

            // Send the update
            var updatePecResponse = await getPecResponse.Value.UpdateAsync(WaitUntil.Completed, approvePayload);
            Assert.AreEqual(targetPec.Data.Name, updatePecResponse.Value.Data.Name, "PEC name changed after update.");
            Assert.AreEqual(
                EventGridPrivateEndpointPersistedConnectionStatus.Approved,
                updatePecResponse.Value.Data.ConnectionState.Status,
                "PEC ConnectionState.Status was not set to Approved."
            );
            Assert.AreEqual(
                "Re-approved via SDK test",
                updatePecResponse.Value.Data.ConnectionState.Description,
                "PEC ConnectionState.Description did not match."
            );
        }
    }
}
