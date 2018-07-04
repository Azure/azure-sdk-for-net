// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Operations for managing indexes.
    /// <see href="https://docs.microsoft.com/rest/api/searchservice/Index-operations" />
    /// </summary>
    public static partial class IndexesOperationsExtensions
    {
        /// <summary>
        /// Creates a new Azure Search index or updates an index if it already exists.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Update-Index" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='index'>
        /// The definition of the index to create or update.
        /// </param>
        /// <param name='allowIndexDowntime'>
        /// Allows new analyzers, tokenizers, token filters, or char filters
        /// to be added to an index by taking the index offline for at least
        /// a few seconds. This temporarily causes indexing and query
        /// requests to fail. Performance and write availability of the index
        /// can be impaired for several minutes after the index is updated,
        /// or longer for very large indexes.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation.
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation.
        /// </param>
        /// <returns>
        /// The index that was created or updated.
        /// </returns>
        public static Index CreateOrUpdate(this IIndexesOperations operations, Index index, bool? allowIndexDowntime = default(bool?), SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition))
        {
            return operations.CreateOrUpdateAsync(index, allowIndexDowntime, searchRequestOptions, accessCondition).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a new Azure Search index or updates an index if it already exists.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Update-Index" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='index'>
        /// The definition of the index to create or update.
        /// </param>
        /// <param name='allowIndexDowntime'>
        /// Allows new analyzers, tokenizers, token filters, or char filters
        /// to be added to an index by taking the index offline for at least
        /// a few seconds. This temporarily causes indexing and query
        /// requests to fail. Performance and write availability of the index
        /// can be impaired for several minutes after the index is updated,
        /// or longer for very large indexes.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation.
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The index that was created or updated.
        /// </returns>
        public static async Task<Index> CreateOrUpdateAsync(this IIndexesOperations operations, Index index, bool? allowIndexDowntime = default(bool?), SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(index, allowIndexDowntime, searchRequestOptions, accessCondition, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Determines whether or not the given index exists in the Azure Search service.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="indexName">
        /// The name of the index.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation.
        /// </param>
        /// <returns>
        /// <c>true</c> if the index exists; <c>false</c> otherwise.
        /// </returns>
        public static bool Exists(
            this IIndexesOperations operations, 
            string indexName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.ExistsAsync(indexName, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Determines whether or not the given index exists in the Azure Search service.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="indexName">
        /// The name of the index.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// <c>true</c> if the index exists; <c>false</c> otherwise.
        /// </returns>
        public static async Task<bool> ExistsAsync(
            this IIndexesOperations operations, 
            string indexName, 
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<bool> result = await operations.ExistsWithHttpMessagesAsync(indexName, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Lists the names of all indexes available for an Azure Search
        /// service. Use this instead of List() when you only need index
        /// names. It will save bandwidth and resource utilization, especially
        /// if your Search Service has many indexes.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/List-Indexes"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation.
        /// </param>
        /// <returns>
        /// The list of all index names for the search service.
        /// </returns>
        public static IList<string> ListNames(
            this IIndexesOperations operations,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return GetIndexNames(operations.List(select: "name", searchRequestOptions: searchRequestOptions));
        }

        /// <summary>
        /// Lists the names of all indexes available for an Azure Search
        /// service. Use this instead of List() when you only need index
        /// names. It will save bandwidth and resource utilization, especially
        /// if your Search Service has many indexes.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/List-Indexes"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The list of all index names for the search service.
        /// </returns>
        public static async Task<IList<string>> ListNamesAsync(
            this IIndexesOperations operations, 
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            IndexListResult indexList = 
                await operations.ListAsync(select: "name", searchRequestOptions: searchRequestOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
            return GetIndexNames(indexList);
        }

        private static IList<string> GetIndexNames(IndexListResult indexListResult)
        {
            return indexListResult.Indexes.Select(index => index.Name).ToList();
        }
    }
}
