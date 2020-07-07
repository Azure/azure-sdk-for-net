// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    /// <summary>
    /// Defines an interface for listening to external event sources.
    /// </summary>
    public interface IListener : IDisposable
    {
        /// <summary>
        /// Start listening.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A task that completes when the listener is fully started.</returns>
        Task StartAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Stop listening.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A task that completes when the listener has stopped.</returns>
        Task StopAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Cancel any in progress listen operation.
        /// </summary>
        void Cancel();
    }
}
