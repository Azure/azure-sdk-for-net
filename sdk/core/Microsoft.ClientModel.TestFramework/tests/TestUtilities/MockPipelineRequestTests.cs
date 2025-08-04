// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class MockPipelineRequestTests
{
    [Test]
    public void DefaultConstructor_SetsDefaultValues()
    {
        var request = new MockPipelineRequest();

        Assert.AreEqual("GET", request.Method);
        Assert.AreEqual("https://www.example.com/", request.Uri?.ToString());
        Assert.IsNull(request.Content);
        Assert.IsNotNull(request.Headers);
    }

    [Test]
    public void Method_CanBeSetAndRetrieved()
    {
        var request = new MockPipelineRequest();
        request.Method = "POST";
        Assert.AreEqual("POST", request.Method);
    }

    [Test]
    public void Method_CanBeSetToAllHttpMethods()
    {
        var request = new MockPipelineRequest();
        var httpMethods = new[] { "GET", "POST", "PUT", "DELETE", "PATCH", "HEAD", "OPTIONS" };
        foreach (var method in httpMethods)
        {
            request.Method = method;
            Assert.AreEqual(method, request.Method);
        }
    }

    [Test]
    public void Uri_CanBeSetAndRetrieved()
    {
        var request = new MockPipelineRequest();
        var testUri = new Uri("https://api.example.com/v1/resource");
        request.Uri = testUri;
        Assert.AreEqual(testUri, request.Uri);
        Assert.AreEqual("https://api.example.com/v1/resource", request.Uri.ToString());
    }

    [Test]
    public void Uri_CanBeSetToNull()
    {
        var request = new MockPipelineRequest();
        var testUri = new Uri("https://api.example.com/v1/resource");
        request.Uri = testUri;
        request.Uri = null;
        Assert.IsNull(request.Uri);
    }

    [Test]
    public void Content_CanBeSetAndRetrieved()
    {
        var request = new MockPipelineRequest();
        var content = BinaryContent.Create(BinaryData.FromString("test content"));
        request.Content = content;
        Assert.AreSame(content, request.Content);
    }

    [Test]
    public void Content_CanBeSetToNull()
    {
        var request = new MockPipelineRequest();
        var content = BinaryContent.Create(BinaryData.FromString("test content"));
        request.Content = content;
        request.Content = null;
        Assert.IsNull(request.Content);
    }

    [Test]
    public void Content_WithJsonData_IsSetCorrectly()
    {
        var request = new MockPipelineRequest();
        var jsonContent = """{"name": "test", "value": 123}""";
        var content = BinaryContent.Create(BinaryData.FromString(jsonContent));
        request.Content = content;
        Assert.IsNotNull(request.Content);
    }

    [Test]
    public void Headers_ReturnsNonNullInstance()
    {
        var request = new MockPipelineRequest();
        Assert.IsNotNull(request.Headers);
    }

    [Test]
    public void Headers_CanAddAndRetrieveValues()
    {
        var request = new MockPipelineRequest();
        request.Headers.Add("Content-Type", "application/json");
        request.Headers.Add("Authorization", "Bearer token123");
        Assert.IsTrue(request.Headers.TryGetValue("Content-Type", out var contentType));
        Assert.AreEqual("application/json", contentType);
        Assert.IsTrue(request.Headers.TryGetValue("Authorization", out var auth));
        Assert.AreEqual("Bearer token123", auth);
    }

    [Test]
    public void Headers_PersistAcrossRequests()
    {
        var request = new MockPipelineRequest();
        request.Headers.Add("X-Custom-Header", "custom-value");
        var retrievedHeaders = request.Headers;
        Assert.AreSame(request.Headers, retrievedHeaders);
        Assert.IsTrue(retrievedHeaders.TryGetValue("X-Custom-Header", out var value));
        Assert.AreEqual("custom-value", value);
    }

    [Test]
    public void Dispose_DoesNotThrow()
    {
        var request = new MockPipelineRequest();
        Assert.DoesNotThrow(() => request.Dispose());
    }

    [Test]
    public void Dispose_CanBeCalledMultipleTimes()
    {
        var request = new MockPipelineRequest();
        Assert.DoesNotThrow(() => request.Dispose());
        Assert.DoesNotThrow(() => request.Dispose());
        Assert.DoesNotThrow(() => request.Dispose());
    }

    [Test]
    public void Request_InheritsFromPipelineRequest()
    {
        var request = new MockPipelineRequest();
        Assert.IsInstanceOf<PipelineRequest>(request);
    }

    [Test]
    public void Request_CanBeUsedPolymorphically()
    {
        PipelineRequest request = new MockPipelineRequest();
        request.Method = "PUT";
        request.Uri = new Uri("https://polymorphic.example.com");
        Assert.AreEqual("PUT", request.Method);
        Assert.AreEqual("https://polymorphic.example.com/", request.Uri.ToString());
    }

    [Test]
    public void Request_WithComplexUri_HandlesCorrectly()
    {
        var request = new MockPipelineRequest();
        var complexUri = new Uri("https://api.example.com:8080/v2/users/123?include=profile&format=json#section");
        request.Uri = complexUri;
        Assert.AreEqual(complexUri, request.Uri);
        Assert.AreEqual("https", request.Uri.Scheme);
        Assert.AreEqual("api.example.com", request.Uri.Host);
        Assert.AreEqual(8080, request.Uri.Port);
        Assert.AreEqual("/v2/users/123", request.Uri.AbsolutePath);
        Assert.AreEqual("?include=profile&format=json", request.Uri.Query);
        Assert.AreEqual("#section", request.Uri.Fragment);
    }

    [Test]
    public void Request_SupportsMethodChaining()
    {
        var request = new MockPipelineRequest();
        var content = BinaryContent.Create(BinaryData.FromString("chain test"));
        request.Method = "POST";
        request.Uri = new Uri("https://chain.example.com");
        request.Content = content;
        request.Headers.Add("X-Test", "chained");

        Assert.AreEqual("POST", request.Method);
        Assert.AreEqual("https://chain.example.com/", request.Uri.ToString());
        Assert.AreSame(content, request.Content);
        Assert.IsTrue(request.Headers.TryGetValue("X-Test", out var headerValue));
        Assert.AreEqual("chained", headerValue);
    }

    [Test]
    public void Request_HandlesEmptyStringMethod()
    {
        var request = new MockPipelineRequest();
        request.Method = "";
        Assert.AreEqual("", request.Method);
    }

    [Test]
    public void Request_HandlesNullMethod()
    {
        var request = new MockPipelineRequest();
        request.Method = null!;
        Assert.IsNull(request.Method);
    }
}
