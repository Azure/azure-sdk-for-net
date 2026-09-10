// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.AppContainers
{
    /// <summary> Outbound type for the cluster. </summary>
    // Preserve the orphaned public enum emitted by the reflection-based generator after its associated model was removed.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and it will be removed in a future version.")]
    public enum ContainerAppManagedEnvironmentOutBoundType
    {
        /// <summary> Load balancer. </summary>
        LoadBalancer = 0,

        /// <summary> User-defined routing. </summary>
        UserDefinedRouting = 1
    }
}
