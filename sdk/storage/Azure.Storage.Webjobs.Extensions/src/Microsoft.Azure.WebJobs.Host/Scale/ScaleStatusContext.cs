// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host.Scale
{
    /// <summary>
    /// Context used by <see cref="IScaleMonitor.GetScaleStatus(ScaleStatusContext)"/> to decide
    /// scale status.
    /// </summary>
    public class ScaleStatusContext
    {
        /// <summary>
        /// The current worker count for the host application.
        /// </summary>
        public int WorkerCount { get; set; }

        /// <summary>
        /// The collection of metrics samples which can be used to make
        /// the scale decision.
        /// </summary>
        public IEnumerable<ScaleMetrics> Metrics { get; set; }
    }

    public class ScaleStatusContext<TMetrics> : ScaleStatusContext where TMetrics : ScaleMetrics
    {
        /// <summary>
        /// The collection of metrics samples which can be used to make
        /// the scale decision.
        /// </summary>
        new public IEnumerable<TMetrics> Metrics { get; set; }
    }
}
