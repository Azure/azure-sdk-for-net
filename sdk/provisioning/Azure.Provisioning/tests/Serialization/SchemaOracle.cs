// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Serialization;

/// <summary>
/// Loads schema oracles from the TypeSpec source-of-truth files.
/// These tsp files define the canonical shapes for the CDK serialization AST.
/// </summary>
internal static class SchemaOracle
{
    private static readonly string SchemaSpecDir = Path.Combine(
        TestContext.CurrentContext.TestDirectory, "Serialization", "SchemaSpec");

    private const string SchemaRepo = "Azure/js-provisioning-lib";
    private const string SchemaBranch = "main";

    private static string? s_staleWarning;
    private static bool s_staleChecked;

    /// <summary>
    /// Checks if the local tsp files are up to date with the remote repo.
    /// Issues a test warning if stale. Caches the result so the gh CLI call
    /// only happens once per test run. Safe to call from [SetUp] on every test.
    /// SOURCE.md must record the upstream branch commit SHA.
    /// </summary>
    public static void WarnIfStale()
    {
        if (!s_staleChecked)
        {
            s_staleChecked = true;
            s_staleWarning = CheckStale();
        }

        if (s_staleWarning != null)
        {
            Assert.Warn(s_staleWarning);
        }
    }

    private static string? CheckStale()
    {
        try
        {
            string sourceFile = Path.Combine(SchemaSpecDir, "SOURCE.md");
            if (!File.Exists(sourceFile))
                return null;

            string sourceContent = File.ReadAllText(sourceFile);
            var shaMatch = Regex.Match(sourceContent, @"\*\*SHA\*\*:\s*([0-9a-f]{40})");
            if (!shaMatch.Success)
                return null;
            string localSha = shaMatch.Groups[1].Value;

            var psi = new ProcessStartInfo(
                "gh",
                $"api repos/{SchemaRepo}/commits/{SchemaBranch} --jq .sha")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            using var proc = Process.Start(psi);
            if (proc == null)
                return null;
            if (!proc.WaitForExit(10_000))
            {
                proc.Kill();
                return null;
            }
            string remoteSha = proc.StandardOutput.ReadToEnd().Trim();
            proc.StandardError.ReadToEnd(); // drain to avoid blocking
            if (proc.ExitCode != 0 || string.IsNullOrEmpty(remoteSha))
                return null;

            if (!remoteSha.StartsWith(localSha) && !localSha.StartsWith(remoteSha))
            {
                return $"Local schema spec (SHA {localSha.Substring(0, 12)}) may be out of date. " +
                    $"Branch {SchemaRepo}:{SchemaBranch} head: {remoteSha.Substring(0, 12)}. " +
                    "Re-download its typespec/ directory and update SOURCE.md.";
            }
        }
        catch
        {
            // Silently skip — no internet, no gh CLI, etc.
        }
        return null;
    }

