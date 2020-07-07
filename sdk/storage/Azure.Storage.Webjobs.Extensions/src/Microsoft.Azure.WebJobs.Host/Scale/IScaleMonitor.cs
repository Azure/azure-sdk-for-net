// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Scale
{
    /// <summary>
    /// Interface defining a monitor that can participate in Azure Functions scaling decisions by
    /// taking metrics samples, and scaling based on those samples.
    /// </summary>
    public interface IScaleMonitor
    {
        /// <summary>
        /// Returns the <see cref="ScaleMonitorDescriptor"/> for this monitor.
        /// </summary>
        ScaleMonitorDescriptor Descriptor { get; }

        /// <summary>
        /// Return a current metrics sample by querying the event source.
        /// </summary>
        /// <returns>The <see cref="ScaleMetrics"/> sample.</returns>
        Task<ScaleMetrics> GetMetricsAsync();

        /// <summary>
        /// Return the current scale status based on the specified context.
        /// </summary>
        /// <param name="context">The <see cref="ScaleStatusContext"/> to use to determine
        /// the scale status.</param>
        /// <returns>The scale status.</returns>
        ScaleStatus GetScaleStatus(ScaleStatusContext context);
    }

    public interface IScaleMonitor<TMetrics> : IScaleMonitor where TMetrics : ScaleMetrics
    {
        new Task<TMetrics> GetMetricsAsync();

        ScaleStatus GetScaleStatus(ScaleStatusContext<TMetrics> context);
    }
}
