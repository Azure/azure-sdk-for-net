// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary>
    /// Backward-compat type alias. Old name was UpdatePrerequisite, renamed to HciClusterUpdatePrerequisite.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdatePrerequisite` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class UpdatePrerequisite : HciClusterUpdatePrerequisite,
        IJsonModel<UpdatePrerequisite>,
        IPersistableModel<UpdatePrerequisite>
    {
        /// <summary> Initializes a new instance of <see cref="UpdatePrerequisite"/>. </summary>
        public UpdatePrerequisite() : base() { }

        internal UpdatePrerequisite(string updateType, string version, string packageName,
            IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(updateType, version, packageName, additionalBinaryDataProperties) { }

        UpdatePrerequisite IJsonModel<UpdatePrerequisite>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdatePrerequisite instead.");

        void IJsonModel<UpdatePrerequisite>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdatePrerequisite instead.");

        UpdatePrerequisite IPersistableModel<UpdatePrerequisite>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdatePrerequisite instead.");

        BinaryData IPersistableModel<UpdatePrerequisite>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use HciClusterUpdatePrerequisite instead.");

        string IPersistableModel<UpdatePrerequisite>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
