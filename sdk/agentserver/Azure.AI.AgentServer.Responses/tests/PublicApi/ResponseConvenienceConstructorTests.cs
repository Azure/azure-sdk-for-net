// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

/// <summary>
/// T013: Validates that ResponseObject has a 2-param convenience constructor (string id, string model)
/// per S-047 (convenience constructor).
/// </summary>
public class ResponseConvenienceConstructorTests
{
    [Test]
    public void Response_HasPublicParameterlessConstructor()
    {
        var ctor = typeof(ResponseObject).GetConstructor(Type.EmptyTypes);
        Assert.That(ctor, Is.Not.Null);
        Assert.That(ctor!.IsPublic, Is.True, "Response() should be public");
    }

    [Test]
    public void Response_ConvenienceConstructor_SetsIdAndModel()
    {
        var response = new ResponseObject { Id = "resp_123", Model = "gpt-4o" };
        Assert.That(response.Id, Is.EqualTo("resp_123"));
        Assert.That(response.Model, Is.EqualTo("gpt-4o"));
    }

    [Test]
    public void Response_ModelFactory_SetsCreatedAt()
    {
        var before = DateTimeOffset.UtcNow;
        var response = AgentServerResponsesModelFactory.ResponseObject(id: "resp_123", model: "gpt-4o");
        var after = DateTimeOffset.UtcNow;

        XAssert.InRange(response.CreatedAt, before, after);
    }

    [Test]
    public void Response_ConvenienceConstructor_HasEmptyOutput()
    {
        var response = new ResponseObject { Id = "resp_123", Model = "gpt-4o" };
        Assert.That(response.OutputItems, Is.Not.Null);
        Assert.That(response.OutputItems, Is.Empty);
    }

    [Test]
    public void Response_ConvenienceConstructor_DefaultsParallelToolCallsToFalse()
    {
        var response = new ResponseObject { Id = "resp_123", Model = "gpt-4o" };
        Assert.That(response.ParallelToolCallsEnabled, Is.False);
    }

    [Test]
    public void Response_ConvenienceConstructor_ProducesValidInstance()
    {
        // Validates the instance is usable (no NullReferenceException on access)
        var response = new ResponseObject { Id = "resp_123", Model = "gpt-4o" };
        Assert.That(response, Is.Not.Null);
        XAssert.IsType<ResponseObject>(response);
    }
}
