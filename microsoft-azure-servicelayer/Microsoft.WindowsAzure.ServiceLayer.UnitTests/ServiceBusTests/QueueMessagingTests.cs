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
    public sealed class QueueMessagingTests: MessagingTestsBase, IUseFixture<UniqueQueueFixture>
    {
        private string _queueName;                          // Shared queue.
        private MessageReceiver _receiver;                  // Receiver for queued messages.

        /// <summary>
        /// Gets the receiver.
        /// </summary>
        public override MessageReceiver Receiver { get { return _receiver; } }

        /// <summary>
        /// Sends a message to the queue.
        /// </summary>
        /// <param name="settings">Message to send.</param>
        protected override void SendMessage(BrokeredMessageSettings settings)
        {
            Configuration.ServiceBus.SendMessageAsync(_queueName, settings).AsTask().Wait();
        }
        // Assigns a fixture to the class.
        void IUseFixture<UniqueQueueFixture>.SetFixture(UniqueQueueFixture data)
        {
            _queueName = data.QueueName;
            _receiver = Configuration.ServiceBus.CreateMessageReceiver(_queueName);
        }

        /// <summary>
        /// Tests specifying invalid arguments in SendMessage call.
        /// </summary>
        [Fact]
        public void InvalidArgsInSendMessage()
        {
            BrokeredMessageSettings message = MessageHelper.CreateMessage("This is a test.");
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.SendMessageAsync(null, message));
            Assert.Throws<ArgumentException>(() => Configuration.ServiceBus.SendMessageAsync("", message));
            Assert.Throws<ArgumentException>(() => Configuration.ServiceBus.SendMessageAsync(" ", message));
            Assert.Throws<ArgumentNullException>(() => Configuration.ServiceBus.SendMessageAsync(_queueName, null));
        }

        /// <summary>
        /// Tests getting a message from a non-existing queue.
        /// </summary>
        [Fact]
        public void GetMessageFromNonExistingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();
            MessageReceiver receiver = Configuration.ServiceBus.CreateMessageReceiver(queueName);

            Assert.Throws<AggregateException>(() => receiver.GetMessageAsync(TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests peeking a message from a non-existing quuee.
        /// </summary>
        [Fact]
        public void PeekMessageFromNonExistingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();
            MessageReceiver receiver = Configuration.ServiceBus.CreateMessageReceiver(queueName);

            Assert.Throws<AggregateException>(() => receiver.PeekMessageAsync(TimeSpan.FromSeconds(10)).AsTask().Wait());
        }
    }
}
