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
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.MsTest.ServiceBusTests
{
    /// <summary>
    /// Runtime tests for queues.
    /// </summary>
    [TestClass]
    public sealed class QueueMessagingTests: MessagingTestsBase
    {
        private static string _queueName;                   // Shared queue.

        /// <summary>
        /// Initializes the environment for all tests in the class.
        /// </summary>
        /// <param name="context">Test context.</param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _queueName = Configuration.GetUniqueQueueName();
            Configuration.ServiceBus.CreateQueueAsync(_queueName).AsTask().Wait();
        }

        /// <summary>
        /// Cleans up the environment after running all tests in the class.
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanup()
        {
            Configuration.ServiceBus.DeleteQueueAsync(_queueName).AsTask().Wait();
            _queueName = null;
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
        /// Gets the first message in the queue.
        /// </summary>
        /// <param name="lockSpan">Lock interval.</param>
        /// <returns>Message.</returns>
        protected override BrokeredMessageInfo GetMessage(TimeSpan lockSpan)
        {
            return Configuration.ServiceBus.GetQueueMessageAsync(_queueName, lockSpan).AsTask().Result;
        }

        /// <summary>
        /// Peeks the first message in the queue.
        /// </summary>
        /// <param name="lockSpan">Lock interval.</param>
        /// <returns>Message.</returns>
        protected override BrokeredMessageInfo PeekMessage(TimeSpan lockSpan)
        {
            return Configuration.ServiceBus.PeekQueueMessageAsync(_queueName, lockSpan).AsTask().Result;
        }

        /// <summary>
        /// Unlocks given message.
        /// </summary>
        /// <param name="sequenceNumber">Sequence number of the locked message.</param>
        /// <param name="lockToken">Lock token of the locked message.</param>
        protected override void UnlockMessage(long sequenceNumber, string lockToken)
        {
            Configuration.ServiceBus.UnlockQueueMessageAsync(_queueName, sequenceNumber, lockToken).AsTask().Wait();
        }

        /// <summary>
        /// Deletes previously locked message.
        /// </summary>
        /// <param name="sequenceNumber">Sequence number of the locked message.</param>
        /// <param name="lockToken">Lock token of the locked message.</param>
        protected override void DeleteMessage(long sequenceNumber, string lockToken)
        {
            Configuration.ServiceBus.DeleteQueueMessageAsync(_queueName, sequenceNumber, lockToken).AsTask().Wait();
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

            Assert.ThrowsException<AggregateException>(() => Configuration.ServiceBus.GetQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests peeking a message from a non-existing quuee.
        /// </summary>
        [TestMethod]
        public void PeekMessageFromNonExistingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();

            Assert.ThrowsException<AggregateException>(() => Configuration.ServiceBus.PeekQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }
    }
}
