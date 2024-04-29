// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments
public abstract class JsonModel<T> : IJsonModel, IJsonModel<T>
{
    private Dictionary<string, BinaryData>? _unknownProperties;

    IDictionary<string, BinaryData> IJsonModel.AdditionalProperties
        => _unknownProperties ??= new();

#pragma warning disable AZC0014 // Avoid using banned types in public API
    protected abstract T CreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options);

    protected abstract void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
#pragma warning restore AZC0014 // Avoid using banned types in public API

    T IJsonModel<T>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => CreateCore(ref reader, options);

    T IPersistableModel<T>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var pm = this as IJsonModel<T>;
        var reader = new Utf8JsonReader(data);
        return pm.Create(ref reader, options);
    }

    string IPersistableModel<T>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => GetFormatFromOptionsCore(options);

    protected virtual string GetFormatFromOptionsCore(ModelReaderWriterOptions options)
    {
        if (options.Format == "W")
            return "J";

        throw new NotSupportedException();
    }

    void IJsonModel<T>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => WriteCore(writer, options);

    BinaryData IPersistableModel<T>.Write(ModelReaderWriterOptions options)
    {
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        var jsonModel = this as IJsonModel<T>;
        jsonModel.Write(writer, options);
        stream.Position = 0;
        // TODO: flush?

        return BinaryData.FromStream(stream);
    }

    private static BinaryData ReadUnknownValue(ref Utf8JsonReader reader)
    {
        var stream = new MemoryStream();
        int depth = 0;
#if NET6_0_OR_GREATER
        bool writeComma = false;
#endif

        // TODO: netstandard2.0

        while (true)
        {
            if (!reader.Read())
                throw new Exception();

            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    if (depth == 0)
                    {
                        return new BinaryData(reader.ValueSpan.ToArray());
                    }
#if NET6_0_OR_GREATER
                    stream.Write("\""u8);
                    stream.Write(reader.ValueSpan);
                    stream.Write("\""u8);
                    writeComma = true;
#endif
                    break;
                case JsonTokenType.Number:
                    if (depth == 0)
                    {
                        return new BinaryData(reader.ValueSpan.ToArray());
                    }
#if NET6_0_OR_GREATER
                    stream.Write(reader.ValueSpan);
                    writeComma = true;
#endif
                    break;
                case JsonTokenType.EndObject:
                case JsonTokenType.EndArray:
#if NET6_0_OR_GREATER
                    stream.Write(reader.ValueSpan);
#endif
                    depth--;
                    if (depth == 0)
                    {
                        stream.Position = 0;
                        return BinaryData.FromStream(stream);
                    }
                    break;
                case JsonTokenType.StartObject:
                case JsonTokenType.StartArray:
                    depth++;
#if NET6_0_OR_GREATER
                    stream.Write(reader.ValueSpan);
#endif
                    break;
                case JsonTokenType.PropertyName:
#if NET6_0_OR_GREATER
                    if (writeComma)
                    {
                        stream.Write(",\n"u8);
                        writeComma = false;
                    }
                    stream.Write("\""u8);
                    stream.Write(reader.ValueSpan);
                    stream.Write("\":"u8);
#endif
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }

#pragma warning disable AZC0014 // Avoid using banned types in public API
    protected void ReadUnknownProperty(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
    {
        string name = reader.GetString()!;
        BinaryData value = ReadUnknownValue(ref reader);
        ((IJsonModel)this).AdditionalProperties.Add(name, value);
    }

#pragma warning disable AZC0014 // Avoid using banned types in public API
    protected void WriteUnknownProperties(Utf8JsonWriter writer, ModelReaderWriterOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
    {
        if (_unknownProperties != null)
        {
            foreach (var property in _unknownProperties)
            {
                // Skip non-serialized items for now
                // TODO: serialize non-serialized items in some cases?
                if (property.Value is not BinaryData serializedValue)
                {
                    continue;
                }

                writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(serializedValue);
#else
                using (JsonDocument document = JsonDocument.Parse(serializedValue))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
        }
    }
}
#pragma warning restore CS1591 // public XML comments
