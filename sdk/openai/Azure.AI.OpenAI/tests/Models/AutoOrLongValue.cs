// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Globalization;
using System.Text.Json;

namespace Azure.AI.OpenAI.Tests.Models;

public readonly struct AutoOrLongValue
{
    public const string NULL = "<<null>>";
    public const string AUTO = "auto";

    private readonly long? _longValue;
    private readonly string _stringValue;

    public AutoOrLongValue()
    {
        _longValue = null;
        _stringValue = NULL;
    }

    public AutoOrLongValue(string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        else if (string.Equals(value, AUTO, StringComparison.OrdinalIgnoreCase))
        {
            _longValue = null;
            _stringValue = AUTO;
        }
        else if (string.Equals(value, NULL, StringComparison.OrdinalIgnoreCase))
        {
            _longValue = null;
            _stringValue = NULL;
        }
        else
        {
            throw new NotSupportedException();
        }
    }

    public AutoOrLongValue(long value)
    {
        _longValue = value;
        _stringValue = value.ToString(CultureInfo.InvariantCulture);
    }

    public JsonElement? ToJsonElement()
    {
        if (_stringValue == NULL)
        {
            return null;
        }

        using var json = JsonDocument.Parse(
            _longValue?.ToString(CultureInfo.InvariantCulture)
            ?? $"\"{_stringValue}\"");

        return json.RootElement.Clone();
    }

    public static AutoOrLongValue FromJsonElement(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.String)
        {
            return new(element.GetString() ?? NULL);
        }
        else if (element.ValueKind == JsonValueKind.Null)
        {
            return new();
        }
        else if (element.ValueKind == JsonValueKind.Number)
        {
            return new(element.GetInt64());
        }
        else
        {
            throw new JsonException("Unsupported element kind: " + element.ValueKind);
        }
    }

    public bool HasValue => _stringValue != NULL && HasLongValue;
    public string StringValue => _stringValue;
    public bool HasLongValue => _longValue.HasValue;
    public long LongValue => _longValue ?? throw new InvalidOperationException("No corresponding long value");

    public static implicit operator AutoOrLongValue(long val) => new AutoOrLongValue(val);
    public static implicit operator AutoOrLongValue(string? val) => new AutoOrLongValue(val ?? NULL);
}
