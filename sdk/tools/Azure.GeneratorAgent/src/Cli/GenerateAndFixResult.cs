// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.GeneratorAgent.Mcp;

namespace Azure.GeneratorAgent.Cli;

/// <summary>
/// Reason the orchestrator stopped. Drives the process exit code.
/// </summary>
public enum GenerateAndFixExitReason
{
    /// <summary>Build is clean and Generated/ is unchanged.</summary>
    Success = 0,

    /// <summary>Build still has errors after the fix loop, or non-deterministic errors remain.</summary>
    BuildFailed = 1,

    /// <summary>Code generation itself failed.</summary>
    GenerationFailed = 2,

    /// <summary>One or more files in Generated/ were modified during the fix loop.</summary>
    GeneratedViolation = 3,

    /// <summary>Invalid arguments / usage error. Set by the CLI front-end.</summary>
    UsageError = 4,
}

/// <summary>
/// Structured result of a <see cref="GenerateAndFixOrchestrator"/> run.
/// Serialized to stdout as the final CI artifact.
/// </summary>
public sealed class GenerateAndFixResult
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("exitReason")]
    public string ExitReason { get; set; } = nameof(GenerateAndFixExitReason.Success);

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonIgnore]
    public GenerateAndFixExitReason Reason { get; set; }

    [JsonPropertyName("iterations")]
    public int Iterations { get; set; }

    [JsonPropertyName("totalFixesApplied")]
    public int TotalFixesApplied { get; set; }

    [JsonPropertyName("fixesByTool")]
    public Dictionary<string, int> FixesByTool { get; set; } = new();

    /// <summary>
    /// Errors that remain after the loop ended. Empty when <see cref="Success"/> is true.
    /// </summary>
    [JsonPropertyName("remainingErrors")]
    public List<ClassifiedError> RemainingErrors { get; set; } = new();

    /// <summary>
    /// Files in <c>Generated/</c> that were modified during the loop.
    /// Populated only when <see cref="Reason"/> is <see cref="GenerateAndFixExitReason.GeneratedViolation"/>.
    /// </summary>
    [JsonPropertyName("generatedViolations")]
    public List<string> GeneratedViolations { get; set; } = new();

    /// <summary>
    /// Free-form human-readable summary message.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}
