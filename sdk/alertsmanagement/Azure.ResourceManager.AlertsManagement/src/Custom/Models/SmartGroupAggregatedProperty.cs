// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Back-compat ApiCompat shim — kept solely to preserve the binary contract of the previously
    // published GA package (Azure.ResourceManager.AlertsManagement v1.1.x).
    //
    // Why it lives here instead of being regenerated:
    //   The SmartGroup operation group is deliberately out of scope for this migration's TypeSpec spec
    //   (specification/alertsmanagement/.../Microsoft.AlertsManagement/AlertsManagement). The
    //   underlying service operations still exist but will be shipped from a separate dedicated package
    //   in a future release, so the MPG generator does not (and must not) emit these types here.
    //
    // What this stub provides:
    //   The type is declared with the original v1.1.x signature so that consumer assemblies compiled
    //   against the old GA still load, but every member throws NotSupportedException at runtime. The
    //   type is also marked [Obsolete(..., error: true)] + [EditorBrowsable(Never)] so the C# compiler
    //   redirects new callers to the future dedicated SmartGroup package.
    /// <summary> Aggregated property of each type. </summary>
    [Obsolete("The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release.", true)]
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
