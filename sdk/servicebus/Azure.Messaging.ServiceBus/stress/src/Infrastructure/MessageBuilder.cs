// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Azure.Messaging.ServiceBus.Stress;
internal static class MessageBuilder
{
    /// <summary>The seed to use for initializing random number generated for a given thread-specific instance.</summary>
    private static int s_randomSeed = Environment.TickCount;

    /// <summary>The random number generator to use for a specific thread.</summary>
    private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref s_randomSeed)), false);

    internal static ReadOnlyMemory<byte> CreateRandomBody(long bodySizeBytes)
    {
        var buffer = new byte[bodySizeBytes];
        RandomNumberGenerator.Value.NextBytes(buffer);

        return buffer;
    }

    internal static IEnumerable<ServiceBusMessage> CreateMessages(int numberOfMessages,
                                                        long maximumBatchSize,
                                                        int largeMessageRandomFactor = 30,
                                                        int minimumBodySize = 15,
                                                        int maximumBodySize = 83886)
    {
        var totalBytesGenerated = 0;

        if (RandomNumberGenerator.Value.Next(1, 100) < largeMessageRandomFactor)
        {
            activeMinimumBodySize = (int)Math.Ceiling(maximumBodySize * 0.65);
        }
        else
        {
            activeMaximumBodySize = (int)Math.Floor((maximumBatchSize * 1.0f) / numberOfMessages);
        }

        for (var index = 0; ((index < numberOfMessages) && (totalBytesGenerated <= maximumBatchSize)); ++index)
        {
            var buffer = new byte[RandomNumberGenerator.Value.Next(activeMinimumBodySize, activeMaximumBodySize)];
            RandomNumberGenerator.Value.NextBytes(buffer);
            totalBytesGenerated += buffer.Length;

            yield return CreateMessageFromBody(buffer);
        }
    }

    internal static IEnumerable<ServiceBusMessage> CreateSmallMessages(int numberOfMessages)
    {
        const int minimumBodySize = 5;
        const int maximumBodySize = 25;

        for (var index = 0; index < numberOfMessages; ++index)
        {
            var buffer = new byte[RandomNumberGenerator.Value.Next(minimumBodySize, maximumBodySize)];
            RandomNumberGenerator.Value.NextBytes(buffer);

            yield return CreateMessageFromBody(buffer);
        }
    }

    internal static ServiceBusMessage CreateMessagefromBody(ReadOnlyMemory<byte> eventBody)
    {
        var id = Guid.NewGuid().ToString();

        return new ServiceBusMessage(eventBody)
        {
            MessageId = id,
            Properties = {{ IdPropertyName, id }}
        };
    }

    internal static async Task<IEnumerable<ServiceBusMessageBatch>> BuildBatchesAsync(IEnumerable<ServiceBusMessage> messages,
                                                                            ServiceBusSender sender,
                                                                            CancellationToken cancellationToken = default)
    {
        ServiceBusMessage message;

        var queuedMessages = new Queue<ServiceBusMessage>(messages);
        var batches = new List<ServiceBusMessageBatch>();
        var currentBatch = default(ServiceBusMessageBatch);

        while (queuedMessages.Count > 0)
        {
            currentBatch ??= (await sender.CreateMessageBatchAsync(cancellationToken).ConfigureAwait(false));
            serviceBusMessage = queuedMessages.Peek();

            if (!currentBatch.TryAddMessage(serviceBusMessage))
            {
                if (currentBatch.Count == 0)
                {
                    throw new InvalidOperationException("There was an event too large to fit into a batch.");
                }

                batches.Add(currentBatch);
                currentBatch = default;
            }
            else
            {
                queuedMessages.Dequeue();
            }
        }

        if ((currentBatch != default) && (currentBatch.Count > 0))
        {
            batches.Add(currentBatch);
        }

        return batches;
    }
}