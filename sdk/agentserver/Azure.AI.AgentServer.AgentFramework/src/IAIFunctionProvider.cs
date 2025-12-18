// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework;

/// <summary>
/// Provides tools (<see cref="AIFunction"/>) to surface to an agent for tool-calling.
/// </summary>
public interface IAIFunctionProvider
{
    /// <summary>
    /// Lists the available tools as Agent Framework <see cref="AIFunction"/> instances.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of tools.</returns>
    Task<IReadOnlyList<AIFunction>> ListToolsAsync(CancellationToken cancellationToken = default);
}
