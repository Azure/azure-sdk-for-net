// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Classify-and-route: validate, create N inner analyzers + 1 outer classifier,
// batch-test, and print a category-aware stdout summary.
// Mirrors Python's create_and_test_router.py.

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;

namespace AzureSdkContentUnderstanding.Skills;

internal static partial class CreateAndTestRouterCommand
{
    public static async Task<int> RunAsync(string[] args)
    {
        var parsed = ParseArgs(args);
        if (parsed is null) return 2;
        var opts = parsed.Value;

        if (!File.Exists(opts.OuterSchema))
        {
            Console.Error.WriteLine($"outer schema not found: {opts.OuterSchema}");
            return 2;
        }
        if (!File.Exists(opts.Input) && !Directory.Exists(opts.Input))
        {
            Console.Error.WriteLine($"input not found: {opts.Input}");
            return 2;
        }
        if (opts.InnerSchemaArgs.Count > 0 && opts.SchemaDir is not null)
        {
            Console.Error.WriteLine("--inner-schema and --schema-dir are mutually exclusive");
            return 2;
        }
        if (opts.InnerSchemaArgs.Count == 0 && opts.SchemaDir is null)
        {
            Console.Error.WriteLine("provide --schema-dir DIR or one or more --inner-schema alias=path");
            return 2;
        }

        Dictionary<string, string> innerPaths;
        if (opts.SchemaDir is not null)
        {
            JsonObject outerPreview;
            try
            {
                outerPreview = JsonNode.Parse(File.ReadAllText(opts.OuterSchema))!.AsObject();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"outer schema is not valid JSON: {ex.Message}");
                return 2;
            }
            try
            {
                innerPaths = DiscoverInnerFromDir(outerPreview, opts.SchemaDir);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 2;
            }
            var summary = string.Join(", ", innerPaths.Select(kv => $"{kv.Key}={Path.GetFileName(kv.Value)}"));
            Console.WriteLine($"[SCHEMA-DIR] resolved: {summary}");
        }
        else
        {
            try
            {
                innerPaths = ParseInnerArg(opts.InnerSchemaArgs);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 2;
            }
        }

