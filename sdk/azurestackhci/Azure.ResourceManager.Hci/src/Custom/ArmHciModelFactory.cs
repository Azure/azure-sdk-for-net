// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    // Backward-compat: preserves [Obsolete] from previous API version on backward-compat overloads
    [CodeGenSuppress("HciExtensionInstanceView", typeof(string), typeof(string), typeof(string), typeof(ExtensionInstanceViewStatus))]
    [CodeGenSuppress("PerNodeExtensionState", typeof(string), typeof(string), typeof(string), typeof(NodeExtensionState?), typeof(HciExtensionInstanceView))]
    public static partial class ArmHciModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.HciExtensionInstanceView"/>. </summary>
        /// <param name="name"> The extension instance view name. </param>
        /// <param name="extensionInstanceViewType"> Specifies the type of the extension. </param>
        /// <param name="typeHandlerVersion"> Specifies the version of the script handler. </param>
        /// <param name="status"> Instance view status. </param>
        /// <returns> A new <see cref="Models.HciExtensionInstanceView"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        public static HciExtensionInstanceView HciExtensionInstanceView(string name, string extensionInstanceViewType, string typeHandlerVersion, ExtensionInstanceViewStatus status)
        {
            return new HciExtensionInstanceView(name, default, typeHandlerVersion, status, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PerNodeExtensionState"/>. </summary>
        /// <param name="name"> Name of the node in HCI Cluster. </param>
        /// <param name="extension"> Fully qualified resource ID for the particular Arc Extension on this node. </param>
        /// <param name="typeHandlerVersion"> Specifies the version of the script handler. </param>
        /// <param name="state"> State of Arc Extension in this node. </param>
        /// <param name="instanceView"> The extension instance view. </param>
        /// <returns> A new <see cref="Models.PerNodeExtensionState"/> instance for mocking. </returns>
        [Obsolete("This method is now deprecated. Please use the new method `ArcExtensionInstanceView` moving forward.")]
        public static PerNodeExtensionState PerNodeExtensionState(string name = default, string extension = default, string typeHandlerVersion = default, NodeExtensionState? state = default, HciExtensionInstanceView instanceView = default)
        {
            return new PerNodeExtensionState(
                name,
                extension,
                typeHandlerVersion,
                state,
                instanceView,
                additionalBinaryDataProperties: null);
        }
    }
}
