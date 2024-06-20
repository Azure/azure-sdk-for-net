// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Azure.WebJobs.ServiceBus.Tests;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Listeners
{
    public class ServiceBusListenerTests
    {
        private readonly ServiceBusListener _listener;
        private readonly Mock<ITriggeredFunctionExecutor> _mockExecutor;
        private readonly Mock<MessagingProvider> _mockMessagingProvider;
        private readonly Mock<ServiceBusClientFactory> _mockClientFactory;
        private readonly Mock<MessageProcessor> _mockMessageProcessor;
        private readonly TestLoggerProvider _loggerProvider;
        private readonly LoggerFactory _loggerFactory;
        private readonly string _functionId = "test-functionid";
        private readonly string _entityPath = "test-entity-path";
        private readonly string _connection = "connection";
        private readonly string _testConnection = "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
        private readonly Mock<IConcurrencyThrottleManager> _mockConcurrencyThrottleManager;
        private readonly ServiceBusClient _client;
        private readonly ConcurrencyManager _concurrencyManager;
        private readonly Mock<IDrainModeManager> _mockDrainModeManager;

        public ServiceBusListenerTests()
        {
            _mockExecutor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);

            _client = new ServiceBusClient(_testConnection);
            ServiceBusProcessor processor = _client.CreateProcessor(_entityPath);
            ServiceBusReceiver receiver = _client.CreateReceiver(_entityPath);
            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>(_connection, _testConnection));

            ServiceBusOptions config = new ServiceBusOptions
            {
                ProcessErrorAsync = ExceptionReceivedHandler
            };
            _mockMessageProcessor = new Mock<MessageProcessor>(MockBehavior.Strict, processor);

            _mockMessagingProvider = new Mock<MessagingProvider>(new OptionsWrapper<ServiceBusOptions>(config));
            _mockClientFactory = new Mock<ServiceBusClientFactory>(configuration, Mock.Of<AzureComponentFactory>(), _mockMessagingProvider.Object, new AzureEventSourceLogForwarder(new NullLoggerFactory()), new OptionsWrapper<ServiceBusOptions>(new ServiceBusOptions()));

            _mockDrainModeManager = new Mock<IDrainModeManager>();
            _mockDrainModeManager.Setup(p => p.IsDrainModeEnabled).Returns(true);

            _mockMessagingProvider
                .Setup(p => p.CreateMessageProcessor(It.IsAny<ServiceBusClient>(), _entityPath, It.IsAny<ServiceBusProcessorOptions>()))
                .Returns(_mockMessageProcessor.Object);

            _mockMessagingProvider
                    .Setup(p => p.CreateBatchMessageReceiver(It.IsAny<ServiceBusClient>(), _entityPath, default))
                    .Returns(receiver);

            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            var concurrencyOptions = new OptionsWrapper<ConcurrencyOptions>(new ConcurrencyOptions());
            _mockConcurrencyThrottleManager = new Mock<IConcurrencyThrottleManager>(MockBehavior.Strict);
            _concurrencyManager = new ConcurrencyManager(concurrencyOptions, _loggerFactory, _mockConcurrencyThrottleManager.Object);

            _listener = new ServiceBusListener(
                _functionId,
                ServiceBusEntityType.Queue,
                _entityPath,
                false,
                config.AutoCompleteMessages,
                config.MaxMessageBatchSize,
                _mockExecutor.Object,
                config,
                "connection",
                _mockMessagingProvider.Object,
                _loggerFactory,
                false,
                _mockClientFactory.Object,
                _concurrencyManager,
                _mockDrainModeManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            _loggerProvider.ClearAllLogMessages();
            _listener.Started = true;
            _listener.Disposed = false;
        }

        [Test]
        [Category("DynamicConcurrency")]
        public void ConcurrencyUpdateManager_UpdatesProcessorConcurrency()
        {
            var concurrencyOptions = new OptionsWrapper<ConcurrencyOptions>(new ConcurrencyOptions { DynamicConcurrencyEnabled = true });
            var concurrencyManager = new ConcurrencyManager(concurrencyOptions, _loggerFactory, _mockConcurrencyThrottleManager.Object);
            _mockConcurrencyThrottleManager.Setup(p => p.GetStatus()).Returns(new ConcurrencyThrottleAggregateStatus { State = ThrottleState.Disabled });
            ServiceBusProcessor processor = _client.CreateProcessor(_entityPath);
            Lazy<MessageProcessor> messageProcessor = new Lazy<MessageProcessor>(() => new MessageProcessor(processor));
            ILogger logger = _loggerFactory.CreateLogger("test");
            ServiceBusListener.ConcurrencyUpdateManager concurrencyUpdateManager = new ServiceBusListener.ConcurrencyUpdateManager(concurrencyManager, messageProcessor, null, false, _functionId, logger);

            // when no messages are being processed, concurrency is not adjusted
            Assert.AreEqual(1, processor.MaxConcurrentCalls);
            SetFunctionCurrentConcurrency(concurrencyManager, _functionId, 10);
            concurrencyUpdateManager.UpdateConcurrency();
            Assert.AreEqual(1, processor.MaxConcurrentCalls);

            // ensure processor concurrency is adjusted up
            concurrencyUpdateManager.MessageProcessed();
            concurrencyUpdateManager.UpdateConcurrency();
            Assert.AreEqual(10, processor.MaxConcurrentCalls);

            // ensure processor concurrency is adjusted down
            SetFunctionCurrentConcurrency(concurrencyManager, _functionId, 5);
            concurrencyUpdateManager.MessageProcessed();
            concurrencyUpdateManager.UpdateConcurrency();
            Assert.AreEqual(5, processor.MaxConcurrentCalls);
        }

        [Test]
        [Category("DynamicConcurrency")]
        public void ConcurrencyUpdateManager_Sessions_UpdatesProcessorConcurrency()
        {
            var concurrencyOptions = new OptionsWrapper<ConcurrencyOptions>(new ConcurrencyOptions { DynamicConcurrencyEnabled = true });
            var concurrencyManager = new ConcurrencyManager(concurrencyOptions, _loggerFactory, _mockConcurrencyThrottleManager.Object);
            _mockConcurrencyThrottleManager.Setup(p => p.GetStatus()).Returns(new ConcurrencyThrottleAggregateStatus { State = ThrottleState.Disabled });
            ServiceBusSessionProcessor sessionProcessor = _client.CreateSessionProcessor(_entityPath, new ServiceBusSessionProcessorOptions { MaxConcurrentSessions = 1, MaxConcurrentCallsPerSession = 1 });
            Lazy<SessionMessageProcessor> sessionMessageProcessor = new Lazy<SessionMessageProcessor>(() => new SessionMessageProcessor(sessionProcessor));
            ILogger logger = _loggerFactory.CreateLogger("test");
            ServiceBusListener.ConcurrencyUpdateManager concurrencyUpdateManager = new ServiceBusListener.ConcurrencyUpdateManager(concurrencyManager, null, sessionMessageProcessor, true, _functionId, logger);

            // when no messages are being processed, concurrency is not adjusted
            Assert.AreEqual(1, sessionProcessor.MaxConcurrentSessions);
            Assert.AreEqual(1, sessionProcessor.MaxConcurrentCallsPerSession);
            SetFunctionCurrentConcurrency(concurrencyManager, _functionId, 10);
            concurrencyUpdateManager.UpdateConcurrency();
            Assert.AreEqual(1, sessionProcessor.MaxConcurrentSessions);
            Assert.AreEqual(1, sessionProcessor.MaxConcurrentCallsPerSession);

            // ensure processor concurrency is adjusted up
            concurrencyUpdateManager.MessageProcessed();
            concurrencyUpdateManager.UpdateConcurrency();
            Assert.AreEqual(10, sessionProcessor.MaxConcurrentSessions);
            Assert.AreEqual(1, sessionProcessor.MaxConcurrentCallsPerSession);

            // ensure processor concurrency is adjusted down
            SetFunctionCurrentConcurrency(concurrencyManager, _functionId, 5);
            concurrencyUpdateManager.MessageProcessed();
            concurrencyUpdateManager.UpdateConcurrency();
            Assert.AreEqual(5, sessionProcessor.MaxConcurrentSessions);
            Assert.AreEqual(1, sessionProcessor.MaxConcurrentCallsPerSession);
        }

        [Test]
        public async Task ProcessMessageAsync_Success()
        {
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(
                messageId: Guid.NewGuid().ToString(),
                sequenceNumber: 1,
                deliveryCount: 55,
                enqueuedTime: DateTimeOffset.Now,
                lockedUntil: DateTimeOffset.Now);
            var receiver = new Mock<ServiceBusReceiver>().Object;
            var args = new ProcessMessageEventArgs(message, receiver, CancellationToken.None);
            _mockMessageProcessor.Setup(p => p.BeginProcessingMessageAsync(It.IsAny<ServiceBusMessageActions>(), message, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            FunctionResult result = new FunctionResult(true);
            _mockExecutor.Setup(p => p.TryExecuteAsync(It.Is<TriggeredFunctionData>(q => ((ServiceBusTriggerInput)q.TriggerValue).Messages[0] == message), It.IsAny<CancellationToken>())).ReturnsAsync(result);

            _mockMessageProcessor.Setup(p => p.CompleteProcessingMessageAsync(It.IsAny<ServiceBusMessageActions>(), message, result, It.IsAny<CancellationToken>())).Returns(Task.FromResult(0));

            await _listener.ProcessMessageAsync(args);

            _mockMessageProcessor.VerifyAll();
            _mockExecutor.VerifyAll();
            _mockMessageProcessor.VerifyAll();
        }

        [Test]
        public async Task ProcessMessageAsync_BeginProcessingReturnsFalse_MessageNotProcessed()
        {
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: Guid.NewGuid().ToString());
            var receiver = new Mock<ServiceBusReceiver>().Object;

            _mockMessageProcessor.Setup(p => p.BeginProcessingMessageAsync(
                It.IsAny<ServiceBusMessageActions>(),
                message,
                It.IsAny<CancellationToken>())).ReturnsAsync(false);
            var args = new ProcessMessageEventArgs(message, receiver, CancellationToken.None);

            await _listener.ProcessMessageAsync(args);

            _mockMessageProcessor.VerifyAll();
        }

        [Test]
        public async Task SessionIdleTimeoutRespected()
        {
            var mockClient = new Mock<ServiceBusClient>();
            var mockSessionReceiver = new Mock<ServiceBusSessionReceiver>();

            var options = new ServiceBusOptions
            {
                ProcessErrorAsync = ExceptionReceivedHandler,
                SessionIdleTimeout = TimeSpan.FromSeconds(5)
            };

            _mockMessagingProvider
                .Setup(p => p.CreateClient(_testConnection, It.IsAny<ServiceBusClientOptions>()))
                .Returns(mockClient.Object);

            mockClient
                .Setup(c => c.AcceptNextSessionAsync(_entityPath, It.IsAny<ServiceBusSessionReceiverOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(mockSessionReceiver.Object));

            mockSessionReceiver
                .Setup(r => r.ReceiveMessagesAsync(options.MaxMessageBatchSize, options.SessionIdleTimeout, It.IsAny<CancellationToken>()))
                .Returns(async () =>
                {
                    // need to simulate IO otherwise listener loop just spins
                    await Task.Delay(1);
                    return await Task.FromResult<IReadOnlyList<ServiceBusReceivedMessage>>(new List<ServiceBusReceivedMessage>(0));
                });

            var listener = new ServiceBusListener(
                _functionId,
                ServiceBusEntityType.Queue,
                _entityPath,
                true,
                true,
                options.MaxMessageBatchSize,
                _mockExecutor.Object,
                options,
                _connection,
                _mockMessagingProvider.Object,
                _loggerFactory,
                false,
                _mockClientFactory.Object,
                _concurrencyManager,
                _mockDrainModeManager.Object);

            await listener.StartAsync(CancellationToken.None);
            await listener.StopAsync(CancellationToken.None);
            mockSessionReceiver.VerifyAll();
        }

        [Test]
        public async Task SessionIdleTimeoutIgnoredWhenNotUsingSessions()
        {
            var mockReceiver = new Mock<ServiceBusReceiver>();

            var options = new ServiceBusOptions
            {
                ProcessErrorAsync = ExceptionReceivedHandler,
                SessionIdleTimeout = TimeSpan.FromSeconds(5)
            };

            _mockMessagingProvider
                .Setup(p => p.CreateBatchMessageReceiver(It.IsAny<ServiceBusClient>(), _entityPath, It.IsAny<ServiceBusReceiverOptions>()))
                .Returns(mockReceiver.Object);

            mockReceiver
                .Setup(r => r.ReceiveMessagesAsync(options.MaxMessageBatchSize, null, It.IsAny<CancellationToken>()))
                .Returns(async () =>
                {
                    // need to simulate IO otherwise listener loop just spins
                    await Task.Delay(1);
                    return await Task.FromResult<IReadOnlyList<ServiceBusReceivedMessage>>(new List<ServiceBusReceivedMessage>(0));
                });

            var listener = new ServiceBusListener(
                _functionId,
                ServiceBusEntityType.Queue,
                _entityPath,
                false,
                true,
                options.MaxMessageBatchSize,
                _mockExecutor.Object,
                options,
                _connection,
                _mockMessagingProvider.Object,
                _loggerFactory,
                false,
                _mockClientFactory.Object,
                _concurrencyManager,
                _mockDrainModeManager.Object);

            await listener.StartAsync(CancellationToken.None);
            await listener.StopAsync(CancellationToken.None);
            mockReceiver.VerifyAll();
        }

        [Test]
        public void GetMonitor_ReturnsExpectedValue()
        {
            IScaleMonitor scaleMonitor = _listener.GetMonitor();

            Assert.AreEqual(typeof(ServiceBusScaleMonitor), scaleMonitor.GetType());
            Assert.AreEqual(scaleMonitor.Descriptor.Id, $"{_functionId}-ServiceBusTrigger-{_entityPath}".ToLower());

            var scaleMonitor2 = _listener.GetMonitor();

            Assert.AreSame(scaleMonitor, scaleMonitor2);
        }

        [Test]
        public void StopAsync_LogListenerDetails()
        {
            Assert.DoesNotThrow(() => _listener.StopAsync(CancellationToken.None));
            Assert.NotNull(_loggerProvider.GetAllLogMessages()
                .SingleOrDefault(x => x.FormattedMessage.StartsWith("Attempting to stop ServiceBus listener")));
            Assert.NotNull(_loggerProvider.GetAllLogMessages()
                .SingleOrDefault(x => x.FormattedMessage.StartsWith("ServiceBus listener stopped")));
        }

        [Test]
        public void StopAsync_ThrowsIfStopped()
        {
            try
            {
                _listener.Started = false;
                Assert.ThrowsAsync<InvalidOperationException>(() => _listener.StopAsync(CancellationToken.None));
                Assert.NotNull(_loggerProvider.GetAllLogMessages()
                    .SingleOrDefault(x => x.FormattedMessage.StartsWith("Attempting to stop ServiceBus listener")));
                Assert.NotNull(_loggerProvider.GetAllLogMessages()
                    .SingleOrDefault(x => x.FormattedMessage.StartsWith("ServiceBus listener stopped")));
            }
            finally
            {
                _listener.Started = true;
            }
        }

        [Test]
        public void ProcessMessageAsync_LogsWarning_Stopped()
        {
            _listener.Started = false;
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(
                messageId: Guid.NewGuid().ToString(),
                sequenceNumber: 1,
                deliveryCount: 55,
                enqueuedTime: DateTimeOffset.Now,
                lockedUntil: DateTimeOffset.Now);
            var receiver = new Mock<ServiceBusReceiver>().Object;
            var args = new ProcessMessageEventArgs(message, receiver, CancellationToken.None);

            Assert.That(
                async () => await _listener.ProcessMessageAsync(args),
                Throws.InstanceOf<InvalidOperationException>());

            Assert.NotNull(_loggerProvider.GetAllLogMessages()
                .SingleOrDefault(
                    x => x.FormattedMessage.StartsWith("Message received for a listener that is not in a running state. The message will not be delivered to the function, " +
                                                       "and instead will be abandoned. (Listener started = False, Listener disposed = False") && x.Level == LogLevel.Warning));
        }

        [Test]
        public void ProcessMessageAsync_LogsWarning_Disposed()
        {
            _listener.Disposed = true;
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(
                messageId: Guid.NewGuid().ToString(),
                sequenceNumber: 1,
                deliveryCount: 55,
                enqueuedTime: DateTimeOffset.Now,
                lockedUntil: DateTimeOffset.Now);
            var receiver = new Mock<ServiceBusReceiver>().Object;
            var args = new ProcessMessageEventArgs(message, receiver, CancellationToken.None);

            Assert.That(
                async () => await _listener.ProcessMessageAsync(args),
                Throws.InstanceOf<InvalidOperationException>());

            Assert.NotNull(_loggerProvider.GetAllLogMessages()
                .SingleOrDefault(
                    x => x.FormattedMessage.StartsWith("Message received for a listener that is not in a running state. The message will not be delivered to the function, " +
                                                       "and instead will be abandoned. (Listener started = True, Listener disposed = True") && x.Level == LogLevel.Warning));
        }

        [Test]
        public void ProcessMessageAsync_LogsWarning_Stopped_Session()
        {
            _listener.Started = false;
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(
                messageId: Guid.NewGuid().ToString(),
                sessionId: Guid.NewGuid().ToString(),
                sequenceNumber: 1,
                deliveryCount: 55,
                enqueuedTime: DateTimeOffset.Now,
                lockedUntil: DateTimeOffset.Now);
            var receiver = new Mock<ServiceBusSessionReceiver>().Object;
            var args = new ProcessSessionMessageEventArgs(message, receiver, CancellationToken.None);

            Assert.That(
                async () => await _listener.ProcessSessionMessageAsync(args),
                Throws.InstanceOf<InvalidOperationException>());

            Assert.NotNull(_loggerProvider.GetAllLogMessages()
                .SingleOrDefault(
                    x => x.FormattedMessage.StartsWith("Message received for a listener that is not in a running state. The message will not be delivered to the function, " +
                                                       "and instead will be abandoned. (Listener started = False, Listener disposed = False") && x.Level == LogLevel.Warning));
        }

        [Test]
        public void ProcessMessageAsync_LogsWarning_Disposed_Session()
        {
            _listener.Disposed = true;
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(
                messageId: Guid.NewGuid().ToString(),
                sessionId: Guid.NewGuid().ToString(),
                sequenceNumber: 1,
                deliveryCount: 55,
                enqueuedTime: DateTimeOffset.Now,
                lockedUntil: DateTimeOffset.Now);
            var receiver = new Mock<ServiceBusSessionReceiver>().Object;
            var args = new ProcessSessionMessageEventArgs(message, receiver, CancellationToken.None);

            Assert.That(
                async () => await _listener.ProcessSessionMessageAsync(args),
                Throws.InstanceOf<InvalidOperationException>());

            Assert.NotNull(_loggerProvider.GetAllLogMessages()
                .SingleOrDefault(
                    x => x.FormattedMessage.StartsWith("Message received for a listener that is not in a running state. The message will not be delivered to the function, " +
                                                       "and instead will be abandoned. (Listener started = True, Listener disposed = True") && x.Level == LogLevel.Warning));
        }

        private Task ExceptionReceivedHandler(ProcessErrorEventArgs eventArgs)
        {
            return Task.CompletedTask;
        }

        private void SetFunctionCurrentConcurrency(ConcurrencyManager concurrencyManager, string functionId, int concurrency)
        {
            var concurrencyStatus = concurrencyManager.GetStatus(functionId);
            var propertyInfo = typeof(ConcurrencyStatus).GetProperty("CurrentConcurrency", BindingFlags.Instance | BindingFlags.Public);
            propertyInfo.SetValue(concurrencyStatus, concurrency);
        }
    }
}
