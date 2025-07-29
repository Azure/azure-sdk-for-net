// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.TelemetryClient
{
    public class TraceTelemetryClientHttpMockTests : AbstractTelemetryClientHttpMockTest
    {
        [Fact]
        public async Task TrackTrace()
        {
            void ClientConsumer(TelemetryClient telemetryClient) =>
                telemetryClient.TrackTrace("Application Insights trace");

            await VerifyTrackMethod(ClientConsumer, "trace/expected-trace.json");
        }

        [Fact]
        public async Task TrackTraceWithWarningSeverityLevel()
        {
            void ClientConsumer(TelemetryClient telemetryClient) =>
                telemetryClient.TrackTrace("Warning message", SeverityLevel.Warning);

            await VerifyTrackMethod(ClientConsumer, "trace/expected-trace-with-warning-severity-level.json");
        }

        [Fact]
        public async Task TrackTraceWithInformationSeverityLevel()
        {
            void ClientConsumer(TelemetryClient telemetryClient) =>
                telemetryClient.TrackTrace("Information message", SeverityLevel.Information);

            await VerifyTrackMethod(ClientConsumer, "trace/expected-trace-with-information-severity-level.json");
        }

        [Fact]
        public async Task TrackTraceWithVerboseSeverityLevel()
        {
            void ClientConsumer(TelemetryClient telemetryClient) =>
                telemetryClient.TrackTrace("Verbose message", SeverityLevel.Verbose);

            await VerifyTrackMethod(ClientConsumer, "trace/expected-trace-with-verbose-severity-level.json");
        }

        [Fact]
        public async Task TrackTraceWithErrorSeverityLevel()
        {
            void ClientConsumer(TelemetryClient telemetryClient) =>
                telemetryClient.TrackTrace("Error message", SeverityLevel.Error);

            await VerifyTrackMethod(ClientConsumer, "trace/expected-trace-with-error-severity-level.json");
        }

        [Fact]
        public async Task TrackTraceWithCriticalSeverityLevel()
        {
            void ClientConsumer(TelemetryClient telemetryClient) =>
                telemetryClient.TrackTrace("Critical message", SeverityLevel.Critical);

            await VerifyTrackMethod(ClientConsumer, "trace/expected-trace-with-critical-severity-level.json");
        }

        [Fact]
        public async Task TrackTraceWithProperties()
        {
            void ClientConsumer(TelemetryClient telemetryClient)
            {
                var properties = new Dictionary<string, string> { { "Key1", "Value1" }, { "Key2", "Value2" } };
                telemetryClient.TrackTrace("Application Insights trace",
                    properties);
            }

            await VerifyTrackMethod(ClientConsumer, "trace/expected-trace-with-properties.json");
        }

        [Fact]
        public async Task TrackTraceWithSeverityLevelAndProperties()
        {
            var properties = new Dictionary<string, string> { { "Key1", "Value1" }, { "Key2", "Value2" } };

            void ClientConsumer(TelemetryClient telemetryClient) =>
                telemetryClient.TrackTrace("Application Insights trace", SeverityLevel.Error, properties);

            await VerifyTrackMethod(ClientConsumer, "trace/expected-trace-with-severity-level-and-properties.json");
        }

        [Fact]
        public async Task ContextGlobalProperties()
        {
            void ClientConsumer(TelemetryClient telemetryClient)
            {
                TelemetryContext telemetryClientContext = telemetryClient.Context;
                telemetryClientContext.GlobalProperties.Add("global-Key1", "global-Value1");
                telemetryClientContext.GlobalProperties.Add("global-Key2", "global-Value2");

                telemetryClient.TrackTrace("Application Insights trace");
            }

            await VerifyTrackMethod(ClientConsumer, "trace/expected-global-properties.json");
        }
    }
}
