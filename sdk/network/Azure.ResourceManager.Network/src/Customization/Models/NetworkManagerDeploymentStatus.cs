// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the NetworkManagerDeploymentStatus type. </summary>
    public partial class NetworkManagerDeploymentStatus
    {
        // The migration name remains canonical; the released alias reads the same extensible enum.
        /// <summary> Gets the deployment status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, use DeploymentStatus instead", false)]
        public NetworkManagerDeploymentState? DeploymentState => DeploymentStatus;
    }
}
