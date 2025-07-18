// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.EventGrid;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests.Scenario
{
    internal class ExtensionTopicTests : EventGridManagementTestBase
    {
        public ExtensionTopicTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task GetAsyncThrowsRequestFailedException()
        {
            // Arrange
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "sdk-eventgrid-test-rg";
            string scope = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";
            var resourceId = ExtensionTopicResource.CreateResourceIdentifier(scope);
            var armClient = new ArmClient(new DefaultAzureCredential(), subscriptionId);
            var extensionTopicResource = new ExtensionTopicResource(armClient, resourceId);

            // Act & Assert
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await extensionTopicResource.GetAsync();
            });

            await Task.CompletedTask;
        }

        [Test]
        public async Task ExtensionTopicResourceGetAsync()
        {
            // Arrange
            string subscriptionId = "5b4b650e-28b9-4790-b3ab-ddbd88d727c4";
            string resourceGroupName = "sdk-eventgrid-test-rg";
            string systemTopicName = "sdk-eventgrid-test-systemTopic";

            var resourceId = SystemTopicResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, systemTopicName);
            var systemTopicResource = Client.GetSystemTopicResource(resourceId);

            // Act
            var response = await systemTopicResource.GetAsync();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(systemTopicName, response.Value.Data.Name);
        }
    }
}
