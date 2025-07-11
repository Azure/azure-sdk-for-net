// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridNamespaceResourceTests : EventGridManagementTestBase
    {
        public EventGridNamespaceResourceTests(bool isAsync)
            : base(isAsync)
        {
        }

        private EventGridNamespaceResource _namespaceResource;
        private string _namespaceName;
        private ResourceGroupResource _resourceGroup;

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), DefaultLocation);
            var namespaceCollection = _resourceGroup.GetEventGridNamespaces();
            _namespaceName = Recording.GenerateAssetName("sdk-Namespace-");

            var namespaceData = new EventGridNamespaceData(DefaultLocation)
            {
                Sku = new NamespaceSku { Name = "Standard", Capacity = 1 },
                IsZoneRedundant = true,
                TopicSpacesConfiguration = new TopicSpacesConfiguration
                {
                    State = TopicSpacesConfigurationState.Enabled
                }
            };

            var createResponse = await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _namespaceName, namespaceData);
            _namespaceResource = createResponse.Value;
        }

        [RecordedTest]
        public async Task Namespace_Lifecycle_CreateGetTagDelete()
        {
            if (Mode == RecordedTestMode.Playback)
                Assert.Ignore("Skipping test in Playback mode due to resource dependencies and Timeout Error");

            // Get
            var getResponse = await _resourceGroup.GetEventGridNamespaces().GetAsync(_namespaceName);
            Assert.IsNotNull(getResponse.Value);

            // Add Tag
            var updated = await _namespaceResource.AddTagAsync("env", "test");
            Assert.IsTrue(updated.Value.Data.Tags.ContainsKey("env"));

            // Set Tags
            var setTags = new Dictionary<string, string> { { "project", "sdk" } };
            updated = await _namespaceResource.SetTagsAsync(setTags);
            Assert.IsTrue(updated.Value.Data.Tags.ContainsKey("project"));
            Assert.IsFalse(updated.Value.Data.Tags.ContainsKey("env"));

            // Remove Tag
            updated = await _namespaceResource.RemoveTagAsync("project");
            Assert.IsFalse(updated.Value.Data.Tags.ContainsKey("project"));
        }

        [Test]
        public async Task Namespace_ClientGroup_Client_PermissionBinding_TopicSpace_Topic_Lifecycle()
        {
            // Client Group
            var clientGroups = _namespaceResource.GetEventGridNamespaceClientGroups();
            var groupName = "testClientGroup";
            var groupData = new EventGridNamespaceClientGroupData { Query = "attributes.test = 'value'" };
            await clientGroups.CreateOrUpdateAsync(WaitUntil.Completed, groupName, groupData);
            var groupResource = await _namespaceResource.GetEventGridNamespaceClientGroupAsync(groupName);
            Assert.IsNotNull(groupResource);
            Assert.AreEqual(groupName, groupResource.Value.Data.Name);

            // Client
            var clients = _namespaceResource.GetEventGridNamespaceClients();
            var clientName = "testClient";
            var clientData = new EventGridNamespaceClientData
            {
                Description = "Test Client",
                ClientCertificateAuthentication = new ClientCertificateAuthentication
                {
                    ValidationScheme = ClientCertificateValidationScheme.ThumbprintMatch,
                    AllowedThumbprints = { "934367bf1c97033f877db0f15cb1b586957d313" }
                }
            };
            await clients.CreateOrUpdateAsync(WaitUntil.Completed, clientName, clientData);
            var clientResource = await _namespaceResource.GetEventGridNamespaceClientAsync(clientName);
            Assert.IsNotNull(clientResource);
            Assert.AreEqual(clientName, clientResource.Value.Data.Name);

            // Topic Space
            var topicSpaces = _namespaceResource.GetTopicSpaces();
            var topicSpaceName = "testTopicSpace";
            var topicSpaceData = new TopicSpaceData();
            topicSpaceData.TopicTemplates.Add("template1");
            await topicSpaces.CreateOrUpdateAsync(WaitUntil.Completed, topicSpaceName, topicSpaceData);
            var topicSpaceResource = await _namespaceResource.GetTopicSpaceAsync(topicSpaceName);
            Assert.IsNotNull(topicSpaceResource);
            Assert.AreEqual(topicSpaceName, topicSpaceResource.Value.Data.Name);

            // Permission Binding
            var bindings = _namespaceResource.GetEventGridNamespacePermissionBindings();
            var bindingName = "testBinding";
            var bindingData = new EventGridNamespacePermissionBindingData
            {
                ClientGroupName = groupName,
                TopicSpaceName = topicSpaceName,
                Permission = PermissionType.Subscriber
            };
            await bindings.CreateOrUpdateAsync(WaitUntil.Completed, bindingName, bindingData);
            var bindingResource = await _namespaceResource.GetEventGridNamespacePermissionBindingAsync(bindingName);
            Assert.IsNotNull(bindingResource);
            Assert.AreEqual(bindingName, bindingResource.Value.Data.Name);

            // Namespace Topic
            var topics = _namespaceResource.GetNamespaceTopics();
            var topicName = "testTopic";
            var topicData = new NamespaceTopicData { EventRetentionInDays = 1 };
            await topics.CreateOrUpdateAsync(WaitUntil.Completed, topicName, topicData);
            var topicResource = await _namespaceResource.GetNamespaceTopicAsync(topicName);
            Assert.IsNotNull(topicResource);
            Assert.AreEqual(topicName, topicResource.Value.Data.Name);

            // CA Certificate
            var caCertificates = _namespaceResource.GetCaCertificates();
            var caCertName = "testCertificate";
            var caCertData = new CaCertificateData
            {
                Description = "Test CA Certificate",
                EncodedCertificate = "SANITIZED_ENCODED_CERTIFICATE"
            };
            await caCertificates.CreateOrUpdateAsync(WaitUntil.Completed, caCertName, caCertData);
            var caCertResource = await _namespaceResource.GetCaCertificateAsync(caCertName);
            Assert.IsNotNull(caCertResource);
            Assert.AreEqual(caCertName, caCertResource.Value.Data.Name);

            // Clean up created resources
            await (await bindings.GetAsync(bindingName)).Value.DeleteAsync(WaitUntil.Completed);
            await (await topicSpaces.GetAsync(topicSpaceName)).Value.DeleteAsync(WaitUntil.Completed);
            await (await topics.GetAsync(topicName)).Value.DeleteAsync(WaitUntil.Completed);
            await (await clientGroups.GetAsync(groupName)).Value.DeleteAsync(WaitUntil.Completed);
            await (await clients.GetAsync(clientName)).Value.DeleteAsync(WaitUntil.Completed);
            await (await caCertificates.GetAsync(caCertName)).Value.DeleteAsync(WaitUntil.Completed);
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode == RecordedTestMode.Playback)
                return;

            if (_namespaceResource != null)
                await _namespaceResource.DeleteAsync(WaitUntil.Completed);

            if (_resourceGroup != null)
                await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
