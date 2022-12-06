// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = "fake";
#endif
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

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

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var  fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var  eventHubName = "fake";
            var  credential = EventHubsTestEnvironment.Instance.Credential;
#endif
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);
            var consumer = new EventHubConsumerClient(consumerGroup, fullyQualifiedNamespace, eventHubName, credential);

            #endregion
        }
    }
}
