// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class MockPipelineMessageTests
{
    [Test]
    public void DefaultConstructor_CreatesMessageWithDefaultRequest()
    {
        var message = new MockPipelineMessage();
        Assert.That(message, Is.Not.Null);
        Assert.That(message.Request, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Request, Is.InstanceOf<MockPipelineRequest>());
            Assert.That(message.Response, Is.Null);
        }
    }

    [Test]
    public void Constructor_WithRequest_SetsRequestCorrectly()
    {
        var request = new MockPipelineRequest();
        var message = new MockPipelineMessage(request);
        Assert.That(message, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Request, Is.SameAs(request));
            Assert.That(message.Response, Is.Null);
        }
    }

    [Test]
    public void SetResponse_SetsResponseCorrectly()
    {
        var message = new MockPipelineMessage();
        var response = new MockPipelineResponse(200, "OK");
        message.SetResponse(response);
        Assert.That(message.Response, Is.SameAs(response));
    }

    [Test]
    public void SetResponse_WithDifferentResponses_UpdatesResponse()
    {
        var message = new MockPipelineMessage();
        var response1 = new MockPipelineResponse(200, "OK");
        var response2 = new MockPipelineResponse(404, "Not Found");
        message.SetResponse(response1);
        Assert.That(message.Response, Is.SameAs(response1));
        message.SetResponse(response2);
        Assert.That(message.Response, Is.SameAs(response2));
        Assert.That(message.Response, Is.Not.SameAs(response1));
    }

    [Test]
    public void SetResponse_WithNull_SetsResponseToNull()
    {
        var message = new MockPipelineMessage();
        var response = new MockPipelineResponse(200, "OK");
        message.SetResponse(response);
        message.SetResponse(null!);
        Assert.That(message.Response, Is.Null);
    }

    [Test]
    public void Message_InheritsFromPipelineMessage()
    {
        var message = new MockPipelineMessage();
        Assert.That(message, Is.InstanceOf<PipelineMessage>());
    }

    [Test]
    public void Message_WithCustomRequest_PreservesRequestProperties()
    {
        var request = new MockPipelineRequest();
        request.Method = "POST";
        request.Uri = new System.Uri("https://example.com/api");
        var message = new MockPipelineMessage(request);
        Assert.That(message.Request, Is.SameAs(request));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Request.Method, Is.EqualTo("POST"));
            Assert.That(message.Request.Uri?.ToString(), Is.EqualTo("https://example.com/api"));
        }
    }

    [Test]
    public void Message_CanBeUsedInPipelineContext()
    {
        var message = new MockPipelineMessage();
        var response = new MockPipelineResponse(201, "Created");
        message.SetResponse(response);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Request, Is.Not.Null);
            Assert.That(message.Response, Is.Not.Null);
        }
        Assert.That(message.Response.Status, Is.EqualTo(201));
        Assert.That(message.Response.ReasonPhrase, Is.EqualTo("Created"));
    }

    [Test]
    public void Message_AllowsResponseAccess()
    {
        var message = new MockPipelineMessage();
        var response = new MockPipelineResponse(500, "Internal Server Error");
        response.SetIsError(true);
        message.SetResponse(response);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Response.IsError, Is.True);
            Assert.That(message.Response.Status, Is.EqualTo(500));
            Assert.That(message.Response.ReasonPhrase, Is.EqualTo("Internal Server Error"));
        }
    }

    [Test]
    public void Message_SupportsMultipleResponseUpdates()
    {
        var message = new MockPipelineMessage();
        var responses = new[]
        {
            new MockPipelineResponse(100, "Continue"),
            new MockPipelineResponse(200, "OK"),
            new MockPipelineResponse(304, "Not Modified")
        };
        foreach (var response in responses)
        {
            message.SetResponse(response);
            Assert.That(message.Response, Is.SameAs(response));
            using (Assert.EnterMultipleScope())
            {
                Assert.That(message.Response.Status, Is.EqualTo(response.Status));
                Assert.That(message.Response.ReasonPhrase, Is.EqualTo(response.ReasonPhrase));
            }
        }
    }
}
