﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Net.ClientModel.Core
{
    /// <summary>
    /// A generic converter which allows <see cref="JsonSerializer"/> to be able to write and read any models that implement <see cref="IJsonModel{T}"/>.
    /// </summary>
#if !NET5_0 // RequiresUnreferencedCode in net5.0 doesn't have AttributeTargets.Class as a target, but it was added in net6.0
    [RequiresUnreferencedCode("The constructors of the type being deserialized are dynamically accessed and may be trimmed.")]
#endif
    public class ModelJsonConverter : JsonConverter<IJsonModel<object>>
    {
        /// <summary>
        /// Gets the <see cref="ModelReaderWriterOptions"/> used to read and write models.
        /// </summary>
        public ModelReaderWriterOptions ModelReaderWriterOptions { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ModelJsonConverter"/> with a default format of <see cref="ModelReaderWriterFormat.Json"/>.
        /// </summary>
        public ModelJsonConverter()
            : this(ModelReaderWriterFormat.Json) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ModelJsonConverter"/>.
        /// </summary>
        /// <param name="format"> The format to write to and read from. </param>
        public ModelJsonConverter(ModelReaderWriterFormat format)
            : this(ModelReaderWriterOptions.GetOptions(format)) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ModelJsonConverter"/>.
        /// </summary>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        public ModelJsonConverter(ModelReaderWriterOptions options)
        {
            ModelReaderWriterOptions = options;
        }

        /// <inheritdoc/>
        public override bool CanConvert(Type typeToConvert)
        {
            return !Attribute.IsDefined(typeToConvert, typeof(JsonConverterAttribute));
        }

        /// <inheritdoc/>
        public override IJsonModel<object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return (IJsonModel<object>)ModelReaderWriter.Read(BinaryData.FromString(document.RootElement.GetRawText()), typeToConvert, ModelReaderWriterOptions)!;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, IJsonModel<object> value, JsonSerializerOptions options)
        {
            value.Write(writer, ModelReaderWriterOptions);
        }
    }
}
