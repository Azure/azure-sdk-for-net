// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402, SA1508, CS0618

using System;
using System.Collections;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    // ───────────────────────────────────────────────────────────────
    //  ContainerRegistryTaskCollection
    // ───────────────────────────────────────────────────────────────
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryTaskCollection : ArmCollection, IEnumerable<ContainerRegistryTaskResource>, IAsyncEnumerable<ContainerRegistryTaskResource>
    {
        protected ContainerRegistryTaskCollection() : base() { }

        public virtual Response<bool> Exists(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<bool>> ExistsAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Response<ContainerRegistryTaskResource> Get(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<Response<ContainerRegistryTaskResource>> GetAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Pageable<ContainerRegistryTaskResource> GetAll(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual AsyncPageable<ContainerRegistryTaskResource> GetAllAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual NullableResponse<ContainerRegistryTaskResource> GetIfExists(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<NullableResponse<ContainerRegistryTaskResource>> GetIfExistsAsync(string taskName, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual ArmOperation<ContainerRegistryTaskResource> CreateOrUpdate(WaitUntil waitUntil, string taskName, ContainerRegistryTaskData data, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
        public virtual Task<ArmOperation<ContainerRegistryTaskResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string taskName, ContainerRegistryTaskData data, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        IEnumerator<ContainerRegistryTaskResource> IEnumerable<ContainerRegistryTaskResource>.GetEnumerator() { return GetAll().GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetAll().GetEnumerator(); }
        IAsyncEnumerator<ContainerRegistryTaskResource> IAsyncEnumerable<ContainerRegistryTaskResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
    }
}
