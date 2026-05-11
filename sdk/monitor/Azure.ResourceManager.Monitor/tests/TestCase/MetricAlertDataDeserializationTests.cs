// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class MetricAlertDataDeserializationTests
    {
        // Regression test for https://github.com/Azure/azure-sdk-for-net/issues/52787:
        // The service may return "targetResourceType": "" when no target resource type was set.
        // Deserialization should not throw and TargetResourceType should be null.
        [Test]
        public void Deserialize_EmptyTargetResourceType_DoesNotThrow()
        {
            string json = """
            {
                "id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Insights/metricAlerts/alert1",
                "name": "alert1",
                "type": "Microsoft.Insights/metricAlerts",
                "location": "global",
                "properties": {
                    "severity": 3,
                    "enabled": true,
                    "scopes": [
                        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/sa1"
                    ],
                    "evaluationFrequency": "PT1M",
                    "windowSize": "PT5M",
                    "targetResourceType": "",
                    "criteria": {
                        "odata.type": "Microsoft.Azure.Monitor.SingleResourceMultipleMetricCriteria",
                        "allOf": []
                    }
                }
            }
            """;

            MetricAlertData data = null;
            Assert.DoesNotThrow(() => data = ModelReaderWriter.Read<MetricAlertData>(BinaryData.FromString(json)));
            Assert.IsNotNull(data);
            Assert.IsNull(data.TargetResourceType);
        }

        [Test]
        public void Deserialize_WhitespaceTargetResourceType_DoesNotThrow()
        {
            string json = """
            {
                "id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Insights/metricAlerts/alert1",
                "name": "alert1",
                "type": "Microsoft.Insights/metricAlerts",
                "location": "global",
                "properties": {
                    "severity": 3,
                    "enabled": true,
                    "scopes": [
                        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/sa1"
                    ],
                    "evaluationFrequency": "PT1M",
                    "windowSize": "PT5M",
                    "targetResourceType": "   ",
                    "criteria": {
                        "odata.type": "Microsoft.Azure.Monitor.SingleResourceMultipleMetricCriteria",
                        "allOf": []
                    }
                }
            }
            """;

            MetricAlertData data = null;
            Assert.DoesNotThrow(() => data = ModelReaderWriter.Read<MetricAlertData>(BinaryData.FromString(json)));
            Assert.IsNotNull(data);
            Assert.IsNull(data.TargetResourceType);
        }

        [Test]
        public void Deserialize_NonEmptyTargetResourceType_RoundTrips()
        {
            string json = """
            {
                "id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Insights/metricAlerts/alert1",
                "name": "alert1",
                "type": "Microsoft.Insights/metricAlerts",
                "location": "global",
                "properties": {
                    "severity": 3,
                    "enabled": true,
                    "scopes": [
                        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/sa1"
                    ],
                    "evaluationFrequency": "PT1M",
                    "windowSize": "PT5M",
                    "targetResourceType": "Microsoft.Storage/storageAccounts",
                    "criteria": {
                        "odata.type": "Microsoft.Azure.Monitor.SingleResourceMultipleMetricCriteria",
                        "allOf": []
                    }
                }
            }
            """;

            MetricAlertData data = ModelReaderWriter.Read<MetricAlertData>(BinaryData.FromString(json));
            Assert.IsNotNull(data);
            Assert.IsNotNull(data.TargetResourceType);
            Assert.AreEqual("Microsoft.Storage/storageAccounts", data.TargetResourceType.Value.ToString());
        }
    }
}
