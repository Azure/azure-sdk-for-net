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
    /// Writes in standard JSON format.
    /// </summary>
    /// <param name="writer">The Utf8JsonWriter to write to.</param>
    /// <param name="jsonPath">The JSON path to write.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void WriteTo(Utf8JsonWriter writer, ReadOnlySpan<byte> jsonPath)
    {
        if (_properties == null)
        {
            return;
        }

        if (_properties.TryGetValue(jsonPath, out var encodedValue))
        {
            if (encodedValue.Kind == ValueKind.Removed)
            {
                return;
            }

            if (encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend))
            {
                _properties.TryUpdateValueKind(jsonPath, encodedValue.Kind | ValueKind.ModelOwned);
                writer.WriteRawValue(encodedValue.Value.Span.Slice(1, encodedValue.Value.Length - 2));
            }
        }

        Span<byte> normalizedPrefix = stackalloc byte[jsonPath.Length];
        JsonPathComparer.Default.Normalize(jsonPath, normalizedPrefix, out int bytesWritten);
        normalizedPrefix = normalizedPrefix.Slice(0, bytesWritten);

#if !NET8_0_OR_GREATER
        Dictionary<byte[], ValueKind> keysToUpdate = new();
#endif
        foreach (var kvp in _properties)
        {
            if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.ModelOwned))
            {
                continue;
            }

            ReadOnlySpan<byte> keySpan = kvp.Key;
            if (!keySpan.StartsWith(normalizedPrefix))
            {
                continue;
            }

            keySpan = keySpan.Slice(normalizedPrefix.Length);

            WriteEncodedValueAsJson(writer, keySpan.GetPropertyNameFromSlice(), kvp.Value);

#if NET8_0_OR_GREATER
            _properties.TryUpdateValueKind(kvp.Key, kvp.Value.Kind | ValueKind.ModelOwned);
#else
            keysToUpdate.Add(kvp.Key, kvp.Value.Kind);
#endif
        }

#if !NET8_0_OR_GREATER
        foreach (var kvp in keysToUpdate)
        {
            _properties.TryUpdateValueKind(kvp.Key, kvp.Value | ValueKind.ModelOwned);
        }
