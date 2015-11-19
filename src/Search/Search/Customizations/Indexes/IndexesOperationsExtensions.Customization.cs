// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    public static partial class IndexesOperationsExtensions
    {
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
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// <c>true</c> if the index exists; <c>false</c> otherwise.
        /// </returns>
        public static bool Exists(
            this IIndexesOperations operations, 
            string indexName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return Task.Factory.StartNew(s => ((IIndexesOperations)s).ExistsAsync(indexName, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
        /// Additional parameters for the operation
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
            try
            {
                // Get validates indexName.
                await operations.GetAsync(indexName, searchRequestOptions, cancellationToken).ConfigureAwait(false);
                return true;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        /// <summary>
        /// Lists the names of all indexes available for an Azure Search
        /// service. Use this instead of List() when you only need index
        /// names. It will save bandwidth and resource utilization, especially
        /// if your Search Service has many indexes.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798923.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
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
        /// <see href="https://msdn.microsoft.com/library/azure/dn798923.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
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
