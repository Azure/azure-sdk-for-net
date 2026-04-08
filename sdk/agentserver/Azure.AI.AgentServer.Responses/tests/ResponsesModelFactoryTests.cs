// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests;

/// <summary>
/// T017: Validates ResponsesModelFactory existence and basic functionality.
/// Per AGENTS.md Principle VIII (Designed for Testability &amp; Mocking).
/// </summary>
public class ResponsesModelFactoryTests
{
    [Test]
    public void ResponsesModelFactory_Exists_IsPublicStatic()
    {
        var factoryType = typeof(ResponsesModelFactory);
        Assert.That(factoryType, Is.Not.Null);
        Assert.That(factoryType.IsPublic, Is.True, "ResponsesModelFactory should be public");
        Assert.That(factoryType.IsAbstract && factoryType.IsSealed, Is.True, "ResponsesModelFactory should be static (abstract + sealed)");
    }

    [Test]
    public void ResponsesModelFactory_Response_ReturnsValidInstance()
    {
        var response = ResponsesModelFactory.ResponseObject(id: "resp_test");
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo("resp_test"));
    }

    [Test]
    public void ResponsesModelFactory_Response_UsesNamedOptionalParameters()
    {
        var response = ResponsesModelFactory.ResponseObject(
            id: "resp_test",
            model: "gpt-4o",
            status: ResponseStatus.Completed);

        Assert.That(response.Id, Is.EqualTo("resp_test"));
        Assert.That(response.Model, Is.EqualTo("gpt-4o"));
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public void ResponsesModelFactory_ResponseError_ReturnsValidInstance()
    {
        var error = ResponsesModelFactory.ResponseErrorInfo(
            code: ResponseErrorCode.ServerError,
            message: "Something went wrong");

        Assert.That(error, Is.Not.Null);
        Assert.That(error.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(error.Message, Is.EqualTo("Something went wrong"));
    }

    [Test]
    public void ResponsesModelFactory_ResponseCreatedEvent_ReturnsValidInstance()
    {
        var response = ResponsesModelFactory.ResponseObject(id: "resp_123", model: "gpt-4o");
        var evt = ResponsesModelFactory.ResponseCreatedEvent(
            response: response,
            sequenceNumber: 1);

        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Response, Is.EqualTo(response));
        Assert.That(evt.SequenceNumber, Is.EqualTo(1));
    }
}
