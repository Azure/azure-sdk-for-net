// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Describes the Extension Instance View. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `ArcExtensionInstanceView` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class HciExtensionInstanceView : IJsonModel<HciExtensionInstanceView>, IPersistableModel<HciExtensionInstanceView>
    {
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="HciExtensionInstanceView"/>. </summary>
        internal HciExtensionInstanceView()
        {
        }

        /// <summary> Initializes a new instance of <see cref="HciExtensionInstanceView"/>. </summary>
        internal HciExtensionInstanceView(string name, string extensionInstanceViewType, string typeHandlerVersion, ExtensionInstanceViewStatus status, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            ExtensionInstanceViewType = extensionInstanceViewType;
            TypeHandlerVersion = typeHandlerVersion;
            Status = status;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The extension name. </summary>
        public string Name { get; }
        /// <summary> Specifies the type of the extension; an example is "MicrosoftMonitoringAgent". </summary>
        public string ExtensionInstanceViewType { get; }
        /// <summary> Specifies the version of the script handler. </summary>
        public string TypeHandlerVersion { get; }
        /// <summary> Instance view status. </summary>
        public ExtensionInstanceViewStatus Status { get; }

        /// <param name="writer"> The writer. </param>
        /// <param name="options"> The options. </param>
        void IJsonModel<HciExtensionInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionInstanceView instead.");

        /// <param name="reader"> The reader. </param>
        /// <param name="options"> The options. </param>
        HciExtensionInstanceView IJsonModel<HciExtensionInstanceView>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionInstanceView instead.");

        /// <param name="options"> The options. </param>
        BinaryData IPersistableModel<HciExtensionInstanceView>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionInstanceView instead.");

        /// <param name="data"> The data. </param>
        /// <param name="options"> The options. </param>
        HciExtensionInstanceView IPersistableModel<HciExtensionInstanceView>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Please use ArcExtensionInstanceView instead.");

        /// <param name="options"> The options. </param>
        string IPersistableModel<HciExtensionInstanceView>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
