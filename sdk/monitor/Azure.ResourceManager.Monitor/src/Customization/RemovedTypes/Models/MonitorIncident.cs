// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> An alert rule incident. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class MonitorIncident : IJsonModel<MonitorIncident>, IPersistableModel<MonitorIncident>
    {
        /// <summary> Initializes a new instance of <see cref="MonitorIncident"/>. </summary>
        public MonitorIncident()
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> The incident name. </summary>
        public string Name { get; }

        /// <summary> The alert rule name. </summary>
        public string RuleName { get; }

        /// <summary> Whether the incident is active. </summary>
        public bool? IsActive { get; }

        /// <summary> The activation time. </summary>
        public DateTimeOffset? ActivatedOn { get; }

        /// <summary> The resolution time. </summary>
        public DateTimeOffset? ResolvedOn { get; }

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<MonitorIncident>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        MonitorIncident IJsonModel<MonitorIncident>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<MonitorIncident>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        MonitorIncident IPersistableModel<MonitorIncident>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<MonitorIncident>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}