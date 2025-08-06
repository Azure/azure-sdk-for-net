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
        Assert.IsTrue(mockResponse.IsError);
        mockResponse.SetIsError(false);
        Assert.IsFalse(mockResponse.IsError);
    }
    [Test]
    public void CanAddHeader()
    {
        MockPipelineResponse mockResponse = new();
        mockResponse.WithHeader("Content-Type", "application/json");
        mockResponse.WithHeader("X-Custom-Header", "CustomValue");
        Assert.IsTrue(mockResponse.Headers.TryGetValue("Content-Type", out string value));
        Assert.AreEqual("application/json", value);
        Assert.IsTrue(mockResponse.Headers.TryGetValue("X-Custom-Header", out value));
        Assert.AreEqual("CustomValue", value);
    }
    [Test]
    public void CanSetByteContent()
    {
        MockPipelineResponse mockResponse = new();
        byte[] content = Encoding.UTF8.GetBytes("Hello, World!");
        mockResponse.WithContent(content);
        Assert.IsNotNull(mockResponse.ContentStream);
        using (var reader = new StreamReader(mockResponse.ContentStream, Encoding.UTF8))
        {
            mockResponse.ContentStream.Position = 0; // Reset stream position for reading
            string result = reader.ReadToEnd();
            Assert.AreEqual("Hello, World!", result);
        }
    }
    [Test]
    public void CanSetStringContent()
    {
        MockPipelineResponse mockResponse = new();
        string content = "Hello, World!";
        mockResponse.WithContent(content);
        Assert.IsNotNull(mockResponse.ContentStream);
        using (var reader = new StreamReader(mockResponse.ContentStream, Encoding.UTF8))
        {
            mockResponse.ContentStream.Position = 0; // Reset stream position for reading
            string result = reader.ReadToEnd();
            Assert.AreEqual("Hello, World!", result);
        }
    }
    [Test]
    public void Constructor_WithStatusAndReasonPhrase_SetsPropertiesCorrectly()
    {
        var response = new MockPipelineResponse(404, "Not Found");
        Assert.AreEqual(404, response.Status);
        Assert.AreEqual("Not Found", response.ReasonPhrase);
        Assert.IsFalse(response.IsError);
        Assert.IsFalse(response.IsDisposed);
    }
    [Test]
    public void Constructor_WithDefaultValues_SetsDefaultProperties()
    {
        var response = new MockPipelineResponse();
        Assert.AreEqual(0, response.Status);
        Assert.AreEqual("", response.ReasonPhrase);
        Assert.IsFalse(response.IsError);
        Assert.IsFalse(response.IsDisposed);
    }
    [Test]
    public void WithHeader_ChainedCalls_AddsAllHeaders()
    {
        var response = new MockPipelineResponse()
            .WithHeader("Content-Type", "application/json")
            .WithHeader("Cache-Control", "no-cache")
            .WithHeader("X-Custom", "custom-value");
        Assert.IsTrue(response.Headers.TryGetValue("Content-Type", out var contentType));
        Assert.AreEqual("application/json", contentType);
        Assert.IsTrue(response.Headers.TryGetValue("Cache-Control", out var cacheControl));
        Assert.AreEqual("no-cache", cacheControl);
        Assert.IsTrue(response.Headers.TryGetValue("X-Custom", out var custom));
        Assert.AreEqual("custom-value", custom);
    }
    [Test]
    public void WithContent_ChainedWithHeaders_SetsContentAndHeaders()
    {
        var response = new MockPipelineResponse(201, "Created")
            .WithContent("response body")
            .WithHeader("Location", "/api/resource/123");
        Assert.AreEqual(201, response.Status);
        Assert.AreEqual("Created", response.ReasonPhrase);
        Assert.AreEqual("response body", response.Content.ToString());
        Assert.IsTrue(response.Headers.TryGetValue("Location", out var location));
        Assert.AreEqual("/api/resource/123", location);
    }
    [Test]
    public void ContentStream_WithNullContent_ReturnsEmptyStream()
    {
        var response = new MockPipelineResponse();
        var contentStream = response.ContentStream;
        Assert.IsNotNull(contentStream);
        Assert.AreEqual(0, contentStream.Length);
    }
    [Test]
    public void Content_WithNullContentStream_ReturnsEmptyBinaryData()
    {
        var response = new MockPipelineResponse();
        var content = response.Content;
        Assert.IsNotNull(content);
        Assert.AreEqual(0, content.ToArray().Length);
    }
    [Test]
    public void ContentStream_SettingToNull_HandlesGracefully()
    {
        var response = new MockPipelineResponse().WithContent("initial content");
        response.ContentStream = null;
        Assert.IsNotNull(response.ContentStream);
        Assert.AreEqual(0, response.ContentStream.Length);
    }
    [Test]
    public void ContentStream_SettingCustomStream_UpdatesContent()
    {
        var response = new MockPipelineResponse();
        var customContent = "custom stream content";
        var customStream = new MemoryStream(Encoding.UTF8.GetBytes(customContent));
        response.ContentStream = customStream;
        var resultStream = response.ContentStream;
        resultStream.Position = 0;
        using var reader = new StreamReader(resultStream, Encoding.UTF8);
        var result = reader.ReadToEnd();
        Assert.AreEqual(customContent, result);
    }
    [Test]
    public void Dispose_SetsIsDisposedToTrue()
    {
        var response = new MockPipelineResponse();
        response.Dispose();
        Assert.IsTrue(response.IsDisposed);
    }
    [Test]
    public void Dispose_MultipleCallsDoNotThrow()
    {
        var response = new MockPipelineResponse();
        Assert.DoesNotThrow(() => response.Dispose());
        Assert.DoesNotThrow(() => response.Dispose());
        Assert.DoesNotThrow(() => response.Dispose());
        Assert.IsTrue(response.IsDisposed);
    }
    [Test]
    public void Dispose_WithContent_BuffersContentBeforeDisposal()
    {
        var response = new MockPipelineResponse().WithContent("disposable content");
        response.Dispose();
        Assert.IsTrue(response.IsDisposed);
        Assert.AreEqual("disposable content", response.Content.ToString());
    }
    [Test]
    public void WithContent_EmptyString_SetsEmptyContent()
    {
        var response = new MockPipelineResponse().WithContent("");
        Assert.AreEqual("", response.Content.ToString());
        Assert.IsNotNull(response.ContentStream);
        Assert.AreEqual(0, response.ContentStream.Length);
    }
    [Test]
    public void WithContent_EmptyByteArray_SetsEmptyContent()
    {
        var response = new MockPipelineResponse().WithContent(new byte[0]);
        Assert.AreEqual(0, response.Content.ToArray().Length);
        Assert.IsNotNull(response.ContentStream);
        Assert.AreEqual(0, response.ContentStream.Length);
    }
    [Test]
    public void WithContent_LargeContent_HandlesCorrectly()
    {
        var largeContent = new string('x', 10000);
        var response = new MockPipelineResponse().WithContent(largeContent);
        Assert.AreEqual(largeContent, response.Content.ToString());
        Assert.AreEqual(10000, response.Content.ToArray().Length);
    }
    [Test]
    public void SetIsError_AffectsIsErrorProperty()
    {
        var response = new MockPipelineResponse();
        Assert.IsFalse(response.IsError);
        response.SetIsError(true);
        Assert.IsTrue(response.IsError);
        response.SetIsError(false);
        Assert.IsFalse(response.IsError);
    }
    [Test]
    public void Response_InheritsFromPipelineResponse()
    {
        var response = new MockPipelineResponse();
        Assert.IsInstanceOf<System.ClientModel.Primitives.PipelineResponse>(response);
    }
    [Test]
    public void Headers_ReturnsConsistentInstance()
    {
        var response = new MockPipelineResponse();
        var headers1 = response.Headers;
        var headers2 = response.Headers;
        Assert.AreSame(headers1, headers2);
    }
    [Test]
    public void WithContent_JsonContent_HandlesJsonCorrectly()
    {
        var jsonContent = """{"name": "test", "age": 30, "active": true}""";
        var response = new MockPipelineResponse(200, "OK")
            .WithContent(jsonContent)
            .WithHeader("Content-Type", "application/json");
        Assert.AreEqual(jsonContent, response.Content.ToString());
        Assert.IsTrue(response.Headers.TryGetValue("Content-Type", out var contentType));
        Assert.AreEqual("application/json", contentType);
    }
}