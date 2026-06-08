// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Azure.Core.Pipeline;
using YamlDotNet.Serialization;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Resolves candidate configs from the optimization service API.
/// </summary>
internal static class CandidateResolver
{
    private const string ApiVersion = "2025-11-15-preview";
    private const string AuthScope = "https://ai.azure.com/.default";

    private static readonly object s_lock = new();
    private static readonly HashSet<string> s_downloaded = new();

    /// <summary>
    /// Resolves a candidate's full config from the optimization service.
    /// </summary>
    public static async Task<JsonElement?> ResolveAsync(
        string candidateId,
        string endpoint,
        string? localDir,
        TokenCredential? credential,
        CancellationToken cancellationToken = default)
    {
        lock (s_lock)
        {
            if (s_downloaded.Contains(candidateId))
            {
                if (localDir is not null && Directory.Exists(Path.Combine(localDir, candidateId)))
                    return null;
                s_downloaded.Remove(candidateId);
            }
        }

        var pipeline = BuildPipeline(endpoint, credential);

        var config = await FetchCandidateConfigAsync(pipeline, endpoint, candidateId, cancellationToken).ConfigureAwait(false);

        if (localDir is not null)
        {
            string candidatePath = Path.Combine(localDir, candidateId);
            try
            {
                PersistToLocalLayout(candidatePath, config);
                await DownloadSkillFilesAsync(pipeline, endpoint, candidateId, candidatePath, cancellationToken).ConfigureAwait(false);
            }
            catch (IOException)
            {
                // Persist failure is non-fatal
            }
        }

        lock (s_lock)
        {
            s_downloaded.Add(candidateId);
        }
        return config;
    }

    private static async Task<JsonElement> FetchCandidateConfigAsync(
        HttpPipeline pipeline,
        string endpoint,
        string candidateId,
        CancellationToken cancellationToken)
    {
        string url = $"{endpoint.TrimEnd('/')}/candidates/{candidateId}/config?api-version={ApiVersion}";
        var request = new RequestUriBuilder();
        request.Reset(new Uri(url));

        using var message = pipeline.CreateMessage();
        message.Request.Uri = request;
        message.Request.Method = RequestMethod.Get;

        await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);

        if (message.Response.Status < 200 || message.Response.Status >= 300)
        {
            throw new RequestFailedException(message.Response);
        }

