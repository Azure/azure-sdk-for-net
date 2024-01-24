// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.ClientModel.Primitives;

/// <summary>
/// A generic converter which allows <see cref="JsonSerializer"/> to be able to write and read any models that implement <see cref="IJsonModel{T}"/>.
/// </summary>
[RequiresUnreferencedCode("The constructors of the type being deserialized are dynamically accessed and may be trimmed.")]
#pragma warning disable AZC0014 // Avoid using banned types in public API
internal class JsonModelConverter : JsonConverter<IJsonModel<object>>
#pragma warning restore AZC0014 // Avoid using banned types in public API
{
    /// <summary>
    /// Gets the <see cref="ModelReaderWriterOptions"/> used to read and write models.
    /// </summary>
    public ModelReaderWriterOptions Options { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="JsonModelConverter"/> with a default options of <see cref="ModelReaderWriterOptions.Json"/>.
    /// </summary>
    public JsonModelConverter()
        : this(ModelReaderWriterOptions.Json) { }

    /// <summary>
    /// Initializes a new instance of <see cref="JsonModelConverter"/>.
    /// </summary>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    public JsonModelConverter(ModelReaderWriterOptions options)
    {
        Options = options;
    }

    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert)
    {
        return !Attribute.IsDefined(typeToConvert, typeof(JsonConverterAttribute));
    }

    /// <inheritdoc/>
#pragma warning disable AZC0014 // Avoid using banned types in public API
    public override IJsonModel<object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return (IJsonModel<object>)ModelReaderWriter.Read(BinaryData.FromString(document.RootElement.GetRawText()), typeToConvert, Options)!;
    }

    /// <inheritdoc/>
#pragma warning disable AZC0014 // Avoid using banned types in public API
    public override void Write(Utf8JsonWriter writer, IJsonModel<object> value, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
    {
        value.Write(writer, Options);
    }
}
