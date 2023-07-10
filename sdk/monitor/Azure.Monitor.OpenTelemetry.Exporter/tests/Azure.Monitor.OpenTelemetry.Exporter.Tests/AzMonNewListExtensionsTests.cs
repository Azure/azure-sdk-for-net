// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (url != null)
            {
                // Validate the length with the same logic from code.
                var length = (urlScheme?.Length ?? 0) + (urlScheme?.Length > 0 ? Uri.SchemeDelimiter.Length : 0) + serverAddress.Length + (serverPort?.Length > 0 ? 1 : 0) + (serverPort?.Length ?? 0) + (urlPath?.Length ?? 1) + (urlQuery?.Length > 0 ? 1 : 0) + (urlQuery?.Length ?? 0);
                Assert.Equal(length, url.Length);
            }
        }

        [Theory]
        [InlineData("my.servicebus.windows.net", "amqps", "queueName", "amqps://my.servicebus.windows.net/queueName")]
        [InlineData("my.servicebus.windows.net", "amqps", "", "amqps://my.servicebus.windows.net/")]
        [InlineData("", "amqps", "queueName", null)]
        [InlineData("my.servicebus.windows.net", "", "queueName", "my.servicebus.windows.net/queueName")]
        [InlineData("my.servicebus.windows.net", null, null, "my.servicebus.windows.net/")]
        [InlineData(null, "amqps", "queueName", null)]
        public void GetNewSchemaMessagingUrl_ActivityKindProducer(string serverAddress, string protocolName, string destinationName, string expectedUrl)
        {
            // Arrange
            AzMonList tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, serverAddress));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetworkProtocolName, protocolName));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeMessagingDestinationName, destinationName));

            // Act
            var url = tagObjects.GetNewSchemaMessagingUrl(ActivityKind.Producer);

            // Assert
            Assert.Equal(expectedUrl, url);
            if (url != null)
            {
                // Validate the length with the same logic from code.
                var length = (protocolName?.Length ?? 0) + (protocolName?.Length > 0 ? Uri.SchemeDelimiter.Length : 0) + serverAddress!.Length + (destinationName?.Length ?? 0) + 1;
                Assert.Equal(length, url.Length);
            }
        }

        [Theory]
        [InlineData("my.servicebus.windows.net", "amqps", "queueName", null, "amqps://my.servicebus.windows.net/queueName")]
        [InlineData("my.servicebus.windows.net", "amqps", "", null, "amqps://my.servicebus.windows.net/")]
        [InlineData("", "amqps", null, null, null)]
        [InlineData("my.servicebus.windows.net", "", null, "destinationName", "my.servicebus.windows.net/destinationName")]
        [InlineData(null, "amqps", null, "destinationName", null)]
        [InlineData("my.servicebus.windows.net", "amqps", "sourceName", "destinationName", "amqps://my.servicebus.windows.net/sourceName")]
        [InlineData("my.servicebus.windows.net", "amqps", null, null, "amqps://my.servicebus.windows.net/")]
        [InlineData("my.servicebus.windows.net", "amqps", "", "", "amqps://my.servicebus.windows.net/")]
        public void GetNewSchemaMessagingUrl_ActivityKindConsumer(string serverAddress, string protocolName, string sourceName, string destinationName, string expectedUrl)
        {
            // Arrange
            AzMonList tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, serverAddress));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetworkProtocolName, protocolName));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeMessagingDestinationName, destinationName));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeMessagingSourceName, sourceName));

            // Act
            var result = tagObjects.GetNewSchemaMessagingUrl(ActivityKind.Consumer);

            // Assert
            Assert.Equal(expectedUrl, result);
        }

        [Fact]
        public void GetNewSchemaMessagingUrl_NullTagObjects_ReturnsNull()
        {
            // Arrange
            AzMonList tagObjects = AzMonList.Initialize();
            var activityKind = ActivityKind.Consumer;

            // Act
            var result = tagObjects.GetNewSchemaMessagingUrl(activityKind);

            // Assert
            Assert.Null(result);
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
