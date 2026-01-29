// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.OpenAI;

internal static partial class CustomSerializationHelpers
{
    internal static TOutput DeserializeNewInstance<TOutput,UInstanceInput>(
        UInstanceInput existingInstance,
        Func<JsonElement, ModelReaderWriterOptions?, TOutput> deserializationFunc,
        ref Utf8JsonReader reader,
        ModelReaderWriterOptions options)
            where UInstanceInput : IJsonModel<TOutput>
    {
        options ??= new("W");
        var format = options.Format == "W" ? ((IJsonModel<TOutput>)existingInstance).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(UInstanceInput)} does not support '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return deserializationFunc.Invoke(document.RootElement, options);
    }

    internal static TOutput DeserializeNewInstance<TOutput,UInstanceInput>(
        UInstanceInput existingInstance,
        Func<JsonElement, ModelReaderWriterOptions, TOutput> deserializationFunc,
        BinaryData data,
        ModelReaderWriterOptions options)
            where UInstanceInput : IPersistableModel<TOutput>
    {
        options ??= new("W");
        var format = options.Format == "W" ? ((IPersistableModel<TOutput>)existingInstance).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return deserializationFunc.Invoke(document.RootElement, options)!;
                }
            default:
                throw new FormatException($"The model {nameof(UInstanceInput)} does not support '{format}' format.");
        }
    }

    internal static void SerializeInstance<TOutput,UInstanceInput>(
        UInstanceInput instance,
        Action<UInstanceInput,Utf8JsonWriter,ModelReaderWriterOptions> serializationFunc,
        Utf8JsonWriter writer,
        ModelReaderWriterOptions options)
            where UInstanceInput : IJsonModel<TOutput>
    {
        options ??= new ModelReaderWriterOptions("W");
        AssertSupportedJsonWriteFormat<TOutput, UInstanceInput>(instance, options);
        serializationFunc.Invoke(instance, writer, options);
    }

    internal static void SerializeInstance<T>(
        T instance,
        Action<T, Utf8JsonWriter, ModelReaderWriterOptions> serializationFunc,
        Utf8JsonWriter writer,
        ModelReaderWriterOptions options)
        where T : IJsonModel<T>
            => SerializeInstance<T, T>(instance, serializationFunc, writer, options);

    internal static BinaryData SerializeInstance<TOutput, UInstanceInput>(
        UInstanceInput instance,
        ModelReaderWriterOptions options)
            where UInstanceInput : IPersistableModel<TOutput>
    {
        options ??= new("W");
        AssertSupportedPersistableWriteFormat<TOutput, UInstanceInput>(instance, options);
        return ModelReaderWriter.Write(instance, options, AzureAIOpenAIContext.Default);
    }

    internal static BinaryData SerializeInstance<T>(T instance, ModelReaderWriterOptions options)
            where T : IPersistableModel<T>
        => SerializeInstance<T, T>(instance, options);

    internal static void AssertSupportedJsonWriteFormat<T>(T instance, ModelReaderWriterOptions options)
        where T : IJsonModel<T>
            => AssertSupportedJsonWriteFormat<T, T>(instance, options);

    internal static void AssertSupportedJsonWriteFormat<TOutput,UInstanceInput>(UInstanceInput instance, ModelReaderWriterOptions options)
        where UInstanceInput : IJsonModel<TOutput>
    {
        var format = options.Format == "W" ? ((IJsonModel<TOutput>)instance).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(UInstanceInput)} does not support '{format}' format.");
        }
    }

    internal static void AssertSupportedPersistableWriteFormat<T>(T instance, ModelReaderWriterOptions options)
        where T : IPersistableModel<T>
            => AssertSupportedPersistableWriteFormat<T, T>(instance, options);

    internal static void AssertSupportedPersistableWriteFormat<TOutput,UInstanceInput>(UInstanceInput instance, ModelReaderWriterOptions options)
        where UInstanceInput : IPersistableModel<TOutput>
    {
        var format = options.Format == "W" ? ((IPersistableModel<TOutput>)instance).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(UInstanceInput)} does not support '{format}' format.");
        }
    }

    internal static void WriteSerializedAdditionalRawData(this Utf8JsonWriter writer, IDictionary<string, BinaryData> dictionary, ModelReaderWriterOptions options)
    {
        if (true && dictionary != null)
        {
            foreach (var item in dictionary)
            {
                writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(item.Value);
#else
                using JsonDocument document = JsonDocument.Parse(item.Value);
                JsonSerializer.Serialize(writer, document.RootElement);
#endif
            }
        }
    }

    internal static void WriteOptionalProperty<T>(this Utf8JsonWriter writer, ReadOnlySpan<byte> name, T value, ModelReaderWriterOptions options)
    {
        if (Optional.IsDefined(value))
        {
            writer.WritePropertyName(name);
            writer.WriteObjectValue(value, options);
        }
    }

    internal static void WriteOptionalCollection<T>(this Utf8JsonWriter writer, ReadOnlySpan<byte> name, IEnumerable<T> values, ModelReaderWriterOptions options)
    {
        if (Optional.IsCollectionDefined(values))
        {
            writer.WritePropertyName(name);
            writer.WriteStartArray();
            foreach (T item in values)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
        }
    }
}
