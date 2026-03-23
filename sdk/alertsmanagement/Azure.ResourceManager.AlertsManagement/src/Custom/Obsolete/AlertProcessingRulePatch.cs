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
    public partial class AlertProcessingRulePatch : IJsonModel<AlertProcessingRulePatch>, IPersistableModel<AlertProcessingRulePatch>
    {
        /// <summary> Initializes a new instance. </summary>
        public AlertProcessingRulePatch() { throw new NotSupportedException(); }

        /// <summary> Gets or sets whether enabled. </summary>
        public bool? IsEnabled { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets the tags. </summary>
        public IDictionary<string, string> Tags { get { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRulePatch IJsonModel<AlertProcessingRulePatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRulePatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRulePatch IPersistableModel<AlertProcessingRulePatch>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRulePatch>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRulePatch>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
