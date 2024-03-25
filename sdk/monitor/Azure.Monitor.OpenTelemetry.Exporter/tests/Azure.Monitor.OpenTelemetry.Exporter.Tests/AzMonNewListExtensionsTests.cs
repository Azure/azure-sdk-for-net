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
        [InlineData("http", "example.com", "8080", "/search", "?q=OpenTelemetry", "http://example.com:8080/search?q=OpenTelemetry")]
        [InlineData("http", "example.com", null, "/search", "?q=OpenTelemetry", "http://example.com/search?q=OpenTelemetry")]
        [InlineData("http", "example.com", "8080", "/", "?q=OpenTelemetry", "http://example.com:8080/?q=OpenTelemetry")]
        [InlineData("http", "example.com", "8080", "/search", null, "http://example.com:8080/search")]
        public void GetNewRequestUrl_ReturnsCorrectUrl(string urlScheme, string serverAddress, string? serverPort, string urlPath, string? urlQuery, string expectedUrl)
        {
            // Arrange
            AzMonList tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlScheme, urlScheme));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, serverAddress));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerPort, serverPort));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlPath, urlPath));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeUrlQuery, urlQuery));

            // Validate the length with the same logic from code.
            int colonLength = serverPort == null ? 0 : 1;
            serverPort ??= string.Empty;
            urlQuery ??= string.Empty;
            var length = urlScheme.Length + Uri.SchemeDelimiter.Length + serverAddress.Length + serverPort.Length + colonLength + urlPath.Length + urlQuery.Length;

            // Act
            string? url = tagObjects.GetNewSchemaRequestUrl();

            // Assert
            Assert.Equal(expectedUrl, url);
            Assert.Equal(length, url?.Length);
        }

        [Theory]
        [InlineData("my.servicebus.windows.net", "amqp", "queueName", "amqp://my.servicebus.windows.net/queueName", "my.servicebus.windows.net/queueName")]
        [InlineData("my.servicebus.windows.net", "amqp", "", "amqp://my.servicebus.windows.net", "my.servicebus.windows.net")]
        [InlineData("", "amqp", "queueName", null, null)]
        [InlineData("my.servicebus.windows.net", "", "queueName", "my.servicebus.windows.net/queueName", "my.servicebus.windows.net/queueName")]
        [InlineData("my.servicebus.windows.net", null, null, "my.servicebus.windows.net", "my.servicebus.windows.net")]
        [InlineData(null, "amqp", "queueName", null, null)]
        public void GetMessagingUrlAndSourceOrTarget_ReturnsCorrectResult(string serverAddress, string protocolName, string destinationName, string expectedUrl, string expectedSourceOrTarget)
        {
            // Arrange
            AzMonList tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeServerAddress, serverAddress));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeNetworkProtocolName, protocolName));
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(SemanticConventions.AttributeMessagingDestinationName, destinationName));

            // Act
            var (messagingUrl, sourceOrTarget) = tagObjects.GetMessagingUrlAndSourceOrTarget(ActivityKind.Producer);

            // Assert
            Assert.Equal(expectedUrl, messagingUrl);
            Assert.Equal(expectedSourceOrTarget, sourceOrTarget);
        }

        [Fact]
        public void GetMessagingUrlAndSourceOrTarget_NullTagObjects_ReturnsNull()
        {
            // Arrange
            AzMonList tagObjects = AzMonList.Initialize();
            var activityKind = ActivityKind.Consumer;

            // Act
            var (messagingUrl, sourceOrTarget) = tagObjects.GetMessagingUrlAndSourceOrTarget(activityKind);

            // Assert
            Assert.Null(messagingUrl);
            Assert.Null(sourceOrTarget);
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
