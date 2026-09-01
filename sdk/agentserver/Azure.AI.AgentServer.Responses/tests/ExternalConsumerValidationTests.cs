// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests;

/// <summary>
/// T019: External consumer validation — proves that a consumer project
/// (no InternalsVisibleTo) can implement ResponseHandler and construct
/// all needed types using public constructors only.
/// Validates SC-001.
/// </summary>
public class ExternalConsumerValidationTests
{
    [Test]
    public void Consumer_CanConstruct_Response_ViaConvenienceConstructor()
    {
        var response = new ResponseObject { Id = "resp_123", Model = "gpt-4o" };
        Assert.That(response.Id, Is.EqualTo("resp_123"));
        Assert.That(response.Model, Is.EqualTo("gpt-4o"));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseCreatedEvent()
    {
        var response = new ResponseObject { Id = "resp_123", Model = "gpt-4o" };
        var evt = new ResponseCreatedEvent { SequenceNumber = (int)(0), Response = response };
        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Response, Is.EqualTo(response));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseInProgressEvent()
    {
        var response = new ResponseObject { Id = "resp_123", Model = "gpt-4o" };
        var evt = new ResponseInProgressEvent { SequenceNumber = (int)(1), Response = response };
        Assert.That(evt, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseTextDeltaEvent()
    {
        var evt = new ResponseTextDeltaEvent { SequenceNumber = (int)(2), ItemId = "item_1", OutputIndex = (int)(0), ContentIndex = (int)(0), Delta = "Hello " };
 foreach (var __v in Array.Empty<ResponseLogProb>() ?? []) evt.TokenLogProbabilities.Add(__v);
        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Delta, Is.EqualTo("Hello "));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseTextDoneEvent()
    {
        var evt = new ResponseTextDoneEvent { SequenceNumber = (int)(3), ItemId = "item_1", OutputIndex = (int)(0), ContentIndex = (int)(0), Text = "Hello world" };
 foreach (var __v in Array.Empty<ResponseLogProb>() ?? []) evt.TokenLogProbabilities.Add(__v);
        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Text, Is.EqualTo("Hello world"));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseCompletedEvent()
    {
        var response = new ResponseObject { Id = "resp_123", Model = "gpt-4o" };
        var evt = new ResponseCompletedEvent { SequenceNumber = (int)(4), Response = response };
        Assert.That(evt, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanConstruct_ErrorPath()
    {
        var error = OpenAIModelFactory.CreateError(ResponseErrorCode.ServerError.ToString(), "failed");
        var response = new ResponseObject { Id = "resp_err", Model = "gpt-4o" };
        response.Error = error;
        var evt = new ResponseFailedEvent { SequenceNumber = (int)(5), Response = response };

        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Response.Error.Message, Is.EqualTo("failed"));
    }

    [Test]
    public void Consumer_CanConstruct_OutputItemMessage()
    {
        var content = ResponseContentPart.CreateOutputTextPart(text: "Hello world", annotations: Array.Empty<Annotation>());
        Assert.That(content, Is.Not.Null);

        var outputMsg = MessageItemFactory.OutputMessage(
            id: "msg_test",
            content: new List<ResponseContentPart> { content },
            status: MessageStatus.Completed);
        Assert.That(outputMsg, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseOutputItemDoneEvent()
    {
        var content = ResponseContentPart.CreateOutputTextPart(text: "Hello world", annotations: Array.Empty<Annotation>());
        var outputMsg = MessageItemFactory.OutputMessage(
            id: "msg_test",
            content: new List<ResponseContentPart> { content },
            status: MessageStatus.Completed);
        var evt = new ResponseOutputItemDoneEvent { SequenceNumber = (int)(6), OutputIndex = (int)(0), Item = outputMsg };

        Assert.That(evt, Is.Not.Null);
        XAssert.IsType<OutputItemMessage>(evt.Item);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseError()
    {
        var error = OpenAIModelFactory.CreateError(ResponseErrorCode.ServerError.ToString(), "test");
        Assert.That(error.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(error.Message, Is.EqualTo("test"));
    }

    [Test]
    public void Consumer_CanUse_ResponsesModelFactory()
    {
        var response = ResponsesModelFactory.ResponseObject(id: "mock_resp");
        Assert.That(response, Is.Not.Null);

        var error = ResponsesModelFactory.ResponseErrorInfo(
            code: ResponseErrorCode.InvalidPrompt,
            message: "bad input");
        Assert.That(error, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanSetProperties_AfterConstruction()
    {
        // R2 accepted: public setters allow post-construction customization
        var response = new ResponseObject { Id = "resp_123", Model = "gpt-4o" };
        response.Status = ResponseStatus.Completed;

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public void Consumer_CanConstruct_CreateResponse()
    {
        var request = new CreateResponse();
        Assert.That(request, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanSetProperties_OnCreateResponse()
    {
        var request = new CreateResponse
        {
            Model = "gpt-4o",
            Instructions = "You are a helpful assistant.",
            StreamingEnabled = true,
            BackgroundModeEnabled = false,
        };

        Assert.That(request.Model, Is.EqualTo("gpt-4o"));
        Assert.That(request.Instructions, Is.EqualTo("You are a helpful assistant."));
        Assert.That(request.StreamingEnabled, Is.True);
        Assert.That(request.BackgroundModeEnabled, Is.False);
    }
}
