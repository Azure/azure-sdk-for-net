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
            Assert.IsNotNull(notificationHubNamespace);
            Assert.AreEqual(notificationHubNamespaceName, notificationHubNamespace.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string notificationHubNamespaceName = Recording.GenerateAssetName("azNotificationHubNamespace");
            await CreateNotificationHubNamespace(_resourceGroup, notificationHubNamespaceName);
            bool flag = await _namespaceCollection.ExistsAsync(notificationHubNamespaceName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string notificationHubNamespaceName = Recording.GenerateAssetName("azNotificationHubNamespace");
            await CreateNotificationHubNamespace(_resourceGroup, notificationHubNamespaceName);
            var notificationHubNamespace = await _namespaceCollection.GetAsync(notificationHubNamespaceName);
            Assert.IsNotNull(notificationHubNamespace);
            Assert.AreEqual(notificationHubNamespaceName, notificationHubNamespace.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string notificationHubNamespaceName = Recording.GenerateAssetName("azNotificationHubNamespace");
            await CreateNotificationHubNamespace(_resourceGroup, notificationHubNamespaceName);
            var list = await _namespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string notificationHubNamespaceName = Recording.GenerateAssetName("azNotificationHubNamespace");
            var notificationHubNamespace = await CreateNotificationHubNamespace(_resourceGroup, notificationHubNamespaceName);
            bool flag = await _namespaceCollection.ExistsAsync(notificationHubNamespaceName);
            Assert.IsTrue(flag);

            await notificationHubNamespace.DeleteAsync(WaitUntil.Completed);
            flag = await _namespaceCollection.ExistsAsync(notificationHubNamespaceName);
            Assert.IsFalse(flag);
        }
    }
}
