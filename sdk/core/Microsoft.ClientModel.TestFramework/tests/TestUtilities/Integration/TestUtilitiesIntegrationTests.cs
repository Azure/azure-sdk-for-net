// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Microsoft.ClientModel.TestFramework.Tests.Integration;
[TestFixture]
public class TestUtilitiesIntegrationTests
{
    [Test]
    public async Task MockCredential_WithMockPipelineMessage_IntegratesCorrectly()
    {
        var credential = new MockCredential("integration-token", DateTimeOffset.UtcNow.AddHours(1));
        var message = new MockPipelineMessage();
        var token = await credential.GetTokenAsync(new GetTokenOptions(new Dictionary<string, object>()), CancellationToken.None);
        message.Request.Headers.Add("Authorization", $"{token.TokenType} {token.TokenValue}");
        Assert.IsTrue(message.Request.Headers.TryGetValue("Authorization", out var authHeader));
        Assert.AreEqual("Bearer integration-token", authHeader);
    }
    [Test]
    public async Task MockPipelineTransport_WithMockCredential_ProcessesAuthenticatedRequests()
    {
        var credential = new MockCredential("transport-token", DateTimeOffset.UtcNow.AddHours(1));
        var transport = new MockPipelineTransport(msg =>
        {
            var response = new MockPipelineResponse(200, "OK");
            if (msg.Request.Headers.TryGetValue("Authorization", out var auth) && auth.StartsWith("Bearer"))
            {
                response.WithHeader("X-Authenticated", "true");
            }
            return response;
        });
        var message = transport.CreateMessage();
        var token = await credential.GetTokenAsync(new GetTokenOptions(new Dictionary<string, object>()), CancellationToken.None);
        message.Request.Headers.Add("Authorization", $"{token.TokenType} {token.TokenValue}");
        transport.Process(message);
        Assert.IsNotNull(message.Response);
        Assert.AreEqual(200, message.Response.Status);
        Assert.IsTrue(message.Response.Headers.TryGetValue("X-Authenticated", out var authenticated));
        Assert.AreEqual("true", authenticated);
        Assert.AreEqual(1, transport.Requests.Count);
    }
    [Test]
    public async Task AsyncAssert_WithAsyncEnumerableExtensions_ValidatesAsyncExceptions()
    {
        // Arrange
        var failingAsyncEnumerable = CreateFailingAsyncEnumerable();
        // Act & Assert
        var exception = await AsyncAssert.ThrowsAsync<InvalidOperationException>(
            async () => await failingAsyncEnumerable.ToEnumerableAsync());
        Assert.AreEqual("Async enumerable failure", exception.Message);
    }
    [Test]
    public async Task CompleteRequestResponseCycle_WithAllMockComponents_WorksEndToEnd()
    {
        // Arrange
        var credential = new MockCredential("complete-token", DateTimeOffset.UtcNow.AddHours(1));
        var requestData = new { name = "test", value = 42 };
        var responseData = """{"result": "success", "id": 123}""";
        var transport = new MockPipelineTransport(msg =>
        {
            var response = new MockPipelineResponse(201, "Created")
                .WithContent(responseData)
                .WithHeader("Content-Type", "application/json")
                .WithHeader("Location", "https://api.example.com/resource/123");
            return response;
        });
        // Act - Build complete request
        var message = transport.CreateMessage();
        var token = await credential.GetTokenAsync(new GetTokenOptions(new Dictionary<string, object>()), CancellationToken.None);
        message.Request.Method = "POST";
        message.Request.Uri = new Uri("https://api.example.com/resource");
        message.Request.Headers.Add("Authorization", $"{token.TokenType} {token.TokenValue}");
        message.Request.Headers.Add("Content-Type", "application/json");
        message.Request.Headers.Add("Accept", "application/json");
        message.Request.Content = BinaryContent.Create(BinaryData.FromString("""{"name": "test", "value": 42}"""));
        transport.Process(message);
        // Assert - Verify complete response
        Assert.IsNotNull(message.Response);
        Assert.AreEqual(201, message.Response.Status);
        Assert.AreEqual("Created", message.Response.ReasonPhrase);
        Assert.IsTrue(message.Response.Headers.TryGetValue("Content-Type", out var contentType));
        Assert.AreEqual("application/json", contentType);
        Assert.IsTrue(message.Response.Headers.TryGetValue("Location", out var location));
        Assert.AreEqual("https://api.example.com/resource/123", location);
        var responseContent = message.Response.Content.ToString();
        Assert.AreEqual(responseData, responseContent);
        // Verify request was captured
        Assert.AreEqual(1, transport.Requests.Count);
        var capturedRequest = transport.Requests[0];
        Assert.AreEqual("POST", capturedRequest.Method);
        Assert.AreEqual("https://api.example.com/resource", capturedRequest.Uri?.ToString());
    }
    [Test]
    public async Task MockTransport_WithAsyncProcessing_HandlesAsyncOperationsCorrectly()
    {
        var processedItems = new List<string>();
        var transport = new MockPipelineTransport(msg =>
        {
            processedItems.Add($"Processed: {msg.Request.Method} {msg.Request.Uri}");
            return new MockPipelineResponse(200, "OK").WithContent("async response");
        });
        transport.ExpectSyncPipeline = false; // Enable async processing
        var messages = new[]
        {
            CreateMessageWithUrl(transport, "GET", "https://api.example.com/item/1"),
            CreateMessageWithUrl(transport, "GET", "https://api.example.com/item/2"),
            CreateMessageWithUrl(transport, "GET", "https://api.example.com/item/3")
        };
        var tasks = messages.Select(async msg =>
        {
            await Task.Delay(10); // Simulate some async work
            await transport.ProcessAsync(msg);
            return msg;
        });
        var results = await Task.WhenAll(tasks);
        // Assert
        Assert.AreEqual(3, results.Length);
        Assert.AreEqual(3, processedItems.Count);
        Assert.AreEqual(3, transport.Requests.Count);
        foreach (var result in results)
        {
            Assert.IsNotNull(result.Response);
            Assert.AreEqual(200, result.Response.Status);
            Assert.AreEqual("async response", result.Response.Content.ToString());
        }
    }
    [Test]
    public void MockTransport_WithSyncAsyncMismatch_ThrowsAppropriateExceptions()
    {
        // Arrange
        var transport = new MockPipelineTransport();
        var message = transport.CreateMessage();
        // Test sync call when expecting async
        transport.ExpectSyncPipeline = false;
        Assert.Throws<InvalidOperationException>(() => transport.Process(message));
        // Test async call when expecting sync
        transport.ExpectSyncPipeline = true;
        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await transport.ProcessAsync(message));
        Assert.IsTrue(exception.Message.Contains("asynchronous processing"));
    }
    [Test]
    public void MockComponents_WithErrorScenarios_HandleErrorsGracefully()
    {
        var transport = new MockPipelineTransport(msg =>
        {
            if (msg.Request.Uri?.AbsolutePath.Contains("error") == true)
            {
                var errorResponse = new MockPipelineResponse(500, "Internal Server Error");
                errorResponse.SetIsError(true);
                return errorResponse.WithContent("""{"error": "Something went wrong"}""");
            }
            return new MockPipelineResponse(200, "OK");
        });
        var errorMessage = CreateMessageWithUrl(transport, "GET", "https://api.example.com/error");
        var successMessage = CreateMessageWithUrl(transport, "GET", "https://api.example.com/success");
        transport.Process(errorMessage);
        transport.Process(successMessage);
        Assert.IsTrue(errorMessage.Response.IsError);
        Assert.AreEqual(500, errorMessage.Response.Status);
        Assert.AreEqual("Internal Server Error", errorMessage.Response.ReasonPhrase);
        Assert.IsFalse(successMessage.Response.IsError);
        Assert.AreEqual(200, successMessage.Response.Status);
        Assert.AreEqual(2, transport.Requests.Count);
    }
    [Test]
    public async Task MockCredential_WithExpirationHandling_HandlesTokenLifecycle()
    {
        var expiredTime = DateTimeOffset.UtcNow.AddMinutes(-10);
        var futureTime = DateTimeOffset.UtcNow.AddHours(1);
        var expiredCredential = new MockCredential("expired-token", expiredTime);
        var validCredential = new MockCredential("valid-token", futureTime);
        var expiredToken = await expiredCredential.GetTokenAsync(new GetTokenOptions(new Dictionary<string, object>()), CancellationToken.None);
        var validToken = await validCredential.GetTokenAsync(new GetTokenOptions(new Dictionary<string, object>()), CancellationToken.None);
        Assert.AreEqual("expired-token", expiredToken.TokenValue);
        Assert.IsTrue(expiredToken.ExpiresOn < DateTimeOffset.UtcNow);
        Assert.AreEqual("valid-token", validToken.TokenValue);
        Assert.IsTrue(validToken.ExpiresOn > DateTimeOffset.UtcNow);
    }
    [Test]
    public void MockPipelineResponse_WithComplexDisposalScenarios_HandlesResourcesCorrectly()
    {
        var response1 = new MockPipelineResponse(200, "OK").WithContent("test content 1");
        var response2 = new MockPipelineResponse(201, "Created").WithContent("test content 2");
        Assert.DoesNotThrow(() => response1.Dispose());
        Assert.DoesNotThrow(() => response1.Dispose());
        Assert.IsTrue(response1.IsDisposed);
        Assert.DoesNotThrow(() => response2.Dispose());
        Assert.IsTrue(response2.IsDisposed);
        Assert.IsNotNull(response1.Content);
        Assert.IsNotNull(response2.Content);
    }
    [Test]
    public async Task AsyncEnumerableExtensions_WithRealAsyncScenarios_ConvertsCorrectly()
    {
        var asyncData = CreateAsyncDataStream();
        var result = await asyncData.ToEnumerableAsync();
        Assert.IsNotNull(result);
        Assert.AreEqual(5, result.Count);
        for (int i = 0; i < 5; i++)
        {
            Assert.AreEqual($"async-item-{i}", result[i]);
        }
    }
    // Helper methods
    private static PipelineMessage CreateMessageWithUrl(MockPipelineTransport transport, string method, string url)
    {
        var message = transport.CreateMessage();
        message.Request.Method = method;
        message.Request.Uri = new Uri(url);
        return message;
    }
    private static async IAsyncEnumerable<string> CreateFailingAsyncEnumerable()
    {
        yield return "item1";
        yield return "item2";
        await Task.Yield();
        throw new InvalidOperationException("Async enumerable failure");
    }
    private static async IAsyncEnumerable<string> CreateAsyncDataStream()
    {
        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(1); // Simulate async operation
            yield return $"async-item-{i}";
        }
    }
}
