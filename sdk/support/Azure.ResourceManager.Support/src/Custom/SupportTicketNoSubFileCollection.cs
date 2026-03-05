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
    public partial class SupportTicketNoSubFileCollection : IEnumerable<SupportTicketNoSubFileResource>, IAsyncEnumerable<SupportTicketNoSubFileResource>
    {
        /// <summary>
        /// Lists all the Files information under a workspace for an Azure subscription.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupportTicketNoSubFileResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SupportTicketNoSubFileResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SupportFileDetailData, SupportTicketNoSubFileResource>(new SupportTicketNoSubFileGetAllAsyncCollectionResultOfT(_supportTicketNoSubFileRestClient, Id.Name, context), data => new SupportTicketNoSubFileResource(Client, data));
        }

        /// <summary>
        /// Lists all the Files information under a workspace for an Azure subscription.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupportTicketNoSubFileResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SupportTicketNoSubFileResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SupportFileDetailData, SupportTicketNoSubFileResource>(new SupportTicketNoSubFileGetAllCollectionResultOfT(_supportTicketNoSubFileRestClient, Id.Name, context), data => new SupportTicketNoSubFileResource(Client, data));
        }

        IEnumerator<SupportTicketNoSubFileResource> IEnumerable<SupportTicketNoSubFileResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<SupportTicketNoSubFileResource> IAsyncEnumerable<SupportTicketNoSubFileResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
