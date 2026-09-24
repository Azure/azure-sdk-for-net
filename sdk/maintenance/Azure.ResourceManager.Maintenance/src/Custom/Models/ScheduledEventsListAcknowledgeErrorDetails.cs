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
    /// <summary> Details about a scheduled-events acknowledgement error response. </summary>
    public partial class ScheduledEventsListAcknowledgeErrorDetails : IJsonModel<ScheduledEventsListAcknowledgeErrorDetails>
    {
        internal ScheduledEventsListAcknowledgeErrorDetails()
        {
            Details = new ChangeTrackingList<ScheduledEventsAcknowledgeErrorDetails>();
        }

        internal ScheduledEventsListAcknowledgeErrorDetails(
            string code,
            string message,
            IReadOnlyList<ScheduledEventsAcknowledgeErrorDetails> details,
            IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Code = code;
            Message = message;
            Details = details;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The service-defined error code. </summary>
        public string Code { get; }

        /// <summary> The human-readable representation of the error. </summary>
        public string Message { get; }

        /// <summary> The acknowledgement error details for each scheduled event. </summary>
        public IReadOnlyList<ScheduledEventsAcknowledgeErrorDetails> Details { get; }

        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        BinaryData IPersistableModel<ScheduledEventsListAcknowledgeErrorDetails>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(this, options, AzureResourceManagerMaintenanceContext.Default);

        ScheduledEventsListAcknowledgeErrorDetails IPersistableModel<ScheduledEventsListAcknowledgeErrorDetails>.Create(BinaryData data, ModelReaderWriterOptions options) => ScheduledEventsAcknowledgeErrorSerializer.DeserializeListErrorDetails(data, options);

        string IPersistableModel<ScheduledEventsListAcknowledgeErrorDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<ScheduledEventsListAcknowledgeErrorDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ScheduledEventsAcknowledgeErrorSerializer.Write(writer, this, options, _additionalBinaryDataProperties);

        ScheduledEventsListAcknowledgeErrorDetails IJsonModel<ScheduledEventsListAcknowledgeErrorDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ScheduledEventsAcknowledgeErrorSerializer.DeserializeListErrorDetails(ref reader, options);
    }
}