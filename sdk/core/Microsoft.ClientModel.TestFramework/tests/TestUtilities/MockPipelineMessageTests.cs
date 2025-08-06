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
        Assert.IsNotNull(message);
        Assert.IsNotNull(message.Request);
        Assert.IsInstanceOf<MockPipelineRequest>(message.Request);
        Assert.IsNull(message.Response);
    }
    [Test]
    public void Constructor_WithRequest_SetsRequestCorrectly()
    {
        var request = new MockPipelineRequest();
        var message = new MockPipelineMessage(request);
        Assert.IsNotNull(message);
        Assert.AreSame(request, message.Request);
        Assert.IsNull(message.Response);
    }
    [Test]
    public void SetResponse_SetsResponseCorrectly()
    {
        var message = new MockPipelineMessage();
        var response = new MockPipelineResponse(200, "OK");
        message.SetResponse(response);
        Assert.AreSame(response, message.Response);
    }
    [Test]
    public void SetResponse_WithDifferentResponses_UpdatesResponse()
    {
        var message = new MockPipelineMessage();
        var response1 = new MockPipelineResponse(200, "OK");
        var response2 = new MockPipelineResponse(404, "Not Found");
        message.SetResponse(response1);
        Assert.AreSame(response1, message.Response);
        message.SetResponse(response2);
        Assert.AreSame(response2, message.Response);
        Assert.AreNotSame(response1, message.Response);
    }
    [Test]
    public void SetResponse_WithNull_SetsResponseToNull()
    {
        var message = new MockPipelineMessage();
        var response = new MockPipelineResponse(200, "OK");
        message.SetResponse(response);
        message.SetResponse(null!);
        Assert.IsNull(message.Response);
    }
    [Test]
    public void Message_InheritsFromPipelineMessage()
    {
        var message = new MockPipelineMessage();
        Assert.IsInstanceOf<PipelineMessage>(message);
    }
    [Test]
    public void Message_WithCustomRequest_PreservesRequestProperties()
    {
        var request = new MockPipelineRequest();
        request.Method = "POST";
        request.Uri = new System.Uri("https://example.com/api");
        var message = new MockPipelineMessage(request);
        Assert.AreSame(request, message.Request);
        Assert.AreEqual("POST", message.Request.Method);
        Assert.AreEqual("https://example.com/api", message.Request.Uri?.ToString());
    }
    [Test]
    public void Message_CanBeUsedInPipelineContext()
    {
        var message = new MockPipelineMessage();
        var response = new MockPipelineResponse(201, "Created");
        message.SetResponse(response);
        Assert.IsNotNull(message.Request);
        Assert.IsNotNull(message.Response);
        Assert.AreEqual(201, message.Response.Status);
        Assert.AreEqual("Created", message.Response.ReasonPhrase);
    }
    [Test]
    public void Message_AllowsResponseAccess()
    {
        var message = new MockPipelineMessage();
        var response = new MockPipelineResponse(500, "Internal Server Error");
        response.SetIsError(true);
        message.SetResponse(response);
        Assert.IsTrue(message.Response.IsError);
        Assert.AreEqual(500, message.Response.Status);
        Assert.AreEqual("Internal Server Error", message.Response.ReasonPhrase);
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
            Assert.AreSame(response, message.Response);
            Assert.AreEqual(response.Status, message.Response.Status);
            Assert.AreEqual(response.ReasonPhrase, message.Response.ReasonPhrase);
        }
    }
}
