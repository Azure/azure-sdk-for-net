// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Stage 2 (single-type): validate schema, create analyzer, batch-test, summarize.
// Mirrors Python's create_and_test.py.

using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;

namespace AzureSdkContentUnderstanding.Skills;

internal static partial class CreateAndTestCommand
{
    private static readonly HashSet<string> SupportedSuffixes = new(StringComparer.OrdinalIgnoreCase)
    {
        ".pdf", ".png", ".jpg", ".jpeg", ".tiff", ".tif", ".bmp", ".heif",
        ".mp4", ".mov", ".wav", ".mp3", ".m4a",
    };

    public static async Task<int> RunAsync(string[] args)
    {
        var parsed = ParseArgs(args);
        if (parsed is null) return 2;
        var opts = parsed.Value;

        if (!File.Exists(opts.Schema))
        {
            Console.Error.WriteLine($"schema not found: {opts.Schema}");
            return 2;
        }
        if (!File.Exists(opts.Input) && !Directory.Exists(opts.Input))
        {
            Console.Error.WriteLine($"input not found: {opts.Input}");
            return 2;
        }
        if (opts.Iterations < 1)
        {
            Console.Error.WriteLine("--iterations must be >= 1");
            return 2;
        }

        return await RunCoreAsync(opts).ConfigureAwait(false);
    }

