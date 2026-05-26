// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that validates a tspconfig.yaml file for correct emitter configuration.
/// </summary>
[McpServerToolType]
public static class ValidateTspConfigTool
{
    private static readonly Regex s_dpgEmitterKeyRegex = new(
        @"""?@azure-typespec/http-client-csharp(?!-mgmt)""?\s*:",
        RegexOptions.Compiled);

    private static readonly Regex s_mgmtEmitterKeyRegex = new(
        @"""?@azure-typespec/http-client-csharp-mgmt""?\s*:",
        RegexOptions.Compiled);

    private static readonly Regex s_emitterOutputDirRegex = new(
        @"emitter-output-dir\s*:",
        RegexOptions.Compiled);

    private static readonly Regex s_namespaceRegex = new(
        @"^\s+namespace\s*:\s*(?<value>.+)$",
        RegexOptions.Compiled | RegexOptions.Multiline);

    private static readonly Regex s_modelNamespaceRegex = new(
        @"model-namespace\s*:",
        RegexOptions.Compiled);

    /// <summary>
    /// The only valid properties for the @azure-typespec/http-client-csharp emitter options.
    /// Anything else means the tspconfig is invalid and will cause the TypeSpec compiler
    /// to fail with "invalid-schema: must NOT have additional properties".
    /// </summary>
    private static readonly HashSet<string> s_validCSharpEmitterProperties = new(StringComparer.OrdinalIgnoreCase)
    {
        "emitter-output-dir",
        "namespace",
        "model-namespace",
        "clear-output-folder",
        "flavor",
    };

    /// <summary>
    /// Regex to extract YAML key-value pairs at an indentation level (property names within a section).
    /// Matches lines like "    some-property: value".
    /// </summary>
    private static readonly Regex s_yamlPropertyRegex = new(
        @"^(?<indent>\s+)(?<key>[a-zA-Z][a-zA-Z0-9-]*)\s*:",
        RegexOptions.Compiled | RegexOptions.Multiline);

    /// <summary>
    /// Matches the start of a top-level YAML key (at most 2 spaces indent), used to
    /// delimit the emitter section from the next section.
    /// </summary>
    private static readonly Regex s_nextTopLevelKeyRegex = new(
        @"^\s{0,2}""?[a-zA-Z@]",
        RegexOptions.Compiled | RegexOptions.Multiline);

    /// <summary>
    /// Matches the existing @azure-typespec/http-client-csharp emitter section
    /// in tspconfig.yaml for replacement.
    /// </summary>
    private static readonly Regex s_emitterSectionRegex = new(
        @"(\s*""?@azure-typespec/http-client-csharp""?\s*:)[\s\S]*?(?=\n\s*""?@|\n\s*emit\b|\n[^\s]|\z)",
        RegexOptions.Compiled);

    [McpServerTool(Name = "validate_tsp_config"), Description("Validate that a tspconfig.yaml has correct @azure-typespec/http-client-csharp emitter configuration.")]
    public static string Execute(
        [Description("Absolute path to the tspconfig.yaml file")] string tspConfigPath,
        [Description("SDK namespace for context (e.g., Azure.Storage.Blobs). Used by FixTspConfig, not checked during validation.")] string sdkNamespace)
    {
        var result = ValidateInProcess(tspConfigPath, sdkNamespace);
        return JsonSerializer.Serialize(result);
    }

    /// <summary>
    /// In-process validation for the orchestrator (reads from file).
    /// </summary>
    public static TspConfigValidationResult ValidateInProcess(string tspConfigPath, string sdkNamespace)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(tspConfigPath);
            if (!File.Exists(normalizedPath))
            {
                return new TspConfigValidationResult { Success = true, IsValid = false, Reason = $"File not found: {normalizedPath}" };
            }

