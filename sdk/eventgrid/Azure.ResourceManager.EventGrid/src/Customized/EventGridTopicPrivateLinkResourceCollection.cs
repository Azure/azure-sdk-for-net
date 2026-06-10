// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.EventGrid.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: per-parent PLR Collection still emits
    // all 6 operations parameterised on parentType/parentName, dropping the parent-
    // bound back-compat shape. Restore the legacy (name) overloads by delegating to
    // the (parentType, parentName, name) operations using the parentName already
    // stored by the generator and a hardcoded parentType.)
    [CodeGenType("TopicEventGridPrivateLinkResourceCollection")]
    public partial class EventGridTopicPrivateLinkResourceCollection : IEnumerable<EventGridTopicPrivateLinkResource>,
        IAsyncEnumerable<EventGridTopicPrivateLinkResource>
    {
        private static readonly PrivateEndpointConnectionsParentType BackCompatParentType = PrivateEndpointConnectionsParentType.Topics;

        /// <summary> Get a specific private link resource under a topic. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<EventGridTopicPrivateLinkResource>> GetAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetAsync(BackCompatParentType, _parentName, privateLinkResourceName, cancellationToken);
        }

        /// <summary> Get a specific private link resource under a topic. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EventGridTopicPrivateLinkResource> Get(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return Get(BackCompatParentType, _parentName, privateLinkResourceName, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<bool>> ExistsAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return ExistsAsync(BackCompatParentType, _parentName, privateLinkResourceName, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return Exists(BackCompatParentType, _parentName, privateLinkResourceName, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<NullableResponse<EventGridTopicPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetIfExistsAsync(BackCompatParentType, _parentName, privateLinkResourceName, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="privateLinkResourceName"> The name of private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<EventGridTopicPrivateLinkResource> GetIfExists(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetIfExists(BackCompatParentType, _parentName, privateLinkResourceName, cancellationToken);
        }

        /// <summary> Get all private link resources under a topic. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<EventGridTopicPrivateLinkResource> GetAllAsync(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetAllAsync(BackCompatParentType, _parentName, filter, top, cancellationToken);
        }

        /// <summary> Get all private link resources under a topic. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<EventGridTopicPrivateLinkResource> GetAll(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetAll(BackCompatParentType, _parentName, filter, top, cancellationToken);
        }

        IEnumerator<EventGridTopicPrivateLinkResource> IEnumerable<EventGridTopicPrivateLinkResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<EventGridTopicPrivateLinkResource> IAsyncEnumerable<EventGridTopicPrivateLinkResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
