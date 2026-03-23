// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

/// <summary>
/// Spike tests verifying that @@usage decorators make compact constructors public,
/// while ensuring no unwanted side effects.
/// T001: Verify compact constructors are public for 3 spike types.
/// T002: Verify no unwanted side effects (abstract bases, full ctors, property accessors).
/// </summary>
public class PublicConstructorSpikeTests
{
    // ===========================================
    // T001: Compact constructors are public
    // ===========================================

    [Test]
    public void ResponseCreatedEvent_HasPublicCompactConstructor()
    {
        var ctor = typeof(ResponseCreatedEvent).GetConstructor(
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: [typeof(long), typeof(Models.Response)],
            modifiers: null);

        Assert.IsNotNull(ctor);
        Assert.IsTrue(ctor!.IsPublic);
    }

    [Test]
    public void ResponseCompletedEvent_HasPublicCompactConstructor()
    {
        var ctor = typeof(ResponseCompletedEvent).GetConstructor(
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: [typeof(long), typeof(Models.Response)],
            modifiers: null);

        Assert.IsNotNull(ctor);
        Assert.IsTrue(ctor!.IsPublic);
    }

    [Test]
    public void ResponseError_HasPublicCompactConstructor()
    {
        var ctor = typeof(Models.ResponseError).GetConstructor(
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: [typeof(ResponseErrorCode), typeof(string)],
            modifiers: null);

        Assert.IsNotNull(ctor);
        Assert.IsTrue(ctor!.IsPublic);
    }

    // ===========================================
    // T002: No unwanted side effects
    // ===========================================

    [Test]
    public void ResponseStreamEvent_HasNoPublicConstructors()
    {
        var publicCtors = typeof(ResponseStreamEvent)
            .GetConstructors(BindingFlags.Public | BindingFlags.Instance);

        Assert.IsEmpty(publicCtors);
    }

    [Test]
    public void ResponseCreatedEvent_FullCtorRemainsNonPublic()
    {
        // The full/serialization constructor includes IDictionary<string, BinaryData>.
        // It should remain internal.
        var fullCtor = typeof(ResponseCreatedEvent).GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance,
            binder: null,
            types: [typeof(ResponseStreamEventType), typeof(long), typeof(IDictionary<string, BinaryData>), typeof(Models.Response)],
            modifiers: null);

        Assert.IsNotNull(fullCtor);
        Assert.IsFalse(fullCtor!.IsPublic, "Full serialization constructor should remain non-public");
    }

    [Test]
    public void ResponseCreatedEvent_Properties_HavePublicSetters()
    {
        // @@usage with Usage.input causes the emitter to generate { get; set; }
        // instead of { get; }. This is expected behavior for input models.
        var type = typeof(ResponseCreatedEvent);

        var responseProp = type.GetProperty("Response", BindingFlags.Public | BindingFlags.Instance);
        Assert.IsNotNull(responseProp);
        Assert.IsNotNull(responseProp!.GetSetMethod(nonPublic: false));

        var seqNumProp = type.GetProperty("SequenceNumber", BindingFlags.Public | BindingFlags.Instance);
        Assert.IsNotNull(seqNumProp);
        Assert.IsNotNull(seqNumProp!.GetSetMethod(nonPublic: false));
    }

    [Test]
    public void ResponseCompletedEvent_Properties_HavePublicSetters()
    {
        var type = typeof(ResponseCompletedEvent);

        var responseProp = type.GetProperty("Response", BindingFlags.Public | BindingFlags.Instance);
        Assert.IsNotNull(responseProp);
        Assert.IsNotNull(responseProp!.GetSetMethod(nonPublic: false));
    }

    [Test]
    public void ResponseError_Properties_HavePublicSetters()
    {
        var type = typeof(Models.ResponseError);

        var codeProp = type.GetProperty("Code", BindingFlags.Public | BindingFlags.Instance);
        Assert.IsNotNull(codeProp);
        Assert.IsNotNull(codeProp!.GetSetMethod(nonPublic: false));

        var msgProp = type.GetProperty("Message", BindingFlags.Public | BindingFlags.Instance);
        Assert.IsNotNull(msgProp);
        Assert.IsNotNull(msgProp!.GetSetMethod(nonPublic: false));
    }

    [Test]
    public void ResponseStreamEvent_IsAbstract()
    {
        Assert.IsTrue(typeof(ResponseStreamEvent).IsAbstract);
    }
}
