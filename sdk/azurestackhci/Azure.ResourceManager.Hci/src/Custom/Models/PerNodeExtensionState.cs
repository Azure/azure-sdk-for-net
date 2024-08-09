// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Status of Arc Extension for a particular node in HCI Cluster. </summary>
    public partial class PerNodeExtensionState
    {
        /// <summary> The extension instance view. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `StartOn` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HciExtensionInstanceView InstanceView { get => new HciExtensionInstanceView(ExtensionInstanceView.Name,
                                                                                           ExtensionInstanceView.ExtensionInstanceViewType,
                                                                                           ExtensionInstanceView.TypeHandlerVersion,
                                                                                           new ExtensionInstanceViewStatus(ExtensionInstanceView.Status.Code,
                                                                                                                           ExtensionInstanceView.Status.Level,
                                                                                                                           ExtensionInstanceView.Status.DisplayStatus,
                                                                                                                           ExtensionInstanceView.Status.Message,
                                                                                                                           ExtensionInstanceView.Status.Time,
                                                                                                                           null),
                                                                                           null); }
    }
}
