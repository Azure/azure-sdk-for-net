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
                await DownloadSkillFilesAsync(pipeline, endpoint, candidateId, candidatePath, cancellationToken).ConfigureAwait(false);
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
        metaLines.Add($"skill_dir: {OptimizationConfig.SkillsDir}");
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

        // skills/
        if (config.TryGetProperty("skills", out var skillsProp) && skillsProp.ValueKind == JsonValueKind.Array)
        {
            string skillsDirPath = Path.Combine(candidatePath, OptimizationConfig.SkillsDir);
            foreach (var skill in skillsProp.EnumerateArray())
            {
                if (skill.ValueKind != JsonValueKind.Object)
                {
                    continue;
                }

                if (!skill.TryGetProperty("name", out var nameProp) || nameProp.ValueKind != JsonValueKind.String)
                {
                    continue;
                }

                string skillName = nameProp.GetString();
                if (string.IsNullOrEmpty(skillName) ||
                    skillName.Contains("..", StringComparison.Ordinal) ||
                    skillName.IndexOf(Path.DirectorySeparatorChar) >= 0 ||
                    skillName.IndexOf(Path.AltDirectorySeparatorChar) >= 0)
                {
                    continue;
                }

                string skillFolder = Path.GetFullPath(Path.Combine(skillsDirPath, skillName));
                string skillsDirFull = Path.GetFullPath(skillsDirPath) + Path.DirectorySeparatorChar;
                if (!skillFolder.StartsWith(skillsDirFull, StringComparison.Ordinal))
                {
                    continue;
                }

                Directory.CreateDirectory(skillFolder);

                var fmDict = new Dictionary<string, string> { ["name"] = skillName };
                if (skill.TryGetProperty("description", out var descProp) && descProp.ValueKind == JsonValueKind.String)
                {
                    fmDict["description"] = descProp.GetString();
                }

                string fmText = SimpleYamlParser.SerializeKeyValuePairs(fmDict).TrimEnd('\n', '\r');
                var parts = new List<string> { $"---\n{fmText}\n---" };

                if (skill.TryGetProperty("body", out var bodyProp) && bodyProp.ValueKind == JsonValueKind.String)
                {
                    string body = bodyProp.GetString() ?? "";
                    if (!string.IsNullOrEmpty(body))
                    {
                        parts.Add(body);
                    }
                }

                File.WriteAllText(
                    Path.Combine(skillFolder, OptimizationConfig.SkillFile),
                    string.Join("\n", parts) + "\n");
            }
        }
    }

    private static async Task DownloadSkillFilesAsync(
        ClientPipeline pipeline,
        string endpoint,
        string candidateId,
        string candidatePath,
        CancellationToken cancellationToken)
    {
        string escapedCandidateId = Uri.EscapeDataString(candidateId);

        // Fetch manifest
        string manifestUrl = $"{endpoint.TrimEnd('/')}/candidates/{escapedCandidateId}?api-version={ApiVersion}";

        using var manifestMessage = pipeline.CreateMessage(new Uri(manifestUrl), "GET");
        manifestMessage.Apply(CreateRequestOptions(cancellationToken));

        await pipeline.SendAsync(manifestMessage).ConfigureAwait(false);

        if (manifestMessage.Response?.IsError != false)
        {
            throw new ClientResultException(manifestMessage.Response);
        }

        using var manifestDoc = JsonDocument.Parse(manifestMessage.Response.Content);
        var manifest = manifestDoc.RootElement;

        if (!manifest.TryGetProperty("files", out var filesProp) || filesProp.ValueKind != JsonValueKind.Array)
        {
            return;
        }

        string skillsDirPath = Path.Combine(candidatePath, OptimizationConfig.SkillsDir);
        string skillsDirFull = Path.GetFullPath(skillsDirPath) + Path.DirectorySeparatorChar;

        foreach (var fileEntry in filesProp.EnumerateArray())
        {
            if (!IsSkillFile(fileEntry))
            {
                continue;
            }

            if (!fileEntry.TryGetProperty("path", out var pathProp) || pathProp.ValueKind != JsonValueKind.String)
            {
                throw new InvalidOperationException($"Invalid manifest for candidate {candidateId}: skill file path is empty");
            }

            string filePath = pathProp.GetString();
            if (string.IsNullOrEmpty(filePath))
            {
                throw new InvalidOperationException($"Invalid manifest for candidate {candidateId}: skill file path is empty");
            }

            // Download skill file content
            string fileUrl = $"{endpoint.TrimEnd('/')}/candidates/{escapedCandidateId}/files?path={Uri.EscapeDataString(filePath)}&api-version={ApiVersion}";
            using var fileMessage = pipeline.CreateMessage(new Uri(fileUrl), "GET");
            fileMessage.Apply(CreateRequestOptions(cancellationToken));

            await pipeline.SendAsync(fileMessage).ConfigureAwait(false);
            if (fileMessage.Response?.IsError != false)
            {
                throw new ClientResultException(fileMessage.Response);
            }

            string content = fileMessage.Response.Content.ToString();

            // Strip skills/ prefix
            string relPath = filePath;
            string prefix = OptimizationConfig.SkillsDir + "/";
            if (relPath.StartsWith(prefix, StringComparison.Ordinal))
            {
                relPath = relPath.Substring(prefix.Length);
            }

            // Path traversal protection
            string outPath = Path.GetFullPath(Path.Combine(skillsDirPath, relPath));
            if (!outPath.StartsWith(skillsDirFull, StringComparison.Ordinal))
            {
                throw new InvalidOperationException($"Invalid skill file path for candidate {candidateId}: {filePath}");
            }

            string parentDir = Path.GetDirectoryName(outPath);
            if (parentDir != null)
            {
                Directory.CreateDirectory(parentDir);
            }

            using (var writer = new StreamWriter(outPath, append: false))
            {
                await writer.WriteAsync(content).ConfigureAwait(false);
            }
        }
    }

    private static bool IsSkillFile(JsonElement fileEntry)
    {
        if (fileEntry.TryGetProperty("type", out var typeProp) && typeProp.ValueKind == JsonValueKind.String && typeProp.GetString() == "skill")
        {
            return true;
        }

        if (fileEntry.TryGetProperty("path", out var pathProp) && pathProp.ValueKind == JsonValueKind.String)
        {
            string path = pathProp.GetString() ?? "";
            return path.StartsWith("skills/", StringComparison.Ordinal);
        }

        return false;
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
