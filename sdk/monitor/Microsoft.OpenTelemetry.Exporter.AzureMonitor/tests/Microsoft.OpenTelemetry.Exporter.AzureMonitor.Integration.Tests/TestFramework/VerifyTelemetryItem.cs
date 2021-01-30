// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;

using Xunit;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.TestFramework
{
    internal static class VerifyTelemetryItem
    {
        public static void Verify(TelemetryItem telemetryItem, ActivityKind activityKind, ExpectedTelemetryItemValues expectedVars)
        {
            switch (activityKind)
            {
                case ActivityKind.Client:
                case ActivityKind.Producer:
                case ActivityKind.Internal:
                    VerifyDependency(telemetryItem, expectedVars);
                    break;
                case ActivityKind.Consumer:
                case ActivityKind.Server:
                    VerifyRequest(telemetryItem, expectedVars);
                    break;
                default:
                    throw new Exception($"unknown ActivityKind '{activityKind}'");
            }
        }

        public static void VerifyRequest(TelemetryItem telemetryItem, ExpectedTelemetryItemValues expectedVars)
        {
            Assert.Equal("Request", telemetryItem.Name);
            Assert.Equal(nameof(RequestData), telemetryItem.Data.BaseType);

            var data = (RequestData)telemetryItem.Data.BaseData;
            Assert.Equal(expectedVars.Name, data.Name);
            Assert.Equal(expectedVars.CustomProperties, data.Properties);
        }

        public static void VerifyDependency(TelemetryItem telemetryItem, ExpectedTelemetryItemValues expectedVars)
        {
            Assert.Equal("RemoteDependency", telemetryItem.Name);
            Assert.Equal(nameof(RemoteDependencyData), telemetryItem.Data.BaseType);

            var data = (RemoteDependencyData)telemetryItem.Data.BaseData;
            Assert.Equal(expectedVars.Name, data.Name);
            Assert.Equal(expectedVars.CustomProperties, data.Properties);
        }

        public static void VerifyEvent(TelemetryItem telemetryItem, ExpectedTelemetryItemValues expectedVars)
        {
            Assert.Equal("Message", telemetryItem.Name);
            Assert.Equal(nameof(MessageData), telemetryItem.Data.BaseType);

            var data = (MessageData)telemetryItem.Data.BaseData;
            Assert.Equal(expectedVars.Message, data.Message);
            Assert.Equal(expectedVars.SeverityLevel, data.SeverityLevel);
            Assert.Equal(expectedVars.SpanId, telemetryItem.Tags["ai.operation.parentId"]);
            Assert.Equal(expectedVars.TraceId, telemetryItem.Tags["ai.operation.id"]);
        }
    }
}
