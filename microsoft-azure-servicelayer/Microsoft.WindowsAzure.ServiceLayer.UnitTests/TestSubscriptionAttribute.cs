using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests
{
    /// <summary>
    /// Creates a topic/subscription pair for a test marked with this attribute.
    /// </summary>
    public class TestSubscriptionAttribute: BeforeAfterTestAttribute
    {
        public TestSubscriptionAttribute()
        {
            TopicName = string.Format(CultureInfo.InvariantCulture, "Test.{0}", Guid.NewGuid());
            SubscriptionName = string.Format(CultureInfo.InvariantCulture, "Subscription.{0}", Guid.NewGuid());
        }

        public TestSubscriptionAttribute(string topicName, string subscriptionName)
        {
            TopicName = topicName;
            SubscriptionName = subscriptionName;
        }

        /// <summary>
        /// Gets the topic name.
        /// </summary>
        public static string TopicName { get; private set; }

        /// <summary>
        /// Gets the subscription name.
        /// </summary>
        public static string SubscriptionName { get; private set; }

        /// <summary>
        /// Runs before the test.
        /// </summary>
        /// <param name="methodUnderTest">Test method.</param>
        public override void Before(MethodInfo methodUnderTest)
        {
            try
            {
                Configuration.ServiceBus.CreateTopicAsync(TopicName).AsTask().Wait();
            }
            catch
            {
                // Do nothing.
            }

            try
            {
                Configuration.ServiceBus.CreateSubscriptionAsync(TopicName, SubscriptionName).AsTask().Wait();
            }
            catch
            {
                // Do nothing.
            }
        }

        /// <summary>
        /// Runs after the test.
        /// </summary>
        /// <param name="methodUnderTest">Test method.</param>
        public override void After(MethodInfo methodUnderTest)
        {
            try 
            {
                Configuration.ServiceBus.DeleteSubscriptionAsync(TopicName, SubscriptionName).AsTask().Wait();
            }
            catch
            {
                // Do nothing.
            }

            try
            {
                Configuration.ServiceBus.DeleteTopicAsync(TopicName).AsTask().Wait();
            }
            catch
            {
                // Do nothing.
            }
        }
    }
}
