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

            var url = "/api/urltest";
            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, httpMethod));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRoute, httpRoute));

            // Act
            var result = TraceHelper.GetNewSchemaOperationName(activity!, url, ref tagObjects);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetNewOperationName_WithValidHttpMethodAndUrl()
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetNewOperationName_WithValidHttpMethodAndUrl)).Build();
            using var activitySource = new ActivitySource(nameof(GetNewOperationName_WithValidHttpMethodAndUrl));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, "GET"));

            // Act
            var result = TraceHelper.GetNewSchemaOperationName(activity!, "/api/test", ref tagObjects);

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

            var url = "/api/test";
            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, httpMethod));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRoute, httpRoute));

            // Act
            var result = TraceHelper.GetNewSchemaOperationName(activity!, url, ref tagObjects);

            // Assert
            Assert.Equal(ActivityName, result);
        }

        [Fact]
        public void GetNewOperationName_WithNullHttpRoute_ReturnsUrlWithVerb()
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetNewOperationName_WithNullHttpRoute_ReturnsUrlWithVerb)).Build();
            using var activitySource = new ActivitySource(nameof(GetNewOperationName_WithNullHttpRoute_ReturnsUrlWithVerb));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, "POST"));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, "example.com"));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlScheme, "http"));

            // Act
            var result = TraceHelper.GetNewSchemaOperationName(activity!, url: null, ref tagObjects);

            // Assert
            Assert.Equal("POST http://example.com", result);
        }

        [Fact]
        public void GetNewOperationName_WithNullUrl_ReturnsFormattedStringFromMappedTags()
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetNewOperationName_WithNullUrl_ReturnsFormattedStringFromMappedTags)).Build();
            using var activitySource = new ActivitySource(nameof(GetNewOperationName_WithNullUrl_ReturnsFormattedStringFromMappedTags));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, "GET"));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRoute, "/api/test"));

            // Act
            var result = TraceHelper.GetNewSchemaOperationName(activity!, null, ref tagObjects);

            // Assert
            Assert.Equal("GET /api/test", result);
        }

        [Fact]
        public void GetHttpOperationNameAndUrl_V1()
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetNewOperationName_WithNullUrl_ReturnsFormattedStringFromMappedTags)).Build();
            using var activitySource = new ActivitySource(nameof(GetNewOperationName_WithNullUrl_ReturnsFormattedStringFromMappedTags));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var httpMappedTags = AzMonList.Initialize();
            AzMonList.Add(ref httpMappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpUrl, "https://example.com"));
            AzMonList.Add(ref httpMappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpMethod, "GET"));

            // Act
            var (requestUrl, operationName) = TraceHelper.GetHttpOperationNameAndUrl(activity!.DisplayName, OperationType.Http, ref httpMappedTags);

            // Assert
            Assert.Equal("https://example.com", requestUrl);
            Assert.Equal("GET /", operationName);
        }

        [Fact]
        public void GetHttpOperationNameAndUrl_V2()
        {
            // Arrange
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(GetNewOperationName_WithNullUrl_ReturnsFormattedStringFromMappedTags)).Build();
            using var activitySource = new ActivitySource(nameof(GetNewOperationName_WithNullUrl_ReturnsFormattedStringFromMappedTags));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server);
            activity?.Stop();

            var httpMappedTags = AzMonList.Initialize();
            AzMonList.Add(ref httpMappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlScheme, "http"));
            AzMonList.Add(ref httpMappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, "example.com"));
            AzMonList.Add(ref httpMappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, "GET"));
            AzMonList.Add(ref httpMappedTags, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlPath, "/search"));

            // Act
            var (requestUrl, operationName) = TraceHelper.GetHttpOperationNameAndUrl(activity!.DisplayName, OperationType.V2, ref httpMappedTags);

            // Assert
            Assert.Equal("http://example.com/search", requestUrl);
            Assert.Equal("GET /search", operationName);
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
