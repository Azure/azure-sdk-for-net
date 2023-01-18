// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.Core.Dynamic
{
    public partial class JsonData
    {
        // Note: internal implementation reading original data and writing to a buffer while
        // iterating over tokens.  Currently implemented without change-tracking in order to
        // prove correctness.
        internal void WriteElementTo(Utf8JsonWriter writer)
        {
            Span<byte> original = _original.Span;
            Utf8JsonReader reader = new Utf8JsonReader(original);

            // TODO: Optimize path manipulations with Span<byte>
            string path = string.Empty;

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        writer.WriteStartObject();
                        WriteObjectElement(path, ref reader, writer);
                        break;
                    case JsonTokenType.StartArray:
                        writer.WriteStartArray();
                        WriteArrayValues(path, ref reader, writer);
                        break;
                    case JsonTokenType.String:
                        WriteString(ref reader, writer);
                        break;
                    case JsonTokenType.Number:
                        WriteNumber(ref reader, writer);
                        break;
                    case JsonTokenType.True:
                        writer.WriteBooleanValue(value: true);
                        break;
                    case JsonTokenType.False:
                        writer.WriteBooleanValue(value: false);
                        break;
                    case JsonTokenType.Null:
                        writer.WriteNullValue();
                        break;
                }
            }

            writer.Flush();
        }

        private void WriteArrayValues(string path, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        writer.WriteStartObject();
                        WriteObjectElement(path, ref reader, writer);
                        continue;
                    case JsonTokenType.StartArray:
                        writer.WriteStartArray();
                        WriteArrayValues(path, ref reader, writer);
                        continue;
                    case JsonTokenType.String:
                        WriteString(ref reader, writer);
                        continue;
                    case JsonTokenType.Number:
                        WriteNumber(ref reader, writer);
                        continue;
                    case JsonTokenType.True:
                        writer.WriteBooleanValue(value: true);
                        return;
                    case JsonTokenType.False:
                        writer.WriteBooleanValue(value: false);
                        return;
                    case JsonTokenType.Null:
                        writer.WriteNullValue();
                        return;
                    case JsonTokenType.EndArray:
                        writer.WriteEndArray();
                        return;
                }
            }
        }

        private void WriteObjectElement(string path, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            bool changed = false;
            JsonDataChange change = default;

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        writer.WriteStartObject();
                        WriteObjectElement(path, ref reader, writer);
                        path = PopProperty(path);
                        continue;
                    case JsonTokenType.StartArray:
                        writer.WriteStartArray();
                        WriteArrayValues(path, ref reader, writer);
                        path = PopProperty(path);
                        continue;
                    case JsonTokenType.PropertyName:
                        path = PushProperty(path, reader.ValueSpan);

                        changed = Changes.TryGetChange(path, out change);

                        writer.WritePropertyName(reader.ValueSpan);
                        Debug.WriteLine($"Path: {path}, TokenStartIndex: {reader.TokenStartIndex}");
                        continue;
                    case JsonTokenType.String:
                        if (changed)
                        {
                            writer.WriteStringValue((string)change.Value!);
                        }
                        else
                        {
                            WriteString(ref reader, writer);
                        }
                        path = PopProperty(path);
                        continue;
                    case JsonTokenType.Number:
                        if (changed)
                        {
                            WriteNumber(change, writer);
                        }
                        else
                        {
                            WriteNumber(ref reader, writer);
                        }
                        path = PopProperty(path);
                        continue;
                    case JsonTokenType.True:
                        if (changed)
                        {
                            writer.WriteBooleanValue((bool)change.Value!);
                        }
                        else
                        {
                            writer.WriteBooleanValue(value: true);
                        }
                        path = PopProperty(path);
                        return;
                    case JsonTokenType.False:
                        if (changed)
                        {
                            writer.WriteBooleanValue((bool)change.Value!);
                        }
                        else
                        {
                            writer.WriteBooleanValue(value: false);
                        }
                        path = PopProperty(path);
                        return;
                    case JsonTokenType.Null:
                        // TODO: Do we want to write the value here if null?
                        writer.WriteNullValue();
                        path = PopProperty(path);
                        return;
                    case JsonTokenType.EndObject:
                        writer.WriteEndObject();
                        return;
                }
            }
        }

        private static void WriteString(ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            writer.WriteStringValue(reader.ValueSpan);
            return;
        }

        private static void WriteNumber(JsonDataChange change, Utf8JsonWriter writer)
        {
            // TODO: Extend to support long as well.
            writer.WriteNumberValue((double)change.Value!);
        }

        private static void WriteNumber(ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            if (reader.TryGetInt64(out long longValue))
            {
                writer.WriteNumberValue(longValue);
                return;
            }

            if (reader.TryGetDouble(out double doubleValue))
            {
                writer.WriteNumberValue(doubleValue);
                return;
            }
        }

        private static string PushProperty(string path, ReadOnlySpan<byte> value)
        {
            string propertyName = BinaryData.FromBytes(value.ToArray()).ToString();
            if (path.Length == 0)
            {
                return propertyName;
            }
            return $"{path}.{propertyName}";
        }

        private static string PopProperty(string path)
        {
            int lastDelimiter = path.LastIndexOf('.');
            if (lastDelimiter == -1)
            {
                return string.Empty;
            }
            return path.Substring(0, lastDelimiter);
        }

        private void WriteTheHardWay(Utf8JsonWriter writer)
        {
            // TODO: Handle arrays
            // TODO: Handle additions
            // TODO: Handle removals

            var original = _original.Span;
            Utf8JsonReader reader = new Utf8JsonReader(original);

            Span<byte> path = stackalloc byte[128];
            int pathLength = 0;
            ReadOnlySpan<byte> currentPropertyName = Span<byte>.Empty;

            JsonDataChange change = default;
            bool changed = false;
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        currentPropertyName = reader.ValueSpan;

                        //push
                        {
                            if (pathLength != 0)
                            {
                                path[pathLength] = (byte)'.';
                                pathLength++;
                            }
                            if (!currentPropertyName.TryCopyTo(path.Slice(pathLength)))
                            {
                                throw new NotImplementedException(); // need to use switch to pooled buffer
                            }
                            pathLength += currentPropertyName.Length;
                        }
                        changed = Changes.TryGetChange(path.Slice(0, pathLength), out change);
                        // TODO: Handle nulls

                        writer.WritePropertyName(currentPropertyName);
                        break;
                    case JsonTokenType.String:
                        if (changed)
                            writer.WriteStringValue((string)change.Value!);
                        else
                            writer.WriteStringValue(reader.ValueSpan);

                        // pop
                        {
                            int lastDelimiter = path.LastIndexOf((byte)'.');
                            if (lastDelimiter != -1)
                            { pathLength = 0; }
                            else
                                pathLength = lastDelimiter;
                        }
                        break;
                    case JsonTokenType.Number:
                        if (changed)
                            writer.WriteNumberValue((double)change.Value!);
                        else
                            writer.WriteStringValue(reader.ValueSpan);

                        // pop
                        {
                            int lastDelimiter = path.LastIndexOf((byte)'.');
                            if (lastDelimiter != -1)
                            { pathLength = 0; }
                            else
                                pathLength = lastDelimiter;
                        }

                        break;
                    case JsonTokenType.StartObject:
                        writer.WriteStartObject();
                        break;
                    case JsonTokenType.EndObject:
                        // pop
                        {
                            int lastDelimiter = path.LastIndexOf((byte)'.');
                            if (lastDelimiter != -1)
                            { pathLength = 0; }
                            else
                                pathLength = lastDelimiter;
                            writer.WriteEndObject();
                        }
                        break;
                }
            }
            writer.Flush();
        }
    }
}
