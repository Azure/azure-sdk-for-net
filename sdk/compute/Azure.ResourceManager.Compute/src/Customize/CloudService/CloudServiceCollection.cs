// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceCollection : ArmCollection, IEnumerable<CloudServiceResource>, IAsyncEnumerable<CloudServiceResource>
    {
        private const string _notSupported = "CloudService operations are no longer supported in this version.";

        /// <summary> Initializes a new instance of CloudServiceCollection for mocking. </summary>
        protected CloudServiceCollection()
        {
        }

        internal CloudServiceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<CloudServiceResource> CreateOrUpdate(WaitUntil waitUntil, string cloudServiceName, CloudServiceData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<CloudServiceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string cloudServiceName, CloudServiceData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<CloudServiceResource> Get(string cloudServiceName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<CloudServiceResource>> GetAsync(string cloudServiceName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CloudServiceResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CloudServiceResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string cloudServiceName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string cloudServiceName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<CloudServiceResource> GetIfExists(string cloudServiceName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<CloudServiceResource>> GetIfExistsAsync(string cloudServiceName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        IEnumerator<CloudServiceResource> IEnumerable<CloudServiceResource>.GetEnumerator() => throw new NotSupportedException(_notSupported);

        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(_notSupported);

        IAsyncEnumerator<CloudServiceResource> IAsyncEnumerable<CloudServiceResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException(_notSupported);
    }
}
