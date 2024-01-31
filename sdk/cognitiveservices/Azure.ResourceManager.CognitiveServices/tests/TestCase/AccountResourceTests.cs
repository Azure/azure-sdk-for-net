// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class AccountResourceTests : CognitiveServicesManagementTestBase
    {
        public AccountResourceTests(bool Async)
            : base(Async)//, RecordedTestMode.Record)
        {
        }
        private async Task<CognitiveServicesAccountResource> CreateAccountResourceAsync(string accountName)
        {
            var container = (await CreateResourceGroupAsync()).GetCognitiveServicesAccounts();
            var input = ResourceDataHelper.GetBasicAccountData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task AccountResourceApiTests()
        {
            //1.Get
            var accountName = Recording.GenerateAssetName("testAccount-");
            var account1 = await CreateAccountResourceAsync(accountName);
            CognitiveServicesAccountResource account2 = await account1.GetAsync();

            ResourceDataHelper.AssertAccount(account1.Data, account2.Data);
            //2.Delete
            await account1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
