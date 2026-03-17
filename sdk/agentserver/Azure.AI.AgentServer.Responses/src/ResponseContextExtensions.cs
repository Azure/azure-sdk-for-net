namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Extension methods for <see cref="IResponseContext"/> that generate
/// correctly formatted item IDs with automatic partition key propagation
/// from the current response.
/// </summary>
public static class ResponseContextExtensions
{
    /// <summary>Generates a new output message item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A message item ID in the format <c>msg_{partitionKey}{entropy}</c>.</returns>
    public static string NewMessageItemId(this IResponseContext context)
        => IdGenerator.NewMessageItemId(context.ResponseId);

    /// <summary>Generates a new function tool call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A function call item ID in the format <c>fc_{partitionKey}{entropy}</c>.</returns>
    public static string NewFunctionCallItemId(this IResponseContext context)
        => IdGenerator.NewFunctionCallItemId(context.ResponseId);

    /// <summary>Generates a new reasoning item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A reasoning item ID in the format <c>rs_{partitionKey}{entropy}</c>.</returns>
    public static string NewReasoningItemId(this IResponseContext context)
        => IdGenerator.NewReasoningItemId(context.ResponseId);

    /// <summary>Generates a new file search call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A file search call item ID in the format <c>fs_{partitionKey}{entropy}</c>.</returns>
    public static string NewFileSearchCallItemId(this IResponseContext context)
        => IdGenerator.NewFileSearchCallItemId(context.ResponseId);

    /// <summary>Generates a new web search call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A web search call item ID in the format <c>ws_{partitionKey}{entropy}</c>.</returns>
    public static string NewWebSearchCallItemId(this IResponseContext context)
        => IdGenerator.NewWebSearchCallItemId(context.ResponseId);

    /// <summary>Generates a new code interpreter call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A code interpreter call item ID in the format <c>ci_{partitionKey}{entropy}</c>.</returns>
    public static string NewCodeInterpreterCallItemId(this IResponseContext context)
        => IdGenerator.NewCodeInterpreterCallItemId(context.ResponseId);

    /// <summary>Generates a new image generation call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An image generation call item ID in the format <c>ig_{partitionKey}{entropy}</c>.</returns>
    public static string NewImageGenCallItemId(this IResponseContext context)
        => IdGenerator.NewImageGenCallItemId(context.ResponseId);

    /// <summary>Generates a new MCP tool call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An MCP tool call item ID in the format <c>mcp_{partitionKey}{entropy}</c>.</returns>
    public static string NewMcpCallItemId(this IResponseContext context)
        => IdGenerator.NewMcpCallItemId(context.ResponseId);

    /// <summary>Generates a new MCP list tools item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>An MCP list tools item ID in the format <c>mcpl_{partitionKey}{entropy}</c>.</returns>
    public static string NewMcpListToolsItemId(this IResponseContext context)
        => IdGenerator.NewMcpListToolsItemId(context.ResponseId);

    /// <summary>Generates a new custom tool call item ID sharing the response's partition key.</summary>
    /// <param name="context">The response context.</param>
    /// <returns>A custom tool call item ID in the format <c>ctc_{partitionKey}{entropy}</c>.</returns>
    public static string NewCustomToolCallItemId(this IResponseContext context)
        => IdGenerator.NewCustomToolCallItemId(context.ResponseId);
}
