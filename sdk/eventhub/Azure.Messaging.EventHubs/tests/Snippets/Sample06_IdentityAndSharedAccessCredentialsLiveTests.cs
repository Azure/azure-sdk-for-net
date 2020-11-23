// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample06_IdentityAndSharedAccessCredentials sample.
    /// </summary>
    ///
    [TestFixture]
    [Ignore("Debugging Potential Hang")]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample06_IdentityAndSharedAccessCredentialsLiveTests
    {
        /// <summary>The active Event Hub resource scope for the test fixture.</summary>
        private EventHubScope _scope;

        /// <summary>
        ///   Performs the tasks needed to initialize the test fixture.  This
        ///   method runs once for the entire fixture, prior to running any tests.
        /// </summary>
        ///
        [OneTimeSetUp]
        public async Task FixtureSetUp()
        {
            _scope = await EventHubScope.CreateAsync(2);
        }

        /// <summary>
        ///   Performs the tasks needed to cleanup the test fixture after all
        ///   tests have run.  This method runs once for the entire fixture.
        /// </summary>
        ///
        [OneTimeTearDown]
        public async Task FixtureTearDown()
        {
            await _scope.DisposeAsync();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task DefaultAzureCredential()
        {
            #region Snippet:EventHubs_Sample06_DefaultAzureCredential

            TokenCredential credential = new DefaultAzureCredential();

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ credential = EventHubsTestEnvironment.Instance.Credential;

            var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();

                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                await producer.SendAsync(eventBatch);
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task SharedAccessSignature()
        {
            #region Snippet:EventHubs_Sample06_SharedAccessSignature

            TokenCredential credential = new DefaultAzureCredential();

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ credential = EventHubsTestEnvironment.Instance.Credential;

            var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();

                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                await producer.SendAsync(eventBatch);
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task SharedAccessKey()
        {
            #region Snippet:EventHubs_Sample06_SharedAccessKey

            TokenCredential credential = new DefaultAzureCredential();

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            /*@@*/ eventHubName = _scope.EventHubName;
            /*@@*/ credential = EventHubsTestEnvironment.Instance.Credential;

            var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();

                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                await producer.SendAsync(eventBatch);
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConnectionStringParse()
        {
            #region Snippet:EventHubs_Sample06_ConnectionStringParse

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _scope.EventHubName;

            EventHubsConnectionStringProperties properties =
                EventHubsConnectionStringProperties.Parse(connectionString);

            TokenCredential credential = new DefaultAzureCredential();
            /*@@*/
            /*@@*/ credential = EventHubsTestEnvironment.Instance.Credential;

            var producer = new EventHubProducerClient(
                properties.FullyQualifiedNamespace,
                properties.EventHubName ?? eventHubName,
                credential);

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();

                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                await producer.SendAsync(eventBatch);
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }
    }
}
