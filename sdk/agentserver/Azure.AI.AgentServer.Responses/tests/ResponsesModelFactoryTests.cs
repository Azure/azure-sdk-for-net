// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests;

/// <summary>
/// T017: Validates ResponsesModelFactory existence and basic functionality.
/// Per AGENTS.md Principle VIII (Designed for Testability &amp; Mocking) and FR-010.
/// </summary>
public class ResponsesModelFactoryTests
{
    [Test]
    public void ResponsesModelFactory_Exists_IsPublicStatic()
    {
        var factoryType = typeof(ResponsesModelFactory);
        Assert.IsNotNull(factoryType);
        Assert.IsTrue(factoryType.IsPublic, "ResponsesModelFactory should be public");
        Assert.IsTrue(factoryType.IsAbstract && factoryType.IsSealed,
            "ResponsesModelFactory should be static (abstract + sealed)");
    }

    [Test]
    public void ResponsesModelFactory_Response_ReturnsValidInstance()
    {
        var response = ResponsesModelFactory.Response(id: "resp_test");
        Assert.IsNotNull(response);
        Assert.AreEqual("resp_test", response.Id);
    }

    [Test]
    public void ResponsesModelFactory_Response_UsesNamedOptionalParameters()
    {
        var response = ResponsesModelFactory.Response(
            id: "resp_test",
            model: "gpt-4o",
            status: ResponseStatus.Completed);

        Assert.AreEqual("resp_test", response.Id);
        Assert.AreEqual("gpt-4o", response.Model);
        Assert.AreEqual(ResponseStatus.Completed, response.Status);
    }

    [Test]
    public void ResponsesModelFactory_ResponseError_ReturnsValidInstance()
    {
        var error = ResponsesModelFactory.ResponseError(
            code: ResponseErrorCode.ServerError,
            message: "Something went wrong");

        Assert.IsNotNull(error);
        Assert.AreEqual(ResponseErrorCode.ServerError, error.Code);
        Assert.AreEqual("Something went wrong", error.Message);
    }

    [Test]
    public void ResponsesModelFactory_ResponseCreatedEvent_ReturnsValidInstance()
    {
        var response = new Models.Response("resp_123", "gpt-4o");
        var evt = ResponsesModelFactory.ResponseCreatedEvent(
            response: response,
            sequenceNumber: 1);

        Assert.IsNotNull(evt);
        Assert.AreEqual(response, evt.Response);
        Assert.AreEqual(1, evt.SequenceNumber);
    }
}
