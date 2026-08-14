// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    public readonly partial struct HciClusterStatus
    {
        /// <summary> Failed. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `DeploymentFailed` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciClusterStatus Failed { get; } = new HciClusterStatus("DeploymentFailed");
        /// <summary> InProgress. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `DeploymentInProgress` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciClusterStatus InProgress { get; } = new HciClusterStatus("DeploymentInProgress");
        /// <summary> Succeeded. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `DeploymentSuccess` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HciClusterStatus Succeeded { get; } = new HciClusterStatus("DeploymentSuccess");
    }
}
