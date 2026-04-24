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
    /// <summary> Backward compatibility stub. The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release. </summary>
    [Obsolete("The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SmartGroupModificationProperties : IJsonModel<SmartGroupModificationProperties>, IPersistableModel<SmartGroupModificationProperties>
    {
        /// <summary> Initializes a new instance. </summary>
        public SmartGroupModificationProperties() { throw new NotSupportedException(); }

        /// <summary> Gets the modifications. </summary>
        public IList<SmartGroupModificationItemInfo> Modifications { get { throw new NotSupportedException(); } }

        /// <summary> Gets or sets the next link. </summary>
        public string NextLink { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }

        /// <summary> Gets the smart group ID. </summary>
        public Guid? SmartGroupId { get { throw new NotSupportedException(); } }

        /// <summary> Writes the model to JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        SmartGroupModificationProperties IJsonModel<SmartGroupModificationProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<SmartGroupModificationProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        SmartGroupModificationProperties IPersistableModel<SmartGroupModificationProperties>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<SmartGroupModificationProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<SmartGroupModificationProperties>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
