// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.SecurityInsights;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // TypeSpec alternateType generates non-nullable state properties; keep the nullable GA SDK surface.
    [CodeGenSuppress("SecurityInsightsOfficeDataConnectorDataTypes", typeof(SecurityInsightsDataTypeConnectionState), typeof(SecurityInsightsDataTypeConnectionState), typeof(SecurityInsightsDataTypeConnectionState))]
    [CodeGenSuppress("ExchangeState")]
    [CodeGenSuppress("SharePointState")]
    [CodeGenSuppress("TeamsState")]
    public partial class SecurityInsightsOfficeDataConnectorDataTypes
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsightsOfficeDataConnectorDataTypes"/>. </summary>
        public SecurityInsightsOfficeDataConnectorDataTypes()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SecurityInsightsOfficeDataConnectorDataTypes"/>. </summary>
        /// <param name="exchange"> Exchange data type connection. </param>
        /// <param name="sharePoint"> SharePoint data type connection. </param>
        /// <param name="teams"> Teams data type connection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exchange"/>, <paramref name="sharePoint"/> or <paramref name="teams"/> is null. </exception>
        public SecurityInsightsOfficeDataConnectorDataTypes(DataConnectorDataTypeCommon exchange, DataConnectorDataTypeCommon sharePoint, DataConnectorDataTypeCommon teams)
        {
            Argument.AssertNotNull(exchange, nameof(exchange));
            Argument.AssertNotNull(sharePoint, nameof(sharePoint));
            Argument.AssertNotNull(teams, nameof(teams));

            Exchange = exchange;
            SharePoint = sharePoint;
            Teams = teams;
        }

        /// <summary> Describe whether this data type connection is enabled or not. </summary>
        [WirePath("exchange.state")]
        public SecurityInsightsDataTypeConnectionState? ExchangeState
        {
            get => Exchange is null ? default : Exchange.State;
            set => Exchange = value.HasValue ? new DataConnectorDataTypeCommon(value.Value) : default;
        }

        /// <summary> Describe whether this data type connection is enabled or not. </summary>
        [WirePath("sharePoint.state")]
        public SecurityInsightsDataTypeConnectionState? SharePointState
        {
            get => SharePoint is null ? default : SharePoint.State;
            set => SharePoint = value.HasValue ? new DataConnectorDataTypeCommon(value.Value) : default;
        }

        /// <summary> Describe whether this data type connection is enabled or not. </summary>
        [WirePath("teams.state")]
        public SecurityInsightsDataTypeConnectionState? TeamsState
        {
            get => Teams is null ? default : Teams.State;
            set => Teams = value.HasValue ? new DataConnectorDataTypeCommon(value.Value) : default;
        }
    }
}
