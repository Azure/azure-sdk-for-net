// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests;

/// <summary>
/// Verifies SDK internal state management after ResponseState removal.
/// Models.ResponseObject now has public setters via @@usage, so ResponseState is no longer needed.
/// </summary>
public class InternalStateManagementTests
{
    private static readonly Assembly ContractsAssembly = typeof(Models.ResponseObject).Assembly;
    private static readonly Assembly SdkAssembly = typeof(ResponseHandler).Assembly;

    [Test]
    public void ResponseState_NoLongerExists()
    {
        var responseStateType = ContractsAssembly.GetType(
            "Azure.AI.AgentServer.Responses.Internal.ResponseState");

        Assert.That(responseStateType, Is.Null);
    }

    [Test]
    public void Response_CanBeConstructedAndMutatedDirectly()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
        };

        Assert.That(response.Id, Is.EqualTo("resp_test"));
        Assert.That(response.Model, Is.EqualTo("gpt-4o"));
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.InProgress));

        // Mutate
        response.Status = ResponseStatus.Completed;
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public void ResponseEndpointHandler_IsInternal()
    {
        var handlerType = SdkAssembly.GetType(
            "Azure.AI.AgentServer.Responses.Internal.ResponseEndpointHandler");

        Assert.That(handlerType, Is.Not.Null);
        Assert.That(handlerType!.IsPublic, Is.False, "ResponseEndpointHandler should be internal — not part of public API");
    }

    [Test]
    public void Response_PublicProperties_HaveSetters_AcceptedR2Behavior()
    {
        // R2 confirmed: @@usage generates { get; set; } on all properties.
        // This is accepted as beneficial for consumer construction.
        var statusProp = typeof(Models.ResponseObject).GetProperty("Status");
        Assert.That(statusProp, Is.Not.Null);
        Assert.That(statusProp!.GetSetMethod(), Is.Not.Null);

        var errorProp = typeof(Models.ResponseObject).GetProperty("Error");
        Assert.That(errorProp, Is.Not.Null);
        Assert.That(errorProp!.GetSetMethod(), Is.Not.Null);
    }
}
