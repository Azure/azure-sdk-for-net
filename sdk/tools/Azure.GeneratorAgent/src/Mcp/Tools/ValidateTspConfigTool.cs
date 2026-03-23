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
    private static readonly Regex s_emitterKeyRegex = new(
        @"""?@azure-typespec/http-client-csharp""?\s*:",
        RegexOptions.Compiled);

    private static readonly Regex s_emitterOutputDirRegex = new(
        @"emitter-output-dir\s*:",
        RegexOptions.Compiled);

    private static readonly Regex s_namespaceRegex = new(
        @"^\s+namespace\s*:\s*(?<value>.+)$",
        RegexOptions.Compiled | RegexOptions.Multiline);

    private static readonly Regex s_modelNamespaceRegex = new(
        @"model-namespace\s*:\s*false",
        RegexOptions.Compiled);

    [McpServerTool(Name = "validate_tsp_config"), Description("Validate that a tspconfig.yaml has correct @azure-typespec/http-client-csharp emitter configuration.")]
    public static string Execute(
        [Description("Absolute path to the tspconfig.yaml file")] string tspConfigPath,
        [Description("Expected SDK namespace (e.g., Azure.Storage.Blobs)")] string expectedNamespace)
    {
        var result = ValidateInProcess(tspConfigPath, expectedNamespace);
        return JsonSerializer.Serialize(result);
    }

    /// <summary>
    /// In-process validation for the orchestrator.
    /// </summary>
    public static TspConfigValidationResult ValidateInProcess(string tspConfigPath, string expectedNamespace)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(tspConfigPath);
            if (!File.Exists(normalizedPath))
            {
                return new TspConfigValidationResult { Success = true, IsValid = false, Reason = $"File not found: {normalizedPath}" };
            }

            var content = File.ReadAllText(normalizedPath);
            var issues = new List<string>();

            // Check emitter key exists and extract its section for scoped validation
            var emitterMatch = s_emitterKeyRegex.Match(content);
            if (!emitterMatch.Success)
            {
                issues.Add("Missing '@azure-typespec/http-client-csharp' key under options");
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
            var nextKeyRegex = new Regex(@"^\s{0,2}""?[a-zA-Z@]", RegexOptions.Multiline);
            var nextKeys = nextKeyRegex.Matches(content, sectionStart + emitterMatch.Length);
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
            var nsMatch = s_namespaceRegex.Match(emitterSection);
            if (!nsMatch.Success)
            {
                issues.Add("Missing 'namespace' field");
            }
            else
            {
                var actualNs = nsMatch.Groups["value"].Value.Trim().Trim('"', '\'');
                if (!string.Equals(actualNs, expectedNamespace, StringComparison.Ordinal))
                {
                    issues.Add($"Namespace mismatch: expected '{expectedNamespace}', got '{actualNs}'");
                }
            }

            // Check model-namespace: false within the emitter section
            if (!s_modelNamespaceRegex.IsMatch(emitterSection))
            {
                issues.Add("Missing or incorrect 'model-namespace: false' field");
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
    /// Inserts or replaces the @azure-typespec/http-client-csharp section.
    /// </summary>
    public static (bool Success, string? Error) FixTspConfig(string tspConfigPath, string expectedNamespace)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(tspConfigPath);
            if (!File.Exists(normalizedPath))
            {
                return (false, $"File not found: {normalizedPath}");
            }

            var content = File.ReadAllText(normalizedPath);
            var correctSection =
                $"  \"@azure-typespec/http-client-csharp\":\n" +
                $"    emitter-output-dir: \"{{output-dir}}/{{service-dir}}/{{namespace}}\"\n" +
                $"    namespace: {expectedNamespace}\n" +
                $"    model-namespace: false";

            // Try to find and replace the existing section
            var sectionRegex = new Regex(
                @"(\s*""?@azure-typespec/http-client-csharp""?\s*:)[\s\S]*?(?=\n\s*""?@|\n\s*emit\b|\n[^\s]|\z)",
                RegexOptions.Compiled);

            var replaced = sectionRegex.Replace(content, "\n" + correctSection);
            if (!ReferenceEquals(replaced, content))
            {
                content = replaced;
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
