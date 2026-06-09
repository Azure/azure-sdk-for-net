// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.Text.Json;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Resolves candidate configs from the optimization service API.
/// </summary>
internal static class CandidateResolver
{
    private const string ApiVersion = "2025-11-15-preview";
    private const string AuthScope = "https://ai.azure.com/.default";

    private static readonly ConcurrentDictionary<string, byte> s_downloaded = new();

    /// <summary>
    /// Resolves a candidate's full config from the optimization service.
    /// </summary>
    public static async Task<JsonElement?> ResolveAsync(
        string candidateId,
        string endpoint,
        string localDir,
        AuthenticationTokenProvider credential,
        CancellationToken cancellationToken = default)
    {
        ValidateCandidateId(candidateId);

        string cacheKey = string.Concat(endpoint.TrimEnd('/'), "|", localDir ?? "", "|", candidateId);

        if (s_downloaded.ContainsKey(cacheKey))
        {
            if (localDir != null && Directory.Exists(Path.Combine(localDir, candidateId)))
            {
                return null;
            }

            s_downloaded.TryRemove(cacheKey, out _);
        }

        var pipeline = BuildPipeline(credential);

        var config = await FetchCandidateConfigAsync(pipeline, endpoint, candidateId, cancellationToken).ConfigureAwait(false);

        if (localDir != null)
        {
            string candidatePath = Path.Combine(localDir, candidateId);
            try
            {
                PersistToLocalLayout(candidatePath, config);
            }
            catch (IOException)
            {
                // Persist failure is non-fatal
            }
        }

        s_downloaded.TryAdd(cacheKey, 0);
        return config;
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

    private static void PersistToLocalLayout(string candidatePath, JsonElement config)
    {
        if (Directory.Exists(candidatePath))
        {
            Directory.Delete(candidatePath, recursive: true);
        }

        Directory.CreateDirectory(candidatePath);

        // metadata.yaml
        var metaLines = new List<string>();
        if (config.TryGetProperty("model", out var modelProp) && modelProp.ValueKind == JsonValueKind.String)
        {
            metaLines.Add($"model: {modelProp.GetString()}");
        }

        if (config.TryGetProperty("temperature", out var tempProp) && tempProp.ValueKind == JsonValueKind.Number)
        {
            metaLines.Add($"temperature: {tempProp.GetDouble()}");
        }

        metaLines.Add($"instruction_file: {OptimizationConfig.InstructionsFile}");
        metaLines.Add($"tool_file: {OptimizationConfig.ToolsFile}");
        File.WriteAllText(Path.Combine(candidatePath, OptimizationConfig.MetadataFile), string.Join("\n", metaLines) + "\n");

        // instructions.md
        if (config.TryGetProperty("instructions", out var instrProp) && instrProp.ValueKind == JsonValueKind.String)
        {
            string instructions = instrProp.GetString() ?? "";
            if (!string.IsNullOrEmpty(instructions))
            {
                File.WriteAllText(Path.Combine(candidatePath, OptimizationConfig.InstructionsFile), instructions);
            }
        }

        // tools.json
        if (config.TryGetProperty("tools", out var toolsProp) && toolsProp.ValueKind == JsonValueKind.Array)
        {
            string toolsJson = JsonSerializer.Serialize(toolsProp, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Path.Combine(candidatePath, OptimizationConfig.ToolsFile), toolsJson);
        }
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
                "An AuthenticationTokenProvider must be provided via ConfigLoaderOptions.Credential when using the resolver API. " +
                "Pass a DefaultAzureCredential or another AuthenticationTokenProvider implementation.");
        }

        return ClientPipeline.Create(
            new OptimizationClientOptions(),
            Array.Empty<PipelinePolicy>(),
            new PipelinePolicy[] { new BearerTokenPolicy(credential, AuthScope) },
            Array.Empty<PipelinePolicy>());
    }

    private sealed class OptimizationClientOptions : ClientPipelineOptions
    {
    }
}
