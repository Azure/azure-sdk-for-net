// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ConnectionMonitorContent : IJsonModel<ConnectionMonitorContent>
    {
        /// <summary> Reads the compatibility model using the canonical request reader. </summary>
        protected new virtual ConnectionMonitorContent PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options) =>
            base.PersistableModelCreateCore(data, options).ToConnectionMonitorContent();

        /// <summary> Reads the compatibility model using the canonical request reader. </summary>
        protected new virtual ConnectionMonitorContent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) =>
            base.JsonModelCreateCore(ref reader, options).ToConnectionMonitorContent();

        /// <summary> Writes the compatibility model using the canonical request writer. </summary>
        protected new virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<ConnectionMonitorContent>)this).Write(writer, options);
            }
            return BinaryData.FromBytes(stream.ToArray());
        }

        BinaryData IPersistableModel<ConnectionMonitorContent>.Write(ModelReaderWriterOptions options) =>
            PersistableModelWriteCore(options);

        ConnectionMonitorContent IPersistableModel<ConnectionMonitorContent>.Create(BinaryData data, ModelReaderWriterOptions options) =>
            PersistableModelCreateCore(data, options);

        string IPersistableModel<ConnectionMonitorContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<ConnectionMonitorContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            // A covariant interface cast can dispatch back here; use the native body writer directly.
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        ConnectionMonitorContent IJsonModel<ConnectionMonitorContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) =>
            JsonModelCreateCore(ref reader, options);
    }
}
