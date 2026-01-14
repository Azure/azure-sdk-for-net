// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Runtime.Catalog;
using Azure.AI.AgentServer.Core.Tools.Runtime.Invocation;

namespace Azure.AI.AgentServer.Core.Tools.Runtime;

/// <summary>
/// Provides access to Foundry tool catalog and invocation capabilities.
/// This is the main entry point for tool runtime operations.
/// </summary>
public interface IFoundryToolRuntime : IAsyncDisposable
{
    /// <summary>
    /// Gets the tool catalog for listing and resolving tools.
    /// </summary>
    IFoundryToolCatalog Catalog { get; }

    /// <summary>
    /// Gets the tool invocation resolver for invoking tools.
    /// </summary>
    IFoundryToolInvocationResolver Invocation { get; }

    /// <summary>
    /// Convenience method to invoke a tool directly by its definition.
    /// </summary>
    /// <param name="tool">
    /// The tool definition. This can be a FoundryTool instance or a dictionary-based facade
    /// that will be converted to a FoundryTool using <see cref="Facade.FoundryToolFactory"/>.
    /// </param>
    /// <param name="arguments">The arguments to pass to the tool invocation, or null for no arguments.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the tool invocation result.
    /// </returns>
    Task<object?> InvokeAsync(
        object tool,
        IDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default);
}
