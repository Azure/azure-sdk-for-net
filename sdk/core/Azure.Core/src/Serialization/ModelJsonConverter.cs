// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// A generic converter which allows <see cref="JsonSerializer"/> to be able to serialize and deserialize any models that implement <see cref="IModelJsonSerializable{T}"/>.
    /// </summary>
#pragma warning disable AZC0014 // Avoid using banned types in public API
#if !NET5_0 // RequiresUnreferencedCode in net5.0 doesn't have AttributeTargets.Class as a target, but it was added in net6.0
    [RequiresUnreferencedCode("The constructors of the type being deserialized are dynamically accessed and may be trimmed.")]
#endif
    public class ModelJsonConverter : JsonConverter<IModelJsonSerializable<object>>
#pragma warning restore AZC0014 // Avoid using banned types in public API
    {
        /// <summary>
        /// Gets the <see cref="ModelSerializerOptions"/> used to serialize and deserialize models.
        /// </summary>
        public ModelSerializerOptions ModelSerializerOptions { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ModelJsonConverter"/> with a default format of <see cref="ModelSerializerFormat.Json"/>.
        /// </summary>
        public ModelJsonConverter()
            : this(ModelSerializerFormat.Json) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ModelJsonConverter"/>.
        /// </summary>
        /// <param name="format"> The format to serialize to and deserialize from. </param>
        public ModelJsonConverter(ModelSerializerFormat format)
            : this(ModelSerializerOptions.GetOptions(format)) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ModelJsonConverter"/>.
        /// </summary>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        public ModelJsonConverter(ModelSerializerOptions options)
        {
            ModelSerializerOptions = options;
        }

        /// <inheritdoc/>
        public override bool CanConvert(Type typeToConvert)
        {
            return !Attribute.IsDefined(typeToConvert, typeof(JsonConverterAttribute));
        }

        /// <inheritdoc/>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public override IModelJsonSerializable<object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return (IModelJsonSerializable<object>)ModelSerializer.Deserialize(BinaryData.FromString(document.RootElement.GetRawText()), typeToConvert, ModelSerializerOptions)!;
        }

        /// <inheritdoc/>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public override void Write(Utf8JsonWriter writer, IModelJsonSerializable<object> value, JsonSerializerOptions options)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            value.Serialize(writer, ModelSerializerOptions);
        }
    }
}
