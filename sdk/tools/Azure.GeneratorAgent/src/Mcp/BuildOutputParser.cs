// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.GeneratorAgent.Mcp;

/// <summary>
/// Parses MSBuild output into structured <see cref="BuildError"/> objects.
/// </summary>
public static class BuildOutputParser
{
    // Matches MSBuild error/warning format:
    // path(line,col): error CS1234: message
    // Also handles 3+ letter codes like AZC0002, MSB3492, NU1234
    private static readonly Regex s_msbuildErrorRegex = new(
        @"^(?<file>[^(]+)\((?<line>\d+),(?<col>\d+)\):\s+(?<severity>error|warning)\s+(?<code>[A-Z]{2,}\d+):\s+(?<message>.+)$",
        RegexOptions.Compiled | RegexOptions.Multiline);

    // Matches simpler MSBuild format without column:
    // path(line): error CS1234: message
    private static readonly Regex s_msbuildErrorNoColRegex = new(
        @"^(?<file>[^(]+)\((?<line>\d+)\):\s+(?<severity>error|warning)\s+(?<code>[A-Z]{2,}\d+):\s+(?<message>.+)$",
        RegexOptions.Compiled | RegexOptions.Multiline);

    // Matches project-level errors:
    // error CS1234: message
    private static readonly Regex s_projectLevelErrorRegex = new(
        @"^\s*(?<severity>error|warning)\s+(?<code>[A-Z]{2,}\d+):\s+(?<message>.+)$",
        RegexOptions.Compiled | RegexOptions.Multiline);

    private static readonly Regex s_generatedPathRegex = new(
        @"[/\\]Generated[/\\]",
        RegexOptions.Compiled);

    /// <summary>
    /// Parses raw MSBuild output into a list of <see cref="BuildError"/> objects.
    /// </summary>
    /// <param name="buildOutput">The raw MSBuild console output.</param>
    /// <returns>List of parsed build errors.</returns>
    public static List<BuildError> Parse(string buildOutput)
    {
        if (string.IsNullOrWhiteSpace(buildOutput))
        {
            return [];
        }

        var errors = new List<BuildError>();
        var seen = new HashSet<string>(StringComparer.Ordinal);

        foreach (Match match in s_msbuildErrorRegex.Matches(buildOutput))
        {
            var error = CreateError(
                match.Groups["file"].Value.Trim(),
                match.Groups["line"].Value,
                match.Groups["col"].Value,
                match.Groups["code"].Value,
                match.Groups["message"].Value.Trim(),
                match.Groups["severity"].Value);

            var key = $"{error.FilePath}:{error.Line}:{error.Code}";
            if (seen.Add(key))
            {
                errors.Add(error);
            }
        }

        foreach (Match match in s_msbuildErrorNoColRegex.Matches(buildOutput))
        {
            var error = CreateError(
                match.Groups["file"].Value.Trim(),
                match.Groups["line"].Value,
                "0",
                match.Groups["code"].Value,
                match.Groups["message"].Value.Trim(),
                match.Groups["severity"].Value);

            var key = $"{error.FilePath}:{error.Line}:{error.Code}";
            if (seen.Add(key))
            {
                errors.Add(error);
            }
        }

        foreach (Match match in s_projectLevelErrorRegex.Matches(buildOutput))
        {
            var code = match.Groups["code"].Value;
            var message = match.Groups["message"].Value.Trim();
            var key = $":::{code}:{message}";
            if (seen.Add(key))
            {
                errors.Add(CreateError(
                    string.Empty, "0", "0", code, message,
                    match.Groups["severity"].Value));
            }
        }

        return errors;
    }

    /// <summary>
    /// Determines whether the build output indicates a successful build.
    /// </summary>
    public static bool IsSuccess(string buildOutput)
    {
        if (string.IsNullOrWhiteSpace(buildOutput))
        {
            return false;
        }

        return buildOutput.Contains("Build succeeded", StringComparison.OrdinalIgnoreCase)
            && !buildOutput.Contains(": error ", StringComparison.OrdinalIgnoreCase);
    }

    private static BuildError CreateError(string file, string line, string col, string code, string message, string severity)
    {
        return new BuildError
        {
            FilePath = file,
            Line = int.TryParse(line, out var l) ? l : 0,
            Column = int.TryParse(col, out var c) ? c : 0,
            Code = code,
            Message = message,
            Severity = severity,
            IsGenerated = !string.IsNullOrEmpty(file) && s_generatedPathRegex.IsMatch(file)
        };
    }
}
