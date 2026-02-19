// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent;

/// <summary>
/// Service for reading and writing YAML configuration files with simple string operations.
/// </summary>
public sealed class FileService
{
    private readonly ILogger<FileService> _logger;
    private const char DoubleQuote = '"';
    private const char SingleQuote = '\'';
    private const string DirectoryFieldName = "directory:";

    /// <summary>
    /// Initializes a new instance of the <see cref="FileService"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    public FileService(ILogger<FileService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Reads the directory field value from tsp-location.yaml.
    /// </summary>
    /// <param name="tspLocationPath">Path to the tsp-location.yaml file.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The directory field value as string, or null if field doesn't exist.</returns>
    /// <exception cref="ArgumentException">Thrown when tspLocationPath is null or empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown when YAML parsing fails.</exception>
    public async Task<string?> ReadDirectoryFieldAsync(string tspLocationPath, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(tspLocationPath))
        {
            throw new ArgumentException("tsp-location.yaml path is required but was not provided", nameof(tspLocationPath));
        }

        _logger.LogDebug("Reading directory field from {FilePath}", tspLocationPath);

        try
        {
            var yamlContent = await File.ReadAllTextAsync(tspLocationPath, cancellationToken).ConfigureAwait(false);

            // Parse directory field directly using simple string search
            string? value = null;
            foreach (var rawLine in yamlContent.Split('\n'))
            {
                var line = rawLine.TrimEnd('\r');
                var trimmedLine = line.TrimStart();

                if (trimmedLine.StartsWith(DirectoryFieldName, StringComparison.Ordinal))
                {
                    var colonIndex = trimmedLine.IndexOf(':', StringComparison.Ordinal);
                    if (colonIndex >= 0 && colonIndex < trimmedLine.Length - 1)
                    {
                        var rawValue = trimmedLine[(colonIndex + 1)..].Trim();
                        value = RemoveYamlQuotes(rawValue);
                        break;
                    }
                }
            }

            _logger.LogDebug("Successfully read directory field with value: {Value}", value);
            return value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to read directory field from tsp-location.yaml at {FilePath}", tspLocationPath);
            throw new InvalidOperationException($"Failed to read tsp-location.yaml at {tspLocationPath}: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Writes/updates a field in tsp-location.yaml.
    /// </summary>
    /// <param name="tspLocationPath">Path to the tsp-location.yaml file.</param>
    /// <param name="field">The field name to write.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <exception cref="ArgumentException">Thrown when tspLocationPath, field, or value is null or empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown when YAML parsing or writing fails.</exception>
    public async Task WriteFieldAsync(string tspLocationPath, string field, string value, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(tspLocationPath))
        {
            throw new ArgumentException("tsp-location.yaml path is required but was not provided", nameof(tspLocationPath));
        }

        if (string.IsNullOrEmpty(field))
        {
            throw new ArgumentException("Field name is required but was not provided", nameof(field));
        }

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Field value is required but was not provided", nameof(value));
        }

        _logger.LogDebug("Writing field {Field} with value {Value} to {FilePath}", field, value, tspLocationPath);

        try
        {
            var yamlContent = await File.ReadAllTextAsync(tspLocationPath, cancellationToken).ConfigureAwait(false);

            var updatedYaml = UpdateYamlField(yamlContent, field, value);

            await File.WriteAllTextAsync(tspLocationPath, updatedYaml, cancellationToken).ConfigureAwait(false);

            _logger.LogInformation("Successfully updated field {Field} to {NewValue} in {FilePath}",
                field, value, tspLocationPath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to write field {Field} to tsp-location.yaml at {FilePath}", field, tspLocationPath);
            throw new InvalidOperationException($"Failed to write tsp-location.yaml at {tspLocationPath}: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Updates a YAML field using span operations to minimize allocations.
    /// </summary>
    /// <param name="yamlContent">Original YAML content.</param>
    /// <param name="field">Field to update.</param>
    /// <param name="newValue">New value.</param>
    /// <returns>Updated YAML content.</returns>
    private static string UpdateYamlField(string yamlContent, string field, string newValue)
    {
        var yamlSpan = yamlContent.AsSpan();
        var fieldPattern = $"{field}:".AsSpan();

        var result = new System.Text.StringBuilder(yamlContent.Length + field.Length + newValue.Length + 16);
        var currentPos = 0;
        var fieldUpdated = false;

        while (currentPos < yamlSpan.Length)
        {
            var lineEnd = yamlSpan[currentPos..].IndexOf('\n');
            var line = lineEnd == -1
                ? yamlSpan[currentPos..]
                : yamlSpan.Slice(currentPos, lineEnd);

            var cleanLine = line.TrimEnd('\r');
            var trimmedLine = cleanLine.TrimStart();

            if (!fieldUpdated && !trimmedLine.IsEmpty && trimmedLine.StartsWith(fieldPattern, StringComparison.Ordinal))
            {
                var indentLength = cleanLine.Length - trimmedLine.Length;
                if (indentLength > 0)
                {
                    result.Append(cleanLine[..indentLength]);
                }
                result.Append($"{field}: {newValue}");
                fieldUpdated = true;
            }
            else
            {
                result.Append(cleanLine);
            }

            if (lineEnd != -1)
            {
                result.Append('\n');
                currentPos += lineEnd + 1;
            }
            else
            {
                break;
            }
        }

        if (!fieldUpdated)
        {
            if (result.Length > 0 && result[^1] != '\n')
            {
                result.Append('\n');
            }
            result.Append($"{field}: {newValue}\n");
        }

        if (yamlContent.Contains("\r\n"))
        {
            result.Replace("\n", "\r\n");
        }

        return result.ToString();
    }

    /// <summary>
    /// Removes YAML quotes from a value if present.
    /// </summary>
    /// <param name="value">Value potentially with quotes.</param>
    /// <returns>Value without quotes, or original if no quotes or empty.</returns>
    private static string? RemoveYamlQuotes(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        if (value.Length < 2)
        {
            return value;
        }

        var span = value.AsSpan();

        if ((span[0] == DoubleQuote && span[^1] == DoubleQuote) ||
            (span[0] == SingleQuote && span[^1] == SingleQuote))
        {
            return span.Length == 2 ? string.Empty : span[1..^1].ToString();
        }

        return value;
    }
}
