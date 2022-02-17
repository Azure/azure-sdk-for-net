// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a <see cref="ConstantPollingStrategy"/> with 0 interval.
    /// This is normally used for testing, like record playback.
    /// </summary>
    internal class ZeroPollingStrategy : ConstantPollingStrategy
    {
        /// <summary>
        /// Create a <see cref="ConstantPollingStrategy"/> with 0 second polling interval.
        /// </summary>
        public ZeroPollingStrategy() : base(TimeSpan.Zero) { }
    }
}
