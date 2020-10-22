// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers
{
    /// <summary>Defines a recurring command that may fail gracefully.</summary>
    internal interface IRecurrentCommand
    {
        /// <summary>Attempts to execute the command.</summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task"/> that will execute the command. The task's result is <see langword="false"/> if the
        /// command fails gracefully; otherwise <see langword="true"/>.
        /// </returns>
        /// <remarks>
        /// The task completes successfully with a <see langword="false"/> result rather than faulting to indicate a
        /// graceful failure.
        /// </remarks>
        Task<bool> TryExecuteAsync(CancellationToken cancellationToken);
    }
}
