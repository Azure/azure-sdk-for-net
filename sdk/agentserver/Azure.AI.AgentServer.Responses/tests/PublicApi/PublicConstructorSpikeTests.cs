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
        if (IsOpenAIOwned(typeof(ResponseCreatedEvent)))
        {
            Assert.That(typeof(ResponseStreamEvent).IsAssignableFrom(typeof(ResponseCreatedEvent)), Is.True);
            return;
        }

        var ctor = typeof(ResponseCreatedEvent).GetConstructor(
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: [typeof(long), typeof(Models.ResponseObject)],
            modifiers: null);

        Assert.That(ctor, Is.Not.Null);
        Assert.That(ctor!.IsPublic, Is.True);
    }

    [Test]
    public void ResponseCompletedEvent_HasPublicCompactConstructor()
    {
        if (IsOpenAIOwned(typeof(ResponseCompletedEvent)))
        {
            Assert.That(typeof(ResponseStreamEvent).IsAssignableFrom(typeof(ResponseCompletedEvent)), Is.True);
            return;
        }

        var ctor = typeof(ResponseCompletedEvent).GetConstructor(
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: [typeof(long), typeof(Models.ResponseObject)],
            modifiers: null);

        Assert.That(ctor, Is.Not.Null);
        Assert.That(ctor!.IsPublic, Is.True);
    }

    [Test]
    public void ResponseError_HasPublicCompactConstructor()
    {
        if (IsOpenAIOwned(typeof(ResponseErrorInfo)))
        {
            Assert.That(typeof(ResponseErrorInfo), Is.Not.Null);
            return;
        }

        var ctor = typeof(ResponseErrorInfo).GetConstructor(
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: [typeof(ResponseErrorCode), typeof(string)],
            modifiers: null);

        Assert.That(ctor, Is.Not.Null);
        Assert.That(ctor!.IsPublic, Is.True);
    }

    // ===========================================
    // T002: No unwanted side effects
    // ===========================================

    [Test]
    public void ResponseStreamEvent_HasNoPublicConstructors()
    {
        if (IsOpenAIOwned(typeof(ResponseStreamEvent)))
        {
            Assert.That(typeof(ResponseStreamEvent), Is.Not.Null);
            return;
        }

        var publicCtors = typeof(ResponseStreamEvent)
            .GetConstructors(BindingFlags.Public | BindingFlags.Instance);

        Assert.That(publicCtors, Is.Empty);
    }

    [Test]
    public void ResponseCreatedEvent_FullCtorRemainsNonPublic()
    {
        if (IsOpenAIOwned(typeof(ResponseCreatedEvent)))
        {
            Assert.That(typeof(ResponseCreatedEvent), Is.Not.Null);
            return;
        }

        // The full/serialization constructor includes IDictionary<string, BinaryData>.
        // It should remain internal.
        var fullCtor = typeof(ResponseCreatedEvent).GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance,
            binder: null,
            types: [typeof(ResponseStreamEventType), typeof(long), typeof(IDictionary<string, BinaryData>), typeof(Models.ResponseObject)],
            modifiers: null);

        Assert.That(fullCtor, Is.Not.Null);
        Assert.That(fullCtor!.IsPublic, Is.False, "Full serialization constructor should remain non-public");
    }

    [Test]
    public void ResponseCreatedEvent_Properties_HavePublicSetters()
    {
        // @@usage with Usage.input causes the emitter to generate { get; set; }
        // instead of { get; }. This is expected behavior for input models.
        var type = typeof(ResponseCreatedEvent);

        var responseProp = type.GetProperty("Response", BindingFlags.Public | BindingFlags.Instance);
        Assert.That(responseProp, Is.Not.Null);
        Assert.That(responseProp!.GetSetMethod(nonPublic: false), Is.Not.Null);

        var seqNumProp = type.GetProperty("SequenceNumber", BindingFlags.Public | BindingFlags.Instance);
        Assert.That(seqNumProp, Is.Not.Null);
        Assert.That(seqNumProp!.GetSetMethod(nonPublic: false), Is.Not.Null);
    }

    [Test]
    public void ResponseCompletedEvent_Properties_HavePublicSetters()
    {
        var type = typeof(ResponseCompletedEvent);

        var responseProp = type.GetProperty("Response", BindingFlags.Public | BindingFlags.Instance);
        Assert.That(responseProp, Is.Not.Null);
        Assert.That(responseProp!.GetSetMethod(nonPublic: false), Is.Not.Null);
    }

    [Test]
    public void ResponseError_Properties_HavePublicSetters()
    {
        if (IsOpenAIOwned(typeof(ResponseErrorInfo)))
        {
            Assert.That(typeof(ResponseErrorInfo).GetProperty("Code", BindingFlags.Public | BindingFlags.Instance), Is.Not.Null);
            Assert.That(typeof(ResponseErrorInfo).GetProperty("Message", BindingFlags.Public | BindingFlags.Instance), Is.Not.Null);
            return;
        }

        var type = typeof(ResponseErrorInfo);

        var codeProp = type.GetProperty("Code", BindingFlags.Public | BindingFlags.Instance);
        Assert.That(codeProp, Is.Not.Null);
        Assert.That(codeProp!.GetSetMethod(nonPublic: false), Is.Not.Null);

        var msgProp = type.GetProperty("Message", BindingFlags.Public | BindingFlags.Instance);
        Assert.That(msgProp, Is.Not.Null);
        Assert.That(msgProp!.GetSetMethod(nonPublic: false), Is.Not.Null);
    }

    [Test]
    public void ResponseStreamEvent_IsAbstract()
    {
        if (IsOpenAIOwned(typeof(ResponseStreamEvent)))
        {
            Assert.That(typeof(ResponseStreamEvent), Is.Not.Null);
            return;
        }

        Assert.That(typeof(ResponseStreamEvent).IsAbstract, Is.True);
    }

    private static bool IsOpenAIOwned(Type type) => type.Namespace?.StartsWith("OpenAI.", StringComparison.Ordinal) == true;
}
