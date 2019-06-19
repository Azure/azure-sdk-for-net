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
    /// Operations for managing datasources. 
    /// <see href="https://docs.microsoft.com/rest/api/searchservice/Indexer-operations" />
    /// </summary>
    public static partial class DataSourcesOperationsExtensions
    {
        /// <summary>
        /// Creates a new Azure Search datasource or updates a datasource if it already
        /// exists.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Update-Data-Source" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='dataSource'>
        /// The definition of the datasource to create or update.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation.
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation.
        /// </param>
        /// <returns>
        /// The datasource that was created or updated.
        /// </returns>
        public static DataSource CreateOrUpdate(this IDataSourcesOperations operations, DataSource dataSource, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition))
        {
            return operations.CreateOrUpdateAsync(dataSource, searchRequestOptions, accessCondition).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a new Azure Search datasource or updates a datasource if it already
        /// exists.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Update-Data-Source" />
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='dataSource'>
        /// The definition of the datasource to create or update.
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
        /// <returns>
        /// The datasource that was created or updated.
        /// </returns>
        public static async Task<DataSource> CreateOrUpdateAsync(this IDataSourcesOperations operations, DataSource dataSource, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(dataSource, searchRequestOptions, accessCondition, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Determines whether or not the given data source exists in the Azure Search service.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="dataSourceName">
        /// The name of the data source.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation.
        /// </param>
        /// <returns>
        /// <c>true</c> if the data source exists; <c>false</c> otherwise.
        /// </returns>
        public static bool Exists(
            this IDataSourcesOperations operations, 
            string dataSourceName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.ExistsAsync(dataSourceName, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Determines whether or not the given data source exists in the Azure Search service.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="dataSourceName">
        /// The name of the data source.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// <c>true</c> if the data source exists; <c>false</c> otherwise.
        /// </returns>
        public static async Task<bool> ExistsAsync(
            this IDataSourcesOperations operations, 
            string dataSourceName, 
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<bool> result = await operations.ExistsWithHttpMessagesAsync(dataSourceName, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
