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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Queue
{
    [TestClass]
    public class CloudQueueMessageTest : QueueTestBase
    {
        
        [TestMethod]
        [Description("Test whether we can add message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddGetMessage()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
            queue.Create();

            string msgContent = Guid.NewGuid().ToString("N");
            CloudQueueMessage message = new CloudQueueMessage(msgContent);
            queue.AddMessage(message);

            CloudQueueMessage receivedMessage1 = queue.GetMessage();

            Assert.IsTrue(receivedMessage1.AsString == message.AsString);

            receivedMessage1.SetMessageContent(Guid.NewGuid().ToString("N"));

            queue.UpdateMessage(receivedMessage1, TimeSpan.FromSeconds(1), MessageUpdateFields.Content|MessageUpdateFields.Visibility);

            queue.DeleteMessage(receivedMessage1);

            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether we can add message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddGetByteMessage()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
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
        [Description("Test whether get message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetMessage()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
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
        [Description("Test whether get messages.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetMessages()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
            queue.Create();

            int messageCount = 30;

            var emptyMessages = queue.GetMessages(messageCount).ToList();
            Assert.AreEqual(0, emptyMessages.Count);

            List<string> messageContentList = new List<string>();
            for (int i = 0; i < messageCount; i++)
            {
                string messageContent = i.ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);
                queue.AddMessage(message);
                messageContentList.Add(messageContent);
            }

            var receivedMessages = queue.GetMessages(messageCount).ToList();
            Assert.AreEqual(messageCount, receivedMessages.Count);

            for (int i = 0; i < messageCount; i++)
            {
                Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
            }

            queue.Delete();
        }

        [TestMethod]
        [Description("Test the queue message within boundary.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageSmallBoundaryTest()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
            queue.Create();

            CloudQueue queueRefWithoutBase64Encoding = DefaultQueueClient.GetQueueReference(name);
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
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
            queue.Create();

            CloudQueue queueRefWithoutBase64Encoding = DefaultQueueClient.GetQueueReference(name);
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
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
            queue.Create();

            CloudQueue queueRefWithoutBase64Encoding = DefaultQueueClient.GetQueueReference(name);
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
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
            queue.Create();
            queue.EncodeMessage = false;

            List<string> messages = new List<string>();
            messages.Add(@"Le débat sur l'identité nationale, l'idée du président Nicolas Sarkozy de déchoir des personnes d'origine étrangère de la nationalité française dans certains cas et les récentes mesures prises contre les Roms ont choqué les experts, qui rendront leurs conclusions le 27 août.");
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
        [Description("Test whether peek message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueuePeekMessage()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
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
        [Description("Test whether peek messages.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueuePeekMessages()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
            queue.Create();

            int messageCount = 30;

            var emptyMessages = queue.PeekMessages(messageCount).ToList();
            Assert.AreEqual(0, emptyMessages.Count);

            List<string> messageContentList = new List<string>();
            for (int i = 0; i < messageCount; i++)
            {
                string messageContent = i.ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);
                queue.AddMessage(message);
                messageContentList.Add(messageContent);
            }

            var receivedMessages = queue.PeekMessages(messageCount).ToList();
            Assert.AreEqual(messageCount, receivedMessages.Count);

            for (int i = 0; i < messageCount; i++)
            {
                Assert.IsTrue(messageContentList.Contains(receivedMessages[i].AsString));
            }
            
            queue.Delete();
        }

        [TestMethod]
        [Description("Test whether clear message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClearMessage()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
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
        [Description("Test when message is null.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageNull()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
            queue.Create();

            queue.AddMessage(new CloudQueueMessage(Encoding.UTF8.GetBytes("")));
            var message = queue.GetMessage();
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
        [Description("Test add message with full parameter.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueAddMessageFullParameter()
        {
            CloudQueueMessage futureMessage = new CloudQueueMessage("This message is for the future.");
            CloudQueueMessage presentMessage = new CloudQueueMessage("This message is for the present.");

            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
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
        [Description("Test add large message.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueMessageQueueAddLargeMessage()
        {
            long maxStringLength = CloudQueueMessage.MaxMessageSize;
            long maxByteArrayLength = CloudQueueMessage.MaxMessageSize * 3 / 4;

            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
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
        [Description("Test update Messgae with full parameters.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueUpdateMessageFullParameter()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
            queue.Create();

            queue.AddMessage(new CloudQueueMessage("message in queue"));
            CloudQueueMessage messageFromQueue = queue.GetMessage(TimeSpan.FromDays(1));
            var nextVisibleTime = messageFromQueue.NextVisibleTime.Value;

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
        [Description("Test update Messgae boundary and negative check.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueUpdateMessageBoundaryAndNegativeCheck()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
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
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
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
    }
}
