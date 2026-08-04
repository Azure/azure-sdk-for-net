// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Stage 1 of the analyzer-authoring loop: extract document layout into
// <file>.layout.{json,md} files. Mirrors Python's extract_layout.py.

using System.Text.Json;
using System.Text.Json.Nodes;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;

namespace AzureSdkContentUnderstanding.Skills;

internal static class ExtractLayoutCommand
{
    private static readonly HashSet<string> SupportedSuffixes = new(StringComparer.OrdinalIgnoreCase)
    {
        ".pdf", ".png", ".jpg", ".jpeg", ".tiff", ".tif", ".bmp", ".heif",
    };

    public static async Task<int> RunAsync(string[] args)
    {
        var parsed = ParseArgs(args);
        if (parsed is null) return 2;
        var (input, output, analyzerId) = parsed.Value;

        if (!File.Exists(input) && !Directory.Exists(input))
        {
            Console.Error.WriteLine($"input does not exist: {input}");
            return 2;
        }

        var inputs = EnumerateInputs(input).ToList();
        if (inputs.Count == 0)
        {
            Console.Error.WriteLine(
                $"no supported documents found under {input} (supported: {string.Join(", ", SupportedSuffixes)})");
            return 2;
        }

        Directory.CreateDirectory(output);
        var client = BuildClient();
        var (ok, fail) = await ExtractLayoutAsync(inputs, output, client, analyzerId).ConfigureAwait(false);

        Console.WriteLine();
        Console.WriteLine($"[DONE] {ok} ok, {fail} failed; output → {output}");
        return fail == 0 ? 0 : 1;
    }

    private static IEnumerable<string> EnumerateInputs(string inputPath)
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

    private static async Task<(int Ok, int Fail)> ExtractLayoutAsync(
        IReadOnlyList<string> inputs,
        string outputDir,
        ContentUnderstandingClient client,
        string analyzerId)
    {
        int ok = 0, fail = 0;

        foreach (var filePath in inputs)
        {
            var stem = Path.GetFileNameWithoutExtension(filePath);
            try
            {
                Console.WriteLine($"[RUN ] {filePath} → {outputDir}/{stem}.layout.{{json,md}}");
                var bytes = await File.ReadAllBytesAsync(filePath).ConfigureAwait(false);
                var data = BinaryData.FromBytes(bytes);
                var op = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    data).ConfigureAwait(false);

                // Prefer the raw service JSON so the on-disk shape matches the
                // Python skill (valueString/valueNumber/... rather than the
                // typed `value` property the C# model exposes). Unwrap the LRO
                // envelope `{id,status,result,usage}` so we save just the
                // analysis result, mirroring `poller.result()` in Python.
                var rawJson = op.GetRawResponse().Content?.ToString();
                string json;
                if (!string.IsNullOrEmpty(rawJson))
                {
                    var parsed = JsonNode.Parse(rawJson);
                    var inner = parsed is JsonObject parsedObj && parsedObj["result"] is JsonObject innerObj
                        ? innerObj
                        : parsed;
                    json = inner!.ToJsonString(new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    });
                }
                else
                {
                    json = SerializeResult(op.Value);
                }
                await File.WriteAllTextAsync(
                    Path.Combine(outputDir, $"{stem}.layout.json"),
                    json).ConfigureAwait(false);

                var markdown = ExtractMarkdown(op.Value) ?? string.Empty;
                await File.WriteAllTextAsync(
                    Path.Combine(outputDir, $"{stem}.layout.md"),
                    markdown).ConfigureAwait(false);
                ok++;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[FAIL] {filePath}: {ex.Message}");
                fail++;
            }
        }

        return (ok, fail);
    }

    private static ContentUnderstandingClient BuildClient()
    {
        var endpoint = ReadEnv("CONTENTUNDERSTANDING_ENDPOINT");
        if (string.IsNullOrWhiteSpace(endpoint))
        {
            throw new InvalidOperationException(
                "CONTENTUNDERSTANDING_ENDPOINT is not set. Configure your .env file (see cu-sdk-setup).");
        }
        // Strip trailing slash to match the convention from samples — avoids
        // double-slash URLs when the env var was copy-pasted from the portal.
        endpoint = endpoint.TrimEnd('/');

        var key = ReadEnv("CONTENTUNDERSTANDING_KEY");
        if (!string.IsNullOrWhiteSpace(key))
        {
            return new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(key));
        }
        // Exclude Managed-Identity / Workload-Identity to skip the slow IMDS
        // probe on dev boxes (CI/cloud environments set AZURE_TOKEN_CREDENTIALS
        // explicitly so the chain there is still correct).
        var options = new DefaultAzureCredentialOptions
        {
            ExcludeManagedIdentityCredential = true,
            ExcludeWorkloadIdentityCredential = true,
        };
        TokenCredential credential = new DefaultAzureCredential(options);
        return new ContentUnderstandingClient(new Uri(endpoint), credential);
    }

    // Reads an env var and strips one layer of surrounding single or double
    // quotes — `python-dotenv` strips them by default but raw `export` from a
    // shell does not, so users who source .env manually still get a clean value.
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

    private static string SerializeResult(AnalysisResult result)
    {
        // SDK models are POCOs; System.Text.Json handles them natively.
        return JsonSerializer.Serialize(
            result,
            new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            });
    }

    private static string? ExtractMarkdown(AnalysisResult result)
    {
        foreach (var content in result.Contents ?? Array.Empty<AnalysisContent>())
        {
            if (!string.IsNullOrEmpty(content.Markdown))
            {
                return content.Markdown;
            }
        }
        return null;
    }

    private static (string Input, string Output, string AnalyzerId)? ParseArgs(string[] args)
    {
        string? input = null;
        string? output = null;
        string analyzerId = "prebuilt-documentSearch";

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--input" when i + 1 < args.Length:
                    input = args[++i]; break;
                case "--output" when i + 1 < args.Length:
                    output = args[++i]; break;
                case "--analyzer-id" when i + 1 < args.Length:
                    analyzerId = args[++i]; break;
                case "-h":
                case "--help":
                    PrintHelp();
                    return null;
                default:
                    Console.Error.WriteLine($"unknown argument: {args[i]}");
                    PrintHelp();
                    return null;
            }
        }

        if (input is null || output is null)
        {
            Console.Error.WriteLine("--input and --output are required");
            PrintHelp();
            return null;
        }
        return (input, output, analyzerId);
    }

    private static void PrintHelp()
    {
        Console.Error.WriteLine("""
            Usage:
              cu-skill extract-layout --input <file-or-folder> --output <dir>
                                      [--analyzer-id prebuilt-documentSearch]

            Stage 1 of the cu-sdk-author-analyzer workflow. Extracts layout
            (.layout.json + .layout.md) for each input file.
            """);
    }
}
