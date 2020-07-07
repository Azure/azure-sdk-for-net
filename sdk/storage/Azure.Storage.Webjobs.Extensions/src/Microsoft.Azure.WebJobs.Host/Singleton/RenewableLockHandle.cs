// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Timers;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Internal lock handle returned by <see cref="SingletonManager"/>
    /// </summary>
    internal class RenewableLockHandle
    {
        public RenewableLockHandle(IDistributedLock handle, ITaskSeriesTimer renewal)
        {
            this.InnerLock = handle;
            this.LeaseRenewalTimer = renewal;
        }

        // The inner lock for the underlying implementation. 
        // This is a pluggable implementation. 
        public IDistributedLock InnerLock { get; private set; }

        // Handle to a timer for renewing the lease. 
        // We handle the timer.
        public ITaskSeriesTimer LeaseRenewalTimer { get; private set; }
    }
}
