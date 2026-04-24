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
    public partial class AlertProcessingRuleCondition : IJsonModel<AlertProcessingRuleCondition>, IPersistableModel<AlertProcessingRuleCondition>
    {
        /// <summary> Initializes a new instance. </summary>
        public AlertProcessingRuleCondition() { throw new NotSupportedException(); }

        /// <summary> Gets or sets the field. </summary>
        public AlertProcessingRuleField? Field { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the operator. </summary>
        public AlertProcessingRuleOperator? Operator { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets the values. </summary>
        public IList<string> Values { get { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleCondition IJsonModel<AlertProcessingRuleCondition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleCondition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleCondition IPersistableModel<AlertProcessingRuleCondition>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleCondition>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleCondition>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