        using var doc = JsonDocument.Parse(message.Response.Content);
        return doc.RootElement.Clone();
    }

    private static void PersistToLocalLayout(string candidatePath, JsonElement config)
    {
        if (Directory.Exists(candidatePath))
            Directory.Delete(candidatePath, recursive: true);

        Directory.CreateDirectory(candidatePath);

        // metadata.yaml
        var metaLines = new List<string>();
        if (config.TryGetProperty("model", out var modelProp) && modelProp.ValueKind == JsonValueKind.String)
            metaLines.Add($"model: {modelProp.GetString()}");
        if (config.TryGetProperty("temperature", out var tempProp) && tempProp.ValueKind == JsonValueKind.Number)
            metaLines.Add($"temperature: {tempProp.GetDouble()}");
        metaLines.Add($"instruction_file: {OptimizationConfig.InstructionsFile}");
        metaLines.Add($"skill_dir: {OptimizationConfig.SkillsDir}");
        metaLines.Add($"tool_file: {OptimizationConfig.ToolsFile}");
        File.WriteAllText(Path.Combine(candidatePath, OptimizationConfig.MetadataFile), string.Join("\n", metaLines) + "\n");

        // instructions.md
        if (config.TryGetProperty("instructions", out var instrProp) && instrProp.ValueKind == JsonValueKind.String)
        {
            string instructions = instrProp.GetString() ?? "";
            if (!string.IsNullOrEmpty(instructions))
                File.WriteAllText(Path.Combine(candidatePath, OptimizationConfig.InstructionsFile), instructions);
        }

        // tools.json
        if (config.TryGetProperty("tools", out var toolsProp) && toolsProp.ValueKind == JsonValueKind.Array)
        {
            string toolsJson = JsonSerializer.Serialize(toolsProp, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Path.Combine(candidatePath, OptimizationConfig.ToolsFile), toolsJson);
        }

        // skills/
        if (config.TryGetProperty("skills", out var skillsProp) && skillsProp.ValueKind == JsonValueKind.Array)
        {
            string skillsDirPath = Path.Combine(candidatePath, OptimizationConfig.SkillsDir);
            foreach (var skill in skillsProp.EnumerateArray())
            {
                if (skill.ValueKind != JsonValueKind.Object)
                    continue;
                if (!skill.TryGetProperty("name", out var nameProp) || nameProp.ValueKind != JsonValueKind.String)
                    continue;

                string skillName = nameProp.GetString()!;
                if (string.IsNullOrEmpty(skillName))
                    continue;

                string skillFolder = Path.Combine(skillsDirPath, skillName);
                Directory.CreateDirectory(skillFolder);

                var fmDict = new Dictionary<string, string> { ["name"] = skillName };
                if (skill.TryGetProperty("description", out var descProp) && descProp.ValueKind == JsonValueKind.String)
                    fmDict["description"] = descProp.GetString()!;

                var serializer = new SerializerBuilder().Build();
                string fmText = serializer.Serialize(fmDict).TrimEnd('\n', '\r');
                var parts = new List<string> { $"---\n{fmText}\n---" };

                if (skill.TryGetProperty("body", out var bodyProp) && bodyProp.ValueKind == JsonValueKind.String)
                {
                    string body = bodyProp.GetString() ?? "";
                    if (!string.IsNullOrEmpty(body))
                        parts.Add(body);
                }

                File.WriteAllText(
                    Path.Combine(skillFolder, OptimizationConfig.SkillFile),
                    string.Join("\n", parts) + "\n");
            }
        }
    }

    private static async Task DownloadSkillFilesAsync(
        HttpPipeline pipeline,
        string endpoint,
        string candidateId,
        string candidatePath,
        CancellationToken cancellationToken)
    {
        // Fetch manifest
        string manifestUrl = $"{endpoint.TrimEnd('/')}/candidates/{candidateId}?api-version={ApiVersion}";

        using var manifestMessage = pipeline.CreateMessage();
        manifestMessage.Request.Uri.Reset(new Uri(manifestUrl));
        manifestMessage.Request.Method = RequestMethod.Get;

        await pipeline.SendAsync(manifestMessage, cancellationToken).ConfigureAwait(false);

        if (manifestMessage.Response.Status < 200 || manifestMessage.Response.Status >= 300)
            throw new RequestFailedException(manifestMessage.Response);

        using var manifestDoc = JsonDocument.Parse(manifestMessage.Response.Content);
        var manifest = manifestDoc.RootElement;

        if (!manifest.TryGetProperty("files", out var filesProp) || filesProp.ValueKind != JsonValueKind.Array)
            return;

        string skillsDirPath = Path.Combine(candidatePath, OptimizationConfig.SkillsDir);
        string skillsDirFull = Path.GetFullPath(skillsDirPath);

        foreach (var fileEntry in filesProp.EnumerateArray())
        {
            if (!IsSkillFile(fileEntry))
                continue;

            if (!fileEntry.TryGetProperty("path", out var pathProp) || pathProp.ValueKind != JsonValueKind.String)
                throw new InvalidOperationException($"Invalid manifest for candidate {candidateId}: skill file path is empty");

            string filePath = pathProp.GetString()!;
            if (string.IsNullOrEmpty(filePath))
                throw new InvalidOperationException($"Invalid manifest for candidate {candidateId}: skill file path is empty");

            // Download skill file content
            string fileUrl = $"{endpoint.TrimEnd('/')}/candidates/{candidateId}/files?path={Uri.EscapeDataString(filePath)}&api-version={ApiVersion}";
            using var fileMessage = pipeline.CreateMessage();
            fileMessage.Request.Uri.Reset(new Uri(fileUrl));
            fileMessage.Request.Method = RequestMethod.Get;

            await pipeline.SendAsync(fileMessage, cancellationToken).ConfigureAwait(false);
            if (fileMessage.Response.Status < 200 || fileMessage.Response.Status >= 300)
                throw new RequestFailedException(fileMessage.Response);

            string content = fileMessage.Response.Content.ToString();

            // Strip skills/ prefix
            string relPath = filePath;
            string prefix = OptimizationConfig.SkillsDir + "/";
            if (relPath.StartsWith(prefix, StringComparison.Ordinal))
                relPath = relPath[prefix.Length..];

            // Path traversal protection
            string outPath = Path.GetFullPath(Path.Combine(skillsDirPath, relPath));
            if (!outPath.StartsWith(skillsDirFull, StringComparison.Ordinal))
                throw new InvalidOperationException($"Invalid skill file path for candidate {candidateId}: {filePath}");

            string? parentDir = Path.GetDirectoryName(outPath);
            if (parentDir is not null)
                Directory.CreateDirectory(parentDir);

            await File.WriteAllTextAsync(outPath, content, cancellationToken).ConfigureAwait(false);
        }
    }

    private static bool IsSkillFile(JsonElement fileEntry)
    {
        if (fileEntry.TryGetProperty("type", out var typeProp) && typeProp.ValueKind == JsonValueKind.String && typeProp.GetString() == "skill")
            return true;

        if (fileEntry.TryGetProperty("path", out var pathProp) && pathProp.ValueKind == JsonValueKind.String)
        {
            string path = pathProp.GetString() ?? "";
            return path.StartsWith("skills/", StringComparison.Ordinal);
        }

        return false;
    }

    private static HttpPipeline BuildPipeline(string endpoint, TokenCredential? credential)
    {
        if (credential is null)
        {
            throw new InvalidOperationException(
                "A TokenCredential must be provided via ConfigLoaderOptions.Credential when using the resolver API. " +
                "Pass a DefaultAzureCredential or another TokenCredential implementation.");
        }

        return HttpPipelineBuilder.Build(
            new OptimizationClientOptions(),
            new BearerTokenAuthenticationPolicy(credential, AuthScope));
    }

    private sealed class OptimizationClientOptions : ClientOptions
    {
    }
}
