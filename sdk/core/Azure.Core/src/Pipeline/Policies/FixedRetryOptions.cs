// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Pipeline.Policies
{
    public class FixedRetryOptions
    {
        /// <summary>
        /// Gets or sets the maximum number of retry attempts before giving up.
        /// </summary>
        public int MaxRetries { get; set; } = 3;

        /// <summary>
        /// Gets or sets the timespan to wait before retries.
        /// </summary>
        public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(0.8);
    }
}
