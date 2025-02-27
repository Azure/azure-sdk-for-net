﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
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
#pragma warning disable AZC0014 // Avoid using banned types in public API
public class JsonModelConverter : JsonConverter<IJsonModel<object>>
#pragma warning restore AZC0014 // Avoid using banned types in public API
{
    private ModelReaderWriterOptions _options;
    private ModelReaderWriterContext? _context;

    /// <summary>
    /// Initializes a new instance of <see cref="JsonModelConverter"/> with a default options of <see cref="ModelReaderWriterOptions.Json"/>.
    /// </summary>
    [RequiresUnreferencedCode("The constructors of the type being deserialized are dynamically accessed and may be trimmed.  Use the constructor which takes ModelReaderWriterContext to be compatible with AOT.")]
    public JsonModelConverter()
        : this(ModelReaderWriterOptions.Json) { }

    /// <summary>
    /// Initializes a new instance of <see cref="JsonModelConverter"/>.
    /// </summary>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    [RequiresUnreferencedCode("The constructors of the type being deserialized are dynamically accessed and may be trimmed.  Use the constructor which takes ModelReaderWriterContext to be compatible with AOT.")]
    public JsonModelConverter(ModelReaderWriterOptions options)
    {
        _options = options;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="JsonModelConverter"/> with a <see cref="ModelReaderWriterContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="ModelReaderWriterContext"/> for model construction.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    public JsonModelConverter(ModelReaderWriterContext context, ModelReaderWriterOptions? options = default)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        _context = context;
        _options = options ?? ModelReaderWriterOptions.Json;
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
        IJsonModel<object>? AotCompatActivate()
        {
            var activator = _context.GetModelInfo(typeToConvert);
            if (activator is null)
            {
                throw new InvalidOperationException($"No activator found for {typeToConvert.Name}.");
            }
            return activator.CreateObject() as IJsonModel<object>;
        }

        [UnconditionalSuppressMessage("Trimming", "IL2067",
            Justification = "We will only call this when we went through a constructor that is marked with RequiresUnreferencedCode.")]
        IJsonModel<object>? NonAotCompatActivate()
        {
            Debug.Assert(_context is null, "This should only be called when _context is null.");
            var context = new ReflectionContext();
            return context.GetModelInfo(typeToConvert).CreateObject() as IJsonModel<object>;
        }

        IJsonModel<object>? iJsonModel = _context is null ? NonAotCompatActivate() : AotCompatActivate();

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
