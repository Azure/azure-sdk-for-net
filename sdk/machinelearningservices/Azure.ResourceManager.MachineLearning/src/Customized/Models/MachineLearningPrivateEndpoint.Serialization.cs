// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
<<<<<<<< HEAD:sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/src/Customized/Models/MachineLearningPrivateEndpoint.Serialization.cs
    public partial class MachineLearningPrivateEndpoint : IUtf8JsonSerializable, IJsonModel<MachineLearningPrivateEndpoint>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MachineLearningPrivateEndpoint>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<MachineLearningPrivateEndpoint>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MachineLearningPrivateEndpoint>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MachineLearningPrivateEndpoint)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format != "W" && Optional.IsDefined(SubnetArmId))
            {
                writer.WritePropertyName("subnetArmId"u8);
                writer.WriteStringValue(SubnetArmId);
========
    public partial class ComputeSkuProfile : IUtf8JsonSerializable, IJsonModel<ComputeSkuProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ComputeSkuProfile>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ComputeSkuProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeSkuProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComputeSkuProfile)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(VmSizes))
            {
                writer.WritePropertyName("vmSizes"u8);
                writer.WriteStartArray();
                foreach (var item in VmSizes)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(AllocationStrategy))
            {
                writer.WritePropertyName("allocationStrategy"u8);
                writer.WriteStringValue(AllocationStrategy.Value.ToString());
>>>>>>>> 3f8cf30a3ebe61cfdd08f1bbe8fa5494eda0e9f7:sdk/compute/Azure.ResourceManager.Compute/src/Generated/Models/ComputeSkuProfile.Serialization.cs
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
            writer.WriteEndObject();
        }

<<<<<<<< HEAD:sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/src/Customized/Models/MachineLearningPrivateEndpoint.Serialization.cs
        MachineLearningPrivateEndpoint IJsonModel<MachineLearningPrivateEndpoint>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MachineLearningPrivateEndpoint>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MachineLearningPrivateEndpoint)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningPrivateEndpoint(document.RootElement, options);
        }

        internal static MachineLearningPrivateEndpoint DeserializeMachineLearningPrivateEndpoint(JsonElement element, ModelReaderWriterOptions options = null)
========
        ComputeSkuProfile IJsonModel<ComputeSkuProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeSkuProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComputeSkuProfile)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeComputeSkuProfile(document.RootElement, options);
        }

        internal static ComputeSkuProfile DeserializeComputeSkuProfile(JsonElement element, ModelReaderWriterOptions options = null)
>>>>>>>> 3f8cf30a3ebe61cfdd08f1bbe8fa5494eda0e9f7:sdk/compute/Azure.ResourceManager.Compute/src/Generated/Models/ComputeSkuProfile.Serialization.cs
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
<<<<<<<< HEAD:sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/src/Customized/Models/MachineLearningPrivateEndpoint.Serialization.cs
            ResourceIdentifier id = default;
            ResourceIdentifier subnetArmId = default;
========
            IList<ComputeSkuProfileVmSize> vmSizes = default;
            ComputeAllocationStrategy? allocationStrategy = default;
>>>>>>>> 3f8cf30a3ebe61cfdd08f1bbe8fa5494eda0e9f7:sdk/compute/Azure.ResourceManager.Compute/src/Generated/Models/ComputeSkuProfile.Serialization.cs
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
<<<<<<<< HEAD:sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/src/Customized/Models/MachineLearningPrivateEndpoint.Serialization.cs
                if (property.NameEquals("id"u8))
========
                if (property.NameEquals("vmSizes"u8))
>>>>>>>> 3f8cf30a3ebe61cfdd08f1bbe8fa5494eda0e9f7:sdk/compute/Azure.ResourceManager.Compute/src/Generated/Models/ComputeSkuProfile.Serialization.cs
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
<<<<<<<< HEAD:sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/src/Customized/Models/MachineLearningPrivateEndpoint.Serialization.cs
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("subnetArmId"u8))
========
                    List<ComputeSkuProfileVmSize> array = new List<ComputeSkuProfileVmSize>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ComputeSkuProfileVmSize.DeserializeComputeSkuProfileVmSize(item, options));
                    }
                    vmSizes = array;
                    continue;
                }
                if (property.NameEquals("allocationStrategy"u8))
>>>>>>>> 3f8cf30a3ebe61cfdd08f1bbe8fa5494eda0e9f7:sdk/compute/Azure.ResourceManager.Compute/src/Generated/Models/ComputeSkuProfile.Serialization.cs
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
<<<<<<<< HEAD:sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/src/Customized/Models/MachineLearningPrivateEndpoint.Serialization.cs
                    subnetArmId = new ResourceIdentifier(property.Value.GetString());
========
                    allocationStrategy = new ComputeAllocationStrategy(property.Value.GetString());
>>>>>>>> 3f8cf30a3ebe61cfdd08f1bbe8fa5494eda0e9f7:sdk/compute/Azure.ResourceManager.Compute/src/Generated/Models/ComputeSkuProfile.Serialization.cs
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
<<<<<<<< HEAD:sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/src/Customized/Models/MachineLearningPrivateEndpoint.Serialization.cs
            return new MachineLearningPrivateEndpoint(id, subnetArmId, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MachineLearningPrivateEndpoint>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MachineLearningPrivateEndpoint>)this).GetFormatFromOptions(options) : options.Format;
========
            return new ComputeSkuProfile(vmSizes ?? new ChangeTrackingList<ComputeSkuProfileVmSize>(), allocationStrategy, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ComputeSkuProfile>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeSkuProfile>)this).GetFormatFromOptions(options) : options.Format;
>>>>>>>> 3f8cf30a3ebe61cfdd08f1bbe8fa5494eda0e9f7:sdk/compute/Azure.ResourceManager.Compute/src/Generated/Models/ComputeSkuProfile.Serialization.cs

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
<<<<<<<< HEAD:sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/src/Customized/Models/MachineLearningPrivateEndpoint.Serialization.cs
                    throw new FormatException($"The model {nameof(MachineLearningPrivateEndpoint)} does not support writing '{options.Format}' format.");
            }
        }

        MachineLearningPrivateEndpoint IPersistableModel<MachineLearningPrivateEndpoint>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MachineLearningPrivateEndpoint>)this).GetFormatFromOptions(options) : options.Format;
========
                    throw new FormatException($"The model {nameof(ComputeSkuProfile)} does not support writing '{options.Format}' format.");
            }
        }

        ComputeSkuProfile IPersistableModel<ComputeSkuProfile>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComputeSkuProfile>)this).GetFormatFromOptions(options) : options.Format;
>>>>>>>> 3f8cf30a3ebe61cfdd08f1bbe8fa5494eda0e9f7:sdk/compute/Azure.ResourceManager.Compute/src/Generated/Models/ComputeSkuProfile.Serialization.cs

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
<<<<<<<< HEAD:sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/src/Customized/Models/MachineLearningPrivateEndpoint.Serialization.cs
                        return DeserializeMachineLearningPrivateEndpoint(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningPrivateEndpoint)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningPrivateEndpoint>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
========
                        return DeserializeComputeSkuProfile(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ComputeSkuProfile)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ComputeSkuProfile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
>>>>>>>> 3f8cf30a3ebe61cfdd08f1bbe8fa5494eda0e9f7:sdk/compute/Azure.ResourceManager.Compute/src/Generated/Models/ComputeSkuProfile.Serialization.cs
    }
}
