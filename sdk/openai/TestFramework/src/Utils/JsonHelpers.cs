// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAI.TestFramework.Utils;

public static class JsonHelpers
{
    /// <summary>
    /// Serializes the specified data to a stream using as a UTF-8 encoded JSON text.
    /// </summary>
    /// <typeparam name="T">The type of the data to serialize.</typeparam>
    /// <param name="stream">The stream to write the serialized data to.</param>
    /// <param name="data">The data to serialize.</param>
    /// <param name="options">(Optional) Options to use when serializing.</param>
    public static void Serialize<T>(Stream stream, T data, JsonSerializerOptions? options = null)
    {
#if NETFRAMEWORK
        using (Utf8JsonWriter writer = new(stream))
        {
            JsonSerializer.Serialize<T>(writer, data, options);
            writer.Flush();
        }
#else
        JsonSerializer.Serialize<T>(stream, data, options);
#endif
    }

    /// <summary>
    /// Deserializes UTF-8 encoded JSON text from a stream.
    /// </summary>
    /// <typeparam name="T">The type of the data to deserialize.</typeparam>
    /// <param name="stream">The stream to read the serialized data from.</param>
    /// <param name="options">(Optional) Options to use when deserializing.</param>
    /// <returns>The deserialized data.</returns>
    public static T? Deserialize<T>(Stream stream, JsonSerializerOptions? options = null)
    {
#if NETFRAMEWORK
        // For now let's keep it simple and load entire JSON bytes into memory
        using MemoryStream buffer = new();
        stream.CopyTo(buffer);

        ReadOnlySpan<byte> jsonBytes = buffer.GetBuffer().AsSpan(0, (int)buffer.Length);
        return JsonSerializer.Deserialize<T>(jsonBytes, options);
#else
        return JsonSerializer.Deserialize<T>(stream, options);
#endif
    }

#if NET6_0_OR_GREATER
    // .Net 6 and newer already have the extension method we need defined in JsonSerializer
#else
    // TODO FIXME once we move to newer versions of System.Text.Json we can directly use the
    //            JsonSerializer extension method for elements
    public static T? Deserialize<T>(this JsonElement element, JsonSerializerOptions? options = null)
    {
        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream, new()
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Indented = false,
            SkipValidation = true
        });
        element.WriteTo(writer);
        writer.Flush();

        stream.Seek(0, SeekOrigin.Begin);
        if (((ulong)stream.Length & 0xffffffff00000000) != 0ul)
        {
            throw new ArgumentOutOfRangeException("JsonElement is too large");
        }

        ReadOnlySpan<byte> span = new(stream.GetBuffer(), 0, (int)stream.Length);
        return JsonSerializer.Deserialize<T>(span, options);
    }
#endif

    /// <summary>
    /// Serializes a value to a JsonElement.
    /// </summary>
    /// <typeparam name="T">Type of the data to serialize.</typeparam>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">(Optional) Options to use when serializing.</param>
    /// <returns>The serialized value as a JsonElement.</returns>
    public static JsonElement SerializeToElement<T>(T value, JsonSerializerOptions? options = null)
    {
#if NET6_0_OR_GREATER
        return JsonSerializer.SerializeToElement(value, options);
#else
        using MemoryStream stream = new();
        Serialize(stream, value, options);
        stream.Seek(0, SeekOrigin.Begin);
        return JsonDocument.Parse(stream).RootElement;
#endif
    }

    /// <summary>
    /// Creates a clone of the specified JSON serializer options.
    /// </summary>
    /// <param name="options">The JSON serializer options to clone.</param>
    /// <param name="converterFilter">(Optional) Filter to apply for selecting specific converters to include in the cloned options.</param>
    /// <returns>A clone of the JSON serializer options.</returns>
    public static JsonSerializerOptions Clone(this JsonSerializerOptions options, Predicate<JsonConverter>? converterFilter = null)
    {
#if NET
        JsonSerializerOptions cloned = new JsonSerializerOptions(options);
        if (converterFilter != null)
        {
            cloned.Converters.Clear();
            foreach (var converter in options.Converters.Where(c => converterFilter(c)))
            {
                cloned.Converters.Add(converter);
            }
        }

        return cloned;
#else
        JsonSerializerOptions clone = new()
        {
            AllowTrailingCommas = options.AllowTrailingCommas,
            DefaultBufferSize = options.DefaultBufferSize,
            DictionaryKeyPolicy = options.DictionaryKeyPolicy,
            Encoder = options.Encoder,
            IgnoreNullValues = options.IgnoreNullValues,
            IgnoreReadOnlyProperties = options.IgnoreReadOnlyProperties,
            MaxDepth = options.MaxDepth,
            PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive,
            PropertyNamingPolicy = options.PropertyNamingPolicy,
            ReadCommentHandling = options.ReadCommentHandling,
            WriteIndented = options.WriteIndented,
        };

        foreach (var converter in options.Converters.Where(c => converterFilter?.Invoke(c) ?? true))
        {
            clone.Converters.Add(converter);
        }

        return clone;
#endif
    }
}
