// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceRoleData : ResourceData, IJsonModel<CloudServiceRoleData>, IPersistableModel<CloudServiceRoleData>
    {
        /// <summary> Initializes a new instance of CloudServiceRoleData for deserialization. </summary>
        internal CloudServiceRoleData()
        {
        }

        /// <summary> The location. </summary>
        public AzureLocation? Location { get; }

        /// <summary> The SKU. </summary>
        public CloudServiceRoleSku Sku { get; }

        /// <summary> The unique identifier. </summary>
        public string UniqueId { get; }

        CloudServiceRoleData IJsonModel<CloudServiceRoleData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<CloudServiceRoleData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceRoleData IPersistableModel<CloudServiceRoleData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<CloudServiceRoleData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<CloudServiceRoleData>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
