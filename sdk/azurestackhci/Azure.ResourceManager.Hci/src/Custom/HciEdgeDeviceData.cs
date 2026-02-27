// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;

namespace Azure.ResourceManager.Hci
{
    public abstract partial class HciEdgeDeviceData
    {
        /// <summary> Initializes a new instance of <see cref="HciEdgeDeviceData"/> for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected HciEdgeDeviceData(ResourceIdentifier id) : this(default(DeviceKind))
        {
        }
    }
}