    internal static async Task<int> RunCoreAsync(Options opts)
    {
        // 1. Validate schema locally.
        var validation = SchemaValidator.ValidateFile(opts.Schema);
        if (!validation.Ok)
        {
            foreach (var e in validation.Errors)
                Console.Error.WriteLine($"[VALIDATE] {e}");
            return 2;
        }

        var rawJson = await File.ReadAllTextAsync(opts.Schema).ConfigureAwait(false);
        var rawSchema = JsonNode.Parse(rawJson)!.AsObject();
        var schema = StripComments(rawSchema)!.AsObject();

        // Pre-flight warning: fieldSchema without models.completion.
        if (schema.ContainsKey("fieldSchema"))
        {
            var models = schema["models"] as JsonObject;
            var completion = models?["completion"]?.GetValue<string?>();
            if (string.IsNullOrEmpty(completion))
            {
                Console.Error.WriteLine(
                    "[WARN]   schema has fieldSchema but no models.completion; " +
                    "this will fail unless resource defaults are configured " +
                    "(see samples/sample_update_defaults.py).");
            }
        }

        var inputs = EnumerateInputs(opts.Input).ToList();
        if (inputs.Count == 0)
        {
            Console.Error.WriteLine($"no supported documents found under {opts.Input}");
            return 2;
        }

        Directory.CreateDirectory(opts.Output);

        var analyzerId = opts.AnalyzerId;
        if (string.IsNullOrEmpty(analyzerId))
        {
            var stem = Path.GetFileNameWithoutExtension(opts.Schema);
            analyzerId = opts.Reuse
                ? $"{stem}_{SchemaHash(schema)}"
                : $"{stem}_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
        }

        var client = BuildClient();

        bool reused = false;
        int fail = 0;
        var results = new List<(string DocName, JsonObject Doc)>();

        try
        {
            if (opts.Reuse)
                reused = await EnsureAnalyzerAsync(client, analyzerId, schema).ConfigureAwait(false);
            else
                await CreateAnalyzerAsync(client, analyzerId, schema).ConfigureAwait(false);

            foreach (var filePath in inputs)
            {
                for (int iter = 1; iter <= opts.Iterations; iter++)
                {
                    var suffix = opts.Iterations > 1 ? $"_iter{iter:D3}" : string.Empty;
                    var stem = Path.GetFileNameWithoutExtension(filePath);
                    var outPath = Path.Combine(opts.Output, $"{stem}{suffix}.json");
                    try
                    {
                        Console.WriteLine($"[ANALYZE] {filePath} → {outPath}");
                        var (doc, llmText) = await AnalyzeFileAsync(client, analyzerId, filePath).ConfigureAwait(false);
                        await File.WriteAllTextAsync(outPath, doc.ToJsonString(WriteOptions)).ConfigureAwait(false);
                        if (!string.IsNullOrEmpty(llmText))
                        {
                            var llmPath = Path.ChangeExtension(outPath, ".llm.md");
                            await File.WriteAllTextAsync(llmPath, llmText).ConfigureAwait(false);
                        }
                        results.Add((Path.GetFileNameWithoutExtension(outPath), doc));
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"[FAIL]   {filePath}: {ex.Message}");
                        fail++;
                    }
                }
            }
        }
        finally
        {
            if (opts.Ephemeral)
            {
                try
                {
                    Console.WriteLine($"[CLEANUP] delete analyzer {analyzerId}");
                    await client.DeleteAnalyzerAsync(analyzerId).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"[CLEANUP] delete failed: {ex.Message}");
                }
            }
            else if (reused)
            {
                Console.WriteLine($"[KEEP]    reused analyzer {analyzerId} retained");
            }
            else
            {
                Console.WriteLine($"[KEEP]    analyzer {analyzerId} retained (use --ephemeral to delete)");
            }
        }

        Console.WriteLine(Summarize(results));
        return fail == 0 ? 0 : 1;
    }

    // -----------------------------------------------------------------------
    // Service interaction
    // -----------------------------------------------------------------------

    internal static ContentUnderstandingClient BuildClient()
    {
        var endpoint = ReadEnv("CONTENTUNDERSTANDING_ENDPOINT");
        if (string.IsNullOrWhiteSpace(endpoint))
        {
            throw new InvalidOperationException(
                "CONTENTUNDERSTANDING_ENDPOINT is not set. Configure your .env file (see cu-sdk-setup).");
        }
        endpoint = endpoint.TrimEnd('/');
        var key = ReadEnv("CONTENTUNDERSTANDING_KEY");
        if (!string.IsNullOrWhiteSpace(key))
        {
            return new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(key));
        }
        var options = new DefaultAzureCredentialOptions
        {
            ExcludeManagedIdentityCredential = true,
            ExcludeWorkloadIdentityCredential = true,
        };
        TokenCredential credential = new DefaultAzureCredential(options);
        return new ContentUnderstandingClient(new Uri(endpoint), credential);
    }

    private static string? ReadEnv(string name)
    {
        var value = Environment.GetEnvironmentVariable(name);
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }
        if (value.Length >= 2 &&
            ((value[0] == '"' && value[^1] == '"') ||
             (value[0] == '\'' && value[^1] == '\'')))
        {
            return value.Substring(1, value.Length - 2);
        }
        return value;
    }

    internal static async Task CreateAnalyzerAsync(
        ContentUnderstandingClient client, string analyzerId, JsonObject schema)
    {
        Console.WriteLine($"[CREATE] analyzer_id={analyzerId}");
        // Use the protocol overload so we can pass arbitrary schema JSON
        // (the typed ContentAnalyzer model might not expose every property).
        var content = RequestContent.Create(BinaryData.FromString(schema.ToJsonString()));
        var op = await client.CreateAnalyzerAsync(WaitUntil.Completed, analyzerId, content).ConfigureAwait(false);
        // Block on response so any service error surfaces here, not at first analyze call.
        _ = op.GetRawResponse();
        Console.WriteLine($"[CREATE] {analyzerId} ready");
    }

    internal static async Task<bool> EnsureAnalyzerAsync(
        ContentUnderstandingClient client, string analyzerId, JsonObject schema)
    {
        try
        {
            await client.GetAnalyzerAsync(analyzerId).ConfigureAwait(false);
            Console.WriteLine($"[REUSE]  analyzer {analyzerId} already exists");
            return true;
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            // Not found — fall through.
        }
        await CreateAnalyzerAsync(client, analyzerId, schema).ConfigureAwait(false);
        return false;
    }

    private static async Task<(JsonObject Doc, string? LlmMarkdown)> AnalyzeFileAsync(
        ContentUnderstandingClient client, string analyzerId, string filePath)
    {
        var bytes = await File.ReadAllBytesAsync(filePath).ConfigureAwait(false);
        var data = BinaryData.FromBytes(bytes);
        var op = await client.AnalyzeBinaryAsync(WaitUntil.Completed, analyzerId, data).ConfigureAwait(false);

        // Read the raw service JSON instead of the typed model so the on-disk
        // shape is identical to what the Python skill writes (typed C# models
        // surface a single `value` property; the wire format uses
        // valueString/valueNumber/... which the summary code keys on).
        var rawJson = op.GetRawResponse().Content?.ToString();
        JsonObject json;
        if (!string.IsNullOrEmpty(rawJson))
        {
            var parsed = JsonNode.Parse(rawJson)!.AsObject();
            // Final LRO polling response wraps the result in `{id,status,result,usage}`.
            // Python's `poller.result()` returns just the inner result, so unwrap
            // here to keep the on-disk shape identical across SDKs.
            json = parsed["result"] is JsonObject inner ? (JsonObject)inner.DeepClone() : parsed;
        }
        else
        {
            // Fallback to typed serialization if the SDK ever stops surfacing
            // raw content (e.g. when the LRO final state is reconstructed).
            json = JsonSerializer.SerializeToNode(op.Value, SerializerOptions)!.AsObject();
        }

        string? llmText = null;
        try
        {
            llmText = op.Value.ToLlmInput();
        }
        catch
        {
            // Best-effort; raw JSON is always written.
        }
        return (json, llmText);
    }

    // -----------------------------------------------------------------------
    // Helpers
    // -----------------------------------------------------------------------

    internal static IEnumerable<string> EnumerateInputs(string inputPath)
    {
        if (File.Exists(inputPath))
        {
            yield return inputPath;
            yield break;
        }
        foreach (var p in Directory.EnumerateFiles(inputPath).OrderBy(s => s, StringComparer.Ordinal))
        {
            if (SupportedSuffixes.Contains(Path.GetExtension(p)))
                yield return p;
        }
    }

    internal static JsonNode? StripComments(JsonNode? node)
    {
        if (node is JsonObject obj)
        {
            var result = new JsonObject();
            foreach (var kv in obj)
            {
                if (kv.Key.StartsWith('_'))
                    continue;
                result[kv.Key] = StripComments(kv.Value?.DeepClone());
            }
            return result;
        }
        if (node is JsonArray arr)
        {
            var result = new JsonArray();
            foreach (var item in arr)
                result.Add(StripComments(item?.DeepClone()));
            return result;
        }
        return node?.DeepClone();
    }

    internal static string SchemaHash(JsonObject schema)
    {
        // Match Python's hashlib.sha1(json.dumps(schema, sort_keys=True))[:8].
        var canonical = JsonCanonicalizer.Canonicalize(schema);
        var bytes = SHA1.HashData(Encoding.UTF8.GetBytes(canonical));
        // Convert.ToHexStringLower is .NET 9+; do it by hand so this also
        // compiles on net8.0 (the repo-wide service.proj traversal exercises
        // multiple TFMs and we don't want the skill csproj to break those legs).
        var hex = Convert.ToHexString(bytes).ToLowerInvariant();
        return hex[..8];
    }

    // -----------------------------------------------------------------------
    // Summary
    // -----------------------------------------------------------------------
    // Pure helpers (Summarize, IterFields, Recurse, FieldValue, GetConfidence,
    // IsEmpty) live in CreateAndTestCommand.Helpers.cs — that source has no
    // Azure.* imports and is linked into the Azure.AI.ContentUnderstanding
    // test project so we can unit-test it without depending on cu-skill.csproj.
    // -----------------------------------------------------------------------

    // -----------------------------------------------------------------------
    // CLI parsing
    // -----------------------------------------------------------------------

    internal readonly record struct Options(
        string Schema,
        string Input,
        string Output,
        string? AnalyzerId,
        int Iterations,
        bool Ephemeral,
        bool Reuse);

    private static Options? ParseArgs(string[] args)
    {
        string? schema = null, input = null, output = null, analyzerId = null;
        int iterations = 1;
        bool ephemeral = false, reuse = false;

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--schema" when i + 1 < args.Length: schema = args[++i]; break;
                case "--input" when i + 1 < args.Length: input = args[++i]; break;
                case "--output" when i + 1 < args.Length: output = args[++i]; break;
                case "--analyzer-id" when i + 1 < args.Length: analyzerId = args[++i]; break;
                case "--iterations" when i + 1 < args.Length:
                    if (!int.TryParse(args[++i], NumberStyles.Integer, CultureInfo.InvariantCulture, out iterations))
                    {
                        Console.Error.WriteLine($"--iterations must be an integer");
                        return null;
                    }
                    break;
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

        if (schema is null || input is null || output is null)
        {
            Console.Error.WriteLine("--schema, --input, and --output are required");
            PrintHelp();
            return null;
        }
        return new Options(schema, input, output, analyzerId, iterations, ephemeral, reuse);
    }

    private static void PrintHelp()
    {
        Console.Error.WriteLine("""
            Usage:
              cu-skill create-and-test
                --schema <file>
                --input <file-or-folder>
                --output <dir>
                [--analyzer-id <id>]
                [--iterations N]
                [--ephemeral]
                [--reuse]

            Stage 2 of the cu-sdk-author-analyzer workflow.

            Exit codes:
              0 — every document analyzed successfully
              1 — at least one service-side failure
              2 — local user error (validation, missing files); no service call made
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

/// <summary>
/// Canonicalize a JSON document with sorted object keys, matching Python's
/// <c>json.dumps(obj, sort_keys=True)</c>. Used to produce stable hashes for
/// <c>--reuse</c> mode.
/// </summary>
internal static class JsonCanonicalizer
{
    public static string Canonicalize(JsonNode? node)
    {
        using var ms = new MemoryStream();
        using (var writer = new System.Text.Json.Utf8JsonWriter(ms, new System.Text.Json.JsonWriterOptions
        {
            Indented = false,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        }))
        {
            Write(writer, node);
        }
        return Encoding.UTF8.GetString(ms.ToArray());
    }

    private static void Write(System.Text.Json.Utf8JsonWriter writer, JsonNode? node)
    {
        switch (node)
        {
            case JsonObject obj:
                writer.WriteStartObject();
                foreach (var kv in obj.OrderBy(kv => kv.Key, StringComparer.Ordinal))
                {
                    writer.WritePropertyName(kv.Key);
                    Write(writer, kv.Value);
                }
                writer.WriteEndObject();
                break;
            case JsonArray arr:
                writer.WriteStartArray();
                foreach (var item in arr) Write(writer, item);
                writer.WriteEndArray();
                break;
            case JsonValue val:
                val.WriteTo(writer);
                break;
            case null:
                writer.WriteNullValue();
                break;
        }
    }
}
