// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.NotificationHubs.Tests
{
    internal class NotificationHubNamespaceTests : NotificationHubsManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;

        private NotificationHubNamespaceCollection _namespaceCollection => _resourceGroup.GetNotificationHubNamespaces();

        public NotificationHubNamespaceTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(DefaultLocation));
            _resourceGroupIdentifier = rgLro.Value.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string notificationHubNamespaceName = Recording.GenerateAssetName("azNotificationHubNamespace");
            var notificationHubNamespace = await CreateNotificationHubNamespace(_resourceGroup, notificationHubNamespaceName);
            Assert.That(notificationHubNamespace, Is.Not.Null);
            Assert.That(notificationHubNamespace.Data.Name, Is.EqualTo(notificationHubNamespaceName));
        }

        [RecordedTest]
        public async Task Exist()
        {
            string notificationHubNamespaceName = Recording.GenerateAssetName("azNotificationHubNamespace");
            await CreateNotificationHubNamespace(_resourceGroup, notificationHubNamespaceName);
            bool flag = await _namespaceCollection.ExistsAsync(notificationHubNamespaceName);
            Assert.That(flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            string notificationHubNamespaceName = Recording.GenerateAssetName("azNotificationHubNamespace");
            await CreateNotificationHubNamespace(_resourceGroup, notificationHubNamespaceName);
            var notificationHubNamespace = await _namespaceCollection.GetAsync(notificationHubNamespaceName);
            Assert.That(notificationHubNamespace, Is.Not.Null);
            Assert.That(notificationHubNamespace.Value.Data.Name, Is.EqualTo(notificationHubNamespaceName));
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string notificationHubNamespaceName = Recording.GenerateAssetName("azNotificationHubNamespace");
            await CreateNotificationHubNamespace(_resourceGroup, notificationHubNamespaceName);
            var list = await _namespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string notificationHubNamespaceName = Recording.GenerateAssetName("azNotificationHubNamespace");
            var notificationHubNamespace = await CreateNotificationHubNamespace(_resourceGroup, notificationHubNamespaceName);
            bool flag = await _namespaceCollection.ExistsAsync(notificationHubNamespaceName);
            Assert.That(flag, Is.True);

            await notificationHubNamespace.DeleteAsync(WaitUntil.Completed);
            flag = await _namespaceCollection.ExistsAsync(notificationHubNamespaceName);
            Assert.That(flag, Is.False);
        }
    }
}
