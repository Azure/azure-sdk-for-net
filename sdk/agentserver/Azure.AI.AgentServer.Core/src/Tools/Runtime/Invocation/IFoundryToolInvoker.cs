// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.Invocation;

/// <summary>
/// Provides invocation capability for a resolved tool.
/// </summary>
public interface IFoundryToolInvoker
{
    /// <summary>
    /// Gets the resolved tool definition associated with this invoker.
    /// </summary>
    ResolvedFoundryTool ResolvedTool { get; }

    /// <summary>
    /// Invokes the tool with the given arguments.
    /// </summary>
    /// <param name="arguments">
    /// The arguments to pass to the tool invocation, or null for no arguments.
    /// </param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the tool invocation result.
    /// </returns>
    Task<object?> InvokeAsync(
        IDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default);
}
