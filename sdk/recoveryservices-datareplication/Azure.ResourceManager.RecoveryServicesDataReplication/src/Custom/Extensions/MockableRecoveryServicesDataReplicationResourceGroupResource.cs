// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.RecoveryServicesDataReplication.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Mocking
{
    /// <summary> A class to add extension methods to <see cref="ResourceGroupResource"/>. </summary>
    public partial class MockableRecoveryServicesDataReplicationResourceGroupResource : ArmResource
    {
        /// <summary>
        /// Performs resource deployment preflight validation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/deployments/{deploymentId}/preflight</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeploymentPreflight_Post</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="deploymentId"> Deployment Id. </param>
        /// <param name="body"> Deployment preflight model. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use PerformDeploymentPreflightValidationAsync instead.", false)]
        public virtual async Task<Response<DeploymentPreflight>> PostDeploymentPreflightAsync(string deploymentId, DeploymentPreflight body = null, CancellationToken cancellationToken = default)
            => await PerformDeploymentPreflightValidationAsync(deploymentId, body, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs resource deployment preflight validation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataReplication/deployments/{deploymentId}/preflight</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeploymentPreflight_Post</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="deploymentId"> Deployment Id. </param>
        /// <param name="body"> Deployment preflight model. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use PerformDeploymentPreflightValidation instead.", false)]
        public virtual Response<DeploymentPreflight> PostDeploymentPreflight(string deploymentId, DeploymentPreflight body = null, CancellationToken cancellationToken = default)
            => PerformDeploymentPreflightValidation(deploymentId, body, cancellationToken);
    }
}
