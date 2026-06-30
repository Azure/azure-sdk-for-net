// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.SecurityInsights;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // The TypeSpec flattening path generates DataTypesAlertsState, but the GA SDK exposed this nested state as AlertsState.
    [CodeGenSuppress("DataTypesAlertsState")]
    public partial class MdatpDataConnector
    {
        /// <summary> Gets or sets the AlertsState. </summary>
        [WirePath("properties.dataTypes.alerts.state")]
        public SecurityInsightsDataTypeConnectionState? AlertsState
        {
            get => Properties is null ? default : Properties.DataTypesAlertsState;
            set
            {
                if (Properties is null)
                {
                    Properties = new MdatpDataConnectorProperties();
                }

                Properties.DataTypesAlertsState = value;
            }
        }
    }
}