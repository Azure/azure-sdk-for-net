// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.SecurityInsights;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/57058: the derived MCAS constructor passes the inner alerts model, so keep the previously shipped base constructor shape.
    [CodeGenSuppress("SecurityInsightsAlertsDataTypeOfDataConnector")]
    [CodeGenSuppress("SecurityInsightsAlertsDataTypeOfDataConnector", typeof(SecurityInsightsDataTypeConnectionState))]
    [CodeGenSuppress("AlertsState")]
    public partial class SecurityInsightsAlertsDataTypeOfDataConnector
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsightsAlertsDataTypeOfDataConnector"/>. </summary>
        public SecurityInsightsAlertsDataTypeOfDataConnector()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SecurityInsightsAlertsDataTypeOfDataConnector"/>. </summary>
        /// <param name="alerts"> Alerts data type connection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="alerts"/> is null. </exception>
        public SecurityInsightsAlertsDataTypeOfDataConnector(DataConnectorDataTypeCommon alerts)
        {
            Argument.AssertNotNull(alerts, nameof(alerts));

            Alerts = alerts;
        }

        /// <summary> Initializes a new instance of <see cref="SecurityInsightsAlertsDataTypeOfDataConnector"/>. </summary>
        /// <param name="alertsState"> Describe whether this data type connection is enabled or not. </param>
        internal SecurityInsightsAlertsDataTypeOfDataConnector(SecurityInsightsDataTypeConnectionState? alertsState)
        {
            Alerts = alertsState.HasValue ? new DataConnectorDataTypeCommon(alertsState.Value) : default;
        }

        /// <summary> Describe whether this data type connection is enabled or not. </summary>
        public SecurityInsightsDataTypeConnectionState? AlertsState
        {
            get => Alerts is null ? default : Alerts.State;
            set => Alerts = value.HasValue ? new DataConnectorDataTypeCommon(value.Value) : default;
        }
    }
}