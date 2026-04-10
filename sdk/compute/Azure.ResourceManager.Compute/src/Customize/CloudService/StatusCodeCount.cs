// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Status code count. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class StatusCodeCount : IJsonModel<StatusCodeCount>, IPersistableModel<StatusCodeCount>
    {
        /// <summary> Initializes a new instance of StatusCodeCount. </summary>
        internal StatusCodeCount() { }

        /// <summary> The instance view status code. </summary>
        public string Code { get; }
        /// <summary> The number of instances having a particular status code. </summary>
        public int? Count { get; }

        StatusCodeCount IJsonModel<StatusCodeCount>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<StatusCodeCount>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        StatusCodeCount IPersistableModel<StatusCodeCount>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<StatusCodeCount>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<StatusCodeCount>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
