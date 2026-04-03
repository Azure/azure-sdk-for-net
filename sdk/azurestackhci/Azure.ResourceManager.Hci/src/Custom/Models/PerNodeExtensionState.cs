// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    // Backward compat: the generator produces a constructor with HciExtensionInstanceView and
    // an InstanceView property. The old SDK used ArcExtensionInstanceView (renamed type) and
    // ExtensionInstanceView (renamed property). Both suppressions are needed to avoid CS0121
    // ambiguous constructor and CS0200 read-only InstanceView assignment conflicts.
    [CodeGenSuppress("PerNodeExtensionState", typeof(string), typeof(string), typeof(string), typeof(NodeExtensionState?), typeof(HciExtensionInstanceView), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("InstanceView")]
    public partial class PerNodeExtensionState
    {
        /// <summary> Initializes a new instance of <see cref="PerNodeExtensionState"/>. </summary>
        internal PerNodeExtensionState(string name, string extension, string typeHandlerVersion, NodeExtensionState? state, ArcExtensionInstanceView extensionInstanceView, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Name = name;
            Extension = extension;
            TypeHandlerVersion = typeHandlerVersion;
            State = state;
            ExtensionInstanceView = extensionInstanceView;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The extension instance view. </summary>
        [WirePath("instanceView")]
        public ArcExtensionInstanceView ExtensionInstanceView { get; }

        /// <summary> The extension instance view. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("instanceView")]
        public HciExtensionInstanceView InstanceView
            => throw new NotSupportedException("This property is now deprecated. Please use ExtensionInstanceView with type ArcExtensionInstanceView instead.");
    }
}
