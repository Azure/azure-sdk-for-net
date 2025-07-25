// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// A polling strategy that returns immediately without any delay.
/// This is used for testing, particularly in playback mode, to accelerate long-running operation tests.
/// </summary>
internal sealed class ZeroPollingStrategy : IPollingStrategy
{
    /// <summary>
    /// Gets the singleton instance of the zero polling strategy.
    /// </summary>
    public static readonly ZeroPollingStrategy Instance = new();

    private ZeroPollingStrategy() { }

    /// <summary>
    /// Returns immediately without any delay.
    /// </summary>
    /// <param name="response">The response from the last status check.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A completed task.</returns>
    public Task WaitAsync(PipelineResponse response, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.CompletedTask;
    }

    /// <summary>
    /// Returns immediately without any delay.
    /// </summary>
    /// <param name="response">The response from the last status check.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public void Wait(PipelineResponse response, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
    }
}
