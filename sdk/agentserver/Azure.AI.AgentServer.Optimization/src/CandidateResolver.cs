// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Resolves candidate configs from the optimization service API.
/// </summary>
internal static class CandidateResolver
{
    private const string ApiVersion = "2025-11-15-preview";
    private const string AuthScope = "https://ai.azure.com/.default";

    /// <summary>
    /// Resolves a candidate's full config from the optimization service.
    /// </summary>
    public static async Task<JsonElement?> ResolveAsync(
        string jobId,
        string candidateId,
        string endpoint,
        AuthenticationTokenProvider tokenProvider,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(jobId))
        {
            throw new ArgumentException("Job ID is required for the resolver API. Set the OPTIMIZATION_JOB_ID environment variable.", nameof(jobId));
        }
        CandidateIdValidator.ThrowIfInvalid(candidateId, nameof(candidateId));

        var pipeline = BuildPipeline(tokenProvider);
        return await FetchCandidateConfigAsync(pipeline, endpoint, jobId, candidateId, cancellationToken).ConfigureAwait(false);
    }

    private static async Task<JsonElement> FetchCandidateConfigAsync(
        ClientPipeline pipeline,
        string endpoint,
        string jobId,
        string candidateId,
        CancellationToken cancellationToken)
    {
        using var message = pipeline.CreateMessage(BuildCandidateConfigUri(endpoint, jobId, candidateId), "GET");
        message.Apply(CreateRequestOptions(cancellationToken));

        await pipeline.SendAsync(message).ConfigureAwait(false);

        PipelineResponse response = message.Response ?? throw new InvalidOperationException("Resolver pipeline returned no response.");
        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        using var doc = JsonDocument.Parse(response.Content);
        return doc.RootElement.Clone();
    }

    private static RequestOptions CreateRequestOptions(CancellationToken cancellationToken) =>
        new()
        {
            CancellationToken = cancellationToken,
        };

    private static Uri BuildCandidateConfigUri(string endpoint, string jobId, string candidateId)
    {
        var builder = new UriBuilder(endpoint);
        string path = builder.Path ?? string.Empty;

        if (!path.EndsWith("/", StringComparison.Ordinal))
        {
            path += "/";
        }

        builder.Path = $"{path}agent_optimization_jobs/{Uri.EscapeDataString(jobId)}/candidates/{Uri.EscapeDataString(candidateId)}/config";
        builder.Query = $"api-version={Uri.EscapeDataString(ApiVersion)}";
        return builder.Uri;
    }

    private static ClientPipeline BuildPipeline(AuthenticationTokenProvider tokenProvider)
    {
        if (tokenProvider == null)
        {
            throw new InvalidOperationException(
                "A token provider must be provided when using the resolver API.");
        }

        return ClientPipeline.Create(
            new ClientPipelineOptions(),
            Array.Empty<PipelinePolicy>(),
            new PipelinePolicy[] { new BearerTokenPolicy(tokenProvider, AuthScope) },
            Array.Empty<PipelinePolicy>());
    }
}
