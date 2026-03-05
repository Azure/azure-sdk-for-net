// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    [Obsolete("This class is now deprecated. Please use the new class `ArcExtensionInstanceView` moving forward.")]
    [CodeGenSuppress("Status")]
    [CodeGenSuppress("HciExtensionInstanceView", typeof(string), typeof(string), typeof(string), typeof(ArcExtensionInstanceViewStatus), typeof(IDictionary<string, BinaryData>))]
    public partial class HciExtensionInstanceView
    {
        /// <summary> Specifies the type of the extension. </summary>
        public string ExtensionInstanceViewType => Type;

        private ExtensionInstanceViewStatus _statusCompat;

        /// <summary> Initializes a new instance of <see cref="HciExtensionInstanceView"/>. </summary>
        internal HciExtensionInstanceView(string name, string type, string typeHandlerVersion, ArcExtensionInstanceViewStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Name = name;
            Type = type;
            TypeHandlerVersion = typeHandlerVersion;
            if (status != null)
            {
                _statusCompat = new ExtensionInstanceViewStatus(status.Code, status.Level, status.DisplayStatus, status.Message, status.Time, null);
            }
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Instance view status. </summary>
        [Obsolete("This property is obsolete. Use Status with type ArcExtensionInstanceViewStatus instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("status")]
        public ExtensionInstanceViewStatus Status => _statusCompat;
    }
}
