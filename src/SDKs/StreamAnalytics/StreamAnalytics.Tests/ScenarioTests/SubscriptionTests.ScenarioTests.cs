// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace StreamAnalytics.Tests
{
    public class SubscriptionTests : TestBase
    {
        [Fact(Skip = "Incorrect number of arguments supplied to call for method.")]
        public void SubscriptionOperationsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                SubscriptionQuotasListResult quotaListResult = streamAnalyticsManagementClient.Subscriptions.ListQuotas(TestHelper.DefaultLocation);
                Assert.Equal(1, quotaListResult.Value.Count);
                Assert.Equal(0, quotaListResult.Value.Single().CurrentCount);
                Assert.Equal(200, quotaListResult.Value.Single().MaxCount);
            }
        }
    }
}