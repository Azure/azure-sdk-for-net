using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer;
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Base class for messaging tests. All tests in this class assume single
    /// storage with support for the following operations: send, get, peek,
    /// lock, unock, and delete.
    /// </summary>
    public abstract class MessagingTestsBase
    {
        /// <summary>
        /// Sends a message, 
        /// </summary>
        /// <param name="settings">Message to send.</param>
        protected abstract void SendMessage(BrokeredMessageSettings settings);

        /// <summary>
        /// Gets a message from the queue.
        /// </summary>
        /// <returns>First queued message.</returns>
        protected abstract BrokeredMessageInfo GetMessage(TimeSpan lockSpan);

        /// <summary>
        /// Peeks a message from the queue.
        /// </summary>
        /// <returns>First queued message.</returns>
        protected abstract BrokeredMessageInfo PeekMessage(TimeSpan lockSpan);

        /// <summary>
        /// Unlocks previously locked message.
        /// </summary>
        /// <param name="sequenceNumber">Sequence number of the locked message.</param>
        /// <param name="lockToken">Lock token of the locked message.</param>
        protected abstract void UnlockMessage(long sequenceNumber, string lockToken);

        /// <summary>
        /// Deletes previously locked message.
        /// </summary>
        /// <param name="sequenceNumber">Sequence number of the locked message.</param>
        /// <param name="lockToken">Lock token of the locked message.</param>
        protected abstract void DeleteMessage(long sequenceNumber, string lockToken);

        /// <summary>
        /// Tests setting and reading a property.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="value">Property value.</param>
        /// <param name="setValue">Method for setting the value.</param>
        /// <param name="getValue">Method for getting the value.</param>
        /// <param name="comparer">Comparer for values.</param>
        protected void TestSetProperty<T>(
            T value,
            Action<BrokeredMessageSettings, T> setValue,
            Func<BrokeredMessageInfo, T> getValue,
            IEqualityComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            // Create a message.
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(Guid.NewGuid().ToString());

            // Set the requested property.
            setValue(settings, value);

            // Send the message to the queue.
            SendMessage(settings);

            // Get the message and compare properties.
            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
            T newValue = getValue(message);
            Assert.Equal(value, newValue, comparer);
        }

        /// <summary>
        /// Verifies preserving content type.
        /// </summary>
        [Fact]
        public void PreserveContentType()
        {
            string[] contentTypes = new string[] { "text/plain", "text/xml", };

            foreach (string contentType in contentTypes)
            {
                BrokeredMessageSettings settings = MessageHelper.CreateMessage(Guid.NewGuid().ToString(), contentType);
                SendMessage(settings);

                BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
                Assert.Equal(message.ContentType, contentType, StringComparer.Ordinal);
            }
        }

        /// <summary>
        /// Tests preserving content text.
        /// </summary>
        [Fact]
        public void PreservingContentText()
        {
            string originalContent = Guid.NewGuid().ToString();
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(originalContent);
            SendMessage(settings);

            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
            string readContent = message.ReadContentAsStringAsync().AsTask().Result;
            Assert.Equal(originalContent, readContent, StringComparer.Ordinal);
        }

        /// <summary>
        /// Tests peeking a message.
        /// </summary>
        [Fact]
        public void PeekingMessage()
        {
            string originalContent = Guid.NewGuid().ToString();
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(originalContent);
            SendMessage(settings);

            BrokeredMessageInfo message = PeekMessage(TimeSpan.FromSeconds(10));
            string readContent = message.ReadContentAsStringAsync().AsTask().Result;
            Assert.Equal(originalContent, readContent, StringComparer.Ordinal);

            // Delete message. This will fail if the message is not there.
            DeleteMessage(message.SequenceNumber, message.LockToken);
        }

        /// <summary>
        /// Tests peeking a message from an empty queue.
        /// </summary>
        [Fact]
        public void PeekingMessageFromEmptyQueue()
        {
            Assert.Throws<AggregateException>(() => PeekMessage(TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        /// Tests getting a message.
        /// </summary>
        [Fact]
        public void GettingMessage()
        {
            string originalContent = Guid.NewGuid().ToString();
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(originalContent);
            SendMessage(settings);

            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
            string readContent = message.ReadContentAsStringAsync().AsTask().Result;
            Assert.Equal(originalContent, readContent, StringComparer.Ordinal);

            // Make sure nothing's left.
            Assert.Throws<AggregateException>(() => PeekMessage(TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        /// Tests getting a message from an empty queue.
        /// </summary>
        [Fact]
        public void GettingMessageFromEmptyQueue()
        {
            Assert.Throws<AggregateException>(() => GetMessage(TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        /// Tests deleting a message.
        /// </summary>
        [Fact]
        public void DeletingMessage()
        {
            BrokeredMessageSettings settings = MessageHelper.CreateMessage("This is a test.");
            SendMessage(settings);

            BrokeredMessageInfo message = PeekMessage(TimeSpan.FromSeconds(10));
            DeleteMessage(message.SequenceNumber, message.LockToken);

            Assert.Throws<AggregateException>(() => PeekMessage(TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        /// Tests specifying invalid arguments for DeleteMessage call.
        /// </summary>
        [Fact]
        public void InvalidArgsInDeleteMessage()
        {
            Assert.Throws<ArgumentNullException>(() => DeleteMessage(0, null));
            Assert.Throws<ArgumentException>(() => DeleteMessage(0, ""));
        }

        /// <summary>
        /// Tests unlocking a message.
        /// </summary>
        [Fact]
        public void UnlockingMessage()
        {
            BrokeredMessageSettings settings = MessageHelper.CreateMessage("This is a test.");
            SendMessage(settings);

            BrokeredMessageInfo message = PeekMessage(TimeSpan.FromSeconds(10));
            UnlockMessage(message.SequenceNumber, message.LockToken);
            message = GetMessage(TimeSpan.FromSeconds(10));
            Assert.Throws<AggregateException>(() => PeekMessage(TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        /// Tests specifying invalid arguments for UnlockMessage call.
        /// </summary>
        [Fact]
        public void InvalidArgsInUnlockMessage()
        {
            Assert.Throws<ArgumentNullException>(() => UnlockMessage(0, null));
            Assert.Throws<ArgumentException>(() => UnlockMessage(0, ""));
        }

        /// <summary>
        /// Tests setting/getting message's CorrelationId property.
        /// </summary>
        [Fact]
        public void SetCorrelationId()
        {
            TestSetProperty(
                "correlationId",
                (message, value) => { message.CorrelationId = value; },
                (message) => message.CorrelationId,
                StringComparer.Ordinal);
        }

        /// <summary>
        /// Tests setting/getting message's Label property.
        /// </summary>
        [Fact]
        public void SetLabel()
        {
            TestSetProperty(
                "TestLabel",
                (message, value) => { message.Label = value; },
                (message) => message.Label,
                StringComparer.Ordinal);
        }

        /// <summary>
        /// Tests setting/getting MessaqgeId property.
        /// </summary>
        [Fact]
        public void SetMessageId()
        {
            TestSetProperty(
                "TestMessageId",
                (message, value) => { message.MessageId = value; },
                (message) => message.MessageId,
                StringComparer.Ordinal);
        }

        /// <summary>
        /// Tests setting ReplyTo property.
        /// </summary>
        [Fact]
        public void SetReplyTo()
        {
            TestSetProperty(
                "testReplyTo",
                (message, value) => { message.ReplyTo = value; },
                (message) => message.ReplyTo,
                StringComparer.Ordinal);
        }

        /// <summary>
        /// Tests setting ReplyToSessionId property.
        /// </summary>
        [Fact]
        public void SetReplyToSessionId()
        {
            TestSetProperty(
                "testReplyToSessionId",
                (message, value) => { message.ReplyToSessionId = value; },
                (message) => message.ReplyToSessionId,
                StringComparer.Ordinal);
        }

        /// <summary>
        /// Tests setting SessionId property.
        /// </summary>
        [Fact]
        public void SetSessionId()
        {
            TestSetProperty(
                "testSessionId",
                (message, value) => { message.SessionId = value; },
                (message) => message.SessionId,
                StringComparer.Ordinal);
        }

        /// <summary>
        /// Tests setting TimeToLive property.
        /// </summary>
        [Fact]
        public void SetTimeToLive()
        {
            TestSetProperty(
                TimeSpan.FromDays(2),
                (message, value) => { message.TimeToLive = value; },
                (message) => message.TimeToLive.Value);
        }

        /// <summary>
        /// Tests setting To property.
        /// </summary>
        [Fact]
        public void SetTo()
        {
            TestSetProperty(
                "testTo",
                (message, value) => { message.To = value; },
                (message) => message.To,
                StringComparer.Ordinal);
        }

        /// <summary>
        /// Tests sending and receiving an array of bytes.
        /// </summary>
        [Fact]
        public void PreserveBytes()
        {
            byte[] originalBytes = new byte[] { 1, 2, 3, 4, };
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(originalBytes);
            SendMessage(settings);
            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));

            List<byte> readBytes = new List<byte>(message.ReadContentAsBytesAsync().AsTask().Result);
            Assert.Equal(originalBytes, readBytes);
        }

        /// <summary>
        /// Tests sending and receiving a stream.
        /// </summary>
        [Fact]
        public void PreserveStream()
        {
            byte[] originalBytes = new byte[] { 5, 4, 3, 2, 1, };
            using (MemoryStream stream = new MemoryStream(originalBytes))
            {
                BrokeredMessageSettings settings = MessageHelper.CreateMessage(stream);
                SendMessage(settings);
                BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));

                using (Stream readStream = message.ReadContentAsStreamAsync().AsTask().Result.AsStreamForRead())
                {
                    byte[] readBytes = new byte[originalBytes.Length];
                    int cnt = readStream.Read(readBytes, 0, originalBytes.Length);
                    Assert.Equal(cnt, readBytes.Length);
                    Assert.Equal(originalBytes, readBytes);

                    cnt = readStream.Read(readBytes, 0, 1);
                    Assert.Equal(cnt, 0);
                }
            }
        }

        /// <summary>
        /// Tests sending/receiving an empty string in the message content.
        /// </summary>
        [Fact]
        public void EmptyStringContent()
        {
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(string.Empty);
            SendMessage(settings);

            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
            string readText = message.ReadContentAsStringAsync().AsTask().Result;
            Assert.Equal(readText.Length, 0);
        }

        /// <summary>
        /// Tests sending/receiving an empty bytes array.
        /// </summary>
        [Fact]
        public void EmptyArrayContent()
        {
            byte[] originalBytes = new byte[0];
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(originalBytes);
            SendMessage(settings);

            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
            List<byte> readBytes = new List<byte>(message.ReadContentAsBytesAsync().AsTask().Result);
            Assert.Equal(originalBytes, readBytes);
        }
    }
}
