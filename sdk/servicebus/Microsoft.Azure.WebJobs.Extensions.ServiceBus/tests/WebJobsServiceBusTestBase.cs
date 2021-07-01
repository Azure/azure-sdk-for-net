// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Tests;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using static Azure.Messaging.ServiceBus.Tests.ServiceBusScope;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    [NonParallelizable]
    [LiveOnly]
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
        protected const int DrainSleepMills = 5 * 1000;
        internal const int MaxAutoRenewDurationMin = 5;
        internal static TimeSpan HostShutdownTimeout = TimeSpan.FromSeconds(120);

        internal static QueueScope _firstQueueScope;
        protected static QueueScope _secondaryNamespaceQueueScope;
        private QueueScope _secondQueueScope;
        private QueueScope _thirdQueueScope;
        protected static TopicScope _topicScope;

        private readonly bool _isSession;
        protected static EventWaitHandle _topicSubscriptionCalled1;
        protected static EventWaitHandle _topicSubscriptionCalled2;
        protected static EventWaitHandle _waitHandle1;
        protected static EventWaitHandle _waitHandle2;
        protected static EventWaitHandle _drainValidationPreDelay;
        protected static EventWaitHandle _drainValidationPostDelay;

        protected WebJobsServiceBusTestBase(bool isSession)
        {
            _isSession = isSession;
        }

        /// <summary>
        ///   Performs the tasks needed to initialize the test.  This
        ///   method runs once for for each test.
        /// </summary>
        ///
        [SetUp]
        public async Task FixtureSetUp()
        {
            _firstQueueScope = await CreateWithQueue(enablePartitioning: false, enableSession: _isSession, lockDuration: TimeSpan.FromSeconds(15));
            _secondQueueScope = await CreateWithQueue(enablePartitioning: false, enableSession: _isSession, lockDuration: TimeSpan.FromSeconds(15));
            _thirdQueueScope = await CreateWithQueue(enablePartitioning: false, enableSession: _isSession, lockDuration: TimeSpan.FromSeconds(15));
            _topicScope = await CreateWithTopic(
                enablePartitioning: false,
                enableSession: _isSession,
                topicSubscriptions: new string[] { "sub1", "sub2" });
            _secondaryNamespaceQueueScope = await CreateWithQueue(
                enablePartitioning: false,
                enableSession: _isSession,
                overrideNamespace: ServiceBusTestEnvironment.Instance.ServiceBusSecondaryNamespace,
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
            await CleanupTestScope(_firstQueueScope);
            await CleanupTestScope(_secondQueueScope);
            await CleanupTestScope(_thirdQueueScope);
            await CleanupTestScope(_secondaryNamespaceQueueScope);
            await CleanupTestScope(_topicScope);
        }

        private async Task CleanupTestScope(IAsyncDisposable disposable)
        {
            if (disposable != null)
            {
                await disposable.DisposeAsync();
            }
        }

        protected IHost BuildHost<TJobClass>(
            Action<IHostBuilder> configurationDelegate = null,
            bool startHost = true,
            bool useTokenCredential = false)
        {
            var settings = new Dictionary<string, string>
            {
                {_firstQueueNameKey, _firstQueueScope.QueueName},
                {_secondQueueNameKey, _secondQueueScope.QueueName},
                {_thirdQueueNameKey, _thirdQueueScope.QueueName},
                {_topicNameKey, _topicScope.TopicName},
                {_firstSubscriptionNameKey, _topicScope.SubscriptionNames[0]},
                {_secondSubscriptionNameKey, _topicScope.SubscriptionNames[1]},
                {_secondaryNamespaceQueueKey, _secondaryNamespaceQueueScope.QueueName},
                {SecondaryConnectionStringKey, ServiceBusTestEnvironment.Instance.ServiceBusSecondaryNamespaceConnectionString}
            };
            if (useTokenCredential)
            {
                settings.Add("AzureWebJobsServiceBus:fullyQualifiedNamespace", ServiceBusTestEnvironment.Instance.FullyQualifiedNamespace);
                settings.Add("AzureWebJobsServiceBus:clientId", ServiceBusTestEnvironment.Instance.ClientId);
                settings.Add("AzureWebJobsServiceBus:clientSecret", ServiceBusTestEnvironment.Instance.ClientSecret);
                settings.Add("AzureWebJobsServiceBus:tenantId", ServiceBusTestEnvironment.Instance.TenantId);
            }
            else
            {
                settings.Add("AzureWebJobsServiceBus", ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
            }

            var hostBuilder = new HostBuilder()
                .ConfigureServices(s =>
                {
                    s.Configure<HostOptions>(opts => opts.ShutdownTimeout = HostShutdownTimeout);
                    // Configure ServiceBusEndToEndTestService before WebJobs stuff so that the ServiceBusEndToEndTestService.StopAsync will be called after
                    // the WebJobsHost.StopAsync (service that is started first will be stopped last by the IHost).
                    // This will allow the logs captured in StopAsync to include everything from WebJobs.
                    s.AddHostedService<ServiceBusEndToEndTestService>();
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
            var sender = client.CreateSender(queueName ?? _firstQueueScope.QueueName);
            ServiceBusMessage messageObj = new ServiceBusMessage(message)
            {
                ContentType = "application/json",
                CorrelationId = "correlationId",
                Subject = "subject",
                To = "to",
                ReplyTo = "replyTo",
                ApplicationProperties = {{ "key", "value"}}
            };
            if (!string.IsNullOrEmpty(sessionId))
            {
                messageObj.SessionId = sessionId;
            }
            await sender.SendMessageAsync(messageObj);
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
            var sender = client.CreateSender(_firstQueueScope.QueueName);
            ServiceBusMessage messageObj = new ServiceBusMessage(payload);
            if (!string.IsNullOrEmpty(sessionId))
            {
                messageObj.SessionId = sessionId;
            }
            await sender.SendMessageAsync(messageObj);
        }

        internal async Task WriteTopicMessage(string message, string sessionId = null)
        {
            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
            var sender = client.CreateSender(_topicScope.TopicName);
            ServiceBusMessage messageObj = new ServiceBusMessage(message);
            if (!string.IsNullOrEmpty(sessionId))
            {
                messageObj.SessionId = sessionId;
            }
            await sender.SendMessageAsync(messageObj);
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class ServiceBusEndToEndTestService : IHostedService
#pragma warning restore SA1402 // File may only contain a single type
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
            var errors = logs.Where(
                p => p.Level == LogLevel.Error &&
                // Ignore this error that the SDK logs when cancelling batch receive
                !p.FormattedMessage.Contains("ReceiveBatchAsync Exception: System.Threading.Tasks.TaskCanceledException"));
            Assert.IsEmpty(errors, string.Join(",", errors.Select(e => e.FormattedMessage)));

            var client = new ServiceBusAdministrationClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);

            // wait for a few seconds to allow updated counts to propagate
            await Task.Delay(TimeSpan.FromSeconds(2));

            QueueRuntimeProperties properties = await client.GetQueueRuntimePropertiesAsync(WebJobsServiceBusTestBase._firstQueueScope.QueueName, CancellationToken.None);
            Assert.AreEqual(0, properties.TotalMessageCount);
        }
    }
}