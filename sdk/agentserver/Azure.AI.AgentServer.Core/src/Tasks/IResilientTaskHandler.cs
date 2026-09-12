// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Handles one execution attempt of a registered resilient task.
/// </summary>
/// <typeparam name="TInput">The task input type.</typeparam>
/// <typeparam name="TOutput">The task output type.</typeparam>
public interface IResilientTaskHandler<TInput, TOutput>
{
    /// <summary>
    /// Executes one attempt using the current task context.
    /// </summary>
    /// <param name="context">The context for the current task turn.</param>
    /// <param name="cancellationToken">The cooperative cancellation token for this attempt.</param>
    /// <returns>The typed task result.</returns>
    Task<TOutput> RunAsync(
        TaskContext<TInput> context,
        CancellationToken cancellationToken = default);
}
