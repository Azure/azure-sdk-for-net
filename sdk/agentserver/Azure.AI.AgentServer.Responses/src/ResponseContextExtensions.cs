// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Extension methods for <see cref="ResponseContext"/> that generate
/// correctly formatted item IDs with automatic partition key propagation
/// from the current response.
/// </summary>
public static class ResponseContextExtensions
{
    /// <summary>Generates a new output message item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A message item ID in the format <c>msg_{partitionKey}{entropy}</c>.</returns>
    public static string NewMessageItemId(this ResponseContext context)
        => IdGenerator.NewMessageItemId(context.ResponseId);

    /// <summary>Generates a new output message item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An output message item ID in the format <c>om_{partitionKey}{entropy}</c>.</returns>
    public static string NewOutputMessageItemId(this ResponseContext context)
        => IdGenerator.NewOutputMessageItemId(context.ResponseId);

    /// <summary>Generates a new function tool call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A function call item ID in the format <c>fc_{partitionKey}{entropy}</c>.</returns>
    public static string NewFunctionCallItemId(this ResponseContext context)
        => IdGenerator.NewFunctionCallItemId(context.ResponseId);

    /// <summary>Generates a new function call output item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A function call output item ID in the format <c>fco_{partitionKey}{entropy}</c>.</returns>
    public static string NewFunctionCallOutputItemId(this ResponseContext context)
        => IdGenerator.NewFunctionCallOutputItemId(context.ResponseId);

    /// <summary>Generates a new reasoning item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A reasoning item ID in the format <c>rs_{partitionKey}{entropy}</c>.</returns>
    public static string NewReasoningItemId(this ResponseContext context)
        => IdGenerator.NewReasoningItemId(context.ResponseId);

    /// <summary>Generates a new file search call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A file search call item ID in the format <c>fs_{partitionKey}{entropy}</c>.</returns>
    public static string NewFileSearchCallItemId(this ResponseContext context)
        => IdGenerator.NewFileSearchCallItemId(context.ResponseId);

    /// <summary>Generates a new web search call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A web search call item ID in the format <c>ws_{partitionKey}{entropy}</c>.</returns>
    public static string NewWebSearchCallItemId(this ResponseContext context)
        => IdGenerator.NewWebSearchCallItemId(context.ResponseId);

    /// <summary>Generates a new code interpreter call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A code interpreter call item ID in the format <c>ci_{partitionKey}{entropy}</c>.</returns>
    public static string NewCodeInterpreterCallItemId(this ResponseContext context)
        => IdGenerator.NewCodeInterpreterCallItemId(context.ResponseId);

    /// <summary>Generates a new image generation call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An image generation call item ID in the format <c>ig_{partitionKey}{entropy}</c>.</returns>
    public static string NewImageGenCallItemId(this ResponseContext context)
        => IdGenerator.NewImageGenCallItemId(context.ResponseId);

    /// <summary>Generates a new MCP tool call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An MCP tool call item ID in the format <c>mcp_{partitionKey}{entropy}</c>.</returns>
    public static string NewMcpCallItemId(this ResponseContext context)
        => IdGenerator.NewMcpCallItemId(context.ResponseId);

    /// <summary>Generates a new MCP list tools item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An MCP list tools item ID in the format <c>mcpl_{partitionKey}{entropy}</c>.</returns>
    public static string NewMcpListToolsItemId(this ResponseContext context)
        => IdGenerator.NewMcpListToolsItemId(context.ResponseId);

    /// <summary>Generates a new custom tool call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A custom tool call item ID in the format <c>ctc_{partitionKey}{entropy}</c>.</returns>
    public static string NewCustomToolCallItemId(this ResponseContext context)
        => IdGenerator.NewCustomToolCallItemId(context.ResponseId);

    /// <summary>Generates a new custom tool call output item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A custom tool call output item ID in the format <c>ctco_{partitionKey}{entropy}</c>.</returns>
    public static string NewCustomToolCallOutputItemId(this ResponseContext context)
        => IdGenerator.NewCustomToolCallOutputItemId(context.ResponseId);