            var content = File.ReadAllText(normalizedPath);
            return ValidateContent(content, sdkNamespace);
        }
        catch (Exception ex)
        {
            return new TspConfigValidationResult { Success = false, Reason = ex.Message };
        }
    }

    /// <summary>
    /// Validates tspconfig.yaml content from a string. Used by both file-based validation
    /// and remote validation (where content is fetched from GitHub).
    /// </summary>
    public static TspConfigValidationResult ValidateContent(string content, string sdkNamespace)
    {
        try
        {
            var issues = new List<string>();

            // Determine emitter key based on package plane
            var isMgmt = sdkNamespace.StartsWith("Azure.ResourceManager.", StringComparison.Ordinal);
            var emitterKeyRegex = isMgmt ? s_mgmtEmitterKeyRegex : s_dpgEmitterKeyRegex;
            var emitterKeyName = isMgmt
                ? "@azure-typespec/http-client-csharp-mgmt"
                : "@azure-typespec/http-client-csharp";

            // Check emitter key exists and extract its section for scoped validation
            var emitterMatch = emitterKeyRegex.Match(content);
            if (!emitterMatch.Success)
            {
                issues.Add($"Missing '{emitterKeyName}' key under options");
                return new TspConfigValidationResult
                {
                    Success = true,
                    IsValid = false,
                    Reason = string.Join("; ", issues),
                    Issues = issues
                };
            }

            // Extract the emitter section: from the emitter key to the next top-level key or EOF
            var sectionStart = emitterMatch.Index;
            var sectionEnd = content.Length;
            var nextKeys = s_nextTopLevelKeyRegex.Matches(content, sectionStart + emitterMatch.Length);
            foreach (Match nk in nextKeys)
            {
                sectionEnd = nk.Index;
                break;
            }
            var emitterSection = content[sectionStart..sectionEnd];

            // Check emitter-output-dir within the emitter section
            if (!s_emitterOutputDirRegex.IsMatch(emitterSection))
            {
                issues.Add("Missing 'emitter-output-dir' field");
            }

            // Check namespace within the emitter section
            if (!s_namespaceRegex.IsMatch(emitterSection))
            {
                issues.Add("Missing 'namespace' field");
            }

            // Check model-namespace within the emitter section
            if (!s_modelNamespaceRegex.IsMatch(emitterSection))
            {
                issues.Add("Missing 'model-namespace' field");
            }

            // Check for invalid properties within the emitter section.
            var emitterProperties = s_yamlPropertyRegex.Matches(emitterSection);
            foreach (Match prop in emitterProperties)
            {
                var key = prop.Groups["key"].Value;
                if (!s_validCSharpEmitterProperties.Contains(key))
                {
                    issues.Add($"Invalid property '{key}' in {emitterKeyName} section — not a recognized emitter option");
                }
            }

            return new TspConfigValidationResult
            {
                Success = true,
                IsValid = issues.Count == 0,
                Reason = issues.Count == 0 ? "Valid" : string.Join("; ", issues),
                Issues = issues
            };
        }
        catch (Exception ex)
        {
            return new TspConfigValidationResult { Success = false, Reason = ex.Message };
        }
    }

    /// <summary>
    /// Fixes a tspconfig.yaml to have the correct emitter configuration.
    /// Detects plane from sdkNamespace and inserts or replaces the appropriate emitter section.
    /// </summary>
    public static (bool Success, string? Error) FixTspConfig(string tspConfigPath, string sdkNamespace)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(tspConfigPath);
            if (!File.Exists(normalizedPath))
            {
                return (false, $"File not found: {normalizedPath}");
            }

            var isMgmt = sdkNamespace.StartsWith("Azure.ResourceManager.", StringComparison.Ordinal);
            var emitterKey = isMgmt
                ? "@azure-typespec/http-client-csharp-mgmt"
                : "@azure-typespec/http-client-csharp";

            var content = File.ReadAllText(normalizedPath);
            var correctSection =
                $"  \"{emitterKey}\":\n" +
                $"    emitter-output-dir: \"{{output-dir}}/{{service-dir}}/{{namespace}}\"\n" +
                $"    namespace: {sdkNamespace}\n" +
                $"    model-namespace: false";

            // Try to find and replace the existing section
            if (s_emitterSectionRegex.IsMatch(content))
            {
                content = s_emitterSectionRegex.Replace(content, "\n" + correctSection);
            }
            else if (content.Contains("options:", StringComparison.Ordinal))
            {
                // Insert after options:
                var optionsIdx = content.IndexOf("options:", StringComparison.Ordinal);
                var lineEnd = content.IndexOf('\n', optionsIdx);
                if (lineEnd >= 0)
                {
                    content = content.Insert(lineEnd + 1, correctSection + "\n");
                }
            }
            else
            {
                // Append options section
                content += "\noptions:\n" + correctSection + "\n";
            }

            File.WriteAllText(normalizedPath, content);
            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
