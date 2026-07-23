// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.OperationalInsights.Models;

namespace Azure.ResourceManager.OperationalInsights
{
    // Backward-compat justification: the GA SDK exposed flattened data export destination properties with legacy WirePath values.
    public partial class OperationalInsightsDataExportData
    {
        /// <summary> The destination resource ID. This can be copied from the Properties entry of the destination resource in Azure. </summary>
        [WirePath("properties.resourceId")]
        public ResourceIdentifier ResourceId
        {
            get => Properties is null ? default : Properties.ResourceId;
            set
            {
                if (Properties is null)
                {
                    Properties = new DataExportProperties();
                }
                Properties.ResourceId = value;
            }
        }

        /// <summary> The type of the destination resource. </summary>
        [WirePath("properties.type")]
        public OperationalInsightsDataExportDestinationType? DestinationType => Properties is null ? default : Properties.DestinationType;

        /// <summary> Optional. Allows to define an Event Hub name. Not applicable when destination is Storage Account. </summary>
        [WirePath("properties.eventHubName")]
        public string EventHubName
        {
            get => Properties is null ? default : Properties.EventHubName;
            set
            {
                if (Properties is null)
                {
                    Properties = new DataExportProperties();
                }
                Properties.EventHubName = value;
            }
        }
    }
}
