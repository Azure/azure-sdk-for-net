// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Scale
{
    /// <summary>
    /// Base class for all scale metrics types, returned by <see cref="IScaleMonitor.GetMetricsAsync"/>.
    /// </summary>
    public class ScaleMetrics
    {
        public ScaleMetrics()
        {
            Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the UTC timestamp of when the sample was taken.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
