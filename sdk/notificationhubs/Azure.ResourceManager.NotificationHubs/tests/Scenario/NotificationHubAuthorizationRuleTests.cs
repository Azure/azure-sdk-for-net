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
    internal class NotificationHubAuthorizationRuleTests : NotificationHubsManagementTestBase
    {
        private ResourceIdentifier _notificationHubIdentifier;
        private NotificationHubResource _notificationHubResource;

        private NotificationHubAuthorizationRuleCollection _authorizationRuleCollection => _notificationHubResource.GetNotificationHubAuthorizationRules();

        public NotificationHubAuthorizationRuleTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(DefaultLocation));
            var notificationHubNamespace = await CreateNotificationHubNamespace(rgLro.Value, SessionRecording.GenerateAssetName("azNotificationHubNamespace"));
            var notificationHub = await CreateNotificationHub(notificationHubNamespace, SessionRecording.GenerateAssetName("azNotificationHub"));
            _notificationHubIdentifier = notificationHub.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _notificationHubResource = await Client.GetNotificationHubResource(_notificationHubIdentifier).GetAsync();
        }

        private async Task<NotificationHubAuthorizationRuleResource> CreateAuthorizationRule(string authorizationRuleName)
        {
            var data = new NotificationHubAuthorizationRuleData(DefaultLocation);
            data.AccessRights.Add(AuthorizationRuleAccessRightExt.Send);
            data.AccessRights.Add(AuthorizationRuleAccessRightExt.Listen);
            data.AccessRights.Add(AuthorizationRuleAccessRightExt.Manage);
            var authorizationRule = await _authorizationRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, authorizationRuleName, data);
            return authorizationRule.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string authorizationRuleName = Recording.GenerateAssetName("CustomPolicy");
            var authorizationRule = await CreateAuthorizationRule(authorizationRuleName);
            Assert.IsNotNull(authorizationRule);
            Assert.AreEqual(authorizationRuleName, authorizationRule.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string authorizationRuleName = Recording.GenerateAssetName("CustomPolicy");
            await CreateAuthorizationRule(authorizationRuleName);
            bool flag = await _authorizationRuleCollection.ExistsAsync(authorizationRuleName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string authorizationRuleName = Recording.GenerateAssetName("CustomPolicy");
            await CreateAuthorizationRule(authorizationRuleName);
            var authorizationRule = await _authorizationRuleCollection.GetAsync(authorizationRuleName);
            Assert.IsNotNull(authorizationRule);
            Assert.AreEqual(authorizationRuleName, authorizationRule.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _authorizationRuleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string authorizationRuleName = Recording.GenerateAssetName("CustomPolicy");
            var authorizationRule = await CreateAuthorizationRule(authorizationRuleName);
            bool flag = await _authorizationRuleCollection.ExistsAsync(authorizationRuleName);
            Assert.IsTrue(flag);

            await authorizationRule.DeleteAsync(WaitUntil.Completed);
            flag = await _authorizationRuleCollection.ExistsAsync(authorizationRuleName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task ListKeys()
        {
            string authorizationRuleName = Recording.GenerateAssetName("CustomPolicy");
            var authoriaztionRule = await CreateAuthorizationRule(authorizationRuleName);
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
            string authorizationRuleName = Recording.GenerateAssetName("CustomPolicy");
            var authoriaztionRule = await CreateAuthorizationRule(authorizationRuleName);

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
