// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests.Scenario
{
    internal class EventGridTopicSpacesTests : EventGridManagementTestBase
    {
        public EventGridTopicSpacesTests(bool isAsync) : base(isAsync) { }
        private EventGridNamespaceCollection NamespaceCollection { get; set; }

        private ResourceGroupResource ResourceGroup { get; set; }

        private EventGridNamespaceResource EventGridNamespace { get; set; }

        [SetUp]

        public async Task SetupTest()
        {
            var rgName = Recording.GenerateAssetName("sdk-rg-");
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            ResourceGroup = ResourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), DefaultLocation);
            NamespaceCollection = ResourceGroup.GetEventGridNamespaces();

            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");

            var namespaceSku = new NamespaceSku { Name = "Standard", Capacity = 1 };

            var nameSpace = new EventGridNamespaceData(AzureLocation.EastUS2)
            {
                Tags = { { "originalTag1", "originalValue1" }, { "originalTag2", "originalValue2" } },

                Sku = namespaceSku,

                IsZoneRedundant = true,
                TopicSpacesConfiguration = new TopicSpacesConfiguration()
                {
                    State = TopicSpacesConfigurationState.Enabled
                },
            };

            EventGridNamespace = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;

            Assert.NotNull(EventGridNamespace);

            Assert.AreEqual(EventGridNamespace.Data.Name, namespaceName);
        }

        [Test]
        public async Task TopicSpacesCreateGetUpdateDelete()
        {
            string topicSpaceName = Recording.GenerateAssetName("topicspace-");

            var topicSpaceData = new TopicSpaceData {
                Description = "Test Topic Space",
                TopicTemplates = { "Microsoft.Resources.ResourceWriteSuccess" },
            };

            var createOperation = await EventGridNamespace.GetTopicSpaces().CreateOrUpdateAsync(WaitUntil.Completed, topicSpaceName, topicSpaceData);

            var topicSpace = createOperation.Value;

            Assert.IsNotNull(topicSpace);

            Assert.AreEqual("Test Topic Space", topicSpace.Data.Description);

            var retrievedTopicSpace = (await EventGridNamespace.GetTopicSpaces().GetAsync(topicSpaceName)).Value;

            Assert.IsNotNull(retrievedTopicSpace);

            Assert.AreEqual(topicSpaceName, retrievedTopicSpace.Data.Name);

            var updatedTopicSpaceData = new TopicSpaceData { Description = "Updated Topic Space Description", TopicTemplates = { "Microsoft.Resources.ResourceWriteSuccess" }, };

            var updatedTopicSpace = (await retrievedTopicSpace.UpdateAsync(WaitUntil.Completed, updatedTopicSpaceData)).Value;

            Assert.IsNotNull(updatedTopicSpace);

            Assert.AreEqual("Updated Topic Space Description", updatedTopicSpace.Data.Description);
            await updatedTopicSpace.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task ListTopicSpaces()
        {
            string topicSpaceName1 = Recording.GenerateAssetName("topicspace1-");

            string topicSpaceName2 = Recording.GenerateAssetName("topicspace2-");

            var topicSpaceData1 = new TopicSpaceData { Description = "Test Topic Space 1", TopicTemplates = { "Microsoft.Resources.ResourceWriteSuccess" }, };

            var topicSpaceData2 = new TopicSpaceData { Description = "Test Topic Space 2", TopicTemplates = { "Microsoft.Resources.ResourceWriteSuccess" }, };
            await EventGridNamespace.GetTopicSpaces().CreateOrUpdateAsync(WaitUntil.Completed, topicSpaceName1, topicSpaceData1);

            await EventGridNamespace.GetTopicSpaces().CreateOrUpdateAsync(WaitUntil.Completed, topicSpaceName2, topicSpaceData2);

            List<TopicSpaceResource> topicSpaces = await EventGridNamespace.GetTopicSpaces().GetAllAsync().ToEnumerableAsync();

            Assert.IsNotNull(topicSpaces);

            Assert.GreaterOrEqual(topicSpaces.Count, 2);

            Assert.IsTrue(topicSpaces.Any(ts => ts.Data.Name == topicSpaceName1));

            Assert.IsTrue(topicSpaces.Any(ts => ts.Data.Name == topicSpaceName2));

            foreach (var topicSpace in topicSpaces)
                await topicSpace.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task TopicSpaceResourceGetAsync()
        {
            // Arrange
            string topicSpaceName = Recording.GenerateAssetName("topicspace-get-");
            var topicSpaceData = new TopicSpaceData
            {
                Description = "GetAsync Test Topic Space",
                TopicTemplates = { "Microsoft.Resources.ResourceWriteSuccess" }
            };

            // Create the topic space
            var createOperation = await EventGridNamespace.GetTopicSpaces().CreateOrUpdateAsync(WaitUntil.Completed, topicSpaceName, topicSpaceData);
            var topicSpace = createOperation.Value;

            // Act
            var getResponse = await topicSpace.GetAsync();

            // Assert
            Assert.IsNotNull(getResponse);
            Assert.IsNotNull(getResponse.Value);
            Assert.IsNotNull(getResponse.Value.Data);
            Assert.AreEqual(topicSpaceName, getResponse.Value.Data.Name);

            // Cleanup
            await getResponse.Value.DeleteAsync(WaitUntil.Completed);
        }

        [OneTimeTearDown]
        public async Task GlobalCleanup()
        {
            if (EventGridNamespace != null)
                await EventGridNamespace.DeleteAsync(WaitUntil.Completed);

            if (ResourceGroup != null)
                await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
