// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.TrafficManager
{
    /// <summary>
    /// The class to overcome issue with the Endpoint Collection REST API where there is no REST API couterpart that GETs all
    /// profile data resource. The all profile data resources are retrived from the collection of endpoints attached to <see cref="ProfileData"/>.
    /// </summary>
    public partial class EndpointCollection : ArmCollection
    {
        private readonly ProfileData _profileData;

        /// <summary> Initializes a new instance of the <see cref="EndpointCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// /// <param name="profileData">The parent profile data. </param>
        internal EndpointCollection(ArmClient client, ResourceIdentifier id, ProfileData profileData) : this(client, id)
        {
            Argument.AssertNull(profileData, nameof(profileData));

            this._profileData = profileData;
        }

        /// <summary>
        /// Asynchroniosly lists all Traffic Manager endpoints within a profile.
        /// </summary>
        /// <returns> A collection of <see cref="EndpointResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EndpointData> GetAllAsync()
        {
            if (this._profileData == null)
                throw new InvalidOperationException("The method can work only when the profileData is provided over ctor.");

            return PageableHelpers.CreateAsyncEnumerable(_ => Task.FromResult(Page.FromValues(this._profileData.Endpoints.AsEnumerable(), null, null)), null);
        }

        /// <summary>
        /// Lists all Traffic Manager endpoints within a profile.
        /// </summary>
        /// <returns> A collection of <see cref="EndpointResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EndpointData> GetAll()
        {
            if (this._profileData == null)
                throw new InvalidOperationException("The method can work only when the profileData is provided over ctor.");

            return PageableHelpers.CreateEnumerable(_ => Page.FromValues(this._profileData.Endpoints, null, null), null, null);
        }
    }
}
