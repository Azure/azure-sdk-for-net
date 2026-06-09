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
        string candidateId,
        string endpoint,
        AuthenticationTokenProvider? tokenProvider,
        CancellationToken cancellationToken = default)
    {
        ValidateCandidateId(candidateId);

        var pipeline = BuildPipeline(tokenProvider);
        return await FetchCandidateConfigAsync(pipeline, endpoint, candidateId, cancellationToken).ConfigureAwait(false);
    }

    private static async Task<JsonElement> FetchCandidateConfigAsync(
        ClientPipeline pipeline,
        string endpoint,
        string candidateId,
        CancellationToken cancellationToken)
    {
        using var message = pipeline.CreateMessage(BuildCandidateConfigUri(endpoint, candidateId), "GET");
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

    private static void ValidateCandidateId(string candidateId)
    {
        if (string.IsNullOrEmpty(candidateId))
        {
            throw new ArgumentNullException(nameof(candidateId));
        }

        ReadOnlySpan<char> candidateIdSpan = candidateId.AsSpan();

        if (ContainsParentTraversal(candidateIdSpan) ||
            candidateIdSpan.IndexOf(Path.DirectorySeparatorChar) >= 0 ||
            candidateIdSpan.IndexOf(Path.AltDirectorySeparatorChar) >= 0)
        {
            throw new ArgumentException("Candidate ID must not contain path separators or '..'.", nameof(candidateId));
        }
    }

    private static bool ContainsParentTraversal(ReadOnlySpan<char> value)
    {
        for (int i = 1; i < value.Length; i++)
        {
            if (value[i - 1] == '.' && value[i] == '.')
            {
                return true;
            }
        }

        return false;
    }

    private static RequestOptions CreateRequestOptions(CancellationToken cancellationToken) =>
        new()
        {
            CancellationToken = cancellationToken,
        };

    private static Uri BuildCandidateConfigUri(string endpoint, string candidateId)
    {
        var builder = new UriBuilder(endpoint);
        string path = builder.Path ?? string.Empty;

        if (!path.EndsWith("/", StringComparison.Ordinal))
        {
            path += "/";
        }

        builder.Path = $"{path}candidates/{Uri.EscapeDataString(candidateId)}/config";
        builder.Query = $"api-version={Uri.EscapeDataString(ApiVersion)}";
        return builder.Uri;
    }

    private static ClientPipeline BuildPipeline(AuthenticationTokenProvider? tokenProvider)
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
