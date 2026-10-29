// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;
#pragma warning disable AAIP001

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
        yield return Case(ResponseItemKind.SharepointGroundingPreviewCall, typeof(SharePointGroundingToolCall));
        yield return Case(ResponseItemKind.SharepointGroundingPreviewCallOutput, typeof(SharePointGroundingToolCallOutput));

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
#pragma warning disable OPENAI001
        ResponseItem agentItem = item.AsAgentResponseItem();
#pragma warning restore OPENAI001
        Assert.That(agentItem, Is.InstanceOf(expectedType), $"AsAgentResponseItem for '{discriminator}' should yield {expectedType.Name} but was {agentItem?.GetType().Name}.");
    }

    [Test]
    [TestCaseSource(nameof(AzureResponseItemKinds))]
    public void DeserializeAzureToolCallPreservesIdAndJsonRoundTrip(ResponseItemKind toolDiscriminator, Type itemType)
    {
        string additionalFields = toolDiscriminator.ToString() switch
        {
            "oauth_consent_request" => ",\n\"consent_link\": \"http://www.microsoft.com\"\n",
            "structured_outputs" => ",\n\"output\": {\"foo\": \"bar\"}\n",
            _ => ""
        };
        BinaryData data = BinaryData.FromString($$"""
            {
              "type": "{{toolDiscriminator}}",
              "id": "item_1",
              "call_id": "call_1",
              "arguments": "{}",
              "status": "completed"{{additionalFields}},
              "unknown_field": "some_value"
            }
            """);

        ResponseItem item = ModelReaderWriter.Read<ResponseItem>(
            data,
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);

        Assert.That(item, Is.TypeOf(itemType));
        Assert.That(item.Id, Is.EqualTo("item_1"));
        Assert.That(item.Patch.GetString("$.unknown_field"u8), Is.EqualTo("some_value"));

        BinaryData serialized = ModelReaderWriter.Write(
            item,
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);

        ResponseItem roundTripped = ModelReaderWriter.Read<ResponseItem>(
            serialized,
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);

        Assert.That(roundTripped, Is.TypeOf(itemType));
        Assert.That(roundTripped.Id, Is.EqualTo("item_1"));
        Assert.That(item.Patch.GetString("$.unknown_field"u8), Is.EqualTo("some_value"));
    }

    [Test]
    [TestCaseSource(nameof(AzureResponseItemKinds))]
    public void DeserializeAzureToolCallFactory(ResponseItemKind toolDiscriminator, Type itemType)
    {
        AgentReference agentReference = new(name: "MockAgent", version: "1.0");
        string id = "123", responseId = "456", callId = "789", actionId = "777", parentActionId = "888", previousActionId = "999", name = "test", arguments = "foo: bar";
        BinaryData output = BinaryData.FromString("\"foo\"");
        ResponseItem item = toolDiscriminator.ToString() switch {
            "a2a_preview_call" => ExtensionsOpenAIModelFactory.A2AToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                name: name,
                arguments: arguments,
                status: ToolCallStatus.Completed
            ),
            "a2a_preview_call_output" => ExtensionsOpenAIModelFactory.A2AToolCallOutput(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                name: name,
                output: output,
                status: ToolCallStatus.Completed
                ),
            "structured_outputs" => ExtensionsOpenAIModelFactory.AgentStructuredOutputsResponseItem(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                output: output
                ),
            "workflow_action" => ExtensionsOpenAIModelFactory.AgentWorkflowPreviewActionResponseItem(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                csdlActionKind: "mock",
                actionId: actionId,
                parentActionId: parentActionId,
                previousActionId: previousActionId,
                status: AgentWorkflowPreviewActionStatus.Completed
                ),
            "azure_ai_search_call" => ExtensionsOpenAIModelFactory.AzureAISearchToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                arguments: arguments,
                status: ToolCallStatus.Completed
                ),
            "azure_ai_search_call_output" => ExtensionsOpenAIModelFactory.AzureAISearchToolCallOutput(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                output: output,
                status: ToolCallStatus.Completed
                ),
            "azure_function_call" => ExtensionsOpenAIModelFactory.AzureFunctionToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                name: name,
                arguments: arguments,
                status: ToolCallStatus.Completed
                ),
            "azure_function_call_output" => ExtensionsOpenAIModelFactory.AzureFunctionToolCallOutput(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                name: name,
                output: output,
                status: ToolCallStatus.Completed
                ),
            "bing_custom_search_preview_call" => ExtensionsOpenAIModelFactory.BingCustomSearchToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                arguments: arguments,
                status: ToolCallStatus.Completed
                ),
            "bing_custom_search_preview_call_output" => ExtensionsOpenAIModelFactory.BingCustomSearchToolCallOutput(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                output: output,
                status: ToolCallStatus.Completed
                ),
            "bing_grounding_call" => ExtensionsOpenAIModelFactory.BingGroundingToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                status: ToolCallStatus.Completed
                ),
            "bing_grounding_call_output" => ExtensionsOpenAIModelFactory.BingGroundingToolCallOutput(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                status: ToolCallStatus.Completed
                ),
            "browser_automation_preview_call" => ExtensionsOpenAIModelFactory.BrowserAutomationToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                arguments: arguments,
                status: ToolCallStatus.Completed
                ),
            "browser_automation_preview_call_output" => ExtensionsOpenAIModelFactory.BrowserAutomationToolCallOutput(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                output: output,
                status: ToolCallStatus.Completed
                ),
            "fabric_dataagent_preview_call" => ExtensionsOpenAIModelFactory.FabricDataAgentToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                arguments: arguments,
                status: ToolCallStatus.Completed
                ),
            "fabric_dataagent_preview_call_output" => ExtensionsOpenAIModelFactory.FabricDataAgentToolCallOutput(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                output: output,
                status: ToolCallStatus.Completed
                ),
            "memory_command_preview_call" => ExtensionsOpenAIModelFactory.MemoryCommandToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                arguments: arguments,
                status: ToolCallStatus.Completed
                ),
            "memory_command_preview_call_output" => ExtensionsOpenAIModelFactory.MemoryCommandToolCallOutput(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                status: ToolCallStatus.Completed
                ),
            "memory_search_call" => ExtensionsOpenAIModelFactory.MemorySearchToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                status: ToolCallStatus.Completed
                ),
            "oauth_consent_request" => ExtensionsOpenAIModelFactory.OAuthConsentRequestResponseItem(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                consentLink: new("https://www.microsoft.com/"),
                serverLabel: "Microsoft"
                ),
            "openapi_call" => ExtensionsOpenAIModelFactory.OpenApiToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                arguments: arguments,
                status: ToolCallStatus.Completed
                ),
            "openapi_call_output" => ExtensionsOpenAIModelFactory.OpenApiToolCallOutput(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                output: output,
                status: ToolCallStatus.Completed
                ),
            "sharepoint_grounding_preview_call" => ExtensionsOpenAIModelFactory.SharePointGroundingToolCall(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                arguments: arguments,
                status: ToolCallStatus.Completed
                ),
            "sharepoint_grounding_preview_call_output" => ExtensionsOpenAIModelFactory.SharePointGroundingToolCallOutput(
                id: id,
                agentReference: agentReference,
                responseId: responseId,
                callId: callId,
                output: output,
                status: ToolCallStatus.Completed
                ),
            _ => throw new InvalidOperationException($"Unknown item type {toolDiscriminator}"),
        };
        BinaryData json = ModelReaderWriter.Write(
            item, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        TestContext.WriteLine(json.ToString());
        using JsonDocument document = JsonDocument.Parse(json);

        // Checks for all tools
        Assert.That(item, Is.TypeOf(itemType));
        Assert.That(document.RootElement.TryGetProperty("agent_reference", out JsonElement agent),
            Is.True, "Factory-supplied agent metadata was dropped.");
        Assert.That(agent.GetProperty("name").GetString(), Is.EqualTo(agentReference.Name));
        Assert.That(agent.GetProperty("version").GetString(), Is.EqualTo(agentReference.Version));
        checkStringValueFromRoot(document.RootElement, "id", id);
        checkStringValueFromRoot(document.RootElement, "response_id", responseId);
        if (toolDiscriminator != ResponseItemKind.StructuredOutputs && toolDiscriminator != ResponseItemKind.OAuthConsentRequest)
        {
            checkStringValueFromRoot(document.RootElement, "status", "completed");
        }
        if (toolDiscriminator != ResponseItemKind.MemorySearchCall && toolDiscriminator != ResponseItemKind.OAuthConsentRequest && toolDiscriminator != ResponseItemKind.WorkflowAction && toolDiscriminator != ResponseItemKind.StructuredOutputs)
        {
            checkStringValueFromRoot(document.RootElement, "call_id", callId);
        }
        if (toolDiscriminator == ResponseItemKind.WorkflowAction)
        {
            checkStringValueFromRoot(document.RootElement, "CSDLActionKind", "mock");
            checkStringValueFromRoot(document.RootElement, "action_id", actionId);
            checkStringValueFromRoot(document.RootElement, "parent_action_id", parentActionId);
            checkStringValueFromRoot(document.RootElement, "previous_action_id", previousActionId);
        }
        else if (toolDiscriminator == ResponseItemKind.OAuthConsentRequest)
        {
            checkStringValueFromRoot(document.RootElement, "consent_link", "https://www.microsoft.com/");
            checkStringValueFromRoot(document.RootElement, "server_label", "Microsoft");
        }
        else if (toolDiscriminator.ToString().EndsWith("output"))
        {
            if (toolDiscriminator != ResponseItemKind.BingGroundingCallOutput && toolDiscriminator != ResponseItemKind.MemoryCommandPreviewCallOutput)
            {
                Assert.That(document.RootElement.TryGetProperty("output", out JsonElement readVal),
                    Is.True, "Factory-supplied response metadata was dropped.");
                Assert.That(readVal.GetString(), Is.EqualTo("foo"));
            }
        }
        else
        {
            if (toolDiscriminator != ResponseItemKind.BingGroundingCall && toolDiscriminator != ResponseItemKind.MemorySearchCall && toolDiscriminator != ResponseItemKind.StructuredOutputs)
            {
                checkStringValueFromRoot(document.RootElement, "arguments", arguments);
            }
        }
    }

    [Test]
    [TestCaseSource(nameof(AzureResponseItemKinds))]
    public void DeserializeAzureToolCallFactoryIdOnly(ResponseItemKind toolDiscriminator, Type itemType)
    {
        string id = "123";
        ResponseItem item = toolDiscriminator.ToString() switch
        {
            "a2a_preview_call" => ExtensionsOpenAIModelFactory.A2AToolCall(id: id),
            "a2a_preview_call_output" => ExtensionsOpenAIModelFactory.A2AToolCallOutput(id: id),
            "structured_outputs" => ExtensionsOpenAIModelFactory.AgentStructuredOutputsResponseItem(
                id: id,
                output: BinaryData.FromString("\"foo\"")
             ),
            "workflow_action" => ExtensionsOpenAIModelFactory.AgentWorkflowPreviewActionResponseItem(
                id: id,
                status: AgentWorkflowPreviewActionStatus.Cancelled
            ),
            "azure_ai_search_call" => ExtensionsOpenAIModelFactory.AzureAISearchToolCall(id: id),
            "azure_ai_search_call_output" => ExtensionsOpenAIModelFactory.AzureAISearchToolCallOutput(id: id),
            "azure_function_call" => ExtensionsOpenAIModelFactory.AzureFunctionToolCall(id: id),
            "azure_function_call_output" => ExtensionsOpenAIModelFactory.AzureFunctionToolCallOutput(id: id),
            "bing_custom_search_preview_call" => ExtensionsOpenAIModelFactory.BingCustomSearchToolCall(id: id),
            "bing_custom_search_preview_call_output" => ExtensionsOpenAIModelFactory.BingCustomSearchToolCallOutput(id: id),
            "bing_grounding_call" => ExtensionsOpenAIModelFactory.BingGroundingToolCall(id: id),
            "bing_grounding_call_output" => ExtensionsOpenAIModelFactory.BingGroundingToolCallOutput(id: id),
            "browser_automation_preview_call" => ExtensionsOpenAIModelFactory.BrowserAutomationToolCall(id: id),
            "browser_automation_preview_call_output" => ExtensionsOpenAIModelFactory.BrowserAutomationToolCallOutput(id: id),
            "fabric_dataagent_preview_call" => ExtensionsOpenAIModelFactory.FabricDataAgentToolCall(id: id),
            "fabric_dataagent_preview_call_output" => ExtensionsOpenAIModelFactory.FabricDataAgentToolCallOutput(id: id),
            "memory_command_preview_call" => ExtensionsOpenAIModelFactory.MemoryCommandToolCall(id: id),
            "memory_command_preview_call_output" => ExtensionsOpenAIModelFactory.MemoryCommandToolCallOutput(id: id),
            "memory_search_call" => ExtensionsOpenAIModelFactory.MemorySearchToolCall(id: id),
            "oauth_consent_request" => ExtensionsOpenAIModelFactory.OAuthConsentRequestResponseItem(
                id: id,
                consentLink: new Uri("https://www.microsoft.com"),
                serverLabel: "Microsoft"
             ),
            "openapi_call" => ExtensionsOpenAIModelFactory.OpenApiToolCall(id: id),
            "openapi_call_output" => ExtensionsOpenAIModelFactory.OpenApiToolCallOutput(id: id),
            "sharepoint_grounding_preview_call" => ExtensionsOpenAIModelFactory.SharePointGroundingToolCall(id: id),
            "sharepoint_grounding_preview_call_output" => ExtensionsOpenAIModelFactory.SharePointGroundingToolCallOutput(id: id),
            _ => throw new InvalidOperationException($"Unknown item type {toolDiscriminator}"),
        };
        BinaryData json = ModelReaderWriter.Write(
            item, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        TestContext.WriteLine(json.ToString());
        using JsonDocument document = JsonDocument.Parse(json);

        Assert.That(item, Is.TypeOf(itemType));
        checkStringValueFromRoot(document.RootElement, "id", id);
    }

    private static void checkStringValueFromRoot(JsonElement root, string name, string expectedValue)
    {
        Assert.That(root.TryGetProperty(name, out JsonElement readVal),
            Is.True, $"Factory-supplied response metadata {name} was dropped.");
        Assert.That(readVal.GetString(), Is.EqualTo(expectedValue));
    }
}
#pragma warning restore AAIP001
