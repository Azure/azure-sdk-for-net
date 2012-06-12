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
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Services.ServiceBus;

namespace Microsoft.WindowsAzure.Services.ServiceBus.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Runtime tests for queues.
    /// </summary>
    [TestClass]
    public sealed class QueueMessagingTests: MessagingTestsBase
    {
        private static string _queueName;                   // Shared queue.
        private static MessageReceiver _receiver;           // Shared receiver for messages in the queue.

        /// <summary>
        /// Gets the receiver used in tests.
        /// </summary>
        protected override MessageReceiver Receiver { get { return _receiver; } }

        /// <summary>
        /// Initializes the environment for all tests in the class.
        /// </summary>
        /// <param name="context">Test context.</param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _queueName = Configuration.GetUniqueQueueName();
            Configuration.ServiceBus.CreateQueueAsync(_queueName).AsTask().Wait();
            _receiver = Configuration.ServiceBus.CreateMessageReceiver(_queueName);
        }

        /// <summary>
        /// Cleans up the environment after running all tests in the class.
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanup()
        {
            Configuration.ServiceBus.DeleteQueueAsync(_queueName).AsTask().Wait();
            _queueName = null;
            _receiver = null;
        }


        /// <summary>
        /// Sends a message to the queue.
        /// </summary>
        /// <param name="settings">Message to send.</param>
        protected override void SendMessage(BrokeredMessageSettings settings)
        {
            Configuration.ServiceBus.SendMessageAsync(_queueName, settings).AsTask().Wait();
        }

        /// <summary>
        /// Tests specifying invalid arguments in SendMessage call.
        /// </summary>
        [TestMethod]
        public void InvalidArgsInSendMessage()
        {
            BrokeredMessageSettings message = MessageHelper.CreateMessage("This is a test.");
            Assert.ThrowsException<ArgumentNullException>(() => Configuration.ServiceBus.SendMessageAsync(null, message));
            Assert.ThrowsException<ArgumentException>(() => Configuration.ServiceBus.SendMessageAsync("", message));
            Assert.ThrowsException<ArgumentException>(() => Configuration.ServiceBus.SendMessageAsync(" ", message));
            Assert.ThrowsException<ArgumentNullException>(() => Configuration.ServiceBus.SendMessageAsync(_queueName, null));
        }

        /// <summary>
        /// Tests getting a message from a non-existing queue.
        /// </summary>
        [TestMethod]
        public void GetMessageFromNonExistingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();
            MessageReceiver receiver = Configuration.ServiceBus.CreateMessageReceiver(queueName);

            Assert.ThrowsException<AggregateException>(() => receiver.GetMessageAsync(TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests peeking a message from a non-existing quuee.
        /// </summary>
        [TestMethod]
        public void PeekMessageFromNonExistingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();
            MessageReceiver receiver = Configuration.ServiceBus.CreateMessageReceiver(queueName);

            Assert.ThrowsException<AggregateException>(() => _receiver.PeekMessageAsync(TimeSpan.FromSeconds(10)).AsTask().Wait());
        }
    }
}
