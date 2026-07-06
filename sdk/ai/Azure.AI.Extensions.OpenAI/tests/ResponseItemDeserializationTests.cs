// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;

[Category("Smoke")]
[Parallelizable(ParallelScope.All)]
public class ResponseItemDeserializationTests
{
    // Maps each Azure-specific ResponseItem discriminator ("type") to the concrete
    // subtype that deserialization should materialize. Base-class dispatch through
    // ModelReaderWriter.Read<ResponseItem> must resolve these; otherwise the payload
    // falls through to OpenAI's opaque unknown-item fallback and the strongly-typed
    // Azure surface is silently lost.
    private static IEnumerable<TestCaseData> AzureResponseItemKinds()
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
        yield return Case(ResponseItemKind.SharepointGroundingPreviewCall, typeof(SharepointGroundingToolCall));
        yield return Case(ResponseItemKind.SharepointGroundingPreviewCallOutput, typeof(SharepointGroundingToolCallOutput));

        static TestCaseData Case(ResponseItemKind discriminator, Type expectedType)
            => new TestCaseData(discriminator, expectedType).SetName($"{{m}}({discriminator} => {expectedType.Name})");
    }

    [TestCaseSource(nameof(AzureResponseItemKinds))]
    public void ReadResponseItemMaterializesAzureSubtype(ResponseItemKind discriminator, Type expectedType)
    {
        string json = $$"""{ "type": "{{discriminator.ToString()}}" }""";

        ResponseItem item = ModelReaderWriter.Read<ResponseItem>(
            BinaryData.FromString(json),
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);

        Assert.That(item, Is.InstanceOf(expectedType), $"'{discriminator}' should deserialize to {expectedType.Name} but was {item?.GetType().Name}.");
    }

    [TestCaseSource(nameof(AzureResponseItemKinds))]
    public void AsAgentResponseItemMaterializesAzureSubtype(ResponseItemKind discriminator, Type expectedType)
    {
        string json = $$"""{ "type": "{{discriminator.ToString()}}" }""";

        ResponseItem item = ModelReaderWriter.Read<ResponseItem>(BinaryData.FromString(json));
        ResponseItem agentItem = item.AsAgentResponseItem();

        Assert.That(agentItem, Is.InstanceOf(expectedType), $"AsAgentResponseItem for '{discriminator}' should yield {expectedType.Name} but was {agentItem?.GetType().Name}.");
    }
}
