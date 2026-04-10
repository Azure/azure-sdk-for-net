// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceRoleInstanceCollection : ArmCollection, IEnumerable<CloudServiceRoleInstanceResource>, IAsyncEnumerable<CloudServiceRoleInstanceResource>
    {
        private const string _notSupported = "CloudService operations are no longer supported in this version.";

        /// <summary> Initializes a new instance of CloudServiceRoleInstanceCollection for mocking. </summary>
        protected CloudServiceRoleInstanceCollection()
        {
        }

        internal CloudServiceRoleInstanceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<CloudServiceRoleInstanceResource> Get(string roleInstanceName, InstanceViewType? expand = null, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<CloudServiceRoleInstanceResource>> GetAsync(string roleInstanceName, InstanceViewType? expand = null, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CloudServiceRoleInstanceResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CloudServiceRoleInstanceResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string roleInstanceName, InstanceViewType? expand = null, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string roleInstanceName, InstanceViewType? expand = null, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<CloudServiceRoleInstanceResource> GetIfExists(string roleInstanceName, InstanceViewType? expand = null, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<CloudServiceRoleInstanceResource>> GetIfExistsAsync(string roleInstanceName, InstanceViewType? expand = null, CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        IEnumerator<CloudServiceRoleInstanceResource> IEnumerable<CloudServiceRoleInstanceResource>.GetEnumerator() => throw new NotSupportedException(_notSupported);

        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(_notSupported);

        IAsyncEnumerator<CloudServiceRoleInstanceResource> IAsyncEnumerable<CloudServiceRoleInstanceResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException(_notSupported);
    }
}
