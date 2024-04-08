// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class ActivityLogsTests : MonitorTestBase
    {
        public ActivityLogsTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetActivityLogsBySubscription()
        {
            var subscription = DefaultSubscription;
            var filter = "eventTimestamp ge '2024-04-08T01:00:00Z' and eventTimestamp le '2024-04-08T18:00:00Z' and resourceGroupName eq 'rgMonitor624'";
            int sum = 0;
            await foreach (var item in subscription.GetActivityLogsAsync(filter))
            {
                sum++;
            }
            Assert.IsTrue(sum > 0);
        }
    }
}
