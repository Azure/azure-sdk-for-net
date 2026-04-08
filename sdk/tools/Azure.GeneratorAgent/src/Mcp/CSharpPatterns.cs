// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.GeneratorAgent.Mcp;

/// <summary>
/// Shared compiled regex patterns for parsing C# source files.
/// </summary>
internal static class CSharpPatterns
{
    /// <summary>
    /// Matches a C# class declaration and captures the class name.
    /// Handles public/internal, static, and partial modifiers.
    /// </summary>
    public static readonly Regex ClassDeclaration = new(
        @"(?:public|internal)\s+(?:static\s+)?(?:partial\s+)?class\s+(?<className>\w+)",
        RegexOptions.Compiled);

    /// <summary>
    /// Truncates a string to the specified maximum length, appending an ellipsis indicator if truncated.
    /// </summary>
    public static string Truncate(string value, int maxLength)
    {
        return value.Length <= maxLength ? value : value[..maxLength] + "... (truncated)";
    }
}
