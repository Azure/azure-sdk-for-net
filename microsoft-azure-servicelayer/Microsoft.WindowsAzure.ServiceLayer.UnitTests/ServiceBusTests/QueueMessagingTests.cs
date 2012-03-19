﻿//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Runtime tests for queues.
    /// </summary>
    public sealed class QueueMessagingTests
    {
        /// <summary>
        /// Tests setting and reading a property.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="value">Property value.</param>
        /// <param name="setValue">Method for setting the value.</param>
        /// <param name="getValue">Method for getting the value.</param>
        /// <param name="comparer">Comparer for values.</param>
        private void TestSetProperty<T>(
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
            string messageText = Guid.NewGuid().ToString();
            BrokeredMessageSettings messageSettings = BrokeredMessageSettings.CreateFromText("text/plain", messageText);

            // Set the requested property.
            setValue(messageSettings, value);

            // Send the message to the queue.
            string queueName = UsesUniqueQueueAttribute.QueueName;
            Configuration.ServiceBus.SendMessageAsync(queueName, messageSettings).AsTask().Wait();
            BrokeredMessageInfo message = Configuration.ServiceBus.GetQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Result;
            T newValue = getValue(message);

            Assert.Equal(value, newValue, comparer);
        }


        /// <summary>
        /// Tests getting a message from the queue.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void PeekMessage()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;
            string text = Guid.NewGuid().ToString();
            BrokeredMessageSettings messageSettings = BrokeredMessageSettings.CreateFromText("text/plain", text);

            BrokeredMessageInfo message = Configuration.ServiceBus.SendMessageAsync(queueName, messageSettings)
                .AsTask()
                .ContinueWith((t) => Configuration.ServiceBus.PeekQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Result, TaskContinuationOptions.OnlyOnRanToCompletion)
                .Result;

            string newText = message.ReadContentAsStringAsync().AsTask().Result;

            Assert.Equal(text, newText, StringComparer.Ordinal);

            // Make sure the message is still there.
            QueueInfo info = Configuration.ServiceBus.GetQueueAsync(queueName).AsTask().Result;
            Assert.Equal(info.MessageCount, 1);
        }

        /// <summary>
        /// Tests getting a message from the queue.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void GetMessage()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;
            string text = Guid.NewGuid().ToString();
            BrokeredMessageSettings messageSettings = BrokeredMessageSettings.CreateFromText("text/html", text);

            BrokeredMessageInfo message = Configuration.ServiceBus.SendMessageAsync(queueName, messageSettings)
                .AsTask()
                .ContinueWith((t) => Configuration.ServiceBus.GetQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Result, TaskContinuationOptions.OnlyOnRanToCompletion)
                .Result;
            string newText = message.ReadContentAsStringAsync().AsTask().Result;

            Assert.Equal(newText, text, StringComparer.Ordinal);

            // Make sure the message disappeared.
            QueueInfo info = Configuration.ServiceBus.GetQueueAsync(queueName).AsTask().Result;
            Assert.Equal(info.MessageCount, 0);
        }

        /// <summary>
        /// Tests getting a message from an empty queue.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void GetMessageFromEmptyQueue()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;

            Assert.Throws<AggregateException>(() => Configuration.ServiceBus.GetQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests deleting a message from the queue.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void DeleteMessage()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;

            BrokeredMessageSettings messageSettings = BrokeredMessageSettings.CreateFromText("text/plain", "This is only a test.");
            Configuration.ServiceBus.SendMessageAsync(queueName, messageSettings).AsTask().Wait();
            BrokeredMessageInfo message = Configuration.ServiceBus.PeekQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Result;
            Configuration.ServiceBus.DeleteQueueMessageAsync(queueName, message.SequenceNumber, message.LockToken).AsTask().Wait();

            QueueInfo info = Configuration.ServiceBus.GetQueueAsync(queueName).AsTask().Result;
            Assert.Equal(info.MessageCount, 0);
        }

        /// <summary>
        /// Tests peeking a message from a non-existing queue.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void PeekMessageFromEmptyQueue()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;
            BrokeredMessageInfo message = Configuration.ServiceBus.PeekQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Result;
            Assert.Null(message);
        }

        /// <summary>
        /// Tests getting a message from a non-existing queue.
        /// </summary>
        [Fact]
        public void GetMessageFromNonExistingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();

            Assert.Throws<AggregateException>(() => Configuration.ServiceBus.GetQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests peeking a message from a non-existing quuee.
        /// </summary>
        [Fact]
        public void PeekMessageFromNonExistingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();

            Assert.Throws<AggregateException>(() => Configuration.ServiceBus.PeekQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests null reference exceptions in queue methods.
        /// </summary>
        [Fact]
        public void NullArgsInQueueMessages()
        {
            BrokeredMessageSettings validMessageSettings = BrokeredMessageSettings.CreateFromText("test/plain", "This is a test");
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.SendMessageAsync(null, validMessageSettings));
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.SendMessageAsync("somename", null));
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.GetQueueMessageAsync(null, TimeSpan.FromSeconds(10)));
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.PeekQueueMessageAsync(null, TimeSpan.FromSeconds(10)));
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.UnlockQueueMessageAsync(null, 0, "test"));
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.UnlockQueueMessageAsync("test", 0, null));
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.DeleteQueueMessageAsync(null, 0, "test"));
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.DeleteQueueMessageAsync("test", 0, null));
        }

        /// <summary>
        /// Tests setting/getting message's CorrelationId property.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
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
        [UsesUniqueQueue]
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
        [UsesUniqueQueue]
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
        [UsesUniqueQueue]
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
        [UsesUniqueQueue]
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
        [UsesUniqueQueue]
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
        [UsesUniqueQueue]
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
        [UsesUniqueQueue]
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
        [UsesUniqueQueue]
        public void SendBytes()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;
            byte[] bytes = new byte[] { 1, 2, 3, };
            BrokeredMessageSettings settings = BrokeredMessageSettings.CreateFromBytes(bytes);
            Configuration.ServiceBus.SendMessageAsync(queueName, settings).AsTask().Wait();

            BrokeredMessageInfo message = Configuration.ServiceBus.GetQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Result;

            // Do that twice to make sure stream positions are preserved.
            for (int i = 0; i < 2; i++)
            {
                List<byte> newBytes = new List<byte>(message.ReadContentAsBytesAsync().AsTask().Result);
                Assert.Equal(bytes, newBytes.ToArray());
            }
        }

        /// <summary>
        /// Tests sending a stream of bytes.
        /// </summary>
        [Fact(Skip="Doesn't work with .Net libraries; disabling for now.")]
        [UsesUniqueQueue]
        public void SendStream()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;
            byte[] inBytes = new byte[] { 1, 2, 3, 4, };

            using (MemoryStream inStream = new MemoryStream())
            {
                inStream.Write(inBytes, 0, inBytes.Length);
                inStream.Flush();
                inStream.Position = 0;

                BrokeredMessageSettings settings = BrokeredMessageSettings.CreateFromStream(inStream.AsInputStream());
                Configuration.ServiceBus.SendMessageAsync(queueName, settings).AsTask().Wait();
            }

            BrokeredMessageInfo message = Configuration.ServiceBus.GetQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Result;

            for (int i = 0; i < 2; i++)
            {
                using (Stream stream = message.ReadContentAsStreamAsync().AsTask().Result.AsStreamForRead())
                {
                    byte[] outBytes = new byte[4];
                    int cnt = stream.Read(outBytes, 0, 4);
                    Assert.Equal(cnt, 4);
                    Assert.Equal(inBytes, outBytes);
                }
            }
        }
    }
}
