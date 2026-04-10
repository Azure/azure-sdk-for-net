// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceRoleProfileProperties : IJsonModel<CloudServiceRoleProfileProperties>, IPersistableModel<CloudServiceRoleProfileProperties>
    {
        /// <summary> Initializes a new instance of CloudServiceRoleProfileProperties. </summary>
        public CloudServiceRoleProfileProperties()
        {
        }

        /// <summary> The name. </summary>
        public string Name { get; set; }

        /// <summary> The SKU. </summary>
        public CloudServiceRoleSku Sku { get; set; }

        CloudServiceRoleProfileProperties IJsonModel<CloudServiceRoleProfileProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<CloudServiceRoleProfileProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceRoleProfileProperties IPersistableModel<CloudServiceRoleProfileProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<CloudServiceRoleProfileProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<CloudServiceRoleProfileProperties>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
