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
    public partial class AlertProcessingRuleMonthlyRecurrence : AlertProcessingRuleRecurrence, IJsonModel<AlertProcessingRuleMonthlyRecurrence>, IPersistableModel<AlertProcessingRuleMonthlyRecurrence>
    {
        /// <summary> Initializes a new instance. </summary>
        /// <param name="daysOfMonth"> The days of month. </param>
        public AlertProcessingRuleMonthlyRecurrence(IEnumerable<int> daysOfMonth) { throw new NotSupportedException(); }

        /// <summary> Gets the days of month. </summary>
        public IList<int> DaysOfMonth { get { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleMonthlyRecurrence IJsonModel<AlertProcessingRuleMonthlyRecurrence>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleMonthlyRecurrence>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleMonthlyRecurrence IPersistableModel<AlertProcessingRuleMonthlyRecurrence>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleMonthlyRecurrence>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleMonthlyRecurrence>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
