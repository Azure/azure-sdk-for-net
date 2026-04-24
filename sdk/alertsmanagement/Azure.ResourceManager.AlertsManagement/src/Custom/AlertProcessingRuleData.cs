// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.AlertsManagement.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AlertsManagement
{
    /// <summary> Backward compatibility stub. The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release. </summary>
    [Obsolete("The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AlertProcessingRuleData : TrackedResourceData, IJsonModel<AlertProcessingRuleData>, IPersistableModel<AlertProcessingRuleData>
    {
        /// <summary> Initializes a new instance. </summary>
        /// <param name="location"> The location. </param>
        public AlertProcessingRuleData(AzureLocation location) : base(location) { }

        /// <summary> Gets or sets the properties. </summary>
        public AlertProcessingRuleProperties Properties { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleData IJsonModel<AlertProcessingRuleData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleData IPersistableModel<AlertProcessingRuleData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
