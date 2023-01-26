// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text.Json;

namespace Azure.Core.Dynamic
{
    public partial class MutableJsonDocument
    {
        internal void WriteElementTo(Utf8JsonWriter writer)
        {
            // TODO: Optimize path manipulations with Span<byte>
            string path = string.Empty;

            Utf8JsonReader reader;

            // Check for changes at the root.
            bool changed = Changes.TryGetChange(path, -1, out MutableJsonChange change);
            if (changed)
            {
                reader = change.GetReader();
            }
            else
            {
                reader = new Utf8JsonReader(_original.Span);
            }

            WriteElement(path, -1, ref reader, writer);

            writer.Flush();
        }

        private void WriteElement(string path, int highWaterMark, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        writer.WriteStartObject();
                        WriteObjectProperties(path, highWaterMark, ref reader, writer);
                        break;
                    case JsonTokenType.StartArray:
                        writer.WriteStartArray();
                        WriteArrayValues(path, highWaterMark, ref reader, writer);
                        break;
                    case JsonTokenType.String:
                        WriteString(path, highWaterMark, ref reader, writer);
                        break;
                    case JsonTokenType.Number:
                        WriteNumber(path, highWaterMark, ref reader, writer);
                        break;
                    case JsonTokenType.True:
                    case JsonTokenType.False:
                        WriteBoolean(path, highWaterMark, reader.TokenType, ref reader, writer);
                        break;
                    case JsonTokenType.Null:
                        WriteNull(path, highWaterMark, ref reader, writer);
                        break;
                }
            }
        }

        private void WriteArrayValues(string path, int highWaterMark, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            int index = 0;

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        path = ChangeTracker.PushIndex(path, index);
                        WriteObject(path, highWaterMark, ref reader, writer);
                        break;
                    case JsonTokenType.StartArray:
                        path = ChangeTracker.PushIndex(path, index);
                        writer.WriteStartArray();
                        WriteArrayValues(path, highWaterMark, ref reader, writer);
                        break;
                    case JsonTokenType.String:
                        path = ChangeTracker.PushIndex(path, index);
                        WriteString(path, highWaterMark, ref reader, writer);
                        break;
                    case JsonTokenType.Number:
                        path = ChangeTracker.PushIndex(path, index);
                        WriteNumber(path, highWaterMark, ref reader, writer);
                        break;
                    case JsonTokenType.True:
                    case JsonTokenType.False:
                        path = ChangeTracker.PushIndex(path, index);
                        WriteBoolean(path, highWaterMark, reader.TokenType, ref reader, writer);
                        break;
                    case JsonTokenType.Null:
                        path = ChangeTracker.PushIndex(path, index);
                        WriteNull(path, highWaterMark, ref reader, writer);
                        break;
                    case JsonTokenType.EndArray:
                        writer.WriteEndArray();
                        return;
                }

                path = ChangeTracker.PopIndex(path);
                index++;
            }
        }

        private void WriteObjectProperties(string path, int highWaterMark, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        WriteObject(path, highWaterMark, ref reader, writer);
                        path = ChangeTracker.PopProperty(path);
                        continue;
                    case JsonTokenType.StartArray:
                        writer.WriteStartArray();
                        WriteArrayValues(path, highWaterMark, ref reader, writer);
                        path = ChangeTracker.PopProperty(path);
                        continue;
                    case JsonTokenType.PropertyName:
                        path = ChangeTracker.PushProperty(path, reader.ValueSpan);

                        writer.WritePropertyName(reader.ValueSpan);
                        Debug.WriteLine($"Path: {path}, TokenStartIndex: {reader.TokenStartIndex}");
                        continue;
                    case JsonTokenType.String:
                        WriteString(path, highWaterMark, ref reader, writer);
                        path = ChangeTracker.PopProperty(path);
                        continue;
                    case JsonTokenType.Number:
                        WriteNumber(path, highWaterMark, ref reader, writer);
                        path = ChangeTracker.PopProperty(path);
                        continue;
                    case JsonTokenType.True:
                    case JsonTokenType.False:
                        WriteBoolean(path, highWaterMark, reader.TokenType, ref reader, writer);
                        path = ChangeTracker.PopProperty(path);
                        continue;
                    case JsonTokenType.Null:
                        WriteNull(path, highWaterMark, ref reader, writer);
                        path = ChangeTracker.PopProperty(path);
                        continue;
                    case JsonTokenType.EndObject:
                        writer.WriteEndObject();
                        return;
                }
            }
        }

        private void WriteObject(string path, int highWaterMark, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            if (Changes.TryGetChange(path, highWaterMark, out MutableJsonChange change))
            {
                WriteStructuralChange(path, change, ref reader, writer);
                return;
            }

            writer.WriteStartObject();
            WriteObjectProperties(path, highWaterMark, ref reader, writer);
        }

        private void WriteStructuralChange(string path, MutableJsonChange change, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            Utf8JsonReader changedElementReader = change.GetReader();
            WriteElement(path, change.Index, ref changedElementReader, writer);

            // Skip this element in the original json buffer.
            reader.Skip();
        }

        private void WriteString(string path, int highWaterMark, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            if (Changes.TryGetChange(path, highWaterMark, out MutableJsonChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    WriteStructuralChange(path, change, ref reader, writer);
                    return;
                }

                writer.WriteStringValue((string)change.Value!);
                return;
            }

            writer.WriteStringValue(reader.ValueSpan);
            return;
        }

        private void WriteNumber(string path, int highWaterMark, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            if (Changes.TryGetChange(path, highWaterMark, out MutableJsonChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    WriteStructuralChange(path, change, ref reader, writer);
                    return;
                }

                switch (change.Value)
                {
                    case long l:
                        writer.WriteNumberValue(l);
                        return;
                    case int i:
                        writer.WriteNumberValue(i);
                        return;
                    case double d:
                        writer.WriteNumberValue(d);
                        return;
                    case float f:
                        writer.WriteNumberValue(f);
                        return;
                    case JsonElement element:
                        if (element.TryGetInt64(out long el))
                        {
                            writer.WriteNumberValue(el);
                            return;
                        }
                        if (element.TryGetDouble(out double ed))
                        {
                            writer.WriteNumberValue(ed);
                            return;
                        }
                        throw new InvalidOperationException("Change doesn't store a number value.");
                    default:
                        throw new InvalidOperationException("Change doesn't store a number value.");
                }
            }

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

            throw new InvalidOperationException("Change doesn't store a number value.");
        }

        private void WriteBoolean(string path, int highWaterMark, JsonTokenType token, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            if (Changes.TryGetChange(path, highWaterMark, out MutableJsonChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    WriteStructuralChange(path, change, ref reader, writer);
                    return;
                }

                writer.WriteBooleanValue((bool)change.Value!);
                return;
            }

            writer.WriteBooleanValue(value: token == JsonTokenType.True);
        }

        private void WriteNull(string path, int highWaterMark, ref Utf8JsonReader reader, Utf8JsonWriter writer)
        {
            if (Changes.TryGetChange(path, highWaterMark, out MutableJsonChange change) && change.ReplacesJsonElement)
            {
                WriteStructuralChange(path, change, ref reader, writer);
                return;
            }

            writer.WriteNullValue();
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

            MutableJsonChange change = default;
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
