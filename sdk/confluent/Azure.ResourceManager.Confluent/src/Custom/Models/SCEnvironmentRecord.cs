// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Confluent.Models
{
    /// <summary>
    /// Backward-compatible shim for the SCEnvironmentRecord type that existed in v1.2.1.
    /// In the new SDK, environment records are modeled as ARM resources (see <see cref="SCEnvironmentRecordData"/>).
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SCEnvironmentRecord : IJsonModel<SCEnvironmentRecord>, IPersistableModel<SCEnvironmentRecord>
    {
        internal SCEnvironmentRecord()
        {
        }

        internal SCEnvironmentRecord(string kind, string id, string name, SCMetadataEntity metadata)
        {
            Kind = kind;
            Id = id;
            Name = name;
            Metadata = metadata;
        }

        /// <summary> Environment id. </summary>
        public string Id { get; }

        /// <summary> Type of environment. </summary>
        public string Kind { get; }

        /// <summary> Metadata of the record. </summary>
        public SCMetadataEntity Metadata { get; }

        /// <summary> Display name of the environment. </summary>
        public string Name { get; }

        internal static SCEnvironmentRecord FromData(SCEnvironmentRecordData data)
        {
            if (data == null)
            {
                return null;
            }
            return new SCEnvironmentRecord(
                data.Kind,
                data.Id?.ToString(),
                data.Name,
                data.Metadata);
        }

        /// <summary> Serialization is not supported for this backward-compatible type. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SCEnvironmentRecord serialization is not supported. Use SCEnvironmentRecordData instead.");
        }

        SCEnvironmentRecord IJsonModel<SCEnvironmentRecord>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SCEnvironmentRecord deserialization is not supported. Use SCEnvironmentRecordData instead.");
        }

        void IJsonModel<SCEnvironmentRecord>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            JsonModelWriteCore(writer, options);
        }

        SCEnvironmentRecord IPersistableModel<SCEnvironmentRecord>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SCEnvironmentRecord deserialization is not supported. Use SCEnvironmentRecordData instead.");
        }

        string IPersistableModel<SCEnvironmentRecord>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<SCEnvironmentRecord>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SCEnvironmentRecord serialization is not supported. Use SCEnvironmentRecordData instead.");
        }
    }
}
