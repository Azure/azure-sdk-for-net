// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.SecurityInsights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests
{
    public class FlattenedDataConnectorTests
    {
        [Test]
        public void McasConstructorAndDiscoveryLogsSerializeFlattenedStates()
        {
            var model = new McasDataConnectorDataTypes(SecurityInsightsDataTypeConnectionState.Enabled)
            {
                DiscoveryLogsState = SecurityInsightsDataTypeConnectionState.Disabled
            };

            Assert.AreEqual(SecurityInsightsDataTypeConnectionState.Enabled, model.AlertsState);
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")).ToString());
            Assert.AreEqual("Enabled", json.RootElement.GetProperty("alerts").GetProperty("state").GetString());
            Assert.AreEqual("Disabled", json.RootElement.GetProperty("discoveryLogs").GetProperty("state").GetString());
        }

        [Test]
        public void GaParameterlessConstructorAndNullableAlertsStateRemainAvailable()
        {
            var model = new SecurityInsightsAlertsDataTypeOfDataConnector();
            SecurityInsightsDataTypeConnectionState? state = SecurityInsightsDataTypeConnectionState.Enabled;
            model.AlertsState = state;
            Assert.AreEqual(state, model.AlertsState);
        }
    }
}
