// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Kusto.Models;

namespace Azure.ResourceManager.Kusto
{
    public partial class KustoClusterResource
    {
        /// <summary> Gets available SKUs for this cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<KustoAvailableSkuDetails> GetAvailableSkus(CancellationToken cancellationToken)
            => GetSkusByResource(cancellationToken);

        /// <summary> Gets available SKUs for this cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<KustoAvailableSkuDetails> GetAvailableSkusAsync(CancellationToken cancellationToken)
            => GetSkusByResourceAsync(cancellationToken);

        /// <summary> Updates this Kusto cluster using the legacy if-match signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<KustoClusterResource> Update(WaitUntil waitUntil, KustoClusterPatch patch, string ifMatch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default, cancellationToken);

        /// <summary> Updates this Kusto cluster using the legacy if-match signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<KustoClusterResource>> UpdateAsync(WaitUntil waitUntil, KustoClusterPatch patch, string ifMatch, CancellationToken cancellationToken)
            => UpdateAsync(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default, cancellationToken);

        /// <summary> Checks attached database configuration name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KustoNameAvailabilityResult> CheckKustoAttachedDatabaseConfigurationNameAvailability(KustoAttachedDatabaseConfigurationNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(content, cancellationToken);

        /// <summary> Checks attached database configuration name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KustoNameAvailabilityResult>> CheckKustoAttachedDatabaseConfigurationNameAvailabilityAsync(KustoAttachedDatabaseConfigurationNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(content, cancellationToken);

        /// <summary> Checks cluster principal assignment name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KustoNameAvailabilityResult> CheckKustoClusterPrincipalAssignmentNameAvailability(KustoClusterPrincipalAssignmentNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(content, cancellationToken);

        /// <summary> Checks cluster principal assignment name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KustoNameAvailabilityResult>> CheckKustoClusterPrincipalAssignmentNameAvailabilityAsync(KustoClusterPrincipalAssignmentNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(content, cancellationToken);

        /// <summary> Checks database name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KustoNameAvailabilityResult> CheckKustoDatabaseNameAvailability(KustoDatabaseNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(content, cancellationToken);

        /// <summary> Checks database name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KustoNameAvailabilityResult>> CheckKustoDatabaseNameAvailabilityAsync(KustoDatabaseNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(content, cancellationToken);

        /// <summary> Checks managed private endpoint name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KustoNameAvailabilityResult> CheckKustoManagedPrivateEndpointNameAvailability(KustoManagedPrivateEndpointNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(content, cancellationToken);

        /// <summary> Checks managed private endpoint name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KustoNameAvailabilityResult>> CheckKustoManagedPrivateEndpointNameAvailabilityAsync(KustoManagedPrivateEndpointNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(content, cancellationToken);

        /// <summary> Checks sandbox custom image name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KustoNameAvailabilityResult> CheckNameAvailabilitySandboxCustomImage(SandboxCustomImagesCheckNameContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(content, cancellationToken);

        /// <summary> Checks sandbox custom image name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KustoNameAvailabilityResult>> CheckNameAvailabilitySandboxCustomImageAsync(SandboxCustomImagesCheckNameContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(content, cancellationToken);
    }
}
