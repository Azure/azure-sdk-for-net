// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Represents a tool that can be invoked.
/// </summary>
public record ResolvedFoundryTool
{
    /// <summary>
    /// Gets or initializes the display name of the tool.
    /// </summary>
    required public string Name { get; init; }

    /// <summary>
    /// Gets or initializes the description of the tool.
    /// </summary>
    required public string Description { get; init; }

    /// <summary>
    /// Gets or initializes the source of the tool.
    /// </summary>
    required public FoundryToolSource Source { get; init; }

    /// <summary>
    /// Gets or initializes the raw metadata from the tool API.
    /// </summary>
    required public IReadOnlyDictionary<string, object?> Metadata { get; init; }

    /// <summary>
    /// Gets or initializes the JSON schema describing the tool's input parameters.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? InputSchema { get; init; }

    /// <summary>
    /// Gets or initializes the tool definition configuration.
    /// </summary>
    public FoundryTool? FoundryTool { get; init; }

    /// <summary>
    /// Gets or sets the synchronous invoker function for this tool.
    /// </summary>
    public Func<IDictionary<string, object?>, object?>? Invoker { get; set; }

    /// <summary>
    /// Gets or sets the asynchronous invoker function for this tool.
    /// </summary>
    public Func<IDictionary<string, object?>, Task<object?>>? AsyncInvoker { get; set; }

    /// <summary>
    /// Invokes the tool synchronously.
    /// </summary>
    /// <param name="arguments">The arguments to pass to the tool.</param>
    /// <returns>The result of the tool invocation.</returns>
    /// <exception cref="NotSupportedException">Thrown when no synchronous invoker is configured.</exception>
    public object? Invoke(IDictionary<string, object?>? arguments = null)
    {
        if (Invoker == null)
        {
            throw new NotSupportedException("No synchronous invoker configured for this tool.");
        }

        return Invoker(arguments ?? new Dictionary<string, object?>());
    }

    /// <summary>
    /// Invokes the tool asynchronously.
    /// </summary>
    /// <param name="arguments">The arguments to pass to the tool.</param>
    /// <returns>A task that represents the asynchronous operation and contains the tool invocation result.</returns>
    /// <exception cref="NotSupportedException">Thrown when no asynchronous invoker is configured.</exception>
    public async Task<object?> InvokeAsync(IDictionary<string, object?>? arguments = null)
    {
        if (AsyncInvoker == null)
        {
            throw new NotSupportedException("No asynchronous invoker configured for this tool.");
        }

        return await AsyncInvoker(arguments ?? new Dictionary<string, object?>()).ConfigureAwait(false);
    }
}
