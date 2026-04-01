// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Describes the Extension Instance View. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `ArcExtensionInstanceView` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class HciExtensionInstanceView
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
    }
}
