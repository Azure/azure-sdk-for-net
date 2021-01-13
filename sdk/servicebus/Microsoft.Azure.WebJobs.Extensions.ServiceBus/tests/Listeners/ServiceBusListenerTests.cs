// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using static Microsoft.Azure.ServiceBus.Message;

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

            MessageHandlerOptions messageOptions = new MessageHandlerOptions(ExceptionReceivedHandler);
            MessageReceiver messageReceiver = new MessageReceiver(_testConnection, _entityPath);
            _mockMessageProcessor = new Mock<MessageProcessor>(MockBehavior.Strict, messageReceiver, messageOptions);

            ServiceBusOptions config = new ServiceBusOptions
            {
                MessageHandlerOptions = messageOptions
            };
            _mockMessagingProvider = new Mock<MessagingProvider>(MockBehavior.Strict, new OptionsWrapper<ServiceBusOptions>(config));

            _mockMessagingProvider
                .Setup(p => p.CreateMessageProcessor(_entityPath, _testConnection))
                .Returns(_mockMessageProcessor.Object);

            _mockMessagingProvider
                    .Setup(p => p.CreateMessageReceiver(_entityPath, _testConnection))
                    .Returns(messageReceiver);

            Mock<ServiceBusAccount> mockServiceBusAccount = new Mock<ServiceBusAccount>(MockBehavior.Strict);
            mockServiceBusAccount.Setup(a => a.ConnectionString).Returns(_testConnection);

            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            _listener = new ServiceBusListener(_functionId, EntityType.Queue, _entityPath, false, _mockExecutor.Object, config, mockServiceBusAccount.Object,
                                _mockMessagingProvider.Object, _loggerFactory, false);
        }

        [Fact]
        public async Task ProcessMessageAsync_Success()
        {
            var message = new CustomMessage();
            var systemProperties = new Message.SystemPropertiesCollection();
            typeof(Message.SystemPropertiesCollection).GetProperty("SequenceNumber").SetValue(systemProperties, 1);
            typeof(Message.SystemPropertiesCollection).GetProperty("DeliveryCount").SetValue(systemProperties, 55);
            typeof(Message.SystemPropertiesCollection).GetProperty("EnqueuedTimeUtc").SetValue(systemProperties, DateTime.Now);
            typeof(Message.SystemPropertiesCollection).GetProperty("LockedUntilUtc").SetValue(systemProperties, DateTime.Now);
            typeof(Message).GetProperty("SystemProperties").SetValue(message, systemProperties);

            message.MessageId = Guid.NewGuid().ToString();
            _mockMessageProcessor.Setup(p => p.BeginProcessingMessageAsync(message, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            FunctionResult result = new FunctionResult(true);
            _mockExecutor.Setup(p => p.TryExecuteAsync(It.Is<TriggeredFunctionData>(q => ((ServiceBusTriggerInput)q.TriggerValue).Messages[0] == message), It.IsAny<CancellationToken>())).ReturnsAsync(result);

            _mockMessageProcessor.Setup(p => p.CompleteProcessingMessageAsync(message, result, It.IsAny<CancellationToken>())).Returns(Task.FromResult(0));

            await _listener.ProcessMessageAsync(message, CancellationToken.None);

            _mockMessageProcessor.VerifyAll();
            _mockExecutor.VerifyAll();
            _mockMessageProcessor.VerifyAll();
        }

        [Fact]
        public async Task ProcessMessageAsync_BeginProcessingReturnsFalse_MessageNotProcessed()
        {
            var message = new CustomMessage();
            message.MessageId = Guid.NewGuid().ToString();
            _mockMessageProcessor.Setup(p => p.BeginProcessingMessageAsync(message, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            await _listener.ProcessMessageAsync(message, CancellationToken.None);

            _mockMessageProcessor.VerifyAll();
        }

        [Fact]
        public void GetMonitor_ReturnsExpectedValue()
        {
            IScaleMonitor scaleMonitor = _listener.GetMonitor();

            Assert.Equal(typeof(ServiceBusScaleMonitor), scaleMonitor.GetType());
            Assert.Equal(scaleMonitor.Descriptor.Id, $"{_functionId}-ServiceBusTrigger-{_entityPath}".ToLower());

            var scaleMonitor2 = _listener.GetMonitor();

            Assert.Same(scaleMonitor, scaleMonitor2);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs eventArgs)
        {
            return Task.CompletedTask;
        }
    }

    // Mock calls ToString() for Mesage. This ckass fixes bug in azure-service-bus-dotnet.
    // https://github.com/Azure/azure-service-bus-dotnet/blob/dev/src/Microsoft.Azure.ServiceBus/Message.cs#L291
#pragma warning disable SA1402 // File may only contain a single type
    internal class CustomMessage : Message
#pragma warning restore SA1402 // File may only contain a single type
    {
        public override string ToString()
        {
            return MessageId;
        }
    }
}
