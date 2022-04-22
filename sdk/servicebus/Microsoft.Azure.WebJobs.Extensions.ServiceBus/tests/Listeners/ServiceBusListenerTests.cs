// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
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
        private readonly string _testConnection = "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
        private readonly Mock<IConcurrencyThrottleManager> _mockConcurrencyThrottleManager;
        private readonly ServiceBusClient _client;

        public ServiceBusListenerTests()
        {
            _mockExecutor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);

            _client = new ServiceBusClient(_testConnection);
            ServiceBusProcessor processor = _client.CreateProcessor(_entityPath);
            ServiceBusReceiver receiver = _client.CreateReceiver(_entityPath);
            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", _testConnection));

            ServiceBusOptions config = new ServiceBusOptions
            {
                ProcessErrorAsync = ExceptionReceivedHandler
            };
            _mockMessageProcessor = new Mock<MessageProcessor>(MockBehavior.Strict, processor);

            _mockMessagingProvider = new Mock<MessagingProvider>(new OptionsWrapper<ServiceBusOptions>(config));
            _mockClientFactory = new Mock<ServiceBusClientFactory>(configuration, Mock.Of<AzureComponentFactory>(), _mockMessagingProvider.Object, new AzureEventSourceLogForwarder(new NullLoggerFactory()), new OptionsWrapper<ServiceBusOptions>(new ServiceBusOptions()));
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
            var concurrencyManager = new ConcurrencyManager(concurrencyOptions, _loggerFactory, _mockConcurrencyThrottleManager.Object);

            _listener = new ServiceBusListener(
                _functionId,
                ServiceBusEntityType.Queue,
                _entityPath,
                false,
                config.AutoCompleteMessages,
                _mockExecutor.Object,
                config,
                "connection",
                _mockMessagingProvider.Object,
                _loggerFactory,
                false,
                _mockClientFactory.Object,
                concurrencyManager);
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
            Assert.ThrowsAsync<InvalidOperationException>(() => _listener.StopAsync(CancellationToken.None));
            Assert.NotNull(_loggerProvider.GetAllLogMessages().SingleOrDefault(x => x.FormattedMessage.StartsWith("ServiceBus listener stopped")));
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
