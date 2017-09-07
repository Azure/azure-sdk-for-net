
using System;
using Xunit;

using Microsoft.AzureStack.Management.Commerce.Admin;
using Microsoft.AzureStack.Management.Commerce.Admin.Models;

using Microsoft.AzureStack.TestFramework;

namespace Commerce.Tests
{
    public class SubscriberUsageAggregateTests : CommerceTestBase
    {

        private void ValidateUsageAggregate(UsageAggregate ua) {
            Assert.NotNull(ua);
            Assert.NotNull(ua.Id);
            Assert.NotNull(ua.InstanceData);
            Assert.NotNull(ua.MeterId);
            Assert.NotNull(ua.Name);
            Assert.NotNull(ua.Quantity);
            Assert.NotNull(ua.SubscriptionId);
            Assert.NotNull(ua.Type);
            Assert.NotNull(ua.UsageEndTime);
            Assert.NotNull(ua.UsageStartTime);
        }

        private void AssertDateIsDayOnly(DateTime time, string msg = null) {
            msg = $"{msg} : " ?? "";
            Assert.Equal(0, time.Hour);
            Assert.Equal(0, time.Minute);
            Assert.Equal(0, time.Second);
            Assert.Equal(0, time.Millisecond);

        }

        [Fact]
        public void TestListSubscriberUsageAggregatesFromLastTwoHours() {
            RunTest((client) => {
                var testDate = new DateTime(2017,09,06);
                testDate = DateTime.SpecifyKind(testDate, DateTimeKind.Utc);
                var start = testDate.Floor();
                var end = start.AddDays(1).Floor();

                // You need to do this.  ARM does this and you need to make 
                // sure you work with ARM.  
                AssertDateIsDayOnly(start, "start");
                AssertDateIsDayOnly(end, "end");

                var subscriberUsageAggregates = client.SubscriberUsageAggregates.List(start, end);
                Assert.NotNull(subscriberUsageAggregates);
                Assert.NotNull(subscriberUsageAggregates.Value);
                Common.MapOverIEnumerable(subscriberUsageAggregates.Value, (v) => ValidateUsageAggregate(v));
            });
        }

    }
}
