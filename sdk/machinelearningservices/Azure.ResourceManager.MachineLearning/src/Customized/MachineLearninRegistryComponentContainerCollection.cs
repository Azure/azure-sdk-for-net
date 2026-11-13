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
    /// <summary> A class representing a collection of <see cref="MachineLearninRegistryComponentContainerResource"/> and their operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("MachineLearninRegistryComponentContainerCollection is obsolete and will be removed in a future release. Please use MachineLearningRegistryComponentContainerCollection instead.")]
    public partial class MachineLearninRegistryComponentContainerCollection : MachineLearningRegistryComponentContainerCollection, IEnumerable<MachineLearninRegistryComponentContainerResource>, IAsyncEnumerable<MachineLearninRegistryComponentContainerResource>
    {
        /// <summary> Initializes a new instance of MachineLearninRegistryComponentContainerCollection for mocking. </summary>
        protected MachineLearninRegistryComponentContainerCollection()
        {
        }

        internal MachineLearninRegistryComponentContainerCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Create or update container. </summary>
        public new virtual async Task<ArmOperation<MachineLearninRegistryComponentContainerResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string componentName, MachineLearningComponentContainerData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<MachineLearningRegistryComponentContainerResource> operation = await base.CreateOrUpdateAsync(waitUntil, componentName, data, cancellationToken).ConfigureAwait(false);
            return new MachineLearninRegistryComponentCompatOperation<MachineLearningRegistryComponentContainerResource, MachineLearninRegistryComponentContainerResource>(operation, ConvertContainerResource);
        }

        /// <summary> Create or update container. </summary>
        public new virtual ArmOperation<MachineLearninRegistryComponentContainerResource> CreateOrUpdate(WaitUntil waitUntil, string componentName, MachineLearningComponentContainerData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<MachineLearningRegistryComponentContainerResource> operation = base.CreateOrUpdate(waitUntil, componentName, data, cancellationToken);
            return new MachineLearninRegistryComponentCompatOperation<MachineLearningRegistryComponentContainerResource, MachineLearninRegistryComponentContainerResource>(operation, ConvertContainerResource);
        }

        /// <summary> Get container. </summary>
        public new virtual async Task<Response<MachineLearninRegistryComponentContainerResource>> GetAsync(string componentName, CancellationToken cancellationToken = default)
        {
            Response<MachineLearningRegistryComponentContainerResource> response = await base.GetAsync(componentName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ConvertContainerResource(response.Value), response.GetRawResponse());
        }

        /// <summary> Get container. </summary>
        public new virtual Response<MachineLearninRegistryComponentContainerResource> Get(string componentName, CancellationToken cancellationToken = default)
        {
            Response<MachineLearningRegistryComponentContainerResource> response = base.Get(componentName, cancellationToken);
            return Response.FromValue(ConvertContainerResource(response.Value), response.GetRawResponse());
        }

        /// <summary> List containers. </summary>
        public new virtual AsyncPageable<MachineLearninRegistryComponentContainerResource> GetAllAsync(string skip = default, CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<MachineLearningRegistryComponentContainerResource, MachineLearninRegistryComponentContainerResource>(base.GetAllAsync(skip, cancellationToken), ConvertContainerResource);
        }

        /// <summary> List containers. </summary>
        public new virtual Pageable<MachineLearninRegistryComponentContainerResource> GetAll(string skip = default, CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<MachineLearningRegistryComponentContainerResource, MachineLearninRegistryComponentContainerResource>(base.GetAll(skip, cancellationToken), ConvertContainerResource);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        public new virtual async Task<NullableResponse<MachineLearninRegistryComponentContainerResource>> GetIfExistsAsync(string componentName, CancellationToken cancellationToken = default)
        {
            NullableResponse<MachineLearningRegistryComponentContainerResource> response = await base.GetIfExistsAsync(componentName, cancellationToken).ConfigureAwait(false);
            return response.HasValue ? Response.FromValue(ConvertContainerResource(response.Value), response.GetRawResponse()) : new NoValueResponse<MachineLearninRegistryComponentContainerResource>(response.GetRawResponse());
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        public new virtual NullableResponse<MachineLearninRegistryComponentContainerResource> GetIfExists(string componentName, CancellationToken cancellationToken = default)
        {
            NullableResponse<MachineLearningRegistryComponentContainerResource> response = base.GetIfExists(componentName, cancellationToken);
            return response.HasValue ? Response.FromValue(ConvertContainerResource(response.Value), response.GetRawResponse()) : new NoValueResponse<MachineLearninRegistryComponentContainerResource>(response.GetRawResponse());
        }

        IEnumerator<MachineLearninRegistryComponentContainerResource> IEnumerable<MachineLearninRegistryComponentContainerResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MachineLearninRegistryComponentContainerResource> IAsyncEnumerable<MachineLearninRegistryComponentContainerResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        private MachineLearninRegistryComponentContainerResource ConvertContainerResource(MachineLearningRegistryComponentContainerResource resource)
        {
            return resource.HasData ? new MachineLearninRegistryComponentContainerResource(Client, resource.Data) : new MachineLearninRegistryComponentContainerResource(Client, resource.Id);
        }
    }
}
