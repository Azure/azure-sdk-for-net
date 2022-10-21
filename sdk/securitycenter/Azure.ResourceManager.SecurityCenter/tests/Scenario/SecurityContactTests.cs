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

        public SecurityContactTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TearDown]
        public async Task TestTearDown()
        {
            var list = await _SecurityContactCollection.GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<SecurityContactResource> CreateSecurityContact(string securityContactName)
        {
            SecurityContactData data = new SecurityContactData()
            {
                Email = $"{Recording.GenerateAssetName("john")}@contoso.com",
                Phone = "18800001111",
                AlertNotifications = AlertNotification.On,
                AlertsToAdmins = AlertsToAdmin.Off,
            };
            var securityContact = await _SecurityContactCollection.CreateOrUpdateAsync(WaitUntil.Completed, securityContactName, data);
            return securityContact.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string securityContactName = Recording.GenerateAssetName("newSecurityContact");
            var securityContact = await CreateSecurityContact(securityContactName);
            ValidateSecurityContactResource(securityContact, securityContactName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string securityContactName = Recording.GenerateAssetName("newSecurityContact");
            await CreateSecurityContact(securityContactName);
            bool flag = await _SecurityContactCollection.ExistsAsync(securityContactName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string securityContactName = Recording.GenerateAssetName("newSecurityContact");
            await CreateSecurityContact(securityContactName);
            var securityContact = await _SecurityContactCollection.GetAsync(securityContactName);
            ValidateSecurityContactResource(securityContact, securityContactName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string securityContactName = Recording.GenerateAssetName("newSecurityContact");
            await CreateSecurityContact(securityContactName);
            var list = await _SecurityContactCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSecurityContactResource(list.First(item => item.Data.Name == securityContactName), securityContactName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string securityContactName = Recording.GenerateAssetName("newSecurityContact");
            var securityContact = await CreateSecurityContact(securityContactName);
            bool flag = await _SecurityContactCollection.ExistsAsync(securityContactName);
            Assert.IsTrue(flag);

            await securityContact.DeleteAsync(WaitUntil.Completed);
            flag = await _SecurityContactCollection.ExistsAsync(securityContactName);
            Assert.IsFalse(flag);
        }

        private void ValidateSecurityContactResource(SecurityContactResource securityContact, string securityContactName)
        {
            Assert.IsNotNull(securityContact);
            Assert.IsNotNull(securityContact.Data.Id);
            Assert.AreEqual(securityContactName, securityContact.Data.Name);
            Assert.AreEqual("18800001111", securityContact.Data.Phone);
            Assert.AreEqual(AlertNotification.On, securityContact.Data.AlertNotifications);
            Assert.AreEqual(AlertsToAdmin.Off, securityContact.Data.AlertsToAdmins);
        }
    }
}
