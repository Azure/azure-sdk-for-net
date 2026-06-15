// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy monitor private link scope operation status. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class MonitorPrivateLinkScopeOperationStatus : IUtf8JsonSerializable, IJsonModel<MonitorPrivateLinkScopeOperationStatus>, IPersistableModel<MonitorPrivateLinkScopeOperationStatus>
    {
        /// <summary> Initializes a new instance of <see cref="MonitorPrivateLinkScopeOperationStatus"/>. </summary>
        internal MonitorPrivateLinkScopeOperationStatus()
        {
        }

        /// <summary> The operation Id. </summary>
        public string Id { get; }

        /// <summary> The operation name. </summary>
        public string Name { get; }

        /// <summary> Start time of the job in standard ISO8601 format. </summary>
        public DateTimeOffset? StartOn { get; }

        /// <summary> End time of the job in standard ISO8601 format. </summary>
        public DateTimeOffset? EndOn { get; }

        /// <summary> The status of the operation. </summary>
        public string Status { get; }

        /// <summary> The error detail of the operation if any. </summary>
        public ResponseError Error { get; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<MonitorPrivateLinkScopeOperationStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        MonitorPrivateLinkScopeOperationStatus IJsonModel<MonitorPrivateLinkScopeOperationStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<MonitorPrivateLinkScopeOperationStatus>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        MonitorPrivateLinkScopeOperationStatus IPersistableModel<MonitorPrivateLinkScopeOperationStatus>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<MonitorPrivateLinkScopeOperationStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