    /// <summary>
    /// Parses a tsp union definition and extracts the set of valid values.
    /// For string literal unions (e.g. TargetScope) it returns the literal values.
    /// For discriminated unions (e.g. ExpressionNode) it looks up the "kind" field
    /// on each referenced model type across all tsp files.
    /// </summary>
    public static HashSet<string> LoadUnionKinds(string tspFile, string unionName)
    {
        string content = File.ReadAllText(Path.Combine(SchemaSpecDir, tspFile));
        string allContent = string.Join("\n",
            Directory.GetFiles(SchemaSpecDir, "*.tsp").Select(f => File.ReadAllText(f)));

        var kinds = new HashSet<string>();
        var unionMatch = Regex.Match(content, @$"union\s+{unionName}\s*\{{([^}}]+)\}}");
        if (!unionMatch.Success)
            return kinds;

        string body = unionMatch.Groups[1].Value;
        foreach (Match member in Regex.Matches(body, @"""?([\w-]+)""?\s*:\s*(""[^""]+""|\w+)"))
        {
            string value = member.Groups[2].Value;
            if (value.StartsWith("\""))
            {
                kinds.Add(value.Trim('"'));
            }
            else
            {
                string typeName = value;
                var modelMatch = Regex.Match(allContent,
                    @$"model\s+{typeName}\s*\{{[^}}]*kind\s*:\s*""([^""]+)""");
                if (modelMatch.Success)
                    kinds.Add(modelMatch.Groups[1].Value);
            }
        }
        return kinds;
    }

    /// <summary>Valid expression kinds from expressions.tsp ExpressionNode union.</summary>
    public static readonly Lazy<HashSet<string>> ExpressionKinds = new(() =>
        LoadUnionKinds("expressions.tsp", "ExpressionNode"));

    /// <summary>Valid type kinds from types.tsp TypeNode union.</summary>
    public static readonly Lazy<HashSet<string>> TypeKinds = new(() =>
        LoadUnionKinds("types.tsp", "TypeNode"));

    /// <summary>Valid target scopes from main.tsp TargetScope union.</summary>
    public static readonly Lazy<HashSet<string>> TargetScopes = new(() =>
        LoadUnionKinds("main.tsp", "TargetScope"));

    /// <summary>Valid primitive type names from types.tsp PrimitiveTypeName union.</summary>
    public static readonly Lazy<HashSet<string>> PrimitiveTypeNames = new(() =>
        LoadUnionKinds("types.tsp", "PrimitiveTypeName"));

    private static readonly Lazy<string> SchemaText = new(() => Regex.Replace(
        string.Join("\n", Directory.GetFiles(SchemaSpecDir, "*.tsp").Select(File.ReadAllText)),
        @"/\*.*?\*/|//[^\r\n]*", "", RegexOptions.Singleline));

    /// <summary>
    /// Validates the model, union, record, array, and scalar syntax used by the pinned schema.
    /// Unlike kind-only checks, this also checks required fields and nested payload shapes.
    /// </summary>
    internal static void AssertMatchesType(JsonElement value, string type)
    {
        string? error = ValidateType(value, type, "$");
        Assert.That(error, Is.Null, error);
    }

    private static string? ValidateType(JsonElement value, string type, string path)
    {
        type = type.Trim();
        string mismatch = $"{path}: expected {type}, got {value.GetRawText()}";
        if (type.StartsWith('"'))
            return value.ValueKind == JsonValueKind.String && value.GetString() == type.Trim('"') ? null : mismatch;
        if (type.Contains('|'))
            return type.Split('|').Any(t => ValidateType(value, t, path) == null) ? null : mismatch;
        switch (type)
        {
            case "string":
                return value.ValueKind == JsonValueKind.String ? null : mismatch;
            case "boolean":
                return value.ValueKind is JsonValueKind.True or JsonValueKind.False ? null : mismatch;
            case "true":
                return value.ValueKind == JsonValueKind.True ? null : mismatch;
            case "null":
                return value.ValueKind == JsonValueKind.Null ? null : mismatch;
            case "safeint":
                return value.ValueKind == JsonValueKind.Number && value.TryGetInt64(out long integer) &&
                    integer >= -9007199254740991 && integer <= 9007199254740991 ? null : mismatch;
        }
        if (type.EndsWith("[]"))
        {
            if (value.ValueKind != JsonValueKind.Array)
                return mismatch;
            int index = 0;
            foreach (JsonElement item in value.EnumerateArray())
            {
                string? error = ValidateType(item, type.Substring(0, type.Length - 2), $"{path}[{index++}]");
                if (error != null)
                    return error;
            }
            return null;
        }
        if (type.StartsWith("Record<") && type.EndsWith('>'))
        {
            if (value.ValueKind != JsonValueKind.Object)
                return mismatch;
            foreach (JsonProperty property in value.EnumerateObject())
            {
                string? error = ValidateType(property.Value, type.Substring(7, type.Length - 8), $"{path}.{property.Name}");
                if (error != null)
                    return error;
            }
            return null;
        }
        Match union = Regex.Match(SchemaText.Value, @$"\bunion\s+{Regex.Escape(type)}\s*\{{([^}}]*)\}}");
        if (union.Success)
        {
            foreach (Match member in Regex.Matches(union.Groups[1].Value, @"""?[\w-]+""?\s*:\s*(""[^""]+""|\w+)"))
            {
                if (ValidateType(value, member.Groups[1].Value, path) == null)
                    return null;
            }
            return mismatch;
        }
        Match model = Regex.Match(SchemaText.Value, @$"\bmodel\s+{Regex.Escape(type)}\s*\{{([^}}]*)\}}");
        if (!model.Success)
            throw new InvalidOperationException($"The schema validator does not recognize TypeSpec type '{type}'.");
        if (value.ValueKind != JsonValueKind.Object)
            return mismatch;
        foreach (Match field in Regex.Matches(model.Groups[1].Value, @"(\w+)(\?)?\s*:\s*([^;]+);"))
        {
            string name = field.Groups[1].Value;
            if (!value.TryGetProperty(name, out JsonElement fieldValue))
            {
                if (!field.Groups[2].Success)
                    return $"{path}: missing required {type}.{name}";
                continue;
            }
            string? error = ValidateType(fieldValue, field.Groups[3].Value, $"{path}.{name}");
            if (error != null)
                return error;
        }
        return null;
    }
}
