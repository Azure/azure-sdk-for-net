// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Tests;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using static Azure.Messaging.ServiceBus.Tests.ServiceBusScope;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    [NonParallelizable]
    [LiveOnly(alwaysRunLocally: true)]
    public class WebJobsServiceBusTestBase
    {
        // surrounding with % indicates that this is used as a pointer to an app setting rather than
        // the literal value of the queue/topic/etc
        private const string _firstQueueNameKey = "webjobstestqueue1";
        protected const string FirstQueueNameKey = "%" + _firstQueueNameKey + "%";

        private const string _secondQueueNameKey = "webjobstestqueue2";
        protected const string SecondQueueNameKey = "%" + _secondQueueNameKey + "%";

        private const string _thirdQueueNameKey = "webjobstestqueue3";
        protected const string ThirdQueueNameKey = "%" + _thirdQueueNameKey + "%";

        private const string _topicNameKey = "webjobstesttopic";
        protected const string TopicNameKey = "%" + _topicNameKey + "%";

        private const string _firstSubscriptionNameKey = "webjobstestsubscription1";
        protected const string FirstSubscriptionNameKey = "%" + _firstSubscriptionNameKey + "%";

        private const string _secondSubscriptionNameKey = "webjobstestsubscription2";
        protected const string SecondSubscriptionNameKey = "%" + _secondSubscriptionNameKey + "%";

        private const string _secondaryNamespaceQueueKey = "webjobtestsecondarynamespacequeue";
        protected const string SecondaryNamespaceQueueNameKey = "%" + _secondaryNamespaceQueueKey + "%";

        // the connection key shouldn't use the % because the value specified is assumed to be a pointer
        protected const string SecondaryConnectionStringKey = "webjobtestsecondaryconnection";

        protected const int SBTimeoutMills = 120 * 1000;
        protected const int DrainWaitTimeoutMills = 120 * 1000;
        internal const int MaxAutoRenewDurationMin = 5;
        protected static TimeSpan HostShutdownTimeout = TimeSpan.FromSeconds(120);

        protected static QueueScope FirstQueueScope { get; private set; }
        protected static QueueScope SecondaryNamespaceQueueScope { get; private set; }
        protected static QueueScope SecondQueueScope { get; private set; }
        private QueueScope _thirdQueueScope;
        protected static TopicScope TopicScope { get; private set; }

        private readonly bool _isSession;
        protected static EventWaitHandle _topicSubscriptionCalled1;
        protected static EventWaitHandle _topicSubscriptionCalled2;
        protected static EventWaitHandle _waitHandle1;
        protected static EventWaitHandle _waitHandle2;
        protected static EventWaitHandle _drainValidationPreDelay;
        protected static EventWaitHandle _drainValidationPostDelay;

        protected static int ExpectedRemainingMessages { get; set; }

        protected WebJobsServiceBusTestBase(bool isSession)
        {
            _isSession = isSession;
        }

        /// <summary>
        ///   Performs the tasks needed to initialize the test.  This
        ///   method runs once for each test.
        /// </summary>
        ///
        [SetUp]
        public async Task FixtureSetUp()
        {
            ExpectedRemainingMessages = 0;
            FirstQueueScope = await CreateWithQueue(enablePartitioning: false, enableSession: _isSession, lockDuration: TimeSpan.FromSeconds(15));
            SecondQueueScope = await CreateWithQueue(enablePartitioning: false, enableSession: _isSession, lockDuration: TimeSpan.FromSeconds(15));
            _thirdQueueScope = await CreateWithQueue(enablePartitioning: false, enableSession: _isSession, lockDuration: TimeSpan.FromSeconds(15));
            TopicScope = await CreateWithTopic(
                enablePartitioning: false,
                enableSession: _isSession,
                topicSubscriptions: new string[] { "sub1", "sub2" });
            SecondaryNamespaceQueueScope = await CreateWithQueue(
                enablePartitioning: false,
                enableSession: _isSession,
                useSecondaryNamespace: true,
                lockDuration: TimeSpan.FromSeconds(15));
            _topicSubscriptionCalled1 = new ManualResetEvent(initialState: false);
            _topicSubscriptionCalled2 = new ManualResetEvent(initialState: false);
            _waitHandle1 = new ManualResetEvent(initialState: false);
            _waitHandle2 = new ManualResetEvent(initialState: false);
            _drainValidationPreDelay = new ManualResetEvent(initialState: false);
            _drainValidationPostDelay = new ManualResetEvent(initialState: false);
        }

        /// <summary>
        ///   Performs the tasks needed to cleanup the test after each
        ///   test has run.
        /// </summary>
        ///
        [TearDown]
        public async Task FixtureTearDown()
        {
            await FirstQueueScope.DisposeAsync();
            await SecondQueueScope.DisposeAsync();
            await _thirdQueueScope.DisposeAsync();
            await SecondaryNamespaceQueueScope.DisposeAsync();
            await TopicScope.DisposeAsync();
        }

        protected IHost BuildHost<TJobClass>(
            Action<IHostBuilder> configurationDelegate = null,
            bool startHost = true,
            bool useTokenCredential = false,
            bool skipValidation = false)
        {
            var settings = new Dictionary<string, string>
            {
                {_firstQueueNameKey, FirstQueueScope.QueueName},
                {_secondQueueNameKey, SecondQueueScope.QueueName},
                {_thirdQueueNameKey, _thirdQueueScope.QueueName},
                {_topicNameKey, TopicScope.TopicName},
                {_firstSubscriptionNameKey, TopicScope.SubscriptionNames[0]},
                {_secondSubscriptionNameKey, TopicScope.SubscriptionNames[1]},
                {_secondaryNamespaceQueueKey, SecondaryNamespaceQueueScope.QueueName},
                {SecondaryConnectionStringKey, ServiceBusTestEnvironment.Instance.ServiceBusSecondaryNamespaceConnectionString}
            };
            if (useTokenCredential)
            {
                settings.Add("AzureWebJobsServiceBus:fullyQualifiedNamespace", ServiceBusTestEnvironment.Instance.FullyQualifiedNamespace);
            }
            else
            {
                settings.Add("AzureWebJobsServiceBus", ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
            }

            var hostBuilder = new HostBuilder()
                .ConfigureServices(s =>
                {
                    s.AddAzureClients(clientBuilder =>
                    {
                        clientBuilder.UseCredential(ServiceBusTestEnvironment.Instance.Credential);
                    });

                    s.Configure<HostOptions>(opts => opts.ShutdownTimeout = HostShutdownTimeout);
                    // Configure ServiceBusEndToEndTestService before WebJobs stuff so that the ServiceBusEndToEndTestService.StopAsync will be called after
                    // the WebJobsHost.StopAsync (service that is started first will be stopped last by the IHost).
                    // This will allow the logs captured in StopAsync to include everything from WebJobs.
                    if (!skipValidation)
                    {
                        s.AddHostedService<ServiceBusEndToEndTestService>();
                    }
                })
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddInMemoryCollection(settings);
                })
                .ConfigureDefaultTestHost<TJobClass>(b =>
                {
                    b.AddServiceBus(options => options.ClientRetryOptions.TryTimeout = TimeSpan.FromSeconds(10));
                });
            // do this after the defaults so test-specific values will override the defaults
            configurationDelegate?.Invoke(hostBuilder);
            IHost host = hostBuilder.Build();
            if (startHost)
            {
                host.StartAsync().GetAwaiter().GetResult();
            }

            return host;
        }

        internal async Task WriteQueueMessage(string message, string sessionId = null, string connectionString = default, string queueName = default)
        {
            await using ServiceBusClient client = new ServiceBusClient(connectionString ?? ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
            var sender = client.CreateSender(queueName ?? FirstQueueScope.QueueName);
            ServiceBusMessage messageObj = new ServiceBusMessage(message)
            {
                ContentType = "application/json",
                CorrelationId = "correlationId",
                Subject = "subject",
                To = "to",
                ReplyTo = "replyTo",
                ApplicationProperties = {{ "key", "value"}},
                PartitionKey = "partitionKey"
            };
            if (!string.IsNullOrEmpty(sessionId))
            {
                messageObj.SessionId = sessionId;
                messageObj.ReplyToSessionId = sessionId;
            }
            await sender.SendMessageAsync(messageObj);
        }

        internal async Task WriteQueueMessages(string[] messages, string[] sessionIds = null, string connectionString = default, string queueName = default)
        {
            await using ServiceBusClient client = new ServiceBusClient(connectionString ?? ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
            var sender = client.CreateSender(queueName ?? FirstQueueScope.QueueName);

            ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
            int sessionCounter = 0;
            for (int i = 0; i < messages.Length; i++)
            {
                var message = new ServiceBusMessage(messages[i]);
                message.ContentType = "application/text";

                if (sessionIds != null && sessionIds.Length > 0)
                {
                    // evenly distribute the messages across sessions
                    message.SessionId = sessionIds[sessionCounter++ % sessionIds.Length];
                    message.ReplyToSessionId = message.SessionId;
                }

                if (!batch.TryAddMessage(message))
                {
                    throw new InvalidOperationException("Unable to add message to batch.");
                }
            }

            await sender.SendMessagesAsync(batch);
        }

        internal async Task WriteQueueMessage(TestPoco obj, string sessionId = null)
        {
            var serializer = new DataContractSerializer(typeof(TestPoco));
            byte[] payload = null;
            using (var memoryStream = new MemoryStream(10))
            {
                var xmlDictionaryWriter = XmlDictionaryWriter.CreateBinaryWriter(memoryStream, null, null, false);
                serializer.WriteObject(xmlDictionaryWriter, obj);
                xmlDictionaryWriter.Flush();
                memoryStream.Flush();
                memoryStream.Position = 0;
                payload = memoryStream.ToArray();
            }

            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
            var sender = client.CreateSender(FirstQueueScope.QueueName);
            ServiceBusMessage messageObj = new ServiceBusMessage(payload);
            if (!string.IsNullOrEmpty(sessionId))
            {
                messageObj.SessionId = sessionId;
                messageObj.ReplyToSessionId = sessionId;
            }
            await sender.SendMessageAsync(messageObj);
        }

        internal async Task WriteTopicMessage(string message, string sessionId = null)
        {
            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
            var sender = client.CreateSender(TopicScope.TopicName);
            ServiceBusMessage messageObj = new ServiceBusMessage(message);
            if (!string.IsNullOrEmpty(sessionId))
            {
                messageObj.SessionId = sessionId;
                messageObj.ReplyToSessionId = sessionId;
            }
            await sender.SendMessageAsync(messageObj);
        }

        protected static Action<IHostBuilder> EnableCrossEntityTransactions =>
            builder => builder.ConfigureWebJobs(b =>
            b.AddServiceBus(sbOptions =>
            {
                sbOptions.EnableCrossEntityTransactions = true;
            }));

        protected static Action<IHostBuilder> SetCustomErrorHandler =>
            builder => builder.ConfigureWebJobs(b =>
                b.AddServiceBus(sbOptions =>
                {
                    sbOptions.ProcessErrorAsync = ServiceBusEndToEndTests.TestCustomErrorHandler.ErrorHandler;
                    sbOptions.MaxAutoLockRenewalDuration = TimeSpan.Zero;
                    sbOptions.MaxConcurrentCalls = 1;
                }));

        protected static class DrainModeHelper
        {
            public static async Task WaitForCancellationAsync(CancellationToken cancellationToken)
            {
                // Wait until the drain operation begins, signalled by the cancellation token
                int elapsedTimeMills = 0;
                while (elapsedTimeMills < DrainWaitTimeoutMills && !cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        await Task.Delay(elapsedTimeMills += 500, cancellationToken);
                    }
                    catch (TaskCanceledException)
                    {
                    }
                }
            }
        }

        private class ServiceBusEndToEndTestService : IHostedService
        {
            private readonly IHost _host;

            public ServiceBusEndToEndTestService(IHost host)
            {
                _host = host;
            }

            public Task StartAsync(CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }

            public async Task StopAsync(CancellationToken cancellationToken)
            {
                var logs = _host.GetTestLoggerProvider().GetAllLogMessages();
                var errors = logs.Where(IsError);
                Assert.IsEmpty(errors, string.Join(
                    ",",
                    errors.Select(e => e.Exception != null ? e.Exception.StackTrace : e.FormattedMessage)));

                var client = new ServiceBusAdministrationClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);

                // wait for a few seconds to allow updated counts to propagate
                await Task.Delay(TimeSpan.FromSeconds(2));

                QueueRuntimeProperties properties = await client.GetQueueRuntimePropertiesAsync(FirstQueueScope.QueueName, CancellationToken.None);
                Assert.AreEqual(ExpectedRemainingMessages, properties.ActiveMessageCount);
            }

            private static bool IsError(LogMessage logMessage)
            {
                if (logMessage.Level < LogLevel.Error)
                {
                    return false;
                }
                // if the inner exception message contains "Test exception" then it's an expected exception
                if (logMessage.Exception != null && logMessage.Exception.InnerException != null &&
                    logMessage.Exception.InnerException.Message.Contains("Test exception"))
                {
                    return false;
                }
                // if the formatted message is not null and it contains "ReceiveBatchAsync Exception: System.Threading.Tasks.TaskCanceledException"
                // then it's an expected exception
                if (logMessage.FormattedMessage != null &&
                    (logMessage.FormattedMessage.Contains("ReceiveBatchAsync Exception: System.Threading.Tasks.TaskCanceledException") ||
                     // this condition can be removed when https://github.com/Azure/azure-sdk-for-net/issues/37713 is fixed
                     logMessage.FormattedMessage.Contains("Put token failed. status-code: 404, status-description: The messaging entity")))
                {
                    return false;
                }

                return true;
            }
        }
    }
}