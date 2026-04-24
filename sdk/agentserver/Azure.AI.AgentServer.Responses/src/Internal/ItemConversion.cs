// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Internal utility for converting <see cref="Item"/> instances from
/// <see cref="CreateResponse.Input"/> to <see cref="OutputItem"/> instances
/// suitable for storage and retrieval via the provider.
/// Each converted item receives a correctly prefixed ID via <see cref="IdGenerator.NewItemId"/>.
/// </summary>
internal static class ItemConversion
{
    /// <summary>
    /// Converts a single <see cref="Item"/> to an <see cref="OutputItem"/>.
    /// Generates a type-specific ID using <see cref="IdGenerator.NewItemId"/> and marks status as completed.
    /// </summary>
    /// <param name="item">The input item to convert.</param>
    /// <param name="partitionKeyHint">
    /// An existing ID (typically the response ID) from which to propagate the partition key
    /// into the generated item ID for storage colocation.
    /// </param>
    /// <returns>The converted output item, or <c>null</c> if the item type is not convertible (e.g., <see cref="ItemReferenceParam"/>).</returns>
    internal static OutputItem? ToOutputItem(Item item, string? partitionKeyHint)
    {
        var id = IdGenerator.NewItemId(item, partitionKeyHint);
        if (id is null)
        {
            return null; // non-convertible type (e.g. ItemReferenceParam)
        }

        return item switch
        {
            // --- Messages ---
            ItemMessage message => new OutputItemMessage(
                id,
                MessageStatus.Completed,
                message.Role,
                message.GetContentExpanded()),

            ItemOutputMessage outputMessage => new OutputItemMessage(
                id,
                ConvertStatus(outputMessage.Status),
                ConvertOutputMessageContent(outputMessage.Content)),

            // --- Function tool calls ---
            ItemFunctionToolCall funcCall => new OutputItemFunctionToolCall(
                OutputItemType.FunctionCall,
                createdBy: null,
                agentReference: null,
                responseId: null,
                additionalBinaryDataProperties: null,
                id: id,
                callId: funcCall.CallId,
                @namespace: null,
                name: funcCall.Name,
                arguments: funcCall.Arguments,
                status: ItemFunctionToolCallStatus.Completed),

            FunctionCallOutputItemParam funcOutput => new OutputItemFunctionToolCallOutput(
                OutputItemType.FunctionCallOutput,
                createdBy: null,
                agentReference: null,
                responseId: null,
                additionalBinaryDataProperties: null,
                id: id,
                callId: funcOutput.CallId,
                output: funcOutput.Output,
                status: OutputItemFunctionToolCallOutputStatus.Completed),

            // --- Custom tool calls ---
            ItemCustomToolCall customCall => new OutputItemCustomToolCall(
                customCall.CallId, customCall.Name, customCall.Input, FunctionCallStatus.Completed)
            { Id = id },

            ItemCustomToolCallOutput customOutput => new OutputItemCustomToolCallOutput(
                customOutput.CallId, customOutput.Output, FunctionCallOutputStatusEnum.Completed)
            { Id = id },

            // --- Computer tool calls ---
            ItemComputerToolCall computerCall => new OutputItemComputerToolCall(
                id,
                computerCall.CallId,
                computerCall.PendingSafetyChecks ?? [],
                ItemComputerToolCallStatus.Completed),

            ComputerCallOutputItemParam computerOutput => new OutputItemComputerToolCallOutput(
                OutputItemType.ComputerCallOutput,
                createdBy: null,
                agentReference: null,
                responseId: null,
                additionalBinaryDataProperties: null,
                id: id,
                callId: computerOutput.CallId,
                acknowledgedSafetyChecks: null,
                output: computerOutput.Output,
                status: OutputItemComputerToolCallOutputStatus.Completed),

            // --- File search ---
            ItemFileSearchToolCall fileSearch => ConvertFileSearchToolCall(fileSearch, id),

            // --- Web search ---
            ItemWebSearchToolCall webSearch => new OutputItemWebSearchToolCall(
                id,
                ItemWebSearchToolCallStatus.Completed,
                webSearch.Action),

            // --- Image generation ---
            ItemImageGenToolCall imageGen => new OutputItemImageGenToolCall(
                id,
                ItemImageGenToolCallStatus.Completed,
                imageGen.Result),

            // --- Code interpreter ---
            ItemCodeInterpreterToolCall codeInterpreter => new OutputItemCodeInterpreterToolCall(
                id,
                ItemCodeInterpreterToolCallStatus.Completed,
                codeInterpreter.ContainerId,
                codeInterpreter.Code,
                codeInterpreter.Outputs ?? []),

            // --- Local shell ---
            ItemLocalShellToolCall localShell => new OutputItemLocalShellToolCall(
                id,
                localShell.CallId,
                localShell.Action,
                ItemLocalShellToolCallStatus.Completed),

            ItemLocalShellToolCallOutput localShellOutput => new OutputItemLocalShellToolCallOutput(
                id, localShellOutput.Output)
            { Status = ItemLocalShellToolCallOutputStatus.Completed },

            // --- Function shell ---
            FunctionShellCallItemParam shellCall => ConvertFunctionShellCall(shellCall, id),

            FunctionShellCallOutputItemParam shellOutput => ConvertFunctionShellCallOutput(shellOutput, id),

            // --- Apply patch ---
            ApplyPatchToolCallItemParam applyPatch => new OutputItemApplyPatchToolCall(
                id,
                applyPatch.CallId,
                ConvertApplyPatchStatus(applyPatch.Status),
                ConvertApplyPatchOperation(applyPatch.Operation)),

            ApplyPatchToolCallOutputItemParam applyPatchOutput => new OutputItemApplyPatchToolCallOutput(
                id,
                applyPatchOutput.CallId,
                ConvertApplyPatchOutputStatus(applyPatchOutput.Status))
            { Output = applyPatchOutput.Output },

            // --- MCP ---
            ItemMcpListTools mcpListTools => new OutputItemMcpListTools(
                id, mcpListTools.ServerLabel, mcpListTools.Tools ?? [])
            { Error = mcpListTools.Error },

            ItemMcpToolCall mcpCall => new OutputItemMcpToolCall(
                id, mcpCall.ServerLabel, mcpCall.Name, mcpCall.Arguments)
            {
                Output = mcpCall.Output,
                Status = MCPToolCallStatus.Completed,
                ApprovalRequestId = mcpCall.ApprovalRequestId,
            },

            ItemMcpApprovalRequest mcpApproval => new OutputItemMcpApprovalRequest(
                id, mcpApproval.ServerLabel, mcpApproval.Name, mcpApproval.Arguments),

            MCPApprovalResponse mcpResponse => new OutputItemMcpApprovalResponseResource(
                id, mcpResponse.ApprovalRequestId, mcpResponse.Approve)
            { Reason = mcpResponse.Reason },

            // --- Reasoning ---
            ItemReasoningItem reasoning => new OutputItemReasoningItem(id, reasoning.Summary)
            {
                EncryptedContent = reasoning.EncryptedContent,
                Status = ItemReasoningItemStatus.Completed,
            },

            // --- Compaction ---
            CompactionSummaryItemParam compaction => new OutputItemCompactionBody(
                id, compaction.EncryptedContent),

            // Should not reach here — NewItemId returned non-null so the type is known.
            _ => null,
        };
    }

