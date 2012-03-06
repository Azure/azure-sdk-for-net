//
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
        /// Tests getting a message from the queue.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void PeekMessage()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;
            string text = Guid.NewGuid().ToString();
            BrokeredMessageSettings messageSettings = new BrokeredMessageSettings(text);

            BrokeredMessageInfo message = Configuration.ServiceBus.SendMessageAsync(queueName, messageSettings)
                .AsTask()
                .ContinueWith((t) => Configuration.ServiceBus.PeekMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Result, TaskContinuationOptions.OnlyOnRanToCompletion)
                .Result;

            Assert.Equal(message.Text, text, StringComparer.Ordinal);

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
            BrokeredMessageSettings messageSettings = new BrokeredMessageSettings(text);

            BrokeredMessageInfo message = Configuration.ServiceBus.SendMessageAsync(queueName, messageSettings)
                .AsTask()
                .ContinueWith((t) => Configuration.ServiceBus.GetMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Result, TaskContinuationOptions.OnlyOnRanToCompletion)
                .Result;

            Assert.Equal(message.Text, text, StringComparer.Ordinal);

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

            Assert.Throws<AggregateException>(() => Configuration.ServiceBus.GetMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests deleting a message from the queue.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void DeleteMessage()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;

            BrokeredMessageSettings messageSettings = new BrokeredMessageSettings("This is only a test.");
            Configuration.ServiceBus.SendMessageAsync(queueName, messageSettings)
                .AsTask()
                .ContinueWith<BrokeredMessageInfo>((tr) => Configuration.ServiceBus.PeekMessageAsync(queueName, TimeSpan.FromSeconds(60)).AsTask().Result, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith((tr) => Configuration.ServiceBus.DeleteMessageAsync(queueName, tr.Result.SequenceNumber, tr.Result.LockId), TaskContinuationOptions.OnlyOnRanToCompletion);

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

            Assert.Throws<AggregateException>(() => Configuration.ServiceBus.PeekMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests getting a message from a non-existing queue.
        /// </summary>
        [Fact]
        public void GetMessageFromNonExistingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();

            Assert.Throws<AggregateException>(() => Configuration.ServiceBus.GetMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests peeking a message from a non-existing quuee.
        /// </summary>
        [Fact]
        public void PeekMessageFromNonExistingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();

            Assert.Throws<AggregateException>(() => Configuration.ServiceBus.PeekMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }
    }
}
