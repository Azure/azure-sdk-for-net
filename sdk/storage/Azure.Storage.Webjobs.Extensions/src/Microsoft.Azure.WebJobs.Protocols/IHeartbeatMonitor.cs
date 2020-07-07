// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Protocols
{
    /// <summary>Defines a monitor for running host heartbeats.</summary>
    public interface IHeartbeatMonitor
    {
        /// <summary>
        /// Gets the time at which a valid shared heartbeat may expire, or <see langword="null"/> if there is currently
        /// no unexpired shared heartbeat.
        /// </summary>
        /// <param name="sharedContainerName">
        /// The name of the heartbeat container shared by all instances of the host.
        /// </param>
        /// <param name="sharedDirectoryName">
        /// The name of the directory in <paramref name="sharedContainerName"/> shared by all instances of the host.
        /// </param>
        /// <param name="expirationInSeconds">The number of seconds after the heartbeat that it expires.</param>
        /// <returns>
        /// The time at which a valid shared heartbeat expires, if there is a valid shared heartbeat; otherwise
        /// <see langword="null"/>.
        /// </returns>
        Task<DateTimeOffset?> GetSharedHeartbeatExpirationAsync(string sharedContainerName, string sharedDirectoryName,
            int expirationInSeconds);

        /// <summary>
        /// Gets the time at which a valid instance heartbeat expires, or <see langword="null"/> if there is currently
        /// no unexpired instance heartbeat.
        /// </summary>
        /// <param name="sharedContainerName">
        /// The name of the heartbeat container shared by all instances of the host.
        /// </param>
        /// <param name="sharedDirectoryName">
        /// The name of the directory in <paramref name="sharedContainerName"/> shared by all instances of the host.
        /// </param>
        /// <param name="instanceBlobName">
        /// The name of the host instance heartbeat blob in <paramref name="sharedDirectoryName"/>.
        /// </param>
        /// <param name="expirationInSeconds">The number of seconds after the heartbeat that it expires.</param>
        /// <returns>
        /// The time at which a valid instance heartbeat expires, if there is a valid instance heartbeat; otherwise
        /// <see langword="null"/>.
        /// </returns>
        Task<DateTimeOffset?> GetInstanceHeartbeatExpirationAsync(string sharedContainerName, string sharedDirectoryName,
            string instanceBlobName, int expirationInSeconds);
    }
}
