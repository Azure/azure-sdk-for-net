// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    /// <summary>
    /// Interface defining methods used to create <see cref="IListener"/>s for
    /// trigger parameter bindings.
    /// </summary>
    public interface IListenerFactory
    {
        /// <summary>
        /// Creates a listener.
        /// </summary>
        /// <param name="token">A <see cref="CancellationToken"/>.</param>
        /// <returns>The listener.</returns>
        Task<IListener> CreateAsync(CancellationToken token);
    }
}
