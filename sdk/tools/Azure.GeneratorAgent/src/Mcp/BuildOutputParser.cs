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

    // Matches MSBuild errors without an error code (e.g., ApiCompat errors):
    // path(line,col): error : CannotSealType : Type 'Foo' is effectively sealed...
    // The code is extracted from the leading word of the message (e.g., "CannotSealType").
    private static readonly Regex s_msbuildCodelessErrorRegex = new(
        @"^(?<file>[^(]+)\((?<line>\d+),(?<col>\d+)\):\s+(?<severity>error|warning)\s+:\s+(?<message>.+)$",
        RegexOptions.Compiled | RegexOptions.Multiline);

    // Extracts the ApiCompat rule name from the message.
    // e.g., "CannotRemoveAttribute : Attribute '...' ..." → "CannotRemoveAttribute"
    private static readonly Regex s_apiCompatRuleRegex = new(
        @"^(?<rule>Cannot\w+|MembersMustExist|TypesMustExist|InterfacesShouldHaveSameMembers)\s+:",
        RegexOptions.Compiled);

    // Matches file-level or tool-prefixed errors without line/col:
    // C:\project.csproj : error NU1100: Unable to resolve 'X' for 'net8.0'.
    // MSBUILD : error MSB1009: Project file does not exist.
    private static readonly Regex s_fileLevelErrorRegex = new(
        @"^(?<file>[^\r\n]*?)\s+:\s+(?<severity>error|warning)\s+(?<code>[A-Z]{2,}\d+)\s*:\s+(?<message>.+)$",
        RegexOptions.Compiled | RegexOptions.Multiline);

    // Matches codeless project-level errors (no file, no error code):
    // error : Unable to find package 'X'. No packages exist with this id in source(s): nuget.org
    private static readonly Regex s_codelessProjectLevelErrorRegex = new(
        @"^\s*(?<severity>error|warning)\s+:\s+(?<message>.+)$",
        RegexOptions.Compiled | RegexOptions.Multiline);

    // Strips the trailing MSBuild project reference from error messages.
    // e.g., "... [C:\src\project.csproj::TargetFramework=netstandard2.0]" → "..."
    private static readonly Regex s_trailingProjectRefRegex = new(
        @"\s*\[[^\]]*\.csproj[^\]]*\]\s*$",
        RegexOptions.Compiled);

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

        // ApiCompat / codeless errors: "path(line,col): error : Message"
        foreach (Match match in s_msbuildCodelessErrorRegex.Matches(buildOutput))
        {
            var rawMessage = match.Groups["message"].Value.Trim();
            // Strip project ref before extracting code (CreateError also strips, but code extraction needs clean message)
            var message = s_trailingProjectRefRegex.Replace(rawMessage, string.Empty);
            var code = ExtractErrorCode(message);
            var error = CreateError(
                match.Groups["file"].Value.Trim(),
                match.Groups["line"].Value,
                match.Groups["col"].Value,
                code,
                message,
                match.Groups["severity"].Value);

            var key = $"{error.FilePath}:{error.Line}:{error.Code}:{error.Message}";
            if (seen.Add(key))
            {
                errors.Add(error);
            }
        }

        // File-level errors (no line/col): "file : error CODE: message" or "TOOL : error CODE: message"
        foreach (Match match in s_fileLevelErrorRegex.Matches(buildOutput))
        {
            var error = CreateError(
                match.Groups["file"].Value.Trim(),
                "0", "0",
                match.Groups["code"].Value,
                match.Groups["message"].Value.Trim(),
                match.Groups["severity"].Value);

            var key = $"{error.FilePath}:0:{error.Code}:{error.Message}";
            if (seen.Add(key))
            {
                errors.Add(error);
            }
        }

        // Codeless project-level errors: "error : message" (no file, no error code)
        foreach (Match match in s_codelessProjectLevelErrorRegex.Matches(buildOutput))
        {
            var rawMessage = match.Groups["message"].Value.Trim();
            var message = s_trailingProjectRefRegex.Replace(rawMessage, string.Empty);
            var code = ExtractErrorCode(message, "BUILD");
            var error = CreateError(
                string.Empty, "0", "0", code, message,
                match.Groups["severity"].Value);

            var key = $":::{error.Code}:{error.Message}";
            if (seen.Add(key))
            {
                errors.Add(error);
            }
        }

        return errors;
    }

    private static BuildError CreateError(string file, string line, string col, string code, string message, string severity)
    {
        return new BuildError
        {
            FilePath = file,
            Line = int.TryParse(line, out var l) ? l : 0,
            Column = int.TryParse(col, out var c) ? c : 0,
            Code = code,
            Message = s_trailingProjectRefRegex.Replace(message, string.Empty),
            Severity = severity,
            IsGenerated = !string.IsNullOrEmpty(file) && s_generatedPathRegex.IsMatch(file)
        };
    }

    /// <summary>
    /// Extracts an error code from a codeless error message.
    /// For ApiCompat errors, returns the rule name (e.g., "CannotRemoveAttribute").
    /// For other codeless errors, returns the <paramref name="fallbackCode"/>.
    /// </summary>
    private static string ExtractErrorCode(string message, string fallbackCode = "ApiCompat")
    {
        var match = s_apiCompatRuleRegex.Match(message);
        return match.Success ? match.Groups["rule"].Value : fallbackCode;
    }
}
