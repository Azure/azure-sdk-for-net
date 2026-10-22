// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class FlowLogInformation
    {
        // Bind the safe-flattened member to its active 1.15 name without renaming the shared nested model.
        /// <summary> Parameters that define the configuration of traffic analytics. </summary>
        [CodeGenMember("NetworkWatcherFlowAnalyticsConfiguration")]
        [WirePath("flowAnalyticsConfiguration.networkWatcherFlowAnalyticsConfiguration")]
        public TrafficAnalyticsConfigurationProperties TrafficAnalyticsConfiguration
        {
            get => FlowAnalyticsConfiguration?.NetworkWatcherFlowAnalyticsConfiguration;
            set
            {
                if (FlowAnalyticsConfiguration is null)
                {
                    FlowAnalyticsConfiguration = new TrafficAnalyticsProperties();
                }
                FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration = value;
            }
        }
    }
}
