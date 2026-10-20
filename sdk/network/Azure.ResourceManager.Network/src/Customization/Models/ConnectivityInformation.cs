// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ConnectivityInformation
    {
        /// <summary> Compatibility member. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete. Please use ConnectionStatus instead.")]
        public NetworkConnectionStatus? NetworkConnectionStatus => ConnectionStatus;
    }
}
