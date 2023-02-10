// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class CommitmentPlanCollectionTests : CognitiveServicesManagementTestBase
    {
        public CommitmentPlanCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<CommitmentPlanCollection> GetCommitmentPlanCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetCognitiveServicesAccounts();
            var input = ResourceDataHelper.GetBasicAccountData(DefaultLocation);
            input.Sku = new CognitiveServicesSku("S");
            input.Kind = "TextAnalytics";
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAccount-"), input);
            var account = lro.Value;
            return account.GetCommitmentPlans();
        }

        [TestCase]
        public async Task CommitmentPlanCollectionApiTests()
        {
            //1.CreateOrUpdate
            var container = await GetCommitmentPlanCollectionAsync();
            var name = Recording.GenerateAssetName("CommitmentPlan-");
            var input = ResourceDataHelper.GetBasicCommitmentPlanData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            CommitmentPlanResource plan1 = lro.Value;
            Assert.AreEqual(name, plan1.Data.Name);
            //2.Get
            CommitmentPlanResource plan2 = await container.GetAsync(name);
            ResourceDataHelper.AssertCommitmentPlan(plan1.Data, plan2.Data);
            //3.GetAll
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            int count = 0;
            await foreach (var plan in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4Exists
            Assert.IsTrue(await container.ExistsAsync(name));
            Assert.IsFalse(await container.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
