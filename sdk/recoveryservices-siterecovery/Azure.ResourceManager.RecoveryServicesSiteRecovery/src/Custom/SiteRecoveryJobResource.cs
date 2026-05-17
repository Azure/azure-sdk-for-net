// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// In the v1.x AutoRest-generated SDK, the "Export" operation
// (POST /subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.RecoveryServices/
//        vaults/{vaultName}/replicationJobs/export)
// was emitted as an instance method on SiteRecoveryJobResource even though the URL is
// a collection-level action with no {jobName} key segment. AutoRest attached the op
// to JobResource via the operation-group tag (@tag("ReplicationJobs")).
//
// The TypeSpec spec models this op as ArmProviderActionAsync<..., Scope = Extension.ResourceGroup>
// with @armResourceCollectionAction (applied internally by the template). The MPG TypeSpec
// emitter has three gaps that prevent the op from landing on JobResource (or JobCollection):
//   1. sdk-context-options.ts has no armResourceCollectionActionName constant, so the
//      decorator name is never imported.
//   2. resource-detection.ts parseResourceOperation has no case for @armResourceCollectionAction,
//      so the op is left without a (kind, modelId) classification.
//   3. The fallback in assignNonResourceMethodsToResources attaches the op to the longest-prefix
//      resource by *instance* path. The Job's instance path ends with /{jobName}, which is not
//      a prefix of /replicationJobs/export, so the op falls through to ResourceGroupResource
//      and is emitted as a plain extension method that takes vaultName as a string parameter.
//
// To restore the v1.x binary surface (SiteRecoveryJobResource.Export[Async]), we add a
// thin forwarder partial that extracts vaultName from Id.Parent.Name and delegates to the
// generated ResourceGroupResource.Export(WaitUntil, vaultName, content, ct).

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.RecoveryServicesSiteRecovery.Models;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public partial class SiteRecoveryJobResource
    {
        /// <summary>
        /// The operation to export the details of the Azure Site Recovery jobs of the vault.
        /// </summary>
        /// <remarks>
        /// This API is deprecated. The underlying REST operation is a vault-scoped collection
        /// action (it is not keyed by a specific job); use
        /// <see cref="RecoveryServicesSiteRecoveryExtensions.ExportAsync(ResourceGroupResource, WaitUntil, string, SiteRecoveryJobQueryContent, CancellationToken)"/>
        /// (available via <c>ResourceGroupResource.ExportAsync</c>) instead.
        /// </remarks>
        /// <param name="waitUntil">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the
        /// long-running operation has completed on the service; <see cref="WaitUntil.Started"/>
        /// if it should return after starting the operation.
        /// </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [Obsolete("This method is deprecated and will be removed in a future version. The underlying REST operation is a vault-scoped collection action; call ResourceGroupResource.ExportAsync(WaitUntil, vaultName, content, ct) instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<ArmOperation<SiteRecoveryJobResource>> ExportAsync(WaitUntil waitUntil, SiteRecoveryJobQueryContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));
            string vaultName = Id.Parent.Name;
            ResourceGroupResource rg = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return await rg.ExportAsync(waitUntil, vaultName, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The operation to export the details of the Azure Site Recovery jobs of the vault.
        /// </summary>
        /// <remarks>
        /// This API is deprecated. The underlying REST operation is a vault-scoped collection
        /// action (it is not keyed by a specific job); use
        /// <see cref="RecoveryServicesSiteRecoveryExtensions.Export(ResourceGroupResource, WaitUntil, string, SiteRecoveryJobQueryContent, CancellationToken)"/>
        /// (available via <c>ResourceGroupResource.Export</c>) instead.
        /// </remarks>
        /// <param name="waitUntil">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the
        /// long-running operation has completed on the service; <see cref="WaitUntil.Started"/>
        /// if it should return after starting the operation.
        /// </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [Obsolete("This method is deprecated and will be removed in a future version. The underlying REST operation is a vault-scoped collection action; call ResourceGroupResource.Export(WaitUntil, vaultName, content, ct) instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<SiteRecoveryJobResource> Export(WaitUntil waitUntil, SiteRecoveryJobQueryContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));
            string vaultName = Id.Parent.Name;
            ResourceGroupResource rg = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return rg.Export(waitUntil, vaultName, content, cancellationToken);
        }
    }
}
