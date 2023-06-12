// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class CommitmentPlanResourceTests : CognitiveServicesManagementTestBase
    {
        public CommitmentPlanResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<CommitmentPlanResource> CreateCommitmentPlanAsync(string planName)
        {
            var accountContainer = (await CreateResourceGroupAsync()).GetCognitiveServicesAccounts();
            var accountInput = ResourceDataHelper.GetBasicAccountData(DefaultLocation);
            accountInput.Sku = new CognitiveServicesSku("S");
            accountInput.Kind = "TextAnalytics";
            var lro = await accountContainer.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAccount-"), accountInput);
            var account = lro.Value;
            var container = account.GetCommitmentPlans();
            var input = ResourceDataHelper.GetBasicCommitmentPlanData();
            var lro_plan = await container.CreateOrUpdateAsync(WaitUntil.Completed, planName, input);
            return lro_plan.Value;
        }

        [TestCase]
        public async Task CommitmentPlanResourceApiTests()
        {
            //1.Get
            var planName = Recording.GenerateAssetName("testCommitmentPlan-");
            var plan1 = await CreateCommitmentPlanAsync(planName);
            CommitmentPlanResource plan2 = await plan1.GetAsync();

            ResourceDataHelper.AssertCommitmentPlan(plan1.Data, plan2.Data);
            //2.Delete
            await plan1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
