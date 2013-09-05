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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

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
        [Description("Test CloudQueueMessage constructor.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateMessage()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.CreateIfNotExists();

                CloudQueueMessage message = new CloudQueueMessage(Guid.NewGuid().ToString());
                queue.AddMessage(message);

                CloudQueueMessage retrMessage = queue.GetMessage();
                string messageId = retrMessage.Id;
                string popReceipt = retrMessage.PopReceipt;

                // Recreate the message using the messageId and popReceipt.
                CloudQueueMessage newMessage = new CloudQueueMessage(messageId, popReceipt);
                Assert.AreEqual(messageId, newMessage.Id);
                Assert.AreEqual(popReceipt, newMessage.PopReceipt);

                queue.UpdateMessage(newMessage, TimeSpan.FromSeconds(30), MessageUpdateFields.Visibility);
                CloudQueueMessage retrMessage2 = queue.GetMessage();
                Assert.AreEqual(null, retrMessage2);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test whether we can add message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddGetMessage()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            queue.AddMessage(message);

            CloudQueueMessage receivedMessage1 = queue.GetMessage();

            Assert.IsTrue(receivedMessage1.AsString == message.AsString);

            receivedMessage1.SetMessageContent(Guid.NewGuid().ToString("N"));

            queue.UpdateMessage(receivedMessage1, TimeSpan.FromSeconds(1), MessageUpdateFields.Content | MessageUpdateFields.Visibility);

            queue.DeleteMessage(receivedMessage1);

            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can add message with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddGetMessageAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Add Message
                IAsyncResult result = queue.BeginAddMessage(message,
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                queue.EndAddMessage(result);

                // Get message and test that it is correct
                result = queue.BeginGetMessage(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                CloudQueueMessage receivedMessage1 = queue.EndGetMessage(result);
                Assert.IsTrue(receivedMessage1.AsString == message.AsString);

                // Update Message
                receivedMessage1.SetMessageContent(Guid.NewGuid().ToString("N"));
                result = queue.BeginUpdateMessage(
                    receivedMessage1,
                    TimeSpan.FromSeconds(1),
                    MessageUpdateFields.Content | MessageUpdateFields.Visibility,
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                queue.EndUpdateMessage(result);

                // Delete Message
                result = queue.BeginDeleteMessage(receivedMessage1, null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndDeleteMessage(result);
            }
            queue.Delete();
        }

#if TASK
        [TestMethod]
        [Description("Test whether we can add message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddGetMessageTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.CreateAsync().Wait();

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            queue.AddMessageAsync(message).Wait();

            CloudQueueMessage receivedMessage1 = queue.GetMessageAsync().Result;

            Assert.IsTrue(receivedMessage1.AsString == message.AsString);

            receivedMessage1.SetMessageContent(Guid.NewGuid().ToString("N"));

            queue.UpdateMessageAsync(receivedMessage1, TimeSpan.FromSeconds(1), MessageUpdateFields.Content | MessageUpdateFields.Visibility).Wait();

            queue.DeleteMessageAsync(receivedMessage1, null, null).Wait();

            queue.DeleteAsync().Wait();
        }
#endif

        [TestMethod]
        [Description("Test whether we can add message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddGetByteMessage()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            byte[] testData = new byte[20];
            CloudQueueMessage message = new CloudQueueMessage(testData);
            queue.AddMessage(message);

            CloudQueueMessage receivedMessage1 = queue.GetMessage();

            Assert.IsTrue(receivedMessage1.AsString == message.AsString);
            TestHelper.AssertStreamsAreEqual(new MemoryStream(receivedMessage1.AsBytes), new MemoryStream(message.AsBytes));

            receivedMessage1.SetMessageContent(Guid.NewGuid().ToString("N"));

            queue.UpdateMessage(receivedMessage1, TimeSpan.FromSeconds(1), MessageUpdateFields.Content | MessageUpdateFields.Visibility);

            queue.DeleteMessage(receivedMessage1);

            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can add message with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddGetByteMessageAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            byte[] testData = new byte[20];
            CloudQueueMessage message = new CloudQueueMessage(testData);

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Add Message
                IAsyncResult result = queue.BeginAddMessage(message, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndAddMessage(result);

                // Test that message is correct
                CloudQueueMessage receivedMessage1 = queue.GetMessage();
                Assert.IsTrue(receivedMessage1.AsString == message.AsString);
                TestHelper.AssertStreamsAreEqual(new MemoryStream(receivedMessage1.AsBytes), new MemoryStream(message.AsBytes));

                // Update Message
                receivedMessage1.SetMessageContent(Guid.NewGuid().ToString("N"));
                result = queue.BeginUpdateMessage(receivedMessage1,
                    TimeSpan.FromSeconds(1),
                    MessageUpdateFields.Content | MessageUpdateFields.Visibility,
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                queue.EndUpdateMessage(result);

                // Delete Message
                result = queue.BeginDeleteMessage(receivedMessage1, null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndDeleteMessage(result);
            }
            queue.Delete();
        }

#if TASK
        [TestMethod]
        [Description("Test whether we can add message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddGetByteMessageTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.CreateAsync().Wait();

            byte[] testData = new byte[20];
            CloudQueueMessage message = new CloudQueueMessage(testData);
            queue.AddMessageAsync(message).Wait();

            CloudQueueMessage receivedMessage1 = queue.GetMessageAsync().Result;

            Assert.IsTrue(receivedMessage1.AsString == message.AsString);
            TestHelper.AssertStreamsAreEqual(new MemoryStream(receivedMessage1.AsBytes), new MemoryStream(message.AsBytes));

            receivedMessage1.SetMessageContent(Guid.NewGuid().ToString("N"));

            queue.UpdateMessageAsync(
                receivedMessage1,
                TimeSpan.FromSeconds(1),
                MessageUpdateFields.Content | MessageUpdateFields.Visibility,
                null,
                new OperationContext()).Wait();

            queue.DeleteMessageAsync(receivedMessage1, null, null).Wait();

            queue.DeleteAsync().Wait();
        }
#endif

        [TestMethod]
        [Description("Test whether we can get message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetMessage()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            CloudQueueMessage emptyMessage = queue.GetMessage();
            Assert.IsNull(emptyMessage);

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            queue.AddMessage(message);
            CloudQueueMessage receivedMessage1 = queue.GetMessage();

            Assert.IsTrue(receivedMessage1.AsString == message.AsString);

            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can get message with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetMessageAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Get Empty Message
                IAsyncResult result = queue.BeginGetMessage(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                CloudQueueMessage emptyMessage = queue.EndGetMessage(result);
                Assert.IsNull(emptyMessage);

                // Create New Message
                string msgContent = Guid.NewGuid().ToString("N");
                CloudQueueMessage message = new CloudQueueMessage(msgContent);

                // Add New Message
                result = queue.BeginAddMessage(message, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndAddMessage(result);

                // Get New Message
                result = queue.BeginGetMessage(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                CloudQueueMessage receivedMessage1 = queue.EndGetMessage(result);

                // Test Message
                Assert.IsTrue(receivedMessage1.AsString == message.AsString);
            }
            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can get messages.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetMessages()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            const int messageCount = 30;

            List<CloudQueueMessage> emptyMessages = queue.GetMessages(messageCount).ToList();
            Assert.AreEqual(0, emptyMessages.Count);

            List<string> messageContentList = new List<string>();
            for (int i = 0; i < messageCount; i++)
            {
                string messageContent = i.ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);
                queue.AddMessage(message);
                messageContentList.Add(messageContent);
            }

            List<CloudQueueMessage> receivedMessages = queue.GetMessages(messageCount).ToList();
            Assert.AreEqual(messageCount, receivedMessages.Count);

            for (int i = 0; i < messageCount; i++)
            {
                Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
            }

            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can get messages with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetMessagesAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            const int messageCount = 30;

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Get Messages
                IAsyncResult result = queue.BeginGetMessages(messageCount, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                List<CloudQueueMessage> emptyMessages = queue.EndGetMessages(result).ToList();

                // No messages should be in queue
                Assert.AreEqual(0, emptyMessages.Count);

                // Create messages to add to queue
                List<string> messageContentList = new List<string>();
                for (int i = 0; i < messageCount; i++)
                {
                    // Create a message
                    string messageContent = i.ToString();
                    CloudQueueMessage message = new CloudQueueMessage(messageContent);

                    // Add message to Queue
                    result = queue.BeginAddMessage(message, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queue.EndAddMessage(result);

                    // Add message to list to compare
                    messageContentList.Add(messageContent);
                }

                // Get messages from queue
                result = queue.BeginGetMessages(messageCount, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                List<CloudQueueMessage> receivedMessages = queue.EndGetMessages(result).ToList();

                // Test that messages are the same
                Assert.AreEqual(messageCount, receivedMessages.Count);
                for (int i = 0; i < messageCount; i++)
                {
                    Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
                }
            }
            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can get messages with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetMessagesWithTimeoutAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            const int messageCount = 30;
            
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result;
                
                // Create messages to add to queue
                List<string> messageContentList = new List<string>();
                for (int i = 0; i < messageCount; i++)
                {
                    // Create a message
                    string messageContent = i.ToString();
                    CloudQueueMessage message = new CloudQueueMessage(messageContent);

                    // Add message to Queue
                    result = queue.BeginAddMessage(message, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queue.EndAddMessage(result);

                    // Add message to list to compare
                    messageContentList.Add(messageContent);
                }

                // Test 1 second timeout (minimum)
                result = queue.BeginGetMessages(
                    messageCount, TimeSpan.FromSeconds(1), null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();

                List<CloudQueueMessage> receivedMessages = queue.EndGetMessages(result).ToList();

                // Test that messages are the same
                Assert.AreEqual(messageCount, receivedMessages.Count);
                for (int i = 0; i < messageCount; i++)
                {
                    Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
                }
                
                // Wait for the timeout to expire
                Thread.Sleep(TimeSpan.FromSeconds(1));

                // Test 7 day timeout (maximum)
                result = queue.BeginGetMessages(
                    messageCount, TimeSpan.FromDays(7), null, new OperationContext(), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                receivedMessages = queue.EndGetMessages(result).ToList();

                // Test that messages are the same
                Assert.AreEqual(messageCount, receivedMessages.Count);
                for (int i = 0; i < messageCount; i++)
                {
                    Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
                }
            }
            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can get messages with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetMessagesNegativeAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            const int messageCount = 30;

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result;

                // Create messages to add to queue
                List<string> messageContentList = new List<string>();
                for (int i = 0; i < messageCount; i++)
                {
                    // Create a message
                    string messageContent = i.ToString();
                    CloudQueueMessage message = new CloudQueueMessage(messageContent);

                    // Add message to Queue
                    result = queue.BeginAddMessage(message, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queue.EndAddMessage(result);

                    // Add message to list to compare
                    messageContentList.Add(messageContent);
                }

                // Expect failure from zero visibility timeout
                result = queue.BeginGetMessages(messageCount, TimeSpan.Zero, null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException<StorageException>(
                    () => queue.EndGetMessages(result),
                    "Expect failure from zero visibility timeout");

                // Expect failure from over 7 days visibility timeout
                result = queue.BeginGetMessages(
                    messageCount,
                    TimeSpan.FromDays(7) + TimeSpan.FromSeconds(1),
                    null,
                    null,
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException<StorageException>(
                    () => queue.EndGetMessages(result),
                    "Expect failure from over 7 days visibility timeout");
            }
            queue.Delete();
        }

#if TASK
        [TestMethod]
        [Description("Test whether we can get messages with Task.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetMessagesTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.CreateAsync().Wait();

            const int messageCount = 30;

            // Get Messages
            List<CloudQueueMessage> emptyMessages = queue.GetMessagesAsync(messageCount).Result.ToList();

            // No messages should be in queue
            Assert.AreEqual(0, emptyMessages.Count);

            // Create messages to add to queue
            List<string> messageContentList = new List<string>();
            for (int i = 0; i < messageCount; i++)
            {
                // Create a message
                string messageContent = i.ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);

                // Add message to Queue
                queue.AddMessageAsync(message).Wait();
                
                // Add message to list to compare
                messageContentList.Add(messageContent);
            }

            // Get messages from queue
            List<CloudQueueMessage> receivedMessages = queue.GetMessagesAsync(messageCount).Result.ToList();

            // Test that messages are the same
            Assert.AreEqual(messageCount, receivedMessages.Count);
            for (int i = 0; i < messageCount; i++)
            {
                Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
            }
           
            queue.DeleteAsync().Wait();
        }

        [TestMethod]
        [Description("Test whether we can get messages with Task.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetMessagesWithTimeoutTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.CreateAsync().Wait();

            const int messageCount = 30;
            
            // Create messages to add to queue
            List<string> messageContentList = new List<string>();
            for (int i = 0; i < messageCount; i++)
            {
                // Create a message
                string messageContent = i.ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);

                // Add message to Queue
                queue.AddMessageAsync(message).Wait();

                // Add message to list to compare
                messageContentList.Add(messageContent);
            }

            // Test 1 second timeout (minimum)
            List<CloudQueueMessage> receivedMessages = queue.GetMessagesAsync(messageCount, TimeSpan.FromSeconds(1), null, null).Result.ToList();

            // Test that messages are the same
            Assert.AreEqual(messageCount, receivedMessages.Count);
            for (int i = 0; i < messageCount; i++)
            {
                Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
            }
                
            // Wait for the timeout to expire
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Test 7 day timeout (maximum)
            receivedMessages = queue.GetMessagesAsync(messageCount, TimeSpan.FromDays(7), null, null).Result.ToList();

            // Test that messages are the same
            Assert.AreEqual(messageCount, receivedMessages.Count);
            for (int i = 0; i < messageCount; i++)
            {
                Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
            }

            queue.DeleteAsync().Wait();
        }
#endif

        [TestMethod]
        [Description("Test the queue message within boundary.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageSmallBoundaryTest()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            CloudQueue queueRefWithoutBase64Encoding = client.GetQueueReference(name);
            queueRefWithoutBase64Encoding.EncodeMessage = false;

            // boundary value 0 and 1
            CloudQueueMessageBase64EncodingBoundaryTest(queue, queueRefWithoutBase64Encoding, 0);
            CloudQueueMessageBase64EncodingBoundaryTest(queue, queueRefWithoutBase64Encoding, 1);

            CloudQueueMessageBase64EncodingBoundaryTest(queue, queueRefWithoutBase64Encoding, 1024);

            queue.Delete();
        }

        [TestMethod]
        [Description("Test the queue message within boundary.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageNormalBoundaryTest()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            CloudQueue queueRefWithoutBase64Encoding = client.GetQueueReference(name);
            queueRefWithoutBase64Encoding.EncodeMessage = false;

            // a string with ascii chars of length 8*6144 will have Base64-encoded length 8*8192 (64kB)
            // the following three test strings with length 8*6144-1, 8*6144, and 8*6144+1
            CloudQueueMessageBase64EncodingBoundaryTest(queue, queueRefWithoutBase64Encoding, 8 * 6144 - 1);
            CloudQueueMessageBase64EncodingBoundaryTest(queue, queueRefWithoutBase64Encoding, 8 * 6144);
            CloudQueueMessageBase64EncodingBoundaryTest(queue, queueRefWithoutBase64Encoding, 8 * 6144 + 1);

            // boundary value 8*8192-1, 8*8192, 8*8192+1
            CloudQueueMessageBase64EncodingBoundaryTest(queue, queueRefWithoutBase64Encoding, 8 * 8192 - 1);
            CloudQueueMessageBase64EncodingBoundaryTest(queue, queueRefWithoutBase64Encoding, 8 * 8192);
            CloudQueueMessageBase64EncodingBoundaryTest(queue, queueRefWithoutBase64Encoding, 8 * 8192 + 1);

            queue.Delete();
        }


        [TestMethod]
        [Description("Test the queue message within boundary.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageOverBoundaryTest()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            CloudQueue queueRefWithoutBase64Encoding = client.GetQueueReference(name);
            queueRefWithoutBase64Encoding.EncodeMessage = false;

            // excessive message size
            CloudQueueMessageBase64EncodingBoundaryTest(queue, queueRefWithoutBase64Encoding, 8 * 12288);

            queue.Delete();
        }

        /// <summary>
        /// Perform a set of Queue message tests given the message length.
        /// </summary>
        private void CloudQueueMessageBase64EncodingBoundaryTest(CloudQueue queue, CloudQueue queueRefWithoutBase64Encoding, int messageLength)
        {
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, true, false, false, messageLength);
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, true, false, true, messageLength);
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, true, true, false, messageLength);
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, true, true, true, messageLength);
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, false, false, false, messageLength);
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, false, false, true, messageLength);
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, false, true, false, messageLength);
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, false, true, true, messageLength);
        }

        /// <summary>
        /// Perform a set of Queue message tests with different chars.
        /// </summary>
        private void QueueBase64EncodingTest(CloudQueue queue, CloudQueue queueRefWithoutBase64Encoding, bool useBase64Encoding, bool useString, bool hasInvalidCharacter, int messageLength)
        {
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, useBase64Encoding, useString, hasInvalidCharacter, messageLength, (char)0x0b, 'a');
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, useBase64Encoding, useString, hasInvalidCharacter, messageLength, (char)0x0b, (char)0x21);
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, useBase64Encoding, useString, hasInvalidCharacter, messageLength, (char)0x0b, (char)0x7f);
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, useBase64Encoding, useString, hasInvalidCharacter, messageLength, (char)0x0b, (char)0xd7ff);
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, useBase64Encoding, useString, hasInvalidCharacter, messageLength, (char)0x0b, '<');
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, useBase64Encoding, useString, hasInvalidCharacter, messageLength, (char)0x19, '>');
            QueueBase64EncodingTest(queue, queueRefWithoutBase64Encoding, useBase64Encoding, useString, hasInvalidCharacter, messageLength, (char)0xfffe, '&');
        }

        /// <summary>
        /// Perform a PUT and GET queue message test customized by a few parameters.
        /// </summary>
        private void QueueBase64EncodingTest(CloudQueue queue, CloudQueue queueRefWithoutBase64Encoding, bool useBase64Encoding, bool useString, bool hasInvalidCharacter, int messageLength, char invalidXmlChar, char validXmlChar)
        {
            queue.EncodeMessage = useBase64Encoding;
            CloudQueueMessage originalMessage = null;
            bool expectedExceptionThrown = false;

            if (!useString)
            {
                // hasInvalidCharacter is ignored
                byte[] data = new byte[messageLength];
                Random random = new Random();
                random.NextBytes(data);
                originalMessage = new CloudQueueMessage(data);
            }
            else
            {
                string message = CreateMessageString(messageLength, hasInvalidCharacter, invalidXmlChar, validXmlChar);
                originalMessage = new CloudQueueMessage(message);
            }

            // check invalid use case and length validation
            if (!useString && !queue.EncodeMessage)
            {
                TestHelper.ExpectedException<ArgumentException>(() => { queue.AddMessage(originalMessage); }, "Binary data must be Base64 encoded");
                expectedExceptionThrown = true;
            }
            else
            {
                expectedExceptionThrown = QueueBase64EncodingTestVerifyLength(queue, originalMessage);
            }

            if (!expectedExceptionThrown)
            {
                // check invalid XML characters validation
                if (!queue.EncodeMessage && hasInvalidCharacter && messageLength > 0)
                {
                    TestHelper.ExpectedException<ArgumentException>(() => { queue.AddMessage(originalMessage); }, "Invalid characters should throw if Base64 encoding is not used");
                    expectedExceptionThrown = true;
                }
                else
                {
                    // good to send messages
                    queue.AddMessage(originalMessage);
                    queue.AddMessage(originalMessage);

                    if (useString)
                    {
                        QueueBase64EncodingTestDownloadMessageAndVerify(queue, queueRefWithoutBase64Encoding, originalMessage.AsString);
                    }
                    else
                    {
                        QueueBase64EncodingTestDownloadMessageAndVerify(queue, queueRefWithoutBase64Encoding, originalMessage.AsBytes);
                    }
                }
            }
        }

        private static void QueueBase64EncodingTestDownloadMessageAndVerify(CloudQueue queue, CloudQueue queueRefWithoutBase64Encoding, string originalMessage)
        {
            // Assumption: 2 of the same messages have been added
            // If the message was uploaded with Base64Encoding, this function will also retrieve the message without Base64 encoding.
            CloudQueueMessage readBack = queue.GetMessage();
            Assert.AreEqual<string>(originalMessage, readBack.AsString);
            queue.DeleteMessage(readBack);

            if (queue.EncodeMessage)
            {
                CloudQueueMessage readBackWithoutBase64Encoding = queueRefWithoutBase64Encoding.GetMessage();
                string decodedMessage = Encoding.UTF8.GetString(Convert.FromBase64String(readBackWithoutBase64Encoding.AsString));
                Assert.AreEqual<string>(originalMessage, decodedMessage);
                queueRefWithoutBase64Encoding.DeleteMessage(readBackWithoutBase64Encoding);
            }
            else
            {
                readBack = queue.GetMessage();
                queue.DeleteMessage(readBack);
            }
        }

        private static bool QueueBase64EncodingTestVerifyLength(CloudQueue queue, CloudQueueMessage message)
        {
            const long MaxMessageSize = 64 * 1024; // 64kb

            if (queue.EncodeMessage && Convert.ToBase64String(message.AsBytes).Length > MaxMessageSize
                || !queue.EncodeMessage && message.AsBytes.Length > MaxMessageSize)
            {
                TestHelper.ExpectedException<ArgumentException>(() => { queue.AddMessage(message); }, "Binary data must be Base64 encoded");
                return true;
            }

            return false;
        }

        private string CreateMessageString(int messageLength, bool hasInvalidCharacter, char invalidXmlChar, char validXmlChar)
        {
            char[] escapedChars = @"<>&".ToCharArray();

            StringBuilder message = new StringBuilder();
            if (messageLength > 0)
            {
                if (hasInvalidCharacter)
                {
                    message.Append(invalidXmlChar);
                    message.Append(CreateMessageString(messageLength - 1, false, invalidXmlChar, validXmlChar));
                }
                else
                {
                    // > and & will be encoded as &gt; and &amp; respectively and may result in RequestBodyTooLarge exception on server side
                    // so we don't add to many of these chars
                    if (messageLength <= 10 || !escapedChars.Contains<char>(validXmlChar))
                    {
                        message.Append(new string(validXmlChar, messageLength));
                    }
                    else
                    {
                        message.Append(new string(validXmlChar, 10));
                        message.Append(CreateMessageString(messageLength - 10, false, invalidXmlChar, 'a'));
                    }
                }
            }

            return message.ToString();
        }

        private static void QueueBase64EncodingTestDownloadMessageAndVerify(CloudQueue queue, CloudQueue queueRefWithoutBase64Encoding, byte[] originalData)
        {
            // Assumption: 2 of the same messages have been added
            // If the message was uploaded with Base64Encoding, this function will also retrieve the message without Base64 encoding.
            CloudQueueMessage readBack = queue.GetMessage();
            if (!CompareByteArray(originalData, readBack.AsBytes))
            {
                string orignalData = PrintByteArray(originalData, "OriginalData");
                string returnedData = PrintByteArray(readBack.AsBytes, "ReturnedData");
                Assert.Fail("Data read back from server doesn't match the original data. \r\n{0}\r\n{1}", orignalData, returnedData);
            }

            queue.DeleteMessage(readBack);
            if (queue.EncodeMessage)
            {
                CloudQueueMessage readBackWithoutBase64Encoding = queueRefWithoutBase64Encoding.GetMessage();
                byte[] returnedDataWithoutBase64Encoding = Convert.FromBase64String(readBackWithoutBase64Encoding.AsString);
                if (!CompareByteArray(originalData, returnedDataWithoutBase64Encoding))
                {
                    string orignalData = PrintByteArray(originalData, "OriginalData");
                    string returnedData = PrintByteArray(returnedDataWithoutBase64Encoding, "ReturnedDataWithoutBase64Encoding");
                    Assert.Fail("Data read back from server doesn't match the original data. \r\n{0}\r\n{1}", orignalData, returnedData);
                }

                queueRefWithoutBase64Encoding.DeleteMessage(readBackWithoutBase64Encoding);
            }
            else
            {
                readBack = queue.GetMessage();
                queue.DeleteMessage(readBack);
            }
        }

        private static bool CompareByteArray(byte[] left, byte[] right)
        {
            bool isSame = true;
            if (left.Length != right.Length)
            {
                isSame = false;
            }
            else
            {
                for (int i = 0; i < left.Length; i++)
                {
                    if (left[i] != right[i])
                    {
                        isSame = false;
                        break;
                    }
                }
            }

            return isSame;
        }

        private static string PrintByteArray(byte[] data, string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Printing byte array: {0}, length: {1}", name, data.Length));
            foreach (byte b in data)
            {
                sb.Append(string.Format("{0:X2} ", b));
            }

            return sb.ToString();
        }

        [TestMethod]
        [Description("Test whether process unicode message properly.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueUnicodeMessages()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();
            queue.EncodeMessage = false;

            List<string> messages = new List<string>();
            messages.Add(@"Pour résoudre les problèmes, suivez les meilleures pratiques.");
            messages.Add(@"Ваш логин Yahoo! дает доступ к таким мощным инструментам связи, как электронная почта, отправка мгновенных сообщений, функции безопасности, в частности, антивирусные средства и блокировщик всплывающей рекламы, и избранное, например, фото и музыка в сети — все бесплат");
            messages.Add(@"据新华社8月12日电 8月11日晚，舟曲境内再次出现强降雨天气，使特大山洪泥石流灾情雪上加霜。白龙江水在梨坝子村的交汇地带形成一个新的堰塞湖，水位比平时高出3米。甘肃省国土资源厅副厅长张国华当日22时许在新闻发布会上介绍，截至12日21时50分，舟曲堰塞湖堰塞体已消除，溃坝险情已消除，目前针对堰塞湖的主要工作是疏通河道。");
            messages.Add("ל כולם\", הדהים יעלון, ויישר קו עם העדות שמסר ראש הממשלה, בנימין נתניהו, לוועדת טירקל. לדבריו, אכן השרים דנו רק בהיבטים התקשורתיים של עצירת המשט: \"בשביעייה לא התקיים דיון על האלטרנטיבות. עסקנו בהיבטים ");
            messages.Add(@"Prozent auf 0,5 Prozent. Im Vergleich zum Vorjahresquartal wuchs die deutsche Wirtschaft von Januar bis März um 2,1 Prozent. Auch das ist eine Korrektur nach oben, ursprünglich waren es hier 1,7 Prozent");
            messages.Add("<?xml version=\"1.0\"?>\n<!DOCTYPE PARTS SYSTEM \"parts.dtd\">\n<?xml-stylesheet type=\"text/css\" href=\"xmlpartsstyle.css\"?>\n<PARTS>\n   <TITLE>Computer Parts</TITLE>\n   <PART>\n      <ITEM>Motherboard</ITEM>\n      <MANUFACTURER>ASUS</MANUFACTURER>\n      <MODEL>" +
                "P3B-F</MODEL>\n      <COST> 123.00</COST>\n   </PART>\n   <PART>\n      <ITEM>Video Card</ITEM>\n      <MANUFACTURER>ATI</MANUFACTURER>\n      <MODEL>All-in-Wonder Pro</MODEL>\n      <COST> 160.00</COST>\n   </PART>\n   <PART>\n      <ITEM>Sound Card</ITEM>\n      <MANUFACTURER>" +
                "Creative Labs</MANUFACTURER>\n      <MODEL>Sound Blaster Live</MODEL>\n      <COST> 80.00</COST>\n   </PART>\n   <PART>\n      <ITEM> inch Monitor</ITEM>\n      <MANUFACTURER>LG Electronics</MANUFACTURER>\n      <MODEL> 995E</MODEL>\n      <COST> 290.00</COST>\n   </PART>\n</PARTS>");

            foreach (string msg in messages)
            {
                queue.AddMessage(new CloudQueueMessage(msg));

                CloudQueueMessage readBack = queue.GetMessage();
                Assert.AreEqual<string>(msg, readBack.AsString);
                queue.DeleteMessage(readBack);
            }

            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether process unicode message properly with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueUnicodeMessagesAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();
            queue.EncodeMessage = false;

            List<string> messages = new List<string>();
            messages.Add(@"Pour résoudre les problèmes, suivez les meilleures pratiques.");
            messages.Add(@"Ваш логин Yahoo! дает доступ к таким мощным инструментам связи, как электронная почта, отправка мгновенных сообщений, функции безопасности, в частности, антивирусные средства и блокировщик всплывающей рекламы, и избранное, например, фото и музыка в сети — все бесплат");
            messages.Add(@"据新华社8月12日电 8月11日晚，舟曲境内再次出现强降雨天气，使特大山洪泥石流灾情雪上加霜。白龙江水在梨坝子村的交汇地带形成一个新的堰塞湖，水位比平时高出3米。甘肃省国土资源厅副厅长张国华当日22时许在新闻发布会上介绍，截至12日21时50分，舟曲堰塞湖堰塞体已消除，溃坝险情已消除，目前针对堰塞湖的主要工作是疏通河道。");
            messages.Add("ל כולם\", הדהים יעלון, ויישר קו עם העדות שמסר ראש הממשלה, בנימין נתניהו, לוועדת טירקל. לדבריו, אכן השרים דנו רק בהיבטים התקשורתיים של עצירת המשט: \"בשביעייה לא התקיים דיון על האלטרנטיבות. עסקנו בהיבטים ");
            messages.Add(@"Prozent auf 0,5 Prozent. Im Vergleich zum Vorjahresquartal wuchs die deutsche Wirtschaft von Januar bis März um 2,1 Prozent. Auch das ist eine Korrektur nach oben, ursprünglich waren es hier 1,7 Prozent");
            messages.Add("<?xml version=\"1.0\"?>\n<!DOCTYPE PARTS SYSTEM \"parts.dtd\">\n<?xml-stylesheet type=\"text/css\" href=\"xmlpartsstyle.css\"?>\n<PARTS>\n   <TITLE>Computer Parts</TITLE>\n   <PART>\n      <ITEM>Motherboard</ITEM>\n      <MANUFACTURER>ASUS</MANUFACTURER>\n      <MODEL>" +
                "P3B-F</MODEL>\n      <COST> 123.00</COST>\n   </PART>\n   <PART>\n      <ITEM>Video Card</ITEM>\n      <MANUFACTURER>ATI</MANUFACTURER>\n      <MODEL>All-in-Wonder Pro</MODEL>\n      <COST> 160.00</COST>\n   </PART>\n   <PART>\n      <ITEM>Sound Card</ITEM>\n      <MANUFACTURER>" +
                "Creative Labs</MANUFACTURER>\n      <MODEL>Sound Blaster Live</MODEL>\n      <COST> 80.00</COST>\n   </PART>\n   <PART>\n      <ITEM> inch Monitor</ITEM>\n      <MANUFACTURER>LG Electronics</MANUFACTURER>\n      <MODEL> 995E</MODEL>\n      <COST> 290.00</COST>\n   </PART>\n</PARTS>");

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                foreach (string msg in messages)
                {
                    // Add Message
                    IAsyncResult result = queue.BeginAddMessage(new CloudQueueMessage(msg), ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queue.EndAddMessage(result);

                    // Get Message
                    result = queue.BeginGetMessage(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    CloudQueueMessage readBack = queue.EndGetMessage(result);

                    // Test Message
                    Assert.AreEqual<string>(msg, readBack.AsString);

                    // Delete Message
                    result = queue.BeginDeleteMessage(readBack, null, null, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queue.EndDeleteMessage(result);
                }
            }
            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can peek message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueuePeekMessage()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            CloudQueueMessage emptyMessage = queue.PeekMessage();
            Assert.IsNull(emptyMessage);

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            queue.AddMessage(message);
            CloudQueueMessage receivedMessage1 = queue.PeekMessage();

            Assert.IsTrue(receivedMessage1.AsString == message.AsString);

            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can peek message with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueuePeekMessageAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Peek Message
                IAsyncResult result = queue.BeginPeekMessage(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                CloudQueueMessage emptyMessage = queue.EndPeekMessage(result);

                // Test that no message exists
                Assert.IsNull(emptyMessage);

                // Create message and add
                string msgContent = Guid.NewGuid().ToString("N");
                CloudQueueMessage message = new CloudQueueMessage(msgContent);
                result = queue.BeginAddMessage(message, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndAddMessage(result);

                // Peek Message
                result = queue.BeginPeekMessage(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                CloudQueueMessage receivedMessage1 = queue.EndPeekMessage(result);

                Assert.IsTrue(receivedMessage1.AsString == message.AsString);

                result = queue.BeginPeekMessage(null, new OperationContext(), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                receivedMessage1 = queue.EndPeekMessage(result);

                Assert.IsTrue(receivedMessage1.AsString == message.AsString);
            }
            queue.Delete();
        }

#if TASK
        [TestMethod]
        [Description("Test whether we can peek message with Task.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueuePeekMessageTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.CreateAsync().Wait();

            CloudQueueMessage emptyMessage = queue.PeekMessageAsync().Result;
            Assert.IsNull(emptyMessage);

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            queue.AddMessageAsync(message).Wait();
            CloudQueueMessage receivedMessage1 = queue.PeekMessageAsync(null, new OperationContext()).Result;

            Assert.IsTrue(receivedMessage1.AsString == message.AsString);

            queue.DeleteAsync().Wait();
        }
#endif

        [TestMethod]
        [Description("Test whether we can peek messages.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueuePeekMessages()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            const int messageCount = 30;

            List<CloudQueueMessage> emptyMessages = queue.PeekMessages(messageCount).ToList();
            Assert.AreEqual(0, emptyMessages.Count);

            List<string> messageContentList = new List<string>();
            for (int i = 0; i < messageCount; i++)
            {
                string messageContent = i.ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);
                queue.AddMessage(message);
                messageContentList.Add(messageContent);
            }

            List<CloudQueueMessage> receivedMessages = queue.PeekMessages(messageCount).ToList();
            Assert.AreEqual(messageCount, receivedMessages.Count);

            for (int i = 0; i < messageCount; i++)
            {
                Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
            }

            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can peek messages with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueuePeekMessagesAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            const int messageCount = 30;

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Peek messages
                IAsyncResult result = queue.BeginPeekMessages(messageCount, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                List<CloudQueueMessage> emptyMessages = queue.EndPeekMessages(result).ToList();

                // Check that no messages exist
                Assert.AreEqual(0, emptyMessages.Count);

                // Create message and add to queue
                List<string> messageContentList = new List<string>();
                for (int i = 0; i < messageCount; i++)
                {
                    // Create message
                    string messageContent = i.ToString();
                    CloudQueueMessage message = new CloudQueueMessage(messageContent);

                    // Add message to queue
                    result = queue.BeginAddMessage(message, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queue.EndAddMessage(result);

                    // Also add to list to compare
                    messageContentList.Add(messageContent);
                }

                // Peek messages
                result = queue.BeginPeekMessages(messageCount, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                List<CloudQueueMessage> receivedMessages = queue.EndPeekMessages(result).ToList();

                // Test peeked messages
                Assert.AreEqual(messageCount, receivedMessages.Count);
                for (int i = 0; i < messageCount; i++)
                {
                    Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
                }

                // Peek messages
                QueueRequestOptions options = QueueRequestOptions.ApplyDefaults(new QueueRequestOptions(), client);
                result = queue.BeginPeekMessages(messageCount, options, new OperationContext(), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                receivedMessages = queue.EndPeekMessages(result).ToList();

                // Test peeked messages
                Assert.AreEqual(messageCount, receivedMessages.Count);
                for (int i = 0; i < messageCount; i++)
                {
                    Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
                }
            }
            queue.Delete();
        }

#if TASK
        [TestMethod]
        [Description("Test whether we can peek messages with Task.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueuePeekMessagesTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.CreateAsync().Wait();

            const int messageCount = 30;

            List<CloudQueueMessage> emptyMessages = queue.PeekMessagesAsync(messageCount).Result.ToList();
            Assert.AreEqual(0, emptyMessages.Count);

            List<string> messageContentList = new List<string>();
            for (int i = 0; i < messageCount; i++)
            {
                string messageContent = i.ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);
                queue.AddMessageAsync(message).Wait();
                messageContentList.Add(messageContent);
            }

            List<CloudQueueMessage> receivedMessages = queue.PeekMessagesAsync(messageCount, null, new OperationContext()).Result.ToList();
            Assert.AreEqual(messageCount, receivedMessages.Count);

            for (int i = 0; i < messageCount; i++)
            {
                Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
            }

            queue.DeleteAsync().Wait();
        }
#endif

        [TestMethod]
        [Description("Test whether we can clear message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClearMessage()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            queue.AddMessage(message);
            CloudQueueMessage receivedMessage1 = queue.PeekMessage();
            Assert.IsTrue(receivedMessage1.AsString == message.AsString);
            queue.Clear();
            Assert.IsNull(queue.PeekMessage());
            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can clear message with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClearMessageAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            // Create Message
            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);

            // Add message to queue
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Add message
                IAsyncResult result = queue.BeginAddMessage(message, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndAddMessage(result);

                // Peek message
                result = queue.BeginPeekMessage(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                CloudQueueMessage receivedMessage1 = queue.EndPeekMessage(result);

                // Test message
                Assert.IsTrue(receivedMessage1.AsString == message.AsString);

                // Clear queue
                result = queue.BeginClear(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndClear(result);

                // Test clear result
                Assert.IsNull(queue.PeekMessage());
            }
            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can clear message with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClearMessageFullParameterAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            // Create Message
            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);

            // Add message to queue
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                // Add message
                IAsyncResult result = queue.BeginAddMessage(message, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndAddMessage(result);

                // Peek message
                result = queue.BeginPeekMessage(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                CloudQueueMessage receivedMessage1 = queue.EndPeekMessage(result);

                // Test message
                Assert.IsTrue(receivedMessage1.AsString == message.AsString);

                // Clear queue
                result = queue.BeginClear(null, new OperationContext(), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndClear(result);

                // Test clear result
                Assert.IsNull(queue.PeekMessage());
            }
            queue.Delete();
        }

#if TASK
        [TestMethod]
        [Description("Test whether we can clear message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClearMessageTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.CreateAsync().Wait();

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            queue.AddMessageAsync(message).Wait();
            CloudQueueMessage receivedMessage1 = queue.PeekMessageAsync().Result;
            Assert.IsTrue(receivedMessage1.AsString == message.AsString);
            queue.ClearAsync().Wait();
            Assert.IsNull(queue.PeekMessage());
            queue.DeleteAsync().Wait();
        }

        [TestMethod]
        [Description("Test whether we can clear message with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClearMessageFullParameterTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            // Create Message
            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);

            // Add message
            queue.AddMessageAsync(message).Wait();

            // Peek message
            CloudQueueMessage receivedMessage1 = queue.PeekMessageAsync().Result;

            // Test message
            Assert.IsTrue(receivedMessage1.AsString == message.AsString);

            // Clear queue
            queue.ClearAsync(null, new OperationContext()).Wait();

            // Test clear result
            Assert.IsNull(queue.PeekMessageAsync().Result);

            queue.DeleteAsync().Wait();
        }
#endif

        [TestMethod]
        [Description("Test when message is null.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageNull()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            queue.AddMessage(new CloudQueueMessage(Encoding.UTF8.GetBytes("")));
            CloudQueueMessage message = queue.GetMessage();
            Assert.IsNotNull(message);
            Assert.IsNotNull(message.Id);
            Assert.IsTrue(message.ExpirationTime.Value.Subtract(TimeSpan.FromMinutes(2)) > DateTime.UtcNow);
            Assert.IsNotNull(message.AsString);
            Assert.IsNotNull(message.InsertionTime.Value < DateTime.UtcNow);
            Assert.IsNotNull(message.PopReceipt);
            Assert.IsTrue(message.NextVisibleTime.Value.Add(TimeSpan.FromMinutes(2)) > DateTime.UtcNow);

            queue.Delete();
        }

        [TestMethod]
        [Description("Test when message is null with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageNullAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            using (AutoResetEvent waitHandler = new AutoResetEvent(false))
            {
                // Add blank message
                IAsyncResult result = queue.BeginAddMessage(new CloudQueueMessage(Encoding.UTF8.GetBytes("")),
                    ar => waitHandler.Set(),
                    null);
                waitHandler.WaitOne();
                queue.EndAddMessage(result);

                // Get message
                result = queue.BeginGetMessage(ar => waitHandler.Set(), null);
                waitHandler.WaitOne();
                CloudQueueMessage message = queue.EndGetMessage(result);

                Assert.IsNotNull(message);
                Assert.IsNotNull(message.Id);
                Assert.IsTrue(message.ExpirationTime.Value.Subtract(TimeSpan.FromMinutes(2)) > DateTime.UtcNow);
                Assert.IsNotNull(message.AsString);
                Assert.IsNotNull(message.InsertionTime.Value < DateTime.UtcNow);
                Assert.IsNotNull(message.PopReceipt);
                Assert.IsTrue(message.NextVisibleTime.Value.Add(TimeSpan.FromMinutes(2)) > DateTime.UtcNow);
            }

            queue.Delete();
        }

        [TestMethod]
        [Description("Test add message with full parameter.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddMessageFullParameter()
        {
            CloudQueueMessage futureMessage = new CloudQueueMessage("This message is for the future.");
            CloudQueueMessage presentMessage = new CloudQueueMessage("This message is for the present.");

            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            queue.AddMessage(futureMessage, null, TimeSpan.FromDays(2));

            // We should not be able to see the future message yet.
            CloudQueueMessage retrievedMessage = queue.GetMessage();
            Assert.IsNull(retrievedMessage);

            queue.AddMessage(presentMessage, null, TimeSpan.Zero);

            // We should be able to see the present message.
            retrievedMessage = queue.GetMessage();
            Assert.IsNotNull(retrievedMessage);
            Assert.AreEqual<string>(presentMessage.AsString, retrievedMessage.AsString);

            TestHelper.ExpectedException<ArgumentException>(
                        () => queue.AddMessage(futureMessage, TimeSpan.FromDays(1), TimeSpan.FromDays(2)),
                        "Using a visibility timeout longer than the time to live should fail");

            TestHelper.ExpectedException<ArgumentException>(
                        () => queue.AddMessage(futureMessage, null, TimeSpan.FromDays(8)),
                        "Using a visibility longer than the maximum time to live should fail");

            TestHelper.ExpectedException<ArgumentException>(
                        () => queue.AddMessage(futureMessage, null, TimeSpan.FromMinutes(-1)),
                        "Using a negative visibility should fail");

            queue.Delete();
        }

        [TestMethod]
        [Description("Test add message with full parameter and APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddMessageFullParameterAPM()
        {
            CloudQueueMessage futureMessage = new CloudQueueMessage("This message is for the future.");
            CloudQueueMessage presentMessage = new CloudQueueMessage("This message is for the present.");

            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            using (AutoResetEvent waitHandler = new AutoResetEvent(false))
            {
                // Add Message
                IAsyncResult result = queue.BeginAddMessage(
                    futureMessage, null, TimeSpan.FromDays(2), null, null, ar => waitHandler.Set(), null);
                waitHandler.WaitOne();
                queue.EndAddMessage(result);

                // We should not be able to see the future message yet.
                result = queue.BeginGetMessage(ar => waitHandler.Set(), null);
                waitHandler.WaitOne();
                CloudQueueMessage retrievedMessage = queue.EndGetMessage(result);

                // Test message for null
                Assert.IsNull(retrievedMessage);

                // Add Message
                result = queue.BeginAddMessage(
                    presentMessage, null, TimeSpan.Zero, null, null, ar => waitHandler.Set(), null);
                waitHandler.WaitOne();
                queue.EndAddMessage(result);

                // We should be able to see the present message.
                result = queue.BeginGetMessage(ar => waitHandler.Set(), null);
                waitHandler.WaitOne();
                retrievedMessage = queue.EndGetMessage(result);

                Assert.IsNotNull(retrievedMessage);
                Assert.AreEqual<string>(presentMessage.AsString, retrievedMessage.AsString);

                TestHelper.ExpectedException<ArgumentException>(
                    () =>
                    queue.BeginAddMessage(
                        futureMessage,
                        TimeSpan.FromDays(1),
                        TimeSpan.FromDays(2),
                        null,
                        null,
                        ar => waitHandler.Set(),
                        null),
                    "Using a visibility timeout longer than the time to live should fail");

                TestHelper.ExpectedException<ArgumentException>(
                    () =>
                    queue.BeginAddMessage(
                        futureMessage, null, TimeSpan.FromDays(8), null, null, ar => waitHandler.Set(), null),
                    "Using a visibility longer than the maximum time to live should fail");

                TestHelper.ExpectedException<ArgumentException>(
                    () =>
                    queue.BeginAddMessage(
                        futureMessage, null, TimeSpan.FromMinutes(-1), null, null, ar => waitHandler.Set(), null),
                    "Using a negative visibility should fail");
            }

            queue.Delete();
        }

#if TASK
        [TestMethod]
        [Description("Test add message with full parameter.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddMessageFullParameterTask()
        {
            CloudQueueMessage futureMessage = new CloudQueueMessage("This message is for the future.");
            CloudQueueMessage presentMessage = new CloudQueueMessage("This message is for the present.");

            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.CreateAsync().Wait();

            queue.AddMessageAsync(futureMessage, null, TimeSpan.FromDays(2), null, null).Wait();

            // We should not be able to see the future message yet.
            CloudQueueMessage retrievedMessage = queue.GetMessageAsync().Result;
            Assert.IsNull(retrievedMessage);

            queue.AddMessageAsync(presentMessage, null, TimeSpan.Zero, null, null).Wait();

            // We should be able to see the present message.
            retrievedMessage = queue.GetMessageAsync().Result;
            Assert.IsNotNull(retrievedMessage);
            Assert.AreEqual<string>(presentMessage.AsString, retrievedMessage.AsString);

            TestHelper.ExpectedException<ArgumentException>(
                        () => queue.AddMessageAsync(futureMessage, TimeSpan.FromDays(1), TimeSpan.FromDays(2), null, null),
                        "Using a visibility timeout longer than the time to live should fail");

            TestHelper.ExpectedException<ArgumentException>(
                        () => queue.AddMessageAsync(futureMessage, null, TimeSpan.FromDays(8), null, null),
                        "Using a visibility longer than the maximum time to live should fail");

            TestHelper.ExpectedException<ArgumentException>(
                        () => queue.AddMessageAsync(futureMessage, null, TimeSpan.FromMinutes(-1), null, null),
                        "Using a negative visibility should fail");

            queue.DeleteAsync().Wait();
        }
#endif

        [TestMethod]
        [Description("Test add large message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageQueueAddLargeMessage()
        {
            long maxStringLength = CloudQueueMessage.MaxMessageSize;
            long maxByteArrayLength = CloudQueueMessage.MaxMessageSize * 3 / 4;

            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            {
                char[] longMessageChars = new char[maxStringLength];
                for (long i = 0; i < longMessageChars.LongLength; i++)
                {
                    longMessageChars[i] = (char)('A' + (i % 26));
                }

                CloudQueueMessage longMessageFromString = new CloudQueueMessage(new string(longMessageChars));

                // Do not encode the message. This allows a maximally-sized string to be used.
                queue.EncodeMessage = false;

                // The following call should succeed.
                queue.AddMessage(longMessageFromString);

                CloudQueueMessage retrievedMessage = queue.GetMessage();
                Assert.AreEqual(longMessageFromString.AsString, retrievedMessage.AsString);
            }

            {
                byte[] longMessageBytes = new byte[maxByteArrayLength];
                for (long i = 0; i < longMessageBytes.LongLength; i++)
                {
                    longMessageBytes[i] = (byte)i;
                }

                CloudQueueMessage longMessageFromByteArray = new CloudQueueMessage(longMessageBytes);

                // The following call should throw an exception because byte array messages must be base 64 encoded.
                queue.EncodeMessage = false;

                TestHelper.ExpectedException<ArgumentException>(
                        () => queue.AddMessage(longMessageFromByteArray),
                        "AddMessage should throw an exception because byte array messages must be base 64 encoded");

                // Encode the message in base 64. This is the only way to use byte arrays in a message.
                queue.EncodeMessage = true;

                // The following call should succeed.
                queue.AddMessage(longMessageFromByteArray);

                CloudQueueMessage retrievedMessage = queue.GetMessage();
                byte[] expectedBytes = longMessageFromByteArray.AsBytes;
                byte[] foundBytes = retrievedMessage.AsBytes;

                Assert.AreEqual(expectedBytes.Length, foundBytes.Length);

                for (int i = 0; i < expectedBytes.Length; i++)
                {
                    Assert.AreEqual(expectedBytes[i], foundBytes[i]);
                }
            }

            queue.Delete();
        }

        [TestMethod]
        [Description("Test add large message with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageQueueAddLargeMessageAPM()
        {
            long maxStringLength = CloudQueueMessage.MaxMessageSize;
            long maxByteArrayLength = CloudQueueMessage.MaxMessageSize * 3 / 4;

            CloudQueueClient client = GenerateCloudQueueClient();
            string name = GenerateNewQueueName();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            {
                char[] longMessageChars = new char[maxStringLength];
                for (long i = 0; i < longMessageChars.LongLength; i++)
                {
                    longMessageChars[i] = (char)('A' + (i % 26));
                }

                CloudQueueMessage longMessageFromString = new CloudQueueMessage(new string(longMessageChars));

                // Do not encode the message. This allows a maximally-sized string to be used.
                queue.EncodeMessage = false;

                using (AutoResetEvent waitHandler = new AutoResetEvent(false))
                {
                    // The following call should succeed.
                    // Add Message
                    IAsyncResult result = queue.BeginAddMessage(longMessageFromString, ar => waitHandler.Set(), null);
                    waitHandler.WaitOne();
                    queue.EndAddMessage(result);

                    // Get Message
                    result = queue.BeginGetMessage(ar => waitHandler.Set(), null);
                    waitHandler.WaitOne();
                    CloudQueueMessage retrievedMessage = queue.EndGetMessage(result);

                    // Test message
                    Assert.AreEqual(longMessageFromString.AsString, retrievedMessage.AsString);
                }
            }

            {
                byte[] longMessageBytes = new byte[maxByteArrayLength];
                for (long i = 0; i < longMessageBytes.LongLength; i++)
                {
                    longMessageBytes[i] = (byte)i;
                }

                CloudQueueMessage longMessageFromByteArray = new CloudQueueMessage(longMessageBytes);

                using (AutoResetEvent waitHandler = new AutoResetEvent(false))
                {
                    // The following call should throw an exception because byte array messages must be base 64 encoded.
                    queue.EncodeMessage = false;

                    TestHelper.ExpectedException<ArgumentException>(
                        () => queue.BeginAddMessage(longMessageFromByteArray, ar => waitHandler.Set(), null),
                        "BeginAddMessage should throw an exception because byte array messages must be base 64 encoded");


                    // Encode the message in base 64. This is the only way to use byte arrays in a message.
                    queue.EncodeMessage = true;

                    // The following call to BeginAddMessage should succeed.
                    IAsyncResult result = queue.BeginAddMessage(longMessageFromByteArray, ar => waitHandler.Set(), null);
                    waitHandler.WaitOne();
                    queue.EndAddMessage(result);

                    // Get Message
                    result = queue.BeginGetMessage(ar => waitHandler.Set(), null);
                    waitHandler.WaitOne();
                    CloudQueueMessage retrievedMessage = queue.EndGetMessage(result);

                    byte[] expectedBytes = longMessageFromByteArray.AsBytes;
                    byte[] foundBytes = retrievedMessage.AsBytes;

                    Assert.AreEqual(expectedBytes.Length, foundBytes.Length);

                    for (int i = 0; i < expectedBytes.Length; i++)
                    {
                        Assert.AreEqual(expectedBytes[i], foundBytes[i]);
                    }
                }
            }

            queue.Delete();
        }

        [TestMethod]
        [Description("Test update message with full parameters.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueUpdateMessageFullParameter()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            queue.AddMessage(new CloudQueueMessage("message in queue"));
            CloudQueueMessage messageFromQueue = queue.GetMessage(TimeSpan.FromDays(1));
            DateTimeOffset nextVisibleTime = messageFromQueue.NextVisibleTime.Value;

            // Modify the message contents client-side
            messageFromQueue.SetMessageContent("new message content!");

            // Increase the message's visibility timeout.
            queue.UpdateMessage(messageFromQueue, TimeSpan.FromDays(2), MessageUpdateFields.Visibility);

            // The extra visibility time we get should be 1 day + small delta server time.
            Assert.IsTrue(messageFromQueue.NextVisibleTime - nextVisibleTime >= TimeSpan.FromDays(1));

            // Decrease the message's visibility timeout.
            queue.UpdateMessage(messageFromQueue, TimeSpan.FromDays(1), MessageUpdateFields.Visibility);

            // Now the extra time equals a small delta server time.
            Assert.IsTrue(messageFromQueue.NextVisibleTime - nextVisibleTime < TimeSpan.FromHours(1));

            // Update the message's visibility and content.
            queue.UpdateMessage(messageFromQueue, TimeSpan.FromSeconds(1), MessageUpdateFields.Visibility | MessageUpdateFields.Content);

            // Wait for message timeout to expire, then retrieve it again.
            Thread.Sleep(TimeSpan.FromSeconds(1.5));
            CloudQueueMessage messageRetrievedAgain = queue.GetMessage();

            // The content should have been modified.
            Assert.AreEqual(messageFromQueue.AsString, messageRetrievedAgain.AsString);

            // Update with zero visibility timeout
            queue.UpdateMessage(messageRetrievedAgain, TimeSpan.Zero, MessageUpdateFields.Visibility);

            // The message is now expired. Retrieve it again.
            messageRetrievedAgain = queue.GetMessage();

            // The content should be the same as before.
            Assert.AreEqual(messageFromQueue.AsString, messageRetrievedAgain.AsString);

            queue.Delete();
        }

        [TestMethod]
        [Description("Test update message with full parameters and APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueUpdateMessageFullParameterAPM()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            using (AutoResetEvent waitHandler = new AutoResetEvent(false))
            {
                queue.AddMessage(new CloudQueueMessage("message in queue"));
                CloudQueueMessage messageFromQueue = queue.GetMessage(TimeSpan.FromDays(1));
                DateTimeOffset nextVisibleTime = messageFromQueue.NextVisibleTime.Value;

                // Modify the message contents client-side
                messageFromQueue.SetMessageContent("new message content!");

                // Increase the message's visibility timeout.
                IAsyncResult result = queue.BeginUpdateMessage(
                    messageFromQueue,
                    TimeSpan.FromDays(2),
                    MessageUpdateFields.Visibility,
                    ar => waitHandler.Set(),
                    null);
                waitHandler.WaitOne();
                queue.EndUpdateMessage(result);


                // The extra visibility time we get should be 1 day + small delta server time.
                Assert.IsTrue(messageFromQueue.NextVisibleTime - nextVisibleTime >= TimeSpan.FromDays(1));

                // Decrease the message's visibility timeout.
                result = queue.BeginUpdateMessage(
                    messageFromQueue,
                    TimeSpan.FromDays(1),
                    MessageUpdateFields.Visibility,
                    ar => waitHandler.Set(),
                    null);
                waitHandler.WaitOne();
                queue.EndUpdateMessage(result);

                // Now the extra time equals a small delta server time.
                Assert.IsTrue(messageFromQueue.NextVisibleTime - nextVisibleTime < TimeSpan.FromHours(1));

                // Update the message's visibility and content.
                result = queue.BeginUpdateMessage(
                    messageFromQueue,
                    TimeSpan.FromSeconds(1),
                    MessageUpdateFields.Visibility | MessageUpdateFields.Content,
                    ar => waitHandler.Set(),
                    null);
                waitHandler.WaitOne();
                queue.EndUpdateMessage(result);

                // Wait for message timeout to expire, then retrieve it again.
                Thread.Sleep(TimeSpan.FromSeconds(1.5));
                result = queue.BeginGetMessage(ar => waitHandler.Set(), null);
                waitHandler.WaitOne();
                CloudQueueMessage messageRetrievedAgain = queue.EndGetMessage(result);

                // The content should have been modified.
                Assert.AreEqual(messageFromQueue.AsString, messageRetrievedAgain.AsString);

                // Update with zero visibility timeout and full parameters
                result = queue.BeginUpdateMessage(
                    messageRetrievedAgain,
                    TimeSpan.Zero,
                    MessageUpdateFields.Visibility,
                    null,
                    new OperationContext(),
                    ar => waitHandler.Set(),
                    null);
                waitHandler.WaitOne();
                queue.EndUpdateMessage(result);

                // The message is now expired. Retrieve it again.
                result = queue.BeginGetMessage(ar => waitHandler.Set(), null);
                waitHandler.WaitOne();
                messageRetrievedAgain = queue.EndGetMessage(result);

                // The content should be the same as before.
                Assert.AreEqual(messageFromQueue.AsString, messageRetrievedAgain.AsString);
            }

            queue.Delete();
        }

        [TestMethod]
        [Description("Test update Messgae boundary and negative check.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueUpdateMessageBoundaryAndNegativeCheck()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            queue.AddMessage(new CloudQueueMessage("message in queue"));
            CloudQueueMessage messageFromQueue = queue.GetMessage(TimeSpan.FromDays(1));

            messageFromQueue.SetMessageContent("newer message content");

            // If Visibility is not flagged for modification, an exception should be raised.
            TestHelper.ExpectedException<ArgumentException>(
                () => queue.UpdateMessage(messageFromQueue, TimeSpan.FromDays(1), MessageUpdateFields.Content),
                "Visibility is not flagged for modification");

            // If visibility timeout is greater than the maximum time to live, an exception should be raised.
            TestHelper.ExpectedException<ArgumentException>(
                () => queue.UpdateMessage(messageFromQueue, TimeSpan.FromDays(7) + TimeSpan.FromSeconds(1), MessageUpdateFields.Visibility),
                "visibility timeout is greater than the maximum time to live");

            // If visibility timeout is negative, an exception should be raised.
            TestHelper.ExpectedException<ArgumentException>(
                () => queue.UpdateMessage(messageFromQueue, TimeSpan.FromSeconds(-1), MessageUpdateFields.Visibility),
                "visibility timeout is negative");

            // If the message has no ID and pop receipt, an exception should be raised.
            CloudQueueMessage messageNotReceived = new CloudQueueMessage("This message has never been in a queue before.");
            TestHelper.ExpectedException<ArgumentException>(
                () => queue.UpdateMessage(messageNotReceived, TimeSpan.FromDays(1), MessageUpdateFields.Visibility),
                "the message has no ID and pop receipt");

            queue.Delete();
        }

        [TestMethod]
        [Description("Test update Messgae boundary and negative check with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueUpdateMessageBoundaryAndNegativeCheckAPM()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            using (AutoResetEvent waitHandler = new AutoResetEvent(false))
            {
                IAsyncResult result = queue.BeginAddMessage(
                    new CloudQueueMessage("message in queue"), ar => waitHandler.Set(), null);
                waitHandler.WaitOne();
                queue.EndAddMessage(result);

                CloudQueueMessage messageFromQueue = queue.GetMessage(TimeSpan.FromDays(1));

                messageFromQueue.SetMessageContent("newer message content");

                // If Visibility is not flagged for modification, an exception should be raised.
                TestHelper.ExpectedException<ArgumentException>(
                    () =>
                    queue.BeginUpdateMessage(
                        messageFromQueue,
                        TimeSpan.FromDays(1),
                        MessageUpdateFields.Content,
                        ar => waitHandler.Set(),
                        null),
                    "Visibility is not flagged for modification");

                // If visibility timeout is greater than the maximum time to live, an exception should be raised.
                TestHelper.ExpectedException<ArgumentException>(
                    () =>
                    queue.BeginUpdateMessage(
                        messageFromQueue,
                        TimeSpan.FromDays(7) + TimeSpan.FromSeconds(1),
                        MessageUpdateFields.Visibility,
                        ar => waitHandler.Set(),
                        null),
                    "visibility timeout is greater than the maximum time to live");

                // If visibility timeout is negative, an exception should be raised.
                TestHelper.ExpectedException<ArgumentException>(
                    () =>
                    queue.BeginUpdateMessage(
                        messageFromQueue,
                        TimeSpan.FromSeconds(-1),
                        MessageUpdateFields.Visibility,
                        ar => waitHandler.Set(),
                        null),
                    "visibility timeout is negative");

                // If the message has no ID and pop receipt, an exception should be raised.
                CloudQueueMessage messageNotReceived = new CloudQueueMessage("This message has never been in a queue before.");
                TestHelper.ExpectedException<ArgumentException>(
                    () =>
                    queue.BeginUpdateMessage(
                        messageNotReceived,
                        TimeSpan.FromDays(1),
                        MessageUpdateFields.Visibility,
                        ar => waitHandler.Set(),
                        null),
                    "the message has no ID and pop receipt");
            }

            queue.Delete();
        }

        [TestMethod]
        [Description("Test get Messgae with full parameter.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageGetMessageFullParameter()
        {
            string data = "Visibility Test Message";
            CloudQueueMessage message;

            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            queue.AddMessage(new CloudQueueMessage(data));

            // Expect failure from zero visibility timeout
            TestHelper.ExpectedException<StorageException>(
                () => queue.GetMessage(TimeSpan.Zero),
                "Expect failure from zero visibility timeout");

            // Expect failure from over 7 days visibility timeout
            TestHelper.ExpectedException<StorageException>(
                () => queue.GetMessage(TimeSpan.FromDays(7) + TimeSpan.FromSeconds(1)),
                "Expect failure from over 7 days visibility timeout");

            // Test 1 second timeout (minimum)
            message = queue.GetMessage(TimeSpan.FromSeconds(1));
            Assert.IsNotNull(message);
            Assert.AreEqual(message.AsString, data);

            // Wait for the timeout to expire
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Test 7 day timeout (maximum)
            message = queue.GetMessage(TimeSpan.FromDays(7));
            Assert.IsNotNull(message);
            Assert.AreEqual(message.AsString, data);

            // Delete the message
            queue.DeleteMessage(message);

            queue.Delete();
        }

        [TestMethod]
        [Description("Test get message with full parameter with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageGetMessageFullParameterAPM()
        {
            string data = "Visibility Test Message";
            CloudQueueMessage message;

            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = queue.BeginAddMessage(new CloudQueueMessage(data), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndAddMessage(result);

                // Expect failure from zero visibility timeout
                result = queue.BeginGetMessage(TimeSpan.Zero, null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException<StorageException>(
                    () => queue.EndGetMessage(result),
                    "Expect failure from zero visibility timeout");

                // Expect failure from over 7 days visibility timeout
                result = queue.BeginGetMessage(TimeSpan.FromDays(7) + TimeSpan.FromSeconds(1), null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException<StorageException>(
                    () => queue.EndGetMessage(result),
                    "Expect failure from over 7 days visibility timeout");

                // Test 1 second timeout (minimum)
                result = queue.BeginGetMessage(TimeSpan.FromSeconds(1), null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                message = queue.EndGetMessage(result);
                Assert.IsNotNull(message);
                Assert.AreEqual(message.AsString, data);

                // Wait for the timeout to expire
                Thread.Sleep(TimeSpan.FromSeconds(1));

                // Test 7 day timeout (maximum)
                result = queue.BeginGetMessage(TimeSpan.FromDays(7), null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                message = queue.EndGetMessage(result);
                Assert.IsNotNull(message);
                Assert.AreEqual(message.AsString, data);

                // Delete the message
                result = queue.BeginDeleteMessage(message.Id, message.PopReceipt, null, null, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndDeleteMessage(result);
            }

            queue.Delete();
        }

#if TASK
        [TestMethod]
        [Description("Test get Messgae with full parameter.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageGetMessageFullParameterTask()
        {
            string data = "Visibility Test Message";
            CloudQueueMessage message;

            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);
            queue.CreateAsync().Wait();

            queue.AddMessageAsync(new CloudQueueMessage(data)).Wait();

            // Expect failure from zero visibility timeout
            TestHelper.ExpectedExceptionTask<StorageException>(
                queue.GetMessageAsync(TimeSpan.Zero, null, null),
                "Expect failure from zero visibility timeout");

            // Expect failure from over 7 days visibility timeout
            TestHelper.ExpectedExceptionTask<StorageException>(
                queue.GetMessageAsync(TimeSpan.FromDays(7) + TimeSpan.FromSeconds(1), null, null),
                "Expect failure from over 7 days visibility timeout");

            // Test 1 second timeout (minimum)
            message = queue.GetMessageAsync(TimeSpan.FromSeconds(1), null, null).Result;
            Assert.IsNotNull(message);
            Assert.AreEqual(message.AsString, data);

            // Wait for the timeout to expire
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Test 7 day timeout (maximum)
            message = queue.GetMessageAsync(TimeSpan.FromDays(7), null, null).Result;
            Assert.IsNotNull(message);
            Assert.AreEqual(message.AsString, data);

            // Delete the message
            queue.DeleteMessageAsync(message.Id, message.PopReceipt, null, null).Wait();
            
            queue.DeleteAsync().Wait();
        }
#endif
    }
}
