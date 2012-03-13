using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Creates a unique topic subscription for the test method.
    /// </summary>
    public sealed class UsesUniqueSubscriptionAttribute: BeforeAfterTestAttribute
    {
        /// <summary>
        /// Gets the topic name.
        /// </summary>
        public static string TopicName { get; private set; }

        /// <summary>
        /// Gets the subscription name.
        /// </summary>
        public static string SubscriptionName { get; private set; }

        /// <summary>
        /// Creates a topic/subscription pair.
        /// </summary>
        /// <param name="methodUnderTest">Test method.</param>
        public override void Before(MethodInfo methodUnderTest)
        {
            base.Before(methodUnderTest);
            TopicName = Configuration.GetUniqueTopicName();
            SubscriptionName = Configuration.GetUniqueSubscriptionName();

            Configuration.ServiceBus.CreateTopicAsync(TopicName).AsTask()
                .ContinueWith((r) => Configuration.ServiceBus.CreateSubscriptionAsync(TopicName, SubscriptionName).AsTask().Wait())
                .Wait();
        }

        /// <summary>
        /// Deletes topic with the subscription.
        /// </summary>
        /// <param name="methodUnderTest">Test method.</param>
        public override void After(MethodInfo methodUnderTest)
        {
            base.After(methodUnderTest);
            Configuration.ServiceBus.DeleteTopicAsync(TopicName).AsTask().Wait();
            TopicName = null;
            SubscriptionName = null;
        }
    }
}
