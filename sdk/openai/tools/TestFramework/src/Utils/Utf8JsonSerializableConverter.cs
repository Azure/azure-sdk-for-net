// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// Converter for types that implement <see cref="IUtf8JsonSerializable"/>.
/// </summary>
public class Utf8JsonSerializableConverter : JsonConverter<IUtf8JsonSerializable>
{
    private static Utf8JsonSerializableConverter? s_instance;

    /// <summary>
    /// Gets the shared instance of the converter.
    /// </summary>
    public static Utf8JsonSerializableConverter Instance => s_instance ??= new();

    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
        => typeof(IUtf8JsonSerializable).IsAssignableFrom(typeToConvert);

    /// <inheritdoc />
    public override IUtf8JsonSerializable Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => throw new NotSupportedException("Only writing JSON is supported");

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, IUtf8JsonSerializable value, JsonSerializerOptions options)
        => value.Write(writer);
}

#if !NET7_0_OR_GREATER
/// <summary>
/// In versions of .Net older than 7.0, System.Text.Json version 6.0.9 has an odd quirk and is particularly pedantic with converters
/// so directly using Utf8JsonSerializableConverter would result in an InvalidCastException. The work around is to use a converter factory.
/// </summary>
public class Utf8JsonSerializableConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert) => typeof(IUtf8JsonSerializable).IsAssignableFrom(typeToConvert);
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        => (JsonConverter?)Activator.CreateInstance(typeof(InnerConverter<>).MakeGenericType(typeToConvert));

    private class InnerConverter<T> : JsonConverter<T> where T : IUtf8JsonSerializable
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => (T)Utf8JsonSerializableConverter.Instance.Read(ref reader, typeToConvert, options);

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            => Utf8JsonSerializableConverter.Instance.Write(writer, value, options);
    }
}
#endif
