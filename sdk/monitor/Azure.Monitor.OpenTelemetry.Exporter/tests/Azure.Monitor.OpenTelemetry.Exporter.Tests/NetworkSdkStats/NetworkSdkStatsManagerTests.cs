// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.NetworkSdkStats
{
    public class NetworkSdkStatsManagerTests
    {
        [Theory]
        [InlineData("westus-0.in.applicationinsights.azure.com", "westus-0")]
        [InlineData("westus2-1.in.applicationinsights.azure.com", "westus2-1")]
        [InlineData("eastus", "eastus")]
        [InlineData("www.westeurope-5.in.applicationinsights.azure.com", "westeurope-5")]
        [InlineData("", "unknown")]
        [InlineData(null, "unknown")]
        public void ExtractStampHost_ReturnsStampSpecificRegion(string? input, string expected)
        {
            Assert.Equal(expected, NetworkSdkStatsHelper.ExtractStampHost(input));
        }

        [Fact]
        public void BuildBaseTags_IncludesAllRequiredDimensions()
        {
            var connectionVars = ConnectionStringParser.GetValues(
                "InstrumentationKey=00000000-0000-0000-0000-000000000001;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/");

            var manager = new NetworkSdkStatsManager(connectionVars, new MockPlatform());

            var tags = manager.BuildBaseTags("westus-0");

            // All dimensions required by the Network SDKStats spec for Request_Success_Count.
            Assert.Contains(tags, t => t.Key == "rp");
            Assert.Contains(tags, t => t.Key == "attach");
            Assert.Contains(tags, t => t.Key == "cikey" && (string?)t.Value == "00000000-0000-0000-0000-000000000001");
            Assert.Contains(tags, t => t.Key == "runtimeVersion");
            Assert.Contains(tags, t => t.Key == "os");
            Assert.Contains(tags, t => t.Key == "language" && (string?)t.Value == "dotnet");
            Assert.Contains(tags, t => t.Key == "version");
            Assert.Contains(tags, t => t.Key == "endpoint" && (string?)t.Value == StatsbeatConstants.NetworkSdkStatsEndpointBreeze);
            Assert.Contains(tags, t => t.Key == "host" && (string?)t.Value == "westus-0");
        }

        [Fact]
        public void TrackSuccess_RecordsRequestSuccessCount()
        {
            var connectionVars = ConnectionStringParser.GetValues(
                "InstrumentationKey=00000000-0000-0000-0000-000000000002;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/");
            var manager = new NetworkSdkStatsManager(connectionVars, new MockPlatform());

            long recorded = 0;
            string? observedHost = null;

            using var listener = new MeterListener
            {
                InstrumentPublished = (instrument, l) =>
                {
                    if (instrument.Meter.Name == StatsbeatConstants.NetworkSdkStatsMeterName
                        && instrument.Name == "Request_Success_Count")
                    {
                        l.EnableMeasurementEvents(instrument);
                    }
                },
            };
            listener.SetMeasurementEventCallback<long>((_, value, tags, _) =>
            {
                recorded += value;
                foreach (var t in tags)
                {
                    if (t.Key == "host")
                    {
                        observedHost = t.Value as string;
                    }
                }
            });
            listener.Start();

            manager.TrackSuccess("westus-0.in.applicationinsights.azure.com");

            Assert.Equal(1, recorded);
            Assert.Equal("westus-0", observedHost);
        }

        [Fact]
        public void TrackPartialSuccessAccepted_RecordsRequestSuccessCountWithAcceptedCount()
        {
            var connectionVars = ConnectionStringParser.GetValues(
                "InstrumentationKey=00000000-0000-0000-0000-000000000003;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/");
            var manager = new NetworkSdkStatsManager(connectionVars, new MockPlatform());

            long recorded = 0;
            using var listener = new MeterListener
            {
                InstrumentPublished = (instrument, l) =>
                {
                    if (instrument.Meter.Name == StatsbeatConstants.NetworkSdkStatsMeterName
                        && instrument.Name == "Request_Success_Count")
                    {
                        l.EnableMeasurementEvents(instrument);
                    }
                },
            };
            listener.SetMeasurementEventCallback<long>((_, value, _, _) => recorded += value);
            listener.Start();

            manager.TrackPartialSuccessAccepted("westus-0.in.applicationinsights.azure.com", 7);

            Assert.Equal(7, recorded);
        }

        [Fact]
        public void TrackPartialSuccessAccepted_ZeroOrNegativeCount_DoesNotRecord()
        {
            var connectionVars = ConnectionStringParser.GetValues(
                "InstrumentationKey=00000000-0000-0000-0000-000000000004;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/");
            var manager = new NetworkSdkStatsManager(connectionVars, new MockPlatform());

            long recorded = 0;
            using var listener = new MeterListener
            {
                InstrumentPublished = (instrument, l) =>
                {
                    if (instrument.Meter.Name == StatsbeatConstants.NetworkSdkStatsMeterName
                        && instrument.Name == "Request_Success_Count")
                    {
                        l.EnableMeasurementEvents(instrument);
                    }
                },
            };
            listener.SetMeasurementEventCallback<long>((_, value, _, _) => recorded += value);
            listener.Start();

            manager.TrackPartialSuccessAccepted("westus-0.in.applicationinsights.azure.com", 0);
            manager.TrackPartialSuccessAccepted("westus-0.in.applicationinsights.azure.com", -3);

            Assert.Equal(0, recorded);
        }

        [Theory]
        [InlineData(401, true)]
        [InlineData(403, true)]
        [InlineData(408, true)]
        [InlineData(429, true)]
        [InlineData(500, true)]
        [InlineData(502, true)]
        [InlineData(503, true)]
        [InlineData(504, true)]
        [InlineData(402, false)]
        [InlineData(439, false)]
        [InlineData(400, false)]
        [InlineData(404, false)]
        [InlineData(200, false)]
        public void IsRetryable_MatchesBreezeSpec(int statusCode, bool expected)
        {
            Assert.Equal(expected, NetworkSdkStatsHelper.IsRetryable(statusCode));
        }

        [Theory]
        [InlineData(402, true)]
        [InlineData(439, true)]
        [InlineData(429, false)]
        [InlineData(503, false)]
        [InlineData(400, false)]
        [InlineData(200, false)]
        public void IsThrottle_MatchesBreezeSpec(int statusCode, bool expected)
        {
            Assert.Equal(expected, NetworkSdkStatsHelper.IsThrottle(statusCode));
        }

        [Fact]
        public void TrackDuration_RecordsRequestDuration()
        {
            var manager = CreateManager("00000000-0000-0000-0000-000000000010");

            double recorded = 0;
            string? observedHost = null;
            using var listener = CreateHistogramListener("Request_Duration", (value, tags) =>
            {
                recorded += value;
                observedHost = GetTag(tags, "host");
            });
            listener.Start();

            manager.TrackDuration("westus-0.in.applicationinsights.azure.com", 123.5);

            Assert.Equal(123.5, recorded);
            Assert.Equal("westus-0", observedHost);
        }

        [Fact]
        public void TrackResponseFailure_NonRetriableStatus_RecordsRequestFailureCountWithStatusCode()
        {
            var manager = CreateManager("00000000-0000-0000-0000-000000000011");

            long recorded = 0;
            int? observedStatusCode = null;
            using var listener = CreateCounterListener("Request_Failure_Count", (value, tags) =>
            {
                recorded += value;
                observedStatusCode = GetIntTag(tags, "statusCode");
            });
            listener.Start();

            manager.TrackResponseFailure("westus-0.in.applicationinsights.azure.com", 404);

            Assert.Equal(1, recorded);
            Assert.Equal(404, observedStatusCode);
        }

        [Fact]
        public void TrackResponseFailure_RetriableStatus_RecordsRetryCount()
        {
            var manager = CreateManager("00000000-0000-0000-0000-000000000012");

            long recorded = 0;
            int? observedStatusCode = null;
            using var listener = CreateCounterListener("Retry_Count", (value, tags) =>
            {
                recorded += value;
                observedStatusCode = GetIntTag(tags, "statusCode");
            });
            listener.Start();

            manager.TrackResponseFailure("westus-0.in.applicationinsights.azure.com", 503);

            Assert.Equal(1, recorded);
            Assert.Equal(503, observedStatusCode);
        }

        [Fact]
        public void TrackResponseFailure_ThrottleStatus_RecordsThrottleCount()
        {
            var manager = CreateManager("00000000-0000-0000-0000-000000000013");

            long recorded = 0;
            int? observedStatusCode = null;
            using var listener = CreateCounterListener("Throttle_Count", (value, tags) =>
            {
                recorded += value;
                observedStatusCode = GetIntTag(tags, "statusCode");
            });
            listener.Start();

            manager.TrackResponseFailure("westus-0.in.applicationinsights.azure.com", 439);

            Assert.Equal(1, recorded);
            Assert.Equal(439, observedStatusCode);
        }

        [Theory]
        [InlineData(200)]
        [InlineData(206)]
        [InlineData(307)]
        [InlineData(308)]
        public void TrackResponseFailure_SuccessPartialOrRedirect_DoesNotRecord(int statusCode)
        {
            var manager = CreateManager("00000000-0000-0000-0000-000000000014");

            long recorded = 0;
            using var failureListener = CreateCounterListener("Request_Failure_Count", (value, _) => recorded += value);
            using var retryListener = CreateCounterListener("Retry_Count", (value, _) => recorded += value);
            using var throttleListener = CreateCounterListener("Throttle_Count", (value, _) => recorded += value);
            failureListener.Start();
            retryListener.Start();
            throttleListener.Start();

            manager.TrackResponseFailure("westus-0.in.applicationinsights.azure.com", statusCode);

            Assert.Equal(0, recorded);
        }

        [Fact]
        public void TrackException_RecordsExceptionCountWithExceptionType()
        {
            var manager = CreateManager("00000000-0000-0000-0000-000000000015");

            long recorded = 0;
            string? observedExceptionType = null;
            using var listener = CreateCounterListener("Exception_Count", (value, tags) =>
            {
                recorded += value;
                observedExceptionType = GetTag(tags, "exceptionType");
            });
            listener.Start();

            manager.TrackException("westus-0.in.applicationinsights.azure.com", "System.Net.Http.HttpRequestException");

            Assert.Equal(1, recorded);
            Assert.Equal("System.Net.Http.HttpRequestException", observedExceptionType);
        }

        [Fact]
        public void TrackException_NullExceptionType_RecordsUnknown()
        {
            var manager = CreateManager("00000000-0000-0000-0000-000000000016");

            string? observedExceptionType = null;
            using var listener = CreateCounterListener("Exception_Count", (_, tags) => observedExceptionType = GetTag(tags, "exceptionType"));
            listener.Start();

            manager.TrackException("westus-0.in.applicationinsights.azure.com", exceptionType: null);

            Assert.Equal("unknown", observedExceptionType);
        }

        [Fact]
        public void TrackException_NullHost_FallsBackToConfiguredIngestionHost()
        {
            var manager = CreateManager("00000000-0000-0000-0000-000000000017");

            string? observedHost = null;
            using var listener = CreateCounterListener("Exception_Count", (_, tags) => observedHost = GetTag(tags, "host"));
            listener.Start();

            manager.TrackException(requestHost: null, exceptionType: "System.TimeoutException");

            Assert.Equal("westus-0", observedHost);
        }

        private static NetworkSdkStatsManager CreateManager(string instrumentationKey)
        {
            var connectionVars = ConnectionStringParser.GetValues(
                $"InstrumentationKey={instrumentationKey};IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/");
            return new NetworkSdkStatsManager(connectionVars, new MockPlatform());
        }

        private static MeterListener CreateCounterListener(string instrumentName, Action<long, KeyValuePair<string, object?>[]> onMeasurement)
        {
            var listener = new MeterListener
            {
                InstrumentPublished = (instrument, l) =>
                {
                    if (instrument.Meter.Name == StatsbeatConstants.NetworkSdkStatsMeterName
                        && instrument.Name == instrumentName)
                    {
                        l.EnableMeasurementEvents(instrument);
                    }
                },
            };
            listener.SetMeasurementEventCallback<long>((_, value, tags, _) => onMeasurement(value, tags.ToArray()));
            return listener;
        }

        private static MeterListener CreateHistogramListener(string instrumentName, Action<double, KeyValuePair<string, object?>[]> onMeasurement)
        {
            var listener = new MeterListener
            {
                InstrumentPublished = (instrument, l) =>
                {
                    if (instrument.Meter.Name == StatsbeatConstants.NetworkSdkStatsMeterName
                        && instrument.Name == instrumentName)
                    {
                        l.EnableMeasurementEvents(instrument);
                    }
                },
            };
            listener.SetMeasurementEventCallback<double>((_, value, tags, _) => onMeasurement(value, tags.ToArray()));
            return listener;
        }

        private static string? GetTag(KeyValuePair<string, object?>[] tags, string key)
        {
            foreach (var t in tags)
            {
                if (t.Key == key)
                {
                    return t.Value as string;
                }
            }

            return null;
        }

        private static int? GetIntTag(KeyValuePair<string, object?>[] tags, string key)
        {
            foreach (var t in tags)
            {
                if (t.Key == key && t.Value is int value)
                {
                    return value;
                }
            }

            return null;
        }
    }
}
