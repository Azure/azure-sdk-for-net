// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Scale
{
    /// <summary>
    /// Provider interface for returning an <see cref="IScaleMonitor"/> instance.
    /// </summary>
    /// <remarks>
    /// Listeners can implement <see cref="IScaleMonitor"/> directly, but in some
    /// cases the decoupling afforded by this interface is needed.
    /// </remarks>
    public interface IScaleMonitorProvider
    {
        /// <summary>
        /// Gets the <see cref="IScaleMonitor"/> instance.
        /// </summary>
        /// <returns>The <see cref="IScaleMonitor"/> instance.</returns>
        IScaleMonitor GetMonitor();
    }
}
