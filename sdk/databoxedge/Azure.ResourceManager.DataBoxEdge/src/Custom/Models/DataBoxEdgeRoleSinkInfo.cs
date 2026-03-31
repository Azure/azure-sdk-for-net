// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: This type was removed in the new generator (flattened to ResourceIdentifier), but baseline API
// exposed it as a standalone type. Recreated for backward compatibility.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    /// <summary> Compute role against which events will be raised. </summary>
    public partial class DataBoxEdgeRoleSinkInfo : IJsonModel<DataBoxEdgeRoleSinkInfo>, IPersistableModel<DataBoxEdgeRoleSinkInfo>
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeRoleSinkInfo"/>. </summary>
        /// <param name="roleId"> Compute role ID. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roleId"/> is null. </exception>
        public DataBoxEdgeRoleSinkInfo(ResourceIdentifier roleId)
        {
            Argument.AssertNotNull(roleId, nameof(roleId));
            RoleId = roleId;
        }

        /// <summary> Compute role ID. </summary>
        public ResourceIdentifier RoleId { get; set; }

        void IJsonModel<DataBoxEdgeRoleSinkInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("roleId"u8);
            writer.WriteStringValue(RoleId);
            writer.WriteEndObject();
        }

        DataBoxEdgeRoleSinkInfo IJsonModel<DataBoxEdgeRoleSinkInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return new DataBoxEdgeRoleSinkInfo(new ResourceIdentifier(doc.RootElement.GetProperty("roleId").GetString()));
        }

        BinaryData IPersistableModel<DataBoxEdgeRoleSinkInfo>.Write(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<DataBoxEdgeRoleSinkInfo>)this).Write(writer, options);
            }
            return new BinaryData(stream.ToArray());
        }

        DataBoxEdgeRoleSinkInfo IPersistableModel<DataBoxEdgeRoleSinkInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return new DataBoxEdgeRoleSinkInfo(new ResourceIdentifier(doc.RootElement.GetProperty("roleId").GetString()));
        }

        string IPersistableModel<DataBoxEdgeRoleSinkInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
