// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The private endpoint resource. </summary>
    public partial class RegistryPrivateEndpoint : PrivateEndpointBase, IJsonModel<RegistryPrivateEndpoint>
    {
        /// <summary> Initializes a new instance of <see cref="RegistryPrivateEndpoint"/>. </summary>
        public RegistryPrivateEndpoint()
        {
        }

        /// <summary> Initializes a new instance of <see cref="RegistryPrivateEndpoint"/>. </summary>
        /// <param name="id"> The resource identifier of the private endpoint. </param>
        public RegistryPrivateEndpoint(ResourceIdentifier id)
        {
            Id = id;
        }

        /// <summary> The resource identifier of the private endpoint. </summary>
        public new ResourceIdentifier Id { get; set; }

        void IJsonModel<RegistryPrivateEndpoint>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<PrivateEndpointBase>)this).Write(writer, options);
        }

        RegistryPrivateEndpoint IJsonModel<RegistryPrivateEndpoint>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            PrivateEndpointBase privateEndpoint = PrivateEndpointBase.DeserializePrivateEndpointBase(document.RootElement, options);
            return privateEndpoint is null ? null : new RegistryPrivateEndpoint(privateEndpoint.Id)
            {
                SubnetArmId = privateEndpoint.SubnetArmId
            };
        }

        BinaryData IPersistableModel<RegistryPrivateEndpoint>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<PrivateEndpointBase>)this).Write(options);
        }

        RegistryPrivateEndpoint IPersistableModel<RegistryPrivateEndpoint>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RegistryPrivateEndpoint>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        PrivateEndpointBase privateEndpoint = PrivateEndpointBase.DeserializePrivateEndpointBase(document.RootElement, options);
                        return privateEndpoint is null ? null : new RegistryPrivateEndpoint(privateEndpoint.Id)
                        {
                            SubnetArmId = privateEndpoint.SubnetArmId
                        };
                    }
                default:
                    throw new FormatException($"The model {nameof(RegistryPrivateEndpoint)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RegistryPrivateEndpoint>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
