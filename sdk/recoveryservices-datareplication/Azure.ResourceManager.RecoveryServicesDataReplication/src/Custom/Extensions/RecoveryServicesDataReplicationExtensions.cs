// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.RecoveryServicesDataReplication.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.RecoveryServicesDataReplication
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.RecoveryServicesDataReplication. </summary>
    public static partial class RecoveryServicesDataReplicationExtensions
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentId"> Deployment Id. </param>
        /// <param name="body"> Deployment preflight model. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="deploymentId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use PerformDeploymentPreflightValidationAsync instead.", false)]
        public static async Task<Response<DeploymentPreflight>> PostDeploymentPreflightAsync(this ResourceGroupResource resourceGroupResource, string deploymentId, DeploymentPreflight body = null, CancellationToken cancellationToken = default)
            => await PerformDeploymentPreflightValidationAsync(resourceGroupResource, deploymentId, body, cancellationToken).ConfigureAwait(false);

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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentId"> Deployment Id. </param>
        /// <param name="body"> Deployment preflight model. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="deploymentId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use PerformDeploymentPreflightValidation instead.", false)]
        public static Response<DeploymentPreflight> PostDeploymentPreflight(this ResourceGroupResource resourceGroupResource, string deploymentId, DeploymentPreflight body = null, CancellationToken cancellationToken = default)
            => PerformDeploymentPreflightValidation(resourceGroupResource, deploymentId, body, cancellationToken);

        /// <summary>
        /// Checks the resource name availability.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataReplication/locations/{location}/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CheckNameAvailability_Post</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="content"> Resource details. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use CheckDataReplicationNameAvailabilityAsync instead.", false)]
        public static async Task<Response<DataReplicationNameAvailabilityResult>> PostCheckNameAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, DataReplicationNameAvailabilityContent content = null, CancellationToken cancellationToken = default)
            => await CheckDataReplicationNameAvailabilityAsync(subscriptionResource, location, content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Checks the resource name availability.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataReplication/locations/{location}/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CheckNameAvailability_Post</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-09-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="content"> Resource details. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Use CheckDataReplicationNameAvailability instead.", false)]
        public static Response<DataReplicationNameAvailabilityResult> PostCheckNameAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, DataReplicationNameAvailabilityContent content = null, CancellationToken cancellationToken = default)
            => CheckDataReplicationNameAvailability(subscriptionResource, location, content, cancellationToken);
    }
}
