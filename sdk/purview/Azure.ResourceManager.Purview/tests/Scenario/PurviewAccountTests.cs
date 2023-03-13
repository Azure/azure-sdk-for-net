// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Purview.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Purview.Samples.Scenario
{
    internal class PurviewAccountTests : PurviewManagementTestBase
    {
        private const string _purviewAccountPrefix = "purviewaccount";
        private PurviewAccountCollection _purviewAccountCollection;

        public PurviewAccountTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var rg = await CreateResourceGroup();
            _purviewAccountCollection = rg.GetPurviewAccounts();
        }

        private async Task<PurviewAccountResource> CreatePurviewAccount(string accountName)
        {
            PurviewAccountData data = new PurviewAccountData(DefaultLocation)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            var purviewAccountLro = await _purviewAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data);

            // Wait 180 seconds for service deployment to complete.
            if (Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(180000);
            }

            return purviewAccountLro.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string purviewAccountName = Recording.GenerateAssetName(_purviewAccountPrefix);
            var purviewAccount = await CreatePurviewAccount(purviewAccountName);
            ValidatePurviewAccount(purviewAccount.Data, purviewAccountName);

            // Exist
            var flag = await _purviewAccountCollection.ExistsAsync(purviewAccountName);
            Assert.IsTrue(flag);

            // Get
            var getPurviewAccount = await _purviewAccountCollection.GetAsync(purviewAccountName);
            ValidatePurviewAccount(getPurviewAccount.Value.Data, purviewAccountName);

            // GetAll
            var list = await _purviewAccountCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePurviewAccount(list.FirstOrDefault().Data, purviewAccountName);

            // Delete
            await purviewAccount.DeleteAsync(WaitUntil.Completed);
            flag = await _purviewAccountCollection.ExistsAsync(purviewAccountName);
            Assert.IsFalse(flag);
        }

        // The current api-version 2022-09 does donot support use GetTagResource().CreateOrUpdate()
        // Http400: The supported api-versions are '2020-12-01-preview, 2021-07-01, 2021-12-01'.
        //[TestCase(true)]
        //[TestCase(null)]
        [TestCase(false)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string purviewAccountName = Recording.GenerateAssetName("purviewAccount");
            var purviewAccount = await CreatePurviewAccount(purviewAccountName);

            // AddTag
            await purviewAccount.AddTagAsync("addtagkey", "addtagvalue");
            purviewAccount = await _purviewAccountCollection.GetAsync(purviewAccountName);
            Assert.AreEqual(1, purviewAccount.Data.Tags.Count);
            KeyValuePair<string, string> tag = purviewAccount.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await purviewAccount.RemoveTagAsync("addtagkey");
            purviewAccount = await _purviewAccountCollection.GetAsync(purviewAccountName);
            Assert.AreEqual(0, purviewAccount.Data.Tags.Count);
        }

        private void ValidatePurviewAccount(PurviewAccountData purviewAccount, string purviewAccountName)
        {
            Assert.IsNotNull(purviewAccount);
            Assert.IsNotNull(purviewAccount.Id);
            Assert.AreEqual(purviewAccountName,purviewAccount.Name);
            Assert.AreEqual("eastus",purviewAccount.Location.ToString());
            Assert.AreEqual("Standard", purviewAccount.Sku.Name.ToString());
            Assert.AreEqual("SystemAssigned", purviewAccount.Identity.ManagedServiceIdentityType.ToString());
        }
    }
}