#endif
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

        // write an empty object if we are not seeded and there are no properties to write and the writer is empty
        if (!isSeeded && _properties is null && isWriterEmpty)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
            return;
        }

        // if there are no properties to write and the writer is not empty then we don't need to write anything
        // we assume the wrapping {} happened outside of us since writer is not empty.
        if (_properties is null && !isWriterEmpty)
        {
            return;
        }

        // if we have properties and we are either not seeded or the writer is empty then we need to write out the properties
        // as standalone items not applying them to the original seeded raw json.
        if (_properties is not null && (isSeeded ? !isWriterEmpty : true))
        {
            bool writingRoot = !isSeeded && isWriterEmpty && !_properties.TryGetValue("$"u8, out var encodedValue) && !encodedValue.Kind.HasFlag(ValueKind.ArrayItemAppend);
            if (writingRoot)
            {
                writer.WriteStartObject();
            }

            foreach (var kvp in _properties)
            {
                if (kvp.Value.Kind == ValueKind.Removed || kvp.Value.Kind.HasFlag(ValueKind.ModelOwned))
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
                    var rawArray = GetCombinedArray(firstNonArray, existingArrayValue);
                    writer.WriteRawValue(rawArray.Span);
                    arrays ??= new();
                    arrays.Add(firstNonArray);
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
            // if there are no properties then we simply echo the existing raw json back into the writer.
            if (!_rawJson.Value.IsEmpty && writer.CurrentDepth == 0 && writer.BytesCommitted == 0 && writer.BytesPending == 0)
            {
                writer.WriteRawValue(_rawJson.Value.Span);
            }
        }
        else
        {
            // we need to apply the properties to the existing raw json and write out the new combined json to the writer.
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
                    newJson = newJson.Set(kvp.Key, GetEncodedBytes(kvp.Value));
                }
            }
            writer.WriteRawValue(newJson.Span);
        }
    }

    private static ReadOnlyMemory<byte> GetEncodedBytes(EncodedValue value)
    {
        ValueKind kind = value.Kind;
        if (kind.HasFlag(ValueKind.Utf8String) || kind.HasFlag(ValueKind.DateTime) || kind.HasFlag(ValueKind.Guid) || kind.HasFlag(ValueKind.TimeSpan))
        {
            return new([(byte)'"', .. value.Value.Span, (byte)'"']);
        }
        return value.Value;
    }

    private static void WriteEncodedValueAsJson(Utf8JsonWriter writer, ReadOnlySpan<byte> propertyName, EncodedValue encodedValue)
    {
        if (encodedValue.Value.Length == 0)
        {
            throw new ArgumentException("Empty encoded value");
        }

        ValueKind kind = encodedValue.Kind & ~ValueKind.ArrayItemAppend;
        ReadOnlySpan<byte> valueBytes = encodedValue.Value.Span;

        if (!propertyName.IsEmpty)
        {
            writer.WritePropertyName(propertyName);
        }

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

    private void WriteAsJsonPatchTo(Utf8JsonWriter writer)
    {
        if (_properties is null)
        {
            return;
        }

        bool isSeeded = !_rawJson.Value.IsEmpty;
        ReadOnlyMemory<byte> rawJson = _rawJson.Value;

        // need to add extra space for append characters and escape characters.
        Span<byte> jsonPointerBuffer = stackalloc byte[_properties.MaxKeyLength << 1];

        foreach (var kvp in _properties)
        {
            ReadOnlySpan<byte> opType;
            bool isArrayItemAppend = kvp.Value.Kind.HasFlag(ValueKind.ArrayItemAppend);
            if (kvp.Value.Kind == ValueKind.Removed)
            {
                opType = "remove"u8;
            }
            else
            {
                if (isArrayItemAppend || !isSeeded || !_rawJson.Value.TryGetJson(kvp.Key, out var currentValue))
                {
                    opType = "add"u8;
                }
                else
                {
                    var valueSpan = kvp.Value.Value.Span;
                    if (valueSpan.SequenceEqual(currentValue.Span))
                    {
                        // same value we can skip
                        continue;
                    }
                    if (kvp.Value.Kind.HasFlag(ValueKind.Utf8String))
                    {
                        // currentValue comes from _rawJson which means strings will be quoted
                        // if kvp is Utf8String we need to remove quotes from currentValue to compare
                        ReadOnlySpan<byte> currentValueSpan = currentValue.Span;
                        if (currentValueSpan.Length >= 2 &&
                            currentValueSpan[0] == (byte)'"' &&
                            currentValueSpan[currentValueSpan.Length - 1] == (byte)'"' &&
                            currentValueSpan.Slice(1, currentValueSpan.Length - 2).SequenceEqual(valueSpan))
                        {
                            // same value we can skip
                            continue;
                        }
                    }
                    opType = "replace"u8;
                }
            }
            writer.WriteStartObject();
            writer.WritePropertyName("op"u8);
            writer.WriteStringValue(opType);
            writer.WritePropertyName("path"u8);
            int bytesWritten = kvp.Key.ConvertToJsonPointer(jsonPointerBuffer, isArrayItemAppend);
            writer.WriteStringValue(jsonPointerBuffer.Slice(0, bytesWritten));
            if (kvp.Value.Kind != ValueKind.Removed)
            {
                writer.WritePropertyName("value"u8);
                ReadOnlyMemory<byte> valueRom = kvp.Value.Value;
                ValueKind kind = kvp.Value.Kind;
                if (isArrayItemAppend && valueRom.IsArrayWrapped())
                {
                    kind = ValueKind.Json;
                    valueRom = valueRom.Slice(1, valueRom.Length - 2);
                }
                WriteEncodedValueAsJson(writer, ReadOnlySpan<byte>.Empty, new(kind, valueRom));
            }
            writer.WriteEndObject();
        }
    }

    private string SerializeToJson()
    {
        using UnsafeBufferSequence buffer = new();
        using Utf8JsonWriter writer = new(buffer);
        WriteTo(writer);
        writer.Flush();
#if NET6_0_OR_GREATER
        return Encoding.UTF8.GetString(buffer.ExtractReader().ToBinaryData().ToMemory().Span);
#else
        return Encoding.UTF8.GetString(buffer.ExtractReader().ToBinaryData().ToArray());
#endif
    }

    private string SerializeToJsonPatch()
    {
        using UnsafeBufferSequence buffer = new();
        using Utf8JsonWriter writer = new(buffer);
        writer.WriteStartArray();
        WriteAsJsonPatchTo(writer);
        writer.WriteEndArray();
        writer.Flush();
#if NET6_0_OR_GREATER
        return Encoding.UTF8.GetString(buffer.ExtractReader().ToBinaryData().ToMemory().Span);
#else
        return Encoding.UTF8.GetString(buffer.ExtractReader().ToBinaryData().ToArray());
#endif
    }
}
