// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.RecoveryServicesSiteRecovery.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public static partial class RecoveryServicesSiteRecoveryExtensions
    {
        /// <summary>
        /// Gets a collection of <see cref="ReplicationEligibilityResultResource"/> in the <see cref="ResourceGroupResource"/>.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="virtualMachineName"> Virtual Machine name. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) for the singleton resource directly.", false)]
        public static ReplicationEligibilityResultCollection GetReplicationEligibilityResults(this ResourceGroupResource resourceGroupResource, string virtualMachineName)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableRecoveryServicesSiteRecoveryResourceGroupResource(resourceGroupResource).GetReplicationEligibilityResults(virtualMachineName);
        }

        /// <summary> Validates whether a given VM can be protected or not in which case returns list of errors. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="virtualMachineName"> Virtual Machine name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) for the singleton resource directly.", false)]
        [Azure.Core.ForwardsClientCalls]
        public static async Task<Response<ReplicationEligibilityResultResource>> GetReplicationEligibilityResultAsync(this ResourceGroupResource resourceGroupResource, string virtualMachineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableRecoveryServicesSiteRecoveryResourceGroupResource(resourceGroupResource).GetReplicationEligibilityResultAsync(virtualMachineName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Validates whether a given VM can be protected or not in which case returns list of errors. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="virtualMachineName"> Virtual Machine name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) for the singleton resource directly.", false)]
        [Azure.Core.ForwardsClientCalls]
        public static Response<ReplicationEligibilityResultResource> GetReplicationEligibilityResult(this ResourceGroupResource resourceGroupResource, string virtualMachineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableRecoveryServicesSiteRecoveryResourceGroupResource(resourceGroupResource).GetReplicationEligibilityResult(virtualMachineName, cancellationToken);
        }
    }
}
