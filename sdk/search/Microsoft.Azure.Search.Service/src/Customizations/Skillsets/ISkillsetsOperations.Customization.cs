// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models;

    public partial interface ISkillsetsOperations
    {
        /// <summary>
        /// Creates a new skillset or updates a skillset if
        /// it already exists.
        /// </summary>
        /// <param name='skillset'>
        /// The definition of the skillset to create or update.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Skillset>> CreateOrUpdateWithHttpMessagesAsync(Skillset skillset, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Determines whether or not the given skillset exists in the search service.
        /// </summary>
        /// <param name="skillsetName">
        /// The name of the skillset.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// A response with the value <c>true</c> if the skillset exists; <c>false</c> otherwise.
        /// </returns>
        Task<AzureOperationResponse<bool>> ExistsWithHttpMessagesAsync(string skillsetName, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}