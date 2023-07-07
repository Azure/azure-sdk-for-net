// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class AzMonListExtensionsV2Tests
    {
        [Theory]
        [InlineData("http", "example.com", "8080", "/search", "q=OpenTelemetry", "http://example.com:8080/search?q=OpenTelemetry")]
        [InlineData(null, "example.com", "8080", "/search", "q=OpenTelemetry", "example.com:8080/search?q=OpenTelemetry")]
        [InlineData("http", null, "8080", "/search", "q=OpenTelemetry", null)]
        [InlineData("http", "example.com", null, "/search", "q=OpenTelemetry", "http://example.com/search?q=OpenTelemetry")]
        [InlineData("http", "example.com", "8080", null, "q=OpenTelemetry", "http://example.com:8080/?q=OpenTelemetry")]
        [InlineData("http", "example.com", "8080", "/search", null, "http://example.com:8080/search")]
        public void GetV2RequestUrl_ReturnsCorrectUrl(string urlScheme, string serverAddress, string serverPort, string urlPath, string urlQuery, string expectedUrl)
        {
            // Arrange
            AzMonList tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlScheme, urlScheme));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, serverAddress));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerPort, serverPort));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlPath, urlPath));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlQuery, urlQuery));

            // Act
            string? url = tagObjects.GetV2RequestUrl();

            // Assert
            Assert.Equal(expectedUrl, url);
        }
    }
}
