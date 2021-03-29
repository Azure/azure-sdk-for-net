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
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Tests;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class ServiceBusEndToEndTests : WebJobsServiceBusTestBase
    {
        private const string TriggerDetailsMessageStart = "Trigger Details:";
        private const string DrainingQueueMessageBody = "queue-message-draining-no-sessions-1";
        private const string DrainingTopicMessageBody = "topic-message-draining-no-sessions-1";

        private static EventWaitHandle _topicSubscriptionCalled1;
        private static EventWaitHandle _topicSubscriptionCalled2;
        private static EventWaitHandle _eventWait;
        private static EventWaitHandle _drainValidationPreDelay;
        private static EventWaitHandle _drainValidationPostDelay;

        // These two variables will be checked at the end of the test
        private static string _resultMessage1;
        private static string _resultMessage2;

        public ServiceBusEndToEndTests() : base(isSession: false)
        {
            _eventWait = new ManualResetEvent(initialState: false);
        }

        [Test]
        public async Task ServiceBusEndToEnd()
        {
            var (jobHost, host) = BuildHost<ServiceBusTestJobs>(startHost: false);
            using (jobHost)
            {
                await ServiceBusEndToEndInternal<ServiceBusTestJobs>(host);
            }
        }

        [Test]
        public async Task ServiceBusBinderTest()
        {
            var (jobHost, host) = BuildHost<BinderTestJobs>();
            using (jobHost)
            {
                int numMessages = 10;
                var args = new { message = "Test Message", numMessages = numMessages };
                await jobHost.CallAsync(nameof(BinderTestJobs.ServiceBusBinderTest), args);
                await jobHost.CallAsync(nameof(BinderTestJobs.ServiceBusBinderTest), args);
                await jobHost.CallAsync(nameof(BinderTestJobs.ServiceBusBinderTest), args);

                var count = await CleanUpEntity(_firstQueueScope.QueueName);

                Assert.AreEqual(numMessages * 3, count);
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
                message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
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
            var (jobHost, host) = BuildHost<ServiceBusTestJobs>(host =>
                host.ConfigureServices(services =>
                {
                    services.AddSingleton<MessagingProvider, CustomMessagingProvider>();
                }),
                startHost: false);

            using (jobHost)
            {
                var loggerProvider = host.GetTestLoggerProvider();

                await ServiceBusEndToEndInternal<ServiceBusTestJobs>(host: host);

                // in addition to verifying that our custom processor was called, we're also
                // verifying here that extensions can log
                IEnumerable<LogMessage> messages = loggerProvider.GetAllLogMessages().Where(m => m.Category == CustomMessagingProvider.CustomMessagingCategory);
                Assert.AreEqual(4, messages.Count(p => p.FormattedMessage.Contains("Custom processor Begin called!")));
                Assert.AreEqual(4, messages.Count(p => p.FormattedMessage.Contains("Custom processor End called!")));
            }
        }

        [Test]
        public async Task MultipleAccountTest()
        {
            var (jobHost, host) = BuildHost<ServiceBusTestJobs>(host =>
                host.ConfigureServices(services =>
                {
                    services.AddSingleton<MessagingProvider, CustomMessagingProvider>();
                }));
            using (jobHost)
            {
                await WriteQueueMessage(
                    "Test",
                    connectionString: ServiceBusTestEnvironment.Instance.ServiceBusSecondaryNamespaceConnectionString,
                    queueName: _secondaryNamespaceQueueScope.QueueName);

                _topicSubscriptionCalled1 = new ManualResetEvent(initialState: false);
                _topicSubscriptionCalled2 = new ManualResetEvent(initialState: false);

                _topicSubscriptionCalled1.WaitOne(SBTimeoutMills);
                _topicSubscriptionCalled2.WaitOne(SBTimeoutMills);

                // ensure all logs have had a chance to flush
                await Task.Delay(3000);
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
        public async Task TestBatch_JsonPoco()
        {
            await TestMultiple<ServiceBusMultipleMessagesTestJob_BindToPocoArray>();
        }

        [Test]
        public async Task TestBatch_DataContractPoco()
        {
            await TestMultiple<ServiceBusMultipleMessagesTestJob_BindToPocoArray>(true);
        }

        [Test]
        public async Task BindToPoco()
        {
            var (jobHost, host) = BuildHost<ServiceBusArgumentBindingJob>();
            using (jobHost)
            {
                await WriteQueueMessage("{ Name: 'foo', Value: 'bar' }");

                bool result = _eventWait.WaitOne(SBTimeoutMills);
                Assert.True(result);

                var logs = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.FormattedMessage).ToList();
                Assert.Contains("PocoValues(foo,bar)", logs);
            }
        }

        [Test]
        public async Task BindToString()
        {
            var (jobHost, host) = BuildHost<ServiceBusArgumentBindingJob>();
            using (jobHost)
            {
                var method = typeof(ServiceBusArgumentBindingJob).GetMethod(nameof(ServiceBusArgumentBindingJob.BindToString), BindingFlags.Static | BindingFlags.Public);
                await jobHost.CallAsync(method, new { input = "foobar" });

                bool result = _eventWait.WaitOne(SBTimeoutMills);
                Assert.True(result);

                var logs = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.FormattedMessage).ToList();
                Assert.Contains("Input(foobar)", logs);
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

        /*
         * Helper functions
         */

        private async Task TestSingleDrainMode<T>(bool sendToQueue)
        {
            var (jobHost, host) = BuildHost<T>(BuildDrainHost<T>());

            using (jobHost)
            {
                _drainValidationPreDelay = new ManualResetEvent(initialState: false);
                _drainValidationPostDelay = new ManualResetEvent(initialState: false);

                if (sendToQueue)
                {
                    await WriteQueueMessage(DrainingQueueMessageBody);
                }
                else
                {
                    await WriteTopicMessage(DrainingTopicMessageBody);
                }

                // Wait to ensure function invocatoin has started before draining messages
                Assert.True(_drainValidationPreDelay.WaitOne(SBTimeoutMills));

                // Start draining in-flight messages
                var drainModeManager = host.Services.GetService<IDrainModeManager>();
                await drainModeManager.EnableDrainModeAsync(CancellationToken.None);

                // Validate that function execution was allowed to complete
                Assert.True(_drainValidationPostDelay.WaitOne(DrainWaitTimeoutMills + SBTimeoutMills));
            }
        }

        private static Action<IHostBuilder> BuildDrainHost<T>()
        {
            return builder =>
                builder.ConfigureDefaultTestHost<T>(b =>
                    b.AddServiceBus(sbOptions =>
                    {
                        // We want to ensure messages can be completed in the function code before signaling success to the test
                        sbOptions.AutoCompleteMessages = false;
                        sbOptions.MaxAutoLockRenewalDuration = TimeSpan.FromMinutes(MaxAutoRenewDurationMin);
                        sbOptions.MaxConcurrentCalls = 1;
                    }));
        }

        private async Task TestMultiple<T>(bool isXml = false)
        {
            var (jobHost, _) = BuildHost<T>();
            using (jobHost)
            {
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

                _topicSubscriptionCalled1 = new ManualResetEvent(initialState: false);

                bool result = _topicSubscriptionCalled1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
        }

        private async Task TestMultipleDrainMode<T>(bool sendToQueue)
        {
            var (jobHost, host) = BuildHost<T>(BuildDrainHost<T>());
            using (jobHost)
            {
                _drainValidationPreDelay = new ManualResetEvent(initialState: false);
                _drainValidationPostDelay = new ManualResetEvent(initialState: false);

                if (sendToQueue)
                {
                    await WriteQueueMessage(DrainingQueueMessageBody);
                }
                else
                {
                    await WriteTopicMessage(DrainingTopicMessageBody);
                }

                // Wait to ensure function invocatoin has started before draining messages
                Assert.True(_drainValidationPreDelay.WaitOne(SBTimeoutMills));

                // Start draining in-flight messages
                var drainModeManager = host.Services.GetService<IDrainModeManager>();
                await drainModeManager.EnableDrainModeAsync(CancellationToken.None);

                // Validate that function execution was allowed to complete
                Assert.True(_drainValidationPostDelay.WaitOne(DrainWaitTimeoutMills + SBTimeoutMills));
            }
        }

        private async Task ServiceBusEndToEndInternal<T>(IHost host)
        {
            var jobContainerType = typeof(T);

            await WriteQueueMessage("E2E");

            _topicSubscriptionCalled1 = new ManualResetEvent(initialState: false);
            _topicSubscriptionCalled2 = new ManualResetEvent(initialState: false);

            await host.StartAsync();

            _topicSubscriptionCalled1.WaitOne(SBTimeoutMills);
            _topicSubscriptionCalled2.WaitOne(SBTimeoutMills);

            // ensure all logs have had a chance to flush
            await Task.Delay(4000);

            // Wait for the host to terminate
            await host.StopAsync();

            Assert.AreEqual("E2E-SBQueue2SBQueue-SBQueue2SBTopic-topic-1", _resultMessage1);
            Assert.AreEqual("E2E-SBQueue2SBQueue-SBQueue2SBTopic-topic-2", _resultMessage2);

            IEnumerable<LogMessage> logMessages = host.GetTestLoggerProvider()
                .GetAllLogMessages();

            // filter out anything from the custom processor for easier validation.
            IEnumerable<LogMessage> consoleOutput = logMessages
                .Where(m => m.Category != CustomMessagingProvider.CustomMessagingCategory);

            Assert.False(consoleOutput.Where(p => p.Level == LogLevel.Error).Any());

            string[] consoleOutputLines = consoleOutput
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
               $"  \"MaxConcurrentCalls\": {16 * Utility.GetProcessorCount()},",
                "  \"MaxConcurrentSessions\": 8,",
                "  \"MaxMessages\": 1000,",
                "  \"SessionIdleTimeout\": \"\"",
                "  \"RetryOptions\": {",
                "       \"Mode\": \"Exponential\",",
                "       \"TryTimeout\": \"00:00:10\",",
                "       \"Delay\": \"00:00:00.8000000\",",
                "       \"MaxDelay\": \"00:01:00\",",
                "       \"MaxRetries\": 3",
                "  }",
                "  \"TransportType\": \"AmqpTcp\",",
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
                [ServiceBusTrigger(FirstQueueNameKey)] string start, int deliveryCount,
                ServiceBusMessageActions messageActions,
                string lockToken,
                [ServiceBus(SecondQueueNameKey)] ServiceBusSender messageSender)
            {
                Assert.AreEqual(1, deliveryCount);

                // verify the message receiver and token are valid
                // TODO lockToken overload not supported in new SDK
                //await messageReceiver.RenewLockAsync(lockToken);

                var message = SBQueue2SBQueue_GetOutputMessage(start);
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

        public class BinderTestJobs
        {
            [NoAutomaticTrigger]
            public static async Task ServiceBusBinderTest(
                string message,
                int numMessages,
                Binder binder)
            {
                var attribute = new ServiceBusAttribute(_firstQueueScope.QueueName)
                {
                    EntityType = EntityType.Queue
                };

                var collector = await binder.BindAsync<IAsyncCollector<string>>(attribute);

                for (int i = 0; i < numMessages; i++)
                {
                    await collector.AddAsync(message + i);
                }

                await collector.FlushAsync();
            }
        }

        public class ServiceBusMultipleTestJobsBase
        {
            protected static bool firstReceived = false;
            protected static bool secondReceived = false;

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
            public static void SBQueue2SBQueue(
                [ServiceBusTrigger(FirstQueueNameKey)]
                ServiceBusReceivedMessage[] array,
                ServiceBusMessageActions messageActions)
            {
                string[] messages = array.Select(x => x.Body.ToString()).ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class ServiceBusMultipleMessagesTestJob_BindToPocoArray
        {
            public static void SBQueue2SBQueue(
                [ServiceBusTrigger(FirstQueueNameKey)] TestPoco[] array,
                ServiceBusMessageActions messageActions)
            {
                string[] messages = array.Select(x => "{'Name': '" + x.Name + "', 'Value': 'Value'}").ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
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
                _eventWait.Set();
            }

            [NoAutomaticTrigger]
            public static void BindToString(
                [ServiceBusTrigger(FirstQueueNameKey)] string input,
                string messageId,
                ILogger logger)
            {
                logger.LogInformation($"Input({input})");
                _eventWait.Set();
            }
        }

        public class DrainModeTestJobQueue
        {
            public static async Task QueueNoSessions(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage msg,
                ServiceBusMessageActions messageActions,
                CancellationToken cancellationToken,
                ILogger logger)
            {
                logger.LogInformation($"DrainModeValidationFunctions.QueueNoSessions: message data {msg.Body}");
                _drainValidationPreDelay.Set();
                await DrainModeHelper.WaitForCancellation(cancellationToken);
                Assert.True(cancellationToken.IsCancellationRequested);
                await messageActions.CompleteMessageAsync(msg);
                _drainValidationPostDelay.Set();
            }
        }

        public class DrainModeTestJobTopic
        {
            public static async Task TopicNoSessions(
                [ServiceBusTrigger(TopicNameKey, FirstSubscriptionNameKey)]
                ServiceBusReceivedMessage msg,
                ServiceBusMessageActions messageActions,
                CancellationToken cancellationToken,
                ILogger logger)
            {
                logger.LogInformation($"DrainModeValidationFunctions.NoSessions: message data {msg.Body}");
                _drainValidationPreDelay.Set();
                await DrainModeHelper.WaitForCancellation(cancellationToken);
                Assert.True(cancellationToken.IsCancellationRequested);
                await messageActions.CompleteMessageAsync(msg);
                _drainValidationPostDelay.Set();
            }
        }

        public class DrainModeTestJobQueueBatch
        {
            public static async Task QueueNoSessionsBatch(
               [ServiceBusTrigger(FirstQueueNameKey)]
               ServiceBusReceivedMessage[] array,
               ServiceBusMessageActions messageActions,
               CancellationToken cancellationToken,
               ILogger logger)
            {
                Assert.True(array.Length > 0);
                logger.LogInformation($"DrainModeTestJobBatch.QueueNoSessionsBatch: received {array.Length} messages");
                _drainValidationPreDelay.Set();
                await DrainModeHelper.WaitForCancellation(cancellationToken);
                Assert.True(cancellationToken.IsCancellationRequested);
                foreach (ServiceBusReceivedMessage msg in array)
                {
                    await messageActions.CompleteMessageAsync(msg);
                }
                _drainValidationPostDelay.Set();
            }
        }

        public class DrainModeTestJobTopicBatch
        {
            public static async Task TopicNoSessionsBatch(
                [ServiceBusTrigger(TopicNameKey, FirstSubscriptionNameKey)] ServiceBusReceivedMessage[] array,
                ServiceBusMessageActions messageActions,
                CancellationToken cancellationToken,
                ILogger logger)
            {
                Assert.True(array.Length > 0);
                logger.LogInformation($"DrainModeTestJobBatch.TopicNoSessionsBatch: received {array.Length} messages");
                _drainValidationPreDelay.Set();
                await DrainModeHelper.WaitForCancellation(cancellationToken);
                Assert.True(cancellationToken.IsCancellationRequested);
                foreach (ServiceBusReceivedMessage msg in array)
                {
                    await messageActions.CompleteMessageAsync(msg);
                }
                _drainValidationPostDelay.Set();
            }
        }

        public class DrainModeHelper
        {
            public static async Task WaitForCancellation(CancellationToken cancellationToken)
            {
                // Wait until the drain operation begins, signalled by the cancellation token
                int elapsedTimeMills = 0;
                while (elapsedTimeMills < DrainWaitTimeoutMills && !cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(elapsedTimeMills += 500);
                }
                // Allow some time for the Service Bus SDK to start draining before returning
                await Task.Delay(DrainSleepMills);
            }
        }

        private class CustomMessagingProvider : MessagingProvider
        {
            public const string CustomMessagingCategory = "CustomMessagingProvider";
            private readonly ILogger _logger;
            private readonly ServiceBusOptions _options;

            public CustomMessagingProvider(IOptions<ServiceBusOptions> serviceBusOptions, ILoggerFactory loggerFactory)
                : base(serviceBusOptions)
            {
                _options = serviceBusOptions.Value;
                _logger = loggerFactory?.CreateLogger(CustomMessagingCategory);
            }

            public override MessageProcessor CreateMessageProcessor(string entityPath, string connectionString)
            {
                var options = new ServiceBusProcessorOptions()
                {
                    MaxConcurrentCalls = 3,
                    MaxAutoLockRenewalDuration = TimeSpan.FromMinutes(MaxAutoRenewDurationMin)
                };

                var client = base.CreateClient(connectionString);
                var processor = client.CreateProcessor(entityPath, options);
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

                public override async Task<bool> BeginProcessingMessageAsync(ServiceBusMessageActions messageActions, ServiceBusReceivedMessage message, CancellationToken cancellationToken)
                {
                    _logger?.LogInformation("Custom processor Begin called!");
                    return await base.BeginProcessingMessageAsync(messageActions, message, cancellationToken);
                }

                public override async Task CompleteProcessingMessageAsync(ServiceBusMessageActions messageActions, ServiceBusReceivedMessage message, Executors.FunctionResult result, CancellationToken cancellationToken)
                {
                    _logger?.LogInformation("Custom processor End called!");
                    await base.CompleteProcessingMessageAsync(messageActions, message, result, cancellationToken);
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
}