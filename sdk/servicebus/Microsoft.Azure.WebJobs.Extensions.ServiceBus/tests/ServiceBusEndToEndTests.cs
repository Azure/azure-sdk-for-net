// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Tests;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Transactions;
using Azure.Core.Shared;
using Azure.Core.Tests;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Extensions.Configuration;
using Constants = Microsoft.Azure.WebJobs.ServiceBus.Constants;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class ServiceBusEndToEndTests : WebJobsServiceBusTestBase
    {
        private const string TriggerDetailsMessageStart = "Trigger Details:";
        private const string DrainingQueueMessageBody = "queue-message-draining-no-sessions-1";
        private const string DrainingTopicMessageBody = "topic-message-draining-no-sessions-1";

        // These two variables will be checked at the end of the test
        private static string _resultMessage1;
        private static string _resultMessage2;

        public ServiceBusEndToEndTests() : base(isSession: false)
        {
        }

        [Test]
        public async Task ServiceBusEndToEnd()
        {
            var host = BuildHost<ServiceBusTestJobs>(startHost: false);
            using (host)
            {
                await ServiceBusEndToEndInternal<ServiceBusTestJobs>(host);
            }
        }

        [Test]
        public async Task ServiceBusEndToEndTokenCredential()
        {
            var host = BuildHost<ServiceBusTestJobs>(startHost: false, useTokenCredential: true);
            using (host)
            {
                await ServiceBusEndToEndInternal<ServiceBusTestJobs>(host);
            }
        }

        [Test]
        public async Task ServiceBusBinderTestAsyncCollector()
        {
            var host = BuildHost<BinderTestJobsAsyncCollector>();
            using (host)
            {
                int numMessages = 10;
                var jobHost = host.GetJobHost();
                var args = new { message = "Test Message", numMessages = numMessages };
                await jobHost.CallAsync(nameof(BinderTestJobsAsyncCollector.ServiceBusBinderTest), args);
                await jobHost.CallAsync(nameof(BinderTestJobsAsyncCollector.ServiceBusBinderTest), args);
                await jobHost.CallAsync(nameof(BinderTestJobsAsyncCollector.ServiceBusBinderTest), args);

                var count = await CleanUpEntity(FirstQueueScope.QueueName);

                Assert.AreEqual(numMessages * 3, count);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task ServiceBusBinderTestSyncCollector()
        {
            var host = BuildHost<BinderTestJobsSyncCollector>();
            using (host)
            {
                int numMessages = 10;
                var args = new { message = "Test Message", numMessages = numMessages };
                var jobHost = host.GetJobHost();
                await jobHost.CallAsync(nameof(BinderTestJobsSyncCollector.ServiceBusBinderTest), args);
                await jobHost.CallAsync(nameof(BinderTestJobsSyncCollector.ServiceBusBinderTest), args);
                await jobHost.CallAsync(nameof(BinderTestJobsSyncCollector.ServiceBusBinderTest), args);

                var count = await CleanUpEntity(FirstQueueScope.QueueName);

                Assert.AreEqual(numMessages * 3, count);
                await host.StopAsync();
            }
        }

        private async Task<int> CleanUpEntity(string queueName)
        {
            await using var client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
            var receiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
            {
                ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete
            });
            ServiceBusReceivedMessage message;
            int count = 0;

            do
            {
                message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                if (message != null)
                {
                    count++;
                }
                else
                {
                    break;
                }
            } while (true);
            return count;
        }

        [Test]
        public async Task CustomMessageProcessorTest()
        {
            var host = BuildHost<ServiceBusTestJobs>(host =>
                host.ConfigureServices(services =>
                {
                    services.AddSingleton<MessagingProvider, CustomMessagingProvider>();
                }),
                startHost: false);

            using (host)
            {
                var loggerProvider = host.GetTestLoggerProvider();

                await ServiceBusEndToEndInternal<ServiceBusTestJobs>(host);

                // in addition to verifying that our custom processor was called, we're also
                // verifying here that extensions can log
                IEnumerable<LogMessage> messages = loggerProvider.GetAllLogMessages().Where(m => m.Category == CustomMessagingProvider.CustomMessagingCategory);
                Assert.AreEqual(4, messages.Count(p => p.FormattedMessage.Contains("Custom processor Begin called!")));
                Assert.AreEqual(4, messages.Count(p => p.FormattedMessage.Contains("Custom processor End called!")));
                await host.StopAsync();
            }
        }

        [Test]
        public async Task MultipleAccountTest()
        {
            var host = BuildHost<ServiceBusTestJobs>(host =>
                host.ConfigureServices(services =>
                {
                    services.AddSingleton<MessagingProvider, CustomMessagingProvider>();
                }));
            using (host)
            {
                await WriteQueueMessage(
                    "Test",
                    connectionString: ServiceBusTestEnvironment.Instance.ServiceBusSecondaryNamespaceConnectionString,
                    queueName: SecondaryNamespaceQueueScope.QueueName);

                _topicSubscriptionCalled1.WaitOne(SBTimeoutMills);
                _topicSubscriptionCalled2.WaitOne(SBTimeoutMills);

                // ensure all logs have had a chance to flush
                await Task.Delay(3000);
                await host.StopAsync();
            }

            Assert.AreEqual("Test-topic-1", _resultMessage1);
            Assert.AreEqual("Test-topic-2", _resultMessage2);
        }

        [Test]
        public async Task TestBatch_String()
        {
            await TestMultiple<ServiceBusMultipleMessagesTestJob_BindToStringArray>();
        }

        [Test]
        public async Task TestBatch_Messages()
        {
            await TestMultiple<ServiceBusMultipleMessagesTestJob_BindToMessageArray>();
        }

        [Test]
         public async Task TestBatch_MinBatchSize()
        {
            await TestMultiple_MinBatch<TestBatchMinBatchSize>(
                configurationDelegate: SetUpMinimumBatchSize);
        }

        [Test]
        public async Task TestBatch_MinBatchSize_WithPartialBatch()
        {
            await TestMultiple_MinBatch_PartialBatch<TestBatchMinBatchSize_PartialBatch>(
                configurationDelegate: SetUpMinimumBatchSize);
        }

        [Test]
        public async Task TestBatch_AutoCompleteMessagesDisabledOnTrigger()
        {
            await TestMultiple<TestBatchAutoCompleteMessagesDisabledOnTrigger>();
        }

        [Test]
        public async Task TestBatch_AutoCompleteEnabledOnTrigger()
        {
            await TestMultiple<TestBatchAutoCompleteMessagesEnabledOnTrigger>(
                configurationDelegate: DisableAutoComplete);
        }

        [Test]
        public async Task TestBatch_AutoCompleteEnabledOnTrigger_CompleteInFunction()
        {
            await TestMultiple<TestBatchAutoCompleteMessagesEnabledOnTrigger_CompleteInFunction>(
                configurationDelegate: DisableAutoComplete);
        }

        [Test]
        public async Task TestSingle_AutoCompleteEnabledOnTrigger_CompleteInFunction()
        {
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            var host = BuildHost<TestSingleAutoCompleteMessagesEnabledOnTrigger_CompleteInFunction>(
                DisableAutoComplete);
            using (host)
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestBatch_MaxMessageBatchSizeProvidedOnTrigger()
        {
            await TestMultiple<TestBatchMaxMessageBatchSizeOnTrigger>();
        }

        [Test]
        public async Task TestSingle_InfiniteLockRenewal()
        {
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            var host = BuildHost<TestSingleInfiniteLockRenewal>(
                SetInfiniteLockRenewal);
            using (host)
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
                var logs = host.GetTestLoggerProvider().GetAllLogMessages();
                Assert.IsNotEmpty(logs.Where(message => message.FormattedMessage.Contains("RenewMessageLock")));
            }
        }

        [Test]
        public async Task TestSingle_Dispose()
        {
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            var host = BuildHost<TestSingleDispose>();

            bool result = _waitHandle1.WaitOne(SBTimeoutMills);
            Assert.True(result);
            host.Dispose();
        }

        [Test]
        public async Task TestSingle_StopWithoutDrain()
        {
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            var host = BuildHost<TestSingleDispose>();

            bool result = _waitHandle1.WaitOne(SBTimeoutMills);
            Assert.True(result);
            await host.StopAsync();
        }

        [Test]
        public async Task TestBatch_Dispose()
        {
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            var host = BuildHost<TestBatchDispose>();

            bool result = _waitHandle1.WaitOne(SBTimeoutMills);
            Assert.True(result);
            await host.StopAsync();
        }

        [Test]
        public async Task TestBatch_StopWithoutDrain()
        {
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            var host = BuildHost<TestBatchDispose>();

            bool result = _waitHandle1.WaitOne(SBTimeoutMills);
            Assert.True(result);
            host.Dispose();
        }

        [Test]
        public async Task TestSingle_AutoCompleteDisabledOnTrigger_AbandonsWhenException()
        {
            await TestAutoCompleteDisabledOnTrigger_AbandonsWhenException<TestSingleAutoCompleteMessagesEnabledOnTriggerException>();
        }

        [Test]
        public async Task TestBatch_AutoCompleteDisabledOnTrigger_AbandonsWhenException()
        {
            await TestAutoCompleteDisabledOnTrigger_AbandonsWhenException<TestBatchAutoCompleteMessagesEnabledOnTriggerException>();
        }

        private async Task TestAutoCompleteDisabledOnTrigger_AbandonsWhenException<T>()
        {
            int messageCount = 2;
            for (int i = 0; i < messageCount; i++)
            {
                await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            }

            // Intentionally skipping validation as we are expecting errors in the error log
            // for this test, so we accept that the stop will not be graceful.
            using (var host = BuildHost<T>(
                host => host.ConfigureWebJobs(b => b.AddServiceBus(options =>
                {
                    options.MaxConcurrentCalls = 1;
                    options.MaxMessageBatchSize = 1;
                })),
                skipValidation: true))
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }

            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
            await using ServiceBusReceiver receiver = client.CreateReceiver(FirstQueueScope.QueueName, new ServiceBusReceiverOptions {ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete});

            // all messages should have been abandoned, so we should be able to receive them right away
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            int remaining = messageCount;
            while (!tokenSource.IsCancellationRequested && remaining > 0)
            {
                try
                {
                    var receivedMessages = await receiver.ReceiveMessagesAsync(remaining, TimeSpan.FromSeconds(5), tokenSource.Token);
                    remaining -= receivedMessages.Count;
                }
                catch (OperationCanceledException)
                {
                }
            }
            Assert.AreEqual(0, remaining);
        }

        [Test]
        public async Task TestSingle_CrossEntityTransaction()
        {
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            var host = BuildHost<TestCrossEntityTransaction>(EnableCrossEntityTransactions);
            using (host)
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestBatch_CrossEntityTransaction()
        {
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            var host = BuildHost<TestCrossEntityTransactionBatch>(EnableCrossEntityTransactions);
            using (host)
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestSingle_CustomErrorHandler()
        {
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");

            // Intentionally skipping validation as we are expecting errors in the error log
            // for this test, so we accept that the stop will not be graceful.
            var host = BuildHost<TestCustomErrorHandler>(SetCustomErrorHandler, skipValidation: true);
            using (host)
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestSingle_ReceiveFromFunction()
        {
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            var host = BuildHost<TestReceiveFromFunction>();
            using (host)
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                // Delay to make sure function is done executing
                await Task.Delay(500);
                Assert.ThrowsAsync<InvalidOperationException>(async () =>
                    await TestReceiveFromFunction.ReceiveActions.ReceiveMessagesAsync(1));
                Assert.ThrowsAsync<InvalidOperationException>(async () =>
                    await TestReceiveFromFunction.ReceiveActions.PeekMessagesAsync(1));
                Assert.ThrowsAsync<InvalidOperationException>(async () =>
                    await TestReceiveFromFunction.ReceiveActions.ReceiveDeferredMessagesAsync(Array.Empty<long>()));
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestSingle_ReceiveFromDeadLetterQueue()
        {
            await WriteTopicMessage("{'Name': 'Test1', 'Value': 'Value'}");
            var host = BuildHost<TestReceiveFromDeadLetterQueue>();
            using (host)
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestBatch_ReceiveFromFunction()
        {
            for (int i = 0; i < TestReceiveFromFunction_Batch.MessageCount; i++)
            {
                await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            }

            var host = BuildHost<TestReceiveFromFunction_Batch>(
                builder =>
                {
                    builder.ConfigureWebJobs(b => b.AddServiceBus(options =>
                    {
                        options.MaxMessageBatchSize = TestReceiveFromFunction_Batch.MessageCount - 1;
                    }));
                });
            using (host)
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                // Delay to make sure function is done executing
                await Task.Delay(500);
                Assert.ThrowsAsync<InvalidOperationException>(async () =>
                    await TestReceiveFromFunction_Batch.ReceiveActions.ReceiveMessagesAsync(1));
                Assert.ThrowsAsync<InvalidOperationException>(async () =>
                    await TestReceiveFromFunction_Batch.ReceiveActions.PeekMessagesAsync(1));
                Assert.ThrowsAsync<InvalidOperationException>(async () =>
                    await TestReceiveFromFunction_Batch.ReceiveActions.ReceiveDeferredMessagesAsync(Array.Empty<long>()));
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestBatch_JsonPoco()
        {
            await TestMultiple<ServiceBusMultipleMessagesTestJob_BindToPocoArray>();
        }

        [Test]
        public async Task TestBatch_ProcessMessagesSpan()
        {
            using var listener = new ClientDiagnosticListener(DiagnosticProperty.DiagnosticNamespace);
            await TestMultiple<ServiceBusMultipleMessagesTestJob_BindToPocoArray>();
            var scope = listener.AssertAndRemoveScope(Constants.ProcessMessagesActivityName);
            var tags = scope.Activity.Tags.ToList();
            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.MessageBusDestination, FirstQueueScope.QueueName));
            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.PeerAddress, ServiceBusTestEnvironment.Instance.FullyQualifiedNamespace));
            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.Component, DiagnosticProperty.ServiceBusServiceContext));
            Assert.AreEqual(2, scope.LinkedActivities.Count);
            Assert.IsTrue(scope.IsCompleted);
        }

        [Test]
        public async Task TestBatch_ProcessMessagesSpan_FailedScope()
        {
            ExpectedRemainingMessages = 2;
            using var listener = new ClientDiagnosticListener(DiagnosticProperty.DiagnosticNamespace);
            await TestMultiple<ServiceBusMultipleMessagesTestJob_BindToPocoArray_Throws>();
            var scope = listener.AssertAndRemoveScope(Constants.ProcessMessagesActivityName);
            var tags = scope.Activity.Tags.ToList();
            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.MessageBusDestination, FirstQueueScope.QueueName));
            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.PeerAddress, ServiceBusTestEnvironment.Instance.FullyQualifiedNamespace));
            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(MessagingClientDiagnostics.Component, DiagnosticProperty.ServiceBusServiceContext));
            Assert.AreEqual(2, scope.LinkedActivities.Count);
            Assert.IsTrue(scope.IsFailed);
        }

        [Test]
        public async Task TestSingle_JObject()
        {
            var host = BuildHost<ServiceBusMultipleMessagesTestJob_BindToJObject>();
            using (host)
            {
                await WriteQueueMessage(JsonConvert.SerializeObject(new {Date = DateTimeOffset.Now}));
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestBatch_NoMessages()
        {
            var host = BuildHost<ServiceBusMultipleMessagesTestJob_NoMessagesExpected>(b =>
            {
                b.ConfigureWebJobs(
                    c =>
                    {
                        // This test uses a TimerTrigger and StorageCoreServices are needed to get the AddTimers to work
                        c.AddAzureStorageCoreServices();
                        c.AddTimers();
                        // Use a large try timeout to validate that stopping the host finishes quickly
                        c.AddServiceBus(o => o.ClientRetryOptions.TryTimeout = TimeSpan.FromSeconds(60));
                    });
            });
            using (host)
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                var start = DateTimeOffset.Now;
                await host.StopAsync();
                var stop = DateTimeOffset.Now;

                Assert.IsTrue(stop.Subtract(start) < TimeSpan.FromSeconds(10));
            }
        }

        [Test]
        public async Task TestSingle_JObject_CustomSettings()
        {
            var host = BuildHost<ServiceBusMultipleMessagesTestJob_BindToJObject_RespectsCustomJsonSettings>(
                configurationDelegate: host =>
                    host.ConfigureWebJobs(b =>
                    {
                        b.AddServiceBus(options =>
                        {
                            options.JsonSerializerSettings = new JsonSerializerSettings
                            {
                                DateParseHandling = DateParseHandling.None
                            };
                        });
                    }));
            using (host)
            {
                await WriteQueueMessage(JsonConvert.SerializeObject(new {Date = DateTimeOffset.Now}));
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestSingle_OutputPoco()
        {
            var host = BuildHost<ServiceBusOutputPocoTest>();
            using (host)
            {
                var jobHost = host.GetJobHost();
                await jobHost.CallAsync(nameof(ServiceBusOutputPocoTest.OutputPoco));
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestSingle_OutputBinaryData()
        {
            var host = BuildHost<ServiceBusOutputBinaryDataTest>();
            using (host)
            {
                var jobHost = host.GetJobHost();
                await jobHost.CallAsync(nameof(ServiceBusOutputBinaryDataTest.OutputBinaryData));
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestSingle_OutputBinaryData_Batch()
        {
            var host = BuildHost<ServiceBusOutputBinaryDataBatchTest>();
            using (host)
            {
                var jobHost = host.GetJobHost();
                await jobHost.CallAsync(nameof(ServiceBusOutputBinaryDataBatchTest.OutputBinaryData));
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        [Test]
        public async Task TestBatch_DataContractPoco()
        {
            await TestMultiple<ServiceBusMultipleMessagesTestJob_BindToPocoArray>(true);
        }

        [Test]
        public async Task BindToPoco()
        {
            var host = BuildHost<ServiceBusArgumentBindingJob>();
            var provider = host.Services.GetService<MessagingProvider>();

            using (host)
            {
                await WriteQueueMessage("{ Name: 'foo', Value: 'bar' }");

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);

                var logs = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.FormattedMessage).ToList();
                Assert.Contains("PocoValues(foo,bar)", logs);
                await host.StopAsync();
            }
            Assert.AreEqual(0, provider.ClientCache.Count);
            Assert.AreEqual(0, provider.MessageReceiverCache.Count);
            Assert.AreEqual(0, provider.MessageSenderCache.Count);
            Assert.AreEqual(0, provider.ActionsCache.Count);
        }

        [Test]
        public async Task BindToString()
        {
            var host = BuildHost<ServiceBusArgumentBindingJob>();
            using (host)
            {
                var method = typeof(ServiceBusArgumentBindingJob).GetMethod(nameof(ServiceBusArgumentBindingJob.BindToString), BindingFlags.Static | BindingFlags.Public);
                var jobHost = host.GetJobHost();
                await jobHost.CallAsync(method, new { input = "foobar" });

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);

                var logs = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.FormattedMessage).ToList();
                Assert.Contains("Input(foobar)", logs);
                await host.StopAsync();
            }
        }

        [Test]
        [Category("DynamicConcurrency")]
        public async Task DynamicConcurrencyTest()
        {
            DynamicConcurrencyTestJob.InvocationCount = 0;

            var host = BuildHost<DynamicConcurrencyTestJob>(b =>
            {
                b.ConfigureWebJobs(b =>
                 {
                     b.Services.AddOptions<ConcurrencyOptions>().Configure(options =>
                     {
                         options.DynamicConcurrencyEnabled = true;

                         // ensure on each test run we work up from 1
                         options.SnapshotPersistenceEnabled = false;
                     });
                 }).ConfigureLogging((context, b) =>
                 {
                     // ensure we get all concurrency logs
                     b.SetMinimumLevel(LogLevel.Debug);
                 });
            }, startHost: false);

            using (host)
            {
                // ensure initial concurrency is 1
                MethodInfo methodInfo = typeof(DynamicConcurrencyTestJob).GetMethod("ProcessMessage", BindingFlags.Public | BindingFlags.Static);
                string functionId = $"{methodInfo.DeclaringType.FullName}.{methodInfo.Name}";
                var concurrencyManager = host.Services.GetServices<ConcurrencyManager>().SingleOrDefault();
                var concurrencyStatus = concurrencyManager.GetStatus(functionId);
                Assert.AreEqual(1, concurrencyStatus.CurrentConcurrency);

                // write a bunch of messages in batch
                int numMessages = 500;
                string[] messages = new string[numMessages];
                for (int i = 0; i < numMessages; i++)
                {
                    messages[i] = Guid.NewGuid().ToString();
                }
                await WriteQueueMessages(messages);

                // start the host and wait for all messages to be processed
                await host.StartAsync();
                await TestHelpers.Await(
                    () => DynamicConcurrencyTestJob.InvocationCount >= numMessages,
                    timeout: 100 * 1000);

                // ensure we've dynamically increased concurrency
                concurrencyStatus = concurrencyManager.GetStatus(functionId);
                Assert.GreaterOrEqual(concurrencyStatus.CurrentConcurrency, 10);

                // check a few of the concurrency logs
                var concurrencyLogs = host.GetTestLoggerProvider().GetAllLogMessages().Where(p => p.Category == LogCategories.Concurrency).Select(p => p.FormattedMessage).ToList();
                int concurrencyIncreaseLogCount = concurrencyLogs.Count(p => p.Contains("ProcessMessage Increasing concurrency"));
                Assert.GreaterOrEqual(concurrencyIncreaseLogCount, 3);

                await host.StopAsync();
            }
        }

        [Test]
        public async Task BindToAmqpValue()
        {
            var host = BuildHost<ServiceBusAmqpValueBinding>();
            using (host)
            {
                var message = new ServiceBusMessage();
                message.GetRawAmqpMessage().Body = AmqpMessageBody.FromValue("foobar");
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
        }

        [Test]
        public async Task BindToAmqpValueAsString()
        {
            var host = BuildHost<ServiceBusAmqpValueBindingAsString>();
            using (host)
            {
                var message = new ServiceBusMessage();
                message.GetRawAmqpMessage().Body = AmqpMessageBody.FromValue("foobar");
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
        }

        [Test]
        public async Task BindToAmqpValueAsPoco()
        {
            var host = BuildHost<ServiceBusAmqpValueBindingAsPoco>();
            using (host)
            {
                var message = new ServiceBusMessage();
                message.GetRawAmqpMessage().Body = AmqpMessageBody.FromValue(new BinaryData(new TestPoco() { Name = "Key", Value = "Value" }).ToString());
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
        }

        [Test]
        public async Task MessageDrainingQueue()
        {
            await TestSingleDrainMode<DrainModeTestJobQueue>(true);
        }

        [Test]
        public async Task MessageDrainingTopic()
        {
            await TestSingleDrainMode<DrainModeTestJobTopic>(false);
        }

        [Test]
        public async Task MessageDrainingQueueBatch()
        {
            await TestMultipleDrainMode<DrainModeTestJobQueueBatch>(true);
        }

        [Test]
        public async Task MessageDrainingTopicBatch()
        {
            await TestMultipleDrainMode<DrainModeTestJobTopicBatch>(false);
        }

        [Test]
        public async Task MultipleFunctionsBindingToSameEntity()
        {
            await TestMultiple<ServiceBusSingleMessageTestJob_BindMultipleFunctionsToSameEntity>();
        }

        /*
         * Helper functions
         */

        private async Task TestSingleDrainMode<T>(bool sendToQueue)
        {
            var host = BuildHost<T>(BuildDrainHost<T>());

            using (host)
            {
                if (sendToQueue)
                {
                    await WriteQueueMessage(DrainingQueueMessageBody);
                }
                else
                {
                    await WriteTopicMessage(DrainingTopicMessageBody);
                }

                // Wait to ensure function invocation has started before draining messages
                Assert.True(_drainValidationPreDelay.WaitOne(SBTimeoutMills));

                // Start draining in-flight messages
                var drainModeManager = host.Services.GetService<IDrainModeManager>();
                await drainModeManager.EnableDrainModeAsync(CancellationToken.None);

                // Validate that function execution was allowed to complete
                Assert.True(_drainValidationPostDelay.WaitOne(DrainWaitTimeoutMills + SBTimeoutMills));
                await host.StopAsync();
            }
        }

        private static int MinBatchSize = 5;
        private static int MaxBatchSize = 10;

        private static Action<IHostBuilder> SetUpMinimumBatchSize =>
            builder =>
                builder.ConfigureWebJobs(b =>
                    b.AddServiceBus(sbOptions =>
                    {
                        sbOptions.MinMessageBatchSize = MinBatchSize;
                        sbOptions.MaxMessageBatchSize = MaxBatchSize;
                        sbOptions.MaxBatchWaitTime = TimeSpan.FromSeconds(5);
                    }));

        private static Action<IHostBuilder> DisableAutoComplete =>
            builder =>
                builder.ConfigureWebJobs(b =>
                    b.AddServiceBus(sbOptions =>
                    {
                        sbOptions.AutoCompleteMessages = false;
                    }));

        private static Action<IHostBuilder> SetInfiniteLockRenewal =>
            builder =>
                builder.ConfigureAppConfiguration(b =>
                    b.AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "AzureWebJobs:Extensions:ServiceBus:MaxAutoLockRenewalDuration", "-00:00:00.0010000" },
                    }));

        private static Action<IHostBuilder> BuildDrainHost<T>()
        {
            return builder =>
                builder.ConfigureWebJobs(b =>
                    b.AddServiceBus(sbOptions =>
                    {
                        // We want to ensure messages can be completed in the function code before signaling success to the test
                        sbOptions.AutoCompleteMessages = false;
                        sbOptions.MaxAutoLockRenewalDuration = TimeSpan.FromMinutes(MaxAutoRenewDurationMin);
                        sbOptions.MaxConcurrentCalls = 1;
                    }));
        }

        private async Task TestMultiple<T>(bool isXml = false, Action<IHostBuilder> configurationDelegate = default)
        {
            // pre-populate queue before starting listener to allow batch receive to get multiple messages
            if (isXml)
            {
                await WriteQueueMessage(new TestPoco() { Name = "Test1", Value = "Value" });
                await WriteQueueMessage(new TestPoco() { Name = "Test2", Value = "Value" });
            }
            else
            {
                await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
                await WriteQueueMessage("{'Name': 'Test2', 'Value': 'Value'}");
            }

            var host = BuildHost<T>(configurationDelegate);
            using (host)
            {
                bool result = _topicSubscriptionCalled1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        private async Task TestMultiple_MinBatch<T>(Action<IHostBuilder> configurationDelegate = default)
        {
            // pre-populate queue before starting listener to allow batch receive to get multiple messages
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            await WriteQueueMessage("{'Name': 'Test2', 'Value': 'Value'}");
            await WriteQueueMessage("{'Name': 'Test3', 'Value': 'Value'}");
            await WriteQueueMessage("{'Name': 'Test4', 'Value': 'Value'}");
            await WriteQueueMessage("{'Name': 'Test5', 'Value': 'Value'}");

            var host = BuildHost<T>(configurationDelegate);
            using (host)
            {
                bool result = _topicSubscriptionCalled1.WaitOne(SBTimeoutMills);
                Assert.True(result);
                await host.StopAsync();
            }
        }

        private async Task TestMultiple_MinBatch_PartialBatch<T>(Action<IHostBuilder> configurationDelegate = default)
        {
            // pre-populate queue before starting listener to allow batch receive to get multiple messages
            await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}");
            await WriteQueueMessage("{'Name': 'Test2', 'Value': 'Value'}");
            await WriteQueueMessage("{'Name': 'Test3', 'Value': 'Value'}");

            var host = BuildHost<T>(configurationDelegate);
            using (host)
            {
                bool result = _topicSubscriptionCalled1.WaitOne(SBTimeoutMills);
                Assert.True(result);

                await host.StopAsync();
            }
        }

        private async Task TestMultipleDrainMode<T>(bool sendToQueue)
        {
            var host = BuildHost<T>(BuildDrainHost<T>());
            using (host)
            {
                if (sendToQueue)
                {
                    await WriteQueueMessage(DrainingQueueMessageBody);
                }
                else
                {
                    await WriteTopicMessage(DrainingTopicMessageBody);
                }

                // Wait to ensure function invocation has started before draining messages
                Assert.True(_drainValidationPreDelay.WaitOne(SBTimeoutMills));

                // Start draining in-flight messages
                var drainModeManager = host.Services.GetService<IDrainModeManager>();
                await drainModeManager.EnableDrainModeAsync(CancellationToken.None);

                // Validate that function execution was allowed to complete
                Assert.True(_drainValidationPostDelay.WaitOne(DrainWaitTimeoutMills + SBTimeoutMills));
                await host.StopAsync();
            }
        }

        private async Task ServiceBusEndToEndInternal<T>(IHost host)
        {
            var jobContainerType = typeof(T);

            await WriteQueueMessage("E2E");

            await host.StartAsync();

            _topicSubscriptionCalled1.WaitOne(SBTimeoutMills);
            _topicSubscriptionCalled2.WaitOne(SBTimeoutMills);

            // ensure all logs have had a chance to flush
            await Task.Delay(4000);

            // Wait for the host to terminate
            await host.StopAsync();

            Assert.AreEqual("E2E-SBQueue2SBQueue-SBQueue2SBTopic-topic-1", _resultMessage1);
            Assert.AreEqual("E2E-SBQueue2SBQueue-SBQueue2SBTopic-topic-2", _resultMessage2);

            IEnumerable<LogMessage> logMessages = host.GetTestLoggerProvider().GetAllLogMessages();

            // Filter out Azure SDK, hosting lifetime, and custom processor logs for easier validation.
            logMessages = logMessages.Where(
                m => !m.Category.StartsWith("Azure.", StringComparison.InvariantCulture) &&
                     !m.Category.StartsWith("Microsoft.Hosting.Lifetime") &&
                     m.Category != CustomMessagingProvider.CustomMessagingCategory);

            string[] consoleOutputLines = logMessages
                .Where(p => p.FormattedMessage != null)
                .SelectMany(p => p.FormattedMessage.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                .OrderBy(p => p)
                .ToArray();

            string[] expectedOutputLines = new string[]
            {
                "Found the following functions:",
                $"{jobContainerType.FullName}.SBQueue2SBQueue",
                $"{jobContainerType.FullName}.MultipleAccounts",
                $"{jobContainerType.FullName}.SBQueue2SBTopic",
                $"{jobContainerType.FullName}.SBTopicListener1",
                $"{jobContainerType.FullName}.SBTopicListener2",
                "Job host started",
                $"Executing '{jobContainerType.Name}.SBQueue2SBQueue'",
                $"Executed '{jobContainerType.Name}.SBQueue2SBQueue' (Succeeded, Id=",
                $"Trigger Details:",
                $"Executing '{jobContainerType.Name}.SBQueue2SBTopic'",
                $"Executed '{jobContainerType.Name}.SBQueue2SBTopic' (Succeeded, Id=",
                $"Trigger Details:",
                $"Executing '{jobContainerType.Name}.SBTopicListener1'",
                $"Executed '{jobContainerType.Name}.SBTopicListener1' (Succeeded, Id=",
                $"Trigger Details:",
                $"Executing '{jobContainerType.Name}.SBTopicListener2'",
                $"Executed '{jobContainerType.Name}.SBTopicListener2' (Succeeded, Id=",
                $"Trigger Details:",
                "Job host stopped",
                "Starting JobHost",
                "Stopping JobHost",
                "Stoppingthelistener'Microsoft.Azure.WebJobs.ServiceBus.Listeners.ServiceBusListener'forfunction'MultipleAccounts'",
                "Stoppedthelistener'Microsoft.Azure.WebJobs.ServiceBus.Listeners.ServiceBusListener'forfunction'MultipleAccounts'",
                "Stoppingthelistener'Microsoft.Azure.WebJobs.ServiceBus.Listeners.ServiceBusListener'forfunction'SBQueue2SBQueue'",
                "Stoppedthelistener'Microsoft.Azure.WebJobs.ServiceBus.Listeners.ServiceBusListener'forfunction'SBQueue2SBQueue'",
                "Stoppingthelistener'Microsoft.Azure.WebJobs.ServiceBus.Listeners.ServiceBusListener'forfunction'SBQueue2SBTopic'",
                "Stoppedthelistener'Microsoft.Azure.WebJobs.ServiceBus.Listeners.ServiceBusListener'forfunction'SBQueue2SBTopic'",
                "Stoppingthelistener'Microsoft.Azure.WebJobs.ServiceBus.Listeners.ServiceBusListener'forfunction'SBTopicListener1'",
                "Stoppedthelistener'Microsoft.Azure.WebJobs.ServiceBus.Listeners.ServiceBusListener'forfunction'SBTopicListener1'",
                "Stoppingthelistener'Microsoft.Azure.WebJobs.ServiceBus.Listeners.ServiceBusListener'forfunction'SBTopicListener2'",
                "Stoppedthelistener'Microsoft.Azure.WebJobs.ServiceBus.Listeners.ServiceBusListener'forfunction'SBTopicListener2'",
                "FunctionResultAggregatorOptions",
                "{",
                "  \"BatchSize\": 1000,",
                "  \"FlushTimeout\": \"00:00:30\",",
                "  \"IsEnabled\": true",
                "}",
                "LoggerFilterOptions",
                "{",
                "  \"MinLevel\": \"Information\"",
                "  \"Rules\": []",
                "}",
                "ServiceBusOptions",
                "{",
                "  \"PrefetchCount\": 0,",
                "  \"AutoCompleteMessages\": true,",
                "  \"MaxAutoLockRenewalDuration\": \"00:05:00\",",
                "  \"MaxBatchWaitTime\":\"00:00:30\",",
               $"  \"MaxConcurrentCalls\": {16 * Utility.GetProcessorCount()},",
                "  \"MaxConcurrentSessions\": 8,",
                "  \"MaxConcurrentCallsPerSession\": 1,",
                "  \"MaxMessageBatchSize\": 1000,",
                "  \"MinMessageBatchSize\":1,",
                "  \"SessionIdleTimeout\": \"\"",
                "  \"ClientRetryOptions\": {",
                "       \"Mode\": \"Exponential\",",
                "       \"TryTimeout\": \"00:00:10\",",
                "       \"Delay\": \"00:00:00.8000000\",",
                "       \"MaxDelay\": \"00:01:00\",",
                "       \"MaxRetries\": 3",
                "  }",
                "  \"TransportType\": \"AmqpTcp\",",
                "  \"EnableCrossEntityTransactions\": false",
                "  \"WebProxy\": \"\",",
                "}",
                "SingletonOptions",
                "{",
                "  \"ListenerLockPeriod\": \"00:01:00\",",
                "  \"LockAcquisitionPollingInterval\": \"00:00:05\",",
                "  \"LockAcquisitionTimeout\": \"",
                "  \"LockPeriod\": \"00:00:15\",",
                "  \"ListenerLockRecoveryPollingInterval\": \"00:01:00\"",
                "}",
                "ConcurrencyOptions",
                "{",
                "  \"DynamicConcurrencyEnabled\": false,",
                "  \"CPUThreshold\": 0.8,",
                "  \"MaximumFunctionConcurrency\": 500,",
                "  \"SnapshotPersistenceEnabled\": true",
                "}",
            }.OrderBy(p => p).ToArray();

            expectedOutputLines = expectedOutputLines.Select(x => x.Replace(" ", string.Empty)).ToArray();
            consoleOutputLines = consoleOutputLines.Select(x => x.Replace(" ", string.Empty)).ToArray();
            Assert.AreEqual(expectedOutputLines.Length, consoleOutputLines.Length);
            for (int i = 0; i < expectedOutputLines.Length; i++)
            {
                StringAssert.StartsWith(expectedOutputLines[i], consoleOutputLines[i]);
            }

            // Verify that trigger details are properly formatted
            string[] triggerDetailsConsoleOutput = consoleOutputLines
                .Where(m => m.StartsWith(TriggerDetailsMessageStart)).ToArray();

            string expectedPattern = "Trigger Details: MessageId: (.*), DeliveryCount: [0-9]+, EnqueuedTime: (.*), LockedUntil: (.*)";

            foreach (string msg in triggerDetailsConsoleOutput)
            {
                Assert.True(Regex.IsMatch(msg, expectedPattern), $"Expected trace event {expectedPattern} not found.");
            }
        }

        public abstract class ServiceBusTestJobsBase
        {
            protected static ServiceBusMessage SBQueue2SBQueue_GetOutputMessage(string input)
            {
                input = input + "-SBQueue2SBQueue";
                return new ServiceBusMessage
                {
                    ContentType = "text/plain",
                    Body = new BinaryData(input)
                };
            }

            protected static ServiceBusMessage SBQueue2SBTopic_GetOutputMessage(string input)
            {
                input = input + "-SBQueue2SBTopic";

                return new ServiceBusMessage(Encoding.UTF8.GetBytes(input))
                {
                    ContentType = "text/plain"
                };
            }

            protected static void SBTopicListener1Impl(string input)
            {
                _resultMessage1 = input + "-topic-1";
                _topicSubscriptionCalled1.Set();
            }

            protected static void SBTopicListener2Impl(ServiceBusReceivedMessage message)
            {
                _resultMessage2 = message.Body.ToString() + "-topic-2";
                _topicSubscriptionCalled2.Set();
            }
        }

        public class ServiceBusTestJobs : ServiceBusTestJobsBase
        {
            // Passes service bus message from a queue to another queue
            public async Task SBQueue2SBQueue(
                [ServiceBusTrigger(FirstQueueNameKey)]
                string body,
                int deliveryCount,
                string lockToken,
                string deadLetterSource,
                DateTime expiresAtUtc,
                DateTimeOffset expiresAt,
                DateTime enqueuedTimeUtc,
                DateTimeOffset enqueuedTime,
                string contentType,
                string replyTo,
                string to,
                string subject,
                string label,
                string correlationId,
                string sessionId,
                string replyToSessionId,
                IDictionary<string, object> applicationProperties,
                IDictionary<string, object> userProperties,
                ServiceBusMessageActions messageActions,
                [ServiceBus(SecondQueueNameKey)] ServiceBusSender messageSender)
            {
                Assert.AreEqual("E2E", body);
                Assert.AreEqual(1, deliveryCount);
                Assert.IsNotNull(lockToken);
                Assert.IsNull(deadLetterSource);
                Assert.AreEqual("replyTo", replyTo);
                Assert.AreEqual("to", to);
                Assert.AreEqual("subject", subject);
                Assert.AreEqual("subject", label);
                Assert.AreEqual("correlationId", correlationId);
                Assert.AreEqual("application/json", contentType);
                Assert.AreEqual("value", applicationProperties["key"]);
                Assert.AreEqual("value", userProperties["key"]);
                Assert.Greater(expiresAtUtc, DateTime.UtcNow);
                Assert.AreEqual(expiresAt.DateTime, expiresAtUtc);
                // account for clock skew
                Assert.Less(enqueuedTimeUtc, DateTime.UtcNow.AddMinutes(5));
                Assert.AreEqual(enqueuedTime.DateTime, enqueuedTimeUtc);
                Assert.IsNull(sessionId);
                Assert.IsNull(replyToSessionId);

                var message = SBQueue2SBQueue_GetOutputMessage(body);
                await messageSender.SendMessageAsync(message);
            }

            // Passes a service bus message from a queue to topic using a brokered message
            public static void SBQueue2SBTopic(
                [ServiceBusTrigger(SecondQueueNameKey)] string message,
                [ServiceBus(TopicNameKey)] out ServiceBusMessage output)
            {
                output = SBQueue2SBTopic_GetOutputMessage(message);
            }

            // First listener for the topic
            public static void SBTopicListener1(
                [ServiceBusTrigger(TopicNameKey, FirstSubscriptionNameKey)] string message,
                ServiceBusMessageActions messageActions,
                string lockToken)
            {
                SBTopicListener1Impl(message);
            }

            // Second listener for the topic
            // Just sprinkling Singleton here because previously we had a bug where this didn't work
            // for ServiceBus.
            [Singleton]
            public static void SBTopicListener2(
                [ServiceBusTrigger(TopicNameKey, SecondSubscriptionNameKey)] ServiceBusReceivedMessage message)
            {
                SBTopicListener2Impl(message);
            }

            // Demonstrate triggering on a queue in one account, and writing to a topic
            // in the primary subscription
            public static void MultipleAccounts(
                [ServiceBusTrigger(SecondaryNamespaceQueueNameKey, Connection = SecondaryConnectionStringKey)] string input,
                [ServiceBus(TopicNameKey)] out string output)
            {
                output = input;
            }
        }

        public class ServiceBusOutputPocoTest
        {
            public static void OutputPoco(
                [ServiceBus(FirstQueueNameKey)] out TestPoco output)
            {
                output = new TestPoco() {Value = "value", Name = "name"};
            }

            public static void TriggerPoco(
                [ServiceBusTrigger(FirstQueueNameKey)] TestPoco received)
            {
                Assert.AreEqual("value", received.Value);
                Assert.AreEqual("name", received.Name);
                _waitHandle1.Set();
            }
        }

        public class ServiceBusOutputBinaryDataTest
        {
            public static void OutputBinaryData(
                [ServiceBus(FirstQueueNameKey)] out BinaryData output)
            {
                output = new BinaryData("message");
            }

            public static void TriggerBinaryData(
                [ServiceBusTrigger(FirstQueueNameKey)] BinaryData received)
            {
                Assert.AreEqual("message", received.ToString());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusOutputBinaryDataBatchTest
        {
            private static volatile bool firstReceived = false;
            private static volatile bool secondReceived = false;
            public static void OutputBinaryData(
                [ServiceBus(FirstQueueNameKey)] ICollector<BinaryData> output)
            {
                output.Add(new BinaryData("message1"));
                output.Add(new BinaryData("message2"));
            }

            public static void TriggerBinaryData(
                [ServiceBusTrigger(FirstQueueNameKey)] BinaryData[] received)
            {
                foreach (BinaryData binaryData in received)
                {
                    switch (binaryData.ToString())
                    {
                        case "message1":
                            firstReceived = true;
                            break;
                        case "message2":
                            secondReceived = true;
                            break;
                    }
                }
                if (firstReceived && secondReceived)
                {
                    // reset for the next test
                    firstReceived = false;
                    secondReceived = false;
                    _waitHandle1.Set();
                }
            }
        }

        public class BinderTestJobsAsyncCollector
        {
            [NoAutomaticTrigger]
            public static async Task ServiceBusBinderTest(
                string message,
                int numMessages,
                Binder binder)
            {
                var attribute = new ServiceBusAttribute(FirstQueueScope.QueueName)
                {
                    EntityType = ServiceBusEntityType.Queue
                };

                var collector = await binder.BindAsync<IAsyncCollector<string>>(attribute);

                for (int i = 0; i < numMessages; i++)
                {
                    await collector.AddAsync(message + i);
                }

                await collector.FlushAsync();
            }
        }

        public class BinderTestJobsSyncCollector
        {
            [NoAutomaticTrigger]
            public static void ServiceBusBinderTest(
                string message,
                int numMessages,
                Binder binder)
            {
                var attribute = new ServiceBusAttribute(FirstQueueScope.QueueName)
                {
                    EntityType = ServiceBusEntityType.Queue
                };

                var collector = binder.Bind<ICollector<string>>(attribute);

                for (int i = 0; i < numMessages; i++)
                {
                    collector.Add(message + i);
                }
            }
        }

        public class ServiceBusMultipleTestJobsBase
        {
            protected static volatile bool firstReceived = false;
            protected static volatile bool secondReceived = false;

            public static void ProcessMessages(string[] messages)
            {
                if (messages.Contains("{'Name': 'Test1', 'Value': 'Value'}"))
                {
                    firstReceived = true;
                }
                if (messages.Contains("{'Name': 'Test2', 'Value': 'Value'}"))
                {
                    secondReceived = true;
                }

                if (firstReceived && secondReceived)
                {
                    // reset for the next test
                    firstReceived = false;
                    secondReceived = false;
                    _topicSubscriptionCalled1.Set();
                }
            }
        }

        public class ServiceBusMultipleMessagesTestJob_BindToStringArray
        {
            public static async Task SBQueue2SBQueue(
                [ServiceBusTrigger(FirstQueueNameKey)] string[] messages,
                ServiceBusMessageActions messageActions, CancellationToken cancellationToken)
            {
                try
                {
                    ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
                    await Task.Delay(0, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                }
            }
        }

        public class ServiceBusMultipleMessagesTestJob_BindToMessageArray
        {
            public static void Run(
                [ServiceBusTrigger(FirstQueueNameKey)]
                ServiceBusReceivedMessage[] array,
                int[] deliveryCountArray,
                string[] lockTokenArray,
                string[] deadLetterSourceArray,
                DateTime[] expiresAtUtcArray,
                DateTimeOffset[] expiresAtArray,
                DateTime[] enqueuedTimeUtcArray,
                DateTimeOffset[] enqueuedTimeArray,
                string[] contentTypeArray,
                string[] replyToArray,
                string[] toArray,
                string[] subjectArray,
                string[] labelArray,
                string[] correlationIdArray,
                string[] sessionIdArray,
                string[] replyToSessionIdArray,
                string[] partitionKeyArray,
                string[] transactionPartitionKeyArray,
                IDictionary<string, object>[] applicationPropertiesArray,
                IDictionary<string, object>[] userPropertiesArray,
                ServiceBusMessageActions messageActions)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Assert.AreEqual(1, deliveryCountArray[i]);
                    Assert.IsNotNull(lockTokenArray[i]);
                    Assert.IsNull(deadLetterSourceArray[i]);
                    Assert.AreEqual("replyTo", replyToArray[i]);
                    Assert.AreEqual("to", toArray[i]);
                    Assert.AreEqual("subject", subjectArray[i]);
                    Assert.AreEqual("subject", labelArray[i]);
                    Assert.AreEqual("correlationId", correlationIdArray[i]);
                    Assert.AreEqual("application/json", contentTypeArray[i]);
                    Assert.AreEqual("partitionKey", partitionKeyArray[i]);
                    Assert.AreEqual("partitionKey", transactionPartitionKeyArray[i]);
                    Assert.AreEqual("value", applicationPropertiesArray[i]["key"]);
                    Assert.AreEqual("value", userPropertiesArray[i]["key"]);
                    Assert.Greater(expiresAtUtcArray[i], DateTime.UtcNow);
                    Assert.AreEqual(expiresAtArray[i].DateTime, expiresAtUtcArray[i]);
                    // account for clock skew
                    Assert.Less(enqueuedTimeUtcArray[i], DateTime.UtcNow.AddMinutes(5));
                    Assert.AreEqual(enqueuedTimeArray[i].DateTime, enqueuedTimeUtcArray[i]);
                    Assert.IsNull(sessionIdArray[i]);
                    Assert.IsNull(replyToSessionIdArray[i]);
                }
                string[] messages = array.Select(x => x.Body.ToString()).ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class ServiceBusMultipleMessagesTestJob_BindToPocoArray
        {
            public static void Run(
                [ServiceBusTrigger(FirstQueueNameKey)] TestPoco[] array,
                ServiceBusMessageActions messageActions)
            {
                string[] messages = array.Select(x => "{'Name': '" + x.Name + "', 'Value': 'Value'}").ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class ServiceBusMultipleMessagesTestJob_BindToPocoArray_Throws
        {
            public static void Run(
                [ServiceBusTrigger(FirstQueueNameKey)] TestPoco[] array,
                ServiceBusMessageActions messageActions)
            {
                string[] messages = array.Select(x => "{'Name': '" + x.Name + "', 'Value': 'Value'}").ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
                throw new Exception("Test exception");
            }
        }

        public class ServiceBusMultipleMessagesTestJob_BindToJObject
        {
            public static void Run([ServiceBusTrigger(FirstQueueNameKey)] JObject input)
            {
                Assert.AreEqual(JTokenType.Date, input["Date"].Type);
                _waitHandle1.Set();
            }
        }

        public class ServiceBusMultipleMessagesTestJob_BindToJObject_RespectsCustomJsonSettings
        {
            public static void BindToJObject([ServiceBusTrigger(FirstQueueNameKey)] JObject input)
            {
                Assert.AreEqual(JTokenType.String, input["Date"].Type);
                _waitHandle1.Set();
            }
        }

        public class ServiceBusMultipleMessagesTestJob_NoMessagesExpected
        {
            public static void ShouldNotRun([ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage[] messages)
            {
                Assert.Fail("Should not be executed!");
            }

            // use a timer trigger that will be invoked every 20 seconds to signal the end of the test
            // 20 seconds should give enough time for the receive call to complete as the TryTimeout being used is 10 seconds.
            public static void Run([TimerTrigger("*/20 * * * * *")] TimerInfo timer)
            {
                _waitHandle1.Set();
            }
        }

        public class ServiceBusArgumentBindingJob
        {
            public static void BindToPoco(
                [ServiceBusTrigger(FirstQueueNameKey)] TestPoco input,
                string name, string value, string messageId,
                ILogger logger)
            {
                Assert.AreEqual(input.Name, name);
                Assert.AreEqual(input.Value, value);
                logger.LogInformation($"PocoValues({name},{value})");
                _waitHandle1.Set();
            }

            [NoAutomaticTrigger]
            public static void BindToString(
                [ServiceBusTrigger(FirstQueueNameKey)]
                string input,
                string messageId,
                ILogger logger)
            {
                logger.LogInformation($"Input({input})");
                _waitHandle1.Set();
            }
        }

        public class ServiceBusAmqpValueBinding
        {
            public static void BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage input)
            {
                input.GetRawAmqpMessage().Body.TryGetValue(out object value);
                Assert.AreEqual("foobar", value);
                _waitHandle1.Set();
            }
        }

        public class ServiceBusAmqpValueBindingAsString
        {
            public static void BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] string input)
            {
                Assert.AreEqual("foobar", input);
                _waitHandle1.Set();
            }
        }

        public class ServiceBusAmqpValueBindingAsPoco
        {
            public static void BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] TestPoco poco)
            {
                Assert.AreEqual("Key", poco.Name);
                Assert.AreEqual("Value", poco.Value);
                _waitHandle1.Set();
            }
        }

        public class DynamicConcurrencyTestJob
        {
            public static int InvocationCount;

            public static async Task ProcessMessage([ServiceBusTrigger(FirstQueueNameKey)] string message, ILogger logger)
            {
                await Task.Delay(250);

                Interlocked.Increment(ref InvocationCount);
            }
        }

        public class TestBatchMinBatchSize
        {
            public static void Run(
               [ServiceBusTrigger(FirstQueueNameKey)]
               ServiceBusReceivedMessage[] array)
            {
                Assert.AreEqual(array.Length, MinBatchSize);
                string[] messages = array.Select(x => x.Body.ToString()).ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class TestBatchMinBatchSize_PartialBatch
        {
            public static void Run(
               [ServiceBusTrigger(FirstQueueNameKey)]
               ServiceBusReceivedMessage[] array)
            {
                Assert.AreEqual(array.Length, 3);
                string[] messages = array.Select(x => x.Body.ToString()).ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class TestBatchAutoCompleteMessagesDisabledOnTrigger
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey, AutoCompleteMessages = false)]
                ServiceBusReceivedMessage[] array,
                ServiceBusMessageActions messageActions)
            {
                string[] messages = array.Select(x => x.Body.ToString()).ToArray();
                foreach (var msg in array)
                {
                    await messageActions.CompleteMessageAsync(msg);
                }
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class TestBatchAutoCompleteMessagesEnabledOnTrigger_CompleteInFunction
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey, AutoCompleteMessages = true)]
                ServiceBusReceivedMessage[] array,
                ServiceBusMessageActions messageActions)
            {
                string[] messages = array.Select(x => x.Body.ToString()).ToArray();
                foreach (var msg in array)
                {
                    await messageActions.CompleteMessageAsync(msg);
                }
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class TestBatchAutoCompleteMessagesEnabledOnTrigger
        {
            public static void Run(
               [ServiceBusTrigger(FirstQueueNameKey, AutoCompleteMessages = true)]
               ServiceBusReceivedMessage[] array)
            {
                Assert.True(array.Length > 0);
                string[] messages = array.Select(x => x.Body.ToString()).ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class TestSingleAutoCompleteMessagesEnabledOnTriggerException
        {
            public async Task Run(
                [ServiceBusTrigger(FirstQueueNameKey, AutoCompleteMessages = false)]
                ServiceBusReceivedMessage message,
                ServiceBusReceiveActions receiveActions)
            {
                // validate that additional messages received will get abandoned after the exception
                await receiveActions.ReceiveMessagesAsync(1);
                _waitHandle1.Set();
                throw new Exception("Exception from user function");
            }
        }

        public class TestBatchAutoCompleteMessagesEnabledOnTriggerException
        {
            public static async Task Run(
                [ServiceBusTrigger(FirstQueueNameKey, AutoCompleteMessages = false)]
                ServiceBusReceivedMessage[] messages,
                ServiceBusReceiveActions receiveActions)
            {
                // validate that additional messages received will get abandoned after the exception
                await receiveActions.ReceiveMessagesAsync(1);
                _waitHandle1.Set();
                throw new Exception("Exception from user function");
            }
        }

        public class TestSingleAutoCompleteMessagesEnabledOnTrigger_CompleteInFunction
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey, AutoCompleteMessages = true)]
                ServiceBusReceivedMessage message,
                ServiceBusMessageActions messageActions)
            {
                // we want to validate that this doesn't trigger an exception in the SDK since AutoComplete = true
                await messageActions.CompleteMessageAsync(message);
                _waitHandle1.Set();
            }
        }
        public class TestBatchMaxMessageBatchSizeOnTrigger
        {
            public static void Run(
               [ServiceBusTrigger(FirstQueueNameKey, MaxMessageBatchSize = 2)]
               ServiceBusReceivedMessage[] array)
            {
                Assert.AreEqual(array.Length, 2);
                string[] messages = array.Select(x => x.Body.ToString()).ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class TestSingleInfiniteLockRenewal
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey)]
                ServiceBusReceivedMessage message,
                ServiceBusMessageActions messageActions)
            {
                // wait long enough to trigger lock renewal
                await Task.Delay(TimeSpan.FromSeconds(20));
                _waitHandle1.Set();
            }
        }

        public class TestSingleDispose
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey)]
                ServiceBusReceivedMessage message,
                CancellationToken cancellationToken)
            {
                _waitHandle1.Set();
                // wait a small amount of time for the host to call dispose
                await Task.Delay(2000, CancellationToken.None);
                Assert.IsTrue(cancellationToken.IsCancellationRequested);
            }
        }

        public class TestBatchDispose
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey)]
                ServiceBusReceivedMessage[] message,
                CancellationToken cancellationToken)
            {
                _waitHandle1.Set();
                // wait a small amount of time for the host to call dispose
                await Task.Delay(2000, CancellationToken.None);
                Assert.IsTrue(cancellationToken.IsCancellationRequested);
            }
        }

        public class TestCrossEntityTransaction
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey)]
                ServiceBusReceivedMessage message,
                ServiceBusMessageActions messageActions,
                ServiceBusClient client)
            {
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await messageActions.CompleteMessageAsync(message);
                    var sender = client.CreateSender(SecondQueueScope.QueueName);
                    await sender.SendMessageAsync(new ServiceBusMessage());
                    ts.Complete();
                }
                // This can be uncommented once https://github.com/Azure/azure-sdk-for-net/issues/24989 is fixed
                // ServiceBusReceiver receiver1 = client.CreateReceiver(_firstQueueScope.QueueName);
                // var received = await receiver1.ReceiveMessageAsync();
                // Assert.IsNull(received);
                // need to use a separate client here to do the assertions
                var noTxClient = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                ServiceBusReceiver receiver2 = noTxClient.CreateReceiver(SecondQueueScope.QueueName);
                var received = await receiver2.ReceiveMessageAsync();
                Assert.IsNotNull(received);
                _waitHandle1.Set();
            }
        }

        public class TestCrossEntityTransactionBatch
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey)]
                ServiceBusReceivedMessage[] messages,
                ServiceBusMessageActions messageActions,
                ServiceBusClient client)
            {
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await messageActions.CompleteMessageAsync(messages.First());
                    var sender = client.CreateSender(SecondQueueScope.QueueName);
                    await sender.SendMessageAsync(new ServiceBusMessage());
                    ts.Complete();
                }
                // This can be uncommented once https://github.com/Azure/azure-sdk-for-net/issues/24989 is fixed
                // ServiceBusReceiver receiver1 = client.CreateReceiver(_firstQueueScope.QueueName);
                // var received = await receiver1.ReceiveMessageAsync();
                // Assert.IsNull(received);
                // need to use a separate client here to do the assertions
                var noTxClient = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                ServiceBusReceiver receiver2 = noTxClient.CreateReceiver(SecondQueueScope.QueueName);
                var received = await receiver2.ReceiveMessageAsync();
                Assert.IsNotNull(received);
                _waitHandle1.Set();
            }
        }

        public class TestReceiveFromFunction
        {
            public static ServiceBusReceiveActions ReceiveActions { get; private set; }

            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey)]
                ServiceBusReceivedMessage message,
                ServiceBusMessageActions messageActions,
                ServiceBusReceiveActions receiveActions)
            {
                ReceiveActions = receiveActions;
                await messageActions.DeferMessageAsync(message);

                var receiveDeferred = await receiveActions.ReceiveDeferredMessagesAsync(
                    new[] { message.SequenceNumber });

                var peeked = await receiveActions.PeekMessagesAsync(1, message.SequenceNumber);
                Assert.IsNotEmpty(peeked);
                Assert.AreEqual(message.SequenceNumber, peeked.Single().SequenceNumber);

                _waitHandle1.Set();
            }
        }

        public class TestReceiveFromDeadLetterQueue
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(TopicNameKey, FirstSubscriptionNameKey)]
                ServiceBusReceivedMessage message,
                ServiceBusMessageActions messageActions)
            {
                await messageActions.DeadLetterMessageAsync(message, "DLQ");
            }

            public static async Task ReceiveFromDeadLetterAsync(
                [ServiceBusTrigger(TopicNameKey,  FirstSubscriptionNameKey + "/$deadletterqueue")]
                ServiceBusReceivedMessage message,
                ServiceBusMessageActions messageActions)
            {
                Assert.AreEqual("DLQ", message.DeadLetterReason);
                await messageActions.CompleteMessageAsync(message);
                _waitHandle1.Set();
            }
        }

        public class TestReceiveFromFunction_Batch
        {
            public const int MessageCount = 3;
            public static ServiceBusReceiveActions ReceiveActions { get; private set; }

            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey)]
                ServiceBusReceivedMessage[] messages,
                ServiceBusMessageActions messageActions,
                ServiceBusReceiveActions receiveActions)
            {
                ReceiveActions = receiveActions;
                await messageActions.DeferMessageAsync(messages.First());

                var receiveDeferred = await receiveActions.ReceiveDeferredMessagesAsync(
                    new[] { messages.First().SequenceNumber });

                var remaining = MessageCount - messages.Length;
                Assert.GreaterOrEqual(remaining, 1);
                while (remaining > 0)
                {
                    var received = await receiveActions.ReceiveMessagesAsync(remaining);
                    remaining -= received.Count;
                }

                _waitHandle1.Set();
            }
        }

        public class TestCustomErrorHandler
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey)]
                ServiceBusReceivedMessage message,
                ServiceBusClient client)
            {
                // Dispose the client so that we will trigger an error in the processor.
                // We can't simply throw an exception here as it would be swallowed by TryExecuteAsync call in the listener.
                // This means that the exception handler will not be used for errors originating from the function. This is the same
                // behavior as in V4.
                await client.DisposeAsync();
            }

            public static Task ErrorHandler(ProcessErrorEventArgs e)
            {
                Assert.IsInstanceOf<ObjectDisposedException>(e.Exception);
                _waitHandle1.Set();
                return Task.CompletedTask;
            }
        }

        public class DrainModeTestJobQueue
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage msg,
                ServiceBusMessageActions messageActions,
                CancellationToken cancellationToken,
                ILogger logger)
            {
                logger.LogInformation($"DrainModeValidationFunctions.QueueNoSessions: message data {msg.Body}");
                _drainValidationPreDelay.Set();
                Assert.False(cancellationToken.IsCancellationRequested);
                await messageActions.CompleteMessageAsync(msg);
                _drainValidationPostDelay.Set();
            }
        }

        public class DrainModeTestJobTopic
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(TopicNameKey, FirstSubscriptionNameKey)]
                ServiceBusReceivedMessage msg,
                ServiceBusMessageActions messageActions,
                CancellationToken cancellationToken,
                ILogger logger)
            {
                logger.LogInformation($"DrainModeValidationFunctions.NoSessions: message data {msg.Body}");
                _drainValidationPreDelay.Set();
                Assert.False(cancellationToken.IsCancellationRequested);
                await messageActions.CompleteMessageAsync(msg);
                _drainValidationPostDelay.Set();
            }
        }

        public class DrainModeTestJobQueueBatch
        {
            public static async Task RunAsync(
               [ServiceBusTrigger(FirstQueueNameKey)]
               ServiceBusReceivedMessage[] array,
               ServiceBusMessageActions messageActions,
               CancellationToken cancellationToken,
               ILogger logger)
            {
                Assert.True(array.Length > 0);
                logger.LogInformation($"DrainModeTestJobBatch.QueueNoSessionsBatch: received {array.Length} messages");
                _drainValidationPreDelay.Set();
                Assert.False(cancellationToken.IsCancellationRequested);
                foreach (ServiceBusReceivedMessage msg in array)
                {
                    await messageActions.CompleteMessageAsync(msg);
                }
                _drainValidationPostDelay.Set();
            }
        }

        public class DrainModeTestJobTopicBatch
        {
            public static async Task RunAsync(
                [ServiceBusTrigger(TopicNameKey, FirstSubscriptionNameKey)] ServiceBusReceivedMessage[] array,
                ServiceBusMessageActions messageActions,
                CancellationToken cancellationToken,
                ILogger logger)
            {
                Assert.True(array.Length > 0);
                logger.LogInformation($"DrainModeTestJobBatch.TopicNoSessionsBatch: received {array.Length} messages");
                _drainValidationPreDelay.Set();
                Assert.False(cancellationToken.IsCancellationRequested);
                foreach (ServiceBusReceivedMessage msg in array)
                {
                    // validate that manual lock renewal works
                    var initialLockedUntil = msg.LockedUntil;
                    await messageActions.RenewMessageLockAsync(msg);
                    Assert.Greater(msg.LockedUntil, initialLockedUntil);

                    await messageActions.CompleteMessageAsync(msg);
                }
                _drainValidationPostDelay.Set();
            }
        }

        public class ServiceBusSingleMessageTestJob_BindMultipleFunctionsToSameEntity
        {
            public static void SBQueueFunction(
                [ServiceBusTrigger(FirstQueueNameKey)] string message)
            {
                ServiceBusMultipleTestJobsBase.ProcessMessages(new string[] { message });
            }

            public static void SBQueueFunction2(
                [ServiceBusTrigger(FirstQueueNameKey)] string message)
            {
                ServiceBusMultipleTestJobsBase.ProcessMessages(new string[] { message });
            }
        }

        private class CustomMessagingProvider : MessagingProvider
        {
            public const string CustomMessagingCategory = "CustomMessagingProvider";
            private readonly ILogger _logger;

            public CustomMessagingProvider(
                IOptions<ServiceBusOptions> serviceBusOptions,
                ILoggerFactory loggerFactory)
                : base(serviceBusOptions)
            {
                _logger = loggerFactory?.CreateLogger(CustomMessagingCategory);
            }

            protected internal override MessageProcessor CreateMessageProcessor(ServiceBusClient client, string entityPath, ServiceBusProcessorOptions options)
            {
                // override the options computed from ServiceBusOptions
                options.MaxConcurrentCalls = 3;
                options.MaxAutoLockRenewalDuration = TimeSpan.FromMinutes(MaxAutoRenewDurationMin);

                var processor = client.CreateProcessor(entityPath, options);
                var receiver = client.CreateReceiver(entityPath);
                // TODO decide whether it makes sense to still default error handler when there is a custom provider
                // currently user needs to set it.
                processor.ProcessErrorAsync += args => Task.CompletedTask;
                return new CustomMessageProcessor(processor, _logger);
            }

            private class CustomMessageProcessor : MessageProcessor
            {
                private readonly ILogger _logger;

                public CustomMessageProcessor(ServiceBusProcessor processor, ILogger logger)
                    : base(processor)
                {
                    _logger = logger;
                }

                protected internal override async Task<bool> BeginProcessingMessageAsync(ServiceBusMessageActions actions, ServiceBusReceivedMessage message, CancellationToken cancellationToken)
                {
                    _logger?.LogInformation("Custom processor Begin called!");
                    return await base.BeginProcessingMessageAsync(actions, message, cancellationToken);
                }

                protected internal override async Task CompleteProcessingMessageAsync(ServiceBusMessageActions actions, ServiceBusReceivedMessage message, Executors.FunctionResult result, CancellationToken cancellationToken)
                {
                    _logger?.LogInformation("Custom processor End called!");
                    await base.CompleteProcessingMessageAsync(actions, message, result, cancellationToken);
                }
            }
        }
    }
}

#pragma warning disable SA1402 // File may only contain a single type
public class TestPoco
#pragma warning restore SA1402 // File may only contain a single type
{
    public string Name { get; set; }
    public string Value { get; set; }
}