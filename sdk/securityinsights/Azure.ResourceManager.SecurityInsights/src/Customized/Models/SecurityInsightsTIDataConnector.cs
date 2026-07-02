// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.SecurityInsights;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // The TypeSpec flattening path generates DataTypesIndicatorsState, but the GA SDK exposed this nested state as IndicatorsState.
    [CodeGenSuppress("DataTypesIndicatorsState")]
    public partial class SecurityInsightsTIDataConnector
    {
        /// <summary> Describe whether this data type connection is enabled or not. </summary>
        [WirePath("properties.dataTypes.indicators.state")]
        public SecurityInsightsDataTypeConnectionState? IndicatorsState
        {
            get => Properties is null ? default : Properties.DataTypesIndicatorsState;
            set
            {
                if (value.HasValue)
                {
                    if (Properties is null)
                    {
                        Properties = new TiDataConnectorProperties();
                    }

                    Properties.DataTypesIndicatorsState = value.Value;
                }
            }
        }
    }
}
