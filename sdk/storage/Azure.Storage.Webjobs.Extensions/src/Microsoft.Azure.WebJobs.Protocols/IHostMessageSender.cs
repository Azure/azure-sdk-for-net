// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Protocols
{
    /// <summary>Defines a host message sender.</summary>
    public interface IHostMessageSender
    {
        /// <summary>Enqueues a message to the host.</summary>
        /// <param name="queueName">The name of the queue to which the host is listening.</param>
        /// <param name="message">The message to the host.</param>
        Task EnqueueAsync(string queueName, HostMessage message);
    }
}
