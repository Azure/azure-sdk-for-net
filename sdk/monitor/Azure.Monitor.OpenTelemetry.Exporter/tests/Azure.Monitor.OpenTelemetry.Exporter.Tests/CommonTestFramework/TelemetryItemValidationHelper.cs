// Copyright (c) Microsoft Corporation. All rights reserved.
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
            string? expectedTraceId,
            string? expectedClientIp = null,
            string expectedCloudRole = "[testNamespace]/testName",
            string expectedCloudInstance = "testInstance",
            string expectedApplicationVersion = "testVersion")
        {
            Assert.Equal("Message", telemetryItem.Name); // telemetry type
            Assert.Equal("MessageData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            var expectedTagsCount = 4;

            if (expectedSpanId != null && expectedTraceId != null)
            {
                expectedTagsCount += 2;

                Assert.Equal(expectedSpanId, telemetryItem.Tags["ai.operation.parentId"]);
                Assert.Equal(expectedTraceId, telemetryItem.Tags["ai.operation.id"]);
            }

            if (expectedClientIp != null)
            {
                expectedTagsCount += 1;
                Assert.Equal(expectedClientIp, telemetryItem.Tags["ai.location.ip"]);
            }

            Assert.Equal(expectedTagsCount, telemetryItem.Tags.Count);
            Assert.Equal(expectedCloudRole, telemetryItem.Tags["ai.cloud.role"]);
            Assert.Equal(expectedApplicationVersion, telemetryItem.Tags["ai.application.ver"]);
            Assert.Equal(expectedCloudInstance, telemetryItem.Tags["ai.cloud.roleInstance"]);
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

        public static void AssertCustomEventTelemetry(
            TelemetryItem telemetryItem,
            string expectedName,
            IDictionary<string, string> expectedProperties,
            string? expectedSpanId,
            string? expectedTraceId,
            string? expectedClientIp = null,
            string expectedCloudRole = "[testNamespace]/testName",
            string expectedCloudInstance = "testInstance",
            string expectedApplicationVersion = "testVersion")
        {
            Assert.Equal("Event", telemetryItem.Name); // telemetry type
            Assert.Equal("EventData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            var expectedTagsCount = 4;

            if (expectedSpanId != null && expectedTraceId != null)
            {
                expectedTagsCount += 2;

                Assert.Equal(expectedSpanId, telemetryItem.Tags["ai.operation.parentId"]);
                Assert.Equal(expectedTraceId, telemetryItem.Tags["ai.operation.id"]);
            }

            if (expectedClientIp != null)
            {
                expectedTagsCount += 1;
                Assert.Equal(expectedClientIp, telemetryItem.Tags["ai.location.ip"]);
            }

            Assert.Equal(expectedTagsCount, telemetryItem.Tags.Count);
            Assert.Equal(expectedCloudRole, telemetryItem.Tags["ai.cloud.role"]);
            Assert.Equal(expectedApplicationVersion, telemetryItem.Tags["ai.application.ver"]);
            Assert.Equal(expectedCloudInstance, telemetryItem.Tags["ai.cloud.roleInstance"]);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            var eventData = (TelemetryEventData)telemetryItem.Data.BaseData;

            Assert.Equal(expectedName, eventData.Name);

            foreach (var prop in expectedProperties)
            {
                Assert.Equal(prop.Value, eventData.Properties[prop.Key]);
            }

            Assert.Equal(expectedProperties.Count, eventData.Properties.Count);
        }

        public static void AssertLog_As_ExceptionTelemetry(
            TelemetryItem telemetryItem,
            string expectedSeverityLevel,
            string expectedMessage,
            string expectedTypeName,
            IDictionary<string, string> expectedProperties,
            string expectedCloudRole = "[testNamespace]/testName",
            string expectedCloudInstance = "testInstance",
            string expectedApplicationVersion = "testVersion")
        {
            Assert.Equal("Exception", telemetryItem.Name); // telemetry type
            Assert.Equal("ExceptionData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            Assert.Equal(4, telemetryItem.Tags.Count);
            Assert.Equal(expectedCloudRole, telemetryItem.Tags["ai.cloud.role"]);
            Assert.Equal(expectedApplicationVersion, telemetryItem.Tags["ai.application.ver"]);
            Assert.Equal(expectedCloudInstance, telemetryItem.Tags["ai.cloud.roleInstance"]);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            var telemetryExceptionData = (TelemetryExceptionData)telemetryItem.Data.BaseData;
            Assert.Equal(expectedSeverityLevel, telemetryExceptionData.SeverityLevel);

            Assert.Equal(1, telemetryExceptionData.Exceptions.Count);

            var telemetryExceptionDetails = (TelemetryExceptionDetails)telemetryExceptionData.Exceptions[0];
            Assert.Equal(expectedMessage, telemetryExceptionDetails.Message);
            Assert.Equal(expectedTypeName, telemetryExceptionDetails.TypeName);
            Assert.True(telemetryExceptionDetails.ParsedStack.Any());
            Assert.Null(telemetryExceptionDetails.Stack);

            foreach (var prop in expectedProperties)
            {
                Assert.Equal(prop.Value, telemetryExceptionData.Properties[prop.Key]);
            }
        }

        public static void AssertActivity_As_DependencyTelemetry(
            TelemetryItem telemetryItem,
            string expectedName,
            string? expectedTraceId,
            string? expectedSpanId,
            IDictionary<string, string>? expectedProperties,
            string expectedAuthUserId,
            string expectedUserId,
            bool expectedSuccess = true,
            string expectedCloudRole = "[testNamespace]/testName",
            string expectedCloudInstance = "testInstance",
            string expectedApplicationVersion = "testVersion")
        {
            Assert.Equal("RemoteDependency", telemetryItem.Name); // telemetry type
            Assert.Equal("RemoteDependencyData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            Assert.Equal(7, telemetryItem.Tags.Count);
            Assert.Equal(expectedTraceId, telemetryItem.Tags["ai.operation.id"]);
            Assert.Equal(expectedAuthUserId, telemetryItem.Tags["ai.user.authUserId"]);
            Assert.Equal(expectedUserId, telemetryItem.Tags["ai.user.id"]);
            Assert.Equal(expectedApplicationVersion, telemetryItem.Tags["ai.application.ver"]);
            Assert.Equal(expectedCloudRole, telemetryItem.Tags["ai.cloud.role"]);
            Assert.Equal(expectedCloudInstance, telemetryItem.Tags["ai.cloud.roleInstance"]);
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
            string expectedUserId,
            bool expectedSuccess = true,
            string expectedCloudRole = "[testNamespace]/testName",
            string expectedCloudInstance = "testInstance",
            string expectedApplicationVersion = "testVersion")
        {
            Assert.Equal("Request", telemetryItem.Name); // telemetry type
            Assert.Equal("RequestData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            var expectedTagsCount = 8;

            Assert.Equal(expectedTagsCount, telemetryItem.Tags.Count);
            Assert.Equal(expectedTraceId, telemetryItem.Tags["ai.operation.id"]);
            Assert.Equal(expectedAuthUserId, telemetryItem.Tags["ai.user.authUserId"]);
            Assert.Equal(expectedUserId, telemetryItem.Tags["ai.user.id"]);
            Assert.Equal(expectedApplicationVersion, telemetryItem.Tags["ai.application.ver"]);
            Assert.Equal(expectedCloudRole, telemetryItem.Tags["ai.cloud.role"]);
            Assert.Equal(expectedCloudInstance, telemetryItem.Tags["ai.cloud.roleInstance"]);
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
            string? expectedSpanId,
            IDictionary<string, string>? expectedProperties,
            Action<TelemetryExceptionData>? additionalChecks = null,
            string expectedCloudRole = "[testNamespace]/testName",
            string expectedCloudInstance = "testInstance",
            string expectedApplicationVersion = "testVersion")
        {
            Assert.Equal("Exception", telemetryItem.Name); // telemetry type
            Assert.Equal("ExceptionData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            Assert.Equal(6, telemetryItem.Tags.Count);
            Assert.Equal(expectedSpanId, telemetryItem.Tags["ai.operation.parentId"]);
            Assert.Equal(expectedTraceId, telemetryItem.Tags["ai.operation.id"]);
            Assert.Equal(expectedCloudRole, telemetryItem.Tags["ai.cloud.role"]);
            Assert.Equal(expectedApplicationVersion, telemetryItem.Tags["ai.application.ver"]);
            Assert.Equal(expectedCloudInstance, telemetryItem.Tags["ai.cloud.roleInstance"]);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            var telemetryExceptionData = (TelemetryExceptionData)telemetryItem.Data.BaseData;
            Assert.Null(telemetryExceptionData.SeverityLevel);

            if (expectedProperties == null)
            {
                Assert.Empty(telemetryExceptionData.Properties);
            }
            else
            {
                foreach (var prop in expectedProperties)
                {
                    Assert.Equal(prop.Value, telemetryExceptionData.Properties[prop.Key]);
                }
            }

            Assert.Equal(1, telemetryExceptionData.Exceptions.Count);

            var telemetryExceptionDetails = (TelemetryExceptionDetails)telemetryExceptionData.Exceptions[0];
            Assert.Equal(expectedExceptionMessage, telemetryExceptionDetails.Message);
            Assert.Equal(expectedExceptionTypeName, telemetryExceptionDetails.TypeName);
            Assert.True(telemetryExceptionDetails.HasFullStack);
            Assert.Empty(telemetryExceptionDetails.ParsedStack);
            Assert.False(string.IsNullOrEmpty(telemetryExceptionDetails.Stack));

            additionalChecks?.Invoke(telemetryExceptionData);
        }

        public static void AssertMetricTelemetry(
            TelemetryItem telemetryItem,
            string expectedMetricDataPointName,
            double expectedMetricDataPointValue,
            int? expectedMetricDataPointCount = null,
            double? expectedMetricDataPointMax = null,
            double? expectedMetricDataPointMin = null,
            double? expectedMetricDataPointStdDev = null,
            Dictionary<string, string>? expectedMetricsProperties = null,
            string expectedCloudRole = "[testNamespace]/testName",
            string expectedCloudInstance = "testInstance",
            string expectedApplicationVersion = "testVersion")
        {
            Assert.Equal("Metric", telemetryItem.Name); // telemetry type
            Assert.Equal("MetricData", telemetryItem.Data.BaseType); // telemetry data type
            Assert.Equal(2, telemetryItem.Data.BaseData.Version); // telemetry api version
            Assert.Equal("00000000-0000-0000-0000-000000000000", telemetryItem.InstrumentationKey);

            Assert.Equal(4, telemetryItem.Tags.Count);
            Assert.Equal(expectedCloudRole, telemetryItem.Tags["ai.cloud.role"]);
            Assert.Equal(expectedApplicationVersion, telemetryItem.Tags["ai.application.ver"]);
            Assert.Equal(expectedCloudInstance, telemetryItem.Tags["ai.cloud.roleInstance"]);
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
