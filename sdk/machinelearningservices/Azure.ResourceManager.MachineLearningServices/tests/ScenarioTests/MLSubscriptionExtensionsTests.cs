// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MachineLearningServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class MLSubscriptionExtensionsTests : MachineLearningServicesManagerTestBase
    {
        public MLSubscriptionExtensionsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetQuotas()
        {
            var quotas = await Client.DefaultSubscription.GetQuotasAsync(DefaultLocation).ToEnumerableAsync();
            Assert.Greater(quotas.Count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateQuotas()
        {
            var updatedQuotas = (await Client.DefaultSubscription.GetQuotaateAsync(
                DefaultLocation,
                new List<QuotaBaseProperties>
                {
                    new QuotaBaseProperties
                    {
                        Id = "", Limit = 1, Type = "", Unit = new QuotaUnit("")
                    }
                })).Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task GetMachineLearningSkus()
        {
            var skus = await Client.DefaultSubscription.GetWorkspaceSkusAsync().ToEnumerableAsync();
            Assert.Greater(skus.Count, 1);
        }
    }
}
