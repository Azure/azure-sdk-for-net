// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Consumer;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests defining the snippets used across the Event Hubs
    ///   samples.
    /// </summary>
    ///
    [TestFixture]
    public class SamplesCommonTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConsumerBasicConfiguration()
        {
            #region Snippet:EventHubs_SamplesCommon_ConsumerBasicConfig

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            var credential = new DefaultAzureCredential();

            #endregion

            Assert.That(fullyQualifiedNamespace, Is.Not.Null);
            Assert.That(eventHubName, Is.Not.Null);
            Assert.That(credential, Is.Not.Null);
            Assert.That(consumerGroup, Is.Not.Null);
        }
    }
}
