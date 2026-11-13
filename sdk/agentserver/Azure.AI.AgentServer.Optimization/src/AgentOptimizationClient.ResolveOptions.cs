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
    /// can inspect HTTP status and headers. When falling back to the env var, the
    /// response from the failed API call is preserved when available.
    /// Returns <c>null</c> when no source matches.
    /// </summary>
    /// <param name="candidateId">The candidate identifier to resolve config for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved config wrapped in a <see cref="Response{T}"/>, or <c>null</c> when no source matched.</returns>
    public virtual async Task<Response<CandidateDeployConfig>> ResolveOptionsAsync(
        string candidateId,
        CancellationToken cancellationToken = default)
    {
        Response failedResponse = null;

        if (!string.IsNullOrEmpty(candidateId) && _endpoint != null && Pipeline != null)
        {
            try
            {
                return await GetCandidateConfigFlatAsync(candidateId, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                failedResponse = ex.GetRawResponse();
            }
        }

        return TryResolveFromEnvVar(failedResponse);
    }

    /// <summary>
    /// Synchronous version of <see cref="ResolveOptionsAsync"/>.
    /// </summary>
    /// <param name="candidateId">The candidate identifier to resolve config for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved config wrapped in a <see cref="Response{T}"/>, or <c>null</c> when no source matched.</returns>
    public virtual Response<CandidateDeployConfig> ResolveOptions(string candidateId, CancellationToken cancellationToken = default)
    {
        Response failedResponse = null;

        if (!string.IsNullOrEmpty(candidateId) && _endpoint != null && Pipeline != null)
        {
            try
            {
                return GetCandidateConfigFlat(candidateId, cancellationToken: cancellationToken);
            }
            catch (RequestFailedException ex)
            {
                failedResponse = ex.GetRawResponse();
            }
        }

        return TryResolveFromEnvVar(failedResponse);
    }

    private static Response<CandidateDeployConfig> TryResolveFromEnvVar(Response response = null)
    {
        string rawConfig = Environment.GetEnvironmentVariable("OPTIMIZATION_CONFIG")?.Trim();
        if (!string.IsNullOrEmpty(rawConfig))
        {
            var config = ModelReaderWriter.Read<CandidateDeployConfig>(
                BinaryData.FromString(rawConfig),
                ModelReaderWriterOptions.Json,
                AzureAIAgentServerOptimizationContext.Default);
            return Response.FromValue(config, response);
        }

        return null;
    }
}