    /// <summary>Generates a new computer call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A computer call item ID in the format <c>cu_{partitionKey}{entropy}</c>.</returns>
    public static string NewComputerCallItemId(this ResponseContext context)
        => IdGenerator.NewComputerCallItemId(context.ResponseId);

    /// <summary>Generates a new computer call output item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A computer call output item ID in the format <c>cuo_{partitionKey}{entropy}</c>.</returns>
    public static string NewComputerCallOutputItemId(this ResponseContext context)
        => IdGenerator.NewComputerCallOutputItemId(context.ResponseId);

    /// <summary>Generates a new local shell call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A local shell call item ID in the format <c>lsh_{partitionKey}{entropy}</c>.</returns>
    public static string NewLocalShellCallItemId(this ResponseContext context)
        => IdGenerator.NewLocalShellCallItemId(context.ResponseId);

    /// <summary>Generates a new local shell call output item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A local shell call output item ID in the format <c>lsho_{partitionKey}{entropy}</c>.</returns>
    public static string NewLocalShellCallOutputItemId(this ResponseContext context)
        => IdGenerator.NewLocalShellCallOutputItemId(context.ResponseId);

    /// <summary>Generates a new function shell call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A function shell call item ID in the format <c>lsh_{partitionKey}{entropy}</c>.</returns>
    public static string NewFunctionShellCallItemId(this ResponseContext context)
        => IdGenerator.NewFunctionShellCallItemId(context.ResponseId);

    /// <summary>Generates a new function shell call output item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A function shell call output item ID in the format <c>lsho_{partitionKey}{entropy}</c>.</returns>
    public static string NewFunctionShellCallOutputItemId(this ResponseContext context)
        => IdGenerator.NewFunctionShellCallOutputItemId(context.ResponseId);

    /// <summary>Generates a new apply-patch call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An apply-patch call item ID in the format <c>ap_{partitionKey}{entropy}</c>.</returns>
    public static string NewApplyPatchCallItemId(this ResponseContext context)
        => IdGenerator.NewApplyPatchCallItemId(context.ResponseId);

    /// <summary>Generates a new apply-patch call output item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An apply-patch call output item ID in the format <c>apo_{partitionKey}{entropy}</c>.</returns>
    public static string NewApplyPatchCallOutputItemId(this ResponseContext context)
        => IdGenerator.NewApplyPatchCallOutputItemId(context.ResponseId);

    /// <summary>Generates a new MCP approval request item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An MCP approval request item ID in the format <c>mcpr_{partitionKey}{entropy}</c>.</returns>
    public static string NewMcpApprovalRequestItemId(this ResponseContext context)
        => IdGenerator.NewMcpApprovalRequestItemId(context.ResponseId);

    /// <summary>Generates a new MCP approval response item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An MCP approval response item ID in the format <c>mcpa_{partitionKey}{entropy}</c>.</returns>
    public static string NewMcpApprovalResponseItemId(this ResponseContext context)
        => IdGenerator.NewMcpApprovalResponseItemId(context.ResponseId);

    /// <summary>Generates a new compaction item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A compaction item ID in the format <c>cmp_{partitionKey}{entropy}</c>.</returns>
    public static string NewCompactionItemId(this ResponseContext context)
        => IdGenerator.NewCompactionItemId(context.ResponseId);

    /// <summary>Generates a new workflow action item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A workflow action item ID in the format <c>wfa_{partitionKey}{entropy}</c>.</returns>
    public static string NewWorkflowActionItemId(this ResponseContext context)
        => IdGenerator.NewWorkflowActionItemId(context.ResponseId);

    /// <summary>Generates a new structured output item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A structured output item ID generated for the current response.</returns>
    public static string NewStructuredOutputItemId(this ResponseContext context)
        => IdGenerator.NewStructuredOutputItemId(context.ResponseId);

    /// <summary>Generates a new generic item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A generic item ID in the format <c>item_{partitionKey}{entropy}</c>.</returns>
    public static string NewItemId(this ResponseContext context)
        => IdGenerator.NewGenericItemId(context.ResponseId);
}
