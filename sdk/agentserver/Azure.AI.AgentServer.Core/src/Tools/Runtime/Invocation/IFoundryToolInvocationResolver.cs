// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Runtime.Invocation;

/// <summary>
/// Resolves tool definitions to invokers that can execute the tools.
/// </summary>
public interface IFoundryToolInvocationResolver
{
    /// <summary>
    /// Resolves a tool definition to an invoker capable of executing it.
    /// </summary>
    /// <param name="tool">
    /// The tool definition. This can be a FoundryTool instance or a dictionary-based facade
    /// that will be converted to a FoundryTool using <see cref="Facade.FoundryToolFactory"/>.
    /// </param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the tool invoker.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the tool cannot be resolved to an invoker.
    /// </exception>
    Task<IFoundryToolInvoker> ResolveAsync(
        object tool,
        CancellationToken cancellationToken = default);
}
