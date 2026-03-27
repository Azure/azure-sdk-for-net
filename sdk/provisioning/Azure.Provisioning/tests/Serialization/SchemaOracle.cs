// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

    private const string SchemaRepo = "bterlson/azure-cdk";
    private const string SchemaPath = "typespec";

    private static string? s_staleWarning;
    private static bool s_staleChecked;

    /// <summary>
    /// Checks if the local tsp files are up to date with the remote repo.
    /// Issues a test warning if stale. Caches the result so the gh CLI call
    /// only happens once per test run. Safe to call from [SetUp] on every test.
    /// SOURCE.md must record the SHA from <c>gh api repos/{repo}/commits?path={path}&amp;per_page=1</c>,
    /// not a merge commit SHA, since path-filtered results exclude merge commits.
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
            if (!File.Exists(sourceFile)) return null;

            string sourceContent = File.ReadAllText(sourceFile);
            var shaMatch = Regex.Match(sourceContent, @"\*\*SHA\*\*:\s*([0-9a-f]{40})");
            if (!shaMatch.Success) return null;
            string localSha = shaMatch.Groups[1].Value;

            var psi = new ProcessStartInfo("gh", $"api repos/{SchemaRepo}/commits?path={SchemaPath}&per_page=1 --jq .[0].sha")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            using var proc = Process.Start(psi);
            if (proc == null) return null;
            if (!proc.WaitForExit(10_000))
            {
                proc.Kill();
                return null;
            }
            string remoteSha = proc.StandardOutput.ReadToEnd().Trim();
            proc.StandardError.ReadToEnd(); // drain to avoid blocking
            if (proc.ExitCode != 0 || string.IsNullOrEmpty(remoteSha)) return null;

            if (!remoteSha.StartsWith(localSha) && !localSha.StartsWith(remoteSha))
            {
                return $"Local schema spec (SHA {localSha.Substring(0, 12)}) may be out of date. " +
                    $"Latest remote commit touching {SchemaPath}/: {remoteSha.Substring(0, 12)}. " +
                    $"Re-download from {SchemaRepo} and update SOURCE.md.";
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
        if (!unionMatch.Success) return kinds;

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

    /// <summary>
    /// Forward-compat expression kinds produced by the compiler but not yet in the spec.
    /// These are kept so we don't reject valid compiled output.
    /// </summary>
    public static readonly HashSet<string> ForwardCompatExpressionKinds = new()
    {
        "binary", "unary", "conditional", "interpolated-string",
        "nested-access", "decorator"
    };

    /// <summary>
    /// All valid expression kinds: spec + forward-compat.
    /// </summary>
    public static HashSet<string> AllValidExpressionKinds
    {
        get
        {
            var combined = new HashSet<string>(ExpressionKinds.Value);
            combined.UnionWith(ForwardCompatExpressionKinds);
            return combined;
        }
    }
}
