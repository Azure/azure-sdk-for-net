// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class SubscriptionLocationOperationsTests : CognitiveServicesManagementTestBase
    {
        public SubscriptionLocationOperationsTests(bool Async)
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
        public async Task ListModelsApiTests()
        {
            bool hasValue = false;
            await foreach (CognitiveServicesModel item in DefaultSubscription.GetModelsAsync(AzureLocation.EastUS))
            {
                hasValue = true;
                Assert.IsNotNull(item.SkuName);
                Assert.IsNotNull(item.Model);
            }
            Assert.IsTrue(hasValue);
        }

        [TestCase]
        public async Task ListUsagesApiTests()
        {
            bool hasValue = false;
            await foreach (ServiceAccountUsage item in DefaultSubscription.GetUsagesAsync(AzureLocation.EastUS))
            {
                hasValue = true;
                Assert.IsNotNull(item.Name);
                Assert.IsNotNull(item.CurrentValue);
            }
            Assert.IsTrue(hasValue);
        }
    }
}
