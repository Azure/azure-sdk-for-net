// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

/// <summary>
/// T008: Comprehensive reflection tests asserting all 53 concrete ResponseStreamEvent
/// subtypes have public compact constructors.
/// </summary>
public class PublicConstructorEventTests
{
    /// <summary>
    /// All 53 concrete ResponseStreamEvent subtypes.
    /// </summary>
    public static IEnumerable<object[]> ConcreteEventTypes => new[]
    {
        new object[] { typeof(ResponseAudioDeltaEvent) },
        new object[] { typeof(ResponseAudioDoneEvent) },
        new object[] { typeof(ResponseAudioTranscriptDeltaEvent) },
        new object[] { typeof(ResponseAudioTranscriptDoneEvent) },
        new object[] { typeof(ResponseCodeInterpreterCallCodeDeltaEvent) },
        new object[] { typeof(ResponseCodeInterpreterCallCodeDoneEvent) },
        new object[] { typeof(ResponseCodeInterpreterCallCompletedEvent) },
        new object[] { typeof(ResponseCodeInterpreterCallInProgressEvent) },
        new object[] { typeof(ResponseCodeInterpreterCallInterpretingEvent) },
        new object[] { typeof(ResponseCompletedEvent) },
        new object[] { typeof(ResponseContentPartAddedEvent) },
        new object[] { typeof(ResponseContentPartDoneEvent) },
        new object[] { typeof(ResponseCreatedEvent) },
        new object[] { typeof(ResponseCustomToolCallInputDeltaEvent) },
        new object[] { typeof(ResponseCustomToolCallInputDoneEvent) },
        new object[] { typeof(ResponseErrorEvent) },
        new object[] { typeof(ResponseFailedEvent) },
        new object[] { typeof(ResponseFileSearchCallCompletedEvent) },
        new object[] { typeof(ResponseFileSearchCallInProgressEvent) },
        new object[] { typeof(ResponseFileSearchCallSearchingEvent) },
        new object[] { typeof(ResponseFunctionCallArgumentsDeltaEvent) },
        new object[] { typeof(ResponseFunctionCallArgumentsDoneEvent) },
        new object[] { typeof(ResponseImageGenCallCompletedEvent) },
        new object[] { typeof(ResponseImageGenCallGeneratingEvent) },
        new object[] { typeof(ResponseImageGenCallInProgressEvent) },
        new object[] { typeof(ResponseImageGenCallPartialImageEvent) },
        new object[] { typeof(ResponseIncompleteEvent) },
        new object[] { typeof(ResponseInProgressEvent) },
        new object[] { typeof(ResponseMCPCallArgumentsDeltaEvent) },
        new object[] { typeof(ResponseMCPCallArgumentsDoneEvent) },
        new object[] { typeof(ResponseMCPCallCompletedEvent) },
        new object[] { typeof(ResponseMCPCallFailedEvent) },
        new object[] { typeof(ResponseMCPCallInProgressEvent) },
        new object[] { typeof(ResponseMCPListToolsCompletedEvent) },
        new object[] { typeof(ResponseMCPListToolsFailedEvent) },
        new object[] { typeof(ResponseMCPListToolsInProgressEvent) },
        new object[] { typeof(ResponseOutputItemAddedEvent) },
        new object[] { typeof(ResponseOutputItemDoneEvent) },
        new object[] { typeof(ResponseOutputTextAnnotationAddedEvent) },
        new object[] { typeof(ResponseQueuedEvent) },
        new object[] { typeof(ResponseReasoningSummaryPartAddedEvent) },
        new object[] { typeof(ResponseReasoningSummaryPartDoneEvent) },
        new object[] { typeof(ResponseReasoningSummaryTextDeltaEvent) },
        new object[] { typeof(ResponseReasoningSummaryTextDoneEvent) },
        new object[] { typeof(ResponseReasoningTextDeltaEvent) },
        new object[] { typeof(ResponseReasoningTextDoneEvent) },
        new object[] { typeof(ResponseRefusalDeltaEvent) },
        new object[] { typeof(ResponseRefusalDoneEvent) },
        new object[] { typeof(ResponseTextDeltaEvent) },
        new object[] { typeof(ResponseTextDoneEvent) },
        new object[] { typeof(ResponseWebSearchCallCompletedEvent) },
        new object[] { typeof(ResponseWebSearchCallInProgressEvent) },
        new object[] { typeof(ResponseWebSearchCallSearchingEvent) },
    };

    [TestCaseSource(nameof(ConcreteEventTypes))]
    public void ConcreteEventType_HasAtLeastOnePublicConstructor(Type eventType)
    {
        var publicCtors = eventType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

        Assert.That(publicCtors.Length > 0, Is.True,
            $"{eventType.Name} should have at least one public constructor but has none.");
    }

    [TestCaseSource(nameof(ConcreteEventTypes))]
    public void ConcreteEventType_FullCtorRemainsNonPublic(Type eventType)
    {
        // The full/serialization constructor includes IDictionary<string, BinaryData>.
        // Verify it exists and is non-public.
        var allCtors = eventType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        var fullCtors = allCtors.Where(c =>
            c.GetParameters().Any(p => p.ParameterType == typeof(IDictionary<string, BinaryData>)));

        foreach (var ctor in fullCtors)
        {
            Assert.That(ctor.IsPublic, Is.False, $"{eventType.Name} serialization constructor should remain non-public.");
        }
    }

    [Test]
    public void AbstractResponseStreamEvent_HasNoPublicConstructors()
    {
        var publicCtors = typeof(ResponseStreamEvent).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors, Is.Empty);
    }

    [Test]
    public void AbstractResponseStreamEvent_RemainsAbstract()
    {
        Assert.That(typeof(ResponseStreamEvent).IsAbstract, Is.True);
    }

    [Test]
    public void ConcreteEventTypes_Count_Is53()
    {
        Assert.That(ConcreteEventTypes.Count(), Is.EqualTo(53));
    }
}
