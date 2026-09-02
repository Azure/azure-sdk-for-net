// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;
#pragma warning disable AAIP001

// Guards the Azure-only "attribution" fields conjured onto response output items via
// @@copyProperties: which agent (agent_reference) and which response (response_id) produced
// the item. These are read off the wire by the generated serializer but were being dropped on
// the way into the strongly-typed subtype, so callers could no longer tell which agent/response
// an output item came from. Unlike the sibling deserialization tests, these assert PROPERTY
// VALUES (not just the materialized type), which is the coverage that was missing when the
// fields were lost.
[Category("Smoke")]
[Parallelizable(ParallelScope.All)]
public class ResponseItemAgentAttributionTests
{
    private const string ExpectedAgentName = "audit-agent";
    private const string ExpectedAgentVersion = "7";
    private const string ExpectedResponseId = "resp_abc123";

    // Representative spread across call items, output items, and non-tool-call agent items. The
    // attribution fields lived on the shared item base, so proving fidelity on this subset proves
    // it for the whole hierarchy.
    private static IEnumerable<TestCaseData> AttributionItemKinds()
    {
        yield return Case(ResponseItemKind.BingGroundingCall, typeof(BingGroundingToolCall));
        yield return Case(ResponseItemKind.BingGroundingCallOutput, typeof(BingGroundingToolCallOutput));
        yield return Case(ResponseItemKind.AzureAISearchCall, typeof(AzureAISearchToolCall));
        yield return Case(ResponseItemKind.A2APreviewCall, typeof(A2AToolCall));
        yield return Case(ResponseItemKind.StructuredOutputs, typeof(AgentStructuredOutputsResponseItem));

        static TestCaseData Case(ResponseItemKind discriminator, Type expectedType)
            => new TestCaseData(discriminator, expectedType).SetName($"{{m}}({discriminator} => {expectedType.Name})");
    }

    private static string ItemJsonWithAttribution(ResponseItemKind discriminator)
    {
        // AgentStructuredOutputsResponseItem models a required `output` payload that its serializer
        // writes back verbatim; include it so the round-trip write has valid content to emit.
        string extraFields = discriminator == ResponseItemKind.StructuredOutputs
            ? """, "output": { "result": "ok" }"""
            : string.Empty;

        return $$"""
        {
          "type": "{{discriminator}}",
          "id": "item_1",
          "agent_reference": { "name": "{{ExpectedAgentName}}", "version": "{{ExpectedAgentVersion}}" },
          "response_id": "{{ExpectedResponseId}}"{{extraFields}}
        }
        """;
    }

    [TestCaseSource(nameof(AttributionItemKinds))]
    public void DeserializedItemSurfacesAgentAttribution(ResponseItemKind discriminator, Type expectedType)
    {
        ResponseItem item = ModelReaderWriter.Read<ResponseItem>(
            BinaryData.FromString(ItemJsonWithAttribution(discriminator)),
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);

        Assert.That(item, Is.InstanceOf(expectedType));
        Assert.That(item.AgentReference, Is.Not.Null, "agent_reference should materialize to a typed AgentReference.");
        Assert.That(item.AgentReference.Name, Is.EqualTo(ExpectedAgentName));
        Assert.That(item.AgentReference.Version, Is.EqualTo(ExpectedAgentVersion));
        Assert.That(item.ResponseId, Is.EqualTo(ExpectedResponseId));
    }

    [TestCaseSource(nameof(AttributionItemKinds))]
    public void AgentAttributionSurvivesRoundTrip(ResponseItemKind discriminator, Type expectedType)
    {
        ResponseItem item = ModelReaderWriter.Read<ResponseItem>(
            BinaryData.FromString(ItemJsonWithAttribution(discriminator)),
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);

        BinaryData rewritten = ModelReaderWriter.Write(item, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);

        ResponseItem roundTripped = ModelReaderWriter.Read<ResponseItem>(
            rewritten,
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);

        Assert.That(roundTripped, Is.InstanceOf(expectedType));
        Assert.That(roundTripped.AgentReference?.Name, Is.EqualTo(ExpectedAgentName),
            "agent_reference must survive a write/read round trip, not be dropped on re-serialization.");
        Assert.That(roundTripped.AgentReference?.Version, Is.EqualTo(ExpectedAgentVersion));
        Assert.That(roundTripped.ResponseId, Is.EqualTo(ExpectedResponseId));
    }
}
#pragma warning restore AAIP001
