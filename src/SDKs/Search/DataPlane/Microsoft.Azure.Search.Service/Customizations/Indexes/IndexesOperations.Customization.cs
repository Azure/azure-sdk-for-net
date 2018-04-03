// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    internal partial class IndexesOperations
    {
        /// <inheritdoc />
        public Task<AzureOperationResponse<Index>> CreateOrUpdateWithHttpMessagesAsync(Index index, bool? allowIndexDowntime = default(bool?), SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return CreateOrUpdateWithHttpMessagesAsync(index != null ? index.Name : null, index, allowIndexDowntime, searchRequestOptions, accessCondition, customHeaders, cancellationToken);
        }
        
        /// <inheritdoc />
        public Task<AzureOperationResponse<bool>> ExistsWithHttpMessagesAsync(
            string indexName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExistsHelper.ExistsFromGetResponse(() =>
                this.GetWithHttpMessagesAsync(indexName, searchRequestOptions, customHeaders, cancellationToken));
        }
    }
}
