// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Routing Configuration indicating the associated and propagated route tables for this connection. </summary>
    public partial class RoutingConfiguration : RoutingConfigurationNfv, IJsonModel<RoutingConfiguration>, IPersistableModel<RoutingConfiguration>
    {
        /// <summary> Initializes a new instance of <see cref="RoutingConfiguration"/>. </summary>
        public RoutingConfiguration()
        {
        }

        /// <summary> The propagated route tables. </summary>
        [Azure.ResourceManager.Network.WirePath("propagatedRouteTables")]
        public new PropagatedRouteTable PropagatedRouteTables { get; set; }

        RoutingConfiguration IJsonModel<RoutingConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new RoutingConfiguration();
        void IJsonModel<RoutingConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<RoutingConfigurationNfv>)this).Write(writer, options);
        RoutingConfiguration IPersistableModel<RoutingConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options) => new RoutingConfiguration();
        string IPersistableModel<RoutingConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<RoutingConfiguration>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<RoutingConfigurationNfv>)this).Write(options);
    }
}
