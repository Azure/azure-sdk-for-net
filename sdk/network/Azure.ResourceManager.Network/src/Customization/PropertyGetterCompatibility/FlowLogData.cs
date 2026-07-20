// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the FlowLogData type. </summary>
    public partial class FlowLogData
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.TrafficAnalyticsConfigurationProperties TrafficAnalyticsConfiguration { get; set; }
    }
}
