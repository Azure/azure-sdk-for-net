// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.Catalog;

/// <summary>
/// Provides access to the catalog of available Foundry tools.
/// Implementations may include caching to optimize repeated tool lookups.
/// </summary>
public interface IFoundryToolCatalog
{
    /// <summary>
    /// Gets a single resolved tool by its definition.
    /// </summary>
    /// <param name="tool">
    /// The tool definition. This can be a FoundryTool instance or a dictionary-based facade
    /// that will be converted to a FoundryTool using <see cref="Facade.FoundryToolFactory"/>.
    /// </param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the resolved tool, or null if the tool could not be resolved.
    /// </returns>
    Task<ResolvedFoundryTool?> GetAsync(
        object tool,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists multiple resolved tools by their definitions.
    /// Implementations should batch requests and use caching for efficiency.
    /// </summary>
    /// <param name="tools">
    /// The collection of tool definitions. Each can be a FoundryTool instance or a dictionary-based facade.
    /// </param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the list of successfully resolved tools.
    /// Tools that could not be resolved are omitted from the result.
    /// </returns>
    Task<IReadOnlyList<ResolvedFoundryTool>> ListAsync(
        IEnumerable<object> tools,
        CancellationToken cancellationToken = default);
}
