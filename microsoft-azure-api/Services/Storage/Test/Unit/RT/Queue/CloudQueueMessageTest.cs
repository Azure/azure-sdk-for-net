// -----------------------------------------------------------------------------------------
// <copyright file="CloudQueueMessageTest.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Queue
{
    [TestClass]
    public class CloudQueueMessageTest : QueueTestBase
    {
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (TestBase.QueueBufferManager != null)
            {
                TestBase.QueueBufferManager.OutstandingBufferCount = 0;
            }
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (TestBase.QueueBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.QueueBufferManager.OutstandingBufferCount);
            }
        }

        [TestMethod]
        // [Description("Test CloudQueueMessage constructor.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueCreateMessageAsync()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            try
            {
                await queue.CreateIfNotExistsAsync();

                CloudQueueMessage message = new CloudQueueMessage(Guid.NewGuid().ToString());
                await queue.AddMessageAsync(message);

                CloudQueueMessage retrMessage = await queue.GetMessageAsync();
                string messageId = retrMessage.Id;
                string popReceipt = retrMessage.PopReceipt;

                // Recreate the message using the messageId and popReceipt.
                CloudQueueMessage newMessage = new CloudQueueMessage(messageId, popReceipt);
                Assert.AreEqual(messageId, newMessage.Id);
                Assert.AreEqual(popReceipt, newMessage.PopReceipt);

                await queue.UpdateMessageAsync(newMessage, TimeSpan.FromSeconds(30), MessageUpdateFields.Visibility);
                CloudQueueMessage retrMessage2 = await queue.GetMessageAsync();
                Assert.AreEqual(null, retrMessage2);
            }
            finally
            {
                queue.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Test add/update/get/delete message")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueMessageBasicOperation()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            await queue.CreateAsync();

            await queue.AddMessageAsync(new CloudQueueMessage("abcde"));

            CloudQueueMessage receivedMessage1 = await queue.GetMessageAsync();

            receivedMessage1.SetMessageContent(Guid.NewGuid().ToString("N"));
            await queue.UpdateMessageAsync(receivedMessage1, null, MessageUpdateFields.Content);

            await queue.DeleteMessageAsync(receivedMessage1);
        }

        [TestMethod]
        /// [Description("Test add/delete message")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueMessageAddDelete()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            await queue.CreateAsync();

            await queue.AddMessageAsync(new CloudQueueMessage("abcde"));

            CloudQueueMessage receivedMessage1 = await queue.GetMessageAsync();

            await queue.DeleteMessageAsync(receivedMessage1.Id, receivedMessage1.PopReceipt);

            CloudQueueMessage receivedMessage2 = await queue.GetMessageAsync();
            Assert.IsNull(receivedMessage2);
        }

        [TestMethod]
        //[Description("Test whether get message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueGetMessageAsync()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            await queue.CreateAsync();

            CloudQueueMessage emptyMessage = await queue.GetMessageAsync();
            Assert.IsNull(emptyMessage);

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            await queue.AddMessageAsync(message);
            CloudQueueMessage receivedMessage1 = await queue.GetMessageAsync();

            Assert.IsTrue(receivedMessage1.AsString == message.AsString);

            await queue.DeleteAsync();
        }

        [TestMethod]
        //[Description("Test whether get messages.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueGetMessagesAsync()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            await queue.CreateAsync();

            int messageCount = 30;

            List<CloudQueueMessage> emptyMessages = (await queue.GetMessagesAsync(messageCount)).ToList();
            Assert.AreEqual(0, emptyMessages.Count);

            List<string> messageContentList = new List<string>();
            for (int i = 0; i < messageCount; i++)
            {
                string messageContent = i.ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);
                await queue.AddMessageAsync(message);
                messageContentList.Add(messageContent);
            }

            List<CloudQueueMessage> receivedMessages = (await queue.GetMessagesAsync(messageCount)).ToList();
            Assert.AreEqual(messageCount, receivedMessages.Count);

            for (int i = 0; i < messageCount; i++)
            {
                Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
            }

            await queue.DeleteAsync();
        }

        [TestMethod]
        //[Description("Test whether peek message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueuePeekMessageAsync()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            await queue.CreateAsync();

            CloudQueueMessage emptyMessage = await queue.PeekMessageAsync();
            Assert.IsNull(emptyMessage);

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            await queue.AddMessageAsync(message);
            CloudQueueMessage receivedMessage1 = await queue.PeekMessageAsync();

            Assert.IsTrue(receivedMessage1.AsString == message.AsString);

            await queue.DeleteAsync();
        }

        [TestMethod]
        //[Description("Test whether peek messages.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueuePeekMessagesAsync()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            await queue.CreateAsync();

            int messageCount = 30;

            List<CloudQueueMessage> emptyMessages = (await queue.PeekMessagesAsync(messageCount)).ToList();
            Assert.AreEqual(0, emptyMessages.Count);

            List<string> messageContentList = new List<string>();
            for (int i = 0; i < messageCount; i++)
            {
                string messageContent = i.ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);
                await queue.AddMessageAsync(message);
                messageContentList.Add(messageContent);
            }

            List<CloudQueueMessage> receivedMessages = (await queue.PeekMessagesAsync(messageCount)).ToList();
            Assert.AreEqual(messageCount, receivedMessages.Count);

            for (int i = 0; i < messageCount; i++)
            {
                Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
            }

            await queue.DeleteAsync();
        }

        [TestMethod]
        //[Description("Test whether clear message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueClearMessageAsync()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            await queue.CreateAsync();

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            await queue.AddMessageAsync(message);
            CloudQueueMessage receivedMessage1 = await queue.PeekMessageAsync();
            Assert.IsTrue(receivedMessage1.AsString == message.AsString);
            await queue.ClearAsync();
            Assert.IsNull(await queue.PeekMessageAsync());
            await queue.DeleteAsync();
        }
    }
}