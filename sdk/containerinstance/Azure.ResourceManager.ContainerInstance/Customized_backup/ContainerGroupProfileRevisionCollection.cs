// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerInstance
{
    // Backward-compat stub: ContainerGroupProfileRevisionCollection was removed in TypeSpec migration.
    // Revisions are now accessed through CGProfileResource.GetAllRevisions().
    /// <summary> A class representing the ContainerGroupProfileRevision collection. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupProfileRevisionCollection : ArmCollection,
        IEnumerable<ContainerGroupProfileRevisionResource>,
        IAsyncEnumerable<ContainerGroupProfileRevisionResource>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileRevisionCollection"/>. </summary>
        protected ContainerGroupProfileRevisionCollection()
        {
        }

        // backward-compat shim: Exists
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string revisionNumber, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfiles() instead.");

        // backward-compat shim: ExistsAsync
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string revisionNumber, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfiles() instead.");

        // backward-compat shim: Get
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerGroupProfileRevisionResource> Get(string revisionNumber, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfile() instead.");

        // backward-compat shim: GetAsync
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ContainerGroupProfileRevisionResource>> GetAsync(string revisionNumber, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfileAsync() instead.");

        // backward-compat shim: GetAll
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ContainerGroupProfileRevisionResource> GetAll(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfiles().GetAll() instead.");

        // backward-compat shim: GetAllAsync
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ContainerGroupProfileRevisionResource> GetAllAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfiles().GetAllAsync() instead.");

        // backward-compat shim: GetIfExists
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<ContainerGroupProfileRevisionResource> GetIfExists(string revisionNumber, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfiles() instead.");

        // backward-compat shim: GetIfExistsAsync
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<ContainerGroupProfileRevisionResource>> GetIfExistsAsync(string revisionNumber, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileResource.GetCGProfiles() instead.");

        IEnumerator<ContainerGroupProfileRevisionResource> IEnumerable<ContainerGroupProfileRevisionResource>.GetEnumerator()
            => throw new NotSupportedException("Backward compat type - use CGProfileResource.GetAllRevisions() instead.");

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotSupportedException("Backward compat type - use CGProfileResource.GetAllRevisions() instead.");

        IAsyncEnumerator<ContainerGroupProfileRevisionResource> IAsyncEnumerable<ContainerGroupProfileRevisionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => throw new NotSupportedException("Backward compat type - use CGProfileResource.GetAllRevisions() instead.");
    }
}
