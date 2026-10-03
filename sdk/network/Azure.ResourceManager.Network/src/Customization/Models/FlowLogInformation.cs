// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Information on flow logging configuration. </summary>
    public partial class FlowLogInformation
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="NetworkWatcherFlowAnalyticsConfiguration"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use NetworkWatcherFlowAnalyticsConfiguration instead.")]
        public TrafficAnalyticsConfigurationProperties TrafficAnalyticsConfiguration
        {
            get => NetworkWatcherFlowAnalyticsConfiguration;
            set => NetworkWatcherFlowAnalyticsConfiguration = value;
        }
    }
}
