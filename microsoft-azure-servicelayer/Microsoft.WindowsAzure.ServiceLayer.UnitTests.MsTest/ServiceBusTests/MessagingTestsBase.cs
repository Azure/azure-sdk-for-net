using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.ServiceLayer;
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.MsTest.ServiceBusTests
{
    /// <summary>
    /// Base class for messaging tests. All tests in this class assume single
    /// storage with support for the following operations: send, get, peek,
    /// lock, unock, and delete.
    /// </summary>
    public abstract class MessagingTestsBase
    {
        /// <summary>
        /// Gets the receiver for reading the messages.
        /// </summary>
        protected abstract MessageReceiver Receiver { get; }

        /// <summary>
        /// Sends a message, 
        /// </summary>
        /// <param name="settings">Message to send.</param>
        protected abstract void SendMessage(BrokeredMessageSettings settings);

        /// <summary>
        /// Gets a message from the queue.
        /// </summary>
        /// <returns>First queued message.</returns>
        protected BrokeredMessageInfo GetMessage(TimeSpan lockSpan)
        {
            return Receiver.GetMessageAsync(lockSpan).AsTask().Result;
        }

        /// <summary>
        /// Peeks a message from the queue.
        /// </summary>
        /// <returns>First queued message.</returns>
        protected BrokeredMessageInfo PeekMessage(TimeSpan lockSpan)
        {
            return Receiver.PeekMessageAsync(lockSpan).AsTask().Result;
        }

        /// <summary>
        /// Abandons previously locked message.
        /// </summary>
        /// <param name="message">Message to abandon.</param>
        protected void AbandonMessage(BrokeredMessageInfo message)
        {
            Receiver.AbandonMessageAsync(message).AsTask().Wait();
        }

        /// <summary>
        /// Deletes previously locked message.
        /// </summary>
        /// <param name="message">Message to delete.</param>
        protected void DeleteMessage(BrokeredMessageInfo message)
        {
            Receiver.DeleteMessageAsync(message).AsTask().Wait();
        }

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
            Assert.IsTrue(comparer.Equals(value, newValue));
        }

        /// <summary>
        /// Verifies preserving content type.
        /// </summary>
        [TestMethod]
        public void PreserveContentType()
        {
            string[] contentTypes = new string[] { "text/plain", "text/xml", };

            foreach (string contentType in contentTypes)
            {
                BrokeredMessageSettings settings = MessageHelper.CreateMessage(Guid.NewGuid().ToString(), contentType);
                SendMessage(settings);

                BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
                Assert.AreEqual(message.ContentType, contentType, false, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Tests preserving content text.
        /// </summary>
        [TestMethod]
        public void PreservingContentText()
        {
            string originalContent = Guid.NewGuid().ToString();
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(originalContent);
            SendMessage(settings);

            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
            string readContent = message.ReadContentAsStringAsync().AsTask().Result;
            Assert.AreEqual(originalContent, readContent, false, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Tests peeking a message.
        /// </summary>
        [TestMethod]
        public void PeekingMessage()
        {
            string originalContent = Guid.NewGuid().ToString();
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(originalContent);
            SendMessage(settings);

            BrokeredMessageInfo message = PeekMessage(TimeSpan.FromSeconds(10));
            string readContent = message.ReadContentAsStringAsync().AsTask().Result;
            Assert.AreEqual(originalContent, readContent, false, CultureInfo.InvariantCulture);

            // Delete message. This will fail if the message is not there.
            DeleteMessage(message);
        }

        /// <summary>
        /// Tests peeking a message from an empty queue.
        /// </summary>
        [TestMethod]
        public void PeekingMessageFromEmptyQueue()
        {
            Assert.ThrowsException<AggregateException>(() => PeekMessage(TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        /// Tests getting a message.
        /// </summary>
        [TestMethod]
        public void GettingMessage()
        {
            string originalContent = Guid.NewGuid().ToString();
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(originalContent);
            SendMessage(settings);

            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
            string readContent = message.ReadContentAsStringAsync().AsTask().Result;
            Assert.AreEqual(originalContent, readContent, false, CultureInfo.InvariantCulture);

            // Make sure nothing's left.
            Assert.ThrowsException<AggregateException>(() => PeekMessage(TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        /// Tests getting a message from an empty queue.
        /// </summary>
        [TestMethod]
        public void GettingMessageFromEmptyQueue()
        {
            Assert.ThrowsException<AggregateException>(() => GetMessage(TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        /// Tests deleting a message.
        /// </summary>
        [TestMethod]
        public void DeletingMessage()
        {
            BrokeredMessageSettings settings = MessageHelper.CreateMessage("This is a test.");
            SendMessage(settings);

            BrokeredMessageInfo message = PeekMessage(TimeSpan.FromSeconds(10));
            DeleteMessage(message);

            Assert.ThrowsException<AggregateException>(() => PeekMessage(TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        /// Tests specifying invalid arguments for DeleteMessage call.
        /// </summary>
        [TestMethod]
        public void InvalidArgsInDeleteMessage()
        {
            Assert.ThrowsException<ArgumentNullException>(() => DeleteMessage(null));
        }

        /// <summary>
        /// Tests unlocking a message.
        /// </summary>
        [TestMethod]
        public void AbandoningMessage()
        {
            BrokeredMessageSettings settings = MessageHelper.CreateMessage("This is a test.");
            SendMessage(settings);

            BrokeredMessageInfo message = PeekMessage(TimeSpan.FromSeconds(10));
            AbandonMessage(message);
            message = GetMessage(TimeSpan.FromSeconds(10));
            Assert.ThrowsException<AggregateException>(() => PeekMessage(TimeSpan.FromSeconds(10)));
        }

        /// <summary>
        /// Tests specifying invalid arguments for UnlockMessage call.
        /// </summary>
        [TestMethod]
        public void InvalidArgsInAbandonMessage()
        {
            Assert.ThrowsException<ArgumentNullException>(() => AbandonMessage(null));
        }

        /// <summary>
        /// Tests setting/getting message's CorrelationId property.
        /// </summary>
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
        public void PreserveBytes()
        {
            byte[] originalBytes = new byte[] { 1, 2, 3, 4, };
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(originalBytes);
            SendMessage(settings);
            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));

            List<byte> readBytes = new List<byte>(message.ReadContentAsBytesAsync().AsTask().Result);
            TestHelper.Equal(originalBytes, readBytes);
        }

        /// <summary>
        /// Tests sending and receiving a stream.
        /// </summary>
        [TestMethod]
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
                    Assert.AreEqual(cnt, readBytes.Length);
                    TestHelper.Equal(originalBytes, readBytes);

                    cnt = readStream.Read(readBytes, 0, 1);
                    Assert.AreEqual(cnt, 0);
                }
            }
        }

        /// <summary>
        /// Tests sending/receiving an empty string in the message content.
        /// </summary>
        [TestMethod]
        public void EmptyStringContent()
        {
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(string.Empty);
            SendMessage(settings);

            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
            string readText = message.ReadContentAsStringAsync().AsTask().Result;
            Assert.AreEqual(readText.Length, 0);
        }

        /// <summary>
        /// Tests sending/receiving an empty bytes array.
        /// </summary>
        [TestMethod]
        public void EmptyArrayContent()
        {
            byte[] originalBytes = new byte[0];
            BrokeredMessageSettings settings = MessageHelper.CreateMessage(originalBytes);
            SendMessage(settings);

            BrokeredMessageInfo message = GetMessage(TimeSpan.FromSeconds(10));
            List<byte> readBytes = new List<byte>(message.ReadContentAsBytesAsync().AsTask().Result);
            TestHelper.Equal(originalBytes, readBytes);
        }
    }
}