    /// <summary>
    /// Converts a sequence of <see cref="Item"/> instances to <see cref="OutputItem"/> instances.
    /// Each item receives a correctly prefixed ID via <see cref="IdGenerator.NewItemId"/>.
    /// Items that cannot be converted inline (e.g., <see cref="ItemReferenceParam"/>) are skipped.
    /// </summary>
    /// <param name="items">The input items to convert.</param>
    /// <param name="partitionKeyHint">
    /// An existing ID (typically the response ID) from which to propagate the partition key.
    /// </param>
    /// <returns>The converted output items (references excluded).</returns>
    internal static IEnumerable<OutputItem> ToOutputItems(
        IEnumerable<Item> items,
        string? partitionKeyHint)
    {
        foreach (var item in items)
        {
            var output = ToOutputItem(item, partitionKeyHint);
            if (output is not null)
            {
                yield return output;
            }
        }
    }

    /// <summary>
    /// Converts an <see cref="OutputItem"/> to its corresponding <see cref="Item"/> representation
    /// using JSON round-trip serialization. Both hierarchies share the same <c>"type"</c>
    /// discriminator values, so serializing an <see cref="OutputItem"/> and deserializing as
    /// <see cref="Item"/> produces the correct concrete subtype (e.g., <see cref="OutputItemMessage"/>
    /// → <see cref="ItemMessage"/>). Returns <c>null</c> if the output item has a type that does not
    /// map to any <see cref="Item"/> subtype.
    /// </summary>
    /// <param name="outputItem">The output item to convert.</param>
    /// <returns>The corresponding input item, or <c>null</c> if conversion is not possible.</returns>
    internal static Item? ToItem(OutputItem outputItem)
    {
        try
        {
            var json = ModelReaderWriter.Write(outputItem, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);
            return ModelReaderWriter.Read<Item>(json, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);
        }
        catch
        {
            return null;
        }
    }

    // ── ApplyPatch helpers ──────────────────────────────────────────────

    private static ApplyPatchCallStatus ConvertApplyPatchStatus(ApplyPatchCallStatusParam status)
    {
        return status == ApplyPatchCallStatusParam.Completed
            ? ApplyPatchCallStatus.Completed
            : ApplyPatchCallStatus.InProgress;
    }

