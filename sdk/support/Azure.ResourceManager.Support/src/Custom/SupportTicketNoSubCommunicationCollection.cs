// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.Support
{
    // The new TypeSpec-based generated code no longer emits GetAll/GetAllAsync methods or
    // IEnumerable<T>/IAsyncEnumerable<T> interface implementations on this collection class.
    // These are re-added here as custom code to preserve backward compatibility with the
    // previously published API surface.
    public partial class SupportTicketNoSubCommunicationCollection : IEnumerable<SupportTicketNoSubCommunicationResource>, IAsyncEnumerable<SupportTicketNoSubCommunicationResource>
    {
        /// <summary>
        /// Lists all communications (attachments not included) for a support ticket.
        /// </summary>
        /// <param name="top"> The number of values to return in the collection. Default is 10 and max is 10. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupportTicketNoSubCommunicationResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SupportTicketNoSubCommunicationResource> GetAllAsync(int? top = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SupportTicketCommunicationData, SupportTicketNoSubCommunicationResource>(new SupportTicketNoSubCommunicationGetAllAsyncCollectionResultOfT(_supportTicketNoSubCommunicationRestClient, Id.Name, top, filter, context), data => new SupportTicketNoSubCommunicationResource(Client, data));
        }

        /// <summary>
        /// Lists all communications (attachments not included) for a support ticket.
        /// </summary>
        /// <param name="top"> The number of values to return in the collection. Default is 10 and max is 10. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupportTicketNoSubCommunicationResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SupportTicketNoSubCommunicationResource> GetAll(int? top = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SupportTicketCommunicationData, SupportTicketNoSubCommunicationResource>(new SupportTicketNoSubCommunicationGetAllCollectionResultOfT(_supportTicketNoSubCommunicationRestClient, Id.Name, top, filter, context), data => new SupportTicketNoSubCommunicationResource(Client, data));
        }

        IEnumerator<SupportTicketNoSubCommunicationResource> IEnumerable<SupportTicketNoSubCommunicationResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<SupportTicketNoSubCommunicationResource> IAsyncEnumerable<SupportTicketNoSubCommunicationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
