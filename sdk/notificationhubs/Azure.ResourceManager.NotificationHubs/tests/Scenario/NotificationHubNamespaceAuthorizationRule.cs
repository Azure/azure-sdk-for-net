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
    internal class NotificationHubNamespaceAuthorizationRule : NotificationHubsManagementTestBase
    {
        private ResourceIdentifier _notificationHubNamespaceIdentifier;
        private NotificationHubNamespaceResource _notificationHubNamespaceResource;

        private NotificationHubNamespaceAuthorizationRuleCollection _AuthorizationRuleCollection => _notificationHubNamespaceResource.GetNotificationHubNamespaceAuthorizationRules();

        public NotificationHubNamespaceAuthorizationRule(bool isAsync) : base(isAsync)
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

        private async Task<NotificationHubNamespaceAuthorizationRuleResource> CreateNamespaceAuthorizationRule(string authorizationRuleName)
        {
            var data = new NotificationHubAuthorizationRuleData(DefaultLocation);
            data.AccessRights.Add(AuthorizationRuleAccessRightExt.Send);
            data.AccessRights.Add(AuthorizationRuleAccessRightExt.Listen);
            data.AccessRights.Add(AuthorizationRuleAccessRightExt.Manage);
            var authoriaztionRule = await _AuthorizationRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, authorizationRuleName, data);
            return authoriaztionRule.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string authorizationRuleName = Recording.GenerateAssetName("ManagesharedAccessKey");
            var authoriaztionRule = await CreateNamespaceAuthorizationRule(authorizationRuleName);
            Assert.IsNotNull(authoriaztionRule);
            Assert.AreEqual(authorizationRuleName, authoriaztionRule.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string authorizationRuleName = Recording.GenerateAssetName("ManagesharedAccessKey");
            await CreateNamespaceAuthorizationRule(authorizationRuleName);
            bool flag = await _AuthorizationRuleCollection.ExistsAsync(authorizationRuleName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string authorizationRuleName = Recording.GenerateAssetName("ManagesharedAccessKey");
            await CreateNamespaceAuthorizationRule(authorizationRuleName);
            var authoriaztionRule = await _AuthorizationRuleCollection.GetAsync(authorizationRuleName);
            Assert.IsNotNull(authoriaztionRule);
            Assert.AreEqual(authorizationRuleName, authoriaztionRule.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _AuthorizationRuleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string authorizationRuleName = Recording.GenerateAssetName("ManagesharedAccessKey");
            var authoriaztionRule = await CreateNamespaceAuthorizationRule(authorizationRuleName);
            bool flag = await _AuthorizationRuleCollection.ExistsAsync(authorizationRuleName);
            Assert.IsTrue(flag);

            await authoriaztionRule.DeleteAsync(WaitUntil.Completed);
            flag = await _AuthorizationRuleCollection.ExistsAsync(authorizationRuleName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task ListKeys()
        {
            string authorizationRuleName = Recording.GenerateAssetName("ManagesharedAccessKey");
            var authoriaztionRule = await CreateNamespaceAuthorizationRule(authorizationRuleName);
            var key = await authoriaztionRule.GetKeysAsync();
            Assert.IsNotNull(key);
            Assert.IsNotNull(key.Value.PrimaryKey);
            Assert.IsNotNull(key.Value.SecondaryKey);
            Assert.IsNotNull(key.Value.SecondaryConnectionString);
            Assert.AreEqual(authorizationRuleName, key.Value.KeyName);
        }

        [RecordedTest]
        public async Task RegenerateKeys()
        {
            string authorizationRuleName = Recording.GenerateAssetName("ManagesharedAccessKey");
            var authoriaztionRule = await CreateNamespaceAuthorizationRule(authorizationRuleName);

            NotificationHubPolicyKey notificationHubPolicyKey = new NotificationHubPolicyKey()
            {
                PolicyKey = "PrimaryKey"
            };
            var key = await authoriaztionRule.RegenerateKeysAsync(notificationHubPolicyKey);
            Assert.IsNotNull(key);
            Assert.IsNotNull(key.Value.PrimaryKey);
            Assert.IsNotNull(key.Value.SecondaryKey);
            Assert.IsNotNull(key.Value.SecondaryConnectionString);
            Assert.AreEqual(authorizationRuleName, key.Value.KeyName);
        }
    }
}
