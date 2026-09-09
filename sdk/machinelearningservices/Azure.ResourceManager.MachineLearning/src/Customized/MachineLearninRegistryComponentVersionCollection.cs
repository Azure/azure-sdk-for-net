// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: the client.tsp resource-name override generates the corrected MachineLearning* collection,
    // while the previously shipped MachineLearnin* collection must remain for compatibility. Inherit the
    // corrected implementation and project invariant operation, response, and pageable values to the legacy type.
    /// <summary> A class representing a collection of <see cref="MachineLearninRegistryComponentVersionResource"/> and their operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("MachineLearninRegistryComponentVersionCollection is obsolete and will be removed in a future release. Please use MachineLearningRegistryComponentVersionCollection instead.")]
    public partial class MachineLearninRegistryComponentVersionCollection : MachineLearningRegistryComponentVersionCollection, IEnumerable<MachineLearninRegistryComponentVersionResource>, IAsyncEnumerable<MachineLearninRegistryComponentVersionResource>
    {
        /// <summary> Initializes a new instance of MachineLearninRegistryComponentVersionCollection for mocking. </summary>
        protected MachineLearninRegistryComponentVersionCollection()
        {
        }

        internal MachineLearninRegistryComponentVersionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Create or update version. </summary>
        public new virtual async Task<ArmOperation<MachineLearninRegistryComponentVersionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string version, MachineLearningComponentVersionData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<MachineLearningRegistryComponentVersionResource> operation = await base.CreateOrUpdateAsync(waitUntil, version, data, cancellationToken).ConfigureAwait(false);
            return new MachineLearninRegistryComponentCompatOperation<MachineLearningRegistryComponentVersionResource, MachineLearninRegistryComponentVersionResource>(operation, ConvertVersionResource);
        }

        /// <summary> Create or update version. </summary>
        public new virtual ArmOperation<MachineLearninRegistryComponentVersionResource> CreateOrUpdate(WaitUntil waitUntil, string version, MachineLearningComponentVersionData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<MachineLearningRegistryComponentVersionResource> operation = base.CreateOrUpdate(waitUntil, version, data, cancellationToken);
            return new MachineLearninRegistryComponentCompatOperation<MachineLearningRegistryComponentVersionResource, MachineLearninRegistryComponentVersionResource>(operation, ConvertVersionResource);
        }

        /// <summary> Get version. </summary>
        public new virtual async Task<Response<MachineLearninRegistryComponentVersionResource>> GetAsync(string version, CancellationToken cancellationToken = default)
        {
            Response<MachineLearningRegistryComponentVersionResource> response = await base.GetAsync(version, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ConvertVersionResource(response.Value), response.GetRawResponse());
        }

        /// <summary> Get version. </summary>
        public new virtual Response<MachineLearninRegistryComponentVersionResource> Get(string version, CancellationToken cancellationToken = default)
        {
            Response<MachineLearningRegistryComponentVersionResource> response = base.Get(version, cancellationToken);
            return Response.FromValue(ConvertVersionResource(response.Value), response.GetRawResponse());
        }

        /// <summary> List versions. </summary>
        public new virtual AsyncPageable<MachineLearninRegistryComponentVersionResource> GetAllAsync(string orderBy = default, int? top = default, string skip = default, CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<MachineLearningRegistryComponentVersionResource, MachineLearninRegistryComponentVersionResource>(base.GetAllAsync(orderBy, top, skip, cancellationToken), ConvertVersionResource);
        }

        /// <summary> List versions. </summary>
        public new virtual Pageable<MachineLearninRegistryComponentVersionResource> GetAll(string orderBy = default, int? top = default, string skip = default, CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<MachineLearningRegistryComponentVersionResource, MachineLearninRegistryComponentVersionResource>(base.GetAll(orderBy, top, skip, cancellationToken), ConvertVersionResource);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        public new virtual async Task<NullableResponse<MachineLearninRegistryComponentVersionResource>> GetIfExistsAsync(string version, CancellationToken cancellationToken = default)
        {
            NullableResponse<MachineLearningRegistryComponentVersionResource> response = await base.GetIfExistsAsync(version, cancellationToken).ConfigureAwait(false);
            return response.HasValue ? Response.FromValue(ConvertVersionResource(response.Value), response.GetRawResponse()) : new NoValueResponse<MachineLearninRegistryComponentVersionResource>(response.GetRawResponse());
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        public new virtual NullableResponse<MachineLearninRegistryComponentVersionResource> GetIfExists(string version, CancellationToken cancellationToken = default)
        {
            NullableResponse<MachineLearningRegistryComponentVersionResource> response = base.GetIfExists(version, cancellationToken);
            return response.HasValue ? Response.FromValue(ConvertVersionResource(response.Value), response.GetRawResponse()) : new NoValueResponse<MachineLearninRegistryComponentVersionResource>(response.GetRawResponse());
        }

        IEnumerator<MachineLearninRegistryComponentVersionResource> IEnumerable<MachineLearninRegistryComponentVersionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MachineLearninRegistryComponentVersionResource> IAsyncEnumerable<MachineLearninRegistryComponentVersionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        private MachineLearninRegistryComponentVersionResource ConvertVersionResource(MachineLearningRegistryComponentVersionResource resource)
        {
            return resource.HasData ? new MachineLearninRegistryComponentVersionResource(Client, resource.Data) : new MachineLearninRegistryComponentVersionResource(Client, resource.Id);
        }
    }
}
