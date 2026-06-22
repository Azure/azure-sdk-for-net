// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceRoleInstanceData : ResourceData, IJsonModel<CloudServiceRoleInstanceData>, IPersistableModel<CloudServiceRoleInstanceData>
    {
        /// <summary> Initializes a new instance of CloudServiceRoleInstanceData for deserialization. </summary>
        internal CloudServiceRoleInstanceData()
        {
        }

        /// <summary> The location. </summary>
        public AzureLocation? Location { get; }

        /// <summary> The tags. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }

        /// <summary> The SKU. </summary>
        public InstanceSku Sku { get; }

        /// <summary> The instance view. </summary>
        public RoleInstanceView InstanceView { get; }

        /// <summary> The network interfaces. </summary>
        public IReadOnlyList<WritableSubResource> NetworkInterfaces { get; } = new List<WritableSubResource>();

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceRoleInstanceData IJsonModel<CloudServiceRoleInstanceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<CloudServiceRoleInstanceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceRoleInstanceData IPersistableModel<CloudServiceRoleInstanceData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<CloudServiceRoleInstanceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<CloudServiceRoleInstanceData>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
