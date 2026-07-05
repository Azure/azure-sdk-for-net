// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Structured test execution result.
/// </summary>
public sealed class TestResult
{
    public bool Success { get; set; }
    public int ExitCode { get; set; }
    public int Passed { get; set; }
    public int Failed { get; set; }
    public int Skipped { get; set; }
    public int Total { get; set; }
    public List<string> Failures { get; set; } = [];
    public string? Error { get; set; }
    public string RawOutput { get; set; } = string.Empty;
}
