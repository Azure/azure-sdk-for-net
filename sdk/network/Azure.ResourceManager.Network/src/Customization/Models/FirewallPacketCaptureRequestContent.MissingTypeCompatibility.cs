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
    /// <summary> Compatibility alias for firewall packet capture request content. </summary>
    public partial class FirewallPacketCaptureRequestContent : FirewallPacketCaptureContent, IJsonModel<FirewallPacketCaptureRequestContent>, IPersistableModel<FirewallPacketCaptureRequestContent>
    {
        /// <summary> Initializes a new instance of <see cref="FirewallPacketCaptureRequestContent"/>. </summary>
        public FirewallPacketCaptureRequestContent()
        {
        }

        FirewallPacketCaptureRequestContent IJsonModel<FirewallPacketCaptureRequestContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new FirewallPacketCaptureRequestContent();
        void IJsonModel<FirewallPacketCaptureRequestContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<FirewallPacketCaptureContent>)this).Write(writer, options);
        FirewallPacketCaptureRequestContent IPersistableModel<FirewallPacketCaptureRequestContent>.Create(BinaryData data, ModelReaderWriterOptions options) => new FirewallPacketCaptureRequestContent();
        string IPersistableModel<FirewallPacketCaptureRequestContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<FirewallPacketCaptureRequestContent>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<FirewallPacketCaptureContent>)this).Write(options);

        /// <summary> Writes the model as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<FirewallPacketCaptureContent>)this).Write(writer, options);
    }
}
