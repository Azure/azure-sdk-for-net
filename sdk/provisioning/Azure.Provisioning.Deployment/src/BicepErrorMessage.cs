// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Represents an error or warning from an external Bicep processing tool.  The
/// <see cref="RawText"/> will always be present and the other members will
/// optionally be available if we are able to parse the message.
/// </summary>
public partial class BicepErrorMessage
{
    /// <summary>
    /// Gets the raw text of the Bicep tool message.
    /// </summary>
    public string RawText { get; private set; }

    /// <summary>
    /// Optional file path containing the error.  If this is not provided then
    /// defer to the <see cref="RawText"/>.
    /// </summary>
    public string? FilePath { get; private set; }

    /// <summary>
    /// Optional line number in <see cref="FilePath"/> containing the error.
    /// If this is not provided then defer to the <see cref="RawText"/>.
    /// </summary>
    public int? LineNumber { get; private set; }

    /// <summary>
    /// Optional column number in <see cref="FilePath"/> containing the error.
    /// If this is not provided then defer to the <see cref="RawText"/>.
    /// </summary>
    public int? ColumnNumber { get; private set; }
    public bool? IsError { get; private set; }

    /// <summary>
    /// Optional error code describing the error.  If this is not provided then
    /// defer to the <see cref="RawText"/>.
    /// </summary>
    public string? Code { get; private set; }

    /// <summary>
    /// Optional error message explaining the error.  If this is not provided
    /// then defer to the <see cref="RawText"/>.
    /// </summary>
    public string? Message { get; private set; }

    private static readonly Lazy<Regex> s_linterRegex =
        new(() => new Regex(
            @"^(?:(?:WARNING|ERROR): )?(?<file>.+?)\((?<line>\d+)\,(?<col>\d+)\) : (?<kind>Warning|Error) (?<code>[^:]+?): (?<message>.+)$",
            RegexOptions.Compiled));

    // Track whether we have parsed output can generate nice ToStrings
    // TODO: Would this type be easier to use if we expose this?
    private readonly bool _parsed;

    internal BicepErrorMessage(string text)
    {
        RawText = text;
        Match match = s_linterRegex.Value.Match(text);
        _parsed = match.Success;
        if (_parsed)
        {
            FilePath = match.Groups["file"].Value;
            LineNumber = int.Parse(match.Groups["line"].Value);
            ColumnNumber = int.Parse(match.Groups["col"].Value);
            IsError = match.Groups["kind"].Value == "Error";
            Code = match.Groups["code"].Value;
            Message = match.Groups["message"].Value;
        }
    }

    /// <inheritdoc/>
    public override string ToString() =>
        !_parsed ? RawText : $"{(IsError == true ? "Error" : "Warning")} {Code}: {FilePath}({LineNumber},{ColumnNumber}): {Message}";
}
