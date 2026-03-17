// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

/// <summary>
/// T013: Validates that Models.Response has a 2-param convenience constructor (string id, string model)
/// per FR-002 (Models.Response ≤ 5 required params) and FR-010 (convenience constructor).
/// </summary>
public class ResponseConvenienceConstructorTests
{
    [Test]
    public void Response_HasTwoParamConvenienceConstructor()
    {
        var ctor = typeof(Models.Response).GetConstructor(new[] { typeof(string), typeof(string) });
        Assert.IsNotNull(ctor);
        Assert.IsTrue(ctor!.IsPublic, "Response(string, string) should be public");
    }

    [Test]
    public void Response_ConvenienceConstructor_SetsIdAndModel()
    {
        var response = new Models.Response("resp_123", "gpt-4o");
        Assert.AreEqual("resp_123", response.Id);
        Assert.AreEqual("gpt-4o", response.Model);
    }

    [Test]
    public void Response_ConvenienceConstructor_SetsCreatedAt()
    {
        var before = DateTimeOffset.UtcNow;
        var response = new Models.Response("resp_123", "gpt-4o");
        var after = DateTimeOffset.UtcNow;

        XAssert.InRange(response.CreatedAt, before, after);
    }

    [Test]
    public void Response_ConvenienceConstructor_HasEmptyOutput()
    {
        var response = new Models.Response("resp_123", "gpt-4o");
        Assert.IsNotNull(response.Output);
        Assert.IsEmpty(response.Output);
    }

    [Test]
    public void Response_ConvenienceConstructor_DefaultsParallelToolCallsToFalse()
    {
        var response = new Models.Response("resp_123", "gpt-4o");
        Assert.IsFalse(response.ParallelToolCalls);
    }

    [Test]
    public void Response_ConvenienceConstructor_ProducesValidInstance()
    {
        // Validates the instance is usable (no NullReferenceException on access)
        var response = new Models.Response("resp_123", "gpt-4o");
        Assert.IsNotNull(response);
        XAssert.IsType<Models.Response>(response);
    }
}
