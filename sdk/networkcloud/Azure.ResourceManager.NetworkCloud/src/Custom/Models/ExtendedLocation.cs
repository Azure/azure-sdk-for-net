// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Backward-compat shim for ExtendedLocation.
    //
    // Root cause: The old Swagger defined ExtendedLocation as a local model in definitions
    // (with two string properties: "name" and "type"), NOT as a $ref to the ARM common type.
    // AutoRest therefore generated a local Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation
    // class with string Name and string ExtendedLocationType properties.
    //
    // In the new TypeSpec spec, the same concept uses Foundations.ExtendedLocation (the ARM
    // common type). The C# MPG generator recognizes this as a known ARM common type and maps
    // it directly to Azure.ResourceManager.Resources.Models.ExtendedLocation — no local type
    // is generated.
    //
    // The ARM common type differs from the old local type:
    //   - Namespace: Azure.ResourceManager.Resources.Models vs Azure.ResourceManager.NetworkCloud.Models
    //   - ExtendedLocationType property: ExtendedLocationType? (struct enum) vs string
    //   - Constructor: parameterless only vs (string name, string extendedLocationType)
    //
    // This shim preserves the old public API surface (namespace, constructor, string property
    // types, and IJsonModel serialization) to avoid breaking changes for existing consumers.

    /// <summary> The complex type of the extended location. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ExtendedLocation : IUtf8JsonSerializable, IJsonModel<ExtendedLocation>
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ExtendedLocation"/>. </summary>
        /// <param name="name"> The resource ID of the extended location on which the resource will be created. </param>
        /// <param name="extendedLocationType"> The extended location type, for example, CustomLocation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="extendedLocationType"/> is null. </exception>
        public ExtendedLocation(string name, string extendedLocationType)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(extendedLocationType, nameof(extendedLocationType));

            Name = name;
            ExtendedLocationType = extendedLocationType;
        }

        /// <summary> Initializes a new instance of <see cref="ExtendedLocation"/>. </summary>
        /// <param name="name"> The resource ID of the extended location on which the resource will be created. </param>
        /// <param name="extendedLocationType"> The extended location type, for example, CustomLocation. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ExtendedLocation(string name, string extendedLocationType, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            ExtendedLocationType = extendedLocationType;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ExtendedLocation"/> for deserialization. </summary>
        internal ExtendedLocation()
        {
        }

        /// <summary> The resource ID of the extended location on which the resource will be created. </summary>
        public string Name { get; set; }
        /// <summary> The extended location type, for example, CustomLocation. </summary>
        public string ExtendedLocationType { get; set; }

        /// <summary>
        /// Implicit conversion to <see cref="Azure.ResourceManager.Resources.Models.ExtendedLocation"/>
        /// so that generated backward-compat ModelFactory methods can pass this local type where the
        /// ARM common type is expected.
        /// </summary>
        public static implicit operator Azure.ResourceManager.Resources.Models.ExtendedLocation(ExtendedLocation value)
        {
            if (value == null) return null;
            return new Azure.ResourceManager.Resources.Models.ExtendedLocation
            {
                Name = value.Name,
                ExtendedLocationType = value.ExtendedLocationType != null
                    ? new Azure.ResourceManager.Resources.Models.ExtendedLocationType(value.ExtendedLocationType)
                    : (Azure.ResourceManager.Resources.Models.ExtendedLocationType?)null
            };
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ExtendedLocation>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ExtendedLocation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendedLocation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtendedLocation)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(ExtendedLocationType);
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        ExtendedLocation IJsonModel<ExtendedLocation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendedLocation>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtendedLocation)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeExtendedLocation(document.RootElement, options);
        }

        internal static ExtendedLocation DeserializeExtendedLocation(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string type = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ExtendedLocation(name, type, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ExtendedLocation>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendedLocation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerNetworkCloudContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ExtendedLocation)} does not support writing '{options.Format}' format.");
            }
        }

        ExtendedLocation IPersistableModel<ExtendedLocation>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendedLocation>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeExtendedLocation(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ExtendedLocation)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ExtendedLocation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
