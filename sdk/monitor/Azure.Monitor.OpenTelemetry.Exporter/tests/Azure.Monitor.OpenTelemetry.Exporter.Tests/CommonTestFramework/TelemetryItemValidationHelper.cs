﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework
{
    internal static class TelemetryItemValidationHelper
    {
        public static void AssertMessageTelemetry(
            TelemetryItem telemetryItem,
            string? expectedSeverityLevel,
            string expectedMessage,
            IDictionary<string, string> expectedMessageProperties,
            string? expectedSpanId,
            string? expectedTraceId)
        {
            Assert.Equal("Message", telemetryItem.Name); // telemetry type
            Assert.Equal("MessageData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            var expectedTagsCount = 3;

            if (expectedSpanId != null && expectedTraceId != null)
            {
                expectedTagsCount = 5;

                Assert.Equal(expectedSpanId, telemetryItem.Tags["ai.operation.parentId"]);
                Assert.Equal(expectedTraceId, telemetryItem.Tags["ai.operation.id"]);
            }

            Assert.Equal(expectedTagsCount, telemetryItem.Tags.Count);
            Assert.Contains("ai.cloud.role", telemetryItem.Tags.Keys);
            Assert.Contains("ai.cloud.roleInstance", telemetryItem.Tags.Keys);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            var messageData = (MessageData)telemetryItem.Data.BaseData;

            if (expectedSeverityLevel == null)
            {
                Assert.Null(messageData.SeverityLevel);
            }
            else
            {
                Assert.Equal(expectedSeverityLevel, messageData.SeverityLevel);
            }

            Assert.Equal(expectedMessage, messageData.Message);

            foreach (var prop in expectedMessageProperties)
            {
                Assert.Equal(prop.Value, messageData.Properties[prop.Key]);
            }
        }

        public static void AssertLog_As_ExceptionTelemetry(
            TelemetryItem telemetryItem,
            string expectedSeverityLevel,
            string expectedMessage,
            string expectedTypeName)
        {
            Assert.Equal("Exception", telemetryItem.Name); // telemetry type
            Assert.Equal("ExceptionData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            Assert.Equal(3, telemetryItem.Tags.Count);
            Assert.Contains("ai.cloud.role", telemetryItem.Tags.Keys);
            Assert.Contains("ai.cloud.roleInstance", telemetryItem.Tags.Keys);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            var telemetryExceptionData = (TelemetryExceptionData)telemetryItem.Data.BaseData;
            Assert.Equal(expectedSeverityLevel, telemetryExceptionData.SeverityLevel);

            Assert.Equal(1, telemetryExceptionData.Exceptions.Count);

            var telemetryExceptionDetails = (TelemetryExceptionDetails)telemetryExceptionData.Exceptions[0];
            Assert.Equal(expectedMessage, telemetryExceptionDetails.Message);
            Assert.Equal(expectedTypeName, telemetryExceptionDetails.TypeName);
            Assert.True(telemetryExceptionDetails.ParsedStack.Any());
            Assert.Null(telemetryExceptionDetails.Stack);
        }

        public static void AssertActivity_As_DependencyTelemetry(
            TelemetryItem telemetryItem,
            string expectedName,
            string? expectedTraceId,
            string? expectedSpanId,
            IDictionary<string, string>? expectedProperties,
            string expectedAuthUserId,
            bool expectedSuccess = true)
        {
            Assert.Equal("RemoteDependency", telemetryItem.Name); // telemetry type
            Assert.Equal("RemoteDependencyData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            Assert.Equal(5, telemetryItem.Tags.Count);
            Assert.Equal(expectedTraceId, telemetryItem.Tags["ai.operation.id"]);
            Assert.Equal(expectedAuthUserId, telemetryItem.Tags["ai.user.authUserId"]);
            Assert.Contains("ai.cloud.role", telemetryItem.Tags.Keys);
            Assert.Contains("ai.cloud.roleInstance", telemetryItem.Tags.Keys);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            var remoteDependencyData = (RemoteDependencyData)telemetryItem.Data.BaseData;
            Assert.Equal(expectedSpanId, remoteDependencyData.Id);
            Assert.Equal(expectedName, remoteDependencyData.Name);
            Assert.Equal(expectedSuccess, remoteDependencyData.Success);

            if (expectedProperties == null)
            {
                Assert.Empty(remoteDependencyData.Properties);
            }
            else
            {
                foreach (var prop in expectedProperties)
                {
                    Assert.Equal(prop.Value, remoteDependencyData.Properties[prop.Key]);
                }
            }
        }

        public static void AssertActivity_As_RequestTelemetry(
            TelemetryItem telemetryItem,
            ActivityKind activityKind,
            string expectedName,
            string? expectedTraceId,
            IDictionary<string, string> expectedProperties,
            string? expectedSpanId,
            string expectedAuthUserId,
            bool expectedSuccess = true)
        {
            Assert.Equal("Request", telemetryItem.Name); // telemetry type
            Assert.Equal("RequestData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            var expectedTagsCount = 6;

            Assert.Equal(expectedTagsCount, telemetryItem.Tags.Count);
            Assert.Equal(expectedTraceId, telemetryItem.Tags["ai.operation.id"]);
            Assert.Equal(expectedAuthUserId, telemetryItem.Tags["ai.user.authUserId"]);
            Assert.Contains("ai.cloud.role", telemetryItem.Tags.Keys);
            Assert.Contains("ai.cloud.roleInstance", telemetryItem.Tags.Keys);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            var requestData = (RequestData)telemetryItem.Data.BaseData;
            Assert.Equal(expectedName, requestData.Name);
            Assert.Equal(expectedSpanId, requestData.Id);
            Assert.Equal(expectedSuccess, requestData.Success);

            if (expectedProperties == null)
            {
                Assert.Empty(requestData.Properties);
            }
            else
            {
                foreach (var prop in expectedProperties)
                {
                    Assert.Equal(prop.Value, requestData.Properties[prop.Key]);
                }
            }
        }

        internal static void AssertActivity_RecordedException(
            TelemetryItem telemetryItem,
            string expectedExceptionMessage,
            string expectedExceptionTypeName,
            string? expectedTraceId,
            string? expectedSpanId)
        {
            Assert.Equal("Exception", telemetryItem.Name); // telemetry type
            Assert.Equal("ExceptionData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            Assert.Equal(5, telemetryItem.Tags.Count);
            Assert.Equal(expectedSpanId, telemetryItem.Tags["ai.operation.parentId"]);
            Assert.Equal(expectedTraceId, telemetryItem.Tags["ai.operation.id"]);
            Assert.Contains("ai.cloud.role", telemetryItem.Tags.Keys);
            Assert.Contains("ai.cloud.roleInstance", telemetryItem.Tags.Keys);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            var telemetryExceptionData = (TelemetryExceptionData)telemetryItem.Data.BaseData;
            Assert.Null(telemetryExceptionData.SeverityLevel);
            Assert.Empty(telemetryExceptionData.Properties);

            Assert.Equal(1, telemetryExceptionData.Exceptions.Count);

            var telemetryExceptionDetails = (TelemetryExceptionDetails)telemetryExceptionData.Exceptions[0];
            Assert.Equal(expectedExceptionMessage, telemetryExceptionDetails.Message);
            Assert.Equal(expectedExceptionTypeName, telemetryExceptionDetails.TypeName);
            Assert.True(telemetryExceptionDetails.HasFullStack);
            Assert.Empty(telemetryExceptionDetails.ParsedStack);
            Assert.False(string.IsNullOrEmpty(telemetryExceptionDetails.Stack));
        }

        public static void AssertMetricTelemetry(
            TelemetryItem telemetryItem,
            string expectedMetricDataPointName,
            double expectedMetricDataPointValue,
            int? expectedMetricDataPointCount = null,
            double? expectedMetricDataPointMax = null,
            double? expectedMetricDataPointMin = null,
            double? expectedMetricDataPointStdDev = null,
            Dictionary<string, string>? expectedMetricsProperties = null)
        {
            Assert.Equal("Metric", telemetryItem.Name); // telemetry type
            Assert.Equal("MetricData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            Assert.Equal(3, telemetryItem.Tags.Count);
            Assert.Contains("ai.cloud.role", telemetryItem.Tags.Keys);
            Assert.Contains("ai.cloud.roleInstance", telemetryItem.Tags.Keys);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            var metricsData = (MetricsData)telemetryItem.Data.BaseData;

            var metricDataPoint = metricsData.Metrics[0];
            Assert.Equal(expectedMetricDataPointName, metricDataPoint.Name);
            Assert.Equal(expectedMetricDataPointCount, metricDataPoint.Count);
            Assert.Equal(expectedMetricDataPointMax, metricDataPoint.Max);
            Assert.Equal(expectedMetricDataPointMin, metricDataPoint.Min);
            Assert.Equal(expectedMetricDataPointStdDev, metricDataPoint.StdDev);
            Assert.Equal(expectedMetricDataPointValue, metricDataPoint.Value);

            if (expectedMetricsProperties != null)
            {
                foreach (var prop in expectedMetricsProperties)
                {
                    Assert.Equal(prop.Value, metricsData.Properties[prop.Key]);
                }
            }
        }
    }
}
