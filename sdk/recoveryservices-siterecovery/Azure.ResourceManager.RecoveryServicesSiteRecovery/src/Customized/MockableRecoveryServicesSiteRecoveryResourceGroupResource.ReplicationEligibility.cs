// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Mocking
{
    public partial class MockableRecoveryServicesSiteRecoveryResourceGroupResource
    {
        /// <summary>
        /// Gets a collection of <see cref="ReplicationEligibilityResultResource"/> in the <see cref="Azure.ResourceManager.Resources.ResourceGroupResource"/>.
        /// </summary>
        /// <param name="virtualMachineName"> Virtual Machine name. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) for the singleton resource directly.", false)]
        public virtual ReplicationEligibilityResultCollection GetReplicationEligibilityResults(string virtualMachineName)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineName, nameof(virtualMachineName));
            return new ReplicationEligibilityResultCollection(Client, Id, virtualMachineName);
        }

        /// <summary> Validates whether a given VM can be protected or not in which case returns list of errors. </summary>
        /// <param name="virtualMachineName"> Virtual Machine name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) for the singleton resource directly.", false)]
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<ReplicationEligibilityResultResource> GetReplicationEligibilityResult(string virtualMachineName, CancellationToken cancellationToken = default)
        {
            return GetReplicationEligibilityResults(virtualMachineName).Get(cancellationToken);
        }

        /// <summary> Validates whether a given VM can be protected or not in which case returns list of errors. </summary>
        /// <param name="virtualMachineName"> Virtual Machine name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) for the singleton resource directly.", false)]
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<ReplicationEligibilityResultResource>> GetReplicationEligibilityResultAsync(string virtualMachineName, CancellationToken cancellationToken = default)
        {
            return GetReplicationEligibilityResults(virtualMachineName).GetAsync(cancellationToken);
        }
    }
}
