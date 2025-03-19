// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

<<<<<<<< HEAD:sdk/network/Azure.ResourceManager.Network/src/Generated/Models/IpamPoolPatch.Serialization.cs
namespace Azure.ResourceManager.Network.Models
{
    public partial class IpamPoolPatch : IUtf8JsonSerializable, IJsonModel<IpamPoolPatch>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<IpamPoolPatch>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<IpamPoolPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
========
namespace Azure.ResourceManager.ServiceNetworking.Models
{
    public partial class FrontendPatch : IUtf8JsonSerializable, IJsonModel<FrontendPatch>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<FrontendPatch>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<FrontendPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/Models/FrontendPatch.Serialization.cs
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
<<<<<<<< HEAD:sdk/network/Azure.ResourceManager.Network/src/Generated/Models/IpamPoolPatch.Serialization.cs
            var format = options.Format == "W" ? ((IPersistableModel<IpamPoolPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IpamPoolPatch)} does not support writing '{format}' format.");
========
            var format = options.Format == "W" ? ((IPersistableModel<FrontendPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FrontendPatch)} does not support writing '{format}' format.");
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/Models/FrontendPatch.Serialization.cs
            }

            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

<<<<<<<< HEAD:sdk/network/Azure.ResourceManager.Network/src/Generated/Models/IpamPoolPatch.Serialization.cs
        IpamPoolPatch IJsonModel<IpamPoolPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IpamPoolPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IpamPoolPatch)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIpamPoolPatch(document.RootElement, options);
        }

        internal static IpamPoolPatch DeserializeIpamPoolPatch(JsonElement element, ModelReaderWriterOptions options = null)
========
        FrontendPatch IJsonModel<FrontendPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FrontendPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FrontendPatch)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFrontendPatch(document.RootElement, options);
        }

        internal static FrontendPatch DeserializeFrontendPatch(JsonElement element, ModelReaderWriterOptions options = null)
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/Models/FrontendPatch.Serialization.cs
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, string> tags = default;
<<<<<<<< HEAD:sdk/network/Azure.ResourceManager.Network/src/Generated/Models/IpamPoolPatch.Serialization.cs
            IpamPoolUpdateProperties properties = default;
========
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/Models/FrontendPatch.Serialization.cs
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
<<<<<<<< HEAD:sdk/network/Azure.ResourceManager.Network/src/Generated/Models/IpamPoolPatch.Serialization.cs
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = IpamPoolUpdateProperties.DeserializeIpamPoolUpdateProperties(property.Value, options);
========
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/Models/FrontendPatch.Serialization.cs
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
<<<<<<<< HEAD:sdk/network/Azure.ResourceManager.Network/src/Generated/Models/IpamPoolPatch.Serialization.cs
            return new IpamPoolPatch(tags ?? new ChangeTrackingDictionary<string, string>(), properties, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<IpamPoolPatch>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IpamPoolPatch>)this).GetFormatFromOptions(options) : options.Format;
========
            return new FrontendPatch(tags ?? new ChangeTrackingDictionary<string, string>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<FrontendPatch>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FrontendPatch>)this).GetFormatFromOptions(options) : options.Format;
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/Models/FrontendPatch.Serialization.cs

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
<<<<<<<< HEAD:sdk/network/Azure.ResourceManager.Network/src/Generated/Models/IpamPoolPatch.Serialization.cs
                    throw new FormatException($"The model {nameof(IpamPoolPatch)} does not support writing '{options.Format}' format.");
            }
        }

        IpamPoolPatch IPersistableModel<IpamPoolPatch>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IpamPoolPatch>)this).GetFormatFromOptions(options) : options.Format;
========
                    throw new FormatException($"The model {nameof(FrontendPatch)} does not support writing '{options.Format}' format.");
            }
        }

        FrontendPatch IPersistableModel<FrontendPatch>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<FrontendPatch>)this).GetFormatFromOptions(options) : options.Format;
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/Models/FrontendPatch.Serialization.cs

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
<<<<<<<< HEAD:sdk/network/Azure.ResourceManager.Network/src/Generated/Models/IpamPoolPatch.Serialization.cs
                        return DeserializeIpamPoolPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(IpamPoolPatch)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<IpamPoolPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
========
                        return DeserializeFrontendPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FrontendPatch)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FrontendPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
>>>>>>>> main:sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/Models/FrontendPatch.Serialization.cs
    }
}
