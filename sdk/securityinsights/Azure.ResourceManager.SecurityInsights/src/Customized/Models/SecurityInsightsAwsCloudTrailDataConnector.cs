// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.SecurityInsights;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // The TypeSpec flattening path generates DataTypesLogsState, but the GA SDK exposed this nested state as LogsState.
    [CodeGenSuppress("DataTypesLogsState")]
    public partial class SecurityInsightsAwsCloudTrailDataConnector
    {
        /// <summary> Describe whether this data type connection is enabled or not. </summary>
        [WirePath("properties.dataTypes.logs.state")]
        public SecurityInsightsDataTypeConnectionState? LogsState
        {
            get => Properties is null ? default : Properties.DataTypesLogsState;
            set
            {
                if (value.HasValue)
                {
                    if (Properties is null)
                    {
                        Properties = new AwsCloudTrailDataConnectorProperties();
                    }

                    Properties.DataTypesLogsState = value.Value;
                }
            }
        }
    }
}