// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

// Pure-C# validator for Content Understanding analyzer schema JSON.
//
// Catches structural mistakes (missing keys, unknown baseAnalyzerId values,
// malformed contentCategories routes) BEFORE any call to the Content
// Understanding service. Failing fast here gives users an actionable error
// message and avoids a wasted service round-trip.
//
// Design rules (see about.md in this directory):
//   * No Azure.* SDK imports — pure System.Text.Json.
//   * No network calls.
//   * Self-contained — drop-in for any tool or test.
//
// Public surface:
//   * SchemaValidator.Validate(JsonElement)          — validate a parsed schema element
//   * SchemaValidator.ValidateFile(string)           — convenience wrapper that loads a JSON file
//   * SchemaValidator.KnownBaseAnalyzerIds           — allow-list of baseAnalyzerId values

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AzureSdkContentUnderstanding.Skills;

/// <summary>
/// Validation result: <see cref="Ok"/> is true when the schema is structurally
/// valid, <see cref="Errors"/> is the list of human-readable error messages.
/// </summary>
public readonly record struct ValidationResult(bool Ok, IReadOnlyList<string> Errors);

public static class SchemaValidator
{
    /// <summary>
    /// Valid <c>baseAnalyzerId</c> values for custom analyzers. Only modality-level
    /// prebuilts are accepted by the service for <c>baseAnalyzerId</c>; <c>*Search</c>
    /// variants and task-specific prebuilts (<c>prebuilt-invoice</c>, <c>prebuilt-receipt</c>)
    /// return <c>InvalidBaseAnalyzerId</c> if used here. See
    /// https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference#baseanalyzerid
    /// </summary>
    public static readonly IReadOnlySet<string> KnownBaseAnalyzerIds = new HashSet<string>
    {
        "prebuilt-document",
        "prebuilt-audio",
        "prebuilt-video",
        "prebuilt-image",
    };

    private static readonly HashSet<string> AllowedFieldTypes = new()
    {
        "string", "number", "integer", "boolean", "date", "time", "array", "object",
    };

    private static readonly HashSet<string> AllowedFieldMethods = new()
    {
        "extract", "generate", "classify",
    };

    /// <summary>Validate a parsed analyzer schema element.</summary>
    public static ValidationResult Validate(JsonElement schema)
    {
        var errors = new List<string>();

        if (schema.ValueKind != JsonValueKind.Object)
        {
            return new ValidationResult(false, new[] { "schema must be a JSON object at the top level" });
        }

        // baseAnalyzerId
        if (!schema.TryGetProperty("baseAnalyzerId", out var baseEl))
        {
            errors.Add("missing required key: baseAnalyzerId");
        }
        else if (baseEl.ValueKind != JsonValueKind.String)
        {
            errors.Add("baseAnalyzerId must be a string");
        }
        else
        {
            var baseValue = baseEl.GetString()!;
            if (!KnownBaseAnalyzerIds.Contains(baseValue))
            {
                var known = string.Join(", ", KnownBaseAnalyzerIds.OrderBy(s => s, StringComparer.Ordinal).Select(s => $"'{s}'"));
                errors.Add($"unknown baseAnalyzerId: '{baseValue}'. Known values: [{known}]");
            }
        }

        // config (optional, but if present must be an object)
        JsonElement? config = null;
        if (schema.TryGetProperty("config", out var configEl))
        {
            if (configEl.ValueKind != JsonValueKind.Object)
            {
                errors.Add("config, if present, must be an object");
                // Bail out: without a well-typed config we can't tell whether this is
                // a single-type or classify-and-route schema, and falling through
                // would emit a confusing cascade of "missing fieldSchema" errors
                // rooted in the same problem.
                return new ValidationResult(false, errors);
            }
            config = configEl;
        }

        var isClassifyRoute = config is { } cfg && cfg.TryGetProperty("contentCategories", out _);

        if (isClassifyRoute)
        {
            errors.AddRange(ValidateClassifyRoute(config!.Value));
            if (schema.TryGetProperty("fieldSchema", out _))
            {
                errors.Add(
                    "classify-and-route schemas should not declare fieldSchema at " +
                    "the top level; field extraction belongs in inner analyzers");
            }
        }
        else
        {
            errors.AddRange(ValidateSingleType(schema));
        }

        return new ValidationResult(errors.Count == 0, errors);
    }

    /// <summary>Validate a schema stored in a JSON file.</summary>
    public static ValidationResult ValidateFile(string path)
    {
        if (!File.Exists(path))
        {
            return new ValidationResult(false, new[] { $"schema file not found: {path}" });
        }

        string text;
        try
        {
            text = File.ReadAllText(path);
        }
        catch (IOException ex)
        {
            return new ValidationResult(false, new[] { $"failed to read schema file {path}: {ex.Message}" });
        }

        try
        {
            using var doc = JsonDocument.Parse(text);
            return Validate(doc.RootElement);
        }
        catch (JsonException ex)
        {
            return new ValidationResult(false, new[] { $"schema file is not valid JSON ({path}): {ex.Message}" });
        }
    }

    // -----------------------------------------------------------------------
    // Internal helpers
    // -----------------------------------------------------------------------