    private static ApplyPatchCallOutputStatus ConvertApplyPatchOutputStatus(ApplyPatchCallOutputStatusParam status)
    {
        return status == ApplyPatchCallOutputStatusParam.Completed
            ? ApplyPatchCallOutputStatus.Completed
            : ApplyPatchCallOutputStatus.Failed;
    }

    private static ApplyPatchFileOperation ConvertApplyPatchOperation(ApplyPatchOperationParam operation)
    {
        return operation switch
        {
            ApplyPatchCreateFileOperationParam create => new ApplyPatchCreateFileOperation(create.Path, create.Diff),
            ApplyPatchDeleteFileOperationParam delete => new ApplyPatchDeleteFileOperation(delete.Path),
            ApplyPatchUpdateFileOperationParam update => new ApplyPatchUpdateFileOperation(update.Path, update.Diff),
            _ => throw new InvalidOperationException($"Unknown ApplyPatchOperationParam type: {operation?.GetType().Name}"),
        };
    }

    // ── FileSearch helper ───────────────────────────────────────────────

    private static OutputItemFileSearchToolCall ConvertFileSearchToolCall(
        ItemFileSearchToolCall fileSearch, string id)
    {
        var result = new OutputItemFileSearchToolCall(
            id,
            ItemFileSearchToolCallStatus.Completed,
            fileSearch.Queries ?? []);
        if (fileSearch.Results is { Count: > 0 })
        {
            foreach (var r in fileSearch.Results)
            {
                result.Results.Add(r);
            }
        }

        return result;
    }

    // ── FunctionShell helpers ───────────────────────────────────────────

    private static OutputItemFunctionShellCall ConvertFunctionShellCall(
        FunctionShellCallItemParam shellCall, string id)
    {
        var action = new FunctionShellAction(
            shellCall.Action.Commands,
            shellCall.Action.TimeoutMs,
            shellCall.Action.MaxOutputLength);

        var environment = ConvertShellEnvironment(shellCall.Environment);

        return new OutputItemFunctionShellCall(
            id,
            shellCall.CallId,
            action,
            LocalShellCallStatus.Completed,
            environment);
    }

    private static OutputItemFunctionShellCallOutput ConvertFunctionShellCallOutput(
        FunctionShellCallOutputItemParam shellOutput, string id)
    {
        var outputContents = new List<FunctionShellCallOutputContent>();
        foreach (var param in shellOutput.Output)
        {
            var outcome = ConvertShellOutcome(param.Outcome);
            outputContents.Add(new FunctionShellCallOutputContent(param.Stdout, param.Stderr, outcome));
        }

        return new OutputItemFunctionShellCallOutput(
            id,
            shellOutput.CallId,
            LocalShellCallOutputStatusEnum.Completed,
            outputContents,
            shellOutput.MaxOutputLength);
    }

    private static FunctionShellCallEnvironment ConvertShellEnvironment(
        FunctionShellCallItemParamEnvironment? environment)
    {
        return environment switch
        {
            FunctionShellCallItemParamEnvironmentContainerReferenceParam container
                => new ContainerReferenceResource(container.ContainerId),
            FunctionShellCallItemParamEnvironmentLocalEnvironmentParam
                => new LocalEnvironmentResource(),
            // null or unknown → default to local
            _ => new LocalEnvironmentResource(),
        };
    }

    private static FunctionShellCallOutputOutcome ConvertShellOutcome(
        FunctionShellCallOutputOutcomeParam? outcome)
    {
        return outcome switch
        {
            FunctionShellCallOutputExitOutcomeParam exit
                => new FunctionShellCallOutputExitOutcome(exit.ExitCode),
            FunctionShellCallOutputTimeoutOutcomeParam
                => new FunctionShellCallOutputTimeoutOutcome(),
            // null or unknown → default to timeout
            _ => new FunctionShellCallOutputTimeoutOutcome(),
        };
    }

    private static MessageStatus ConvertStatus(ItemOutputMessageStatus status)
    {
        return status switch
        {
            ItemOutputMessageStatus.InProgress => MessageStatus.InProgress,
            ItemOutputMessageStatus.Completed => MessageStatus.Completed,
            ItemOutputMessageStatus.Incomplete => MessageStatus.Incomplete,
            _ => MessageStatus.InProgress,
        };
    }

    private static IEnumerable<MessageContent> ConvertOutputMessageContent(
        IList<OutputMessageContent> items)
    {
        foreach (var item in items)
        {
            switch (item)
            {
                case OutputMessageContentOutputTextContent text:
                    yield return new MessageContentOutputTextContent(
                        text.Text, text.Annotations, text.Logprobs);
                    break;
                case OutputMessageContentRefusalContent refusal:
                    yield return new MessageContentRefusalContent(refusal.Refusal);
                    break;
            }
        }
    }
}
