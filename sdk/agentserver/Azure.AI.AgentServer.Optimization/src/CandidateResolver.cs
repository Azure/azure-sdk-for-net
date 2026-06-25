// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Resolves candidate configs from the optimization service API using the
/// generated <see cref="AgentOptimizationClient"/> client.
/// </summary>
internal static class CandidateResolver
{
    /// <summary>
    /// Resolves a candidate's deploy config from the optimization service
    /// using the flat route: <c>optimize/candidates/{candidateId}/config</c>.
    /// </summary>
    public static async Task<CandidateDeployConfig> ResolveAsync(
        string candidateId,
        string endpoint,
        TokenCredential credential,
        CancellationToken cancellationToken = default)
    {
        CandidateIdValidator.ThrowIfInvalid(candidateId, nameof(candidateId));

        if (credential == null)
        {
            throw new InvalidOperationException(
                "A credential must be provided when using the resolver API.");
        }

        var client = new AgentOptimizationClient(new Uri(endpoint), credential);

        Response<CandidateDeployConfig> response = await client.GetCandidateConfigFlatAsync(
            candidateId,
            cancellationToken: cancellationToken).ConfigureAwait(false);

        return response.Value;
    }
}
