// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using System.ClientModel.Primitives;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Extends <see cref="AgentOptimizationClient"/> with a public config resolution
/// method that wraps the internal <c>GetCandidateConfigFlat</c> call with
/// <c>OPTIMIZATION_CONFIG</c> env-var fallback.
/// </summary>
public partial class AgentOptimizationClient
{
    /// <summary>
    /// Resolves a <see cref="CandidateDeployConfig"/> using a priority waterfall:
    /// <list type="number">
    /// <item><description><b>API</b> — calls <c>GetCandidateConfigFlat</c> using
    /// the client's configured endpoint and credential pipeline.</description></item>
    /// <item><description><b>Env var</b> — reads <c>OPTIMIZATION_CONFIG</c> as
    /// inline JSON and deserializes it.</description></item>
    /// </list>
    /// Returns a <see cref="Response{T}"/> wrapping the resolved config so callers
    /// can inspect HTTP status and headers. When falling back to the env var, a
    /// synthetic response with no HTTP context is returned.
    /// Returns <c>null</c> when no source matches.
    /// </summary>
    /// <param name="candidateId">The candidate identifier to resolve config for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved config wrapped in a <see cref="Response{T}"/>, or <c>null</c> when no source matched.</returns>
#pragma warning disable AZC0015 // Convenience method — may skip the network when falling back to env vars
#pragma warning disable AZC0004 // Sync counterpart is ResolveOptions below
    public virtual async Task<Response<CandidateDeployConfig>> ResolveOptionsAsync(
        string candidateId,
        CancellationToken cancellationToken = default)
    {
        // Priority 1: Try the API using this client's pipeline
        if (!string.IsNullOrEmpty(candidateId) && _endpoint != null && Pipeline != null)
        {
            try
            {
                Response<CandidateDeployConfig> response = await GetCandidateConfigFlatAsync(
                    candidateId,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (RequestFailedException)
            {
                // API call failed — fall through to env var
            }
        }

        // Priority 2: OPTIMIZATION_CONFIG env var (inline JSON)
        string rawConfig = Environment.GetEnvironmentVariable("OPTIMIZATION_CONFIG")?.Trim();
        if (!string.IsNullOrEmpty(rawConfig))
        {
            var config = ModelReaderWriter.Read<CandidateDeployConfig>(
                BinaryData.FromString(rawConfig),
                ModelReaderWriterOptions.Json,
                AzureAIAgentServerOptimizationContext.Default);
            return Response.FromValue(config, response: null);
        }

        return null;
    }
#pragma warning restore AZC0004
#pragma warning restore AZC0015

    /// <summary>
    /// Synchronous version of <see cref="ResolveOptionsAsync"/>.
    /// </summary>
    /// <param name="candidateId">The candidate identifier to resolve config for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved config wrapped in a <see cref="Response{T}"/>, or <c>null</c> when no source matched.</returns>
#pragma warning disable AZC0015
#pragma warning disable AZC0004
    public virtual Response<CandidateDeployConfig> ResolveOptions(string candidateId, CancellationToken cancellationToken = default)
    {
#pragma warning disable AZC0102
        return ResolveOptionsAsync(candidateId, cancellationToken).GetAwaiter().GetResult();
#pragma warning restore AZC0102
    }
#pragma warning restore AZC0004
#pragma warning restore AZC0015
}
