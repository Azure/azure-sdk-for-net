// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Automation.Tests.TestCase
{
    public class VariableTests : AutomationManagementTestBase
    {
        public VariableTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AutomationVariableCollection> GetVariableCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var accountCollection = resourceGroup.GetAutomationAccounts();
            var accountName = Recording.GenerateAssetName("account");
            var input = ResourceDataHelpers.GetAccountData();
            var accountResource = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return accountResource.Value.GetAutomationVariables();
        }

        [Test]
        public async Task VariableApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetVariableCollectionAsync();
            var name = Recording.GenerateAssetName("variable");
            var name2 = Recording.GenerateAssetName("vaiable");
            var name3 = Recording.GenerateAssetName("variable");
            var input = ResourceDataHelpers.GetVariableData(name);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            AutomationVariableResource variable1 = lro.Value;
            Assert.That(variable1.Data.Name, Is.EqualTo(name));
            //2.Get
            AutomationVariableResource variable2 = await variable1.GetAsync();
            ResourceDataHelpers.AssertVariable(variable1.Data, variable2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.GreaterThanOrEqualTo(2));
            //4.Exists
            Assert.That((bool)await collection.ExistsAsync(name), Is.True);
            Assert.That((bool)await collection.ExistsAsync(name + "1"), Is.False);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            AutomationVariableResource avriable3 = await variable1.GetAsync();
            ResourceDataHelpers.AssertVariable(variable1.Data, avriable3.Data);
            //6.Delete
            await variable1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
