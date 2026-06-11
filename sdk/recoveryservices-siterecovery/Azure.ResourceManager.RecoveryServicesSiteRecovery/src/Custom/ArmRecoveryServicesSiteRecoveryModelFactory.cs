// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// The v1.x AutoRest-generated SDK exposed a model-factory method for
// SiteRecoveryClusterRecoveryPointData. The new TypeSpec specification no longer models
// the cluster recovery point sub-resource as an ARM resource (it does not appear in the
// ARM templates index), so the MPG emitter does not generate a ResourceData type for it and
// therefore no factory method. Removing the factory method would be a binary-breaking
// change for consumers, so we keep the signature here, mark it obsolete, and have it throw
// NotSupportedException.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServicesSiteRecovery;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public static partial class ArmRecoveryServicesSiteRecoveryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryServicesSiteRecovery.SiteRecoveryClusterRecoveryPointData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future version. The cluster recovery point sub-resource is no longer modeled as an ARM resource.")]
        public static SiteRecoveryClusterRecoveryPointData SiteRecoveryClusterRecoveryPointData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string clusterRecoveryPointType = default, SiteRecoveryClusterRecoveryPointProperties properties = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
    }
}
