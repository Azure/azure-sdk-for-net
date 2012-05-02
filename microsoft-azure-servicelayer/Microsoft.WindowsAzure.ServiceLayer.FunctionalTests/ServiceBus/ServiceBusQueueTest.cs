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
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.ServiceLayer;
using Microsoft.WindowsAzure.ServiceLayer.Http;
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;

namespace Microsoft.WindowsAzure.ServiceLayer.FunctionalTests
{
    [TestClass]
    /// <summary>
    /// Functional Tests for the service bus management.
    /// </summary>
    public class ServiceBusQueueTest
    {
        private string _queueName = "functionaltestWinMDQueue";
        private QueueSettings _sendQueueSettings;
        private int _noOfMessageToSend = 2;
        private ServiceBusClient Service { get { return Configuration.ServiceBus; } }

        /// <summary>
        /// Test Initialize.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            //cleanup if queue already exists.
            Cleanup();
        }

        /// <summary>
        /// Test Queue send and receive wait for completion.
        /// </summary>
        [TestMethod]
        public void SendAndReceive()
        {
            SendAndReceiveAsync().Wait();
        }

        /// <summary>
        /// Test Queue send and receive async.
        /// </summary>
        async Task SendAndReceiveAsync()
        {
            await SendMessageAsync();
            await ReceiveMessageAsync();
        }

        /// <summary>
        /// Send message async.
        /// </summary>
        async internal Task SendMessageAsync()
        {
            if (Service == null)
            {
                Assert.Fail("Unexpected error, creation of service bus service returned null");
                return;
            }
            _sendQueueSettings = new QueueSettings();
            _sendQueueSettings.MaximumSizeInMegabytes = 1024;
            _sendQueueSettings.RequiresDuplicateDetection = true;
            _sendQueueSettings.RequiresSession = false;
            await Service.CreateQueueAsync(_queueName, _sendQueueSettings);
            List<BrokeredMessageSettings> messageList = new List<BrokeredMessageSettings>();
            for (int i = 0; i < _noOfMessageToSend; i++)
            {
                BrokeredMessageSettings message = BrokeredMessageSettings.CreateFromText("message" + i);
                message.Properties["id"] = i;
                message.Label = "label" + i;
                messageList.Add(message);
            }
            foreach (BrokeredMessageSettings message in messageList)
            {
                await Service.SendMessageAsync(_queueName, message);
            }
        }

        /// <summary>
        /// Receive message and verify async.
        /// </summary>
        async internal Task ReceiveMessageAsync()
        {
            QueueDescription queue = await Service.GetQueueAsync(_queueName);
            //check if we got the properties of the queue back correctly.
            Assert.AreEqual(queue.MaximumSizeInMegabytes, _sendQueueSettings.MaximumSizeInMegabytes, "MaximumSizeinMegabytes value received doesn't match the value that was sent earlier");
            Assert.AreEqual(queue.RequiresDuplicateDetection, _sendQueueSettings.RequiresDuplicateDetection, "RequiresDuplicateDetection value received doesn't match the value that was sent earlier");
            Assert.AreEqual(queue.MessageCount, _noOfMessageToSend, "Messagecount value received for the queue doesn't match the number of messages sent earlier");
            MessageReceiver messageReceiver = Service.CreateMessageReceiver(_queueName);
            for (int i = 0; i < queue.MessageCount; i++)
            {
                BrokeredMessageDescription message = await messageReceiver.PeekMessageAsync(new TimeSpan(1000));
                //check we got the properties of the the message back correctly.
                Assert.AreEqual(Convert.ToInt32(message.Properties["id"]), i, "Message custom property 'id' value received doesn't match what was sent earlier");
                Assert.AreEqual(message.Label, "label" + i, "Message label property value received doesn't match what was sent earlier");
                Assert.AreEqual(await message.ReadContentAsStringAsync(), "message" + i, "Message content value received doesn't match what was sent earlier");
            }
        }

        /// <summary>
        /// cleanup the queue created wait for completion.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                CleanupAsync().Wait();
            }
            catch (AggregateException ex)
            {

            }
        }

        /// <summary>
        /// cleanup the queue async
        /// </summary>
        async internal Task CleanupAsync()
        {
            await Service.DeleteQueueAsync(_queueName);
        }
    }
}
