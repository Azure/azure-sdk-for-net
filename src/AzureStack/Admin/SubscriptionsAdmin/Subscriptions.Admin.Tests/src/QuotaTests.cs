// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Microsoft.AzureStack.Management.Subscriptions.Admin.Models;
using Subscriptions.Tests.src.Helpers;
using System;
using Xunit;

namespace Subscriptions.Tests
{
    public class QuotaTests : SubscriptionsTestBase
    {
        private void ValidateQuota(Quota quota)
        {
            Assert.NotNull(quota);
            Assert.NotNull(quota.Id);
            Assert.NotNull(quota.Location);
            Assert.NotNull(quota.Name);
            Assert.NotNull(quota.Type);

        }

        [Fact]
        public void TestListQuotas() {
            RunTest((client) => {
                var quotas = client.Quotas.List(TestContext.LocationName);
                quotas.ForEach(q => ValidateQuota(q));
            });
        }
    }
}
