// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class QueueTriggerTests
    {
        private const string QueueName = "input-queuetriggertests";
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            queueServiceClient.GetQueueClient(QueueName).DeleteIfExists();
            queueServiceClient.GetQueueClient(QueueName + "-poison").DeleteIfExists();
        }

        private async Task SetupAsync(QueueServiceClient client, object contents)
        {
            BinaryData message;
            if (contents is string str)
            {
                message = BinaryData.FromString(str);
            }
            else if (contents is byte[] bytearray)
            {
                message = BinaryData.FromBytes(bytearray);
            }
            else
            {
                throw new InvalidOperationException("bad test");
            }

            var queue = await CreateQueue(client, QueueName);

            // message.InsertionTime is provided by FakeStorageAccount when the message is inserted.
            await queue.SendMessageAsync(message);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToCloudQueueMessage_Binds()
        {
            // Arrange
            string expectedGuid = Guid.NewGuid().ToString();
            var queue = await CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(expectedGuid);

            // Act
            QueueMessage result = await RunTriggerAsync<QueueMessage>(typeof(BindToCloudQueueMessageProgram),
                (s) => BindToCloudQueueMessageProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(expectedGuid, result.MessageText);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToString_Binds()
        {
            string expectedContent = Guid.NewGuid().ToString();
            await TestBindToString(expectedContent);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToStringAndMessageIsEmpty_Binds()
        {
            await TestBindToString(string.Empty);
        }

        private async Task TestBindToString(string expectedContent)
        {
            // Arrange
            var queue = await CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(expectedContent);

            // Act
            string result = await RunTriggerAsync<string>(typeof(BindToStringProgram),
                (s) => BindToStringProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(expectedContent, result);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToStringAndMessageIsNotUtf8ByteArray_DoesNotBind()
        {
            // Arrange
            byte[] content = new byte[] { 0xFF, 0x00 }; // Not a valid UTF-8 byte sequence.
            var queue = await CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(BinaryData.FromBytes(content));

            // Act
            Exception exception = await RunTriggerFailureAsync<string>(typeof(BindToStringProgram),
                (s) => BindToStringProgram.TaskSource = s);

            // Assert
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Exception binding parameter 'message'", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.IsInstanceOf<DecoderFallbackException>(innerException);
            StringAssert.IsMatch("Unable to translate bytes \\[FF\\] at index .*? from specified code page to Unicode.",
                innerException.Message);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToByteArray_Binds()
        {
            byte[] expectedContent = new byte[] { 0x31, 0x32, 0x33 };
            await TestBindToByteArray(expectedContent);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToByteArrayAndMessageIsEmpty_Binds()
        {
            byte[] expectedContent = new byte[0];
            await TestBindToByteArray(expectedContent);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToByteArrayAndMessageIsNonUtf8_Binds()
        {
            byte[] expectedContent = new byte[] { 0xFF, 0x00 }; // Not a valid UTF-8 byte sequence.
            await TestBindToByteArray(expectedContent);
        }

        private async Task TestBindToByteArray(byte[] expectedContent)
        {
            // Arrange
            var queue = await CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(BinaryData.FromBytes(expectedContent));

            // Act
            byte[] result = await RunTriggerAsync<byte[]>(typeof(BindToByteArrayProgram),
                (s) => BindToByteArrayProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(expectedContent, result);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToBinaryData_Binds()
        {
            byte[] expectedContent = new byte[] { 0x31, 0x32, 0x33 };
            await TestBindToBinaryData(expectedContent);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToBinaryDataAndMessageIsEmpty_Binds()
        {
            byte[] expectedContent = new byte[0];
            await TestBindToBinaryData(expectedContent);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToBinaryDataAndMessageIsNonUtf8_Binds()
        {
            byte[] expectedContent = new byte[] { 0xFF, 0x00 }; // Not a valid UTF-8 byte sequence.
            await TestBindToBinaryData(expectedContent);
        }

        private async Task TestBindToBinaryData(byte[] expectedContent)
        {
            // Arrange
            var queue = await CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(BinaryData.FromBytes(expectedContent));

            // Act
            BinaryData result = await RunTriggerAsync<BinaryData>(typeof(BindToBinaryDataProgram),
                (s) => BindToBinaryDataProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(expectedContent, result.ToArray());
        }

        [Test]
        public async Task QueueTrigger_IfBoundToPoco_Binds()
        {
            Poco expectedContent = new Poco { Value = "abc" };
            await TestBindToPoco(expectedContent);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToPocoAndMessageIsJsonNull_Binds()
        {
            Poco expectedContent = null;
            await TestBindToPoco(expectedContent);
        }

        private async Task TestBindToPoco(Poco expectedContent)
        {
            // Arrange
            var queue = await CreateQueue(queueServiceClient, QueueName);
            string content = JsonConvert.SerializeObject(expectedContent, typeof(Poco), settings: null);
            await queue.SendMessageAsync(content);

            // Act
            Poco result = await RunTriggerAsync<Poco>(typeof(BindToPocoProgram), (s) => BindToPocoProgram.TaskSource = s);

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
            Assert.AreEqual(expected.Value, actual.Value);
            Assert.AreEqual(expected.Int32Value, actual.Int32Value);
            AssertEqual(expected.Child, actual.Child);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToPocoAndMessageIsNotJson_DoesNotBind()
        {
            // Arrange
            const string content = "not json"; // Not a valid JSON byte sequence.
            var queue = await CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(content);

            // Act
            Exception exception = await RunTriggerFailureAsync<Poco>(typeof(BindToPocoProgram),
                (s) => BindToPocoProgram.TaskSource = s);

            // Assert
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Exception binding parameter 'message'", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.IsInstanceOf<InvalidOperationException>(innerException);
            const string expectedInnerMessage = "Binding parameters to complex objects (such as 'Poco') uses " +
                "Json.NET serialization. 1. Bind the parameter type as 'string' instead of 'Poco' to get the raw " +
                "values and avoid JSON deserialization, or2. Change the queue payload to be valid json. The JSON " +
                "parser failed: Unexpected character encountered while parsing value: n. Path '', line 0, position " +
                "0.";
            string actual = Regex.Replace(innerException.Message, @"[\n\r]", "");
            Assert.AreEqual(expectedInnerMessage, actual);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToPocoAndMessageIsIncompatibleJson_DoesNotBind()
        {
            // Arrange
            const string content = "123"; // A JSON int rather than a JSON object.
            var queue = await CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(content);

            // Act
            Exception exception = await RunTriggerFailureAsync<Poco>(typeof(BindToPocoProgram),
                (s) => BindToPocoProgram.TaskSource = s);

            // Assert
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Exception binding parameter 'message'", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.IsInstanceOf<InvalidOperationException>(innerException);
            string expectedInnerMessage = "Binding parameters to complex objects (such as 'Poco') uses Json.NET " +
                "serialization. 1. Bind the parameter type as 'string' instead of 'Poco' to get the raw values " +
                "and avoid JSON deserialization, or2. Change the queue payload to be valid json. The JSON parser " +
                "failed: Error converting value 123 to type '" + typeof(Poco).FullName + "'. Path '', line 1, " +
                "position 3.";
            string actual = Regex.Replace(innerException.Message, @"[\n\r]", "");
            Assert.AreEqual(expectedInnerMessage, actual);
        }

        [Test]
        public async Task QueueTrigger_IfBoundToPocoStruct_Binds()
        {
            // Arrange
            const int expectedContent = 123;
            var queue = await CreateQueue(queueServiceClient, QueueName);
            string content = JsonConvert.SerializeObject(expectedContent, typeof(int), settings: null);
            await queue.SendMessageAsync(content);

            // Act
            int result = await RunTriggerAsync<int>(typeof(BindToPocoStructProgram),
                (s) => BindToPocoStructProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(expectedContent, result);
        }

        [Test]
        public async Task QueueTrigger_IfMessageIsString_ProvidesQueueTriggerBindingData()
        {
            // Arrange
            string expectedQueueTrigger = Guid.NewGuid().ToString();
            var queue = await CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(expectedQueueTrigger);

            // Act
            string result = await RunTriggerAsync<string>(typeof(BindToQueueTriggerBindingDataProgram),
                (s) => BindToQueueTriggerBindingDataProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(expectedQueueTrigger, result);
        }

        [Test]
        public async Task QueueTrigger_IfMessageIsUtf8ByteArray_ProvidesQueueTriggerBindingData()
        {
            // Arrange
            const string expectedQueueTrigger = "abc";
            byte[] content = Encoding.UTF8.GetBytes(expectedQueueTrigger);
            var queue = await CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(BinaryData.FromBytes(content));

            // Act
            string result = await RunTriggerAsync<string>(typeof(BindToQueueTriggerBindingDataProgram),
                (s) => BindToQueueTriggerBindingDataProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(expectedQueueTrigger, result);
        }

        [Test]
        public async Task QueueTrigger_IfMessageIsNonUtf8ByteArray_DoesNotProvideQueueTriggerBindingData()
        {
            // Arrange
            byte[] content = new byte[] { 0xFF, 0x00 }; // Not a valid UTF-8 byte sequence.
            var queue = await CreateQueue(queueServiceClient, QueueName);
            await queue.SendMessageAsync(BinaryData.FromBytes(content));

            // Act
            Exception exception = await RunTriggerFailureAsync<string>(typeof(BindToQueueTriggerBindingDataProgram),
                (s) => BindToQueueTriggerBindingDataProgram.TaskSource = s);

            // Assert
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Exception binding parameter 'queueTrigger'", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.IsInstanceOf<InvalidOperationException>(innerException);
            Assert.AreEqual("Binding data does not contain expected value 'queueTrigger'.", innerException.Message);
        }

        [Test]
        public async Task QueueTrigger_ProvidesDequeueCountBindingData()
        {
            // Arrange
            var queue = await CreateQueue(queueServiceClient, QueueName);
            // message.DequeueCount is provided by FakeStorageAccount when the message is retrieved.
            await queue.SendMessageAsync("ignore");

            // Act
            long result = await RunTriggerAsync<long>(typeof(BindToDequeueCountBindingDataProgram),
                (s) => BindToDequeueCountBindingDataProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task QueueTrigger_ProvidesExpirationTimeBindingData()
        {
            // Arrange
            var queue = await CreateQueue(queueServiceClient, QueueName);
            // message.ExpirationTime is provided by FakeStorageAccount when the message is inserted.
            await queue.SendMessageAsync("ignore");

            // Act
            DateTimeOffset result = await RunTriggerAsync<DateTimeOffset>(typeof(BindToExpirationTimeBindingDataProgram),
                (s) => BindToExpirationTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(0, (int)DateTimeOffset.Now.AddDays(7).Subtract(result).TotalDays);
        }

        [Test]
        public async Task QueueTrigger_ProvidesIdBindingData()
        {
            // Arrange
            var queue = await CreateQueue(queueServiceClient, QueueName);
            // message.Id is provided by FakeStorageAccount when the message is inserted.
            await queue.SendMessageAsync("ignore");

            // Act
            string result = await RunTriggerAsync<string>(typeof(BindToIdBindingDataProgram),
                (s) => BindToIdBindingDataProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            CollectionAssert.IsNotEmpty(result);
        }

        [Test]
        public async Task QueueTrigger_ProvidesInsertionTimeBindingData()
        {
            // Arrange
            await SetupAsync(queueServiceClient, "ignore");

            // Act
            DateTimeOffset result = await RunTriggerAsync<DateTimeOffset>(typeof(BindToInsertionTimeBindingDataProgram),
                (s) => BindToInsertionTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(0, (int)DateTimeOffset.Now.Subtract(result).TotalHours);
        }

        [Test]
        public async Task QueueTrigger_ProvidesNextVisibleTimeBindingData()
        {
            // Arrange
            await SetupAsync(queueServiceClient, "ignore");

            // Act
            DateTimeOffset result = await RunTriggerAsync<DateTimeOffset>(typeof(BindToNextVisibleTimeBindingDataProgram),
                (s) => BindToNextVisibleTimeBindingDataProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(0, (int)DateTimeOffset.Now.Subtract(result).TotalHours);
        }

        [Test]
        public async Task QueueTrigger_ProvidesPopReceiptBindingData()
        {
            // Arrange
            await SetupAsync(queueServiceClient, "ignore");

            // Act
            string result = await RunTriggerAsync<string>(typeof(BindToPopReceiptBindingDataProgram),
                (s) => BindToPopReceiptBindingDataProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            CollectionAssert.IsNotEmpty(result);
        }

        [Test]
        public async Task QueueTrigger_ProvidesPocoStructPropertyBindingData()
        {
            // Arrange
            const int expectedInt32Value = 123;

            Poco value = new Poco { Int32Value = expectedInt32Value };
            string content = JsonConvert.SerializeObject(value, typeof(Poco), settings: null);

            await SetupAsync(queueServiceClient, content);

            // Act
            int result = await RunTriggerAsync<int>(typeof(BindToPocoStructPropertyBindingDataProgram),
                (s) => BindToPocoStructPropertyBindingDataProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(expectedInt32Value, result);
        }

        [Test]
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

            await SetupAsync(queueServiceClient, content);

            // Act
            Poco result = await RunTriggerAsync<Poco>(typeof(BindToPocoComplexPropertyBindingDataProgram),
                (s) => BindToPocoComplexPropertyBindingDataProgram.TaskSource = s);

            // Assert
            AssertEqual(expectedChild, result);
        }

        [Test]
        public async Task QueueTrigger_IfBindingAlwaysFails_MovesToPoisonQueue()
        {
            // Arrange
            const string expectedContents = "abc";
            await SetupAsync(queueServiceClient, expectedContents);

            // Act
            string result = await RunTriggerAsync<string>(typeof(PoisonQueueProgram),
                (s) => PoisonQueueProgram.TaskSource = s,
                new string[] { typeof(PoisonQueueProgram).Name + ".PutInPoisonQueue" });

            // Assert
            Assert.AreEqual(expectedContents, result);
        }

        [Test]
        public async Task QueueTrigger_IfDequeueCountReachesMaxDequeueCount_MovesToPoisonQueue()
        {
            try
            {
                // Arrange
                const string expectedContents = "abc";
                await SetupAsync(queueServiceClient, expectedContents);

                // Act
                await RunTriggerAsync<object>(typeof(MaxDequeueCountProgram),
                    (s) => MaxDequeueCountProgram.TaskSource = s,
                    new string[] { typeof(MaxDequeueCountProgram).Name + ".PutInPoisonQueue" });

                // Assert
                // These tests use the FakeQueuesOptionsSetup, so compare dequeue count to that
                FakeQueuesOptionsSetup optionsSetup = new FakeQueuesOptionsSetup();
                QueuesOptions options = new QueuesOptions();
                optionsSetup.Configure(options);
                Assert.AreEqual(options.MaxDequeueCount, MaxDequeueCountProgram.DequeueCount);
            }
            finally
            {
                MaxDequeueCountProgram.DequeueCount = 0;
            }
        }

        [Test]
        public async Task CallQueueTrigger_IfArgumentIsCloudQueueMessage_Binds()
        {
            // Arrange
            QueueMessage expectedMessage = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", 0);

            // Act
            QueueMessage result = await CallQueueTriggerAsync<QueueMessage>(expectedMessage,
                typeof(BindToCloudQueueMessageProgram), (s) => BindToCloudQueueMessageProgram.TaskSource = s);

            // Assert
            Assert.AreSame(expectedMessage, result);
        }

        [Test]
        public async Task CallQueueTrigger_IfArgumentIsString_Binds()
        {
            // Arrange
            const string expectedContents = "abc";

            // Act
            QueueMessage result = await CallQueueTriggerAsync<QueueMessage>(expectedContents,
                typeof(BindToCloudQueueMessageProgram), (s) => BindToCloudQueueMessageProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedContents, result.MessageText);
        }

        [Test]
        public async Task CallQueueTrigger_IfArgumentIsIStorageQueueMessage_Binds()
        {
            // Arrange
            QueueMessage expectedMessage = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", 0);

            // Act
            QueueMessage result = await CallQueueTriggerAsync<QueueMessage>(expectedMessage,
                typeof(BindToCloudQueueMessageProgram), (s) => BindToCloudQueueMessageProgram.TaskSource = s);

            // Assert
            Assert.AreSame(expectedMessage, result);
        }

        [Test]
        public async Task CallQueueTrigger_ProvidesDequeueCountBindingData()
        {
            // Arrange
            const long expectedDequeueCount = 123;
            QueueMessage message = QueuesModelFactory.QueueMessage("id", "receipt", "ignore", expectedDequeueCount);

            // Act
            long result = await CallQueueTriggerAsync<long>(message, typeof(BindToDequeueCountBindingDataProgram),
                (s) => BindToDequeueCountBindingDataProgram.TaskSource = s);

            // Assert
            Assert.AreEqual(expectedDequeueCount, result);
        }

        [Test]
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
            Assert.AreEqual(expectedExpirationTime, result);
        }

        [Test]
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
            Assert.AreEqual(DateTimeOffset.MaxValue, result);
        }

        [Test]
        public async Task CallQueueTrigger_ProvidesIdBindingData()
        {
            // Arrange
            const string expectedId = "abc";
            QueueMessage message = QueuesModelFactory.QueueMessage(expectedId, "receipt", "ignore", 0);

            // Act
            string result = await CallQueueTriggerAsync<string>(message, typeof(BindToIdBindingDataProgram),
                (s) => BindToIdBindingDataProgram.TaskSource = s);

            // Assert
            Assert.AreSame(expectedId, result);
        }

        [Test]
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
            Assert.AreEqual(expectedInsertionTime, result);
        }

        [Test]
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
            Assert.AreEqual(0, (int)DateTimeOffset.Now.Subtract(result).TotalMinutes);
            Assert.AreEqual(TimeSpan.Zero, result.Offset);
        }

        [Test]
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
            Assert.AreEqual(expectedNextVisibleTime, result);
        }

        [Test]
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
            Assert.AreEqual(DateTimeOffset.MaxValue, result);
        }

        [Test]
        public async Task CallQueueTrigger_ProvidesPopReceiptBindingData()
        {
            // Arrange
            const string expectedPopReceipt = "abc";
            QueueMessage message = QueuesModelFactory.QueueMessage("id", expectedPopReceipt, "ignore", 0);

            // Act
            string result = await CallQueueTriggerAsync<string>(message, typeof(BindToPopReceiptBindingDataProgram),
                (s) => BindToPopReceiptBindingDataProgram.TaskSource = s);

            // Assert
            Assert.AreSame(expectedPopReceipt, result);
        }

        private async Task<TResult> RunTriggerAsync<TResult>(Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(b => ConfigureQueues(b), programType, setTaskSource);
        }

        private async Task<TResult> RunTriggerAsync<TResult>(Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource, IEnumerable<string> ignoreFailureFunctions)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(b => ConfigureQueues(b), programType, setTaskSource, ignoreFailureFunctions);
        }

        private async Task<Exception> RunTriggerFailureAsync<TResult>(Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerFailureAsync<TResult>(b => ConfigureQueues(b), programType, setTaskSource);
        }

        private async Task<TResult> CallQueueTriggerAsync<TResult>(object message, Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            var method = programType.GetMethod("Run");
            Assert.NotNull(method);

            var result = await FunctionalTest.CallAsync<TResult>(b => ConfigureQueues(b), programType, method, new Dictionary<string, object>
            {
                { "message", message }
            }, setTaskSource);

            return result;
        }

        private void ConfigureQueues(IWebJobsBuilder builder)
        {
            builder.AddAzureStorageQueues();
            builder.Services.AddSingleton<IConfigureOptions<QueuesOptions>, FakeQueuesOptionsSetup>();
            builder.UseQueueService(queueServiceClient);
        }

        private static async Task<QueueClient> CreateQueue(QueueServiceClient client, string queueName)
        {
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

        private class BindToBinaryDataProgram
        {
            public static TaskCompletionSource<BinaryData> TaskSource { get; set; }

            public static void Run([QueueTrigger(QueueName)] BinaryData message)
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
