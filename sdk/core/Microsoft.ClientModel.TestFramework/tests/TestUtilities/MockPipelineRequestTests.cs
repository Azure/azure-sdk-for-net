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
        using (Assert.EnterMultipleScope())
        {
            Assert.That(request.Method, Is.EqualTo("GET"));
            Assert.That(request.Uri?.ToString(), Is.EqualTo("https://www.example.com/"));
            Assert.That(request.Content, Is.Null);
            Assert.That(request.Headers, Is.Not.Null);
        }
    }
    [Test]
    public void Method_CanBeSetAndRetrieved()
    {
        var request = new MockPipelineRequest();
        request.Method = "POST";
        Assert.That(request.Method, Is.EqualTo("POST"));
    }
    [Test]
    public void Method_CanBeSetToAllHttpMethods()
    {
        var request = new MockPipelineRequest();
        var httpMethods = new[] { "GET", "POST", "PUT", "DELETE", "PATCH", "HEAD", "OPTIONS" };
        foreach (var method in httpMethods)
        {
            request.Method = method;
            Assert.That(request.Method, Is.EqualTo(method));
        }
    }
    [Test]
    public void Uri_CanBeSetAndRetrieved()
    {
        var request = new MockPipelineRequest();
        var testUri = new Uri("https://api.example.com/v1/resource");
        request.Uri = testUri;
        Assert.That(request.Uri, Is.EqualTo(testUri));
        Assert.That(request.Uri.ToString(), Is.EqualTo("https://api.example.com/v1/resource"));
    }
    [Test]
    public void Uri_CanBeSetToNull()
    {
        var request = new MockPipelineRequest();
        var testUri = new Uri("https://api.example.com/v1/resource");
        request.Uri = testUri;
        request.Uri = null;
        Assert.That(request.Uri, Is.Null);
    }
    [Test]
    public void Content_CanBeSetAndRetrieved()
    {
        var request = new MockPipelineRequest();
        var content = BinaryContent.Create(BinaryData.FromString("test content"));
        request.Content = content;
        Assert.That(request.Content, Is.SameAs(content));
    }
    [Test]
    public void Content_CanBeSetToNull()
    {
        var request = new MockPipelineRequest();
        var content = BinaryContent.Create(BinaryData.FromString("test content"));
        request.Content = content;
        request.Content = null;
        Assert.That(request.Content, Is.Null);
    }
    [Test]
    public void Content_WithJsonData_IsSetCorrectly()
    {
        var request = new MockPipelineRequest();
        var jsonContent = """{"name": "test", "value": 123}""";
        var content = BinaryContent.Create(BinaryData.FromString(jsonContent));
        request.Content = content;
        Assert.That(request.Content, Is.Not.Null);
    }
    [Test]
    public void Headers_ReturnsNonNullInstance()
    {
        var request = new MockPipelineRequest();
        Assert.That(request.Headers, Is.Not.Null);
    }
    [Test]
    public void Headers_CanAddAndRetrieveValues()
    {
        var request = new MockPipelineRequest();
        request.Headers.Add("Content-Type", "application/json");
        request.Headers.Add("Authorization", "Bearer token123");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(request.Headers.TryGetValue("Content-Type", out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo("application/json"));
            Assert.That(request.Headers.TryGetValue("Authorization", out var auth), Is.True);
            Assert.That(auth, Is.EqualTo("Bearer token123"));
        }
    }
    [Test]
    public void Headers_PersistAcrossRequests()
    {
        var request = new MockPipelineRequest();
        request.Headers.Add("X-Custom-Header", "custom-value");
        var retrievedHeaders = request.Headers;
        Assert.That(retrievedHeaders, Is.SameAs(request.Headers));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(retrievedHeaders.TryGetValue("X-Custom-Header", out var value), Is.True);
            Assert.That(value, Is.EqualTo("custom-value"));
        }
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
        Assert.That(request, Is.InstanceOf<PipelineRequest>());
    }
    [Test]
    public void Request_CanBeUsedPolymorphically()
    {
        PipelineRequest request = new MockPipelineRequest();
        request.Method = "PUT";
        request.Uri = new Uri("https://polymorphic.example.com");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(request.Method, Is.EqualTo("PUT"));
            Assert.That(request.Uri.ToString(), Is.EqualTo("https://polymorphic.example.com/"));
        }
    }
    [Test]
    public void Request_WithComplexUri_HandlesCorrectly()
    {
        var request = new MockPipelineRequest();
        var complexUri = new Uri("https://api.example.com:8080/v2/users/123?include=profile&format=json#section");
        request.Uri = complexUri;
        Assert.That(request.Uri, Is.EqualTo(complexUri));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(request.Uri.Scheme, Is.EqualTo("https"));
            Assert.That(request.Uri.Host, Is.EqualTo("api.example.com"));
            Assert.That(request.Uri.Port, Is.EqualTo(8080));
            Assert.That(request.Uri.AbsolutePath, Is.EqualTo("/v2/users/123"));
            Assert.That(request.Uri.Query, Is.EqualTo("?include=profile&format=json"));
            Assert.That(request.Uri.Fragment, Is.EqualTo("#section"));
        }
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
        using (Assert.EnterMultipleScope())
        {
            Assert.That(request.Method, Is.EqualTo("POST"));
            Assert.That(request.Uri.ToString(), Is.EqualTo("https://chain.example.com/"));
            Assert.That(request.Content, Is.SameAs(content));
            Assert.That(request.Headers.TryGetValue("X-Test", out var headerValue), Is.True);
            Assert.That(headerValue, Is.EqualTo("chained"));
        }
    }
    [Test]
    public void Request_HandlesEmptyStringMethod()
    {
        var request = new MockPipelineRequest();
        request.Method = "";
        Assert.That(request.Method, Is.Empty);
    }
    [Test]
    public void Request_HandlesNullMethod()
    {
        var request = new MockPipelineRequest();
        request.Method = null!;
        Assert.That(request.Method, Is.Null);
    }
}
