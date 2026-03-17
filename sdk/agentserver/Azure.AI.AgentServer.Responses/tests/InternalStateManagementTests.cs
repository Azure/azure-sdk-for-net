// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests;

/// <summary>
/// Verifies SDK internal state management after ResponseState removal.
/// Models.Response now has public setters via @@usage, so ResponseState is no longer needed.
/// </summary>
public class InternalStateManagementTests
{
    private static readonly Assembly ContractsAssembly = typeof(Models.Response).Assembly;
    private static readonly Assembly SdkAssembly = typeof(IResponseHandler).Assembly;

    [Test]
    public void ResponseState_NoLongerExists()
    {
        var responseStateType = ContractsAssembly.GetType(
            "Azure.AI.AgentServer.Responses.Internal.ResponseState");

        Assert.IsNull(responseStateType);
    }

    [Test]
    public void Response_CanBeConstructedAndMutatedDirectly()
    {
        var response = new Models.Response("resp_test", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
        };

        Assert.AreEqual("resp_test", response.Id);
        Assert.AreEqual("gpt-4o", response.Model);
        Assert.AreEqual(ResponseStatus.InProgress, response.Status);

        // Mutate
        response.Status = ResponseStatus.Completed;
        Assert.AreEqual(ResponseStatus.Completed, response.Status);
    }

    [Test]
    public void ResponseEndpointHandler_IsInternal()
    {
        var handlerType = SdkAssembly.GetType(
            "Azure.AI.AgentServer.Responses.Internal.ResponseEndpointHandler");

        Assert.IsNotNull(handlerType);
        Assert.IsFalse(handlerType!.IsPublic,
            "ResponseEndpointHandler should be internal — not part of public API");
    }

    [Test]
    public void Response_PublicProperties_HaveSetters_AcceptedR2Behavior()
    {
        // R2 confirmed: @@usage generates { get; set; } on all properties.
        // This is accepted as beneficial for consumer construction.
        var statusProp = typeof(Models.Response).GetProperty("Status");
        Assert.IsNotNull(statusProp);
        Assert.IsNotNull(statusProp!.GetSetMethod());

        var errorProp = typeof(Models.Response).GetProperty("Error");
        Assert.IsNotNull(errorProp);
        Assert.IsNotNull(errorProp!.GetSetMethod());
    }
}
