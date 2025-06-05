// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.ClientModel.Primitives;

/// <summary>
/// A generic converter which allows <see cref="JsonSerializer"/> to be able to write and read any models that implement <see cref="IJsonModel{T}"/>.
/// </summary>
/// <remarks>
/// Since <see cref="IJsonModel{T}"/> defines what the serialized shape should look like the <see cref="JsonSerializerOptions"/> are ignored
/// except for those pertaining to indentation formatting.
/// </remarks>
[RequiresUnreferencedCode("The constructors of the type being deserialized are dynamically accessed and may be trimmed.")]
#pragma warning disable AZC0014 // Avoid using banned types in public API
public class JsonModelConverter : JsonConverter<IJsonModel<object>>
#pragma warning restore AZC0014 // Avoid using banned types in public API
{
    /// <summary>
    /// Gets the <see cref="ModelReaderWriterOptions"/> used to read and write models.
    /// </summary>
    private ModelReaderWriterOptions _options { get; }

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
        _options = options;
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
        var iJsonModel = ModelReaderWriter.GetObjectInstance(typeToConvert) as IJsonModel<object>;
        if (iJsonModel is null)
        {
            throw new InvalidOperationException($"Either {typeToConvert.Name} or the PersistableModelProxyAttribute defined needs to implement IJsonModel.");
        }
        return (IJsonModel<object>)iJsonModel.Create(ref reader, _options);
    }

    /// <inheritdoc/>
#pragma warning disable AZC0014 // Avoid using banned types in public API
    public override void Write(Utf8JsonWriter writer, IJsonModel<object> value, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
    {
        value.Write(writer, _options);
    }
}
