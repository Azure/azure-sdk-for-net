// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
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
            var mockClient = Mock.Of<EventHubClient>();
            Func<PartitionContext, BasePartitionProcessor> mockFactory = context => Mock.Of<BasePartitionProcessor>();
            var mockPartitionManager = Mock.Of<PartitionManager>();

            yield return new object[] { new ReadableOptionsMock(EventHubConsumer.DefaultConsumerGroupName, mockClient, mockFactory, mockPartitionManager), "no options" };
            yield return new object[] { new ReadableOptionsMock(EventHubConsumer.DefaultConsumerGroupName, mockClient, mockFactory, mockPartitionManager, null), "null options" };
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor{T}" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConsumerGroup(string consumerGroup)
        {
            var mockClient = Mock.Of<EventHubClient>();
            Func<PartitionContext, BasePartitionProcessor> mockFactory = context => Mock.Of<BasePartitionProcessor>();
            var mockPartitionManager = Mock.Of<PartitionManager>();

            Assert.That(() => new EventProcessor<BasePartitionProcessor>(consumerGroup, mockClient, mockFactory, mockPartitionManager), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor{T}" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheEventHubClient()
        {
            Func<PartitionContext, BasePartitionProcessor> mockFactory = context => Mock.Of<BasePartitionProcessor>();
            var mockPartitionManager = Mock.Of<PartitionManager>();

            Assert.That(() => new EventProcessor<BasePartitionProcessor>(EventHubConsumer.DefaultConsumerGroupName, null, mockFactory, mockPartitionManager), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor{T}" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesThePartitionProcessorFactory()
        {
            var mockClient = Mock.Of<EventHubClient>();
            var mockPartitionManager = Mock.Of<PartitionManager>();

            Assert.That(() => new EventProcessor<BasePartitionProcessor>(EventHubConsumer.DefaultConsumerGroupName, mockClient, null, mockPartitionManager), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor{T}" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesThePartitionManager()
        {
            var mockClient = Mock.Of<EventHubClient>();
            Func<PartitionContext, BasePartitionProcessor> mockFactory = context => Mock.Of<BasePartitionProcessor>();

            Assert.That(() => new EventProcessor<BasePartitionProcessor>(EventHubConsumer.DefaultConsumerGroupName, mockClient, mockFactory, null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor{T}" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(ReadableOptionsMock eventProcessor,
                                                     string constructorDescription)
        {
            var defaultOptions = new EventProcessorOptions();
            var options = eventProcessor.Options;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The { constructorDescription } constructor should not have the same options instance.");
            Assert.That(options.InitialEventPosition.IsEquivalentTo(defaultOptions.InitialEventPosition), Is.True, $"The { constructorDescription } constructor should have the correct initial event position.");
            Assert.That(options.MaximumMessageCount, Is.EqualTo(defaultOptions.MaximumMessageCount), $"The { constructorDescription } constructor should have the correct maximum message count.");
            Assert.That(options.MaximumReceiveWaitTime, Is.EqualTo(defaultOptions.MaximumReceiveWaitTime), $"The { constructorDescription } constructor should have the correct maximum receive wait time.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor{T}" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorClonesOptions()
        {
            var mockClient = Mock.Of<EventHubClient>();
            Func<PartitionContext, BasePartitionProcessor> mockFactory = context => Mock.Of<BasePartitionProcessor>();
            var mockPartitionManager = Mock.Of<PartitionManager>();

            var options = new EventProcessorOptions
            {
                InitialEventPosition = EventPosition.FromOffset(55),
                MaximumMessageCount = 43,
                MaximumReceiveWaitTime = TimeSpan.FromMinutes(65)
            };

            var eventProcessor = new ReadableOptionsMock(EventHubConsumer.DefaultConsumerGroupName, mockClient, mockFactory, mockPartitionManager, options);
            var clonedOptions = eventProcessor.Options;

            Assert.That(clonedOptions, Is.Not.Null, "The constructor should have set the options.");
            Assert.That(clonedOptions, Is.Not.SameAs(options), "The constructor should have cloned the options.");
            Assert.That(clonedOptions.InitialEventPosition, Is.EqualTo(options.InitialEventPosition), "The constructor should have the correct initial event position.");
            Assert.That(clonedOptions.MaximumMessageCount, Is.EqualTo(options.MaximumMessageCount), "The constructor should have the correct maximum message count.");
            Assert.That(clonedOptions.MaximumReceiveWaitTime, Is.EqualTo(options.MaximumReceiveWaitTime), "The constructor should have the correct maximum receive wait time.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessor{T}" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorCreatesTheIdentifier()
        {
            var mockClient = Mock.Of<EventHubClient>();
            Func<PartitionContext, BasePartitionProcessor> mockFactory = context => Mock.Of<BasePartitionProcessor>();
            var mockPartitionManager = Mock.Of<PartitionManager>();

            var eventProcessor = new EventProcessor<BasePartitionProcessor>(EventHubConsumer.DefaultConsumerGroupName, mockClient, mockFactory, mockPartitionManager);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.Not.Empty);
        }

        /// <summary>
        ///   Allows for the options used by the event processor to be exposed for testing purposes.
        /// </summary>
        ///
        public class ReadableOptionsMock : EventProcessor<BasePartitionProcessor>
        {
            public EventProcessorOptions Options =>
                typeof(EventProcessor<BasePartitionProcessor>)
                    .GetProperty(nameof(Options), BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(this) as EventProcessorOptions;

            public ReadableOptionsMock(string consumerGroup,
                                       EventHubClient eventHubClient,
                                       Func<PartitionContext, BasePartitionProcessor> partitionProcessorFactory,
                                       PartitionManager partitionManager) : base(consumerGroup, eventHubClient, partitionProcessorFactory, partitionManager)
            {
            }

            public ReadableOptionsMock(string consumerGroup,
                                       EventHubClient eventHubClient,
                                       Func<PartitionContext, BasePartitionProcessor> partitionProcessorFactory,
                                       PartitionManager partitionManager,
                                       EventProcessorOptions options) : base(consumerGroup, eventHubClient, partitionProcessorFactory, partitionManager, options)
            {
            }
        }
    }
}
