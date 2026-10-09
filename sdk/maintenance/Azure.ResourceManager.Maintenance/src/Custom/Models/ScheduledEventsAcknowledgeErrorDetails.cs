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
    /// <summary> Details about an acknowledgement error for one scheduled event. </summary>
    public partial class ScheduledEventsAcknowledgeErrorDetails : IJsonModel<ScheduledEventsAcknowledgeErrorDetails>
    {
        internal ScheduledEventsAcknowledgeErrorDetails()
        {
        }

        internal ScheduledEventsAcknowledgeErrorDetails(
            string target,
            string code,
            string message,
            IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Target = target;
            Code = code;
            Message = message;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The scheduled event ID. </summary>
        public string Target { get; }

        /// <summary> The status code for the scheduled-events acknowledgement operation. </summary>
        public string Code { get; }

        /// <summary> The human-readable representation of the error. </summary>
        public string Message { get; }

        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        BinaryData IPersistableModel<ScheduledEventsAcknowledgeErrorDetails>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(this, options, AzureResourceManagerMaintenanceContext.Default);

        ScheduledEventsAcknowledgeErrorDetails IPersistableModel<ScheduledEventsAcknowledgeErrorDetails>.Create(BinaryData data, ModelReaderWriterOptions options) => ScheduledEventsAcknowledgeErrorSerializer.DeserializeErrorDetails(data, options);

        string IPersistableModel<ScheduledEventsAcknowledgeErrorDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<ScheduledEventsAcknowledgeErrorDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ScheduledEventsAcknowledgeErrorSerializer.Write(writer, this, options, _additionalBinaryDataProperties);

        ScheduledEventsAcknowledgeErrorDetails IJsonModel<ScheduledEventsAcknowledgeErrorDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ScheduledEventsAcknowledgeErrorSerializer.DeserializeErrorDetails(ref reader, options);
    }
}