        return await RunCoreAsync(opts, innerPaths).ConfigureAwait(false);
    }

    private static async Task<int> RunCoreAsync(Options opts, Dictionary<string, string> innerPaths)
    {
        // 1. Validate everything locally.
        var (outerSchema, innerSchemas, valFailed) = ValidateAll(opts.OuterSchema, innerPaths);
        if (valFailed) return 2;

        var inputs = CreateAndTestCommand.EnumerateInputs(opts.Input).ToList();
        if (inputs.Count == 0)
        {
            Console.Error.WriteLine($"no supported documents found under {opts.Input}");
            return 2;
        }

        Directory.CreateDirectory(opts.Output);

        var analyzerId = opts.AnalyzerId;
        if (string.IsNullOrEmpty(analyzerId))
        {
            var stem = Path.GetFileNameWithoutExtension(opts.OuterSchema);
            if (opts.Reuse)
            {
                // Hash includes inner schema hashes so any inner edit forces a new outer.
                var innerBlob = string.Concat(
                    innerSchemas
                        .OrderBy(kv => kv.Key, StringComparer.Ordinal)
                        .Select(kv => $"{kv.Key}:{CreateAndTestCommand.SchemaHash(kv.Value)};"));
                var compound = new JsonObject
                {
                    ["outer"] = outerSchema!.DeepClone(),
                    ["inner"] = innerBlob,
                };
                analyzerId = $"{stem}_{CreateAndTestCommand.SchemaHash(compound)}";
            }
            else
            {
                analyzerId = $"{stem}_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            }
        }

        var client = CreateAndTestCommand.BuildClient();

        var aliasToId = new Dictionary<string, string>();
        bool outerReused = false;
        int fail = 0;
        var results = new List<(string DocName, JsonObject Doc)>();

        try
        {
            // 2. Create inner analyzers.
            foreach (var (alias, innerSchema) in innerSchemas)
            {
                string realId;
                if (opts.Reuse)
                {
                    realId = $"{analyzerId}_inner_{alias}_{CreateAndTestCommand.SchemaHash(innerSchema)}";
                    await CreateAndTestCommand.EnsureAnalyzerAsync(client, realId, innerSchema).ConfigureAwait(false);
                }
                else
                {
                    realId = $"{analyzerId}_inner_{alias}";
                    Console.WriteLine($"[CREATE-INNER] {alias} → {realId}");
                    await CreateAndTestCommand.CreateAnalyzerAsync(client, realId, innerSchema).ConfigureAwait(false);
                }
                aliasToId[alias] = realId;
            }

            // 3. Patch outer schema with real inner IDs.
            var (patched, wireErrors) = WireInnerIds(outerSchema!, aliasToId);
            if (wireErrors.Count > 0)
            {
                foreach (var e in wireErrors) Console.Error.WriteLine($"[VALIDATE] {e}");
                return 2;
            }

            // 4. Create outer.
            if (opts.Reuse)
            {
                outerReused = await CreateAndTestCommand.EnsureAnalyzerAsync(client, analyzerId, patched).ConfigureAwait(false);
            }
            else
            {
                Console.WriteLine($"[CREATE-OUTER] {analyzerId}");
                await CreateAndTestCommand.CreateAnalyzerAsync(client, analyzerId, patched).ConfigureAwait(false);
                Console.WriteLine($"[CREATE-OUTER] {analyzerId} ready");
            }

            // 5. Analyze inputs.
            foreach (var filePath in inputs)
            {
                var stem = Path.GetFileNameWithoutExtension(filePath);
                var outPath = Path.Combine(opts.Output, $"{stem}.json");
                try
                {
                    Console.WriteLine($"[ANALYZE] {filePath} → {outPath}");
                    var bytes = await File.ReadAllBytesAsync(filePath).ConfigureAwait(false);
                    var data = BinaryData.FromBytes(bytes);
                    var op = await client.AnalyzeBinaryAsync(WaitUntil.Completed, analyzerId, data).ConfigureAwait(false);
                    // Read raw service JSON so the on-disk shape (valueString/...)
                    // matches the Python skill output and the summary logic.
                    // Unwrap the LRO `{id,status,result,usage}` envelope.
                    var rawJson = op.GetRawResponse().Content?.ToString();
                    JsonObject docJson;
                    if (!string.IsNullOrEmpty(rawJson))
                    {
                        var parsed = JsonNode.Parse(rawJson)!.AsObject();
                        docJson = parsed["result"] is JsonObject inner
                            ? (JsonObject)inner.DeepClone()
                            : parsed;
                    }
                    else
                    {
                        docJson = JsonSerializer.SerializeToNode(op.Value, SerializerOptions)!.AsObject();
                    }
                    await File.WriteAllTextAsync(outPath, docJson.ToJsonString(WriteOptions)).ConfigureAwait(false);
                    try
                    {
                        var llmText = op.Value.ToLlmInput();
                        if (!string.IsNullOrEmpty(llmText))
                        {
                            await File.WriteAllTextAsync(
                                Path.ChangeExtension(outPath, ".llm.md"),
                                llmText).ConfigureAwait(false);
                        }
                    }
                    catch
                    {
                        // Best-effort.
                    }
                    results.Add((Path.GetFileNameWithoutExtension(outPath), docJson));
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"[FAIL]    {filePath}: {ex.Message}");
                    fail++;
                }
            }
        }
        finally
        {
            if (opts.Ephemeral)
            {
                foreach (var id in new[] { analyzerId }.Concat(aliasToId.Values))
                {
                    try
                    {
                        Console.WriteLine($"[CLEANUP] delete {id}");
                        await client.DeleteAnalyzerAsync(id).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"[CLEANUP] failed for {id}: {ex.Message}");
                    }
                }
            }
            else
            {
                var kept = new[] { analyzerId }.Concat(aliasToId.Values).ToList();
                Console.WriteLine(
                    $"[KEEP]    analyzers retained ({kept.Count}): " +
                    $"[{string.Join(", ", kept)}] (use --ephemeral to delete)");
            }
        }

        Console.WriteLine(SummarizeRouted(results));
        return fail == 0 ? 0 : 1;
    }

    // -----------------------------------------------------------------------
    // -----------------------------------------------------------------------
    // Pure helpers (ParseInnerArg, WireInnerIds, SummarizeRouted, FieldValue,
    // GetConfidence) live in CreateAndTestRouterCommand.Helpers.cs — that
    // source has no Azure.* imports and is linked into the
    // Azure.AI.ContentUnderstanding test project so we can unit-test it
    // without depending on cu-skill.csproj.
    // -----------------------------------------------------------------------

    // -----------------------------------------------------------------------
    // Inner / outer wiring (filesystem-touching helpers stay here)
    // -----------------------------------------------------------------------

    private static Dictionary<string, string> DiscoverInnerFromDir(JsonObject outerSchema, string schemaDir)
    {
        if (!Directory.Exists(schemaDir))
            throw new InvalidOperationException($"--schema-dir is not a directory: {schemaDir}");

        var categories = (outerSchema["config"] as JsonObject)?["contentCategories"] as JsonObject ?? new JsonObject();
        var aliases = new List<string>();
        foreach (var (_, catEntry) in categories)
        {
            if (catEntry is not JsonObject entry) continue;
            var alias = entry["analyzerId"]?.GetValue<string?>();
            if (alias is null || alias.StartsWith("prebuilt-", StringComparison.Ordinal))
                continue;
            aliases.Add(alias);
        }

        var jsonFiles = Directory.EnumerateFiles(schemaDir, "*.json")
            .OrderBy(p => p, StringComparer.Ordinal)
            .ToList();

        var resolved = new Dictionary<string, string>(StringComparer.Ordinal);
        var missing = new List<string>();
        foreach (var alias in aliases)
        {
            var matches = jsonFiles
                .Where(p =>
                {
                    var stem = Path.GetFileNameWithoutExtension(p);
                    return stem == alias || stem.StartsWith($"{alias}_", StringComparison.Ordinal);
                })
                .ToList();
            if (matches.Count == 0)
            {
                missing.Add(alias);
                continue;
            }
            resolved[alias] = matches[^1]; // alphabetically last = newest version
        }

        if (missing.Count > 0)
        {
            throw new InvalidOperationException(
                $"--schema-dir could not resolve inner schemas for: [{string.Join(", ", missing)}]. " +
                $"Looked in {schemaDir} for files named <alias>.json or <alias>_*.json.");
        }
        return resolved;
    }

    private static (JsonObject? Outer, Dictionary<string, JsonObject> Inner, bool Failed)
        ValidateAll(string outerSchemaPath, Dictionary<string, string> innerPaths)
    {
        var failures = new List<string>();

        var outerRes = SchemaValidator.ValidateFile(outerSchemaPath);
        if (!outerRes.Ok)
            failures.AddRange(outerRes.Errors.Select(e => $"[outer] {e}"));

        var innerSchemas = new Dictionary<string, JsonObject>(StringComparer.Ordinal);
        foreach (var (alias, path) in innerPaths)
        {
            if (!File.Exists(path))
            {
                failures.Add($"[inner:{alias}] schema file not found: {path}");
                continue;
            }
            var res = SchemaValidator.ValidateFile(path);
            if (!res.Ok)
            {
                failures.AddRange(res.Errors.Select(e => $"[inner:{alias}] {e}"));
                continue;
            }
            try
            {
                var node = JsonNode.Parse(File.ReadAllText(path))!.AsObject();
                innerSchemas[alias] = CreateAndTestCommand.StripComments(node)!.AsObject();
            }
            catch (Exception ex)
            {
                failures.Add($"[inner:{alias}] parse failed: {ex.Message}");
            }
        }

        if (failures.Count > 0)
        {
            foreach (var line in failures)
                Console.Error.WriteLine($"[VALIDATE] {line}");
            return (null, innerSchemas, true);
        }

        var outerSchema = CreateAndTestCommand.StripComments(JsonNode.Parse(File.ReadAllText(outerSchemaPath))!.AsObject())!.AsObject();

        // Pre-flight: warn on inner schemas missing models.completion.
        foreach (var (alias, schema) in innerSchemas)
        {
            if (schema.ContainsKey("fieldSchema"))
            {
                var models = schema["models"] as JsonObject;
                var completion = models?["completion"]?.GetValue<string?>();
                if (string.IsNullOrEmpty(completion))
                {
                    Console.Error.WriteLine(
                        $"[WARN]    inner schema '{alias}' has fieldSchema but no models.completion; " +
                        "this will fail unless resource defaults are configured " +
                        "(see samples/sample_update_defaults.py).");
                }
            }
        }

        return (outerSchema, innerSchemas, false);
    }

    // -----------------------------------------------------------------------
    // CLI
    // -----------------------------------------------------------------------

    private readonly record struct Options(
        string OuterSchema,
        IReadOnlyList<string> InnerSchemaArgs,
        string? SchemaDir,
        string Input,
        string Output,
        string? AnalyzerId,
        bool Ephemeral,
        bool Reuse);

    private static Options? ParseArgs(string[] args)
    {
        string? outer = null, schemaDir = null, input = null, output = null, analyzerId = null;
        var innerArgs = new List<string>();
        bool ephemeral = false, reuse = false;

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--outer-schema" when i + 1 < args.Length: outer = args[++i]; break;
                case "--inner-schema" when i + 1 < args.Length: innerArgs.Add(args[++i]); break;
                case "--schema-dir" when i + 1 < args.Length: schemaDir = args[++i]; break;
                case "--input" when i + 1 < args.Length: input = args[++i]; break;
                case "--output" when i + 1 < args.Length: output = args[++i]; break;
                case "--analyzer-id" when i + 1 < args.Length: analyzerId = args[++i]; break;
                case "--ephemeral": ephemeral = true; break;
                case "--reuse": reuse = true; break;
                case "-h":
                case "--help":
                    PrintHelp(); return null;
                default:
                    Console.Error.WriteLine($"unknown argument: {args[i]}");
                    PrintHelp(); return null;
            }
        }

        if (outer is null || input is null || output is null)
        {
            Console.Error.WriteLine("--outer-schema, --input, and --output are required");
            PrintHelp();
            return null;
        }
        return new Options(outer, innerArgs, schemaDir, input, output, analyzerId, ephemeral, reuse);
    }

    private static void PrintHelp()
    {
        Console.Error.WriteLine("""
            Usage:
              cu-skill create-and-test-router
                --outer-schema <file>
                (--inner-schema ALIAS=PATH [--inner-schema ...] | --schema-dir <dir>)
                --input <file-or-folder>
                --output <dir>
                [--analyzer-id <id>]
                [--ephemeral]
                [--reuse]

            Classify-and-route Stage 2: validate, create N inner analyzers + 1
            outer classifier, batch-test, print a category-aware summary.
            """);
    }

    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
    };

    private static readonly JsonSerializerOptions WriteOptions = new()
    {
        WriteIndented = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };
}
