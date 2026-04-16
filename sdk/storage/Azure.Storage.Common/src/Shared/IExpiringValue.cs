// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage
{
    /// <summary>
    /// Represents a cached value that has an expiration time and a proactive refresh time.
    /// </summary>
    internal interface IExpiringValue
    {
        /// <summary>
        /// The time at which this value is no longer valid and must be re-acquired.
        /// </summary>
        DateTimeOffset ExpiresOn { get; }

        /// <summary>
        /// The time at which a background refresh should be initiated so that a new value
        /// is ready before <see cref="ExpiresOn"/> is reached.
        /// </summary>
        DateTimeOffset RefreshOn { get; }

        /// <summary>
        /// Returns a new copy of this value with the specified <paramref name="refreshOn"/> time.
        /// Used by the cache to modify the refresh time while keeping everything else the same.
        /// </summary>
        IExpiringValue WithRefreshOn(DateTimeOffset refreshOn);
    }
}
