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
    public partial class AlertProcessingRuleProperties : IJsonModel<AlertProcessingRuleProperties>, IPersistableModel<AlertProcessingRuleProperties>
    {
        /// <summary> Initializes a new instance. </summary>
        /// <param name="scopes"> The scopes. </param>
        /// <param name="actions"> The actions. </param>
        public AlertProcessingRuleProperties(IEnumerable<string> scopes, IEnumerable<AlertProcessingRuleAction> actions) { throw new NotSupportedException(); }

        /// <summary> Gets the actions. </summary>
        public IList<AlertProcessingRuleAction> Actions { get { throw new NotSupportedException(); } }

        /// <summary> Gets the conditions. </summary>
        public IList<AlertProcessingRuleCondition> Conditions { get { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the description. </summary>
        public string Description { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets whether enabled. </summary>
        public bool? IsEnabled { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the schedule. </summary>
        public AlertProcessingRuleSchedule Schedule { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets the scopes. </summary>
        public IList<string> Scopes { get { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleProperties IJsonModel<AlertProcessingRuleProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleProperties IPersistableModel<AlertProcessingRuleProperties>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleProperties>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
