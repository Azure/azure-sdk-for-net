
using Microsoft.AzureStack.Management.Commerce.Admin;
using Microsoft.AzureStack.TestFramework;
using Xunit;

namespace Commerce.Tests
{

    public class CommerceTestBase : TestBase<CommerceAdminClient>
    {
        public CommerceTestBase()
        {
            // Empty
        }

        protected override void ValidateClient(CommerceAdminClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.SubscriberUsageAggregates);
            Assert.NotNull(client.SubscriptionId);
        }
    }
}
