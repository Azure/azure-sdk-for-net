// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebJobs.ServiceBus.Triggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Azure;
using Azure.Messaging.ServiceBus.Tests;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.ServiceBus.Tests;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Host.Scale;
using System;
using System.Linq;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Bindings
{
    public class ServiceBusTriggerAttributeBindingProviderTests
    {
        private readonly ServiceBusTriggerAttributeBindingProvider _provider;
        private readonly string _testConnection = "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=";
        private readonly ILoggerFactory _loggerFactory;
        private readonly TestLoggerProvider _loggerProvider;

        public ServiceBusTriggerAttributeBindingProviderTests()
        {
            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>(Constants.DefaultConnectionStringName, "defaultConnection"));

            Mock<INameResolver> mockResolver = new Mock<INameResolver>(MockBehavior.Strict);

            ServiceBusOptions options = new ServiceBusOptions();

            var loggerFactory = new LoggerFactory();
            var concurrencyOptions = new OptionsWrapper<ConcurrencyOptions>(new ConcurrencyOptions());
            var mockConcurrencyThrottleManager = new Mock<IConcurrencyThrottleManager>(MockBehavior.Strict);
            var concurrencyManager = new ConcurrencyManager(concurrencyOptions, loggerFactory, mockConcurrencyThrottleManager.Object);

            Mock<IConverterManager> convertManager = new Mock<IConverterManager>(MockBehavior.Default);
            var provider = new MessagingProvider(new OptionsWrapper<ServiceBusOptions>(options));
            var factory = new ServiceBusClientFactory(configuration, new Mock<AzureComponentFactory>().Object, provider, new AzureEventSourceLogForwarder(new NullLoggerFactory()), new OptionsWrapper<ServiceBusOptions>(options));
            _provider = new ServiceBusTriggerAttributeBindingProvider(mockResolver.Object, options, provider, NullLoggerFactory.Instance, convertManager.Object, factory, concurrencyManager);

            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);
        }

        [Test]
        public async Task TryCreateAsync_AccountOverride_OverrideIsApplied()
        {
            ParameterInfo parameter = GetType().GetMethod("TestJob_AccountOverride", BindingFlags.NonPublic | BindingFlags.Static).GetParameters()[0];
            TriggerBindingProviderContext context = new TriggerBindingProviderContext(parameter, CancellationToken.None);

            ITriggerBinding binding = await _provider.TryCreateAsync(context);

            Assert.NotNull(binding);
        }

        [Test]
        public async Task TryCreateAsync_DefaultAccount()
        {
            ParameterInfo parameter = GetType().GetMethod("TestJob", BindingFlags.NonPublic | BindingFlags.Static).GetParameters()[0];
            TriggerBindingProviderContext context = new TriggerBindingProviderContext(parameter, CancellationToken.None);

            ITriggerBinding binding = await _provider.TryCreateAsync(context);

            Assert.NotNull(binding);
        }

        [Test]
        public async Task GetAutoCompleteMessagesOptionToUse_AutoCompleteDisabledOnTrigger()
        {
            var listenerContext = new ListenerFactoryContext(
                new Mock<FunctionDescriptor>().Object,
                new Mock<ITriggeredFunctionExecutor>().Object,
                CancellationToken.None);
            var parameters = new object[] { listenerContext };
            var entityPath = "autocompleteMessagesDisabled";

            var client = new ServiceBusClient(_testConnection);
            ServiceBusProcessor processor = client.CreateProcessor(entityPath);
            ServiceBusReceiver receiver = client.CreateReceiver(entityPath);
            var configuration = ConfigurationUtilities.CreateConfiguration(new KeyValuePair<string, string>("connection", _testConnection));

            ServiceBusOptions config = new ServiceBusOptions();
            var mockMessageProcessor = new Mock<MessageProcessor>(MockBehavior.Strict, processor);

            var mockMessagingProvider = new Mock<MessagingProvider>(new OptionsWrapper<ServiceBusOptions>(config));
            var mockClientFactory = new Mock<ServiceBusClientFactory>(configuration, Mock.Of<AzureComponentFactory>(), mockMessagingProvider.Object, new AzureEventSourceLogForwarder(new NullLoggerFactory()), new OptionsWrapper<ServiceBusOptions>(new ServiceBusOptions()));
            mockMessagingProvider
                .Setup(p => p.CreateMessageProcessor(It.IsAny<ServiceBusClient>(), entityPath, It.IsAny<ServiceBusProcessorOptions>()))
                .Returns(mockMessageProcessor.Object);

            var parameter = GetType().GetMethod("TestAutoCompleteMessagesDisbledOnTrigger", BindingFlags.NonPublic | BindingFlags.Static).GetParameters()[0];
            var context = new TriggerBindingProviderContext(parameter, CancellationToken.None);
            var binding = await _provider.TryCreateAsync(context);
            var createListenerTask = binding.GetType().GetMethod("CreateListenerAsync");
            var listener = await (Task<IListener>)createListenerTask.Invoke(binding, parameters);
            var listenerOptions = (ServiceBusOptions)listener.GetType().GetField("_serviceBusOptions", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(listener);
            var autoCompleteMessagesFlagSentToListener = (bool)listener.GetType().GetField("_autoCompleteMessagesOptionEvaluatedValue", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(listener);

            Assert.NotNull(listenerOptions);
            Assert.True(listenerOptions.AutoCompleteMessages);
            Assert.False(autoCompleteMessagesFlagSentToListener);
        }

        [Test]
        public void LogExceptionReceivedEvent_NonTransientEvent_LoggedAsError()
        {
            _loggerProvider.ClearAllLogMessages();
            var ex = new ServiceBusException(isTransient: false, message: "message");
            Assert.False(ex.IsTransient);
            ProcessErrorEventArgs e = new ProcessErrorEventArgs(ex, ServiceBusErrorSource.Abandon, "TestEndpoint", "TestEntity", CancellationToken.None);
            ServiceBusTriggerAttributeBindingProvider.LogExceptionReceivedEvent(e, "TestFunction", _loggerFactory);

            var expectedMessage = $"Message processing error (Action=Abandon, EntityPath=TestEntity, Endpoint=TestEndpoint)";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual(LogLevel.Error, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage, logMessage.FormattedMessage);
            Assert.True(logMessage.Category.Contains("TestFunction"));
        }

        [Test]
        public void LogExceptionReceivedEvent_TransientEvent_LoggedAsInformation()
        {
            _loggerProvider.ClearAllLogMessages();
            var ex = new ServiceBusException(message: "message", isTransient: true);
            Assert.True(ex.IsTransient);
            ProcessErrorEventArgs e = new ProcessErrorEventArgs(ex, ServiceBusErrorSource.Receive, "TestEndpoint", "TestEntity", CancellationToken.None);
            ServiceBusTriggerAttributeBindingProvider.LogExceptionReceivedEvent(e, "TestFunction", _loggerFactory);

            var expectedMessage = $"Message processing error (Action=Receive, EntityPath=TestEntity, Endpoint=TestEndpoint)";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual(LogLevel.Information, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage, logMessage.FormattedMessage);
            Assert.True(logMessage.Category.Contains("TestFunction"));
        }

        [Test]
        public void LogExceptionReceivedEvent_NonMessagingException_LoggedAsError()
        {
            _loggerProvider.ClearAllLogMessages();
            var ex = new MissingMethodException("What method??");
            ProcessErrorEventArgs e = new ProcessErrorEventArgs(ex, ServiceBusErrorSource.Complete, "TestEndpoint", "TestEntity", CancellationToken.None);
            ServiceBusTriggerAttributeBindingProvider.LogExceptionReceivedEvent(e, "TestFunction", _loggerFactory);

            var expectedMessage = $"Message processing error (Action=Complete, EntityPath=TestEntity, Endpoint=TestEndpoint)";
            var logMessage = _loggerProvider.GetAllLogMessages().Single();
            Assert.AreEqual(LogLevel.Error, logMessage.Level);
            Assert.AreSame(ex, logMessage.Exception);
            Assert.AreEqual(expectedMessage, logMessage.FormattedMessage);
            Assert.True(logMessage.Category.Contains("TestFunction"));
        }

        internal static void TestJob_AccountOverride(
            [ServiceBusTriggerAttribute("test"),
             ServiceBusAccount(Constants.DefaultConnectionStringName)]
            ServiceBusMessage message)
        {
            message = new ServiceBusMessage();
        }

        internal static void TestJob(
            [ServiceBusTriggerAttribute("test", Connection = Constants.DefaultConnectionStringName)]
            ServiceBusMessage message)
        {
            message = new ServiceBusMessage();
        }

        internal static void TestAutoCompleteMessagesDisbledOnTrigger(
            [ServiceBusTriggerAttribute("autocompleteMessagesDisabled", AutoCompleteMessages = false),
             ServiceBusAccount(Constants.DefaultConnectionStringName)] ServiceBusMessage message)
        {
            message = new ServiceBusMessage();
        }
    }
}
