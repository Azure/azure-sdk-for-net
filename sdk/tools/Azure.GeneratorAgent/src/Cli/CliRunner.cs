// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.GeneratorAgent.Cli;

/// <summary>
/// Front-end for the <c>generate-and-fix</c> CLI subcommand.
/// Parses arguments, runs <see cref="GenerateAndFixOrchestrator"/>, prints a JSON
/// summary to <paramref name="stdout"/>, progress to <paramref name="stderr"/>, and
/// returns an exit code mapped from <see cref="GenerateAndFixExitReason"/>.
/// </summary>
public static class CliRunner
{
    private static readonly JsonSerializerOptions s_jsonOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never,
    };

    /// <summary>
    /// Entry point for CLI mode. <paramref name="args"/> is the full argv (i.e., the
    /// subcommand is at index 0).
    /// </summary>
    public static async Task<int> RunAsync(
        string[] args,
        TextWriter stdout,
        TextWriter stderr,
        IOrchestratorSteps? steps = null,
        CancellationToken cancellationToken = default)
    {
        if (args.Length == 0)
        {
            PrintUsage(stderr);
            return (int)GenerateAndFixExitReason.UsageError;
        }

        switch (args[0])
        {
            case "-h":
            case "--help":
            case "help":
                PrintUsage(stdout);
                return 0;

            case "generate-and-fix":
                return await RunGenerateAndFixAsync(args, stdout, stderr, steps, cancellationToken).ConfigureAwait(false);

            default:
                stderr.WriteLine($"Unknown command: {args[0]}");
                PrintUsage(stderr);
                return (int)GenerateAndFixExitReason.UsageError;
        }
    }

    private static async Task<int> RunGenerateAndFixAsync(
        string[] args,
        TextWriter stdout,
        TextWriter stderr,
        IOrchestratorSteps? steps,
        CancellationToken cancellationToken)
    {
        if (!TryParseGenerateAndFixOptions(args, stderr, out var options))
        {
            return (int)GenerateAndFixExitReason.UsageError;
        }

        var orchestrator = new GenerateAndFixOrchestrator(steps, msg => stderr.WriteLine(msg));

        GenerateAndFixResult result;
        try
        {
            result = await orchestrator.RunAsync(options, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            stderr.WriteLine("Cancelled.");
            return (int)GenerateAndFixExitReason.BuildFailed;
        }
        catch (Exception ex)
        {
            stderr.WriteLine($"Unhandled error: {ex}");
            return (int)GenerateAndFixExitReason.BuildFailed;
        }

        stdout.WriteLine(JsonSerializer.Serialize(result, s_jsonOptions));
        return (int)result.Reason;
    }

    /// <summary>
    /// Parses <c>--project</c>, <c>--specs-path</c>, <c>--max-iterations</c>, <c>--skip-generation</c>
    /// from <paramref name="args"/> (skipping <c>args[0]</c>, the subcommand name).
    /// </summary>
    internal static bool TryParseGenerateAndFixOptions(string[] args, TextWriter stderr, out GenerateAndFixOptions options)
    {
        string? project = null;
        string? specs = null;
        var maxIterations = 10;
        var skipGeneration = false;

        for (var i = 1; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--project":
                case "-p":
                    if (++i >= args.Length)
                    {
                        stderr.WriteLine("--project requires a value.");
                        options = new GenerateAndFixOptions();
                        return false;
                    }
                    project = args[i];
                    break;

                case "--specs-path":
                case "-s":
                    if (++i >= args.Length)
                    {
                        stderr.WriteLine("--specs-path requires a value.");
                        options = new GenerateAndFixOptions();
                        return false;
                    }
                    specs = args[i];
                    break;

                case "--max-iterations":
                    if (++i >= args.Length || !int.TryParse(args[i], out maxIterations) || maxIterations <= 0)
                    {
                        stderr.WriteLine("--max-iterations requires a positive integer.");
                        options = new GenerateAndFixOptions();
                        return false;
                    }
                    break;

                case "--skip-generation":
                    skipGeneration = true;
                    break;

                case "-h":
                case "--help":
                    PrintUsage(stderr);
                    options = new GenerateAndFixOptions();
                    return false;

                default:
                    stderr.WriteLine($"Unknown argument: {args[i]}");
                    options = new GenerateAndFixOptions();
                    return false;
            }
        }

        if (string.IsNullOrWhiteSpace(project))
        {
            stderr.WriteLine("--project is required.");
            options = new GenerateAndFixOptions();
            return false;
        }

        options = new GenerateAndFixOptions
        {
            ProjectPath = Path.GetFullPath(project),
            LocalSpecsPath = string.IsNullOrWhiteSpace(specs) ? null : Path.GetFullPath(specs),
            MaxIterations = maxIterations,
            SkipGeneration = skipGeneration,
        };
        return true;
    }

    private static void PrintUsage(TextWriter writer)
    {
        writer.WriteLine("Azure.GeneratorAgent CLI");
        writer.WriteLine();
        writer.WriteLine("Usage:");
        writer.WriteLine("  Azure.GeneratorAgent                       Run as MCP server over stdio (default).");
        writer.WriteLine("  Azure.GeneratorAgent mcp                   Same as default.");
        writer.WriteLine("  Azure.GeneratorAgent --mcp-server          Same as default.");
        writer.WriteLine("  Azure.GeneratorAgent generate-and-fix      Regenerate the project, then deterministically");
        writer.WriteLine("                                             fix build errors in custom (non-Generated/) code.");
        writer.WriteLine();
        writer.WriteLine("generate-and-fix options:");
        writer.WriteLine("  --project, -p <path>     Absolute path to the SDK project directory. Required.");
        writer.WriteLine("  --specs-path, -s <path>  Optional path to a local azure-rest-api-specs clone or spec dir.");
        writer.WriteLine("  --max-iterations <N>     Max build → fix iterations. Default: 10.");
        writer.WriteLine("  --skip-generation        Skip code generation; only run the build–fix loop.");
        writer.WriteLine("  --help, -h               Show this help.");
        writer.WriteLine();
        writer.WriteLine("Output:");
        writer.WriteLine("  Progress lines are written to stderr.");
        writer.WriteLine("  A JSON summary is written to stdout when generate-and-fix completes.");
        writer.WriteLine();
        writer.WriteLine("Exit codes:");
        writer.WriteLine("  0  Build is clean and Generated/ is unchanged.");
        writer.WriteLine("  1  Build still has errors after the fix loop, or non-deterministic errors remain.");
        writer.WriteLine("  2  Code generation failed.");
        writer.WriteLine("  3  Files in Generated/ were modified during the fix loop and could not be reverted.");
        writer.WriteLine("  4  Invalid arguments / usage error.");
    }
}
