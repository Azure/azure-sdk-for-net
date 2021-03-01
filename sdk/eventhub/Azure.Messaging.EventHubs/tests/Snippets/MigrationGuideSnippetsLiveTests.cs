// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   migration guides.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class MigrationGuideSnippetsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void CreateWithConnectionString()
        {
            #region Snippet:EventHubs_Migrate_CreateWithConnectionString

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fake";

            var producer = new EventHubProducerClient(connectionString, eventHubName);
            var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void CreateWithDefaultAzureCredential()
        {
            #region Snippet:EventHubs_Migrate_CreateWithDefaultAzureCredential

            TokenCredential credential = new DefaultAzureCredential();

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            /*@@*/ eventHubName = "fake";
            /*@@*/ credential = EventHubsTestEnvironment.Instance.Credential;

            var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);
            var consumer = new EventHubConsumerClient(consumerGroup, fullyQualifiedNamespace, eventHubName, credential);

            #endregion
        }
    }
}
