// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace KeyVault.Tests
{
    using Microsoft.AzureStack.Management.KeyVault.Admin;
    using Microsoft.AzureStack.Management.KeyVault.Admin.Models;
    using Xunit;

    public class SubscriberUsageAggregateTests : KeyVaultTestBase
    {

        private void ValidateQuota(Quota ua)
        {
            Assert.NotNull(ua);
            Assert.NotNull(ua.Id);
            Assert.NotNull(ua.Name);
            Assert.NotNull(ua.Type);
        }

        /// <summary>
        /// Test that we can retrieve subscriber ussage aggregates over the last two days.
        /// </summary>
        [Fact]
        public void TestListQuotas()
        {
            RunTest((client) =>
            {

                var quotas = client.Quotas.List("local");
                quotas.ForEach(ValidateQuota);
            });
        }

    }
}
