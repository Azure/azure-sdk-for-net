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
    public class TraceHelperV2Tests
    {
        private const string ActivityName = "AzureMonitorTraceHelperTestsActivity";

        [Theory]
        [InlineData("GET", "/api/{controller}/{action}", "GET /api/urltest")]
        [InlineData("GET", "/api/routetest", "GET /api/routetest")]
        [InlineData("POST", "/api/routetest", "POST /api/routetest")]
        public void GetV2OperationName_ValidateHttpMethodAndHttpRoute(string httpMethod, string httpRoute, string expected)
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetV2OperationName_ValidateHttpMethodAndHttpRoute)).Build();
            using var activitySource = new ActivitySource(nameof(GetV2OperationName_ValidateHttpMethodAndHttpRoute));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var url = "/api/urltest";
            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, httpMethod));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRoute, httpRoute));

            // Act
            var result = TraceHelper.GetV2OperationName(activity!, url, ref tagObjects);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetV2OperationName_WithValidHttpMethodAndUrl()
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetV2OperationName_WithValidHttpMethodAndUrl)).Build();
            using var activitySource = new ActivitySource(nameof(GetV2OperationName_WithValidHttpMethodAndUrl));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, "GET"));

            // Act
            var result = TraceHelper.GetV2OperationName(activity!, "/api/test", ref tagObjects);

            // Assert
            Assert.Equal("GET /api/test", result);
        }

        [Theory]
        [InlineData(null, "/api/test")]
        [InlineData("", "/api/test")]
        public void GetV2OperationName_WithNullHttpMethod_ReturnsActivityDisplayName(string httpMethod, string httpRoute)
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetV2OperationName_WithNullHttpMethod_ReturnsActivityDisplayName)).Build();
            using var activitySource = new ActivitySource(nameof(GetV2OperationName_WithNullHttpMethod_ReturnsActivityDisplayName));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var url = "/api/test";
            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, httpMethod));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRoute, httpRoute));

            // Act
            var result = TraceHelper.GetV2OperationName(activity!, url, ref tagObjects);

            // Assert
            Assert.Equal(ActivityName, result);
        }

        [Fact]
        public void GetV2OperationName_WithNullHttpRoute_ReturnsActivityDisplayName()
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetV2OperationName_WithNullHttpRoute_ReturnsActivityDisplayName)).Build();
            using var activitySource = new ActivitySource(nameof(GetV2OperationName_WithNullHttpRoute_ReturnsActivityDisplayName));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, "POST"));

            // Act
            var result = TraceHelper.GetV2OperationName(activity!, url: null, ref tagObjects);

            // Assert
            Assert.Equal(ActivityName, result);
        }

        [Fact]
        public void GetV2OperationName_WithNullUrl_ReturnsFormattedStringFromMappedTags()
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetV2OperationName_WithNullUrl_ReturnsFormattedStringFromMappedTags)).Build();
            using var activitySource = new ActivitySource(nameof(GetV2OperationName_WithNullUrl_ReturnsFormattedStringFromMappedTags));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, "GET"));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRoute, "/api/test"));

            // Act
            var result = TraceHelper.GetV2OperationName(activity!, null, ref tagObjects);

            // Assert
            Assert.Equal("GET /api/test", result);
        }

        private string? GetExpectedMSlinks(IEnumerable<ActivityLink> links)
        {
            if (links != null && links.Any())
            {
                var linksJson = new StringBuilder();
                linksJson.Append('[');
                foreach (var link in links)
                {
                    linksJson
                        .Append('{')
                        .Append("\"operation_Id\":")
                        .Append('\"')
                        .Append(link.Context.TraceId.ToHexString())
                        .Append('\"')
                        .Append(',');
                    linksJson
                        .Append("\"id\":")
                        .Append('\"')
                        .Append(link.Context.SpanId.ToHexString())
                        .Append('\"');
                    linksJson.Append("},");
                }

                if (linksJson.Length > 0)
                {
                    // trim trailing comma - json does not support it
                    linksJson.Remove(linksJson.Length - 1, 1);
                }

                linksJson.Append(']');

                return linksJson.ToString();
            }

            return null;
        }
    }
}
