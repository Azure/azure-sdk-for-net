// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class AzMonNewListExtensionsTests
    {
        [Theory]
        [InlineData("http", "example.com", "8080", "/search", "q=OpenTelemetry", "http://example.com:8080/search?q=OpenTelemetry")]
        [InlineData(null, "example.com", "8080", "/search", "q=OpenTelemetry", "example.com:8080/search?q=OpenTelemetry")]
        [InlineData("http", null, "8080", "/search", "q=OpenTelemetry", null)]
        [InlineData("http", "example.com", null, "/search", "q=OpenTelemetry", "http://example.com/search?q=OpenTelemetry")]
        [InlineData("http", "example.com", "8080", null, "q=OpenTelemetry", "http://example.com:8080/?q=OpenTelemetry")]
        [InlineData("http", "example.com", "8080", "/search", null, "http://example.com:8080/search")]
        public void GetNewRequestUrl_ReturnsCorrectUrl(string urlScheme, string serverAddress, string serverPort, string urlPath, string urlQuery, string expectedUrl)
        {
            // Arrange
            AzMonList tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlScheme, urlScheme));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, serverAddress));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerPort, serverPort));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlPath, urlPath));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlQuery, urlQuery));

            // Act
            string? url = tagObjects.GetNewSchemaRequestUrl();

            // Assert
            Assert.Equal(expectedUrl, url);
        }

        [Theory]
        [InlineData("example.com", "80", "example.com")]
        [InlineData("example.com", "443", "example.com")]
        [InlineData("example.com", "8080", "example.com:8080")]
        [InlineData("example.com", null, "example.com")]
        [InlineData("example.com", "", "example.com")]
        [InlineData(null, "8080", null)]
        [InlineData("", "8080", null)]
        public void GetNewHttpDependencyTarget_ReturnsExpectedResult(string serverAddress, string serverPort, string expected)
        {
            // Arrange
            AzMonList tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, serverAddress));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerPort, serverPort));

            // Act
            string? result = tagObjects.GetNewSchemaHttpDependencyTarget();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("POST", "http://example.com/api/users", "POST /api/users")]
        [InlineData("GET", "http://example.com/api/posts?page=2", "GET /api/posts")]
        [InlineData("PUT", "http://example.com", "PUT /")]
        [InlineData("", "http://example.com", null)]
        [InlineData(null, "http://example.com", null)]
        [InlineData("GET", "", null)]
        [InlineData("GET", null, null)]
        [InlineData("", "", null)]
        public void GetNewHttpDependencyName_ReturnsExpectedResult(string httpMethod, string httpUrl, string expected)
        {
            // Arrange
            AzMonList tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeHttpRequestMethod, httpMethod));

            // Act
            string? result = tagObjects.GetNewSchemaHttpDependencyName(httpUrl);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
