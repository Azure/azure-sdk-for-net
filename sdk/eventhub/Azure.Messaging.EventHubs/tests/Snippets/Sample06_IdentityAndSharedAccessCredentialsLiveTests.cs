// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.EventHubs.Authorization;
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
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample06_IdentityAndSharedAccessCredentialsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task DefaultAzureCredential()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample06_DefaultAzureCredential

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
#endif

            var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);

            try
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();

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
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample06_SharedAccessSignature

#if SNIPPET
            var credential = new AzureSasCredential("<< SHARED ACCESS KEY STRING >>");

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var resource = EventHubConnection.BuildConnectionSignatureAuthorizationResource(new EventHubProducerClientOptions().ConnectionOptions.TransportType, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName);
            var signature = new SharedAccessSignature(resource, EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);
            var credential = new AzureSasCredential(signature.Value);

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
#endif

            var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);

            try
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();

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
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample06_SharedAccessKey

#if SNIPPET
            var credential = new AzureNamedKeyCredential("<< SHARED KEY NAME >>", "<< SHARED KEY >>");

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var credential = new AzureNamedKeyCredential(EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
#endif

            var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);

            try
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();

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
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample06_ConnectionStringParse

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            EventHubsConnectionStringProperties properties =
                EventHubsConnectionStringProperties.Parse(connectionString);

            var producer = new EventHubProducerClient(
                properties.FullyQualifiedNamespace,
                properties.EventHubName ?? eventHubName,
                credential);

            try
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();

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
