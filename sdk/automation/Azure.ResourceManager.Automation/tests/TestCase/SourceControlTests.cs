// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Automation.Tests.TestCase
{
    public class SourceControlTests : AutomationManagementTestBase
    {
        public SourceControlTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AutomationSourceControlCollection> GetSourceControlCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var accountCollection = resourceGroup.GetAutomationAccounts();
            var accountName = Recording.GenerateAssetName("account");
            var input = ResourceDataHelpers.GetAccountData();
            var accountResource = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return accountResource.Value.GetAutomationSourceControls();
        }

        [TestCase]
        [Ignore("SourceControl validation failed")]
        public async Task SourceControlApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetSourceControlCollectionAsync();
            var name = Recording.GenerateAssetName("sourcecontrol");
            var name2 = Recording.GenerateAssetName("sourcecontrol");
            var name3 = Recording.GenerateAssetName("sourcecontrol");
            var input = ResourceDataHelpers.GetSourceControlData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            AutomationSourceControlResource sourcecontrol = lro.Value;
            Assert.AreEqual(name, sourcecontrol.Data.Name);
            //2.Get
            AutomationSourceControlResource sourcecontrol2 = await sourcecontrol.GetAsync();
            ResourceDataHelpers.AssertSourceControl(sourcecontrol.Data, sourcecontrol2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            AutomationSourceControlResource sourcecontrol3 = await sourcecontrol.GetAsync();
            ResourceDataHelpers.AssertSourceControl(sourcecontrol.Data, sourcecontrol3.Data);
            //6.Delete
            await sourcecontrol.DeleteAsync(WaitUntil.Completed);
        }
    }
}
