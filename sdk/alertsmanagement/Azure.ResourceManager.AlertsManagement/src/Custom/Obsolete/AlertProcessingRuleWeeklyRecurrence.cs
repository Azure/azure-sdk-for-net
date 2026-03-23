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
    /// <summary> Backward compatibility stub. This type is no longer supported. </summary>
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AlertProcessingRuleWeeklyRecurrence : AlertProcessingRuleRecurrence, IJsonModel<AlertProcessingRuleWeeklyRecurrence>, IPersistableModel<AlertProcessingRuleWeeklyRecurrence>
    {
        /// <summary> Initializes a new instance. </summary>
        /// <param name="daysOfWeek"> The days of week. </param>
        public AlertProcessingRuleWeeklyRecurrence(IEnumerable<AlertsManagementDayOfWeek> daysOfWeek) { throw new NotSupportedException(); }

        /// <summary> Gets the days of week. </summary>
        public IList<AlertsManagementDayOfWeek> DaysOfWeek { get { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleWeeklyRecurrence IJsonModel<AlertProcessingRuleWeeklyRecurrence>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleWeeklyRecurrence>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleWeeklyRecurrence IPersistableModel<AlertProcessingRuleWeeklyRecurrence>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleWeeklyRecurrence>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleWeeklyRecurrence>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
