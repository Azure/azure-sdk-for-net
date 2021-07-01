// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Snippets
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Processor;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Xunit;

    /// <summary>
    ///   The suite of tests defining the snippets used in the migration guide
    ///   illustrating concepts from Microsoft.Azure.EventHubs and
    ///   Azure.Messaging.EventHubs in a side-by-side manner.
    /// </summary>
    ///
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class MigrationGuideSnippets
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public void CreateWithConnectionString()
        {
            #region Snippet:EventHubs_Migrate_T1_CreateWithConnectionString

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = TestUtility.EventHubsConnectionString;
            /*@@*/ eventHubName = "fake";

            var builder = new EventHubsConnectionStringBuilder(connectionString);
            builder.EntityPath = eventHubName;

            EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());

            #endregion

            client.Close();
        }

        [Fact(Skip = "Manual run only")]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task CreateWithAzureActiveDirectory()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_CreateWithAzureActiveDirectory

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ fullyQualifiedNamespace = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString).Endpoint.ToString();
            /*@@*/ eventHubName = scope.EventHubName;

            var authority = "<< NAME OF THE AUTHORITY TO ASSOCIATE WITH THE TOKEN >>";
            var aadAppId = "<< THE AZURE ACTIVE DIRECTORY APPLICATION ID TO REQUEST A TOKEN FOR >>";
            var aadAppSecret = "<< THE AZURE ACTIVE DIRECTORY SECRET TO USE FOR THE TOKEN >>";
            /*@@*/
            /*@@*/ authority = "";     // Needed for manual run
            /*@@*/ aadAppId = "";      // Needed for manual run
            /*@@*/ aadAppSecret = "";  // Needed for manual run

            AzureActiveDirectoryTokenProvider.AuthenticationCallback authCallback =
                async (audience, authority, state) =>
                {
                    var authContext = new AuthenticationContext(authority);
                    var clientCredential = new ClientCredential(aadAppId, aadAppSecret);

                    AuthenticationResult authResult = await authContext.AcquireTokenAsync(audience, clientCredential);
                    return authResult.AccessToken;
                };

            EventHubClient client = EventHubClient.CreateWithAzureActiveDirectory(
                new Uri(fullyQualifiedNamespace),
                eventHubName,
                authCallback,
                authority);

            #endregion

            client.Close();
        }

        [Fact(Skip = "Manual run only")]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task CreateWithManagedIdentity()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_ManagedIdentity

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ fullyQualifiedNamespace = new EventHubsConnectionStringBuilder(TestUtility.EventHubsConnectionString).Endpoint.ToString();
            /*@@*/ eventHubName = scope.EventHubName;

            EventHubClient client = EventHubClient.CreateWithManagedIdentity(
                new Uri(fullyQualifiedNamespace),
                eventHubName);

            #endregion

            client.Close();
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PublishWithAutomaticRouting()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_PublishWithAutomaticRouting

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = TestUtility.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

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

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PublishWithAPartitionKey()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_PublishWithAPartitionKey

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = TestUtility.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

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

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PublishToSpecificPartition()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_PublishToSpecificPartition

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = TestUtility.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

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

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReadFromSpecificPartition()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_ReadFromSpecificPartition

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ connectionString = TestUtility.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;
            /*@@*/ consumerGroup = PartitionReceiver.DefaultConsumerGroupName;

            var builder = new EventHubsConnectionStringBuilder(connectionString);
            builder.EntityPath = eventHubName;

            EventHubClient client = EventHubClient.CreateFromConnectionString(builder.ToString());
            PartitionReceiver receiver = default;

            try
            {
                string firstPartition = (await client.GetRuntimeInformationAsync()).PartitionIds.First();
                receiver = client.CreateReceiver(consumerGroup, firstPartition, EventPosition.FromStart());

                IEnumerable<EventData> events = await receiver.ReceiveAsync(50);

                foreach (var eventData in events)
                {
                   Debug.WriteLine($"Read event of length { eventData.Body.Count } from { firstPartition }");
                }
            }
            finally
            {
                receiver?.Close();
                client.Close();
            }

            #endregion
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task BasicEventProcessorHost()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_BasicEventProcessorHost

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = TestUtility.StorageConnectionString;
            /*@@*/ blobContainerName = "migragionsample";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = TestUtility.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;
            /*@@*/ consumerGroup = PartitionReceiver.DefaultConsumerGroupName;

            var eventProcessorHost = new EventProcessorHost(
                eventHubName,
                consumerGroup,
                eventHubsConnectionString,
                storageConnectionString,
                blobContainerName);

            try
            {
                // Registering the processor class will also signal the
                // host to begin processing events.

                await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

                // The processor runs in the background, to allow it to process,
                // this example will wait for 30 seconds and then trigger
                // cancellation.

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                await Task.Delay(Timeout.Infinite, cancellationSource.Token);
            }
            catch (TaskCanceledException)
            {
                // This is expected when the cancellation token is
                // signaled.
            }
            finally
            {
                // Unregistering the processor class will signal the
                // host to stop processing.

                await eventProcessorHost.UnregisterEventProcessorAsync();
            }

            #endregion
        }
    }

    #region Snippet:EventHubs_Migrate_T1_SimpleEventProcessor

    public class SimpleEventProcessor : IEventProcessor
    {
        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
             Debug.WriteLine($"Partition '{context.PartitionId}' is closing.");
             return Task.CompletedTask;
        }

        public Task OpenAsync(PartitionContext context)
        {
            Debug.WriteLine($"Partition: '{context.PartitionId}' was initialized.");
            return Task.CompletedTask;
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            Debug.WriteLine(
                $"Error for partition: {context.PartitionId}, " +
                $"Error: {error.Message}");

            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (var eventData in messages)
            {
                var data = Encoding.UTF8.GetString(
                    eventData.Body.Array,
                    eventData.Body.Offset,
                    eventData.Body.Count);

                Debug.WriteLine(
                    $"Event received for partition: '{context.PartitionId}', " +
                    $"Data: '{data}'");
            }

            return Task.CompletedTask;
        }
    }

    #endregion
}
