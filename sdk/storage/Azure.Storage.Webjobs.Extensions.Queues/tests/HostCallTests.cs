// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Newtonsoft.Json;
using Xunit;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    // Some tests in this class aren't as targeted as most other tests in this project.
    // (Look elsewhere for better examples to use as templates for new tests.)
    [Collection(AzuriteCollection.Name)]
    public class HostCallTests
    {
        private const string QueueName = "input-hostcalltests";
        private const string OutputQueueName = "output-hostcalltests";
        private const int TestValue = Int32.MinValue;
        private const string TestQueueMessage = "ignore";
        private readonly StorageAccount account;

        public HostCallTests(AzuriteFixture azuriteFixture)
        {
            account = azuriteFixture.GetAccount();
            account.CreateQueueServiceClient().GetQueueClient(QueueName).DeleteIfExists();
            account.CreateQueueServiceClient().GetQueueClient(OutputQueueName).DeleteIfExists();
        }

        [Fact]
        public async Task Int32Argument_CanCallViaStringParse()
        {
            // Arrange
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "value", "15" }
            };

            // Act
            int result = await CallAsync<int>(account, typeof(UnboundInt32Program), "Call", arguments,
                (s) => UnboundInt32Program.TaskSource = s);

            Assert.Equal(15, result);
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

        [Fact]
        public async Task Queue_IfBoundToOutPoco_CanCall()
        {
            // Act
            await CallAsync(account, typeof(QueueProgram), "BindToOutPoco");

            // Assert
            var queue = account.CreateQueueServiceClient().GetQueueClient(OutputQueueName);
            AssertMessageSent(new PocoMessage { Value = "15" }, queue);
        }

        [Fact]
        public async Task Queue_IfBoundToICollectorPoco_CanCall()
        {
            await TestEnqueueMultiplePocoMessages("BindToICollectorPoco");
        }

        [Fact]
        public async Task Queue_IfBoundToIAsyncCollectorPoco_CanCall()
        {
            await TestEnqueueMultiplePocoMessages("BindToIAsyncCollectorPoco");
        }

        [Fact]
        public async Task Queue_IfBoundToIAsyncCollectorByteArray_CanCall()
        {
            // Act
            await CallAsync(account, typeof(QueueProgram), "BindToIAsyncCollectorByteArray"); // TODO (kasobol-msft) revisit when BinaryData is in SDK

            // Assert
            var queue = account.CreateQueueServiceClient().GetQueueClient(OutputQueueName);
            QueueMessage[] messages = await queue.ReceiveMessagesAsync(32);
            Assert.NotNull(messages);
            Assert.Equal(3, messages.Count());
            QueueMessage[] sortedMessages = messages.OrderBy((m) => m.MessageText).ToArray();

            // TODO (kasobol-msft) revisit this when base64/BinaryData is in the SDK
            Assert.Equal("test1", sortedMessages[0].MessageText);
            Assert.Equal("test2", sortedMessages[1].MessageText);
            Assert.Equal("test3", sortedMessages[2].MessageText);
        }

        [Fact]
        public async Task Queue_IfBoundToICollectorByteArray_CanCall() // TODO (kasobol-msft) revisit when BinaryData is in SDK
        {
            // Act
            await CallAsync(account, typeof(QueueProgram), "BindToICollectorByteArray");

            // Assert
            var queue = account.CreateQueueServiceClient().GetQueueClient(OutputQueueName);
            QueueMessage[] messages = await queue.ReceiveMessagesAsync(32);
            Assert.NotNull(messages);
            Assert.Equal(3, messages.Count());
            QueueMessage[] sortedMessages = messages.OrderBy((m) => m.MessageText).ToArray();

            Assert.Equal("test1", sortedMessages[0].MessageText);
            Assert.Equal("test2", sortedMessages[1].MessageText);
            Assert.Equal("test3", sortedMessages[2].MessageText);
        }

        [Fact]
        public async Task Queue_IfBoundToIAsyncCollectorInt_NotSupported()
        {
            // Act
            FunctionIndexingException ex = await Assert.ThrowsAsync<FunctionIndexingException>(() =>
            {
                return CallAsync(account, typeof(QueueNotSupportedProgram), "BindToICollectorInt");
            });

            // Assert
            Assert.Equal("Primitive types are not supported.", ex.InnerException.Message);
        }

        private async Task TestEnqueueMultiplePocoMessages(string methodName)
        {
            // Act
            await CallAsync(account, typeof(QueueProgram), methodName);

            // Assert
            var queue = account.CreateQueueServiceClient().GetQueueClient(OutputQueueName);
            QueueMessage[] messages = await queue.ReceiveMessagesAsync(32);
            Assert.NotNull(messages);
            Assert.Equal(3, messages.Count());
            IEnumerable<QueueMessage> sortedMessages = messages.OrderBy((m) => m.MessageText);
            QueueMessage firstMessage = sortedMessages.ElementAt(0);
            QueueMessage secondMessage = sortedMessages.ElementAt(1);
            QueueMessage thirdMessage = sortedMessages.ElementAt(2);
            AssertEqual(new PocoMessage { Value = "10" }, firstMessage);
            AssertEqual(new PocoMessage { Value = "20" }, secondMessage);
            AssertEqual(new PocoMessage { Value = "30" }, thirdMessage);
        }

        [Fact]
        public async Task Queue_IfBoundToIAsyncCollector_AddEnqueuesImmediately()
        {
            // Act
            await CallAsync(account, typeof(QueueProgram), "BindToIAsyncCollectorEnqueuesImmediately");
        }

        [Fact]
        public async Task Queue_IfBoundToCloudQueue_CanCall()
        {
            // Act
            QueueClient result = await CallAsync<QueueClient>(account, typeof(BindToCloudQueueProgram), "BindToCloudQueue",
                (s) => BindToCloudQueueProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(QueueName, result.Name);
        }

        [Fact]
        public async Task Queue_IfBoundToCloudQueueAndQueueIsMissing_Creates()
        {
            // Act
            QueueClient result = await CallAsync<QueueClient>(account, typeof(BindToCloudQueueProgram), "BindToCloudQueue",
                (s) => BindToCloudQueueProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            QueueClient queue = account.CreateQueueServiceClient().GetQueueClient(QueueName);
            Assert.True(await queue.ExistsAsync());
        }

        private class BindToCloudQueueProgram
        {
            public static TaskCompletionSource<QueueClient> TaskSource { get; set; }

            public static void BindToCloudQueue([Queue(QueueName)] QueueClient queue)
            {
                TaskSource.TrySetResult(queue);
            }
        }

        [Theory]
        [InlineData("FuncWithOutCloudQueueMessage", TestQueueMessage)]
        [InlineData("FuncWithOutByteArray", TestQueueMessage)]
        [InlineData("FuncWithOutString", TestQueueMessage)]
        [InlineData("FuncWithICollector", TestQueueMessage)]
        public async Task Queue_IfBoundToTypeAndQueueIsMissing_CreatesAndSends(string methodName, string expectedMessage)
        {
            // Act
            await CallAsync(account, typeof(MissingQueueProgram), methodName);

            // Assert
            QueueClient queue = account.CreateQueueServiceClient().GetQueueClient(OutputQueueName);
            Assert.True(await queue.ExistsAsync());
            AssertMessageSent(expectedMessage, queue);
        }

        [Fact]
        public async Task Queue_IfBoundToOutPocoAndQueueIsMissing_CreatesAndSends()
        {
            // Act
            await CallAsync(account, typeof(MissingQueueProgram), "FuncWithOutT");

            // Assert
            QueueClient queue = account.CreateQueueServiceClient().GetQueueClient(OutputQueueName);
            Assert.True(await queue.ExistsAsync());
            AssertMessageSent(new PocoMessage { Value = TestQueueMessage }, queue);
        }

        [Fact]
        public async Task Queue_IfBoundToOutStructAndQueueIsMissing_CreatesAndSends()
        {
            // Act
            await CallAsync(account, typeof(MissingQueueProgram), "FuncWithOutT");

            // Assert
            QueueClient queue = account.CreateQueueServiceClient().GetQueueClient(OutputQueueName);
            Assert.True(await queue.ExistsAsync());
            AssertMessageSent(new StructMessage { Value = TestQueueMessage }, queue);
        }

        [Theory]
        [InlineData("FuncWithOutCloudQueueMessageNull")]
        [InlineData("FuncWithOutByteArrayNull")]
        [InlineData("FuncWithOutStringNull")]
        [InlineData("FuncWithICollectorNoop")]
        public async Task Queue_IfBoundToTypeAndQueueIsMissing_DoesNotCreate(string methodName)
        {
            // Act
            await CallAsync(account, typeof(MissingQueueProgram), methodName);

            // Assert
            QueueClient queue = account.CreateQueueServiceClient().GetQueueClient(OutputQueueName);
            Assert.False(await queue.ExistsAsync());
        }

        private static void AssertMessageSent(string expectedMessage, QueueClient queue)
        {
            Assert.NotNull(queue);
            QueueMessage message = queue.ReceiveMessages(1).Value.FirstOrDefault();
            Assert.NotNull(message);
            Assert.Equal(expectedMessage, message.MessageText);
        }

        private static void AssertMessageSent(PocoMessage expected, QueueClient queue)
        {
            Assert.NotNull(queue);
            QueueMessage message = queue.ReceiveMessages(1).Value.FirstOrDefault();
            Assert.NotNull(message);
            AssertEqual(expected, message);
        }

        private static void AssertMessageSent(StructMessage expected, QueueClient queue)
        {
            Assert.NotNull(queue);
            QueueMessage message = queue.ReceiveMessages(1).Value.FirstOrDefault();
            Assert.NotNull(message);
            AssertEqual(expected, message);
        }

        private static void AssertEqual(PocoMessage expected, QueueMessage actualMessage)
        {
            Assert.NotNull(actualMessage);
            string content = actualMessage.MessageText;
            PocoMessage actual = JsonConvert.DeserializeObject<PocoMessage>(content);
            AssertEqual(expected, actual);
        }

        private static void AssertEqual(StructMessage expected, QueueMessage actualMessage)
        {
            Assert.NotNull(actualMessage);
            string content = actualMessage.MessageText;
            StructMessage actual = JsonConvert.DeserializeObject<StructMessage>(content);
            AssertEqual(expected, actual);
        }

        private static void AssertEqual(PocoMessage expected, PocoMessage actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }

            Assert.Equal(expected.Value, actual.Value);
        }

        private static void AssertEqual(StructMessage expected, StructMessage actual)
        {
            Assert.Equal(expected.Value, actual.Value);
        }

        private static async Task CallAsync(StorageAccount account, Type programType, string methodName, params Type[] customExtensions)
        {
            await FunctionalTest.CallAsync(account, programType, programType.GetMethod(methodName), null, customExtensions);
        }

        private static async Task CallAsync(StorageAccount account, Type programType, string methodName,
            IDictionary<string, object> arguments, params Type[] customExtensions)
        {
            await FunctionalTest.CallAsync(account, programType, programType.GetMethod(methodName), arguments, customExtensions);
        }

        private static async Task<TResult> CallAsync<TResult>(StorageAccount account, Type programType, string methodName,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            IDictionary<string, object> arguments = null;
            return await FunctionalTest.CallAsync<TResult>(account, programType, programType.GetMethod(methodName), arguments, setTaskSource);
        }

        private static async Task<TResult> CallAsync<TResult>(StorageAccount account, Type programType, string methodName,
            IDictionary<string, object> arguments, Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.CallAsync<TResult>(account, programType, programType.GetMethod(methodName), arguments, setTaskSource);
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

            public static async Task BindToIAsyncCollectorEnqueuesImmediately(
                [Queue(OutputQueueName)] IAsyncCollector<string> collector,
                [Queue(OutputQueueName)] QueueClient queue)
            {
                string expectedContents = "Enqueued immediately";
                await collector.AddAsync(expectedContents);
                QueueMessage message = (await queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
                Assert.NotNull(message);
                Assert.Equal(expectedContents, message.MessageText);
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
                Assert.NotNull(queue);
                queue.Add(TestQueueMessage);
            }

            public static void FuncWithICollectorNoop([Queue(QueueName)] ICollector<PocoMessage> queue)
            {
                Assert.NotNull(queue);
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
