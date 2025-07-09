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
    [TestFixture(true)]
    [TestFixture(false)]
    internal class ExtensionTopicTests
    {
        private readonly bool _isAsync;

        public ExtensionTopicTests(bool isAsync)
        {
            _isAsync = isAsync;
        }

        [Test]
        public async Task GetAsync_ThrowsRequestFailedException()
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
    }
}
