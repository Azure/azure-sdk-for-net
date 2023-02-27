// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.TrafficManager
{
    /// <summary>
    /// The class to overcome issue with the TrafficManagerEndpoint Collection REST API where there is no REST API counterpart that GETs all
    /// profile data resource. The all profile data resources are retrieved from the collection of endpoints attached to <see cref="TrafficManagerProfileData"/>.
    /// </summary>
    public partial class TrafficManagerEndpointCollection : ArmCollection, IEnumerable<TrafficManagerEndpointData>, IAsyncEnumerable<TrafficManagerEndpointData>
    {
        private readonly TrafficManagerProfileData _profileData;

        /// <summary> Initializes a new instance of the <see cref="TrafficManagerEndpointCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// /// <param name="profileData">The parent profile data. </param>
        internal TrafficManagerEndpointCollection(ArmClient client, ResourceIdentifier id, TrafficManagerProfileData profileData) : this(client, id)
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
