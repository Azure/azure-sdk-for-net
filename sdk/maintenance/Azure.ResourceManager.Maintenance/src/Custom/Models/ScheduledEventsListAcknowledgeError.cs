// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.Maintenance;

namespace Azure.ResourceManager.Maintenance.Models
{
    /// <summary> An error response received from the Azure Maintenance service when acknowledging scheduled events. </summary>
    public partial class ScheduledEventsListAcknowledgeError : IJsonModel<ScheduledEventsListAcknowledgeError>
    {
        internal ScheduledEventsListAcknowledgeError()
        {
        }

        internal ScheduledEventsListAcknowledgeError(
            ScheduledEventsListAcknowledgeErrorDetails error,
            IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Error = error;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The error response details. </summary>
        public ScheduledEventsListAcknowledgeErrorDetails Error { get; }

        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        BinaryData IPersistableModel<ScheduledEventsListAcknowledgeError>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(this, options, AzureResourceManagerMaintenanceContext.Default);

        ScheduledEventsListAcknowledgeError IPersistableModel<ScheduledEventsListAcknowledgeError>.Create(BinaryData data, ModelReaderWriterOptions options) => ScheduledEventsAcknowledgeErrorSerializer.DeserializeListError(data, options);

        string IPersistableModel<ScheduledEventsListAcknowledgeError>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<ScheduledEventsListAcknowledgeError>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ScheduledEventsAcknowledgeErrorSerializer.Write(writer, this, options, _additionalBinaryDataProperties);

        ScheduledEventsListAcknowledgeError IJsonModel<ScheduledEventsListAcknowledgeError>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ScheduledEventsAcknowledgeErrorSerializer.DeserializeListError(ref reader, options);
    }
}