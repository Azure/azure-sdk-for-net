// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary>
    /// Backward-compat type alias. Old name was ExtensionUpgradeContent, renamed to ArcExtensionUpgradeContent.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `ArcExtensionUpgradeContent` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ExtensionUpgradeContent : ArcExtensionUpgradeContent,
        IJsonModel<ExtensionUpgradeContent>,
        IPersistableModel<ExtensionUpgradeContent>
    {
        /// <summary> Initializes a new instance of <see cref="ExtensionUpgradeContent"/>. </summary>
        public ExtensionUpgradeContent() : base() { }

        ExtensionUpgradeContent IJsonModel<ExtensionUpgradeContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionUpgradeContent instead.");

        void IJsonModel<ExtensionUpgradeContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionUpgradeContent instead.");

        ExtensionUpgradeContent IPersistableModel<ExtensionUpgradeContent>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionUpgradeContent instead.");

        BinaryData IPersistableModel<ExtensionUpgradeContent>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionUpgradeContent instead.");

        string IPersistableModel<ExtensionUpgradeContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
