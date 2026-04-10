// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class UpdateDomainIdentifier : IJsonModel<UpdateDomainIdentifier>, IPersistableModel<UpdateDomainIdentifier>
    {
        /// <summary> Initializes a new instance of UpdateDomainIdentifier. </summary>
        public UpdateDomainIdentifier()
        {
        }

        /// <summary> The resource ID. </summary>
        public ResourceIdentifier Id { get; }

        /// <summary> The name. </summary>
        public string Name { get; }

        UpdateDomainIdentifier IJsonModel<UpdateDomainIdentifier>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<UpdateDomainIdentifier>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        UpdateDomainIdentifier IPersistableModel<UpdateDomainIdentifier>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<UpdateDomainIdentifier>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<UpdateDomainIdentifier>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