    private static List<string> ValidateSingleType(JsonElement schema)
    {
        var errors = new List<string>();

        if (!schema.TryGetProperty("fieldSchema", out var fieldSchema))
        {
            errors.Add(
                "missing required key: fieldSchema " +
                "(single-type schemas must declare fields to extract)");
            return errors;
        }

        if (fieldSchema.ValueKind != JsonValueKind.Object)
        {
            errors.Add("fieldSchema must be an object");
            return errors;
        }

        if (!fieldSchema.TryGetProperty("fields", out var fields))
        {
            errors.Add("fieldSchema.fields is required");
            return errors;
        }

        if (fields.ValueKind != JsonValueKind.Object)
        {
            errors.Add("fieldSchema.fields must be an object mapping field names to definitions");
            return errors;
        }

        bool any = false;
        foreach (var prop in fields.EnumerateObject())
        {
            any = true;
            errors.AddRange(ValidateFieldDefinition(prop.Name, prop.Value, path: null));
        }
        if (!any)
        {
            errors.Add("fieldSchema.fields must declare at least one field");
        }

        return errors;
    }

    private static List<string> ValidateFieldDefinition(string name, JsonElement definition, string? path)
    {
        var errors = new List<string>();
        var prefix = path ?? $"fieldSchema.fields['{name}']";

        if (definition.ValueKind != JsonValueKind.Object)
        {
            errors.Add($"{prefix} must be an object");
            return errors;
        }

        // type
        string? fieldType = null;
        if (!definition.TryGetProperty("type", out var typeEl))
        {
            errors.Add($"{prefix}.type is required");
        }
        else if (typeEl.ValueKind != JsonValueKind.String)
        {
            errors.Add($"{prefix}.type must be a string");
        }
        else
        {
            fieldType = typeEl.GetString();
            if (fieldType is null || !AllowedFieldTypes.Contains(fieldType))
            {
                var allowed = string.Join(", ", AllowedFieldTypes.OrderBy(s => s, StringComparer.Ordinal).Select(s => $"'{s}'"));
                errors.Add($"{prefix}.type '{fieldType}' is not one of [{allowed}]");
            }
        }

        // method (optional)
        if (definition.TryGetProperty("method", out var methodEl) && methodEl.ValueKind == JsonValueKind.String)
        {
            var method = methodEl.GetString();
            if (method is null || !AllowedFieldMethods.Contains(method))
            {
                var allowed = string.Join(", ", AllowedFieldMethods.OrderBy(s => s, StringComparer.Ordinal).Select(s => $"'{s}'"));
                errors.Add($"{prefix}.method '{method}' is not one of [{allowed}]");
            }
        }
        else if (definition.TryGetProperty("method", out var methodEl2) && methodEl2.ValueKind != JsonValueKind.Null)
        {
            errors.Add($"{prefix}.method must be a string");
        }

        // description (optional, but if present must be a string)
        if (definition.TryGetProperty("description", out var descEl) && descEl.ValueKind != JsonValueKind.String && descEl.ValueKind != JsonValueKind.Null)
        {
            errors.Add($"{prefix}.description must be a string");
        }

        // Recurse into nested object/array shapes
        if (fieldType == "object")
        {
            if (definition.TryGetProperty("properties", out var propsEl))
            {
                if (propsEl.ValueKind != JsonValueKind.Object)
                {
                    errors.Add($"{prefix}.properties must be an object");
                }
                else
                {
                    foreach (var child in propsEl.EnumerateObject())
                    {
                        errors.AddRange(ValidateFieldDefinition(
                            child.Name, child.Value, path: $"{prefix}.properties['{child.Name}']"));
                    }
                }
            }
        }
        else if (fieldType == "array")
        {
            if (definition.TryGetProperty("items", out var itemsEl))
            {
                if (itemsEl.ValueKind != JsonValueKind.Object)
                {
                    errors.Add($"{prefix}.items must be an object");
                }
                else
                {
                    errors.AddRange(ValidateFieldDefinition("items", itemsEl, path: $"{prefix}.items"));
                }
            }
        }

        return errors;
    }

    private static List<string> ValidateClassifyRoute(JsonElement config)
    {
        var errors = new List<string>();

        // enableSegment must be exactly true
        var hasEnableSegment = config.TryGetProperty("enableSegment", out var enableEl) &&
                               enableEl.ValueKind == JsonValueKind.True;
        if (!hasEnableSegment)
        {
            errors.Add("classify-and-route schemas must set config.enableSegment = true");
        }

        if (!config.TryGetProperty("contentCategories", out var categories) ||
            categories.ValueKind != JsonValueKind.Object)
        {
            errors.Add("config.contentCategories must be an object");
            return errors;
        }

        bool any = false;
        foreach (var cat in categories.EnumerateObject())
        {
            any = true;
            var prefix = $"config.contentCategories['{cat.Name}']";
            var entry = cat.Value;

            if (entry.ValueKind != JsonValueKind.Object)
            {
                errors.Add($"{prefix} must be an object");
                continue;
            }

            if (!entry.TryGetProperty("description", out var descEl) ||
                descEl.ValueKind != JsonValueKind.String ||
                string.IsNullOrWhiteSpace(descEl.GetString()))
            {
                errors.Add($"{prefix}.description is required and must be a non-empty string");
            }

            if (entry.TryGetProperty("analyzerId", out var analyzerIdEl) &&
                analyzerIdEl.ValueKind != JsonValueKind.String &&
                analyzerIdEl.ValueKind != JsonValueKind.Null)
            {
                errors.Add($"{prefix}.analyzerId, if present, must be a string");
            }
        }

        if (!any)
        {
            errors.Add("config.contentCategories must declare at least one category");
        }

        return errors;
    }
}
