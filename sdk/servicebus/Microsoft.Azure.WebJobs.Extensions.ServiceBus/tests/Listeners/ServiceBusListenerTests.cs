// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Extensions.Logging;
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
        private readonly Mock<MessageProcessor> _mockMessageProcessor;
        private readonly TestLoggerProvider _loggerProvider;
        private readonly LoggerFactory _loggerFactory;
        private readonly string _functionId = "test-functionid";
        private readonly string _entityPath = "test-entity-path";
        private readonly string _testConnection = "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";

        public ServiceBusListenerTests()
        {
            _mockExecutor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);

            var client = new ServiceBusClient(_testConnection);
            ServiceBusProcessor processor = client.CreateProcessor(_entityPath);
            ServiceBusReceiver receiver = client.CreateReceiver(_entityPath);

            ServiceBusOptions config = new ServiceBusOptions
            {
                ExceptionHandler = ExceptionReceivedHandler
            };
            _mockMessageProcessor = new Mock<MessageProcessor>(MockBehavior.Strict, processor);

            _mockMessagingProvider = new Mock<MessagingProvider>(MockBehavior.Strict, new OptionsWrapper<ServiceBusOptions>(config));

            _mockMessagingProvider
                .Setup(p => p.CreateMessageProcessor(_entityPath, _testConnection))
                .Returns(_mockMessageProcessor.Object);

            _mockMessagingProvider
                    .Setup(p => p.CreateBatchMessageReceiver(_entityPath, _testConnection))
                    .Returns(receiver);

            Mock<ServiceBusAccount> mockServiceBusAccount = new Mock<ServiceBusAccount>(MockBehavior.Strict);
            mockServiceBusAccount.Setup(a => a.ConnectionString).Returns(_testConnection);

            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            _listener = new ServiceBusListener(_functionId, EntityType.Queue, _entityPath, false, _mockExecutor.Object, config, mockServiceBusAccount.Object,
                                _mockMessagingProvider.Object, _loggerFactory, false);
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

        private Task ExceptionReceivedHandler(ProcessErrorEventArgs eventArgs)
        {
            return Task.CompletedTask;
        }
    }
}
