// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Confluent.Models
{
    /// <summary>
    /// Backward-compatible shim for the SCClusterRecord type that existed in v1.2.1.
    /// In the new SDK, cluster records are modeled as ARM resources (see <see cref="SCClusterRecordData"/>).
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SCClusterRecord : IJsonModel<SCClusterRecord>, IPersistableModel<SCClusterRecord>
    {
        internal SCClusterRecord()
        {
        }

        internal SCClusterRecord(string kind, string id, string name, SCMetadataEntity metadata, SCClusterSpecEntity spec, ClusterStatusEntity status)
        {
            Kind = kind;
            Id = id;
            Name = name;
            Metadata = metadata;
            Spec = spec;
            Status = status;
        }

        /// <summary> Id of the cluster. </summary>
        public string Id { get; }

        /// <summary> Type of cluster. </summary>
        public string Kind { get; }

        /// <summary> Metadata of the record. </summary>
        public SCMetadataEntity Metadata { get; }

        /// <summary> Name of the cluster. </summary>
        public string Name { get; }

        /// <summary> Specification of the cluster. </summary>
        public SCClusterSpecEntity Spec { get; }

        /// <summary> Specification of the cluster status. </summary>
        public ClusterStatusEntity Status { get; }

        internal static SCClusterRecord FromData(SCClusterRecordData data)
        {
            if (data == null)
            {
                return null;
            }
            return new SCClusterRecord(
                data.Kind,
                data.Id?.ToString(),
                data.Name,
                data.Metadata,
                data.Spec,
                data.Status);
        }

        /// <summary> Serialization is not supported for this backward-compatible type. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SCClusterRecord serialization is not supported. Use SCClusterRecordData instead.");
        }

        SCClusterRecord IJsonModel<SCClusterRecord>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SCClusterRecord deserialization is not supported. Use SCClusterRecordData instead.");
        }

        void IJsonModel<SCClusterRecord>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            JsonModelWriteCore(writer, options);
        }

        SCClusterRecord IPersistableModel<SCClusterRecord>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SCClusterRecord deserialization is not supported. Use SCClusterRecordData instead.");
        }

        string IPersistableModel<SCClusterRecord>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<SCClusterRecord>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("SCClusterRecord serialization is not supported. Use SCClusterRecordData instead.");
        }
    }
}
