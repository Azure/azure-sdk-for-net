// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402 // File may only contain a single type

#nullable disable

namespace Azure.ResourceManager.SecurityInsights.Models
{
    internal partial class DataConnectorWithAlertsProperties
    {
        internal SecurityInsightsDataTypeConnectionState? DataTypesAlertsState
        {
            get => DataTypes?.Alerts?.State;
            set => SetAlertsState(DataTypes, value, dataTypes => DataTypes = dataTypes);
        }

        internal static void SetAlertsState(
            SecurityInsightsAlertsDataTypeOfDataConnector dataTypes,
            SecurityInsightsDataTypeConnectionState? value,
            System.Action<SecurityInsightsAlertsDataTypeOfDataConnector> setDataTypes)
        {
            if (!value.HasValue)
            {
                return;
            }

            if (dataTypes is null)
            {
                dataTypes = new SecurityInsightsAlertsDataTypeOfDataConnector(null, null);
                setDataTypes(dataTypes);
            }

            dataTypes.Alerts ??= new DataConnectorDataTypeCommon(value.Value);
            dataTypes.Alerts.State = value.Value;
        }
    }

    internal partial class AadDataConnectorProperties
    {
        internal SecurityInsightsDataTypeConnectionState? DataTypesAlertsState
        {
            get => DataTypes?.Alerts?.State;
            set => DataConnectorWithAlertsProperties.SetAlertsState(DataTypes, value, dataTypes => DataTypes = dataTypes);
        }
    }

    internal partial class AatpDataConnectorProperties
    {
        internal SecurityInsightsDataTypeConnectionState? DataTypesAlertsState
        {
            get => DataTypes?.Alerts?.State;
            set => DataConnectorWithAlertsProperties.SetAlertsState(DataTypes, value, dataTypes => DataTypes = dataTypes);
        }
    }

    internal partial class MdatpDataConnectorProperties
    {
        internal SecurityInsightsDataTypeConnectionState? DataTypesAlertsState
        {
            get => DataTypes?.Alerts?.State;
            set => DataConnectorWithAlertsProperties.SetAlertsState(DataTypes, value, dataTypes => DataTypes = dataTypes);
        }
    }
}
