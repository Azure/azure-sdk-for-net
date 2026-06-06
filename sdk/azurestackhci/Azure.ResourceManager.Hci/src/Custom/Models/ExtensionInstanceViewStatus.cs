// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary>
    /// Backward-compat type alias for ExtensionInstanceViewStatus (old autorest name).
    /// The TypeSpec migration renamed it to ArcExtensionInstanceViewStatus.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `ArcExtensionInstanceViewStatus` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ExtensionInstanceViewStatus : ArcExtensionInstanceViewStatus,
        IJsonModel<ExtensionInstanceViewStatus>,
        IPersistableModel<ExtensionInstanceViewStatus>
    {
        internal ExtensionInstanceViewStatus() : base() { }

        ExtensionInstanceViewStatus IJsonModel<ExtensionInstanceViewStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionInstanceViewStatus instead.");

        void IJsonModel<ExtensionInstanceViewStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionInstanceViewStatus instead.");

        ExtensionInstanceViewStatus IPersistableModel<ExtensionInstanceViewStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionInstanceViewStatus instead.");

        BinaryData IPersistableModel<ExtensionInstanceViewStatus>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionInstanceViewStatus instead.");

        string IPersistableModel<ExtensionInstanceViewStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
