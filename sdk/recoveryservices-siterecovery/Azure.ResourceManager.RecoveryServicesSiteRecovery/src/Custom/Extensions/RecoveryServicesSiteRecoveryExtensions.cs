// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customizations are intentionally retained for backward compatibility.
// Each member here corresponds to a public API that existed in the v1.x AutoRest-generated SDK
// but is no longer produced by the MPG emitter under the new TypeSpec specification. Removing
// them would be a binary-breaking change for consumers, so we keep the signatures here but mark
// them obsolete and have them throw NotSupportedException. See the per-member XML doc comments
// and Obsolete messages for the recommended replacement APIs.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public static partial class RecoveryServicesSiteRecoveryExtensions
    {
        // The ClusterRecoveryPoint sub-resource is no longer modeled as an ARM resource in the
        // new TypeSpec specification, so the MPG emitter does not generate a Resource type or its
        // by-id ArmClient accessor. This shim preserves the v1.x signature.
        /// <summary> Gets an object representing a SiteRecoveryClusterRecoveryPointResource along with the instance operations that can be performed on it but with no data. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future version. The cluster recovery point sub-resource is no longer modeled as an ARM resource.")]
        public static SiteRecoveryClusterRecoveryPointResource GetSiteRecoveryClusterRecoveryPointResource(this ArmClient client, ResourceIdentifier id)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        // The ReplicationEligibilityResult resource is modeled as @singleton("default") in the new
        // TypeSpec specification, and its parent in the ARM URL is a Microsoft.Compute virtual
        // machine rather than the resource group itself. The MPG emitter therefore does not
        // generate RG-scoped accessor methods (only ArmClient.GetReplicationEligibilityResult(
        // ResourceIdentifier) is emitted). The v1.x SDK exposed RG-scoped methods that took a
        // virtualMachineName string and assumed the VM lived in the same RG as the caller's
        // ResourceGroupResource; that assumption was incorrect in cross-RG scenarios. Callers
        // should construct the VM ResourceIdentifier explicitly and pass it to the scope-based
        // accessor instead.

        /// <summary>
        /// Gets a <see cref="ReplicationEligibilityResultResource"/> for the specified virtual machine.
        /// Preserved only for backward compatibility; the resource is now modeled as a singleton scoped
        /// to a virtual machine. Use <c>ArmClient.GetReplicationEligibilityResult(ResourceIdentifier)</c>
        /// passing the virtual machine identifier instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future version. ReplicationEligibilityResult is now modeled as a singleton scoped to a virtual machine; use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) instead.")]
        [Azure.Core.ForwardsClientCalls]
        public static Response<ReplicationEligibilityResultResource> GetReplicationEligibilityResult(this ResourceGroupResource resourceGroupResource, string virtualMachineName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary>
        /// Gets a <see cref="ReplicationEligibilityResultResource"/> for the specified virtual machine.
        /// Preserved only for backward compatibility; the resource is now modeled as a singleton scoped
        /// to a virtual machine. Use <c>ArmClient.GetReplicationEligibilityResult(ResourceIdentifier)</c>
        /// passing the virtual machine identifier instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future version. ReplicationEligibilityResult is now modeled as a singleton scoped to a virtual machine; use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) instead.")]
        [Azure.Core.ForwardsClientCalls]
        public static Task<Response<ReplicationEligibilityResultResource>> GetReplicationEligibilityResultAsync(this ResourceGroupResource resourceGroupResource, string virtualMachineName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary>
        /// Gets a collection of <see cref="ReplicationEligibilityResultResource"/> for the specified virtual machine.
        /// Preserved only for backward compatibility; the resource is now modeled as a singleton scoped
        /// to a virtual machine. Use <c>ArmClient.GetReplicationEligibilityResult(ResourceIdentifier)</c>
        /// passing the virtual machine identifier instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future version. ReplicationEligibilityResult is now modeled as a singleton scoped to a virtual machine; use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) instead.")]
        public static ReplicationEligibilityResultCollection GetReplicationEligibilityResults(this ResourceGroupResource resourceGroupResource, string virtualMachineName)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
    }
}
