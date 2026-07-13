// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the FlowLogInformation type. </summary>
    public partial class FlowLogInformation
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.TrafficAnalyticsConfigurationProperties TrafficAnalyticsConfiguration { get; set; }
    }
}
