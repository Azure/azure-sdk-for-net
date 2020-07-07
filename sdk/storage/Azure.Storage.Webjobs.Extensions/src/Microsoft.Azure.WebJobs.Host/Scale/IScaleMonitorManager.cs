// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host.Scale
{
    /// <summary>
    /// Manager for registering and accessing <see cref="IScaleMonitor"/> instances for
    /// a <see cref="JobHost"/> instance.
    /// </summary>
    public interface IScaleMonitorManager
    {
        /// <summary>
        /// Register an <see cref="IScaleMonitor"/> instance.
        /// </summary>
        /// <param name="monitor">The monitor instance to register.</param>
        void Register(IScaleMonitor monitor);

        /// <summary>
        /// Get all registered monitor instances.
        /// </summary>
        /// <remarks>
        /// Should only be called after the host has been started and all
        /// instances are registered.
        /// </remarks>
        /// <returns>The collection of monitor intances.</returns>
        IEnumerable<IScaleMonitor> GetMonitors();
    }
}
