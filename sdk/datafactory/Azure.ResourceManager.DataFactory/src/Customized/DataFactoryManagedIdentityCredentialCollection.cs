// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory
{
    // Customization restores the DataFactoryManagedIdentityCredentialCollection back-compat surface.
    //
    // Spec context: only one credential resource type exists in TypeSpec/swagger/Bicep
    // (Microsoft.DataFactory/factories/credentials). The pre-MPG AutoRest SDK exposed a second
    // SDK-only collection over the same REST endpoint to surface the specialized
    // DataFactoryManagedIdentityCredential view. Since the spec does not define this view, the
    // MPG generator does not emit it. This partial reconstructs the collection as a thin delegating
    // wrapper over DataFactoryServiceCredentialCollection so list/get/create operations hit the
    // same REST endpoint while preserving the published API surface.
    /// <summary>
    /// A class representing a collection of <see cref="DataFactoryManagedIdentityCredentialResource"/> and their operations.
    /// Each <see cref="DataFactoryManagedIdentityCredentialResource"/> in the collection will belong to the same instance of <see cref="DataFactoryResource"/>.
    /// To get a <see cref="DataFactoryManagedIdentityCredentialCollection"/> instance call the GetDataFactoryManagedIdentityCredentials method from an instance of <see cref="DataFactoryResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DataFactoryManagedIdentityCredentialCollection : ArmCollection, IEnumerable<DataFactoryManagedIdentityCredentialResource>, IAsyncEnumerable<DataFactoryManagedIdentityCredentialResource>
    {
        private readonly DataFactoryServiceCredentialCollection _inner;

        /// <summary> Initializes a new instance of the <see cref="DataFactoryManagedIdentityCredentialCollection"/> class for mocking. </summary>
        protected DataFactoryManagedIdentityCredentialCollection()
        {
        }

        internal DataFactoryManagedIdentityCredentialCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _inner = new DataFactoryResource(client, id).GetDataFactoryServiceCredentials();
        }

        /// <summary> Creates or updates a credential. </summary>
        public virtual async Task<ArmOperation<DataFactoryManagedIdentityCredentialResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string credentialName, DataFactoryManagedIdentityCredentialData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));
            Argument.AssertNotNull(data, nameof(data));
            var etag = ifMatch != null ? new ETag(ifMatch) : (ETag?)null;
            var operation = await _inner.CreateOrUpdateAsync(waitUntil, credentialName, data.ToServiceCredentialData(), etag, cancellationToken).ConfigureAwait(false);
            return new DataFactoryManagedIdentityCredentialArmOperationWrapper(Client, operation);
        }

        /// <summary> Creates or updates a credential. </summary>
        public virtual ArmOperation<DataFactoryManagedIdentityCredentialResource> CreateOrUpdate(WaitUntil waitUntil, string credentialName, DataFactoryManagedIdentityCredentialData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));
            Argument.AssertNotNull(data, nameof(data));
            var etag = ifMatch != null ? new ETag(ifMatch) : (ETag?)null;
            var operation = _inner.CreateOrUpdate(waitUntil, credentialName, data.ToServiceCredentialData(), etag, cancellationToken);
            return new DataFactoryManagedIdentityCredentialArmOperationWrapper(Client, operation);
        }

        /// <summary> Gets a credential. </summary>
        public virtual async Task<Response<DataFactoryManagedIdentityCredentialResource>> GetAsync(string credentialName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));
            var etag = ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null;
            var response = await _inner.GetAsync(credentialName, etag, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new DataFactoryManagedIdentityCredentialResource(Client, new DataFactoryManagedIdentityCredentialData(response.Value.Data)), response.GetRawResponse());
        }

        /// <summary> Gets a credential. </summary>
        public virtual Response<DataFactoryManagedIdentityCredentialResource> Get(string credentialName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));
            var etag = ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null;
            var response = _inner.Get(credentialName, etag, cancellationToken);
            return Response.FromValue(new DataFactoryManagedIdentityCredentialResource(Client, new DataFactoryManagedIdentityCredentialData(response.Value.Data)), response.GetRawResponse());
        }

        /// <summary> List credentials. </summary>
        public virtual AsyncPageable<DataFactoryManagedIdentityCredentialResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<DataFactoryServiceCredentialResource, DataFactoryManagedIdentityCredentialResource>(
                _inner.GetAllAsync(cancellationToken),
                r => new DataFactoryManagedIdentityCredentialResource(Client, new DataFactoryManagedIdentityCredentialData(r.Data)));
        }

        /// <summary> List credentials. </summary>
        public virtual Pageable<DataFactoryManagedIdentityCredentialResource> GetAll(CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<DataFactoryServiceCredentialResource, DataFactoryManagedIdentityCredentialResource>(
                _inner.GetAll(cancellationToken),
                r => new DataFactoryManagedIdentityCredentialResource(Client, new DataFactoryManagedIdentityCredentialData(r.Data)));
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string credentialName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));
            var etag = ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null;
            return _inner.ExistsAsync(credentialName, etag, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Response<bool> Exists(string credentialName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));
            var etag = ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null;
            return _inner.Exists(credentialName, etag, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual async Task<NullableResponse<DataFactoryManagedIdentityCredentialResource>> GetIfExistsAsync(string credentialName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));
            var etag = ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null;
            var response = await _inner.GetIfExistsAsync(credentialName, etag, cancellationToken).ConfigureAwait(false);
            if (!response.HasValue)
            {
                return new NoValueResponseOfDataFactoryManagedIdentityCredentialResource(response.GetRawResponse());
            }
            return Response.FromValue(new DataFactoryManagedIdentityCredentialResource(Client, new DataFactoryManagedIdentityCredentialData(response.Value.Data)), response.GetRawResponse());
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual NullableResponse<DataFactoryManagedIdentityCredentialResource> GetIfExists(string credentialName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));
            var etag = ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null;
            var response = _inner.GetIfExists(credentialName, etag, cancellationToken);
            if (!response.HasValue)
            {
                return new NoValueResponseOfDataFactoryManagedIdentityCredentialResource(response.GetRawResponse());
            }
            return Response.FromValue(new DataFactoryManagedIdentityCredentialResource(Client, new DataFactoryManagedIdentityCredentialData(response.Value.Data)), response.GetRawResponse());
        }

        IEnumerator<DataFactoryManagedIdentityCredentialResource> IEnumerable<DataFactoryManagedIdentityCredentialResource>.GetEnumerator() => GetAll().GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        IAsyncEnumerator<DataFactoryManagedIdentityCredentialResource> IAsyncEnumerable<DataFactoryManagedIdentityCredentialResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
