// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

// Pure-C# helpers for CreateAndTestRouterCommand (the classify-and-route
// create-and-test workflow). Intentionally no Azure.* imports so this
// source can be linked into the package's test project (which uses
// central package management) without dragging in cu-skill's HintPath /
// Azure.Identity dependency. See the Azure.AI.ContentUnderstanding test
// project's <Compile Include> entry and Skills.CreateAndTestRouterCommandTests.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Nodes;

namespace AzureSdkContentUnderstanding.Skills;

internal static partial class CreateAndTestRouterCommand
{
    // -----------------------------------------------------------------------
    // CLI argument parsing for --inner-schema alias=path
    // -----------------------------------------------------------------------

    internal static Dictionary<string, string> ParseInnerArg(IReadOnlyList<string> values)
    {
        var result = new Dictionary<string, string>(StringComparer.Ordinal);
        foreach (var entry in values)
        {
            var eq = entry.IndexOf('=');
            if (eq <= 0)
                throw new InvalidOperationException($"--inner-schema must be alias=path, got: '{entry}'");
            var alias = entry.Substring(0, eq).Trim();
            var path = entry.Substring(eq + 1).Trim();
            if (alias.Length == 0)
                throw new InvalidOperationException($"--inner-schema alias empty in: '{entry}'");
            if (result.ContainsKey(alias))
                throw new InvalidOperationException($"--inner-schema alias repeated: '{alias}'");
            result[alias] = path;
        }
        return result;
    }

    // -----------------------------------------------------------------------
    // Inner-id wiring: substitute alias placeholders in the outer schema's
    // contentCategories[*].analyzerId with the real analyzer IDs that were
    // just created. Returns a deep-clone (input is never mutated) plus a
    // list of human-readable validation errors (mismatched alias counts,
    // unused inner schemas).
    // -----------------------------------------------------------------------

    internal static (JsonObject Patched, List<string> Errors) WireInnerIds(
        JsonObject outerSchema, IReadOnlyDictionary<string, string> aliasToRealId)
    {
        var errors = new List<string>();
        var patched = outerSchema.DeepClone()!.AsObject();
        var categories = (patched["config"] as JsonObject)?["contentCategories"] as JsonObject ?? new JsonObject();

        foreach (var (catName, catEntry) in categories)
        {
            if (catEntry is not JsonObject entry) continue;
            var alias = entry["analyzerId"]?.GetValue<string?>();
            if (alias is null) continue;
            if (alias.StartsWith("prebuilt-", StringComparison.Ordinal)) continue;
            if (!aliasToRealId.TryGetValue(alias, out var real))
            {
                errors.Add(
                    $"category '{catName}' references analyzerId='{alias}', but " +
                    $"no --inner-schema entry matches alias '{alias}'. " +
                    $"Known aliases: [{string.Join(", ", aliasToRealId.Keys.OrderBy(s => s, StringComparer.Ordinal))}]");
                continue;
            }
            entry["analyzerId"] = real;
        }

        // Catch unused inner schemas (cheap typo check).
        var used = new HashSet<string>(StringComparer.Ordinal);
        foreach (var (_, catEntry) in categories)
        {
            if (catEntry is JsonObject entry && entry["analyzerId"] is JsonValue v && v.TryGetValue<string>(out var id))
                used.Add(id);
        }
        foreach (var (alias, real) in aliasToRealId)
        {
            if (!used.Contains(real))
            {
                errors.Add($"--inner-schema '{alias}' was supplied but no category in the outer schema routes to it");
            }
        }

        return (patched, errors);
    }

    // -----------------------------------------------------------------------
    // Category-aware stdout summary
    // -----------------------------------------------------------------------

