// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using NUnit.Framework;

namespace Microsoft.Azure.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the T1 snippets used in the Event Hubs
    ///   migration guides.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class TrackOneMigrationGuideSnippets
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void CreateWithConnectionString()
        {
            #region Snippet:EventHubs_Migrate_T1_CreateWithConnectionString
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = "fake";
#endif

            var builder = new EventHubsConnectionStringBuilder(connectionString);
            builder.EntityPath = eventHubName;

            EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());

            #endregion

            client.Close();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CreateWithAzureActiveDirectory()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_CreateWithAzureActiveDirectory
#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";

            var authority = "<< NAME OF THE AUTHORITY TO ASSOCIATE WITH THE TOKEN >>";
            var aadAppId = "<< THE AZURE ACTIVE DIRECTORY APPLICATION ID TO REQUEST A TOKEN FOR >>";
            var aadAppSecret = "<< THE AZURE ACTIVE DIRECTORY SECRET TO USE FOR THE TOKEN >>";
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var authority = EventHubsTestEnvironment.Instance.AuthorityHostUrl;
            var aadAppId = EventHubsTestEnvironment.Instance.ClientId;
            var aadAppSecret = EventHubsTestEnvironment.Instance.ClientSecret;
#endif

            AzureActiveDirectoryTokenProvider.AuthenticationCallback authCallback =
                async (audience, authority, state) =>
                {
                    var authContext = new AuthenticationContext(authority);
                    var clientCredential = new ClientCredential(aadAppId, aadAppSecret);

                    AuthenticationResult authResult = await authContext.AcquireTokenAsync(audience, clientCredential);
                    return authResult.AccessToken;
                };

            EventHubClient client = EventHubClient.CreateWithAzureActiveDirectory(
                new Uri($"sb://{ fullyQualifiedNamespace }"),
                eventHubName,
                authCallback,
                authority);

            #endregion

            client.Close();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        /// <remarks>
        ///   This is intentionally NOT decorated as a test method, as it requires a managed identity to
        ///   be configured, which local development environments will not have.
        /// </remarks>
        ///
        public void CreateWithManagedIdentity()
        {
            #region Snippet:EventHubs_Migrate_T1_ManagedIdentity

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";

            EventHubClient client = EventHubClient.CreateWithManagedIdentity(
                new Uri(fullyQualifiedNamespace),
                eventHubName);

            #endregion

            client.Close();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task PublishWithAutomaticRouting()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_PublishWithAutomaticRouting
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

            var builder = new EventHubsConnectionStringBuilder(connectionString);
            builder.EntityPath = eventHubName;

            EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());

            try
            {
                using var eventBatch = client.CreateBatch();

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData(Encoding.UTF8.GetBytes($"Event #{ index }"));

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added");
                    }
                }

                await client.SendAsync(eventBatch);
            }
            finally
            {
                client.Close();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task PublishWithAPartitionKey()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_PublishWithAPartitionKey
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

            var builder = new EventHubsConnectionStringBuilder(connectionString);
            builder.EntityPath = eventHubName;

            EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());

            try
            {
                var batchOptions = new BatchOptions
                {
                    PartitionKey = "Any Value Will Do..."
                };

                using var eventBatch = client.CreateBatch(batchOptions);

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData(Encoding.UTF8.GetBytes($"Event #{ index }"));

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added");
                    }
                }

                await client.SendAsync(eventBatch);
            }
            finally
            {
                client.Close();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task PublishToSpecificPartition()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_PublishToSpecificPartition
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

            var builder = new EventHubsConnectionStringBuilder(connectionString);
            builder.EntityPath = eventHubName;

            EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());
            PartitionSender sender = default;

            try
            {
                using var eventBatch = client.CreateBatch();

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData(Encoding.UTF8.GetBytes($"Event #{ index }"));

                    if (!eventBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added");
                    }
                }

                string firstPartition = (await client.GetRuntimeInformationAsync()).PartitionIds.First();
                sender = client.CreatePartitionSender(firstPartition);

                await sender.SendAsync(eventBatch);
            }
            finally
            {
                sender?.Close();
                client.Close();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadFromSpecificPartition()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_ReadFromSpecificPartition
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
            var consumerGroup = PartitionReceiver.DefaultConsumerGroupName;
#endif

            var builder = new EventHubsConnectionStringBuilder(connectionString);
            builder.EntityPath = eventHubName;

            EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());
            PartitionReceiver receiver = default;

            try
            {
                string firstPartition = (await client.GetRuntimeInformationAsync()).PartitionIds.First();
                receiver = client.CreateReceiver(consumerGroup, firstPartition, EventPosition.FromStart());

                IEnumerable<EventData> events = await receiver.ReceiveAsync(50);

                if (events != null)
                {
                    foreach (var eventData in events)
                    {
                       Debug.WriteLine($"Read event of length { eventData.Body.Count } from { firstPartition }");
                    }
                }
            }
            finally
            {
                receiver?.Close();
                client.Close();
            }

            #endregion
        }
    }
}
