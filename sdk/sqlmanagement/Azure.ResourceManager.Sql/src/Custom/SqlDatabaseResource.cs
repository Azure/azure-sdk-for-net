// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A Class representing a SqlDatabase along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SqlDatabaseResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSqlDatabaseResource method.
    /// Otherwise you can get one from its parent resource <see cref="SqlServerResource" /> using the GetSqlDatabase method.
    /// </summary>
    public partial class SqlDatabaseResource : ArmResource
    {
        /// <summary>
        /// List database columns
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/columns
        /// Operation Id: DatabaseColumns_ListByDatabase
        /// </summary>
        /// <param name="schema"> The ArrayOfGet3ItemsItem to use. </param>
        /// <param name="table"> The ArrayOfGet4ItemsItem to use. </param>
        /// <param name="column"> The ArrayOfGet5ItemsItem to use. </param>
        /// <param name="orderBy"> The ArrayOfGet6ItemsItem to use. </param>
        /// <param name="skiptoken"> An opaque token that identifies a starting point in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlDatabaseColumnResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlDatabaseColumnResource> GetDatabaseColumnsAsync(IEnumerable<string> schema = null, IEnumerable<string> table = null, IEnumerable<string> column = null, IEnumerable<string> orderBy = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SqlDatabaseColumnResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlDatabaseColumnDatabaseColumnsClientDiagnostics.CreateScope("SqlDatabaseResource.GetDatabaseColumns");
                scope.Start();
                try
                {
                    var response = await _sqlDatabaseColumnDatabaseColumnsRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseColumnResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SqlDatabaseColumnResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlDatabaseColumnDatabaseColumnsClientDiagnostics.CreateScope("SqlDatabaseResource.GetDatabaseColumns");
                scope.Start();
                try
                {
                    var response = await _sqlDatabaseColumnDatabaseColumnsRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseColumnResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List database columns
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/columns
        /// Operation Id: DatabaseColumns_ListByDatabase
        /// </summary>
        /// <param name="schema"> The ArrayOfGet3ItemsItem to use. </param>
        /// <param name="table"> The ArrayOfGet4ItemsItem to use. </param>
        /// <param name="column"> The ArrayOfGet5ItemsItem to use. </param>
        /// <param name="orderBy"> The ArrayOfGet6ItemsItem to use. </param>
        /// <param name="skiptoken"> An opaque token that identifies a starting point in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseColumnResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlDatabaseColumnResource> GetDatabaseColumns(IEnumerable<string> schema = null, IEnumerable<string> table = null, IEnumerable<string> column = null, IEnumerable<string> orderBy = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            Page<SqlDatabaseColumnResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlDatabaseColumnDatabaseColumnsClientDiagnostics.CreateScope("SqlDatabaseResource.GetDatabaseColumns");
                scope.Start();
                try
                {
                    var response = _sqlDatabaseColumnDatabaseColumnsRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseColumnResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SqlDatabaseColumnResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlDatabaseColumnDatabaseColumnsClientDiagnostics.CreateScope("SqlDatabaseResource.GetDatabaseColumns");
                scope.Start();
                try
                {
                    var response = _sqlDatabaseColumnDatabaseColumnsRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseColumnResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/currentSensitivityLabels
        /// Operation Id: SensitivityLabels_ListCurrentByDatabase
        /// </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="count"> The Boolean to use. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlDatabaseSensitivityLabelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlDatabaseSensitivityLabelResource> GetCurrentSensitivityLabelsAsync(string skipToken = null, bool? count = null, string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SqlDatabaseSensitivityLabelResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlDatabaseSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("SqlDatabaseResource.GetCurrentSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _sqlDatabaseSensitivityLabelSensitivityLabelsRestClient.ListCurrentByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SqlDatabaseSensitivityLabelResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlDatabaseSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("SqlDatabaseResource.GetCurrentSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _sqlDatabaseSensitivityLabelSensitivityLabelsRestClient.ListCurrentByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/currentSensitivityLabels
        /// Operation Id: SensitivityLabels_ListCurrentByDatabase
        /// </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="count"> The Boolean to use. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseSensitivityLabelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlDatabaseSensitivityLabelResource> GetCurrentSensitivityLabels(string skipToken = null, bool? count = null, string filter = null, CancellationToken cancellationToken = default)
        {
            Page<SqlDatabaseSensitivityLabelResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlDatabaseSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("SqlDatabaseResource.GetCurrentSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _sqlDatabaseSensitivityLabelSensitivityLabelsRestClient.ListCurrentByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SqlDatabaseSensitivityLabelResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlDatabaseSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("SqlDatabaseResource.GetCurrentSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _sqlDatabaseSensitivityLabelSensitivityLabelsRestClient.ListCurrentByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/recommendedSensitivityLabels
        /// Operation Id: SensitivityLabels_ListRecommendedByDatabase
        /// </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="includeDisabledRecommendations"> Specifies whether to include disabled recommendations or not. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlDatabaseSensitivityLabelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlDatabaseSensitivityLabelResource> GetRecommendedSensitivityLabelsAsync(string skipToken = null, bool? includeDisabledRecommendations = null, string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SqlDatabaseSensitivityLabelResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlDatabaseSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("SqlDatabaseResource.GetRecommendedSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _sqlDatabaseSensitivityLabelSensitivityLabelsRestClient.ListRecommendedByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SqlDatabaseSensitivityLabelResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlDatabaseSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("SqlDatabaseResource.GetRecommendedSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _sqlDatabaseSensitivityLabelSensitivityLabelsRestClient.ListRecommendedByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/recommendedSensitivityLabels
        /// Operation Id: SensitivityLabels_ListRecommendedByDatabase
        /// </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="includeDisabledRecommendations"> Specifies whether to include disabled recommendations or not. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseSensitivityLabelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlDatabaseSensitivityLabelResource> GetRecommendedSensitivityLabels(string skipToken = null, bool? includeDisabledRecommendations = null, string filter = null, CancellationToken cancellationToken = default)
        {
            Page<SqlDatabaseSensitivityLabelResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlDatabaseSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("SqlDatabaseResource.GetRecommendedSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _sqlDatabaseSensitivityLabelSensitivityLabelsRestClient.ListRecommendedByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SqlDatabaseSensitivityLabelResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlDatabaseSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("SqlDatabaseResource.GetRecommendedSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _sqlDatabaseSensitivityLabelSensitivityLabelsRestClient.ListRecommendedByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
