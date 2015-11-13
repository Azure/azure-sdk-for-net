﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    public static partial class DataSourcesOperationsExtensions
    {
        /// <summary>
        /// Creates a new Azure Search datasource or updates a datasource if it
        /// already exists.
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
        public static DataSource CreateOrUpdate(
            this IDataSourcesOperations operations, 
            DataSource dataSource,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.CreateOrUpdate(dataSource.Name, dataSource, searchRequestOptions);
        }

        /// <summary>
        /// Creates a new Azure Search datasource or updates a datasource if it
        /// already exists.
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static Task<DataSource> CreateOrUpdateAsync(
            this IDataSourcesOperations operations, 
            DataSource dataSource, 
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return operations.CreateOrUpdateAsync(dataSource.Name, dataSource, searchRequestOptions, cancellationToken);
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
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// <c>true</c> if the data source exists; <c>false</c> otherwise.
        /// </returns>
        public static bool Exists(
            this IDataSourcesOperations operations, 
            string dataSourceName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return Task.Factory.StartNew(s => ((IDataSourcesOperations)s).ExistsAsync(dataSourceName, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
        /// Additional parameters for the operation
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
            try
            {
                // Get validates indexName.
                await operations.GetAsync(dataSourceName, searchRequestOptions, cancellationToken).ConfigureAwait(false);
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
    }
}
