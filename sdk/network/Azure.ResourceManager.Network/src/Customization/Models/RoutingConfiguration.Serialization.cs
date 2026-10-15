// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Network.Models
{
    public partial class RoutingConfiguration
    {
        // The legacy reader must populate native routing storage for its flattened facade.
        RoutingConfiguration IJsonModel<RoutingConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => Wrap(base.JsonModelCreateCore(ref reader, options));

        RoutingConfiguration IPersistableModel<RoutingConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
            => Wrap(base.PersistableModelCreateCore(data, options));

        private static RoutingConfiguration Wrap(RoutingConfigurationNfv model)
            => model is null ? null : new RoutingConfiguration(model);

        // Calling the covariant interface on this derived model would dispatch back here.
        void IJsonModel<RoutingConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            base.JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }
        string IPersistableModel<RoutingConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<RoutingConfiguration>.Write(ModelReaderWriterOptions options) => base.PersistableModelWriteCore(options);
    }
}
