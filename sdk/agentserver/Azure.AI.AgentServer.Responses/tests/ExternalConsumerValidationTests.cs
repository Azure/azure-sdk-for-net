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
        var evt = new ResponseCreatedEvent(sequenceNumber: 0, response: response);
        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Response, Is.EqualTo(response));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseInProgressEvent()
    {
        var response = new Models.ResponseObject("resp_123", "gpt-4o");
        var evt = new ResponseInProgressEvent(sequenceNumber: 1, response: response);
        Assert.That(evt, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseTextDeltaEvent()
    {
        var evt = new ResponseTextDeltaEvent(
            sequenceNumber: 2,
            itemId: "item_1",
            outputIndex: 0,
            contentIndex: 0,
            delta: "Hello ",
            logprobs: Array.Empty<ResponseLogProb>());
        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Delta, Is.EqualTo("Hello "));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseTextDoneEvent()
    {
        var evt = new ResponseTextDoneEvent(
            sequenceNumber: 3,
            itemId: "item_1",
            outputIndex: 0,
            contentIndex: 0,
            text: "Hello world",
            logprobs: Array.Empty<ResponseLogProb>());
        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Text, Is.EqualTo("Hello world"));
    }

    [Test]
    public void Consumer_CanConstruct_ResponseCompletedEvent()
    {
        var response = new Models.ResponseObject("resp_123", "gpt-4o");
        var evt = new ResponseCompletedEvent(sequenceNumber: 4, response: response);
        Assert.That(evt, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanConstruct_ErrorPath()
    {
        var error = new Models.ResponseErrorInfo(ResponseErrorCode.ServerError, "failed");
        var response = new Models.ResponseObject("resp_err", "gpt-4o");
        response.Error = error;
        var evt = new ResponseFailedEvent(sequenceNumber: 5, response: response);

        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Response.Error.Message, Is.EqualTo("failed"));
    }

    [Test]
    public void Consumer_CanConstruct_OutputItemMessage()
    {
        var content = new MessageContentOutputTextContent(
            text: "Hello world",
            annotations: Array.Empty<Annotation>(),
            logprobs: Array.Empty<LogProb>());
        Assert.That(content, Is.Not.Null);

        var outputMsg = new OutputItemMessage(
            id: "msg_test",
            content: new List<MessageContent> { content },
            status: MessageStatus.Completed);
        Assert.That(outputMsg, Is.Not.Null);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseOutputItemDoneEvent()
    {
        var content = new MessageContentOutputTextContent(
            text: "Hello world",
            annotations: Array.Empty<Annotation>(),
            logprobs: Array.Empty<LogProb>());
        var outputMsg = new OutputItemMessage(
            id: "msg_test",
            content: new List<MessageContent> { content },
            status: MessageStatus.Completed);
        var evt = new ResponseOutputItemDoneEvent(
            sequenceNumber: 6,
            outputIndex: 0,
            item: outputMsg);

        Assert.That(evt, Is.Not.Null);
        XAssert.IsType<OutputItemMessage>(evt.Item);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseError()
    {
        var error = new Models.ResponseErrorInfo(ResponseErrorCode.ServerError, "test");
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
        Assert.That(request.Stream, Is.True);
        Assert.That(request.Background, Is.False);
    }
}
