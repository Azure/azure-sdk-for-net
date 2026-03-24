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
    [PersistableModelProxy(typeof(UnknownAction))]
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract partial class AlertProcessingRuleAction : IJsonModel<AlertProcessingRuleAction>, IPersistableModel<AlertProcessingRuleAction>
    {
        /// <summary> Initializes a new instance of AlertProcessingRuleAction. </summary>
        protected AlertProcessingRuleAction() { }

        /// <summary> Writes the model to JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleAction IJsonModel<AlertProcessingRuleAction>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleAction>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleAction IPersistableModel<AlertProcessingRuleAction>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleAction>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleAction>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
