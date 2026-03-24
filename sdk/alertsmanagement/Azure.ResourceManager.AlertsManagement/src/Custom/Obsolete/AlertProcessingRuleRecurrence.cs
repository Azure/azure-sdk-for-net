// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Backward compatibility stub. This type is no longer supported. </summary>
    [PersistableModelProxy(typeof(UnknownRecurrence))]
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract partial class AlertProcessingRuleRecurrence : IJsonModel<AlertProcessingRuleRecurrence>, IPersistableModel<AlertProcessingRuleRecurrence>
    {
        /// <summary> Initializes a new instance. </summary>
        protected AlertProcessingRuleRecurrence() { }

        /// <summary> Gets or sets the end time. </summary>
        public TimeSpan? EndOn { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the start time. </summary>
        public TimeSpan? StartOn { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleRecurrence IJsonModel<AlertProcessingRuleRecurrence>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleRecurrence>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleRecurrence IPersistableModel<AlertProcessingRuleRecurrence>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleRecurrence>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleRecurrence>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
