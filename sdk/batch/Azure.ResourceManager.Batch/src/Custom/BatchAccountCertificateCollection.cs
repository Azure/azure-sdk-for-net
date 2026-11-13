// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Batch.Models;

namespace Azure.ResourceManager.Batch
{
    /// <summary>
    /// A class representing a collection of <see cref="BatchAccountCertificateResource"/> and their operations.
    /// </summary>
    [Obsolete("This type is obsolete and will be removed in a future release. Certificate management APIs have been removed from the Batch service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class BatchAccountCertificateCollection : ArmCollection, IEnumerable<BatchAccountCertificateResource>, IAsyncEnumerable<BatchAccountCertificateResource>
    {
        /// <summary> Initializes a new instance of the <see cref="BatchAccountCertificateCollection"/> class. </summary>
        protected BatchAccountCertificateCollection()
        {
        }

        /// <summary> Creates a new certificate inside the specified account. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO. </param>
        /// <param name="certificateName"> The identifier for the certificate. </param>
        /// <param name="content"> Additional parameters for certificate creation. </param>
        /// <param name="ifMatch"> ETag of the certificate entity. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new certificate to be created, but to prevent updating an existing certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BatchAccountCertificateResource> CreateOrUpdate(WaitUntil waitUntil, string certificateName, BatchAccountCertificateCreateOrUpdateContent content, ETag? ifMatch = default, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Creates a new certificate inside the specified account. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO. </param>
        /// <param name="certificateName"> The identifier for the certificate. </param>
        /// <param name="content"> Additional parameters for certificate creation. </param>
        /// <param name="ifMatch"> ETag of the certificate entity. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new certificate to be created, but to prevent updating an existing certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<BatchAccountCertificateResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string certificateName, BatchAccountCertificateCreateOrUpdateContent content, ETag? ifMatch = default, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Gets information about the specified certificate. </summary>
        /// <param name="certificateName"> The identifier for the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BatchAccountCertificateResource> Get(string certificateName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Gets information about the specified certificate. </summary>
        /// <param name="certificateName"> The identifier for the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BatchAccountCertificateResource>> GetAsync(string certificateName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Lists all of the certificates in the specified account. </summary>
        /// <param name="maxresults"> The maximum number of items to return in the response. </param>
        /// <param name="select"> Comma separated list of properties that should be returned. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BatchAccountCertificateResource> GetAll(int? maxresults = default, string select = null, string filter = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Lists all of the certificates in the specified account. </summary>
        /// <param name="maxresults"> The maximum number of items to return in the response. </param>
        /// <param name="select"> Comma separated list of properties that should be returned. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BatchAccountCertificateResource> GetAllAsync(int? maxresults = default, string select = null, string filter = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="certificateName"> The identifier for the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string certificateName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="certificateName"> The identifier for the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string certificateName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="certificateName"> The identifier for the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<BatchAccountCertificateResource> GetIfExists(string certificateName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="certificateName"> The identifier for the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<BatchAccountCertificateResource>> GetIfExistsAsync(string certificateName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        IEnumerator<BatchAccountCertificateResource> IEnumerable<BatchAccountCertificateResource>.GetEnumerator()
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");

        IAsyncEnumerator<BatchAccountCertificateResource> IAsyncEnumerable<BatchAccountCertificateResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => throw new NotSupportedException("Certificate management APIs have been removed from the Batch service.");
    }
}
