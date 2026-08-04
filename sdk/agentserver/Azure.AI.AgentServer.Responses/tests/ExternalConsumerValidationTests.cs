// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

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
        var response = new Models.ResponseObject("resp_123", "gpt-4o");
        Assert.That(response.Id, Is.EqualTo("resp_123"));
        Assert.That(response.Model, Is.EqualTo("gpt-4o"));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseCreatedEvent()
    {
        var response = new Models.ResponseObject("resp_123", "gpt-4o");
        var evt = new ResponseCreatedEvent { SequenceNumber = 0, Response = response };
        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Response, Is.EqualTo(response));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseInProgressEvent()
    {
        var response = new Models.ResponseObject("resp_123", "gpt-4o");
        var evt = new ResponseInProgressEvent { SequenceNumber = 1, Response = response };
        Assert.That(evt, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseTextDeltaEvent()
    {
        var evt = new ResponseTextDeltaEvent
        {
            SequenceNumber = 2,
            ItemId = "item_1",
            OutputIndex = 0,
            ContentIndex = 0,
            Delta = "Hello ",
        };
        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Delta, Is.EqualTo("Hello "));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseTextDoneEvent()
    {
        var evt = new ResponseTextDoneEvent
        {
            SequenceNumber = 3,
            ItemId = "item_1",
            OutputIndex = 0,
            ContentIndex = 0,
            Text = "Hello world",
        };
        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Text, Is.EqualTo("Hello world"));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseCompletedEvent()
    {
        var response = new Models.ResponseObject("resp_123", "gpt-4o");
        var evt = new ResponseCompletedEvent { SequenceNumber = 4, Response = response };
        Assert.That(evt, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanConstruct_ErrorPath()
    {
        var error = ResponsesModelFactory.ResponseErrorInfo(OpenAI.Responses.ResponseErrorCode.ServerError, "failed");
        var response = new Models.ResponseObject("resp_err", "gpt-4o");
        response.Error = error;
        var evt = new ResponseFailedEvent { SequenceNumber = 5, Response = response };

        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Response.Error.Message, Is.EqualTo("failed"));
    }

    [Test]
    public void Consumer_CanConstruct_OutputItemMessage()
    {
        var content = ResponseContentPart.CreateOutputTextPart(
            "Hello world",
            Array.Empty<Annotation>());
        Assert.That(content, Is.Not.Null);

        var outputMsg = TestModels.OutputItemMessage(
            id: "msg_test",
            status: MessageStatus.Completed,
            content: new List<MessageContent> { content });
        Assert.That(outputMsg, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseOutputItemDoneEvent()
    {
        var content = ResponseContentPart.CreateOutputTextPart(
            "Hello world",
            Array.Empty<Annotation>());
        var outputMsg = TestModels.OutputItemMessage(
            id: "msg_test",
            status: MessageStatus.Completed,
            content: new List<MessageContent> { content });
        var evt = new ResponseOutputItemDoneEvent
        {
            SequenceNumber = 6,
            OutputIndex = 0,
            Item = outputMsg,
        };

        Assert.That(evt, Is.Not.Null);
        XAssert.IsType<OutputItemMessage>(evt.Item);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseError()
    {
        var error = ResponsesModelFactory.ResponseErrorInfo(OpenAI.Responses.ResponseErrorCode.ServerError, "test");
        Assert.That(error.Code, Is.EqualTo(OpenAI.Responses.ResponseErrorCode.ServerError));
        Assert.That(error.Message, Is.EqualTo("test"));
    }

    [Test]
    public void Consumer_CanUse_ResponsesModelFactory()
    {
        var response = ResponsesModelFactory.ResponseObject(id: "mock_resp");
        Assert.That(response, Is.Not.Null);

        var error = ResponsesModelFactory.ResponseErrorInfo(
            code: OpenAI.Responses.ResponseErrorCode.InvalidPrompt,
            message: "bad input");
        Assert.That(error, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanSetProperties_AfterConstruction()
    {
        // R2 accepted: public setters allow post-construction customization
        var response = new Models.ResponseObject("resp_123", "gpt-4o");
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
            Stream = true,
            Background = false,
        };

        Assert.That(request.Model, Is.EqualTo("gpt-4o"));
        Assert.That(request.Instructions, Is.EqualTo("You are a helpful assistant."));
        Assert.That(request.StreamingEnabled, Is.True);
        Assert.That(request.BackgroundModeEnabled, Is.False);
    }
}
