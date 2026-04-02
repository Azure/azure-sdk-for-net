// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core.Internal;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class RequestIdBaggagePropagatorTests
{
    [Test]
    public async Task InvokeAsync_SetsBaggage_WhenXRequestIdPresent()
    {
        var middleware = new RequestIdBaggagePropagator();
        var context = new DefaultHttpContext();
        context.Request.Headers["x-request-id"] = "test-request-123";

        // Start an activity so baggage can be set
        using var activity = new Activity("test").Start();

        await middleware.InvokeAsync(context, _ => Task.CompletedTask);

        var baggage = activity.GetBaggageItem("x-request-id");
        Assert.That(baggage, Is.EqualTo("test-request-123"));
    }

    [Test]
    public async Task InvokeAsync_DoesNotSetBaggage_WhenXRequestIdMissing()
    {
        var middleware = new RequestIdBaggagePropagator();
        var context = new DefaultHttpContext();

        using var activity = new Activity("test").Start();

        await middleware.InvokeAsync(context, _ => Task.CompletedTask);

        var baggage = activity.GetBaggageItem("x-request-id");
        Assert.That(baggage, Is.Null);
    }

    [Test]
    public async Task InvokeAsync_CallsNext_Regardless()
    {
        var middleware = new RequestIdBaggagePropagator();
        var context = new DefaultHttpContext();
        var nextCalled = false;

        await middleware.InvokeAsync(context, _ =>
        {
            nextCalled = true;
            return Task.CompletedTask;
        });

        Assert.That(nextCalled, Is.True);
    }
}
