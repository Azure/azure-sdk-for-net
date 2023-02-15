// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Confluent.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Confluent.Tests
{
    public class MarketplaceTests : ConfluentManagementTestBase
    {
        public MarketplaceTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        [Ignore("Need service team to run the case")]
        public async Task BasicTest()
        {
            var resource = (await DefaultSubscription.CreateMarketplaceAgreementAsync()).Value;
            Assert.NotNull(resource);

            var list = await DefaultSubscription.GetMarketplaceAgreementsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 1);
        }
    }
}
