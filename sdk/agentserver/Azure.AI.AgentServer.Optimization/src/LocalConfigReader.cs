// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Reads optimization config from the local directory layout.
/// </summary>
internal static class LocalConfigReader
{
    /// <summary>
    /// Loads an <see cref="OptimizationConfig"/> from a local directory.
    /// </summary>
    public static OptimizationConfig? Load(string? candidateId, string? configDir)
    {
        string localDir = ResolveLocalDir(configDir);
        if (!Directory.Exists(localDir))
        {
            return null;
        }

        string? candidatePath = ResolveCandidateFolder(localDir, candidateId);
        if (candidatePath is null)
        {
            return null;
        }

        string? resolvedCandidateId = null;
        string? nonEmptyCandidateId = string.IsNullOrEmpty(candidateId) ? null : candidateId;
        if (nonEmptyCandidateId != null && IsValidCandidateId(nonEmptyCandidateId))
        {
            resolvedCandidateId = nonEmptyCandidateId;
        }
        string metadataFilePath = Path.Combine(candidatePath, OptimizationConfig.MetadataFile);
        return LoadCandidateFromMetadata(candidatePath, metadataFilePath, resolvedCandidateId);
    }

    /// <summary>
    /// Loads skills from a directory of skill folders.
    /// </summary>
    public static IReadOnlyList<OptimizationSkill> LoadSkillsFromDirectory(string skillsDir)
    {
        if (!Directory.Exists(skillsDir))
        {
            return Array.Empty<OptimizationSkill>();
        }

        var skills = new List<OptimizationSkill>();
        foreach (var skillFolder in Directory.GetDirectories(skillsDir).OrderBy(d => d))
        {
            string skillFile = Path.Combine(skillFolder, OptimizationConfig.SkillFile);
            if (!File.Exists(skillFile))
            {
                continue;
            }

            try
            {
                string content = File.ReadAllText(skillFile).Trim();
                var (frontmatter, body) = ParseSkillFrontmatter(content);
                string name = frontmatter.TryGetValue("name", out var n) && n is string nameStr
                    ? nameStr
                    : Path.GetFileName(skillFolder);
                string description = frontmatter.TryGetValue("description", out var d) && d is string descStr
                    ? descStr
                    : "";

                if (frontmatter.Count == 0 && !string.IsNullOrEmpty(body))
                {
                    var lines = body.Split(new[] { '\n' }, 2);
                    description = lines[0].TrimStart('#').Trim();
                    body = lines.Length > 1 ? lines[1].Trim() : "";
                }

                skills.Add(new OptimizationSkill(name, description, body));
            }
            catch (IOException)
            {
                // Skip unreadable skill files
            }
        }

        return skills;
    }

    internal static string ResolveLocalDir(string? configDir)
    {
        if (configDir != null)
        {
            return Path.GetFullPath(configDir);
        }

        string envDir = Environment.GetEnvironmentVariable(OptimizationConfig.EnvLocalDir)?.Trim() ?? "";
        if (!string.IsNullOrEmpty(envDir))
        {
            return Path.GetFullPath(envDir);
        }

        return Path.GetFullPath(OptimizationConfig.DefaultLocalDir);
    }

    private static string? ResolveCandidateFolder(string localDir, string? candidateId)
    {
        string? nonEmptyCandidateId = string.IsNullOrEmpty(candidateId) ? null : candidateId;
        if (nonEmptyCandidateId != null && IsValidCandidateId(nonEmptyCandidateId))
        {
            string exact = Path.Combine(localDir, nonEmptyCandidateId);
            if (Directory.Exists(exact))
            {
                return exact;
            }
        }

        string baseline = Path.Combine(localDir, OptimizationConfig.BaselineDir);
        return Directory.Exists(baseline) ? baseline : null;
    }

    private static OptimizationConfig? LoadCandidateFromMetadata(
        string candidatePath,
        string metadataFilePath,
        string? candidateId)
    {
        IDictionary<string, object?> raw;
        if (File.Exists(metadataFilePath))
        {
            try
            {
                string yamlContent = File.ReadAllText(metadataFilePath);
                raw = SimpleYamlParser.ParseKeyValuePairs(yamlContent);
            }
            catch (Exception ex) when (ex is FormatException or IOException)
            {
                throw new InvalidOperationException($"Invalid metadata file {metadataFilePath}: {ex.Message}", ex);
            }
        }
        else
        {
            raw = new Dictionary<string, object?>();
        }

        var meta = MetadataConfig.FromDictionary(raw);

        // Read instructions
        string instructionsPath = Path.Combine(candidatePath, meta.InstructionFile);
        string? instructions = File.Exists(instructionsPath)
            ? File.ReadAllText(instructionsPath).Trim()
            : null;

        // Resolve skills directory
        string skillsPath = Path.Combine(candidatePath, meta.SkillDir);
        string? skillsDirectory = Directory.Exists(skillsPath)
            ? Path.GetFullPath(skillsPath)
            : null;
        IReadOnlyList<OptimizationSkill> skills = skillsDirectory != null
            ? LoadSkillsFromDirectory(skillsDirectory)
            : Array.Empty<OptimizationSkill>();

        // Load tool definitions
        string toolFilePath = Path.Combine(candidatePath, meta.ToolFile);
        var toolDefinitions = LoadToolDefinitions(toolFilePath);

        return new OptimizationConfig(
            instructions: instructions,
            model: meta.Model,
            temperature: meta.Temperature,
            skills: skills,
            skillsDirectory: skillsDirectory,
            toolDefinitions: toolDefinitions,
            source: $"local:{candidatePath}",
            candidateId: candidateId);
    }

    private static IReadOnlyList<BinaryData> LoadToolDefinitions(string toolFilePath)
    {
        if (!File.Exists(toolFilePath))
        {
            return Array.Empty<BinaryData>();
        }

        try
        {
            string json = File.ReadAllText(toolFilePath);
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.ValueKind != JsonValueKind.Array)
            {
                return Array.Empty<BinaryData>();
            }

            var tools = new List<BinaryData>();
            foreach (var item in doc.RootElement.EnumerateArray())
            {
                tools.Add(BinaryData.FromString(item.GetRawText()));
            }

            return tools;
        }
        catch (Exception ex) when (ex is JsonException or IOException)
        {
            return Array.Empty<BinaryData>();
        }
    }

    internal static (Dictionary<string, object?> Frontmatter, string Body) ParseSkillFrontmatter(string content)
    {
        if (!content.StartsWith("---"))
        {
            return (new Dictionary<string, object?>(), content);
        }

        int end = content.IndexOf("---", 3, StringComparison.Ordinal);
        if (end == -1)
        {
            return (new Dictionary<string, object?>(), content);
        }

        string fmText = content.Substring(3, end - 3).Trim();
        string body = content.Substring(end + 3).Trim();

        try
        {
            return (SimpleYamlParser.ParseKeyValuePairs(fmText), body);
        }
        catch (FormatException)
        {
            return (new Dictionary<string, object?>(), body);
        }
    }

    private static bool IsValidCandidateId(string candidateId)
    {
        return !candidateId.Contains("..", StringComparison.Ordinal) &&
            candidateId.IndexOf(Path.DirectorySeparatorChar) < 0 &&
            candidateId.IndexOf(Path.AltDirectorySeparatorChar) < 0;
    }
}
