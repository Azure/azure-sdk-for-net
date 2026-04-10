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
    public partial class ResourceInstanceViewStatus : IJsonModel<ResourceInstanceViewStatus>, IPersistableModel<ResourceInstanceViewStatus>
    {
        /// <summary> Initializes a new instance of ResourceInstanceViewStatus for deserialization. </summary>
        internal ResourceInstanceViewStatus()
        {
        }

        /// <summary> The code. </summary>
        public string Code { get; }

        /// <summary> The display status. </summary>
        public string DisplayStatus { get; }

        /// <summary> The level. </summary>
        public ComputeStatusLevelType? Level { get; }

        /// <summary> The message. </summary>
        public string Message { get; }

        /// <summary> The time. </summary>
        public DateTimeOffset? Time { get; }

        ResourceInstanceViewStatus IJsonModel<ResourceInstanceViewStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<ResourceInstanceViewStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        ResourceInstanceViewStatus IPersistableModel<ResourceInstanceViewStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<ResourceInstanceViewStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<ResourceInstanceViewStatus>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
