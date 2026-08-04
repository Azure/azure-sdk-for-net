// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// The v1.x AutoRest-generated SDK exposed an ArmClient-scoped accessor for
// SiteRecoveryClusterRecoveryPointResource (the by-id resolver
// GetSiteRecoveryClusterRecoveryPointResource(ResourceIdentifier)). The new TypeSpec
// specification no longer models the cluster recovery point sub-resource as an ARM resource
// (it does not appear in the ARM templates index), so the MPG emitter does not generate
// this accessor. Removing it would be a binary-breaking change for consumers, so we keep
// the signature here, mark it obsolete, and have it throw NotSupportedException.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Mocking
{
    public partial class MockableRecoveryServicesSiteRecoveryArmClient
    {
        /// <summary> Gets an object representing a SiteRecoveryClusterRecoveryPointResource along with the instance operations that can be performed on it but with no data. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future version. The cluster recovery point sub-resource is no longer modeled as an ARM resource.")]
        public virtual SiteRecoveryClusterRecoveryPointResource GetSiteRecoveryClusterRecoveryPointResource(ResourceIdentifier id)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
    }
}
