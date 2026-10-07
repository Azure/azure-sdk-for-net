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
    public partial class CloudServiceOSVersionCollection : ArmCollection, IEnumerable<CloudServiceOSVersionResource>, IAsyncEnumerable<CloudServiceOSVersionResource>
    {
        private const string _notSupported = "CloudService operations are no longer supported in this version.";

        /// <summary> Initializes a new instance of CloudServiceOSVersionCollection for mocking. </summary>
        protected CloudServiceOSVersionCollection()
        {
        }

        internal CloudServiceOSVersionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<CloudServiceOSVersionResource> Get(string osVersionName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<CloudServiceOSVersionResource>> GetAsync(string osVersionName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CloudServiceOSVersionResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CloudServiceOSVersionResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string osVersionName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string osVersionName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<CloudServiceOSVersionResource> GetIfExists(string osVersionName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<CloudServiceOSVersionResource>> GetIfExistsAsync(string osVersionName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        IEnumerator<CloudServiceOSVersionResource> IEnumerable<CloudServiceOSVersionResource>.GetEnumerator() => throw new NotSupportedException(_notSupported);

        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(_notSupported);

        IAsyncEnumerator<CloudServiceOSVersionResource> IAsyncEnumerable<CloudServiceOSVersionResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException(_notSupported);
    }
}
