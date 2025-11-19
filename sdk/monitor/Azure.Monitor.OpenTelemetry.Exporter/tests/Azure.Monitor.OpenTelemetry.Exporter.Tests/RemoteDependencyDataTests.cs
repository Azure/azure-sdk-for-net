// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry.Trace;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class RemoteDependencyDataTests
    {
        private const string ActivitySourceName = "RemoteDependencyDataTests";
        private const string ActivityName = "RemoteDependencyDataActivity";

        static RemoteDependencyDataTests()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);
        }

        [Theory]
        [InlineData("mssql")]
        [InlineData("microsoft.sql_server")]
        [InlineData("redis")]
        public void ValidateDBDependencyType(string dbSystem)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.SetTag(SemanticConventions.AttributeDbSystem, dbSystem);

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyDataType = new RemoteDependencyData(2, activity, ref activityTagsProcessor).Type;
            var expectedType = AzMonListExtensions.s_dbSystems.Contains(dbSystem) ? "SQL" : dbSystem;

            Assert.Equal(expectedType, remoteDependencyDataType);
        }

        [Fact]
        public void DependencyTypeIsSetToInProcForInternalSpan()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity("Activity", ActivityKind.Internal);

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyDataType = new RemoteDependencyData(2, activity, ref activityTagsProcessor).Type;

            Assert.Equal("InProc", remoteDependencyDataType);
        }

        [Theory]
        [InlineData(ActivityKind.Client)]
        [InlineData(ActivityKind.Producer)]
        [InlineData(ActivityKind.Internal)]
        public void RemoteDependencyTypeReflectsAzureNamespace(ActivityKind activityKind)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity("Activity", activityKind);
            activity?.AddTag("az.namespace", "DemoAzureResource");

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.Equal("DemoAzureResource", activityTagsProcessor.AzureNamespace);
            if (activity.Kind == ActivityKind.Internal)
            {
                Assert.Equal("InProc | DemoAzureResource", remoteDependencyData.Type);
            }
            else if (activity.Kind == ActivityKind.Producer)
            {
                Assert.Equal("Queue Message | DemoAzureResource", remoteDependencyData.Type);
            }
            else
            {
                Assert.Equal("DemoAzureResource", remoteDependencyData.Type);
            }
        }

        [Fact]
        public void ValidateHttpRemoteDependencyData()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            Assert.NotNull(activity);
            activity.Stop();

            var httpUrl = "https://www.foo.bar/search";
            activity.SetStatus(ActivityStatusCode.Ok);
            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpUrl, httpUrl); // only adding test via http.url. all possible combinations are covered in AzMonListExtensionsTests.
            activity.SetTag(SemanticConventions.AttributeHttpHost, "www.foo.bar");
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, "200");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.Equal("GET /search", remoteDependencyData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), remoteDependencyData.Id);
            Assert.Equal(httpUrl, remoteDependencyData.Data);
            Assert.Equal("www.foo.bar", remoteDependencyData.Target);
            Assert.Equal("200", remoteDependencyData.ResultCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), remoteDependencyData.Duration);
            Assert.Equal(activity.Status != ActivityStatusCode.Error, remoteDependencyData.Success);
            Assert.True(remoteDependencyData.Properties.Count == 0);
            Assert.True(remoteDependencyData.Measurements.Count == 0);
        }

        [Fact]
        public void ValidateOldDbRemoteDependencyData()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            Assert.NotNull(activity);
            activity.Stop();

            activity.SetStatus(ActivityStatusCode.Ok);
            activity.SetTag(SemanticConventions.AttributeDbName, "mysqlserver");
            activity.SetTag(SemanticConventions.AttributeDbSystem, "mssql");
            activity.SetTag(SemanticConventions.AttributePeerService, "localhost"); // only adding test via peer.service. all possible combinations are covered in AzMonListExtensionsTests.
            activity.SetTag(SemanticConventions.AttributeDbStatement, "Select * from table");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.Equal(ActivityName, remoteDependencyData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), remoteDependencyData.Id);
            Assert.Equal("Select * from table", remoteDependencyData.Data);
            Assert.Equal("localhost | mysqlserver", remoteDependencyData.Target);
            Assert.Null(remoteDependencyData.ResultCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), remoteDependencyData.Duration);
            Assert.Equal(activity.Status != ActivityStatusCode.Error, remoteDependencyData.Success);
            Assert.True(remoteDependencyData.Properties.Count == 1);
            Assert.True(remoteDependencyData.Properties.Contains(new KeyValuePair<string, string>(SemanticConventions.AttributeDbName, "mysqlserver" )));
            Assert.True(remoteDependencyData.Measurements.Count == 0);
        }

        [Fact]
        public void ValidateNewDbRemoteDependencyData()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            Assert.NotNull(activity);
            activity.Stop();

            activity.SetStatus(ActivityStatusCode.Ok);
            activity.SetTag(SemanticConventions.AttributeDbNamespace, "mysqlserver");
            activity.SetTag(SemanticConventions.AttributeDbSystemName, "mssql");
            activity.SetTag(SemanticConventions.AttributePeerService, "localhost"); // only adding test via peer.service. all possible combinations are covered in AzMonListExtensionsTests.
            activity.SetTag(SemanticConventions.AttributeDbQueryText, "Select * from table");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.Equal(ActivityName, remoteDependencyData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), remoteDependencyData.Id);
            Assert.Equal("Select * from table", remoteDependencyData.Data);
            Assert.Equal("localhost | mysqlserver", remoteDependencyData.Target);
            Assert.Null(remoteDependencyData.ResultCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), remoteDependencyData.Duration);
            Assert.Equal(activity.Status != ActivityStatusCode.Error, remoteDependencyData.Success);
            Assert.True(remoteDependencyData.Properties.Count == 1);
            Assert.True(remoteDependencyData.Properties.Contains(new KeyValuePair<string, string>(SemanticConventions.AttributeDbName, "mysqlserver" )));
            Assert.True(remoteDependencyData.Measurements.Count == 0);
        }

        [Fact]
        public void HttpDependencyNameIsActivityDisplayNameByDefault()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");

            activity.DisplayName = "HTTP GET";

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyDataName = new RemoteDependencyData(2, activity, ref activityTagsProcessor).Name;

            Assert.Equal(activity.DisplayName, remoteDependencyDataName);
        }

        [Fact]
        public void VerifyAllDependenciesSetTargetViaServerAddress()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.SetTag(SemanticConventions.AttributeServerAddress, "unitTestAddress");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.Equal("unitTestAddress", remoteDependencyData.Target);
        }

        [Fact]
        public void VerifyAllDependenciesSetTargetViaServerAddressAndPort()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.SetTag(SemanticConventions.AttributeServerAddress, "unitTestAddress");
            activity.SetTag(SemanticConventions.AttributeServerPort, "unitTestPort");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.Equal("unitTestAddress:unitTestPort", remoteDependencyData.Target);
        }
    }
}