    internal static string SummarizeRouted(IReadOnlyList<(string DocName, JsonObject Doc)> results)
    {
        var table = new SortedDictionary<string, SortedDictionary<string, List<(string Doc, object? Val, double? Conf)>>>(StringComparer.Ordinal);
        var segCounts = new SortedDictionary<string, int>(StringComparer.Ordinal);

        foreach (var (docName, doc) in results)
        {
            if (doc["contents"] is not JsonArray contents) continue;
            foreach (var content in contents.OfType<JsonObject>())
            {
                var category = content["category"]?.GetValue<string?>() ?? "(uncategorized)";
                segCounts.TryGetValue(category, out var c);
                segCounts[category] = c + 1;
                if (content["fields"] is not JsonObject fields) continue;
                foreach (var (fname, fnode) in fields)
                {
                    if (fnode is not JsonObject fobj) continue;
                    if (!table.TryGetValue(category, out var perField))
                    {
                        perField = new SortedDictionary<string, List<(string, object?, double?)>>(StringComparer.Ordinal);
                        table[category] = perField;
                    }
                    if (!perField.TryGetValue(fname, out var rows))
                    {
                        rows = new List<(string, object?, double?)>();
                        perField[fname] = rows;
                    }
                    rows.Add((docName, FieldValueRouted(fobj), GetConfidenceRouted(fobj)));
                }
            }
        }

        if (table.Count == 0 && segCounts.Count == 0)
            return "[SUMMARY] no segments classified.";

        var lines = new List<string> { string.Empty, new('=', 72), "[SUMMARY] (category-aware)" };
        foreach (var (category, denom) in segCounts)
        {
            var header = $"category: {category}  ({denom} segments)";
            lines.Add(string.Empty);
            lines.Add(header);
            lines.Add(new('-', header.Length));
            if (!table.TryGetValue(category, out var perField) || perField.Count == 0)
            {
                lines.Add("  (no extracted fields — classification-only or missing analyzerId)");
                continue;
            }
            lines.Add($"  {"field",-30} fill rate   avg conf");
            foreach (var (fname, rows) in perField)
            {
                var filled = rows.Where(r => r.Val is not null).ToList();
                var fillRate = denom == 0 ? 0.0 : (double)filled.Count / denom;
                var confs = filled.Where(r => r.Conf.HasValue).Select(r => r.Conf!.Value).ToList();
                var avg = confs.Count > 0 ? (double?)confs.Average() : null;
                var confStr = avg is null ? "  n/a" : avg.Value.ToString("0.000", CultureInfo.InvariantCulture);
                lines.Add($"  {fname,-30} {(fillRate * 100):0.0}%      {confStr}");
            }
        }

        var lowest = new List<(double Conf, string Cat, string Field, string Doc)>();
        foreach (var (category, perField) in table)
        {
            foreach (var (fname, rows) in perField)
            {
                foreach (var (docName, val, conf) in rows)
                {
                    if (val is null || conf is null) continue;
                    lowest.Add((conf.Value, category, fname, docName));
                }
            }
        }
        lowest.Sort((a, b) => a.Conf.CompareTo(b.Conf));
        if (lowest.Count > 0)
        {
            lines.Add(string.Empty);
            lines.Add("lowest-confidence fields across all categories:");
            foreach (var (conf, cat, fname, docName) in lowest.Take(3))
            {
                lines.Add($"  {conf.ToString("0.000", CultureInfo.InvariantCulture)}  [{cat}] {fname}  ({docName})");
            }
        }
        lines.Add(new('=', 72));
        return string.Join("\n", lines);
    }

    private static object? FieldValueRouted(JsonObject field)
    {
        foreach (var key in new[] { "valueString", "valueNumber", "valueInteger", "valueBoolean", "valueDate", "valueTime" })
        {
            if (field[key] is JsonValue v)
            {
                var raw = v.ToJsonString();
                if (raw != "null" && raw != "\"\"") return v;
            }
        }
        if (field["valueArray"] is JsonArray arr) return arr.Count > 0 ? arr : null;
        if (field["valueObject"] is JsonObject obj) return obj.Count > 0 ? obj : null;
        return null;
    }

    private static double? GetConfidenceRouted(JsonObject field)
    {
        if (field["confidence"] is JsonValue v && v.TryGetValue<double>(out var d))
            return d;
        return null;
    }
}
