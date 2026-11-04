// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        yield return Case(ResponseItemKind.A2APreviewCall, typeof(A2AToolCall));
        yield return Case(ResponseItemKind.A2APreviewCallOutput, typeof(A2AToolCallOutput));
        yield return Case(ResponseItemKind.StructuredOutputs, typeof(AgentStructuredOutputsResponseItem));
        yield return Case(ResponseItemKind.WorkflowAction, typeof(AgentWorkflowPreviewActionResponseItem));
        yield return Case(ResponseItemKind.AzureAISearchCall, typeof(AzureAISearchToolCall));
        yield return Case(ResponseItemKind.AzureAISearchCallOutput, typeof(AzureAISearchToolCallOutput));
        yield return Case(ResponseItemKind.AzureFunctionCall, typeof(AzureFunctionToolCall));
        yield return Case(ResponseItemKind.AzureFunctionCallOutput, typeof(AzureFunctionToolCallOutput));
        yield return Case(ResponseItemKind.BingCustomSearchPreviewCall, typeof(BingCustomSearchToolCall));
        yield return Case(ResponseItemKind.BingCustomSearchPreviewCallOutput, typeof(BingCustomSearchToolCallOutput));
        yield return Case(ResponseItemKind.BingGroundingCall, typeof(BingGroundingToolCall));
        yield return Case(ResponseItemKind.BingGroundingCallOutput, typeof(BingGroundingToolCallOutput));
        yield return Case(ResponseItemKind.BrowserAutomationPreviewCall, typeof(BrowserAutomationToolCall));
        yield return Case(ResponseItemKind.BrowserAutomationPreviewCallOutput, typeof(BrowserAutomationToolCallOutput));
        yield return Case(ResponseItemKind.FabricDataAgentPreviewCall, typeof(FabricDataAgentToolCall));
        yield return Case(ResponseItemKind.FabricDataAgentPreviewCallOutput, typeof(FabricDataAgentToolCallOutput));
        yield return Case(ResponseItemKind.MemoryCommandPreviewCall, typeof(MemoryCommandToolCall));
        yield return Case(ResponseItemKind.MemoryCommandPreviewCallOutput, typeof(MemoryCommandToolCallOutput));
        yield return Case(ResponseItemKind.MemorySearchCall, typeof(MemorySearchToolCall));
        yield return Case(ResponseItemKind.OAuthConsentRequest, typeof(OAuthConsentRequestResponseItem));
        yield return Case(ResponseItemKind.OpenApiCall, typeof(OpenApiToolCall));
        yield return Case(ResponseItemKind.OpenApiCallOutput, typeof(OpenApiToolCallOutput));
        yield return Case(ResponseItemKind.SharepointGroundingPreviewCall, typeof(SharePointGroundingToolCall));
        yield return Case(ResponseItemKind.SharepointGroundingPreviewCallOutput, typeof(SharePointGroundingToolCallOutput));

        static TestCaseData Case(ResponseItemKind discriminator, Type expectedType)
            => new TestCaseData(discriminator, expectedType).SetName($"{{m}}({discriminator} => {expectedType.Name})");
    }

    private static string ItemJsonWithAttribution(ResponseItemKind discriminator)
    {
        // AgentStructuredOutputsResponseItem models a required `output` payload that its serializer
        // writes back verbatim; include it so the round-trip write has valid content to emit.
        string extraFields = discriminator.ToString() switch
        {
            "oauth_consent_request" => ",\n\"consent_link\": \"http://www.microsoft.com\"\n",
            "structured_outputs" => ",\n\"output\": {\"foo\": \"bar\"}\n",
            _ => ""
        };

        return $$"""
        {
          "type": "{{discriminator}}",
          "id": "item_1",
          "agent_reference": { "name": "{{ExpectedAgentName}}", "version": "{{ExpectedAgentVersion}}" },
          "response_id": "{{ExpectedResponseId}}",
          "status": "completed"{{extraFields}}
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

        using JsonDocument document = JsonDocument.Parse(rewritten);
        JsonProperty[] properties = [..document.RootElement.EnumerateObject()];
        Assert.Multiple(() =>
        {
            Assert.That(properties.Count(property => property.NameEquals("agent_reference")), Is.EqualTo(1),
                "agent_reference must be serialized exactly once.");
            Assert.That(properties.Count(property => property.NameEquals("response_id")), Is.EqualTo(1),
                "response_id must be serialized exactly once.");
        });

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
