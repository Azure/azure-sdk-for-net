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
        AuthenticationTokenProvider credential,
        CancellationToken cancellationToken = default)
    {
        ValidateCandidateId(candidateId);

        var pipeline = BuildPipeline(credential);
        return await FetchCandidateConfigAsync(pipeline, endpoint, candidateId, cancellationToken).ConfigureAwait(false);
    }

    private static async Task<JsonElement> FetchCandidateConfigAsync(
        ClientPipeline pipeline,
        string endpoint,
        string candidateId,
        CancellationToken cancellationToken)
    {
        string escapedCandidateId = Uri.EscapeDataString(candidateId);
        string url = $"{endpoint.TrimEnd('/')}/candidates/{escapedCandidateId}/config?api-version={ApiVersion}";

        using var message = pipeline.CreateMessage(new Uri(url), "GET");
        message.Apply(CreateRequestOptions(cancellationToken));

        await pipeline.SendAsync(message).ConfigureAwait(false);

        if (message.Response?.IsError != false)
        {
            throw new ClientResultException(message.Response);
        }

        using var doc = JsonDocument.Parse(message.Response.Content);
        return doc.RootElement.Clone();
    }

    private static void ValidateCandidateId(string candidateId)
    {
        if (string.IsNullOrEmpty(candidateId))
        {
            throw new ArgumentNullException(nameof(candidateId));
        }

        if (candidateId.Contains("..", StringComparison.Ordinal) ||
            candidateId.IndexOf(Path.DirectorySeparatorChar) >= 0 ||
            candidateId.IndexOf(Path.AltDirectorySeparatorChar) >= 0)
        {
            throw new ArgumentException("Candidate ID must not contain path separators or '..'.", nameof(candidateId));
        }
    }

    private static RequestOptions CreateRequestOptions(CancellationToken cancellationToken) =>
        new()
        {
            CancellationToken = cancellationToken,
        };

    private static ClientPipeline BuildPipeline(AuthenticationTokenProvider credential)
    {
        if (credential == null)
        {
            throw new InvalidOperationException(
                "An AuthenticationTokenProvider credential must be provided when using the resolver API.");
        }

        return ClientPipeline.Create(
            new ClientPipelineOptions(),
            Array.Empty<PipelinePolicy>(),
            new PipelinePolicy[] { new BearerTokenPolicy(credential, AuthScope) },
            Array.Empty<PipelinePolicy>());
    }
}
