// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Monitor.Models
{
    // TypeSpec no longer models the legacy AlertRule data-source hierarchy.
    // Keep this obsolete derived type so the stable RuleDataSource polymorphic API remains loadable.
    /// <summary> A management event alert rule data source. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class RuleManagementEventDataSource : RuleDataSource, IJsonModel<RuleManagementEventDataSource>, IPersistableModel<RuleManagementEventDataSource>
    {
        /// <summary> Initializes a new instance of <see cref="RuleManagementEventDataSource"/>. </summary>
        public RuleManagementEventDataSource()
        {
        }

        /// <summary> The claims email address. </summary>
        public string ClaimsEmailAddress { get; set; }

        /// <summary> The event name. </summary>
        public string EventName { get; set; }

        /// <summary> The event source. </summary>
        public string EventSource { get; set; }

        /// <summary> The level. </summary>
        public string Level { get; set; }

        /// <summary> The operation name. </summary>
        public string OperationName { get; set; }

        /// <summary> The resource group name. </summary>
        public string ResourceGroupName { get; set; }

        /// <summary> The resource provider name. </summary>
        public string ResourceProviderName { get; set; }

        /// <summary> The status. </summary>
        public string Status { get; set; }

        /// <summary> The sub-status. </summary>
        public string SubStatus { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        RuleManagementEventDataSource IJsonModel<RuleManagementEventDataSource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<RuleManagementEventDataSource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        RuleManagementEventDataSource IPersistableModel<RuleManagementEventDataSource>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<RuleManagementEventDataSource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<RuleManagementEventDataSource>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}
