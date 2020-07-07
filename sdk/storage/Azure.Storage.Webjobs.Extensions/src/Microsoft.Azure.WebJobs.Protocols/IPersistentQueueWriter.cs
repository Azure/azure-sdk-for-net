// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Defines a persistent queue writer.</summary>
    /// <typeparam name="T">The type of messages in the queue.</typeparam>
#if PUBLICPROTOCOL
    public interface IPersistentQueueWriter<T>
#else
    internal interface IPersistentQueueWriter<T>
#endif
    {
        /// <summary>Adds a message to the queue.</summary>
        /// <param name="message">The message to enqueue.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> that will provide the enqueued message identifier.</returns>
        Task<string> EnqueueAsync(T message, CancellationToken cancellationToken);

        /// <summary>Deletes a message from the queue.</summary>
        /// <param name="messageId">The message identifier from the message to delete.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> that will delete the message from the queue.</returns>
        Task DeleteAsync(string messageId, CancellationToken cancellationToken);
    }
}
