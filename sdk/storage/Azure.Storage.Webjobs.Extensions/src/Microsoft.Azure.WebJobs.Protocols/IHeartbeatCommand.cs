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
    /// <summary>Defines a command that signals a heartbeat from a running host instance.</summary>
#if PUBLICPROTOCOL
    public interface IHeartbeatCommand
#else
    internal interface IHeartbeatCommand
#endif
    {
        /// <summary>Signals a heartbeat from a running host instance.</summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> that will signal the heartbeat.</returns>
        Task BeatAsync(CancellationToken cancellationToken);
    }
}
