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
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AlertProcessingRuleRemoveAllGroupsAction : AlertProcessingRuleAction, IJsonModel<AlertProcessingRuleRemoveAllGroupsAction>, IPersistableModel<AlertProcessingRuleRemoveAllGroupsAction>
    {
        /// <summary> Initializes a new instance. </summary>
        public AlertProcessingRuleRemoveAllGroupsAction() { throw new NotSupportedException(); }

        /// <summary> Writes the model to JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleRemoveAllGroupsAction IJsonModel<AlertProcessingRuleRemoveAllGroupsAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleRemoveAllGroupsAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleRemoveAllGroupsAction IPersistableModel<AlertProcessingRuleRemoveAllGroupsAction>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleRemoveAllGroupsAction>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleRemoveAllGroupsAction>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
