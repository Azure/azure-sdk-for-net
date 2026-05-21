// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// The ReplicationEligibilityResult resource is modeled as @singleton("default") in the new
// TypeSpec specification, and its parent in the ARM URL is a Microsoft.Compute virtual machine
// rather than the resource group itself. The MPG emitter therefore does not generate RG-scoped
// accessor methods (only an ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) scope
// accessor is emitted). The previous AutoRest-generated v1.x SDK exposed RG-scoped methods that
// took a virtualMachineName string and assumed the VM lived in the same RG; removing them would
// be a binary-breaking change for consumers, so we keep the methods here but mark them obsolete
// and have them throw NotSupportedException. Callers should construct the VM ResourceIdentifier
// explicitly and pass it to ArmClient.GetReplicationEligibilityResult(scope) instead.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Mocking
{
    public partial class MockableRecoveryServicesSiteRecoveryResourceGroupResource
    {
        /// <summary>
        /// Gets a <see cref="ReplicationEligibilityResultResource"/> for the specified virtual machine.
        /// Preserved only for backward compatibility; the resource is now modeled as a singleton scoped
        /// to a virtual machine. Use <c>ArmClient.GetReplicationEligibilityResult(ResourceIdentifier)</c>
        /// passing the virtual machine identifier instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future version. ReplicationEligibilityResult is now modeled as a singleton scoped to a virtual machine; use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) instead.")]
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<ReplicationEligibilityResultResource> GetReplicationEligibilityResult(string virtualMachineName, CancellationToken cancellationToken = default)
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
        public virtual Task<Response<ReplicationEligibilityResultResource>> GetReplicationEligibilityResultAsync(string virtualMachineName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary>
        /// Gets a collection of <see cref="ReplicationEligibilityResultResource"/> for the specified virtual machine.
        /// Preserved only for backward compatibility; the resource is now modeled as a singleton scoped
        /// to a virtual machine. Use <c>ArmClient.GetReplicationEligibilityResult(ResourceIdentifier)</c>
        /// passing the virtual machine identifier instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future version. ReplicationEligibilityResult is now modeled as a singleton scoped to a virtual machine; use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) instead.")]
        public virtual ReplicationEligibilityResultCollection GetReplicationEligibilityResults(string virtualMachineName)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
    }
}
