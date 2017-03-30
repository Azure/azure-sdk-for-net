// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Operations for managing synonymmaps. 
    /// </summary>
    public static partial class SynonymMapsOperationsExtensions
    {
        /// <summary>
        /// Creates a new Azure Search synonymmap or updates a synonymmap if it
        /// already exists.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='synonymMap'>
        /// The definition of the synonymmap to create or update.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation
        /// </param>
        public static SynonymMap CreateOrUpdate(this ISynonymMapsOperations operations, SynonymMap synonymMap, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition))
        {
            return operations.CreateOrUpdateAsync(synonymMap, searchRequestOptions, accessCondition).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a new Azure Search synonymmap or updates a synonymmap if it
        /// already exists.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='synonymMap'>
        /// The definition of the synonymmap to create or update.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<SynonymMap> CreateOrUpdateAsync(this ISynonymMapsOperations operations, SynonymMap synonymMap, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(synonymMap, searchRequestOptions, accessCondition, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Determines whether or not the given synonym map exists in the Azure Search service.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="synonymMapName">
        /// The name of the synonym map.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// <c>true</c> if the synonym map exists; <c>false</c> otherwise.
        /// </returns>
        public static bool Exists(
            this ISynonymMapsOperations operations, 
            string synonymMapName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.ExistsAsync(synonymMapName, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Determines whether or not the given synonym map exists in the Azure Search service.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="synonymMapName">
        /// The name of the synonym map.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// <c>true</c> if the synonym map exists; <c>false</c> otherwise.
        /// </returns>
        public static async Task<bool> ExistsAsync(
            this ISynonymMapsOperations operations, 
            string synonymMapName, 
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<bool> result = await operations.ExistsWithHttpMessagesAsync(synonymMapName, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
