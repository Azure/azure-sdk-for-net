// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ServiceNetworking.Models;

namespace Azure.ResourceManager.ServiceNetworking
{
#pragma warning disable 0618
    /// <summary>
    /// A class representing the TrafficController data model.
    /// Concrete tracked resource types can be created by aliasing this type using a specific property type.
    /// </summary>
    public partial class TrafficControllerData : TrackedResourceData
    {
        /// <summary> The status of the last operation. </summary>
        [Obsolete("This property is now deprecated. Please use `TrafficControllerProvisioningState` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProvisioningState? ProvisioningState { get => TrafficControllerProvisioningState.ToString(); }
    }
#pragma warning restore 0618
}
