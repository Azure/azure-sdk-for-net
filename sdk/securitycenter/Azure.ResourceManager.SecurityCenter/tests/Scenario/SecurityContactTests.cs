// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class SecurityContactTests : SecurityCenterManagementTestBase
    {
        private SecurityContactCollection _SecurityContactCollection => DefaultSubscription.GetSecurityContacts();
        private const string _securityContactName = "default";

        public SecurityContactTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<SecurityContactResource> CreateSecurityContact(string securityContactName = _securityContactName)
        {
            SecurityContactData data = new SecurityContactData()
            {
                Emails = $"{Recording.GenerateAssetName("john")}@contoso.com",
                Phone = "18800001111",
                AlertNotifications = new SecurityContactPropertiesAlertNotifications()
                {
                    State = SecurityAlertNotificationState.On
                },
                NotificationsByRole = new SecurityContactPropertiesNotificationsByRole()
                {
                    State = SecurityAlertNotificationByRoleState.Off,
                },
            };
            var securityContact = await _SecurityContactCollection.CreateOrUpdateAsync(WaitUntil.Completed, securityContactName, data);
            return securityContact.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var securityContact = await CreateSecurityContact();
            ValidateSecurityContactResource(securityContact, _securityContactName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            await CreateSecurityContact();
            bool flag = await _SecurityContactCollection.ExistsAsync(_securityContactName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            await CreateSecurityContact();
            var securityContact = await _SecurityContactCollection.GetAsync(_securityContactName);
            ValidateSecurityContactResource(securityContact);
        }

        [RecordedTest]
        [Ignore("OPEN ISSUE: https://github.com/Azure/azure-rest-api-specs/issues/21260")]
        public async Task GetAll()
        {
            await CreateSecurityContact();
            var list = await _SecurityContactCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSecurityContactResource(list.First(item => item.Data.Name == _securityContactName));
        }

        [RecordedTest]
        public async Task Delete()
        {
            var securityContact = await CreateSecurityContact();
            bool flag = await _SecurityContactCollection.ExistsAsync(_securityContactName);
            Assert.IsTrue(flag);

            await securityContact.DeleteAsync(WaitUntil.Completed);
            flag = await _SecurityContactCollection.ExistsAsync(_securityContactName);
            Assert.IsFalse(flag);
        }

        private void ValidateSecurityContactResource(SecurityContactResource securityContact, string securityContactName = _securityContactName)
        {
            Assert.IsNotNull(securityContact);
            Assert.IsNotNull(securityContact.Data.Id);
            Assert.AreEqual(securityContactName, securityContact.Data.Name);
            Assert.AreEqual("18800001111", securityContact.Data.Phone);
        }
    }
}
