// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> The diagnostic setting resource. </summary>
    [CodeGenSuppress("DiagnosticSettingData")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class DiagnosticSettingData : ResourceData, IJsonModel<DiagnosticSettingData>, IPersistableModel<DiagnosticSettingData>
    {
        /// <summary> Initializes a new instance of <see cref="DiagnosticSettingData"/>. </summary>
        public DiagnosticSettingData()
        {
            Metrics = new ChangeTrackingList<MetricSettings>();
            Logs = new ChangeTrackingList<LogSettings>();
        }

        /// <summary> The resource ID of the storage account to which you would like to send Diagnostic Logs. </summary>
        public ResourceIdentifier StorageAccountId { get; set; }

        /// <summary> The service bus rule Id of the diagnostic setting. This is here to maintain backwards compatibility. </summary>
        public ResourceIdentifier ServiceBusRuleId { get; set; }

        /// <summary> The resource Id for the event hub authorization rule. </summary>
        public ResourceIdentifier EventHubAuthorizationRuleId { get; set; }

        /// <summary> The name of the event hub. If none is specified, the default event hub will be selected. </summary>
        public string EventHubName { get; set; }

        /// <summary> The list of metric settings. </summary>
        public IList<MetricSettings> Metrics { get; }

        /// <summary> The list of logs settings. </summary>
        public IList<LogSettings> Logs { get; }

        /// <summary> The full ARM resource ID of the Log Analytics workspace to which you would like to send Diagnostic Logs. </summary>
        public ResourceIdentifier WorkspaceId { get; set; }

        /// <summary> A string indicating whether the export to Log Analytics should use the default destination type. </summary>
        public string LogAnalyticsDestinationType { get; set; }

        /// <summary> The full ARM resource ID of the Marketplace resource to which you would like to send Diagnostic Logs. </summary>
        public ResourceIdentifier MarketplacePartnerId { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DiagnosticSettingData IJsonModel<DiagnosticSettingData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<DiagnosticSettingData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DiagnosticSettingData IPersistableModel<DiagnosticSettingData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<DiagnosticSettingData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<DiagnosticSettingData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}
