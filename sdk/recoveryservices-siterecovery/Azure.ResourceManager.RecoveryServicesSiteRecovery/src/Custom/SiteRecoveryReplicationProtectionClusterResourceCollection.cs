// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: Rename the generator-synthesized SiteRecoveryReplicationProtectionClusterCollection
// to its v1.x baseline name SiteRecoveryReplicationProtectionClusterResourceCollection via
// [CodeGenType]. The v1.x AutoRest SDK emitted this single Collection with the unusual
// "{ResourceTypeName}Collection" form that retains the "Resource" suffix — every other
// resource in the SDK already uses the standard "{ResourceName}Collection" form. The new
// MPG TypeSpec emitter normalized this outlier to the standard form, which is a binary-
// breaking change for downstream consumers. The rename consolidates back to a single type
// with the v1.x name so callers continue to compile and run unchanged.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    [CodeGenType("SiteRecoveryReplicationProtectionClusterCollection")]
    public partial class SiteRecoveryReplicationProtectionClusterResourceCollection
    {
    }
}
