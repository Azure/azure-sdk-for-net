// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Backward compatibility stub. The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release. </summary>
    [Obsolete("The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AlertProcessingRuleSchedule : IJsonModel<AlertProcessingRuleSchedule>, IPersistableModel<AlertProcessingRuleSchedule>
    {
        /// <summary> Initializes a new instance. </summary>
        public AlertProcessingRuleSchedule() { throw new NotSupportedException(); }

        /// <summary> Gets or sets the effective from date. </summary>
        public DateTimeOffset? EffectiveFrom { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the effective until date. </summary>
        public DateTimeOffset? EffectiveUntil { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets the recurrences. </summary>
        public IList<AlertProcessingRuleRecurrence> Recurrences { get { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the time zone. </summary>
        public string TimeZone { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleSchedule IJsonModel<AlertProcessingRuleSchedule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleSchedule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleSchedule IPersistableModel<AlertProcessingRuleSchedule>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleSchedule>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleSchedule>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
