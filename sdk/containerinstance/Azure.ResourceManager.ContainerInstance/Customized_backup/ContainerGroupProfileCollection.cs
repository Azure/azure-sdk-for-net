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
using Azure.ResourceManager.ContainerInstance.Models;

namespace Azure.ResourceManager.ContainerInstance
{
    // Backward-compat alias: ContainerGroupProfileCollection was renamed to CGProfileCollection in TypeSpec migration.
    /// <summary> A class representing the ContainerGroupProfile collection and its operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupProfileCollection : CGProfileCollection,
        IEnumerable<ContainerGroupProfileResource>,
        IAsyncEnumerable<ContainerGroupProfileResource>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileCollection"/>. </summary>
        protected ContainerGroupProfileCollection()
        {
        }

        // backward-compat shim: old return type was ArmOperation<ContainerGroupProfileResource>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual ArmOperation<ContainerGroupProfileResource> CreateOrUpdate(WaitUntil waitUntil, string containerGroupProfileName, ContainerGroupProfileData data, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileCollection.CreateOrUpdate() instead.");

        // backward-compat shim: old return type was Task<ArmOperation<ContainerGroupProfileResource>>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Task<ArmOperation<ContainerGroupProfileResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string containerGroupProfileName, ContainerGroupProfileData data, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileCollection.CreateOrUpdateAsync() instead.");

        // backward-compat shim: old return type was Response<ContainerGroupProfileResource>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> Get(string containerGroupProfileName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileCollection.Get() instead.");

        // backward-compat shim: old return type was Task<Response<ContainerGroupProfileResource>>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Task<Response<ContainerGroupProfileResource>> GetAsync(string containerGroupProfileName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileCollection.GetAsync() instead.");

        // backward-compat shim: old return type was Pageable<ContainerGroupProfileResource>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Pageable<ContainerGroupProfileResource> GetAll(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileCollection.GetAll() instead.");

        // backward-compat shim: old return type was AsyncPageable<ContainerGroupProfileResource>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual AsyncPageable<ContainerGroupProfileResource> GetAllAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileCollection.GetAllAsync() instead.");

        // backward-compat shim: old return type was NullableResponse<ContainerGroupProfileResource>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual NullableResponse<ContainerGroupProfileResource> GetIfExists(string containerGroupProfileName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileCollection.GetIfExists() instead.");

        // backward-compat shim: old return type was Task<NullableResponse<ContainerGroupProfileResource>>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Task<NullableResponse<ContainerGroupProfileResource>> GetIfExistsAsync(string containerGroupProfileName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Backward compat shim - use CGProfileCollection.GetIfExistsAsync() instead.");

        // backward-compat shim: IEnumerable<ContainerGroupProfileResource>
        IEnumerator<ContainerGroupProfileResource> IEnumerable<ContainerGroupProfileResource>.GetEnumerator()
            => throw new NotSupportedException("Backward compat shim.");

        // backward-compat shim: IAsyncEnumerable<ContainerGroupProfileResource>
        IAsyncEnumerator<ContainerGroupProfileResource> IAsyncEnumerable<ContainerGroupProfileResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => throw new NotSupportedException("Backward compat shim.");

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotSupportedException("Backward compat shim.");
    }
}
