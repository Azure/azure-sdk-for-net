// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessor" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventProcessorTests
    {
        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorCreatesDefaultOptionsCases()
        {
            yield return new object[] { new ReadableOptionsMock("consumerGroup", Mock.Of<EventHubClient>(), Mock.Of<PartitionManager>()), "no options" };
            yield return new object[] { new ReadableOptionsMock("consumerGroup", Mock.Of<EventHubClient>(), Mock.Of<PartitionManager>(), null), "null options" };
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConsumerGroup(string consumerGroup)
        {
            Assert.That(() => new EventProcessor(consumerGroup, Mock.Of<EventHubClient>(), Mock.Of<PartitionManager>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheEventHubClient()
        {
            Assert.That(() => new EventProcessor("consumerGroup", null, Mock.Of<PartitionManager>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesThePartitionManager()
        {
            Assert.That(() => new EventProcessor("consumerGroup", Mock.Of<EventHubClient>(), null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(ReadableOptionsMock eventProcessor,
                                                     string constructorDescription)
        {
            var defaultOptions = new EventProcessorOptions();
            EventProcessorOptions options = eventProcessor.Options;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The { constructorDescription } constructor should not have the same options instance.");
            Assert.That(options.InitialEventPosition.IsEquivalentTo(defaultOptions.InitialEventPosition), Is.True, $"The { constructorDescription } constructor should have the correct initial event position.");
            Assert.That(options.MaximumMessageCount, Is.EqualTo(defaultOptions.MaximumMessageCount), $"The { constructorDescription } constructor should have the correct maximum message count.");
            Assert.That(options.MaximumReceiveWaitTime, Is.EqualTo(defaultOptions.MaximumReceiveWaitTime), $"The { constructorDescription } constructor should have the correct maximum receive wait time.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorClonesOptions()
        {
            var options = new EventProcessorOptions
            {
                InitialEventPosition = EventPosition.FromOffset(55),
                MaximumMessageCount = 43,
                MaximumReceiveWaitTime = TimeSpan.FromMinutes(65)
            };

            var eventProcessor = new ReadableOptionsMock("consumerGroup", Mock.Of<EventHubClient>(), Mock.Of<PartitionManager>(), options);
            EventProcessorOptions clonedOptions = eventProcessor.Options;

            Assert.That(clonedOptions, Is.Not.Null, "The constructor should have set the options.");
            Assert.That(clonedOptions, Is.Not.SameAs(options), "The constructor should have cloned the options.");
            Assert.That(clonedOptions.InitialEventPosition, Is.EqualTo(options.InitialEventPosition), "The constructor should have the correct initial event position.");
            Assert.That(clonedOptions.MaximumMessageCount, Is.EqualTo(options.MaximumMessageCount), "The constructor should have the correct maximum message count.");
            Assert.That(clonedOptions.MaximumReceiveWaitTime, Is.EqualTo(options.MaximumReceiveWaitTime), "The constructor should have the correct maximum receive wait time.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorCreatesTheIdentifier()
        {
            var eventProcessor = new EventProcessor("consumerGroup", Mock.Of<EventHubClient>(), Mock.Of<PartitionManager>());

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.Not.Empty);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor.StartAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void StartAsyncValidatesProcessEventsAsync()
        {
            EventProcessor processor = new EventProcessor("consumerGroup", Mock.Of<EventHubClient>(), Mock.Of<PartitionManager>());
            processor.ProcessExceptionAsync = (context, exception) => Task.CompletedTask;

            Assert.That(async () => await processor.StartAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessor.ProcessEventsAsync)));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor.StartAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void StartAsyncValidatesProcessExceptionAsync()
        {
            EventProcessor processor = new EventProcessor("consumerGroup", Mock.Of<EventHubClient>(), Mock.Of<PartitionManager>());
            processor.ProcessEventsAsync = (context, events) => Task.CompletedTask;

            Assert.That(async () => await processor.StartAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessor.ProcessExceptionAsync)));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor.StartAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncStartsTheEventProcessorWhenProcessingHandlerPropertiesAreSet()
        {
            EventProcessor processor = new EventProcessor("consumerGroup", Mock.Of<EventHubClient>(), Mock.Of<PartitionManager>());

            processor.ProcessEventsAsync = (context, events) => Task.CompletedTask;
            processor.ProcessExceptionAsync = (context, exception) => Task.CompletedTask;

            Assert.That(async () => await processor.StartAsync(), Throws.Nothing);

            await processor.StopAsync();
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor" /> properties.
        /// </summary>
        ///
        [Test]
        public async Task HandlerPropertiesCannotBeSetWhenEventProcessorIsRunning()
        {
            EventProcessor processor = new EventProcessor("consumerGroup", Mock.Of<EventHubClient>(), Mock.Of<PartitionManager>());

            processor.ProcessEventsAsync = (context, events) => Task.CompletedTask;
            processor.ProcessExceptionAsync = (context, exception) => Task.CompletedTask;

            await processor.StartAsync();

            Assert.That(() => processor.InitializeProcessingForPartitionAsync = ((context) => Task.CompletedTask), Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessingForPartitionStoppedAsync = ((context, reason) => Task.CompletedTask), Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessEventsAsync = ((context, events) => Task.CompletedTask), Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessExceptionAsync = ((context, exception) => Task.CompletedTask), Throws.InstanceOf<InvalidOperationException>());

            await processor.StopAsync();
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor" /> properties.
        /// </summary>
        ///
        [Test]
        public async Task HandlerPropertiesCanBeSetAfterEventProcessorHasStopped()
        {
            EventProcessor processor = new EventProcessor("consumerGroup", Mock.Of<EventHubClient>(), Mock.Of<PartitionManager>());

            processor.ProcessEventsAsync = (context, events) => Task.CompletedTask;
            processor.ProcessExceptionAsync = (context, exception) => Task.CompletedTask;

            await processor.StartAsync();
            await processor.StopAsync();

            Assert.That(() => processor.InitializeProcessingForPartitionAsync = ((context) => Task.CompletedTask), Throws.Nothing);
            Assert.That(() => processor.ProcessingForPartitionStoppedAsync = ((context, reason) => Task.CompletedTask), Throws.Nothing);
            Assert.That(() => processor.ProcessEventsAsync = ((context, events) => Task.CompletedTask), Throws.Nothing);
            Assert.That(() => processor.ProcessExceptionAsync = ((context, exception) => Task.CompletedTask), Throws.Nothing);
        }

        /// <summary>
        ///   Allows for the options used by the event processor to be exposed for testing purposes.
        /// </summary>
        ///
        public class ReadableOptionsMock : EventProcessor
        {
            public EventProcessorOptions Options =>
                typeof(EventProcessor)
                    .GetProperty(nameof(Options), BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(this) as EventProcessorOptions;

            public ReadableOptionsMock(string consumerGroup,
                                       EventHubClient eventHubClient,
                                       PartitionManager partitionManager) : base(consumerGroup, eventHubClient, partitionManager)
            {
            }

            public ReadableOptionsMock(string consumerGroup,
                                       EventHubClient eventHubClient,
                                       PartitionManager partitionManager,
                                       EventProcessorOptions options) : base(consumerGroup, eventHubClient, partitionManager, options)
            {
            }
        }
    }
}
