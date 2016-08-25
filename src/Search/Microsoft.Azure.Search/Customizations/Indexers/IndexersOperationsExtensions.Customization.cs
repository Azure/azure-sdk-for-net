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
    /// Operations for managing indexers. 
    /// <see href="https://msdn.microsoft.com/library/azure/dn946891.aspx" />
    /// </summary>
    public static partial class IndexersOperationsExtensions
    {
        /// <summary>
        /// Creates a new Azure Search indexer or updates an indexer if it already
        /// exists.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='indexer'>
        /// The definition of the indexer to create or update.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation
        /// </param>
        public static Indexer CreateOrUpdate(this IIndexersOperations operations, Indexer indexer, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition))
        {
            return Task.Factory.StartNew(s => ((IIndexersOperations)s).CreateOrUpdateAsync(indexer, searchRequestOptions, accessCondition), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a new Azure Search indexer or updates an indexer if it already
        /// exists.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='indexer'>
        /// The definition of the indexer to create or update.
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
        public static async Task<Indexer> CreateOrUpdateAsync(this IIndexersOperations operations, Indexer indexer, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(indexer, searchRequestOptions, accessCondition, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Determines whether or not the given indexer exists in the Azure Search service.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="indexerName">
        /// The name of the indexer.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// <c>true</c> if the indexer exists; <c>false</c> otherwise.
        /// </returns>
        public static bool Exists(
            this IIndexersOperations operations, 
            string indexerName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return Task.Factory.StartNew(s => ((IIndexersOperations)s).ExistsAsync(indexerName, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Determines whether or not the given indexer exists in the Azure Search service.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="indexerName">
        /// The name of the indexer.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// <c>true</c> if the indexer exists; <c>false</c> otherwise.
        /// </returns>
        public static async Task<bool> ExistsAsync(
            this IIndexersOperations operations, 
            string indexerName, 
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<bool> result = await operations.ExistsWithHttpMessagesAsync(indexerName, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
