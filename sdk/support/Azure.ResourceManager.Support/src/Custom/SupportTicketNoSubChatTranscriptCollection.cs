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
    public partial class SupportTicketNoSubChatTranscriptCollection : IEnumerable<SupportTicketNoSubChatTranscriptResource>, IAsyncEnumerable<SupportTicketNoSubChatTranscriptResource>
    {
        /// <summary>
        /// Lists all chat transcripts for a support ticket
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupportTicketNoSubChatTranscriptResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SupportTicketNoSubChatTranscriptResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<ChatTranscriptDetailData, SupportTicketNoSubChatTranscriptResource>(new SupportTicketNoSubChatTranscriptGetAllAsyncCollectionResultOfT(_supportTicketNoSubChatTranscriptRestClient, Id.Name, context), data => new SupportTicketNoSubChatTranscriptResource(Client, data));
        }

        /// <summary>
        /// Lists all chat transcripts for a support ticket
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupportTicketNoSubChatTranscriptResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SupportTicketNoSubChatTranscriptResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<ChatTranscriptDetailData, SupportTicketNoSubChatTranscriptResource>(new SupportTicketNoSubChatTranscriptGetAllCollectionResultOfT(_supportTicketNoSubChatTranscriptRestClient, Id.Name, context), data => new SupportTicketNoSubChatTranscriptResource(Client, data));
        }

        IEnumerator<SupportTicketNoSubChatTranscriptResource> IEnumerable<SupportTicketNoSubChatTranscriptResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<SupportTicketNoSubChatTranscriptResource> IAsyncEnumerable<SupportTicketNoSubChatTranscriptResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
