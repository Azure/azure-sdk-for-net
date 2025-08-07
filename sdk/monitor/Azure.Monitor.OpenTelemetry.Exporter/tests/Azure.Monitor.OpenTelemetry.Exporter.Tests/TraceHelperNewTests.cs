// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class TraceHelperNewTests
    {
        private const string ActivityName = "AzureMonitorTraceHelperTestsActivity";

        [Theory]
        [InlineData("GET", "/api/{controller}/{action}", "GET /api/urltest")]
        [InlineData("GET", "/api/routetest", "GET /api/routetest")]
        [InlineData("POST", "/api/routetest", "POST /api/routetest")]
        public void GetNewOperationName_ValidateHttpMethodAndHttpRoute(string httpMethod, string httpRoute, string expected)
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetNewOperationName_ValidateHttpMethodAndHttpRoute)).Build();
            using var activitySource = new ActivitySource(nameof(GetNewOperationName_ValidateHttpMethodAndHttpRoute));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var path = "/api/urltest";
            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, httpMethod));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRoute, httpRoute));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlPath, path));

            // Act
            var result = TraceHelper.GetOperationNameV2(activity!, ref tagObjects);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetNewOperationName_WithValidHttpMethodAndPath()
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetNewOperationName_WithValidHttpMethodAndPath)).Build();
            using var activitySource = new ActivitySource(nameof(GetNewOperationName_WithValidHttpMethodAndPath));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, "GET"));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlPath, "/api/test"));

            // Act
            var result = TraceHelper.GetOperationNameV2(activity!, ref tagObjects);

            // Assert
            Assert.Equal("GET /api/test", result);
        }

        [Theory]
        [InlineData(null, "/api/test")]
        [InlineData("", "/api/test")]
        public void GetNewOperationName_WithNullHttpMethod_ReturnsActivityDisplayName(string httpMethod, string httpRoute)
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetNewOperationName_WithNullHttpMethod_ReturnsActivityDisplayName)).Build();
            using var activitySource = new ActivitySource(nameof(GetNewOperationName_WithNullHttpMethod_ReturnsActivityDisplayName));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var path = "/api/test";
            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, httpMethod));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRoute, httpRoute));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlPath, path));

            // Act
            var result = TraceHelper.GetOperationNameV2(activity!, ref tagObjects);

            // Assert
            Assert.Equal(ActivityName, result);
        }

        [Fact]
        public void DuplicateTagsOnProperties()
        {
            // Arrange
            IDictionary<string, string> destination = new Dictionary<string, string>();
            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>("key1", "value1"));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>("key1", "value2"));

            // Act
            TraceHelper.AddPropertiesToTelemetry(destination, ref tagObjects);

            // Assert
            Assert.True(destination.TryGetValue("key1", out var value));
            Assert.Equal("value1", value);
        }
    }
}
