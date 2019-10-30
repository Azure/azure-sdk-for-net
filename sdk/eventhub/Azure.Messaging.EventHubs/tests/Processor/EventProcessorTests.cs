// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Processor;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessorClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventProcessorTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorExpandedArgumentInvalidCases()
        {
            TokenCredential credential = Mock.Of<TokenCredential>();

            yield return new object[] { null, "fakePath", credential };
            yield return new object[] { "", "fakePath", credential };
            yield return new object[] { "FakeNamespace", null, credential };
            yield return new object[] { "FakNamespace", "", credential };
            yield return new object[] { "FakeNamespace", "FakePath", null };
        }

        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> MultipleConstructorsCases()
        {
            yield return new object[] { new ReadableOptionsMock("connectionString", "consumerGroup", Mock.Of<PartitionManager>()), "simple connection string" };
            yield return new object[] { new ReadableOptionsMock("connectionString", "eventHubName", "consumerGroup", Mock.Of<PartitionManager>()), "connection string with event hub name" };
            yield return new object[] { new ReadableOptionsMock("namespace", "eventHubName", Mock.Of<TokenCredential>(), "consumerGroup", Mock.Of<PartitionManager>()), "expanded arguments" };
        }

        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorClonesOptionsCases()
        {
            var options = new EventProcessorClientOptions
            {
                MaximumMessageCount = 25,
                MaximumReceiveWaitTime = TimeSpan.FromMilliseconds(427)
            };

            yield return new object[] { new ReadableOptionsMock("connectionString", "consumerGroup", Mock.Of<PartitionManager>(), options), options, "simple connection string" };
            yield return new object[] { new ReadableOptionsMock("connectionString", "eventHubName", "consumerGroup", Mock.Of<PartitionManager>(), options), options, "connection string with event hub name" };
            yield return new object[] { new ReadableOptionsMock("namespace", "eventHubName", Mock.Of<TokenCredential>(), "consumerGroup", Mock.Of<PartitionManager>(), options), options, "expanded arguments" };
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresConnectionString(string connectionString)
        {
            // Seems ExactTypeConstraints is not re-entrant.
            ExactTypeConstraint TypeConstraint() => connectionString is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            Assert.That(() => new EventProcessorClient(connectionString, "consumerGroup", Mock.Of<PartitionManager>()), TypeConstraint(), "The constructor with no event hub should perform validation.");
            Assert.That(() => new EventProcessorClient(connectionString, "eventHubName", "consumerGroup", Mock.Of<PartitionManager>()), TypeConstraint(), "The constructor with the event hub should perform validation.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresConsumerGroup(string consumerGroup)
        {
            // Seems ExactTypeConstraints is not re-entrant.
            ExactTypeConstraint TypeConstraint() => consumerGroup is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            Assert.That(() => new EventProcessorClient("connectionString", consumerGroup, Mock.Of<PartitionManager>()), TypeConstraint(), "The constructor with connection string and no event hub should perform validation.");
            Assert.That(() => new EventProcessorClient("connectionString", "eventHubName", consumerGroup, Mock.Of<PartitionManager>()), TypeConstraint(), "The constructor with connection string and event hub should perform validation.");
            Assert.That(() => new EventProcessorClient("namespace", "eventHubName", Mock.Of<TokenCredential>(), consumerGroup, Mock.Of<PartitionManager>()), TypeConstraint(), "The constructor with expanded arguments should perform validation.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresPartitionManager()
        {
            Assert.That(() => new EventProcessorClient("connectionString", "consumerGroup", null), Throws.InstanceOf<ArgumentNullException>(), "The constructor with connection string and no event hub should perform validation.");
            Assert.That(() => new EventProcessorClient("connectionString", "eventHubName", "consumerGroup", null), Throws.InstanceOf<ArgumentNullException>(), "The constructor with connection string and event hub should perform validation.");
            Assert.That(() => new EventProcessorClient("namespace", "eventHubName", Mock.Of<TokenCredential>(), "consumerGroup", null), Throws.InstanceOf<ArgumentNullException>(), "The constructor with expanded arguments should perform validation.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorExpandedArgumentInvalidCases))]
        public void ConstructorRequiresExpandedArguments(string fullyQualifiedNamespace,
                                                         string eventHubName,
                                                         TokenCredential credential)
        {
            Assert.That(() => new EventHubClient(fullyQualifiedNamespace, eventHubName, credential), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(MultipleConstructorsCases))]
        public void ConstructorCreatesDefaultOptions(ReadableOptionsMock eventProcessor,
                                                     string constructorDescription)
        {
            var defaultOptions = new EventProcessorClientOptions();
            EventProcessorClientOptions options = eventProcessor.Options;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The { constructorDescription } constructor should not have the same options instance.");
            Assert.That(options.MaximumMessageCount, Is.EqualTo(defaultOptions.MaximumMessageCount), $"The { constructorDescription } constructor should have the correct maximum message count.");
            Assert.That(options.MaximumReceiveWaitTime, Is.EqualTo(defaultOptions.MaximumReceiveWaitTime), $"The { constructorDescription } constructor should have the correct maximum receive wait time.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorClonesOptionsCases))]
        public void ConstructorClonesOptions(ReadableOptionsMock eventProcessor,
                                             EventProcessorClientOptions constructorOptions,
                                             string constructorDescription)
        {
            var options = eventProcessor.Options;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set the options.");
            Assert.That(options, Is.Not.SameAs(constructorOptions), $"The { constructorDescription } constructor should have cloned the options.");
            Assert.That(options.MaximumMessageCount, Is.EqualTo(constructorOptions.MaximumMessageCount), $"The { constructorDescription } constructor should have the correct maximum message count.");
            Assert.That(options.MaximumReceiveWaitTime, Is.EqualTo(constructorOptions.MaximumReceiveWaitTime), $"The constructor { constructorDescription } should have the correct maximum receive wait time.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(MultipleConstructorsCases))]
        public void ConstructorCreatesTheIdentifier(EventProcessorClient eventProcessor,
                                                    string constructorDescription)
        {
            Assert.That(eventProcessor.Identifier, Is.Not.Null.And.Not.Empty, $"The { constructorDescription } constructor should have set the identifier.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void StartAsyncValidatesProcessEventsAsync()
        {
            EventProcessorClient processor = new EventProcessorClient("connectionString", "consumerGroup", Mock.Of<PartitionManager>());
            processor.ProcessExceptionAsync = errorContext => Task.CompletedTask;

            Assert.That(async () => await processor.StartAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessEventAsync)));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void StartAsyncValidatesProcessExceptionAsync()
        {
            EventProcessorClient processor = new EventProcessorClient("connectionString", "consumerGroup", Mock.Of<PartitionManager>());
            processor.ProcessEventAsync = partitionEvent => Task.CompletedTask;

            Assert.That(async () => await processor.StartAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessExceptionAsync)));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncStartsTheEventProcessorWhenProcessingHandlerPropertiesAreSet()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            EventProcessorClient processor = new EventProcessorClient(fakeConnection, "consumerGroup", Mock.Of<PartitionManager>());

            processor.ProcessEventAsync = partitionEvent => Task.CompletedTask;
            processor.ProcessExceptionAsync = errorContext => Task.CompletedTask;

            Assert.That(async () => await processor.StartAsync(), Throws.Nothing);

            await processor.StopAsync();
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public async Task HandlerPropertiesCannotBeSetWhenEventProcessorIsRunning()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            EventProcessorClient processor = new EventProcessorClient(fakeConnection, "consumerGroup", Mock.Of<PartitionManager>());

            processor.ProcessEventAsync = partitionEvent => Task.CompletedTask;
            processor.ProcessExceptionAsync = errorContext => Task.CompletedTask;

            await processor.StartAsync();

            Assert.That(() => processor.InitializeProcessingForPartitionAsync = initContext => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessingForPartitionStoppedAsync = stopContext => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessEventAsync = partitionEvent => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessExceptionAsync = errorContext => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());

            await processor.StopAsync();
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public async Task HandlerPropertiesCanBeSetAfterEventProcessorHasStopped()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            EventProcessorClient processor = new EventProcessorClient(fakeConnection, "consumerGroup", Mock.Of<PartitionManager>());

            processor.ProcessEventAsync = partitionEvent => Task.CompletedTask;
            processor.ProcessExceptionAsync = errorContext => Task.CompletedTask;

            await processor.StartAsync();
            await processor.StopAsync();

            Assert.That(() => processor.InitializeProcessingForPartitionAsync = initContext => Task.CompletedTask, Throws.Nothing);
            Assert.That(() => processor.ProcessingForPartitionStoppedAsync = stopContext => Task.CompletedTask, Throws.Nothing);
            Assert.That(() => processor.ProcessEventAsync = partitionEvent => Task.CompletedTask, Throws.Nothing);
            Assert.That(() => processor.ProcessExceptionAsync = errorContext => Task.CompletedTask, Throws.Nothing);
        }

        /// <summary>
        ///   Allows for the options used by the event processor to be exposed for testing purposes.
        /// </summary>
        ///
        public class ReadableOptionsMock : EventProcessorClient
        {
            public EventProcessorClientOptions Options =>
                typeof(EventProcessorClient)
                    .GetProperty(nameof(Options), BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(this) as EventProcessorClientOptions;

            public ReadableOptionsMock(string connectionString,
                                       string consumerGroup,
                                       PartitionManager partitionManager,
                                       EventProcessorClientOptions options = default) : base(connectionString, consumerGroup, partitionManager, options)
            {
            }

            public ReadableOptionsMock(string connectionString,
                                       string eventHubName,
                                       string consumerGroup,
                                       PartitionManager partitionManager,
                                       EventProcessorClientOptions options = default) : base(connectionString, eventHubName, consumerGroup, partitionManager, options)
            {
            }

            public ReadableOptionsMock(string fullyQualifiedNamespace,
                                       string eventHubName,
                                       TokenCredential credential,
                                       string consumerGroup,
                                       PartitionManager partitionManager,
                                       EventProcessorClientOptions options = default) : base(fullyQualifiedNamespace, eventHubName, credential, consumerGroup, partitionManager, options)
            {
            }
        }
    }
}
