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

        [Theory]
        [InlineData(SemanticConventions.AttributeMicrosoftDependencyType, "CustomType")]
        [InlineData(SemanticConventions.AttributeMicrosoftDependencyData, "CustomData")]
        [InlineData(SemanticConventions.AttributeMicrosoftDependencyName, "CustomName")]
        [InlineData(SemanticConventions.AttributeMicrosoftDependencyTarget, "CustomTarget")]
        [InlineData(SemanticConventions.AttributeMicrosoftDependencyResultCode, "CustomResult")]
        public void MicrosoftOverrideAttributeTakesPrecedenceOverSemanticConventions(string overrideAttribute, string expectedValue)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(ActivityName, ActivityKind.Client);
            Assert.NotNull(activity);

            // Set semantic convention attributes (HTTP dependency)
            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpUrl, "https://example.com/api");
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, "200");

            // Set Microsoft override attribute
            activity.SetTag(overrideAttribute, expectedValue);

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            // Verify override took precedence
            switch (overrideAttribute)
            {
                case SemanticConventions.AttributeMicrosoftDependencyType:
                    Assert.Equal(expectedValue, remoteDependencyData.Type);
                    break;
                case SemanticConventions.AttributeMicrosoftDependencyData:
                    Assert.Equal(expectedValue, remoteDependencyData.Data);
                    break;
                case SemanticConventions.AttributeMicrosoftDependencyName:
                    Assert.Equal(expectedValue, remoteDependencyData.Name);
                    break;
                case SemanticConventions.AttributeMicrosoftDependencyTarget:
                    Assert.Equal(expectedValue, remoteDependencyData.Target);
                    break;
                case SemanticConventions.AttributeMicrosoftDependencyResultCode:
                    Assert.Equal(expectedValue, remoteDependencyData.ResultCode);
                    break;
            }
        }

        [Theory]
        [InlineData("Http", SemanticConventions.AttributeHttpMethod, "GET", SemanticConventions.AttributeHttpUrl, "https://api.example.com")]
        [InlineData("SQL", SemanticConventions.AttributeDbSystem, "mssql", SemanticConventions.AttributeDbStatement, "SELECT * FROM users")]
        [InlineData("servicebus", SemanticConventions.AttributeMessagingSystem, "servicebus", SemanticConventions.AttributeMessagingDestinationName, "myqueue")]
        public void MicrosoftOverrideAttributesWorkWithAllDependencyTypes(string expectedDefaultType, string conventionKey1, string conventionValue1, string conventionKey2, string conventionValue2)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(ActivityName, ActivityKind.Client);
            Assert.NotNull(activity);

            // Set semantic convention attributes for specific dependency type
            activity.SetTag(conventionKey1, conventionValue1);
            activity.SetTag(conventionKey2, conventionValue2);

            // Without override - verify semantic conventions are used
            var activityTagsProcessor1 = TraceHelper.EnumerateActivityTags(activity);
            var remoteDependencyData1 = new RemoteDependencyData(2, activity, ref activityTagsProcessor1);
            Assert.Equal(expectedDefaultType, remoteDependencyData1.Type);

            // Add override attributes
            activity.SetTag(SemanticConventions.AttributeMicrosoftDependencyType, "OverriddenType");
            activity.SetTag(SemanticConventions.AttributeMicrosoftDependencyData, "OverriddenData");
            activity.SetTag(SemanticConventions.AttributeMicrosoftDependencyTarget, "OverriddenTarget");

            // With override - verify overrides take precedence
            var activityTagsProcessor2 = TraceHelper.EnumerateActivityTags(activity);
            var remoteDependencyData2 = new RemoteDependencyData(2, activity, ref activityTagsProcessor2);
            Assert.Equal("OverriddenType", remoteDependencyData2.Type);
            Assert.Equal("OverriddenData", remoteDependencyData2.Data);
            Assert.Equal("OverriddenTarget", remoteDependencyData2.Target);
        }

        [Fact]
        public void HasOverrideAttributesFlagIsSetWhenOverrideAttributesPresent()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(ActivityName, ActivityKind.Client);
            Assert.NotNull(activity);

            // Without override attributes
            var activityTagsProcessor1 = TraceHelper.EnumerateActivityTags(activity);
            Assert.False(activityTagsProcessor1.HasOverrideAttributes);

            // With override attribute
            activity.SetTag(SemanticConventions.AttributeMicrosoftDependencyType, "CustomType");
            var activityTagsProcessor2 = TraceHelper.EnumerateActivityTags(activity);
            Assert.True(activityTagsProcessor2.HasOverrideAttributes);
        }

        [Fact]
        public void MultipleOverrideAttributesAllApplied()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(ActivityName, ActivityKind.Client);
            Assert.NotNull(activity);

            // Set semantic convention attributes (HTTP)
            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpUrl, "https://example.com/api");
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, "200");

            // Set all override attributes
            activity.SetTag(SemanticConventions.AttributeMicrosoftDependencyType, "CustomType");
            activity.SetTag(SemanticConventions.AttributeMicrosoftDependencyData, "CustomData");
            activity.SetTag(SemanticConventions.AttributeMicrosoftDependencyName, "CustomName");
            activity.SetTag(SemanticConventions.AttributeMicrosoftDependencyTarget, "CustomTarget");
            activity.SetTag(SemanticConventions.AttributeMicrosoftDependencyResultCode, "CustomResult");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            // Verify all overrides applied
            Assert.Equal("CustomType", remoteDependencyData.Type);
            Assert.Equal("CustomData", remoteDependencyData.Data);
            Assert.Equal("CustomName", remoteDependencyData.Name);
            Assert.Equal("CustomTarget", remoteDependencyData.Target);
            Assert.Equal("CustomResult", remoteDependencyData.ResultCode);
        }

        [Fact]
        public void PartialOverridesOnlyAffectSpecifiedFields()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(ActivityName, ActivityKind.Client);
            Assert.NotNull(activity);

            var httpUrl = "https://example.com/api";
            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpUrl, httpUrl);
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, "200");

            // Only override Type, leave others from semantic conventions
            activity.SetTag(SemanticConventions.AttributeMicrosoftDependencyType, "CustomType");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            // Type is overridden
            Assert.Equal("CustomType", remoteDependencyData.Type);
            // Data comes from semantic conventions
            Assert.Equal(httpUrl, remoteDependencyData.Data);
            // ResultCode comes from semantic conventions
            Assert.Equal("200", remoteDependencyData.ResultCode);
        }
    }
}
