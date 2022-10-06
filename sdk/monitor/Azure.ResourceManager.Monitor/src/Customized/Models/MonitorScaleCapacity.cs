// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

[assembly: CodeGenSuppressType("MonitorScaleCapacity")]

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary>
    /// The number of instances that can be used during this profile.
    /// </summary>
    public partial class MonitorScaleCapacity
    {
        /// <summary> Initializes a new instance of MonitorScaleCapacity. </summary>
        /// <param name="minimum">
        /// the minimum number of instances for the resource.
        /// </param>
        /// <param name="maximum">
        /// the maximum number of instances for the resource. The actual maximum number of instances is limited by the cores that are available in the subscription.
        /// </param>
        /// <param name="default">
        /// the number of instances that will be set if metrics are not available for evaluation. The default is only used if the current instance count is lower than the default.
        /// </param>
        public MonitorScaleCapacity(int minimum, int maximum, int @default)
        {
            Minimum = minimum;
            Maximum = maximum;
            Default = @default;
        }

        /// <summary>
        /// the minimum number of instances for the resource.
        /// </summary>
        public int Minimum { get; set; }
        /// <summary>
        /// the maximum number of instances for the resource. The actual maximum number of instances is limited by the cores that are available in the subscription.
        /// </summary>
        public int Maximum { get; set; }
        /// <summary>
        /// the number of instances that will be set if metrics are not available for evaluation. The default is only used if the current instance count is lower than the default.
        /// </summary>
        public int Default { get; set; }
    }
}
