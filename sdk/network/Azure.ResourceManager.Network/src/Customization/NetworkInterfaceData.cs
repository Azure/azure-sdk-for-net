// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkInterfaceData
    {
        /// <inheritdoc cref="VirtualMachineId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use VirtualMachineId instead.")]
        [WirePath("properties.virtualMachine")]
        public WritableSubResource VirtualMachine
        {
            get => VirtualMachineId is null ? default : new WritableSubResource { Id = VirtualMachineId };
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
