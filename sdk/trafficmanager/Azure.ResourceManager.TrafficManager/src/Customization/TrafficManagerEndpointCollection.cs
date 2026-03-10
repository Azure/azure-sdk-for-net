// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.TrafficManager.Models;

namespace Azure.ResourceManager.TrafficManager
{
    /// <summary>
    /// The class to overcome issue with the TrafficManagerEndpointData Collection REST API where there is no REST API counterpart that GETs all
    /// endpoint data resources. The all endpoint data resources are retrieved from the collection of endpoints attached to <see cref="TrafficManagerProfileData"/>.
    /// </summary>
    public partial class TrafficManagerEndpointCollection : ArmCollection, IEnumerable<TrafficManagerEndpointData>, IAsyncEnumerable<TrafficManagerEndpointData>
    {
        private readonly TrafficManagerProfileData _profileData;

        /// <summary> Initializes a new instance of the <see cref="TrafficManagerEndpointCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// /// <param name="profileData">The parent profile data. </param>
        internal TrafficManagerEndpointCollection(ArmClient client, ResourceIdentifier id, TrafficManagerProfileData profileData) : base(client, id)
        {
            Argument.AssertNotNull(profileData, nameof(profileData));

            this._profileData = profileData;
        }

        /// <summary>
        /// Asynchronously lists all Traffic Manager endpoints within a profile.
        /// </summary>
        /// <returns> A collection of <see cref="TrafficManagerEndpointResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TrafficManagerEndpointData> GetAllAsync()
        {
            if (this._profileData == null)
                throw new InvalidOperationException("The method can work only when the profileData is provided over ctor.");

            return PageableHelpers.CreateAsyncEnumerable(_ => Task.FromResult(Page.FromValues(this._profileData.Endpoints.AsEnumerable(), null, null)), null);
        }

        /// <summary>
        /// Lists all Traffic Manager endpoints within a profile.
        /// </summary>
        /// <returns> A collection of <see cref="TrafficManagerEndpointResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TrafficManagerEndpointData> GetAll()
        {
            if (this._profileData == null)
                throw new InvalidOperationException("The method can work only when the profileData is provided over ctor.");

            return PageableHelpers.CreateEnumerable(_ => Page.FromValues(this._profileData.Endpoints, null, null), null, null);
        }

        /// <summary> Creates or updates a Traffic Manager endpoint. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="data"> The Traffic Manager endpoint parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<TrafficManagerEndpointResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string endpointType, string endpointName, TrafficManagerEndpointData data, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, ParseEndpointType(endpointType), endpointName, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Creates or updates a Traffic Manager endpoint. </summary>
        /// <param name="waitUntil"> Completion option. </param>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint to be created or updated. </param>
        /// <param name="data"> The Traffic Manager endpoint parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<TrafficManagerEndpointResource> CreateOrUpdate(WaitUntil waitUntil, string endpointType, string endpointName, TrafficManagerEndpointData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, ParseEndpointType(endpointType), endpointName, data, cancellationToken);
        }

        /// <summary> Gets a Traffic Manager endpoint. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<TrafficManagerEndpointResource>> GetAsync(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ParseEndpointType(endpointType), endpointName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a Traffic Manager endpoint. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<TrafficManagerEndpointResource> Get(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return Get(ParseEndpointType(endpointType), endpointName, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(ParseEndpointType(endpointType), endpointName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return Exists(ParseEndpointType(endpointType), endpointName, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<TrafficManagerEndpointResource>> GetIfExistsAsync(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(ParseEndpointType(endpointType), endpointName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="endpointType"> The type of the Traffic Manager endpoint. </param>
        /// <param name="endpointName"> The name of the Traffic Manager endpoint. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<TrafficManagerEndpointResource> GetIfExists(string endpointType, string endpointName, CancellationToken cancellationToken = default)
        {
            return GetIfExists(ParseEndpointType(endpointType), endpointName, cancellationToken);
        }

        private static TrafficManagerEndpointType ParseEndpointType(string endpointType)
        {
            return (TrafficManagerEndpointType)Enum.Parse(typeof(TrafficManagerEndpointType), endpointType, true);
        }

        IEnumerator<TrafficManagerEndpointData> IEnumerable<TrafficManagerEndpointData>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TrafficManagerEndpointData> IAsyncEnumerable<TrafficManagerEndpointData>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync().GetAsyncEnumerator(cancellationToken);
        }
    }
}
