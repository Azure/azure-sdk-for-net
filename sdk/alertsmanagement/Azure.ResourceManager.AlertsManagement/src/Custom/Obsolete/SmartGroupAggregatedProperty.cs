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
    public partial class SmartGroupAggregatedProperty : IJsonModel<SmartGroupAggregatedProperty>, IPersistableModel<SmartGroupAggregatedProperty>
    {
        /// <summary> Initializes a new instance. </summary>
        public SmartGroupAggregatedProperty() { throw new NotSupportedException(); }

        /// <summary> Gets or sets the count. </summary>
        public long? Count { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the name. </summary>
        public string Name { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        SmartGroupAggregatedProperty IJsonModel<SmartGroupAggregatedProperty>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<SmartGroupAggregatedProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        SmartGroupAggregatedProperty IPersistableModel<SmartGroupAggregatedProperty>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<SmartGroupAggregatedProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<SmartGroupAggregatedProperty>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
