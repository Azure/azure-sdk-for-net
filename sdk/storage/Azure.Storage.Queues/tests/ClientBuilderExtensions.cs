// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using QueuesClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Queues.QueueServiceClient,
    Azure.Storage.Queues.QueueClientOptions>;

namespace Azure.Storage.Queues.Tests
{
    public static class ClientBuilderExtensions
    {
        public static string GetNewQueueName(this QueuesClientBuilder clientBuilder)
            => $"test-queue-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewMessageId(this QueuesClientBuilder clientBuilder)
            => $"test-message-{clientBuilder.Recording.Random.NewGuid()}";

        public static async Task<DisposingQueue> GetTestQueueAsync(
            this QueuesClientBuilder clientBuilder,
            QueueServiceClient service = default,
            IDictionary<string, string> metadata = default)
        {
            service ??= clientBuilder.GetServiceClient_SharedKey();
            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            QueueClient queue = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetQueueClient(clientBuilder.GetNewQueueName()));
            return await DisposingQueue.CreateAsync(queue, metadata);
        }

        public static QueueServiceClient GetServiceClient_SharedKey(this QueuesClientBuilder clientBuilder, QueueClientOptions options = default)
            => clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigDefault, options);

        public static QueueServiceClient GetServiceClient_OAuth(this QueuesClientBuilder clientBuilder)
            => clientBuilder.GetServiceClientFromOauthConfig(clientBuilder.Tenants.TestConfigOAuth);

        public class DisposingQueue : IAsyncDisposable
        {
            public QueueClient Queue { get; private set; }

            public static async Task<DisposingQueue> CreateAsync(QueueClient queue, IDictionary<string, string> metadata)
            {
                await queue.CreateIfNotExistsAsync(metadata: metadata);
                return new DisposingQueue(queue);
            }

            private DisposingQueue(QueueClient queue)
            {
                Queue = queue;
            }

            public async ValueTask DisposeAsync()
            {
                if (Queue != null)
                {
                    try
                    {
                        await Queue.DeleteIfExistsAsync();
                        Queue = null;
                    }
                    catch
                    {
                        // swallow the exception to avoid hiding another test failure
                    }
                }
            }
        }
    }
}
