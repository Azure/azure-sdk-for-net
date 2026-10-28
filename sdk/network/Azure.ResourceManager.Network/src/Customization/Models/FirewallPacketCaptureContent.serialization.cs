// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Network.Models
{
    public partial class FirewallPacketCaptureContent : IJsonModel<FirewallPacketCaptureContent>
    {
        // The 1.15 legacy model only supports conversion through ToNewRequestContent.
        FirewallPacketCaptureContent IJsonModel<FirewallPacketCaptureContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        FirewallPacketCaptureContent IPersistableModel<FirewallPacketCaptureContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        string IPersistableModel<FirewallPacketCaptureContent>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        void IJsonModel<FirewallPacketCaptureContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        BinaryData IPersistableModel<FirewallPacketCaptureContent>.Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
