// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

// Pure-C# helpers for CreateAndTestCommand (the single-analyzer
// create-and-test workflow). Intentionally no Azure.* imports so this
// source can be linked into the package's test project (which uses
// central package management) without dragging in cu-skill's HintPath /
// Azure.Identity dependency. See the Azure.AI.ContentUnderstanding test
// project's <Compile Include> entry and Skills.CreateAndTestCommandTests.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Nodes;

namespace AzureSdkContentUnderstanding.Skills;

internal static partial class CreateAndTestCommand
{
    // -----------------------------------------------------------------------
    // Stdout summary
    // -----------------------------------------------------------------------

    internal static string Summarize(IReadOnlyList<(string DocName, JsonObject Doc)> results)
    {
        // category → field → list[(docName, value, confidence)]
        var table = new SortedDictionary<string, SortedDictionary<string, List<(string DocName, object? Value, double? Confidence)>>>(StringComparer.Ordinal);

        foreach (var (docName, doc) in results)
        {
            foreach (var (category, fieldPath, fieldVal) in IterFields(doc))
            {
                if (!table.TryGetValue(category, out var perField))
                {
                    perField = new SortedDictionary<string, List<(string, object?, double?)>>(StringComparer.Ordinal);
                    table[category] = perField;
                }
                if (!perField.TryGetValue(fieldPath, out var rows))
                {
                    rows = new List<(string, object?, double?)>();
                    perField[fieldPath] = rows;
                }
                rows.Add((docName, FieldValue(fieldVal), GetConfidence(fieldVal)));
            }
        }

        if (table.Count == 0)
            return "[SUMMARY] no fields extracted across any document.";

        var lines = new List<string> { string.Empty, new('=', 72), "[SUMMARY]" };
        foreach (var (category, perField) in table)
        {
            var docNames = new HashSet<string>(StringComparer.Ordinal);
            foreach (var rows in perField.Values)
                foreach (var r in rows) docNames.Add(r.DocName);
            var nDocs = docNames.Count;
            var catLabel = string.IsNullOrEmpty(category) ? "(single)" : category;
            var header = $"category: {catLabel}  ({nDocs} document{(nDocs == 1 ? string.Empty : "s")})";
            lines.Add(string.Empty);
            lines.Add(header);
            lines.Add(new('-', header.Length));
            lines.Add($"  {"field",-40} fill rate   avg conf");
            foreach (var (fname, rows) in perField)
            {
                var denom = rows.Count;
                var filled = rows.Where(r => !IsEmpty(r.Value)).ToList();
                var fillRate = denom == 0 ? 0.0 : (double)filled.Count / denom;
                var confidences = filled.Where(r => r.Confidence.HasValue).Select(r => r.Confidence!.Value).ToList();
                var avgConf = confidences.Count > 0 ? (double?)confidences.Average() : null;
                var confStr = avgConf is null ? "  n/a" : avgConf.Value.ToString("0.000", CultureInfo.InvariantCulture);
                lines.Add($"  {fname,-40} {(fillRate * 100):0.0}%      {confStr}");
            }
        }

        // Lowest-confidence triples.
        var lowest = new List<(double Conf, string Cat, string Field, string Doc)>();
        foreach (var (category, perField) in table)
        {
            foreach (var (fname, rows) in perField)
            {
                foreach (var (docName, value, conf) in rows)
                {
                    if (IsEmpty(value) || conf is null) continue;
                    lowest.Add((conf.Value, category, fname, docName));
                }
            }
        }
        lowest.Sort((a, b) => a.Conf.CompareTo(b.Conf));
        if (lowest.Count > 0)
        {
            lines.Add(string.Empty);
            lines.Add("lowest-confidence fields:");
            foreach (var (conf, cat, fname, docName) in lowest.Take(3))
            {
                var catTag = string.IsNullOrEmpty(cat) ? string.Empty : $"[{cat}] ";
                lines.Add($"  {conf.ToString("0.000", CultureInfo.InvariantCulture)}  {catTag}{fname}  ({docName})");
            }
        }
        lines.Add(new('=', 72));
        return string.Join("\n", lines);
    }

    internal static IEnumerable<(string Category, string FieldPath, JsonObject FieldVal)> IterFields(JsonObject doc)
    {
        if (doc["contents"] is not JsonArray contents) yield break;
        foreach (var content in contents.OfType<JsonObject>())
        {
            var category = content["category"]?.GetValue<string?>() ?? string.Empty;
            if (content["fields"] is not JsonObject fields) continue;
            foreach (var (fname, fnode) in fields)
            {
                if (fnode is not JsonObject fobj) continue;
                foreach (var (path, leaf) in Recurse(fname, fobj))
                    yield return (category, path, leaf);
            }
        }
    }

    private static IEnumerable<(string Path, JsonObject Leaf)> Recurse(string prefix, JsonObject fieldVal)
    {
        if (fieldVal["valueArray"] is JsonArray arr)
        {
            foreach (var item in arr)
            {
                if (item is JsonObject itemObj && itemObj["valueObject"] is JsonObject vobj)
                {
                    foreach (var (childName, childVal) in vobj)
                    {
                        if (childVal is JsonObject childObj)
                        {
                            foreach (var r in Recurse($"{prefix}[].{childName}", childObj))
                                yield return r;
                        }
                    }
                }
                else
                {
                    var wrap = new JsonObject();
                    if (item is JsonValue jv && jv.TryGetValue<string>(out var sv))
                    {
                        wrap["valueString"] = sv;
                    }
                    else if (item is JsonObject io)
                    {
                        wrap = (JsonObject)io.DeepClone();
                    }
                    yield return (prefix, wrap);
                }
            }
            yield break;
        }
        if (fieldVal["valueObject"] is JsonObject objVal)
        {
            foreach (var (childName, childVal) in objVal)
            {
                if (childVal is JsonObject childObj)
                {
                    foreach (var r in Recurse($"{prefix}.{childName}", childObj))
                        yield return r;
                }
            }
            yield break;
        }
        yield return (prefix, fieldVal);
    }

    private static object? FieldValue(JsonObject field)
    {
        foreach (var key in new[] { "valueString", "valueNumber", "valueInteger", "valueBoolean", "valueDate", "valueTime" })
        {
            if (field[key] is JsonValue v)
            {
                var raw = v.ToJsonString();
                if (raw != "null" && raw != "\"\"")
                    return v;
            }
        }
        if (field["valueArray"] is JsonArray arr)
            return arr.Count > 0 ? arr : null;
        if (field["valueObject"] is JsonObject obj)
            return obj.Count > 0 ? obj : null;
        return null;
    }

    private static double? GetConfidence(JsonObject field)
    {
        if (field["confidence"] is JsonValue v && v.TryGetValue<double>(out var d))
            return d;
        return null;
    }

    private static bool IsEmpty(object? value) => value is null;
}
