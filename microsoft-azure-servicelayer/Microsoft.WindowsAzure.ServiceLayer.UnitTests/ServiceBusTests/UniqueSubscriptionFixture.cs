using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Fixture for subscription messaging tests.
    /// </summary>
    public sealed class UniqueSubscriptionFixture : IDisposable
    {
        /// <summary>
        /// Gets the topic name.
        /// </summary>
        public string TopicName { get; private set; }

        /// <summary>
        /// Gets the subscription name.
        /// </summary>
        public string SubscriptionName { get; private set; }

        /// <summary>
        /// Constructor. Creates a topic/subscription pair with unique names.
        /// </summary>
        public UniqueSubscriptionFixture()
        {
            TopicName = Configuration.GetUniqueTopicName();
            SubscriptionName = Configuration.GetUniqueSubscriptionName();

            Configuration.ServiceBus.CreateTopicAsync(TopicName).AsTask().Wait();
            Configuration.ServiceBus.CreateSubscriptionAsync(TopicName, SubscriptionName).AsTask().Wait();
        }

        /// <summary>
        /// Disposes the fixture by removing the topic.
        /// </summary>
        void IDisposable.Dispose()
        {
            Configuration.ServiceBus.DeleteTopicAsync(TopicName).AsTask().Wait();
            TopicName = null;
            SubscriptionName = null;
        }
    }
}
