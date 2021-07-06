using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class SubscriptionContainerTests : ResourceManagerTestBase
    {
        public SubscriptionContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            int count = 0;
            await foreach (var rg in Client.GetSubscriptions().ListAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task TryGet()
        {
            var foo = await Client.GetSubscriptions().TryGetAsync("/subscriptions/" + new Guid().ToString()).ConfigureAwait(false);
            Assert.IsNull(foo);
            string subscriptionId = Client.DefaultSubscription.Id.SubscriptionId;
            var subscription = await Client.GetSubscriptions().TryGetAsync("/subscriptions/" + subscriptionId).ConfigureAwait(false);
            Assert.NotNull(subscription);
            Assert.IsTrue(subscription.Id.SubscriptionId.Equals(subscriptionId));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string subscriptionId = Client.DefaultSubscription.Id.SubscriptionId;
            Subscription result = await Client.GetSubscriptions().GetAsync(subscriptionId).ConfigureAwait(false);
            Assert.AreEqual(subscriptionId, result.Id.SubscriptionId);

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.GetSubscriptions().GetAsync(null).ConfigureAwait(false));
        }

        [TestCase]
        [RecordedTest]
        public async Task DoesExist()
        {
            var expectFalse = await Client.GetSubscriptions().DoesExistAsync("/subscriptions/" + new Guid().ToString()).ConfigureAwait(false);
            Assert.IsFalse(expectFalse);
            string subscriptionId = Client.DefaultSubscription.Id.SubscriptionId;
            var expectTrue = await Client.GetSubscriptions().DoesExistAsync("/subscriptions/" + subscriptionId).ConfigureAwait(false);
            Assert.IsTrue(expectTrue);
        }
    }
}
