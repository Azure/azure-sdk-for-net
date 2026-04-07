// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace Microsoft.ClientModel.TestFramework.Tests;
public class MockPipelineResponseTests
{
    [Test]
    public void CanSetIsError()
    {
        MockPipelineResponse mockResponse = new();
        mockResponse.SetIsError(true);
        Assert.That(mockResponse.IsError, Is.True);
        mockResponse.SetIsError(false);
        Assert.That(mockResponse.IsError, Is.False);
    }

    [Test]
    public void CanAddHeader()
    {
        MockPipelineResponse mockResponse = new();
        mockResponse.WithHeader("Content-Type", "application/json");
        mockResponse.WithHeader("X-Custom-Header", "CustomValue");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(mockResponse.Headers.TryGetValue("Content-Type", out string value), Is.True);
            Assert.That(value, Is.EqualTo("application/json"));
            Assert.That(mockResponse.Headers.TryGetValue("X-Custom-Header", out value), Is.True);
            Assert.That(value, Is.EqualTo("CustomValue"));
        }
    }

    [Test]
    public void CanSetByteContent()
    {
        MockPipelineResponse mockResponse = new();
        byte[] content = Encoding.UTF8.GetBytes("Hello, World!");
        mockResponse.WithContent(content);
        Assert.That(mockResponse.ContentStream, Is.Not.Null);
        using (var reader = new StreamReader(mockResponse.ContentStream, Encoding.UTF8))
        {
            mockResponse.ContentStream.Position = 0; // Reset stream position for reading
            string result = reader.ReadToEnd();
            Assert.That(result, Is.EqualTo("Hello, World!"));
        }
    }

    [Test]
    public void CanSetStringContent()
    {
        MockPipelineResponse mockResponse = new();
        string content = "Hello, World!";
        mockResponse.WithContent(content);
        Assert.That(mockResponse.ContentStream, Is.Not.Null);
        using (var reader = new StreamReader(mockResponse.ContentStream, Encoding.UTF8))
        {
            mockResponse.ContentStream.Position = 0; // Reset stream position for reading
            string result = reader.ReadToEnd();
            Assert.That(result, Is.EqualTo("Hello, World!"));
        }
    }

    [Test]
    public void ConstructorWithStatusAndReasonPhraseSetsPropertiesCorrectly()
    {
        var response = new MockPipelineResponse(404, "Not Found");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Status, Is.EqualTo(404));
            Assert.That(response.ReasonPhrase, Is.EqualTo("Not Found"));
            Assert.That(response.IsError, Is.False);
            Assert.That(response.IsDisposed, Is.False);
        }
    }

    [Test]
    public void ConstructorWithDefaultValuesSetsDefaultProperties()
    {
        var response = new MockPipelineResponse();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Status, Is.EqualTo(0));
            Assert.That(response.ReasonPhrase, Is.Empty);
            Assert.That(response.IsError, Is.False);
            Assert.That(response.IsDisposed, Is.False);
        }
    }

    [Test]
    public void WithHeaderChainedCallsAddsAllHeaders()
    {
        var response = new MockPipelineResponse()
            .WithHeader("Content-Type", "application/json")
            .WithHeader("Cache-Control", "no-cache")
            .WithHeader("X-Custom", "custom-value");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Headers.TryGetValue("Content-Type", out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo("application/json"));
            Assert.That(response.Headers.TryGetValue("Cache-Control", out var cacheControl), Is.True);
            Assert.That(cacheControl, Is.EqualTo("no-cache"));
            Assert.That(response.Headers.TryGetValue("X-Custom", out var custom), Is.True);
            Assert.That(custom, Is.EqualTo("custom-value"));
        }
    }

    [Test]
    public void WithContentChainedWithHeadersSetsContentAndHeaders()
    {
        var response = new MockPipelineResponse(201, "Created")
            .WithContent("response body")
            .WithHeader("Location", "/api/resource/123");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Status, Is.EqualTo(201));
            Assert.That(response.ReasonPhrase, Is.EqualTo("Created"));
            Assert.That(response.Content.ToString(), Is.EqualTo("response body"));
            Assert.That(response.Headers.TryGetValue("Location", out var location), Is.True);
            Assert.That(location, Is.EqualTo("/api/resource/123"));
        }
    }

    [Test]
    public void ContentStreamWithNullContentReturnsEmptyStream()
    {
        var response = new MockPipelineResponse();
        var contentStream = response.ContentStream;
        Assert.That(contentStream, Is.Not.Null);
        Assert.That(contentStream.Length, Is.EqualTo(0));
    }

    [Test]
    public void ContentWithNullContentStreamReturnsEmptyBinaryData()
    {
        var response = new MockPipelineResponse();
        var content = response.Content;
        Assert.That(content, Is.Not.Null);
        Assert.That(content.ToArray().Length, Is.EqualTo(0));
    }

    [Test]
    public void ContentStreamSettingToNullHandlesGracefully()
    {
        var response = new MockPipelineResponse().WithContent("initial content");
        response.ContentStream = null;
        Assert.That(response.ContentStream, Is.Not.Null);
        Assert.That(response.ContentStream.Length, Is.EqualTo(0));
    }

    [Test]
    public void ContentStreamSettingCustomStreamUpdatesContent()
    {
        var response = new MockPipelineResponse();
        var customContent = "custom stream content";
        var customStream = new MemoryStream(Encoding.UTF8.GetBytes(customContent));
        response.ContentStream = customStream;
        var resultStream = response.ContentStream;
        resultStream.Position = 0;
        using var reader = new StreamReader(resultStream, Encoding.UTF8);
        var result = reader.ReadToEnd();
        Assert.That(result, Is.EqualTo(customContent));
    }

    [Test]
    public void DisposeSetsIsDisposedToTrue()
    {
        var response = new MockPipelineResponse();
        response.Dispose();
        Assert.That(response.IsDisposed, Is.True);
    }

    [Test]
    public void DisposeMultipleCallsDoNotThrow()
    {
        var response = new MockPipelineResponse();
        Assert.DoesNotThrow(() => response.Dispose());
        Assert.DoesNotThrow(() => response.Dispose());
        Assert.DoesNotThrow(() => response.Dispose());
        Assert.That(response.IsDisposed, Is.True);
    }

    [Test]
    public void DisposeWithContentBuffersContentBeforeDisposal()
    {
        var response = new MockPipelineResponse().WithContent("disposable content");
        response.Dispose();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsDisposed, Is.True);
            Assert.That(response.Content.ToString(), Is.EqualTo("disposable content"));
        }
    }

    [Test]
    public void WithContentEmptyStringSetsEmptyContent()
    {
        var response = new MockPipelineResponse().WithContent("");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Content.ToString(), Is.Empty);
            Assert.That(response.ContentStream, Is.Not.Null);
        }
        Assert.That(response.ContentStream.Length, Is.EqualTo(0));
    }

    [Test]
    public void WithContentEmptyByteArraySetsEmptyContent()
    {
        var response = new MockPipelineResponse().WithContent(new byte[0]);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Content.ToArray().Length, Is.EqualTo(0));
            Assert.That(response.ContentStream, Is.Not.Null);
        }
        Assert.That(response.ContentStream.Length, Is.EqualTo(0));
    }

    [Test]
    public void WithContentLargeContentHandlesCorrectly()
    {
        var largeContent = new string('x', 10000);
        var response = new MockPipelineResponse().WithContent(largeContent);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Content.ToString(), Is.EqualTo(largeContent));
            Assert.That(response.Content.ToArray().Length, Is.EqualTo(10000));
        }
    }

    [Test]
    public void SetIsErrorAffectsIsErrorProperty()
    {
        var response = new MockPipelineResponse();
        Assert.That(response.IsError, Is.False);
        response.SetIsError(true);
        Assert.That(response.IsError, Is.True);
        response.SetIsError(false);
        Assert.That(response.IsError, Is.False);
    }

    [Test]
    public void ResponseInheritsFromPipelineResponse()
    {
        var response = new MockPipelineResponse();
        Assert.That(response, Is.InstanceOf<System.ClientModel.Primitives.PipelineResponse>());
    }

    [Test]
    public void HeadersReturnsConsistentInstance()
    {
        var response = new MockPipelineResponse();
        var headers1 = response.Headers;
        var headers2 = response.Headers;
        Assert.That(headers2, Is.SameAs(headers1));
    }

    [Test]
    public void WithContentJsonContentHandlesJsonCorrectly()
    {
        var jsonContent = """{"name": "test", "age": 30, "active": true}""";
        var response = new MockPipelineResponse(200, "OK")
            .WithContent(jsonContent)
            .WithHeader("Content-Type", "application/json");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Content.ToString(), Is.EqualTo(jsonContent));
            Assert.That(response.Headers.TryGetValue("Content-Type", out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo("application/json"));
        }
    }
}
