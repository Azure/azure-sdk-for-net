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

    /// <summary>
    ///   Creates random values to fill <see cref="ServiceBusMessage"/> bodies.
    /// </summary>
    ///
    internal static ReadOnlyMemory<byte> CreateRandomBody(long bodySizeBytes)
    {
        var buffer = new byte[bodySizeBytes];
        RandomNumberGenerator.Value.NextBytes(buffer);

        return buffer;
    }

    /// <summary>
    ///   Creates a random set of messages with random data and random body size within the specified constraints.
    /// </summary>
    ///
    /// <param name="maxNumberOfMessages">The max number of messages to create.</param>
    /// <param name="maximumBatchSize">The maximum size of the batch.</param>
    /// <param name="largeMessageRandomFactor">The percentage of messages that should be large.</param>
    /// <param name="minimumBodySize">The minimum size of the message body.</param>
    /// <param name="maximumBodySize">The maximum size of the message body.</param>
    ///
    /// <returns>The requested set of messages.</returns>
    ///
    internal static IEnumerable<ServiceBusMessage> CreateMessages(int maxNumberOfMessages,
                                                        long maximumBatchSize,
                                                        int largeMessageRandomFactor = 5,
                                                        int minimumBodySize = 15,
                                                        int maximumBodySize = 83886,
                                                        string sessionId = null)
    {
        var activeMinimumBodySize = minimumBodySize;
        var activeMaximumBodySize = maximumBodySize;
        var totalBytesGenerated = 0;

        if (RandomNumberGenerator.Value.Next(1, 100) < largeMessageRandomFactor)
        {
            activeMinimumBodySize = (int)Math.Ceiling(maximumBodySize * 0.65);
        }
        else
        {
            activeMaximumBodySize = (int)Math.Floor((maximumBatchSize * 1.0f) / maxNumberOfMessages);
        }

        for (var index = 0; ((index < maxNumberOfMessages) && (totalBytesGenerated <= maximumBatchSize)); ++index)
        {
            var buffer = new byte[RandomNumberGenerator.Value.Next(activeMinimumBodySize, activeMaximumBodySize)];
            RandomNumberGenerator.Value.NextBytes(buffer);
            totalBytesGenerated += buffer.Length;

            yield return CreateMessageFromBody(buffer, sessionId);
        }
    }

    /// <summary>
    ///   Creates a random set of small messages with random data and random body size within the specified constraints.
    /// </summary>
    ///
    /// <param name="numberOfMessages">The number of messages to create.</param>
    ///
    /// <returns>The requested set of messages.</returns>
    ///
    internal static IEnumerable<ServiceBusMessage> CreateSmallMessages(int numberOfMessages)
    {
        const int minimumBodySize = 5;
        const int maximumBodySize = 25;

        for (var index = 0; index < numberOfMessages; ++index)
        {
            var buffer = new byte[RandomNumberGenerator.Value.Next(minimumBodySize, maximumBodySize)];
            RandomNumberGenerator.Value.NextBytes(buffer);

            yield return CreateMessageFromBody(buffer, null);
        }
    }

    /// <summary>
    ///   Creates a message from the given message body.
    /// </summary>
    ///
    /// <param name="messageBody">The body of the message to create.</param>
    ///
    /// <returns>The requested message.</returns>
    ///
    internal static ServiceBusMessage CreateMessageFromBody(ReadOnlyMemory<byte> messageBody, string sessionId)
    {
        var id = Guid.NewGuid().ToString();

        ServiceBusMessage m;

        if (!string.IsNullOrEmpty(sessionId))
        {
            m = new ServiceBusMessage(messageBody)
            {
                SessionId = sessionId
            };
        }
        else
        {
            m = new ServiceBusMessage(messageBody);
        }
        m.MessageId = id;
        return m;
    }

    /// <summary>
    ///   Creates a batch with a given set of messages.
    /// </summary>
    ///
    /// <param name="messages">The set of messages to add to the batch.</param>
    /// <param name="sender">The sender to use to build the batch.</param>
    /// <param name="cancellationToken">The token to signal cancellation of the task.</param>
    ///
    /// <returns>The requested message.</returns>
    ///
    internal static async Task<IEnumerable<ServiceBusMessageBatch>> BuildBatchesAsync(IEnumerable<ServiceBusMessage> messages,
                                                                            ServiceBusSender sender,
                                                                            CancellationToken cancellationToken = default)
    {
        ServiceBusMessage serviceBusMessage;

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
                    throw new InvalidOperationException("There was a message too large to fit into a batch.");
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