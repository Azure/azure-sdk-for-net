// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests;

/// <summary>
/// T019: External consumer validation — proves that a consumer project
/// (no InternalsVisibleTo) can implement IResponseHandler and construct
/// all needed types using public constructors only.
/// Validates SC-001.
/// </summary>
public class ExternalConsumerValidationTests
{
    [Test]
    public void Consumer_CanConstruct_Response_ViaConvenienceConstructor()
    {
        var response = new Models.Response("resp_123", "gpt-4o");
        Assert.AreEqual("resp_123", response.Id);
        Assert.AreEqual("gpt-4o", response.Model);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseCreatedEvent()
    {
        var response = new Models.Response("resp_123", "gpt-4o");
        var evt = new ResponseCreatedEvent(sequenceNumber: 0, response: response);
        Assert.IsNotNull(evt);
        Assert.AreEqual(response, evt.Response);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseInProgressEvent()
    {
        var response = new Models.Response("resp_123", "gpt-4o");
        var evt = new ResponseInProgressEvent(sequenceNumber: 1, response: response);
        Assert.IsNotNull(evt);
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
        Assert.IsNotNull(evt);
        Assert.AreEqual("Hello ", evt.Delta);
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
        Assert.IsNotNull(evt);
        Assert.AreEqual("Hello world", evt.Text);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseCompletedEvent()
    {
        var response = new Models.Response("resp_123", "gpt-4o");
        var evt = new ResponseCompletedEvent(sequenceNumber: 4, response: response);
        Assert.IsNotNull(evt);
    }

    [Test]
    public void Consumer_CanConstruct_ErrorPath()
    {
        var error = new Models.ResponseError(ResponseErrorCode.ServerError, "failed");
        var response = new Models.Response("resp_err", "gpt-4o");
        response.Error = error;
        var evt = new ResponseFailedEvent(sequenceNumber: 5, response: response);

        Assert.IsNotNull(evt);
        Assert.AreEqual("failed", evt.Response.Error.Message);
    }

    [Test]
    public void Consumer_CanConstruct_OutputItemOutputMessage()
    {
        var content = new OutputMessageContentOutputTextContent(
            text: "Hello world",
            annotations: Array.Empty<Annotation>(),
            logprobs: Array.Empty<LogProb>());
        Assert.IsNotNull(content);

        var outputMsg = new OutputItemOutputMessage(
            id: "msg_test",
            content: new List<OutputMessageContent> { content },
            status: OutputItemOutputMessageStatus.Completed);
        Assert.IsNotNull(outputMsg);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseOutputItemDoneEvent()
    {
        var content = new OutputMessageContentOutputTextContent(
            text: "Hello world",
            annotations: Array.Empty<Annotation>(),
            logprobs: Array.Empty<LogProb>());
        var outputMsg = new OutputItemOutputMessage(
            id: "msg_test",
            content: new List<OutputMessageContent> { content },
            status: OutputItemOutputMessageStatus.Completed);
        var evt = new ResponseOutputItemDoneEvent(
            sequenceNumber: 6,
            outputIndex: 0,
            item: outputMsg);

        Assert.IsNotNull(evt);
        XAssert.IsType<OutputItemOutputMessage>(evt.Item);
    }

    [Test]
    public void Consumer_CanConstruct_ResponseError()
    {
        var error = new Models.ResponseError(ResponseErrorCode.ServerError, "test");
        Assert.AreEqual(ResponseErrorCode.ServerError, error.Code);
        Assert.AreEqual("test", error.Message);
    }

    [Test]
    public void Consumer_CanUse_ResponsesModelFactory()
    {
        var response = ResponsesModelFactory.Response(id: "mock_resp");
        Assert.IsNotNull(response);

        var error = ResponsesModelFactory.ResponseError(
            code: ResponseErrorCode.InvalidPrompt,
            message: "bad input");
        Assert.IsNotNull(error);
    }

    [Test]
    public void Consumer_CanSetProperties_AfterConstruction()
    {
        // R2 accepted: public setters allow post-construction customization
        var response = new Models.Response("resp_123", "gpt-4o");
        response.Status = ResponseStatus.Completed;

        Assert.AreEqual(ResponseStatus.Completed, response.Status);
    }

    [Test]
    public void Consumer_CanConstruct_CreateResponse()
    {
        var request = new CreateResponse();
        Assert.IsNotNull(request);
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

        Assert.AreEqual("gpt-4o", request.Model);
        Assert.AreEqual("You are a helpful assistant.", request.Instructions);
        Assert.IsTrue(request.Stream);
        Assert.IsFalse(request.Background);
    }
}
