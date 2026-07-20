// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    // The service has a singleton resource at /locations/{location}/applicationGatewayWafDynamicManifests/dafault,
    // but the shipped SDK exposed a location-scoped collection facade. Keep that facade and delegate
    // to the generated singleton resource so compatibility members remain functional.
    /// <summary> Compatibility declaration for the ApplicationGatewayWafDynamicManifestCollection type. </summary>
    public partial class ApplicationGatewayWafDynamicManifestCollection : ArmCollection, IEnumerable<ApplicationGatewayWafDynamicManifestResource>, IAsyncEnumerable<ApplicationGatewayWafDynamicManifestResource>
    {
        private readonly ResourceIdentifier _id;
        private readonly AzureLocation _location;

        /// <summary> Initializes a new instance of the ApplicationGatewayWafDynamicManifestCollection class. </summary>
        protected ApplicationGatewayWafDynamicManifestCollection() { }

        internal ApplicationGatewayWafDynamicManifestCollection(ArmClient client, ResourceIdentifier id, AzureLocation location) : base(client, id)
        {
            _id = id;
            _location = location;
        }

        /// <summary> Invokes the ApplicationGatewayWafDynamicManifestAsyncPageable compatibility operation. </summary>
        public virtual AsyncPageable<ApplicationGatewayWafDynamicManifestResource> GetAllAsync(CancellationToken cancellationToken = default) => new ApplicationGatewayWafDynamicManifestAsyncPageable(GetAsync, cancellationToken);
        /// <summary> Invokes the GetAll compatibility operation. </summary>
        public virtual Pageable<ApplicationGatewayWafDynamicManifestResource> GetAll(CancellationToken cancellationToken = default) => Pageable<ApplicationGatewayWafDynamicManifestResource>.FromPages(GetPages(cancellationToken));
        /// <summary> Invokes the Get compatibility operation. </summary>
        public virtual NullableResponse<ApplicationGatewayWafDynamicManifestResource> GetIfExists(CancellationToken cancellationToken = default) => Get(cancellationToken);
        /// <summary> Invokes the GetIfExists compatibility operation. </summary>
        public virtual NullableResponse<ApplicationGatewayWafDynamicManifestResource> GetIfExists(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default) => GetIfExists(cancellationToken);
        /// <summary> Invokes the GetResource compatibility operation. </summary>
        public virtual Response<ApplicationGatewayWafDynamicManifestResource> Get(CancellationToken cancellationToken = default) => GetResource().Get(cancellationToken);
        /// <summary> Invokes the Get compatibility operation. </summary>
        public virtual Response<ApplicationGatewayWafDynamicManifestResource> Get(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default) => Get(cancellationToken);
        /// <summary> Invokes the Exists compatibility operation. </summary>
        public virtual Response<bool> Exists(CancellationToken cancellationToken = default)
        {
            Response<ApplicationGatewayWafDynamicManifestResource> response = Get(cancellationToken);
            return Response.FromValue(response.Value is not null, response.GetRawResponse());
        }
        /// <summary> Invokes the Exists compatibility operation. </summary>
        public virtual Response<bool> Exists(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default) => Exists(cancellationToken);
        /// <summary> Invokes the GetAsync compatibility operation. </summary>
        public virtual async Task<NullableResponse<ApplicationGatewayWafDynamicManifestResource>> GetIfExistsAsync(CancellationToken cancellationToken = default) => await GetAsync(cancellationToken).ConfigureAwait(false);
        /// <summary> Invokes the GetIfExistsAsync compatibility operation. </summary>
        public virtual Task<NullableResponse<ApplicationGatewayWafDynamicManifestResource>> GetIfExistsAsync(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default) => GetIfExistsAsync(cancellationToken);
        /// <summary> Invokes the GetResource compatibility operation. </summary>
        public virtual Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetAsync(CancellationToken cancellationToken = default) => GetResource().GetAsync(cancellationToken);
        /// <summary> Invokes the GetAsync compatibility operation. </summary>
        public virtual Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetAsync(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default) => GetAsync(cancellationToken);
        /// <summary> Invokes the ExistsAsync compatibility operation. </summary>
        public virtual async Task<Response<bool>> ExistsAsync(CancellationToken cancellationToken = default)
        {
            Response<ApplicationGatewayWafDynamicManifestResource> response = await GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value is not null, response.GetRawResponse());
        }
        /// <summary> Invokes the ExistsAsync compatibility operation. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string applicationGatewayWafDynamicManifestName, CancellationToken cancellationToken = default) => ExistsAsync(cancellationToken);
        IAsyncEnumerator<ApplicationGatewayWafDynamicManifestResource> IAsyncEnumerable<ApplicationGatewayWafDynamicManifestResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        IEnumerator<ApplicationGatewayWafDynamicManifestResource> IEnumerable<ApplicationGatewayWafDynamicManifestResource>.GetEnumerator() => GetAll().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        private ApplicationGatewayWafDynamicManifestResource GetResource()
            => Client.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(_id.SubscriptionId, _location.ToString()));

        private IEnumerable<Page<ApplicationGatewayWafDynamicManifestResource>> GetPages(CancellationToken cancellationToken)
        {
            Response<ApplicationGatewayWafDynamicManifestResource> response = Get(cancellationToken);
            yield return Page<ApplicationGatewayWafDynamicManifestResource>.FromValues(new[] { response.Value }, default, response.GetRawResponse());
        }
    }
}
