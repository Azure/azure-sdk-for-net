// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

#pragma warning disable SA1402 // Compatibility shims for multiple removed GA types are grouped intentionally.
namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility alias for propagated route table. </summary>
    public partial class PropagatedRouteTable : PropagatedRouteTableNfv, IJsonModel<PropagatedRouteTable>, IPersistableModel<PropagatedRouteTable>
    {
        /// <summary> Initializes a new instance of <see cref="PropagatedRouteTable"/>. </summary>
        public PropagatedRouteTable()
        {
            Ids = new List<WritableSubResource>();
        }

        /// <summary> Route table resource identifiers. </summary>
        [Azure.ResourceManager.Network.WirePath("ids")]
        public new IList<WritableSubResource> Ids { get; }

        PropagatedRouteTable IJsonModel<PropagatedRouteTable>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new PropagatedRouteTable();
        void IJsonModel<PropagatedRouteTable>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<PropagatedRouteTableNfv>)this).Write(writer, options);
        PropagatedRouteTable IPersistableModel<PropagatedRouteTable>.Create(BinaryData data, ModelReaderWriterOptions options) => new PropagatedRouteTable();
        string IPersistableModel<PropagatedRouteTable>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<PropagatedRouteTable>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<PropagatedRouteTableNfv>)this).Write(options);
    }
}
