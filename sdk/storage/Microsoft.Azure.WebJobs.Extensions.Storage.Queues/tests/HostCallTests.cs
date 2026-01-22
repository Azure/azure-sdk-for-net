// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    // Some tests in this class aren't as targeted as most other tests in this project.
    // (Look elsewhere for better examples to use as templates for new tests.)
    public class HostCallTests
    {
        private const string QueueName = "input-hostcalltests";
        private const string OutputQueueName = "output-hostcalltests";
        private const string TestQueueMessage = "ignore";
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            queueServiceClient.GetQueueClient(QueueName).DeleteIfExists();
            queueServiceClient.GetQueueClient(OutputQueueName).DeleteIfExists();
        }

        [Test]
        public async Task Int32Argument_CanCallViaStringParse()
        {
            // Arrange
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "value", "15" }
            };

            // Act
            int result = await CallAsync<int>(typeof(UnboundInt32Program), "Call", arguments,
                (s) => UnboundInt32Program.TaskSource = s);

            Assert.That(result, Is.EqualTo(15));
        }

        private class UnboundInt32Program
        {
            public static TaskCompletionSource<int> TaskSource { get; set; }

            [NoAutomaticTrigger]
            public static void Call(int value)
            {
                TaskSource.TrySetResult(value);
            }
        }

        [Test]
        public async Task Queue_IfBoundToOutPoco_CanCall()
        {
            // Act
            await CallAsync(typeof(QueueProgram), "BindToOutPoco");

            // Assert
            var queue = queueServiceClient.GetQueueClient(OutputQueueName);
            AssertMessageSent(new PocoMessage { Value = "15" }, queue);
        }

        [Test]
        public async Task Queue_IfBoundToICollectorPoco_CanCall()
        {
            await TestEnqueueMultiplePocoMessages("BindToICollectorPoco");
        }

        [Test]
        public async Task Queue_IfBoundToIAsyncCollectorPoco_CanCall()
        {
            await TestEnqueueMultiplePocoMessages("BindToIAsyncCollectorPoco");
        }

        [Test]
        public async Task Queue_IfBoundToIAsyncCollectorByteArray_CanCall()
        {
            // Act
            await CallAsync(typeof(QueueProgram), "BindToIAsyncCollectorByteArray");

            // Assert
            var queue = queueServiceClient.GetQueueClient(OutputQueueName);
            QueueMessage[] messages = await queue.ReceiveMessagesAsync(32);
            Assert.That(messages, Is.Not.Null);
            Assert.That(messages.Count(), Is.EqualTo(3));
            QueueMessage[] sortedMessages = messages.OrderBy((m) => m.Body.ToString()).ToArray();

            Assert.That(sortedMessages[0].Body.ToString(), Is.EqualTo("test1"));
            Assert.That(sortedMessages[1].Body.ToString(), Is.EqualTo("test2"));
            Assert.That(sortedMessages[2].Body.ToString(), Is.EqualTo("test3"));
        }

        [Test]
        public async Task Queue_IfBoundToICollectorByteArray_CanCall()
        {
            // Act
            await CallAsync(typeof(QueueProgram), "BindToICollectorByteArray");

            // Assert
            var queue = queueServiceClient.GetQueueClient(OutputQueueName);
            QueueMessage[] messages = await queue.ReceiveMessagesAsync(32);
            Assert.That(messages, Is.Not.Null);
            Assert.That(messages.Count(), Is.EqualTo(3));
            QueueMessage[] sortedMessages = messages.OrderBy((m) => m.Body.ToString()).ToArray();

            Assert.That(sortedMessages[0].Body.ToString(), Is.EqualTo("test1"));
            Assert.That(sortedMessages[1].Body.ToString(), Is.EqualTo("test2"));
            Assert.That(sortedMessages[2].Body.ToString(), Is.EqualTo("test3"));
        }

        [Test]
        public async Task Queue_IfBoundToIAsyncCollectorBinaryData_CanCall()
        {
            // Act
            await CallAsync(typeof(QueueProgram), "BindToIAsyncCollectorBinaryData");

            // Assert
            var queue = queueServiceClient.GetQueueClient(OutputQueueName);
            QueueMessage[] messages = await queue.ReceiveMessagesAsync(32);
            Assert.That(messages, Is.Not.Null);
            Assert.That(messages.Count(), Is.EqualTo(3));
            QueueMessage[] sortedMessages = messages.OrderBy((m) => m.Body.ToString()).ToArray();

            Assert.That(sortedMessages[0].Body.ToString(), Is.EqualTo("test1"));
            Assert.That(sortedMessages[1].Body.ToString(), Is.EqualTo("test2"));
            Assert.That(sortedMessages[2].Body.ToString(), Is.EqualTo("test3"));
        }

        [Test]
        public async Task Queue_IfBoundToICollectorBinaryData_CanCall()
        {
            // Act
            await CallAsync(typeof(QueueProgram), "BindToICollectorBinaryData");

            // Assert
            var queue = queueServiceClient.GetQueueClient(OutputQueueName);
            QueueMessage[] messages = await queue.ReceiveMessagesAsync(32);
            Assert.That(messages, Is.Not.Null);
            Assert.That(messages.Count(), Is.EqualTo(3));
            QueueMessage[] sortedMessages = messages.OrderBy((m) => m.Body.ToString()).ToArray();

            Assert.That(sortedMessages[0].Body.ToString(), Is.EqualTo("test1"));
            Assert.That(sortedMessages[1].Body.ToString(), Is.EqualTo("test2"));
            Assert.That(sortedMessages[2].Body.ToString(), Is.EqualTo("test3"));
        }

        [Test]
        public async Task Queue_IfBoundToBinaryData_CanCall()
        {
            // Act
            await CallAsync(typeof(QueueProgram), "BindToBinaryData");

            // Assert
            var queue = queueServiceClient.GetQueueClient(OutputQueueName);
            QueueMessage[] messages = await queue.ReceiveMessagesAsync(32);
            Assert.That(messages, Is.Not.Null);
            Assert.That(messages.Count(), Is.EqualTo(1));
            QueueMessage[] sortedMessages = messages.OrderBy((m) => m.Body.ToString()).ToArray();

            Assert.That(sortedMessages[0].Body.ToString(), Is.EqualTo("test"));
        }

        [Test]
        public void Queue_IfBoundToIAsyncCollectorInt_NotSupported()
        {
            // Act
            FunctionIndexingException ex = Assert.ThrowsAsync<FunctionIndexingException>(() =>
            {
                return CallAsync(typeof(QueueNotSupportedProgram), "BindToICollectorInt");
            });

            // Assert
            Assert.That(ex.InnerException.Message, Is.EqualTo("Primitive types are not supported."));
        }

        private async Task TestEnqueueMultiplePocoMessages(string methodName)
        {
            // Act
            await CallAsync(typeof(QueueProgram), methodName);

            // Assert
            var queue = queueServiceClient.GetQueueClient(OutputQueueName);
            QueueMessage[] messages = await queue.ReceiveMessagesAsync(32);
            Assert.That(messages, Is.Not.Null);
            Assert.That(messages.Count(), Is.EqualTo(3));
            IEnumerable<QueueMessage> sortedMessages = messages.OrderBy((m) => m.MessageText);
            QueueMessage firstMessage = sortedMessages.ElementAt(0);
            QueueMessage secondMessage = sortedMessages.ElementAt(1);
            QueueMessage thirdMessage = sortedMessages.ElementAt(2);
            AssertEqual(new PocoMessage { Value = "10" }, firstMessage);
            AssertEqual(new PocoMessage { Value = "20" }, secondMessage);
            AssertEqual(new PocoMessage { Value = "30" }, thirdMessage);
        }

        [Test]
        public async Task Queue_IfBoundToIAsyncCollector_AddEnqueuesImmediately()
        {
            // Act
            await CallAsync(typeof(QueueProgram), "BindToIAsyncCollectorEnqueuesImmediately");
        }

        [Test]
        public async Task Queue_IfBoundToCloudQueue_CanCall()
        {
            // Act
            QueueClient result = await CallAsync<QueueClient>(typeof(BindToCloudQueueProgram), "BindToCloudQueue",
                (s) => BindToCloudQueueProgram.TaskSource = s);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(QueueName));
        }

        [Test]
        public async Task Queue_IfBoundToCloudQueueAndQueueIsMissing_Creates()
        {
            // Act
            QueueClient result = await CallAsync<QueueClient>(typeof(BindToCloudQueueProgram), "BindToCloudQueue",
                (s) => BindToCloudQueueProgram.TaskSource = s);

            // Assert
            Assert.That(result, Is.Not.Null);
            QueueClient queue = queueServiceClient.GetQueueClient(QueueName);
            Assert.That((bool)await queue.ExistsAsync(), Is.True);
        }

        private class BindToCloudQueueProgram
        {
            public static TaskCompletionSource<QueueClient> TaskSource { get; set; }

            public static void BindToCloudQueue([Queue(QueueName)] QueueClient queue)
            {
                TaskSource.TrySetResult(queue);
            }
        }

        [TestCase("FuncWithOutCloudQueueMessage", TestQueueMessage)]
        [TestCase("FuncWithOutByteArray", TestQueueMessage)]
        [TestCase("FuncWithOutString", TestQueueMessage)]
        [TestCase("FuncWithICollector", TestQueueMessage)]
        public async Task Queue_IfBoundToTypeAndQueueIsMissing_CreatesAndSends(string methodName, string expectedMessage)
        {
            // Act
            await CallAsync(typeof(MissingQueueProgram), methodName);

            // Assert
            QueueClient queue = queueServiceClient.GetQueueClient(OutputQueueName);
            Assert.That((bool)await queue.ExistsAsync(), Is.True);
            AssertMessageSent(expectedMessage, queue);
        }

        [Test]
        public async Task Queue_IfBoundToOutPocoAndQueueIsMissing_CreatesAndSends()
        {
            // Act
            await CallAsync(typeof(MissingQueueProgram), "FuncWithOutT");

            // Assert
            QueueClient queue = queueServiceClient.GetQueueClient(OutputQueueName);
            Assert.That((bool)await queue.ExistsAsync(), Is.True);
            AssertMessageSent(new PocoMessage { Value = TestQueueMessage }, queue);
        }

        [Test]
        public async Task Queue_IfBoundToOutStructAndQueueIsMissing_CreatesAndSends()
        {
            // Act
            await CallAsync(typeof(MissingQueueProgram), "FuncWithOutT");

            // Assert
            QueueClient queue = queueServiceClient.GetQueueClient(OutputQueueName);
            Assert.That((bool)await queue.ExistsAsync(), Is.True);
            AssertMessageSent(new StructMessage { Value = TestQueueMessage }, queue);
        }

        [TestCase("FuncWithOutCloudQueueMessageNull")]
        [TestCase("FuncWithOutByteArrayNull")]
        [TestCase("FuncWithOutStringNull")]
        [TestCase("FuncWithICollectorNoop")]
        public async Task Queue_IfBoundToTypeAndQueueIsMissing_DoesNotCreate(string methodName)
        {
            // Act
            await CallAsync(typeof(MissingQueueProgram), methodName);

            // Assert
            QueueClient queue = queueServiceClient.GetQueueClient(OutputQueueName);
            Assert.That((bool)await queue.ExistsAsync(), Is.False);
        }

        private static void AssertMessageSent(string expectedMessage, QueueClient queue)
        {
            Assert.That(queue, Is.Not.Null);
            QueueMessage message = queue.ReceiveMessages(1).Value.FirstOrDefault();
            Assert.That(message, Is.Not.Null);
            Assert.That(message.MessageText, Is.EqualTo(expectedMessage));
        }

        private static void AssertMessageSent(PocoMessage expected, QueueClient queue)
        {
            Assert.That(queue, Is.Not.Null);
            QueueMessage message = queue.ReceiveMessages(1).Value.FirstOrDefault();
            Assert.That(message, Is.Not.Null);
            AssertEqual(expected, message);
        }

        private static void AssertMessageSent(StructMessage expected, QueueClient queue)
        {
            Assert.That(queue, Is.Not.Null);
            QueueMessage message = queue.ReceiveMessages(1).Value.FirstOrDefault();
            Assert.That(message, Is.Not.Null);
            AssertEqual(expected, message);
        }

        private static void AssertEqual(PocoMessage expected, QueueMessage actualMessage)
        {
            Assert.That(actualMessage, Is.Not.Null);
            string content = actualMessage.MessageText;
            PocoMessage actual = JsonConvert.DeserializeObject<PocoMessage>(content);
            AssertEqual(expected, actual);
        }

        private static void AssertEqual(StructMessage expected, QueueMessage actualMessage)
        {
            Assert.That(actualMessage, Is.Not.Null);
            string content = actualMessage.MessageText;
            StructMessage actual = JsonConvert.DeserializeObject<StructMessage>(content);
            AssertEqual(expected, actual);
        }

        private static void AssertEqual(PocoMessage expected, PocoMessage actual)
        {
            if (expected == null)
            {
                Assert.That(actual, Is.Null);
                return;
            }

            Assert.That(actual.Value, Is.EqualTo(expected.Value));
        }

        private static void AssertEqual(StructMessage expected, StructMessage actual)
        {
            Assert.That(actual.Value, Is.EqualTo(expected.Value));
        }

        private async Task CallAsync(Type programType, string methodName, params Type[] customExtensions)
        {
            await FunctionalTest.CallAsync(b => ConfigureStorage(b), programType, programType.GetMethod(methodName), null, customExtensions);
        }

        private async Task CallAsync(Type programType, string methodName,
            IDictionary<string, object> arguments, params Type[] customExtensions)
        {
            await FunctionalTest.CallAsync(b => ConfigureStorage(b), programType, programType.GetMethod(methodName), arguments, customExtensions);
        }

        private async Task<TResult> CallAsync<TResult>(Type programType, string methodName,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            IDictionary<string, object> arguments = null;
            return await FunctionalTest.CallAsync<TResult>(b => ConfigureStorage(b), programType, programType.GetMethod(methodName), arguments, setTaskSource);
        }

        private async Task<TResult> CallAsync<TResult>(Type programType, string methodName,
            IDictionary<string, object> arguments, Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.CallAsync<TResult>(b => ConfigureStorage(b), programType, programType.GetMethod(methodName), arguments, setTaskSource);
        }

        private void ConfigureStorage(IWebJobsBuilder builder)
        {
            builder.AddAzureStorageQueues();
            builder.UseQueueService(queueServiceClient);
        }

        private struct CustomDataValue
        {
            public int ValueId { get; set; }
            public string Content { get; set; }
        }

        private class CustomDataObject
        {
            public int ValueId { get; set; }
            public string Content { get; set; }
        }

        private class QueueNotSupportedProgram
        {
            public static void BindToICollectorInt(
                [Queue(OutputQueueName)] ICollector<int> output)
            {
                // not supported
            }
        }

        private class QueueProgram
        {
            public static void BindToOutPoco([Queue(OutputQueueName)] out PocoMessage output)
            {
                output = new PocoMessage { Value = "15" };
            }

            public static void BindToICollectorPoco([Queue(OutputQueueName)] ICollector<PocoMessage> output)
            {
                output.Add(new PocoMessage { Value = "10" });
                output.Add(new PocoMessage { Value = "20" });
                output.Add(new PocoMessage { Value = "30" });
            }

            public static async Task BindToIAsyncCollectorPoco(
                [Queue(OutputQueueName)] IAsyncCollector<PocoMessage> output)
            {
                await output.AddAsync(new PocoMessage { Value = "10" });
                await output.AddAsync(new PocoMessage { Value = "20" });
                await output.AddAsync(new PocoMessage { Value = "30" });
            }

            public static async Task BindToIAsyncCollectorByteArray(
                [Queue(OutputQueueName)] IAsyncCollector<byte[]> output)
            {
                await output.AddAsync(Encoding.UTF8.GetBytes("test1"));
                await output.AddAsync(Encoding.UTF8.GetBytes("test2"));
                await output.AddAsync(Encoding.UTF8.GetBytes("test3"));
            }

            public static void BindToICollectorByteArray(
                [Queue(OutputQueueName)] ICollector<byte[]> output)
            {
                output.Add(Encoding.UTF8.GetBytes("test1"));
                output.Add(Encoding.UTF8.GetBytes("test2"));
                output.Add(Encoding.UTF8.GetBytes("test3"));
            }

            public static async Task BindToIAsyncCollectorBinaryData(
                [Queue(OutputQueueName)] IAsyncCollector<BinaryData> output)
            {
                await output.AddAsync(BinaryData.FromString("test1"));
                await output.AddAsync(BinaryData.FromString("test2"));
                await output.AddAsync(BinaryData.FromString("test3"));
            }

            public static void BindToICollectorBinaryData(
                [Queue(OutputQueueName)] ICollector<BinaryData> output)
            {
                output.Add(BinaryData.FromString("test1"));
                output.Add(BinaryData.FromString("test2"));
                output.Add(BinaryData.FromString("test3"));
            }

            public static void BindToBinaryData(
                [Queue(OutputQueueName)] out BinaryData output)
            {
                output = BinaryData.FromString("test");
            }

            public static async Task BindToIAsyncCollectorEnqueuesImmediately(
                [Queue(OutputQueueName)] IAsyncCollector<string> collector,
                [Queue(OutputQueueName)] QueueClient queue)
            {
                string expectedContents = "Enqueued immediately";
                await collector.AddAsync(expectedContents);
                QueueMessage message = (await queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
                Assert.That(message, Is.Not.Null);
                Assert.That(message.MessageText, Is.EqualTo(expectedContents));
            }
        }

        private class PocoMessage
        {
            public string Value { get; set; }
        }

        private struct StructMessage
        {
            public string Value { get; set; }
        }

        private class MissingQueueProgram
        {
            public static void FuncWithOutCloudQueueMessage([Queue(OutputQueueName)] out QueueMessage message)
            {
                message = QueuesModelFactory.QueueMessage(null, null, TestQueueMessage, 0);
            }

            public static void FuncWithOutCloudQueueMessageNull([Queue(OutputQueueName)] out QueueMessage message)
            {
                message = null;
            }

            public static void FuncWithOutByteArray([Queue(OutputQueueName)] out byte[] payload)
            {
                payload = Encoding.UTF8.GetBytes(TestQueueMessage);
            }

            public static void FuncWithOutByteArrayNull([Queue(OutputQueueName)] out byte[] payload)
            {
                payload = null;
            }

            public static void FuncWithOutString([Queue(OutputQueueName)] out string payload)
            {
                payload = TestQueueMessage;
            }

            public static void FuncWithOutStringNull([Queue(OutputQueueName)] out string payload)
            {
                payload = null;
            }

            public static void FuncWithICollector([Queue(OutputQueueName)] ICollector<string> queue)
            {
                Assert.That(queue, Is.Not.Null);
                queue.Add(TestQueueMessage);
            }

            public static void FuncWithICollectorNoop([Queue(QueueName)] ICollector<PocoMessage> queue)
            {
                Assert.That(queue, Is.Not.Null);
            }

            public static void FuncWithOutT([Queue(OutputQueueName)] out PocoMessage value)
            {
                value = new PocoMessage { Value = TestQueueMessage };
            }

            public static void FuncWithOutTNull([Queue(OutputQueueName)] out PocoMessage value)
            {
                value = null;
            }

            public static void FuncWithOutValueT([Queue(OutputQueueName)] out StructMessage value)
            {
                value = new StructMessage { Value = TestQueueMessage };
            }
        }
    }
}
