// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class ServiceBusSessionsEndToEndTests : WebJobsServiceBusTestBase
    {
        private const string _drainModeSessionId = "drain-session";
        private const string DrainingQueueMessageBody = "queue-message-draining-with-sessions-1";
        private const string DrainingTopicMessageBody = "topic-message-draining-with-sessions-1";
        private static EventWaitHandle _waitHandle1;
        private static EventWaitHandle _waitHandle2;
        private static EventWaitHandle _drainValidationPreDelay;
        private static EventWaitHandle _drainValidationPostDelay;

        public ServiceBusSessionsEndToEndTests() : base(isSession: true)
        {
        }

        [Test]
        public async Task ServiceBusSessionQueue_OrderGuaranteed()
        {
            var (jobHost, host) = BuildSessionHost<ServiceBusSessionsTestJobs1>();
            using (jobHost)
            {
                _waitHandle1 = new ManualResetEvent(initialState: false);

                await WriteQueueMessage("message1", "test-session1");
                await WriteQueueMessage("message2", "test-session1");
                await WriteQueueMessage("message3", "test-session1");
                await WriteQueueMessage("message4", "test-session1");
                await WriteQueueMessage("message5", "test-session1");

                Assert.True(_waitHandle1.WaitOne(SBTimeoutMills));

                IEnumerable<LogMessage> logMessages = host.GetTestLoggerProvider().GetAllLogMessages();

                // filter out anything from the custom processor for easier validation.
                List<LogMessage> consoleOutput = logMessages.Where(m => m.Category == "Function.SBQueue1Trigger.User").ToList();

                Assert.True(consoleOutput.Count() == 5, ServiceBusSessionsTestHelper.GetLogsAsString(consoleOutput));

                int i = 1;
                foreach (LogMessage logMessage in consoleOutput)
                {
                    StringAssert.StartsWith("message" + i++, logMessage.FormattedMessage);
                }
            }
        }

        [Test]
        public async Task ServiceBusSessionTopicSubscription_OrderGuaranteed()
        {
            var (jobHost, host) = BuildSessionHost<ServiceBusSessionsTestJobs1>();
            using (jobHost)
            {
                _waitHandle1 = new ManualResetEvent(initialState: false);

                await WriteTopicMessage("message1", "test-session1");
                await WriteTopicMessage("message2", "test-session1");
                await WriteTopicMessage("message3", "test-session1");
                await WriteTopicMessage("message4", "test-session1");
                await WriteTopicMessage("message5", "test-session1");

                Assert.True(_waitHandle1.WaitOne(SBTimeoutMills));

                IEnumerable<LogMessage> logMessages = host.GetTestLoggerProvider().GetAllLogMessages();

                // filter out anything from the custom processor for easier validation.
                List<LogMessage> consoleOutput = logMessages.Where(m => m.Category == "Function.SBSub1Trigger.User").ToList();

                Assert.True(consoleOutput.Count() == 5, ServiceBusSessionsTestHelper.GetLogsAsString(consoleOutput));

                int i = 1;
                foreach (LogMessage logMessage in consoleOutput)
                {
                    StringAssert.StartsWith("message" + i++, logMessage.FormattedMessage);
                }
            }
        }

        [Test]
        public async Task ServiceBusSessionQueue_DifferentHosts_DifferentSessions()
        {
            var (jobHost1, host1) = BuildSessionHost<ServiceBusSessionsTestJobs1>(true);
            var (jobHost2, host2) = BuildSessionHost<ServiceBusSessionsTestJobs2>(true);
            using (jobHost1)
            using (jobHost2)
            {
                _waitHandle1 = new ManualResetEvent(initialState: false);
                _waitHandle2 = new ManualResetEvent(initialState: false);

                await WriteQueueMessage("message1", "test-session1");
                await WriteQueueMessage("message1", "test-session2");

                await WriteQueueMessage("message2", "test-session1");
                await WriteQueueMessage("message2", "test-session2");

                await WriteQueueMessage("message3", "test-session1");
                await WriteQueueMessage("message3", "test-session2");

                await WriteQueueMessage("message4", "test-session1");
                await WriteQueueMessage("message4", "test-session2");

                await WriteQueueMessage("message5", "test-session1");
                await WriteQueueMessage("message5", "test-session2");

                Assert.True(_waitHandle1.WaitOne(SBTimeoutMills));
                Assert.True(_waitHandle2.WaitOne(SBTimeoutMills));

                IEnumerable<LogMessage> logMessages1 = host1.GetTestLoggerProvider().GetAllLogMessages();
                List<LogMessage> consoleOutput1 = logMessages1.Where(m => m.Category == "Function.SBQueue1Trigger.User").ToList();
                Assert.IsNotEmpty(logMessages1.Where(m => m.Category == "CustomMessagingProvider" && m.FormattedMessage.StartsWith("Custom processor Begin called!")));
                Assert.IsNotEmpty(logMessages1.Where(m => m.Category == "CustomMessagingProvider" && m.FormattedMessage.StartsWith("Custom processor End called!")));
                IEnumerable<LogMessage> logMessages2 = host2.GetTestLoggerProvider().GetAllLogMessages();
                List<LogMessage> consoleOutput2 = logMessages2.Where(m => m.Category == "Function.SBQueue2Trigger.User").ToList();
                Assert.IsNotEmpty(logMessages2.Where(m => m.Category == "CustomMessagingProvider" && m.FormattedMessage.StartsWith("Custom processor Begin called!")));
                Assert.IsNotEmpty(logMessages2.Where(m => m.Category == "CustomMessagingProvider" && m.FormattedMessage.StartsWith("Custom processor End called!")));
                char sessionId1 = consoleOutput1[0].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1];
                foreach (LogMessage m in consoleOutput1)
                {
                    Assert.AreEqual(sessionId1, m.FormattedMessage[m.FormattedMessage.Length - 1]);
                }

                char sessionId2 = consoleOutput2[0].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1];
                foreach (LogMessage m in consoleOutput2)
                {
                    Assert.AreEqual(sessionId2, m.FormattedMessage[m.FormattedMessage.Length - 1]);
                }
            }
        }

        [Test]
        public async Task ServiceBusSessionSub_DifferentHosts_DifferentSessions()
        {
            var (jobHost1, host1) = BuildSessionHost<ServiceBusSessionsTestJobs1>(true);
            var (jobHost2, host2) = BuildSessionHost<ServiceBusSessionsTestJobs2>(true);
            using (jobHost1)
            using (jobHost2)
            {
                _waitHandle1 = new ManualResetEvent(initialState: false);
                _waitHandle2 = new ManualResetEvent(initialState: false);

                await WriteTopicMessage("message1", "test-session1");
                await WriteTopicMessage("message1", "test-session2");

                await WriteTopicMessage("message2", "test-session1");
                await WriteTopicMessage("message2", "test-session2");

                await WriteTopicMessage("message3", "test-session1");
                await WriteTopicMessage("message3", "test-session2");

                await WriteTopicMessage("message4", "test-session1");
                await WriteTopicMessage("message4", "test-session2");

                await WriteTopicMessage("message5", "test-session1");
                await WriteTopicMessage("message5", "test-session2");

                Assert.True(_waitHandle1.WaitOne(SBTimeoutMills));
                Assert.True(_waitHandle2.WaitOne(SBTimeoutMills));

                IEnumerable<LogMessage> logMessages1 = host1.GetTestLoggerProvider().GetAllLogMessages();
                List<LogMessage> consoleOutput1 = logMessages1.Where(m => m.Category == "Function.SBSub1Trigger.User").ToList();
                Assert.IsNotEmpty(logMessages1.Where(m => m.Category == "CustomMessagingProvider" && m.FormattedMessage.StartsWith("Custom processor Begin called!")));
                Assert.IsNotEmpty(logMessages1.Where(m => m.Category == "CustomMessagingProvider" && m.FormattedMessage.StartsWith("Custom processor End called!")));
                IEnumerable<LogMessage> logMessages2 = host2.GetTestLoggerProvider().GetAllLogMessages();
                List<LogMessage> consoleOutput2 = logMessages2.Where(m => m.Category == "Function.SBSub2Trigger.User").ToList();
                Assert.IsNotEmpty(logMessages2.Where(m => m.Category == "CustomMessagingProvider" && m.FormattedMessage.StartsWith("Custom processor Begin called!")));
                Assert.IsNotEmpty(logMessages2.Where(m => m.Category == "CustomMessagingProvider" && m.FormattedMessage.StartsWith("Custom processor End called!")));

                char sessionId1 = consoleOutput1[0].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1];
                foreach (LogMessage m in consoleOutput1)
                {
                    Assert.AreEqual(sessionId1, m.FormattedMessage[m.FormattedMessage.Length - 1]);
                }

                char sessionId2 = consoleOutput2[0].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1];
                foreach (LogMessage m in consoleOutput2)
                {
                    Assert.AreEqual(sessionId2, m.FormattedMessage[m.FormattedMessage.Length - 1]);
                }
            }
        }

        [Test]
        public async Task ServiceBusSessionQueue_SessionLocks()
        {
            var (jobHost, host) = BuildSessionHost<ServiceBusSessionsTestJobs1>(addCustomProvider: true);
            using (jobHost)
            {
                _waitHandle1 = new ManualResetEvent(initialState: false);
                _waitHandle2 = new ManualResetEvent(initialState: false);

                await WriteQueueMessage("message1", "test-session1");
                await WriteQueueMessage("message1", "test-session2");

                await WriteQueueMessage("message2", "test-session1");
                await WriteQueueMessage("message2", "test-session2");

                await WriteQueueMessage("message3", "test-session1");
                await WriteQueueMessage("message3", "test-session2");

                await WriteQueueMessage("message4", "test-session1");
                await WriteQueueMessage("message4", "test-session2");

                await WriteQueueMessage("message5", "test-session1");
                await WriteQueueMessage("message5", "test-session2");

                Assert.True(_waitHandle1.WaitOne(SBTimeoutMills));
                Assert.True(_waitHandle2.WaitOne(SBTimeoutMills));

                IEnumerable<LogMessage> logMessages1 = host.GetTestLoggerProvider().GetAllLogMessages();

                // filter out anything from the custom processor for easier validation.
                List<LogMessage> consoleOutput1 = logMessages1.Where(m => m.Category == "Function.SBQueue1Trigger.User").ToList();
                Assert.True(consoleOutput1.Count() == 10, ServiceBusSessionsTestHelper.GetLogsAsString(consoleOutput1));
                double seconds = (consoleOutput1[5].Timestamp - consoleOutput1[4].Timestamp).TotalSeconds;
                Assert.True(seconds > 90 && seconds < 110, seconds.ToString());
                for (int i = 0; i < consoleOutput1.Count(); i++)
                {
                    if (i < 5)
                    {
                        Assert.AreEqual(consoleOutput1[i].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1],
                            consoleOutput1[0].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1]);
                    }
                    else
                    {
                        Assert.AreEqual(consoleOutput1[i].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1],
                            consoleOutput1[5].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1]);
                    }
                }
            }
        }

        [Test]
        public async Task ServiceBusSessionSub_SessionLocks()
        {
            var (jobHost, host) = BuildSessionHost<ServiceBusSessionsTestJobs1>(addCustomProvider: true);
            using (jobHost)
            {
                _waitHandle1 = new ManualResetEvent(initialState: false);
                _waitHandle2 = new ManualResetEvent(initialState: false);

                await WriteTopicMessage("message1", "test-session1");
                await WriteTopicMessage("message1", "test-session2");

                await WriteTopicMessage("message2", "test-session1");
                await WriteTopicMessage("message2", "test-session2");

                await WriteTopicMessage("message3", "test-session1");
                await WriteTopicMessage("message3", "test-session2");

                await WriteTopicMessage("message4", "test-session1");
                await WriteTopicMessage("message4", "test-session2");

                await WriteTopicMessage("message5", "test-session1");
                await WriteTopicMessage("message5", "test-session2");

                Assert.True(_waitHandle1.WaitOne(SBTimeoutMills));
                Assert.True(_waitHandle2.WaitOne(SBTimeoutMills));

                IEnumerable<LogMessage> logMessages1 = host.GetTestLoggerProvider().GetAllLogMessages();

                // filter out anything from the custom processor for easier validation.
                List<LogMessage> consoleOutput1 = logMessages1.Where(m => m.Category == "Function.SBSub1Trigger.User").ToList();
                Assert.True(consoleOutput1.Count() == 10, ServiceBusSessionsTestHelper.GetLogsAsString(consoleOutput1));
                double seconds = (consoleOutput1[5].Timestamp - consoleOutput1[4].Timestamp).TotalSeconds;
                Assert.True(seconds > 90 && seconds < 110, seconds.ToString());
                for (int i = 0; i < consoleOutput1.Count(); i++)
                {
                    if (i < 5)
                    {
                        Assert.AreEqual(consoleOutput1[i].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1],
                            consoleOutput1[0].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1]);
                    }
                    else
                    {
                        Assert.AreEqual(consoleOutput1[i].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1],
                            consoleOutput1[5].FormattedMessage[consoleOutput1[0].FormattedMessage.Length - 1]);
                    }
                }
            }
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
        public async Task MessageDraining_QueueWithSessions()
        {
            await TestSingleDrainMode<DrainModeTestJobQueue>(true);
        }

        [Test]
        public async Task MessageDraining_TopicWithSessions()
        {
            await TestSingleDrainMode<DrainModeTestJobTopic>(false);
        }

        [Test]
        public async Task MessageDraining_QueueWithSessions_Batch()
        {
            await TestMultipleDrainMode<DrainModeTestJobQueueBatch>(true);
        }

        [Test]
        public async Task MessageDraining_TopicWithSessions_Batch()
        {
            await TestMultipleDrainMode<DrainModeTestJobTopicBatch>(false);
        }

        /*
         * Helper functions
         */

        private (JobHost JobHost, IHost Host) BuildSessionHost<T>(bool addCustomProvider = false, bool autoComplete = true)
        {
            return BuildHost<T>(builder =>
                builder.ConfigureWebJobs(b =>
                    b.AddServiceBus(sbOptions =>
                    {
                        // Will be disabled for drain mode validation as messages are completed by functoin code to validate draining allows completion
                        sbOptions.AutoCompleteMessages = autoComplete;
                        sbOptions.MaxAutoLockRenewalDuration = TimeSpan.FromMinutes(MaxAutoRenewDurationMin);
                        sbOptions.MaxConcurrentSessions = 1;
                    }))
                .ConfigureServices(services =>
                {
                    if (addCustomProvider)
                    {
                        services.AddSingleton<MessagingProvider, CustomMessagingProvider>();
                    }
                })
            );
        }

        private async Task TestSingleDrainMode<T>(bool sendToQueue)
        {
            _drainValidationPreDelay = new ManualResetEvent(initialState: false);
            _drainValidationPostDelay = new ManualResetEvent(initialState: false);

            if (sendToQueue)
            {
                await WriteQueueMessage(DrainingQueueMessageBody, _drainModeSessionId);
            }
            else
            {
                await WriteTopicMessage(DrainingTopicMessageBody, _drainModeSessionId);
            }
            var (jobHost, host) = BuildSessionHost<T>(false, false);
            using (jobHost)
            {
                // Wait to ensure function invocatoin has started before draining messages
                Assert.True(_drainValidationPreDelay.WaitOne(SBTimeoutMills));

                // Start draining in-flight messages
                var drainModeManager = host.Services.GetService<IDrainModeManager>();
                await drainModeManager.EnableDrainModeAsync(CancellationToken.None);

                // Validate that function execution was allowed to complete
                Assert.True(_drainValidationPostDelay.WaitOne(DrainWaitTimeoutMills + SBTimeoutMills));
            }
        }

        private async Task TestMultiple<T>(bool isXml = false)
        {
            _waitHandle1 = new ManualResetEvent(initialState: false);

            if (isXml)
            {
                await WriteQueueMessage(new TestPoco() { Name = "Test1" }, "sessionId");
                await WriteQueueMessage(new TestPoco() { Name = "Test2" }, "sessionId");
            }
            else
            {
                await WriteQueueMessage("{'Name': 'Test1', 'Value': 'Value'}", "sessionId");
                await WriteQueueMessage("{'Name': 'Test2', 'Value': 'Value'}", "sessionId");
            }
            var (jobHost, _) = BuildSessionHost<T>(true);
            using (jobHost)
            {
                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
        }

        private async Task TestMultipleDrainMode<T>(bool sendToQueue)
        {
            _drainValidationPreDelay = new ManualResetEvent(initialState: false);
            _drainValidationPostDelay = new ManualResetEvent(initialState: false);

            if (sendToQueue)
            {
                await WriteQueueMessage(DrainingQueueMessageBody, _drainModeSessionId);
            }
            else
            {
                await WriteTopicMessage(DrainingTopicMessageBody, _drainModeSessionId);
            }
            var (jobHost, host) = BuildSessionHost<T>(false, false);
            using (jobHost)
            {
                // Wait to ensure function invocatoin has started before draining messages
                Assert.True(_drainValidationPreDelay.WaitOne(SBTimeoutMills));

                // Start draining in-flight messages
                var drainModeManager = host.Services.GetService<IDrainModeManager>();
                await drainModeManager.EnableDrainModeAsync(CancellationToken.None);

                // Validate that function execution was allowed to complete
                Assert.True(_drainValidationPostDelay.WaitOne(DrainWaitTimeoutMills + SBTimeoutMills));
            }
        }

        public class ServiceBusSessionsTestJobs1
        {
            public static void SBQueue1Trigger(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, int deliveryCount,
                ServiceBusSessionMessageActions messageSession,
                ILogger log,
                string lockToken)
            {
                Assert.AreEqual(1, deliveryCount);
                Assert.AreEqual(message.LockToken, lockToken);

                ServiceBusSessionsTestHelper.ProcessMessage(message, log, _waitHandle1, _waitHandle2);
            }

            public static void SBSub1Trigger(
                [ServiceBusTrigger(TopicNameKey, FirstSubscriptionNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, int deliveryCount,
                ServiceBusSessionMessageActions messageSession,
                ILogger log,
                string lockToken)
            {
                Assert.AreEqual(1, deliveryCount);
                Assert.AreEqual(message.LockToken, lockToken);

                ServiceBusSessionsTestHelper.ProcessMessage(message, log, _waitHandle1, _waitHandle2);
            }
        }

        public class ServiceBusSessionsTestJobs2
        {
            public static void SBQueue2Trigger(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message,
                ILogger log)
            {
                ServiceBusSessionsTestHelper.ProcessMessage(message, log, _waitHandle1, _waitHandle2);
            }

            public static void SBSub2Trigger(
                [ServiceBusTrigger(TopicNameKey, FirstSubscriptionNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message,
                ILogger log)
            {
                ServiceBusSessionsTestHelper.ProcessMessage(message, log, _waitHandle1, _waitHandle2);
            }
        }

        public class DrainModeTestJobQueue
        {
            public static async Task QueueWithSessions(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage msg,
                ServiceBusMessageActions messageActions,
                CancellationToken cancellationToken,
                ILogger logger)
            {
                logger.LogInformation($"DrainModeValidationFunctions.QueueWithSessions: message data {msg.Body} with session id {msg.SessionId}");
                Assert.AreEqual(_drainModeSessionId, msg.SessionId);
                _drainValidationPreDelay.Set();
                await DrainModeHelper.WaitForCancellation(cancellationToken);
                Assert.True(cancellationToken.IsCancellationRequested);
                await messageActions.CompleteMessageAsync(msg);
                _drainValidationPostDelay.Set();
            }
        }

        public class DrainModeTestJobTopic
        {
            public static async Task TopicWithSessions(
                [ServiceBusTrigger(TopicNameKey, FirstSubscriptionNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage msg,
                ServiceBusSessionMessageActions messageSession,
                CancellationToken cancellationToken,
                ILogger logger)
            {
                logger.LogInformation($"DrainModeValidationFunctions.TopicWithSessions: message data {msg.Body} with session id {msg.SessionId}");
                Assert.AreEqual(_drainModeSessionId, msg.SessionId);
                _drainValidationPreDelay.Set();
                await DrainModeHelper.WaitForCancellation(cancellationToken);
                Assert.True(cancellationToken.IsCancellationRequested);
                await messageSession.CompleteMessageAsync(msg);
                _drainValidationPostDelay.Set();
            }
        }

        public class DrainModeTestJobQueueBatch
        {
            public static async Task QueueWithSessionsBatch(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage[] array,
                ServiceBusMessageActions messageActions,
                CancellationToken cancellationToken,
                ILogger logger)
            {
                Assert.True(array.Length > 0);
                logger.LogInformation($"DrainModeTestJobBatch.QueueWithSessionsBatch: received {array.Length} messages with session id {array[0].SessionId}");
                Assert.AreEqual(_drainModeSessionId, array[0].SessionId);
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
            public static async Task TopicWithSessionsBatch(
                [ServiceBusTrigger(TopicNameKey, FirstSubscriptionNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage[] array,
                ServiceBusSessionMessageActions messageSession,
                CancellationToken cancellationToken,
                 ILogger logger)
            {
                Assert.True(array.Length > 0);
                logger.LogInformation($"DrainModeTestJobBatch.TopicWithSessionsBatch: received {array.Length} messages with session id {array[0].SessionId}");
                Assert.AreEqual(_drainModeSessionId, array[0].SessionId);
                _drainValidationPreDelay.Set();
                await DrainModeHelper.WaitForCancellation(cancellationToken);
                Assert.True(cancellationToken.IsCancellationRequested);
                foreach (ServiceBusReceivedMessage msg in array)
                {
                    await messageSession.CompleteMessageAsync(msg);
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

        public class ServiceBusMultipleTestJobsBase
        {
            protected static bool firstReceived = false;
            protected static bool secondReceived = false;

            public static void ProcessMessages(string[] messages, EventWaitHandle waitHandle = null)
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
                    bool b = (waitHandle != null) ? waitHandle.Set() : _waitHandle1.Set();
                }
            }
        }

        public class ServiceBusMultipleMessagesTestJob_BindToStringArray
        {
            public static async Task SBQueue2SBQueue(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] string[] messages,
                ServiceBusSessionMessageActions messageSession, CancellationToken cancellationToken)
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
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage[] array,
                ServiceBusSessionMessageActions messageSession)
            {
                string[] messages = array.Select(x => x.Body.ToString()).ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class ServiceBusMultipleMessagesTestJob_BindToPocoArray
        {
            public static void SBQueue2SBQueue(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] TestPoco[] array,
                ServiceBusSessionMessageActions messageSession)
            {
                string[] messages = array.Select(x => "{'Name': '" + x.Name + "', 'Value': 'Value'}").ToArray();
                ServiceBusMultipleTestJobsBase.ProcessMessages(messages);
            }
        }

        public class CustomMessagingProvider : MessagingProvider
        {
            public const string CustomMessagingCategory = "CustomMessagingProvider";
            private readonly ILogger _logger;
            private readonly ServiceBusOptions _options;

            public CustomMessagingProvider(IOptions<ServiceBusOptions> serviceBusOptions, ILoggerFactory loggerFactory)
                : base(serviceBusOptions)
            {
                _options = serviceBusOptions.Value;
                //_options.SessionProcessorOptions.MessageWaitTimeout = TimeSpan.FromSeconds(90);
                _options.RetryOptions.TryTimeout = TimeSpan.FromSeconds(90);
                _options.MaxConcurrentSessions = 1;
                _logger = loggerFactory?.CreateLogger(CustomMessagingCategory);
            }

            public override SessionMessageProcessor CreateSessionMessageProcessor(string entityPath, string connectionString)
            {
                var client = new ServiceBusClient(connectionString, _options.ToClientOptions());
                ServiceBusSessionProcessor processor;
                if (entityPath == _firstQueueScope.QueueName)
                {
                    processor = client.CreateSessionProcessor(entityPath, _options.ToSessionProcessorOptions());
                }
                else
                {
                    string[] arr = entityPath.Split('/');
                    processor = client.CreateSessionProcessor(arr[0], arr[2], _options.ToSessionProcessorOptions());
                }
                processor.ProcessErrorAsync += args => Task.CompletedTask;
                return new CustomSessionMessageProcessor(processor, _logger);
            }

            private class CustomSessionMessageProcessor : SessionMessageProcessor
            {
                private readonly ILogger _logger;

                public CustomSessionMessageProcessor(ServiceBusSessionProcessor sessionProcessor, ILogger logger)
                    : base(sessionProcessor)
                {
                    _logger = logger;
                }

                public override async Task<bool> BeginProcessingMessageAsync(ServiceBusSessionMessageActions sessionActions, ServiceBusReceivedMessage message, CancellationToken cancellationToken)
                {
                    _logger?.LogInformation("Custom processor Begin called!" + message.Body.ToString());
                    return await base.BeginProcessingMessageAsync(sessionActions, message, cancellationToken);
                }

                public override async Task CompleteProcessingMessageAsync(ServiceBusSessionMessageActions sessionActions, ServiceBusReceivedMessage message, Executors.FunctionResult result, CancellationToken cancellationToken)
                {
                    _logger?.LogInformation("Custom processor End called!" + message.Body.ToString());
                    await base.CompleteProcessingMessageAsync(sessionActions, message, result, cancellationToken);
                }
            }
        }

        public void Dispose()
        {
            if (_waitHandle1 != null)
            {
                _waitHandle1.Dispose();
            }
            if (_waitHandle2 != null)
            {
                _waitHandle2.Dispose();
            }
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class ServiceBusSessionsTestHelper
#pragma warning restore SA1402 // File may only contain a single type
    {
        public static void ProcessMessage(ServiceBusReceivedMessage message, ILogger log, EventWaitHandle waitHandle1, EventWaitHandle waitHandle2)
        {
            string messageString = message.Body.ToString();
            log.LogInformation($"{messageString}-{message.SessionId}");

            if (messageString == "message5" && message.SessionId == "test-session1")
            {
                waitHandle1.Set();
            }

            if (messageString == "message5" && message.SessionId == "test-session2")
            {
                waitHandle2.Set();
            }
        }

        public static string GetLogsAsString(List<LogMessage> messages)
        {
            if (messages.Count() != 5 && messages.Count() != 10)
            {
            }

            string reuslt = string.Empty;
            foreach (LogMessage message in messages)
            {
                reuslt += message.FormattedMessage + System.Environment.NewLine;
            }
            return reuslt;
        }
    }
}