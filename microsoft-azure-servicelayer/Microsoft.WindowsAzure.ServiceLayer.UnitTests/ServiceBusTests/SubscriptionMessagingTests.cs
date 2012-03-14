using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Unit tests for topic/subscription messaging.
    /// </summary>
    public sealed class SubscriptionMessagingTests: IUseFixture<UniqueSubscriptionFixture>
    {
        UniqueSubscriptionFixture _subscription;            // Unique topic/subscription fixture.

        /// <summary>
        /// Gets the topics name used in tests.
        /// </summary>
        private string TopicName 
        { 
            get { return _subscription.TopicName; } 
        }

        /// <summary>
        /// Gets the subscription name used in tests.
        /// </summary>
        private string SubscriptionName
        {
            get { return _subscription.SubscriptionName; }
        }

        /// <summary>
        /// Gets the service bus interface.
        /// </summary>
        private IServiceBusService ServiceBus
        {
            get { return Configuration.ServiceBus; }
        }

        /// <summary>
        /// Assigns fixture to the class.
        /// </summary>
        /// <param name="data">Fixture.</param>
        void IUseFixture<UniqueSubscriptionFixture>.SetFixture(UniqueSubscriptionFixture data)
        {
            _subscription = data;
        }

        /// <summary>
        /// Sends a text message with the given text to the topic.
        /// </summary>
        /// <param name="messageText">Message text.</param>
        /// <returns>Message settings.</returns>
        BrokeredMessageSettings SendTextMessage(string messageText)
        {
            BrokeredMessageSettings message = new BrokeredMessageSettings("text/plain", messageText);
            ServiceBus.SendMessageAsync(TopicName, message).AsTask().Wait();
            return message;
        }

        /// <summary>
        /// Tests passing invalid null arguments into methods.
        /// </summary>
        [Fact]
        public void NullArgs()
        {
            Assert.Throws<ArgumentNullException>(() => ServiceBus.PeekSubscriptionMessageAsync(null, "subscription", TimeSpan.FromSeconds(10)));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.PeekSubscriptionMessageAsync("topic", null, TimeSpan.FromSeconds(10)));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.GetSubscriptionMessageAsync(null, "subscription", TimeSpan.FromSeconds(10)));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.GetSubscriptionMessageAsync("topic", null, TimeSpan.FromSeconds(10)));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.UnlockSubscriptionMessageAsync(null, "subscription", 0, "lockToken"));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.UnlockSubscriptionMessageAsync("topic", null, 0, "lockToken"));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.UnlockSubscriptionMessageAsync("topic", "subscription", 0, null));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.DeleteSubscriptionMessageAsync(null, "subscription", 0, "lockToken"));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.DeleteSubscriptionMessageAsync("topic", null, 0, "lockToken"));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.DeleteSubscriptionMessageAsync("topic", "subscription", 0, null));
        }

        /// <summary>
        /// Tests getting a message from subscription (destructive reading).
        /// </summary>
        [Fact]
        public void GetMessage()
        {
            string messageText = Guid.NewGuid().ToString();
            SendTextMessage(messageText);

            BrokeredMessageInfo message = ServiceBus.GetSubscriptionMessageAsync(TopicName, SubscriptionName, TimeSpan.FromSeconds(10)).AsTask().Result;
            Assert.Equal(message.ReadContentAsStringAsync().AsTask().Result, messageText, StringComparer.Ordinal);

            // Reading the message should've removed it from the subscription.
            Assert.Throws<AggregateException>(() => ServiceBus.GetSubscriptionMessageAsync(TopicName, SubscriptionName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests peeking a message.
        /// </summary>
        [Fact]
        public void PeekMessage()
        {
            string messageText = Guid.NewGuid().ToString();
            SendTextMessage(messageText);

            // Peeking is a non-destructive operation; should work two times in a row.
            for (int i = 0; i < 2; i++)
            {
                BrokeredMessageInfo message = ServiceBus.PeekSubscriptionMessageAsync(TopicName, SubscriptionName, TimeSpan.FromSeconds(10)).AsTask().Result;
                Assert.Equal(messageText, message.ReadContentAsStringAsync().AsTask().Result, StringComparer.Ordinal);

                // Unlock the message.
                ServiceBus.UnlockSubscriptionMessageAsync(TopicName, SubscriptionName, message.SequenceNumber, message.LockToken).AsTask().Wait();
            }

            // Remove the message.
            ServiceBus.GetSubscriptionMessageAsync(TopicName, SubscriptionName, TimeSpan.FromSeconds(0)).AsTask().Wait();
        }

        /// <summary>
        /// Tests locking and deleting a message.
        /// </summary>
        [Fact]
        public void DeleteMessage()
        {
            string messageText = Guid.NewGuid().ToString();
            SendTextMessage(messageText);

            BrokeredMessageInfo message = ServiceBus.PeekSubscriptionMessageAsync(TopicName, SubscriptionName, TimeSpan.FromSeconds(10)).AsTask().Result;
            ServiceBus.DeleteSubscriptionMessageAsync(TopicName, SubscriptionName, message.SequenceNumber, message.LockToken).AsTask().Wait();

            Assert.Throws<AggregateException>(() => ServiceBus.GetSubscriptionMessageAsync(TopicName, SubscriptionName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }
    }
}
