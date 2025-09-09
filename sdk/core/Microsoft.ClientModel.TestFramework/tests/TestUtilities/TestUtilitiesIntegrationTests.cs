// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public async Task MockCredentialWithMockPipelineMessageIntegratesCorrectly()
    {
        var credential = new MockCredential("integration-token", DateTimeOffset.UtcNow.AddHours(1));
        var message = new MockPipelineMessage();
        var token = await credential.GetTokenAsync(new GetTokenOptions(new Dictionary<string, object>()), CancellationToken.None);
        message.Request.Headers.Add("Authorization", $"{token.TokenType} {token.TokenValue}");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Request.Headers.TryGetValue("Authorization", out var authHeader), Is.True);
            Assert.That(authHeader, Is.EqualTo("Bearer integration-token"));
        }
    }

    [Test]
    public async Task MockPipelineTransportWithMockCredentialProcessesAuthenticatedRequests()
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

        Assert.That(message.Response, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Response.Status, Is.EqualTo(200));
            Assert.That(message.Response.Headers.TryGetValue("X-Authenticated", out var authenticated), Is.True);
            Assert.That(authenticated, Is.EqualTo("true"));
            Assert.That(transport.Requests.Count, Is.EqualTo(1));
        }
    }

    [Test]
    public void AsyncAssertWithAsyncEnumerableExtensionsValidatesAsyncExceptions()
    {
        var failingAsyncEnumerable = CreateFailingAsyncEnumerable();

        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await failingAsyncEnumerable.ToEnumerableAsync());
        Assert.That(exception.Message, Is.EqualTo("Async enumerable failure"));
    }

    [Test]
    public async Task CompleteRequestResponseCycleWithAllMockComponentsWorksEndToEnd()
    {
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

        var message = transport.CreateMessage();
        var token = await credential.GetTokenAsync(new GetTokenOptions(new Dictionary<string, object>()), CancellationToken.None);
        message.Request.Method = "POST";
        message.Request.Uri = new Uri("https://api.example.com/resource");
        message.Request.Headers.Add("Authorization", $"{token.TokenType} {token.TokenValue}");
        message.Request.Headers.Add("Content-Type", "application/json");
        message.Request.Headers.Add("Accept", "application/json");
        message.Request.Content = BinaryContent.Create(BinaryData.FromString("""{"name": "test", "value": 42}"""));
        transport.Process(message);

        Assert.That(message.Response, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Response.Status, Is.EqualTo(201));
            Assert.That(message.Response.ReasonPhrase, Is.EqualTo("Created"));
            Assert.That(message.Response.Headers.TryGetValue("Content-Type", out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo("application/json"));
            Assert.That(message.Response.Headers.TryGetValue("Location", out var location), Is.True);
            Assert.That(location, Is.EqualTo("https://api.example.com/resource/123"));
        }

        var responseContent = message.Response.Content.ToString();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(responseContent, Is.EqualTo(responseData));
            // Verify request was captured
            Assert.That(transport.Requests.Count, Is.EqualTo(1));
        }

        var capturedRequest = transport.Requests[0];
        using (Assert.EnterMultipleScope())
        {
            Assert.That(capturedRequest.Method, Is.EqualTo("POST"));
            Assert.That(capturedRequest.Uri?.ToString(), Is.EqualTo("https://api.example.com/resource"));
        }
    }

    [Test]
    public async Task MockTransportWithAsyncProcessingHandlesAsyncOperationsCorrectly()
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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(results.Length, Is.EqualTo(3));
            Assert.That(processedItems.Count, Is.EqualTo(3));
            Assert.That(transport.Requests.Count, Is.EqualTo(3));
        }

        foreach (var result in results)
        {
            Assert.That(result.Response, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.Response.Status, Is.EqualTo(200));
                Assert.That(result.Response.Content.ToString(), Is.EqualTo("async response"));
            }
        }
    }

    [Test]
    public void MockTransportWithSyncAsyncMismatchThrowsAppropriateExceptions()
    {
        var transport = new MockPipelineTransport();
        var message = transport.CreateMessage();

        // Test sync call when expecting async
        transport.ExpectSyncPipeline = false;
        Assert.Throws<InvalidOperationException>(() => transport.Process(message));

        // Test async call when expecting sync
        transport.ExpectSyncPipeline = true;

        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await transport.ProcessAsync(message));
        Assert.That(exception.Message.Contains("asynchronous processing"), Is.True);
    }

    [Test]
    public void MockComponentsWithErrorScenariosHandleErrorsGracefully()
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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(errorMessage.Response.IsError, Is.True);
            Assert.That(errorMessage.Response.Status, Is.EqualTo(500));
            Assert.That(errorMessage.Response.ReasonPhrase, Is.EqualTo("Internal Server Error"));
            Assert.That(successMessage.Response.IsError, Is.False);
            Assert.That(successMessage.Response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests.Count, Is.EqualTo(2));
        }
    }

    [Test]
    public async Task MockCredentialWithExpirationHandlingHandlesTokenLifecycle()
    {
        var expiredTime = DateTimeOffset.UtcNow.AddMinutes(-10);
        var futureTime = DateTimeOffset.UtcNow.AddHours(1);

        var expiredCredential = new MockCredential("expired-token", expiredTime);
        var validCredential = new MockCredential("valid-token", futureTime);
        var expiredToken = await expiredCredential.GetTokenAsync(new GetTokenOptions(new Dictionary<string, object>()), CancellationToken.None);
        var validToken = await validCredential.GetTokenAsync(new GetTokenOptions(new Dictionary<string, object>()), CancellationToken.None);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(expiredToken.TokenValue, Is.EqualTo("expired-token"));
            Assert.That(expiredToken.ExpiresOn < DateTimeOffset.UtcNow, Is.True);
            Assert.That(validToken.TokenValue, Is.EqualTo("valid-token"));
            Assert.That(validToken.ExpiresOn > DateTimeOffset.UtcNow, Is.True);
        }
    }

    [Test]
    public void MockPipelineResponseWithComplexDisposalScenariosHandlesResourcesCorrectly()
    {
        var response1 = new MockPipelineResponse(200, "OK").WithContent("test content 1");
        var response2 = new MockPipelineResponse(201, "Created").WithContent("test content 2");

        Assert.DoesNotThrow(() => response1.Dispose());
        Assert.DoesNotThrow(() => response1.Dispose());
        Assert.That(response1.IsDisposed, Is.True);
        Assert.DoesNotThrow(() => response2.Dispose());
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response2.IsDisposed, Is.True);
            Assert.That(response1.Content, Is.Not.Null);
            Assert.That(response2.Content, Is.Not.Null);
        }
    }

    [Test]
    public async Task AsyncEnumerableExtensionsWithRealAsyncScenariosConvertsCorrectly()
    {
        var asyncData = CreateAsyncDataStream();
        var result = await asyncData.ToEnumerableAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(5));
        for (int i = 0; i < 5; i++)
        {
            Assert.That(result[i], Is.EqualTo($"async-item-{i}"));
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
