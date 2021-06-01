// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.Messaging.EventHubs.Consumer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests defining the snippets used across the Event Hubs
    ///   samples.
    /// </summary>
    ///
    [TestFixture]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class SamplesCommonTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ProducerBasicConfiguration()
        {
            #region Snippet:EventHubs_SamplesCommon_ProducerBasicConfig

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";

            #endregion

            Assert.That(connectionString, Is.Not.Null);
            Assert.That(eventHubName, Is.Not.Null);
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConsumerBasicConfiguration()
        {
            #region Snippet:EventHubs_SamplesCommon_ConsumerBasicConfig

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            #endregion

            Assert.That(connectionString, Is.Not.Null);
            Assert.That(eventHubName, Is.Not.Null);
            Assert.That(consumerGroup, Is.Not.Null);
        }
    }
}
