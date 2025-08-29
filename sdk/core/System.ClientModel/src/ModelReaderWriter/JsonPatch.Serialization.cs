// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

public partial struct JsonPatch
{
    /// <summary>
    /// Writes the JSON representation of the JsonPatch to the specified Utf8JsonWriter for the specified JSON path.
    /// </summary>
    /// <param name="writer">The Utf8JsonWriter to write to.</param>
    /// <param name="jsonPath">The JSON path to write.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void WriteTo(Utf8JsonWriter writer, ReadOnlySpan<byte> jsonPath)
    {
        if (_properties == null)
            return;

        Span<byte> normalizedPrefix = stackalloc byte[jsonPath.Length];
        JsonPathComparer.Default.Normalize(jsonPath, normalizedPrefix, out int bytesWritten);
        normalizedPrefix = normalizedPrefix.Slice(0, bytesWritten);

        foreach (var kvp in _properties)
        {
            if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.Written))
                continue;

            ReadOnlySpan<byte> keySpan = kvp.Key;
            if (!keySpan.StartsWith(normalizedPrefix))
                continue;

            keySpan = keySpan.Slice(normalizedPrefix.Length);

            WriteEncodedValueAsJson(writer, keySpan.GetPropertyNameFromSlice(), kvp.Value);
        }
    }

    /// <summary>
    /// Writes the JSON representation of the specified array to the specified Utf8JsonWriter.
    /// </summary>
    /// <param name="writer">The Utf8JsonWriter to write to.</param>
    /// <param name="arrayPath">The JSON path of the array to write.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void WriteArrayTo(Utf8JsonWriter writer, ReadOnlySpan<byte> arrayPath)
    {
        if (_properties == null)
            return;

        if (!_properties.TryGetValue(arrayPath, out var value))
            return;

        if (value.Kind == ValueKind.Removed)
            return;

        value.Kind |= ValueKind.Written;
        _properties.Set(arrayPath, value);
        writer.WriteRawValue(value.Value.Span.Slice(1, value.Value.Length - 2));
    }

    /// <summary>
    /// Writes the JSON representation of the JsonPatch to the specified Utf8JsonWriter.
    /// </summary>
    /// <param name="writer">The Utf8JsonWriter to write to.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void WriteTo(Utf8JsonWriter writer)
    {
        bool isWriterEmpty = writer.CurrentDepth == 0 && writer.BytesCommitted == 0 && writer.BytesPending == 0;
        bool isSeeded = !_rawJson.Value.IsEmpty;

        SpanHashSet? arrays = null;

        if (!isSeeded && _properties is null && isWriterEmpty)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
            return;
        }

        if (_properties is null && !isWriterEmpty)
        {
            return;
        }

        // write patches
        if (_properties is not null && (isSeeded ? !isWriterEmpty : true))
        {
            bool writingRoot = !isSeeded && isWriterEmpty && !_properties.TryGetValue("$"u8, out var encodedValue) && !encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend);
            if (writingRoot)
            {
                writer.WriteStartObject();
            }

            foreach (var kvp in _properties)
            {
                if (_propagatorIsFlattened is not null && _propagatorIsFlattened(kvp.Key))
                    continue;

                if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.Written))
                {
                    continue;
                }

                if (kvp.Value.Kind.HasFlag(ValueKind.ArrayItemAppend))
                {
                    var firstNonArray = kvp.Key.GetFirstNonIndexParent();
                    if (arrays?.Contains(firstNonArray) == true)
                    {
                        continue;
                    }

                    if (!kvp.Key.IsRoot() && !kvp.Key.IsArrayIndex())
                    {
                        writer.WritePropertyName(kvp.Key.GetPropertyName());
                    }
                    _properties.TryGetValue(firstNonArray, out var existingArrayValue);
                    var rawArray = GetCombinedArray(firstNonArray, existingArrayValue, true);
                    writer.WriteRawValue(rawArray.Span);
                    arrays ??= new();
                    arrays.Add(firstNonArray);
                    continue;
                }

                if (!kvp.Key.GetParent().IsRoot())
                {
                    JsonPathReader pathReader = new(kvp.Key);
                    ReadOnlySpan<byte> firstProperty = pathReader.GetFirstProperty();

                    writer.WritePropertyName(firstProperty.GetPropertyName());
                    writer.WriteStartObject();
                    WriteTo(writer, firstProperty);
                    writer.WriteEndObject();
                    continue;
                }

                WriteEncodedValueAsJson(writer, kvp.Key.GetPropertyName(), kvp.Value);
            }

            if (writingRoot)
            {
                writer.WriteEndObject();
            }
            return;
        }

        Debug.Assert(isSeeded, "Raw JSON should not be empty at this point");
        Debug.Assert(isWriterEmpty, "Writer should be empty at this point");

        if (_properties is null)
        {
            if (!_rawJson.Value.IsEmpty && writer.CurrentDepth == 0 && writer.BytesCommitted == 0 && writer.BytesPending == 0)
            {
                writer.WriteRawValue(_rawJson.Value.Span);
            }
        }
        else
        {
            ReadOnlyMemory<byte> newJson = _rawJson.Value;
            foreach (var kvp in _properties)
            {
                if (kvp.Value.Kind.HasFlag(ValueKind.Removed))
                {
                    newJson = newJson.Remove(kvp.Key);
                }
                else if (kvp.Value.Kind.HasFlag(ValueKind.ArrayItemAppend))
                {
                    newJson = newJson.Append(kvp.Key, kvp.Value.Value.Slice(1, kvp.Value.Value.Length - 2));
                }
                else
                {
                    if (kvp.Key.IsArrayIndex())
                    {
                        newJson = newJson.InsertAt(kvp.Key, kvp.Value.Value);
                    }
                    else
                    {
                        newJson = newJson.Set(kvp.Key, kvp.Value.Value);
                    }
                }
            }
            writer.WriteRawValue(newJson.Span);
        }
    }

    private static void WriteEncodedValueAsJson(Utf8JsonWriter writer, ReadOnlySpan<byte> propertyName, EncodedValue encodedValue)
    {
        if (encodedValue.Value.Length == 0)
            throw new ArgumentException("Empty encoded value");

        ValueKind kind = encodedValue.Kind & ~ValueKind.ArrayItemAppend;
        ReadOnlySpan<byte> valueBytes = encodedValue.Value.Span;

        if (!propertyName.IsEmpty)
            writer.WritePropertyName(propertyName);

        switch (kind)
        {
            case ValueKind.Number:
                // valueBytes contains JSON number representation
                writer.WriteRawValue(valueBytes);
                break;

            case ValueKind.BooleanTrue:
            case ValueKind.BooleanFalse:
                // valueBytes contains JSON boolean representation
                writer.WriteBooleanValue(kind == ValueKind.BooleanTrue);
                break;

            case ValueKind.Json:
                // Write raw JSON value
                writer.WriteRawValue(valueBytes, skipInputValidation: true);
                break;

            case ValueKind.Null:
                writer.WriteNullValue();
                break;

            case ValueKind.Removed:
                // Skip removed properties during serialization
                break;

            case ValueKind.Utf8String:
            case ValueKind.TimeSpan:
            case ValueKind.Guid:
            case ValueKind.DateTime:
                writer.WriteStringValue(valueBytes);
                break;

            default:
                throw new NotSupportedException($"Unsupported value kind: {kind}");
        }
    }
}
