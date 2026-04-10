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
    public partial class CloudServiceRoleCollection : ArmCollection, IEnumerable<CloudServiceRoleResource>, IAsyncEnumerable<CloudServiceRoleResource>
    {
        private const string _notSupported = "CloudService operations are no longer supported in this version.";

        /// <summary> Initializes a new instance of CloudServiceRoleCollection for mocking. </summary>
        protected CloudServiceRoleCollection()
        {
        }

        internal CloudServiceRoleCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<CloudServiceRoleResource> Get(string roleName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<CloudServiceRoleResource>> GetAsync(string roleName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CloudServiceRoleResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CloudServiceRoleResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string roleName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string roleName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<CloudServiceRoleResource> GetIfExists(string roleName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<CloudServiceRoleResource>> GetIfExistsAsync(string roleName, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        IEnumerator<CloudServiceRoleResource> IEnumerable<CloudServiceRoleResource>.GetEnumerator() => throw new NotSupportedException(_notSupported);

        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(_notSupported);

        IAsyncEnumerator<CloudServiceRoleResource> IAsyncEnumerable<CloudServiceRoleResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException(_notSupported);
    }
}
