// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NotificationHubs.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.NotificationHubs.Tests
{
    internal class NotificationHubTests : NotificationHubsManagementTestBase
    {
        private ResourceIdentifier _notificationHubNamespaceIdentifier;
        private NotificationHubNamespaceResource _notificationHubNamespaceResource;

        private NotificationHubCollection _notificationHubCollection => _notificationHubNamespaceResource.GetNotificationHubs();

        public NotificationHubTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(DefaultLocation));
            var notificationHubNamespace = await CreateNotificationHubNamespace(rgLro.Value, SessionRecording.GenerateAssetName("azNotificationHubNamespace"));
            _notificationHubNamespaceIdentifier = notificationHubNamespace.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _notificationHubNamespaceResource = await Client.GetNotificationHubNamespaceResource(_notificationHubNamespaceIdentifier).GetAsync();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string notificationHubName = Recording.GenerateAssetName("azNotificationHub");
            var notificationHub = await CreateNotificationHub(_notificationHubNamespaceResource, notificationHubName);
            Assert.IsNotNull(notificationHub);
            Assert.AreEqual(notificationHubName, notificationHub.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string notificationHubName = Recording.GenerateAssetName("azNotificationHub");
            await CreateNotificationHub(_notificationHubNamespaceResource, notificationHubName);
            bool flag = await _notificationHubCollection.ExistsAsync(notificationHubName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string notificationHubName = Recording.GenerateAssetName("azNotificationHub");
            await CreateNotificationHub(_notificationHubNamespaceResource, notificationHubName);
            var notificationHub = await _notificationHubCollection.GetAsync(notificationHubName);
            Assert.IsNotNull(notificationHub);
            Assert.AreEqual(notificationHubName, notificationHub.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string notificationHubName = Recording.GenerateAssetName("azNotificationHub");
            await CreateNotificationHub(_notificationHubNamespaceResource, notificationHubName);
            var list = await _notificationHubCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string notificationHubName = Recording.GenerateAssetName("azNotificationHub");
            var notificationHub = await CreateNotificationHub(_notificationHubNamespaceResource, notificationHubName);
            bool flag = await _notificationHubCollection.ExistsAsync(notificationHubName);
            Assert.IsTrue(flag);

            await notificationHub.DeleteAsync(WaitUntil.Completed);
            flag = await _notificationHubCollection.ExistsAsync(notificationHubName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task GetPnsCredentials()
        {
            string notificationHubName = Recording.GenerateAssetName("azNotificationHub");
            var notificationHub = await CreateNotificationHub(_notificationHubNamespaceResource, notificationHubName);
            var pnsCredential = await notificationHub.GetPnsCredentialsAsync();
            Assert.IsNotNull(pnsCredential);
        }
    }
}
