// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // Preserve the nullable property shipped in the GA release.
    [CodeGenSuppress("AlertsState")]
    public partial class SecurityInsightsAlertsDataTypeOfDataConnector
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsightsAlertsDataTypeOfDataConnector"/>. </summary>
        public SecurityInsightsAlertsDataTypeOfDataConnector()
        {
        }

        /// <summary> Describe whether this data type connection is enabled or not. </summary>
        public SecurityInsightsDataTypeConnectionState? AlertsState
        {
            get => Alerts is null ? default : Alerts.State;
            set => Alerts = value.HasValue ? new DataConnectorDataTypeCommon(value.Value) : default;
        }
    }
}
