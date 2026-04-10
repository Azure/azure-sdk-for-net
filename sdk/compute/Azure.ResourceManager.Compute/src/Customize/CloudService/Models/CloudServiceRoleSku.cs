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
    public partial class CloudServiceRoleSku : IJsonModel<CloudServiceRoleSku>, IPersistableModel<CloudServiceRoleSku>
    {
        /// <summary> Initializes a new instance of CloudServiceRoleSku. </summary>
        public CloudServiceRoleSku()
        {
        }

        /// <summary> The name. </summary>
        public string Name { get; set; }

        /// <summary> The tier. </summary>
        public string Tier { get; set; }

        /// <summary> The capacity. </summary>
        public long? Capacity { get; set; }

        CloudServiceRoleSku IJsonModel<CloudServiceRoleSku>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<CloudServiceRoleSku>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceRoleSku IPersistableModel<CloudServiceRoleSku>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<CloudServiceRoleSku>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<CloudServiceRoleSku>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
