// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Host.FunctionalTests.TestDoubles;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    [Collection(AzuriteCollection.Name)]
    public class QueueTriggerTests
    {
        private const string QueueName = "input-queuetriggertests";
        private readonly StorageAccount account;

        public QueueTriggerTests(AzuriteFixture azuriteFixture)
        {
            account = azuriteFixture.GetAccount();
            account.CreateQueueServiceClient().GetQueueClient(QueueName).DeleteIfExists();
        }

        private async Task SetupAsync(StorageAccount account, object contents)
        {
            string message;
            if (contents is string str)
            {
                message = str;
            }
            else if (contents is byte[] bytearray) // TODO (kasobol-msft) revisit this when we have Base64/BinaryData
            {
                message = Encoding.UTF8.GetString(bytearray);
            }
            else
            {
                throw new InvalidOperationException("bad test");
            }

            var queue = await CreateQueue(account, QueueName);

            // message.InsertionTime is provided by FakeStorageAccount when the message is inserted.
            await queue.SendMessageAsync(message);
        }

        [Fact]
        public async Task QueueTrigger_IfBoundToCloudQueueMessage_Binds()
        {
            // Arrange
            string expectedGuid = Guid.NewGuid().ToString();
            var queue = await CreateQueue(account, QueueName);
            await queue.SendMessageAsync(expectedGuid);

            // Act
            QueueMessage result = await RunTriggerAsync<QueueMessage>(account, typeof(BindToCloudQueueMessageProgram),
                (s) => BindToCloudQueueMessageProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedGuid, result.MessageText);
        }

        [Fact]
        public async Task QueueTrigger_IfBoundToString_Binds()
        {
            string expectedContent = Guid.NewGuid().ToString();
            await TestBindToString(expectedContent);
        }

        [Fact]
        public async Task QueueTrigger_IfBoundToStringAndMessageIsEmpty_Binds()
        {
            await TestBindToString(string.Empty);
        }

        private async Task TestBindToString(string expectedContent)
        {
            // Arrange
            var queue = await CreateQueue(account, QueueName);
            await queue.SendMessageAsync(expectedContent);

            // Act
            string result = await RunTriggerAsync<string>(account, typeof(BindToStringProgram),
                (s) => BindToStringProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedContent, result);
        }

        [Fact(Skip = "TODO (kasobol-msft) reenable when we get base64/BinaryData in SDK")]
        public async Task QueueTrigger_IfBoundToStringAndMessageIsNotUtf8ByteArray_DoesNotBind()
        {
            // Arrange
            byte[] content = new byte[] { 0xFF, 0x00 }; // Not a valid UTF-8 byte sequence.
            var queue = await CreateQueue(account, QueueName);
            await queue.SendMessageAsync(Convert.ToBase64String(content));

            // Act
            Exception exception = await RunTriggerFailureAsync<string>(account, typeof(BindToStringProgram),
                (s) => BindToStringProgram.TaskSource = s);

            // Assert
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Exception binding parameter 'message'", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.IsType<DecoderFallbackException>(innerException);
            Assert.Equal("Unable to translate bytes [FF] at index -1 from specified code page to Unicode.",
                innerException.Message);
        }

        [Fact(Skip = "TODO (kasobol-msft) revisit this when base64/BinaryData is in the SDK")]
        public async Task QueueTrigger_IfBoundToByteArray_Binds()
        {
            byte[] expectedContent = new byte[] { 0x31, 0x32, 0x33 };
            await TestBindToByteArray(expectedContent);
        }

        [Fact]
        public async Task QueueTrigger_IfBoundToByteArrayAndMessageIsEmpty_Binds()
        {
            byte[] expectedContent = new byte[0];
            await TestBindToByteArray(expectedContent);
        }

        [Fact(Skip = "TODO (kasobol-msft) revisit this when base64/BinaryData is in the SDK")]
        public async Task QueueTrigger_IfBoundToByteArrayAndMessageIsNonUtf8_Binds()
        {
            byte[] expectedContent = new byte[] { 0xFF, 0x00 }; // Not a valid UTF-8 byte sequence.
            await TestBindToByteArray(expectedContent);
        }

        private async Task TestBindToByteArray(byte[] expectedContent) // TODO (kasobol-msft) Revisit base64 encoding story
        {
            // Arrange
            var queue = await CreateQueue(account, QueueName);
            await queue.SendMessageAsync(Convert.ToBase64String(expectedContent));

            // Act
            byte[] result = await RunTriggerAsync<byte[]>(account, typeof(BindToByteArrayProgram),
                (s) => BindToByteArrayProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedContent, result);
        }

        [Fact]
        public async Task QueueTrigger_IfBoundToPoco_Binds()
        {
            Poco expectedContent = new Poco { Value = "abc" };
            await TestBindToPoco(expectedContent);
        }

        [Fact]
        public async Task QueueTrigger_IfBoundToPocoAndMessageIsJsonNull_Binds()
        {
            Poco expectedContent = null;
            await TestBindToPoco(expectedContent);
        }

        private async Task TestBindToPoco(Poco expectedContent)
        {
            // Arrange
            var queue = await CreateQueue(account, QueueName);
            string content = JsonConvert.SerializeObject(expectedContent, typeof(Poco), settings: null);
            await queue.SendMessageAsync(content);

            // Act
            Poco result = await RunTriggerAsync<Poco>(account, typeof(BindToPocoProgram), (s) => BindToPocoProgram.TaskSource = s);

            // Assert
            AssertEqual(expectedContent, result);
        }

        private static void AssertEqual(Poco expected, Poco actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }

            Assert.NotNull(actual);
            Assert.Equal(expected.Value, actual.Value);
            Assert.Equal(expected.Int32Value, actual.Int32Value);
            AssertEqual(expected.Child, actual.Child);
        }

        [Fact]
        public async Task QueueTrigger_IfBoundToPocoAndMessageIsNotJson_DoesNotBind()
        {
            // Arrange
            const string content = "not json"; // Not a valid JSON byte sequence.
            var queue = await CreateQueue(account, QueueName);
            await queue.SendMessageAsync(content);

            // Act
            Exception exception = await RunTriggerFailureAsync<Poco>(account, typeof(BindToPocoProgram),
                (s) => BindToPocoProgram.TaskSource = s);

            // Assert
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Exception binding parameter 'message'", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.IsType<InvalidOperationException>(innerException);
            const string expectedInnerMessage = "Binding parameters to complex objects (such as 'Poco') uses " +
                "Json.NET serialization. 1. Bind the parameter type as 'string' instead of 'Poco' to get the raw " +
                "values and avoid JSON deserialization, or2. Change the queue payload to be valid json. The JSON " +
                "parser failed: Unexpected character encountered while parsing value: n. Path '', line 0, position " +
                "0.";
            string actual = Regex.Replace(innerException.Message, @"[\n\r]", "");
            Assert.Equal(expectedInnerMessage, actual);
        }

        [Fact]
        public async Task QueueTrigger_IfBoundToPocoAndMessageIsIncompatibleJson_DoesNotBind()
        {
            // Arrange
            const string content = "123"; // A JSON int rather than a JSON object.
            var queue = await CreateQueue(account, QueueName);
            await queue.SendMessageAsync(content);

            // Act
            Exception exception = await RunTriggerFailureAsync<Poco>(account, typeof(BindToPocoProgram),
                (s) => BindToPocoProgram.TaskSource = s);

            // Assert
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Exception binding parameter 'message'", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.IsType<InvalidOperationException>(innerException);
            string expectedInnerMessage = "Binding parameters to complex objects (such as 'Poco') uses Json.NET " +
                "serialization. 1. Bind the parameter type as 'string' instead of 'Poco' to get the raw values " +
                "and avoid JSON deserialization, or2. Change the queue payload to be valid json. The JSON parser " +
                "failed: Error converting value 123 to type '" + typeof(Poco).FullName + "'. Path '', line 1, " +
                "position 3.";
            string actual = Regex.Replace(innerException.Message, @"[\n\r]", "");
            Assert.Equal(expectedInnerMessage, actual);
        }

        [Fact]
        public async Task QueueTrigger_IfBoundToPocoStruct_Binds()
        {
            // Arrange
            const int expectedContent = 123;
            var queue = await CreateQueue(account, QueueName);
            string content = JsonConvert.SerializeObject(expectedContent, typeof(int), settings: null);
            await queue.SendMessageAsync(content);

            // Act
            int result = await RunTriggerAsync<int>(account, typeof(BindToPocoStructProgram),
                (s) => BindToPocoStructProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedContent, result);
        }

        [Fact]
        public async Task QueueTrigger_IfMessageIsString_ProvidesQueueTriggerBindingData()
        {
            // Arrange
            string expectedQueueTrigger = Guid.NewGuid().ToString();
            var queue = await CreateQueue(account, QueueName);
            await queue.SendMessageAsync(expectedQueueTrigger);

            // Act
            string result = await RunTriggerAsync<string>(account, typeof(BindToQueueTriggerBindingDataProgram),
                (s) => BindToQueueTriggerBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedQueueTrigger, result);
        }

        [Fact]
        public async Task QueueTrigger_IfMessageIsUtf8ByteArray_ProvidesQueueTriggerBindingData()
        {
            // Arrange
            const string expectedQueueTrigger = "abc";
            byte[] content = Encoding.UTF8.GetBytes(expectedQueueTrigger); // TODO (kasobol-msft) Revisit base64 encoding story
            var queue = await CreateQueue(account, QueueName);
            await queue.SendMessageAsync(expectedQueueTrigger);

            // Act
            string result = await RunTriggerAsync<string>(account, typeof(BindToQueueTriggerBindingDataProgram),
                (s) => BindToQueueTriggerBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedQueueTrigger, result);
        }

        [Fact(Skip = "TODO (kasobol-msft) revisit that when we get base64/BinaryData in the SDK")]
        public async Task QueueTrigger_IfMessageIsNonUtf8ByteArray_DoesNotProvideQueueTriggerBindingData()
        {
            // Arrange
            byte[] content = new byte[] { 0xFF, 0x00 }; // Not a valid UTF-8 byte sequence.
            var queue = await CreateQueue(account, QueueName);
            await queue.SendMessageAsync(Convert.ToBase64String(content));

            // Act
            Exception exception = await RunTriggerFailureAsync<string>(account, typeof(BindToQueueTriggerBindingDataProgram),
                (s) => BindToQueueTriggerBindingDataProgram.TaskSource = s);

            // Assert
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Exception binding parameter 'queueTrigger'", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.IsType<InvalidOperationException>(innerException);
            Assert.Equal("Binding data does not contain expected value 'queueTrigger'.", innerException.Message);
        }

        [Fact]
        public async Task QueueTrigger_ProvidesDequeueCountBindingData()
        {
            // Arrange
            var queue = await CreateQueue(account, QueueName);
            // message.DequeueCount is provided by FakeStorageAccount when the message is retrieved.
            await queue.SendMessageAsync("ignore");

            // Act
            long result = await RunTriggerAsync<long>(account, typeof(BindToDequeueCountBindingDataProgram),
                (s) => BindToDequeueCountBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task QueueTrigger_ProvidesExpirationTimeBindingData()
        {
            // Arrange
            var queue = await CreateQueue(account, QueueName);
            // message.ExpirationTime is provided by FakeStorageAccount when the message is inserted.
            await queue.SendMessageAsync("ignore");

            // Act
            DateTimeOffset result = await RunTriggerAsync<DateTimeOffset>(account, typeof(BindToExpirationTimeBindingDataProgram),
                (s) => BindToExpirationTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(0, (int)DateTimeOffset.Now.AddDays(7).Subtract(result).TotalDays);
        }

        [Fact]
        public async Task QueueTrigger_ProvidesIdBindingData()
        {
            // Arrange
            var queue = await CreateQueue(account, QueueName);
            // message.Id is provided by FakeStorageAccount when the message is inserted.
            await queue.SendMessageAsync("ignore");

            // Act
            string result = await RunTriggerAsync<string>(account, typeof(BindToIdBindingDataProgram),
                (s) => BindToIdBindingDataProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task QueueTrigger_ProvidesInsertionTimeBindingData()
        {
            // Arrange
            await SetupAsync(account, "ignore");

            // Act
            DateTimeOffset result = await RunTriggerAsync<DateTimeOffset>(account, typeof(BindToInsertionTimeBindingDataProgram),
                (s) => BindToInsertionTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(0, (int)DateTimeOffset.Now.Subtract(result).TotalHours);
        }

        [Fact]
        public async Task QueueTrigger_ProvidesNextVisibleTimeBindingData()
        {
            // Arrange
            await SetupAsync(account, "ignore");

            // Act
            DateTimeOffset result = await RunTriggerAsync<DateTimeOffset>(account, typeof(BindToNextVisibleTimeBindingDataProgram),
                (s) => BindToNextVisibleTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(0, (int)DateTimeOffset.Now.Subtract(result).TotalHours);
        }

        [Fact]
        public async Task QueueTrigger_ProvidesPopReceiptBindingData()
        {
            // Arrange
            await SetupAsync(account, "ignore");

            // Act
            string result = await RunTriggerAsync<string>(account, typeof(BindToPopReceiptBindingDataProgram),
                (s) => BindToPopReceiptBindingDataProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task QueueTrigger_ProvidesPocoStructPropertyBindingData()
        {
            // Arrange
            const int expectedInt32Value = 123;

            Poco value = new Poco { Int32Value = expectedInt32Value };
            string content = JsonConvert.SerializeObject(value, typeof(Poco), settings: null);

            await SetupAsync(account, content);

            // Act
            int result = await RunTriggerAsync<int>(account, typeof(BindToPocoStructPropertyBindingDataProgram),
                (s) => BindToPocoStructPropertyBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedInt32Value, result);
        }

        [Fact]
        public async Task QueueTrigger_ProvidesPocoComplexPropertyBindingData()
        {
            // Arrange
            Poco expectedChild = new Poco
            {
                Value = "abc",
                Int32Value = 123
            };

            Poco value = new Poco { Child = expectedChild };
            string content = JsonConvert.SerializeObject(value, typeof(Poco), settings: null);

            await SetupAsync(account, content);

            // Act
            Poco result = await RunTriggerAsync<Poco>(account, typeof(BindToPocoComplexPropertyBindingDataProgram),
                (s) => BindToPocoComplexPropertyBindingDataProgram.TaskSource = s);

            // Assert
            AssertEqual(expectedChild, result);
        }

        [Fact]
        public async Task QueueTrigger_IfBindingAlwaysFails_MovesToPoisonQueue()
        {
            // Arrange
            const string expectedContents = "abc";
            await SetupAsync(account, expectedContents);

            // Act
            string result = await RunTriggerAsync<string>(account, typeof(PoisonQueueProgram),
                (s) => PoisonQueueProgram.TaskSource = s,
                new string[] { typeof(PoisonQueueProgram).FullName + ".PutInPoisonQueue" });

            // Assert
            Assert.Equal(expectedContents, result);
        }

        [Fact]
        public async Task QueueTrigger_IfDequeueCountReachesMaxDequeueCount_MovesToPoisonQueue()
        {
            try
            {
                // Arrange
                const string expectedContents = "abc";
                await SetupAsync(account, expectedContents);

                // Act
                await RunTriggerAsync<object>(account, typeof(MaxDequeueCountProgram),
                    (s) => MaxDequeueCountProgram.TaskSource = s,
                    new string[] { typeof(MaxDequeueCountProgram).FullName + ".PutInPoisonQueue" });

                // Assert
                // These tests use the FakeQueuesOptionsSetup, so compare dequeue count to that
                FakeQueuesOptionsSetup optionsSetup = new FakeQueuesOptionsSetup();
                QueuesOptions options = new QueuesOptions();
                optionsSetup.Configure(options);
                Assert.Equal(options.MaxDequeueCount, MaxDequeueCountProgram.DequeueCount);
            }
            finally
            {
                MaxDequeueCountProgram.DequeueCount = 0;
            }
        }

        [Fact]
        public async Task CallQueueTrigger_IfArgumentIsCloudQueueMessage_Binds()
        {
            // Arrange
            QueueMessage expectedMessage = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", 0);

            // Act
            QueueMessage result = await CallQueueTriggerAsync<QueueMessage>(expectedMessage,
                typeof(BindToCloudQueueMessageProgram), (s) => BindToCloudQueueMessageProgram.TaskSource = s);

            // Assert
            Assert.Same(expectedMessage, result);
        }

        [Fact]
        public async Task CallQueueTrigger_IfArgumentIsString_Binds()
        {
            // Arrange
            const string expectedContents = "abc";

            // Act
            QueueMessage result = await CallQueueTriggerAsync<QueueMessage>(expectedContents,
                typeof(BindToCloudQueueMessageProgram), (s) => BindToCloudQueueMessageProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedContents, result.MessageText);
        }

        [Fact]
        public async Task CallQueueTrigger_IfArgumentIsIStorageQueueMessage_Binds()
        {
            // Arrange
            QueueMessage expectedMessage = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", 0);

            // Act
            QueueMessage result = await CallQueueTriggerAsync<QueueMessage>(expectedMessage,
                typeof(BindToCloudQueueMessageProgram), (s) => BindToCloudQueueMessageProgram.TaskSource = s);

            // Assert
            Assert.Same(expectedMessage, result);
        }

        [Fact]
        public async Task CallQueueTrigger_ProvidesDequeueCountBindingData()
        {
            // Arrange
            const long expectedDequeueCount = 123;
            QueueMessage message = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", expectedDequeueCount);

            // Act
            long result = await CallQueueTriggerAsync<long>(message, typeof(BindToDequeueCountBindingDataProgram),
                (s) => BindToDequeueCountBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedDequeueCount, result);
        }

        [Fact]
        public async Task CallQueueTrigger_ProvidesExpirationTimeBindingData()
        {
            // Arrange
            DateTimeOffset expectedExpirationTime = DateTimeOffset.Now;
            QueueMessage message = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", 0, expiresOn: expectedExpirationTime);

            // Act
            DateTimeOffset result = await CallQueueTriggerAsync<DateTimeOffset>(message,
                typeof(BindToExpirationTimeBindingDataProgram),
                (s) => BindToExpirationTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedExpirationTime, result);
        }

        [Fact]
        public async Task CallQueueTrigger_IfExpirationTimeIsNull_ProvidesMaxValueExpirationTimeBindingData()
        {
            // Arrange
            DateTimeOffset expectedExpirationTime = DateTimeOffset.Now;
            QueueMessage message = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", 0, expiresOn: null);

            // Act
            DateTimeOffset result = await CallQueueTriggerAsync<DateTimeOffset>(message,
                typeof(BindToExpirationTimeBindingDataProgram),
                (s) => BindToExpirationTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(DateTimeOffset.MaxValue, result);
        }

        [Fact]
        public async Task CallQueueTrigger_ProvidesIdBindingData()
        {
            // Arrange
            const string expectedId = "abc";
            QueueMessage message = QueuesModelFactory.QueueMessage(expectedId, "receipt", "ignore", 0);

            // Act
            string result = await CallQueueTriggerAsync<string>(message, typeof(BindToIdBindingDataProgram),
                (s) => BindToIdBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Same(expectedId, result);
        }

        [Fact]
        public async Task CallQueueTrigger_ProvidesInsertionTimeBindingData()
        {
            // Arrange
            DateTimeOffset expectedInsertionTime = DateTimeOffset.Now;
            QueueMessage message = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", 0, insertedOn: expectedInsertionTime);

            // Act
            DateTimeOffset result = await CallQueueTriggerAsync<DateTimeOffset>(message,
                typeof(BindToInsertionTimeBindingDataProgram),
                (s) => BindToInsertionTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedInsertionTime, result);
        }

        [Fact]
        public async Task CallQueueTrigger_IfInsertionTimeIsNull_ProvidesUtcNowInsertionTimeBindingData()
        {
            // Arrange
            DateTimeOffset expectedInsertionTime = DateTimeOffset.Now;
            QueueMessage message = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", 0, insertedOn: null);

            // Act
            DateTimeOffset result = await CallQueueTriggerAsync<DateTimeOffset>(message,
                typeof(BindToInsertionTimeBindingDataProgram),
                (s) => BindToInsertionTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(0, (int)DateTimeOffset.Now.Subtract(result).TotalMinutes);
            Assert.Equal(TimeSpan.Zero, result.Offset);
        }

        [Fact]
        public async Task CallQueueTrigger_ProvidesNextVisibleTimeBindingData()
        {
            // Arrange
            DateTimeOffset expectedNextVisibleTime = DateTimeOffset.Now;
            QueueMessage message = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", 0, nextVisibleOn: expectedNextVisibleTime);

            // Act
            DateTimeOffset result = await CallQueueTriggerAsync<DateTimeOffset>(message,
                typeof(BindToNextVisibleTimeBindingDataProgram),
                (s) => BindToNextVisibleTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(expectedNextVisibleTime, result);
        }

        [Fact]
        public async Task CallQueueTrigger_IfNextVisibleTimeIsNull_ProvidesMaxValueNextVisibleTimeBindingData()
        {
            // Arrange
            DateTimeOffset expectedNextVisibleTime = DateTimeOffset.Now;
            QueueMessage message = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", 0, nextVisibleOn: null);

            // Act
            DateTimeOffset result = await CallQueueTriggerAsync<DateTimeOffset>(message,
                typeof(BindToNextVisibleTimeBindingDataProgram),
                (s) => BindToNextVisibleTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Equal(DateTimeOffset.MaxValue, result);
        }

        [Fact]
        public async Task CallQueueTrigger_ProvidesPopReceiptBindingData()
        {
            // Arrange
            const string expectedPopReceipt = "abc";
            QueueMessage message = QueuesModelFactory.QueueMessage("id", expectedPopReceipt, "ignore", 0);

            // Act
            string result = await CallQueueTriggerAsync<string>(message, typeof(BindToPopReceiptBindingDataProgram),
                (s) => BindToPopReceiptBindingDataProgram.TaskSource = s);

            // Assert
            Assert.Same(expectedPopReceipt, result);
        }

        private static async Task<TResult> RunTriggerAsync<TResult>(StorageAccount account, Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(account, programType, setTaskSource);
        }

        private static async Task<TResult> RunTriggerAsync<TResult>(StorageAccount account, Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource, IEnumerable<string> ignoreFailureFunctions)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(account, programType, setTaskSource, ignoreFailureFunctions);
        }

        private static async Task<Exception> RunTriggerFailureAsync<TResult>(StorageAccount account, Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerFailureAsync<TResult>(account, programType, setTaskSource);
        }

        private async Task<TResult> CallQueueTriggerAsync<TResult>(object message, Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            var method = programType.GetMethod("Run");
            Assert.NotNull(method);

            var result = await FunctionalTest.CallAsync<TResult>(account, programType, method, new Dictionary<string, object>
            {
                { "message", message }
            }, setTaskSource);

            return result;
        }

        private static async Task<QueueClient> CreateQueue(StorageAccount account, string queueName)
        {
            var client = account.CreateQueueServiceClient();
            var queue = client.GetQueueClient(queueName);
            await queue.CreateIfNotExistsAsync();
            return queue;
        }

        private class BindToCloudQueueMessageProgram
        {
            public static TaskCompletionSource<QueueMessage> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] QueueMessage message)
            {
                TaskSource.TrySetResult(message);
            }
        }

        private class BindToStringProgram
        {
            public static TaskCompletionSource<string> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] string message)
            {
                TaskSource.TrySetResult(message);
            }
        }

        private class BindToByteArrayProgram
        {
            public static TaskCompletionSource<byte[]> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] byte[] message)
            {
                TaskSource.TrySetResult(message);
            }
        }

        private class BindToPocoProgram
        {
            public static TaskCompletionSource<Poco> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] Poco message)
            {
                TaskSource.TrySetResult(message);
            }
        }

        private class BindToPocoStructProgram
        {
            public static TaskCompletionSource<int> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] int message)
            {
                TaskSource.TrySetResult(message);
            }
        }

        private class BindToQueueTriggerBindingDataProgram
        {
            public static TaskCompletionSource<string> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] QueueMessage message, string queueTrigger)
            {
                TaskSource.TrySetResult(queueTrigger);
            }
        }

        private class BindToDequeueCountBindingDataProgram
        {
            public static TaskCompletionSource<long> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] QueueMessage message, long dequeueCount)
            {
                TaskSource.TrySetResult(dequeueCount);
            }
        }

        private class BindToExpirationTimeBindingDataProgram
        {
            public static TaskCompletionSource<DateTimeOffset> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] QueueMessage message, DateTimeOffset expirationTime)
            {
                TaskSource.TrySetResult(expirationTime);
            }
        }

        private class BindToIdBindingDataProgram
        {
            public static TaskCompletionSource<string> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] QueueMessage message, string id)
            {
                TaskSource.TrySetResult(id);
            }
        }

        private class BindToInsertionTimeBindingDataProgram
        {
            public static TaskCompletionSource<DateTimeOffset> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] QueueMessage message, DateTimeOffset insertionTime)
            {
                TaskSource.TrySetResult(insertionTime);
            }
        }

        private class BindToNextVisibleTimeBindingDataProgram
        {
            public static TaskCompletionSource<DateTimeOffset> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] QueueMessage message, DateTimeOffset nextVisibleTime)
            {
                TaskSource.TrySetResult(nextVisibleTime);
            }
        }

        private class BindToPopReceiptBindingDataProgram
        {
            public static TaskCompletionSource<string> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] QueueMessage message, string popReceipt)
            {
                TaskSource.TrySetResult(popReceipt);
            }
        }

        private class BindToPocoStructPropertyBindingDataProgram
        {
            public static TaskCompletionSource<int> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] Poco message, int int32Value)
            {
                TaskSource.TrySetResult(int32Value);
            }
        }

        private class BindToPocoComplexPropertyBindingDataProgram
        {
            public static TaskCompletionSource<Poco> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] Poco message, Poco child)
            {
                TaskSource.TrySetResult(child);
            }
        }

        private class Poco
        {
            public string Value { get; set; }

            public int Int32Value { get; set; }

            public Poco Child { get; set; }
        }

        private class PoisonQueueProgram
        {
            public static TaskCompletionSource<string> TaskSource { get; set; }

            public static void PutInPoisonQueue([QueueTrigger(QueueName)] string message)
            {
                throw new InvalidOperationException();
            }

            public static void ReceiveFromPoisonQueue([QueueTrigger(QueueName + "-poison")] string message)
            {
                TaskSource.TrySetResult(message);
            }
        }

        private class MaxDequeueCountProgram
        {
            public static TaskCompletionSource<object> TaskSource { get; set; }

            public static int DequeueCount { get; set; }

            public static void PutInPoisonQueue([QueueTrigger(QueueName)] string message)
            {
                DequeueCount++;
                throw new InvalidOperationException();
            }

            public static void ReceiveFromPoisonQueue([QueueTrigger(QueueName + "-poison")] string message)
            {
                TaskSource.TrySetResult(null);
            }
        }
    }
}
