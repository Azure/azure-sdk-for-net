// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedDatabaseResource
    {
        /// <summary>
        /// List managed database columns
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/columns
        /// Operation Id: ManagedDatabaseColumns_ListByDatabase
        /// </summary>
        /// <param name="schema"> The ArrayOfGet3ItemsItem to use. </param>
        /// <param name="table"> The ArrayOfGet4ItemsItem to use. </param>
        /// <param name="column"> The ArrayOfGet5ItemsItem to use. </param>
        /// <param name="orderBy"> The ArrayOfGet6ItemsItem to use. </param>
        /// <param name="skiptoken"> An opaque token that identifies a starting point in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedDatabaseColumnResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ManagedDatabaseColumnResource> GetManagedDatabaseColumnsByDatabaseAsync(IEnumerable<string> schema = null, IEnumerable<string> table = null, IEnumerable<string> column = null, IEnumerable<string> orderBy = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedDatabaseColumnResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseColumnsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseColumnsByDatabase");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseColumnsRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseColumnResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedDatabaseColumnResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedDatabaseColumnsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseColumnsByDatabase");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseColumnsRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseColumnResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List managed database columns
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/columns
        /// Operation Id: ManagedDatabaseColumns_ListByDatabase
        /// </summary>
        /// <param name="schema"> The ArrayOfGet3ItemsItem to use. </param>
        /// <param name="table"> The ArrayOfGet4ItemsItem to use. </param>
        /// <param name="column"> The ArrayOfGet5ItemsItem to use. </param>
        /// <param name="orderBy"> The ArrayOfGet6ItemsItem to use. </param>
        /// <param name="skiptoken"> An opaque token that identifies a starting point in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseColumnResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ManagedDatabaseColumnResource> GetManagedDatabaseColumnsByDatabase(IEnumerable<string> schema = null, IEnumerable<string> table = null, IEnumerable<string> column = null, IEnumerable<string> orderBy = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedDatabaseColumnResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseColumnsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseColumnsByDatabase");
                scope.Start();
                try
                {
                    var response = _managedDatabaseColumnsRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseColumnResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedDatabaseColumnResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedDatabaseColumnsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseColumnsByDatabase");
                scope.Start();
                try
                {
                    var response = _managedDatabaseColumnsRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseColumnResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/currentSensitivityLabels
        /// Operation Id: ManagedDatabaseSensitivityLabels_ListCurrent
        /// </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="count"> The Boolean to use. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedDatabaseSensitivityLabelResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ManagedDatabaseSensitivityLabelResource> GetCurrentManagedDatabaseSensitivityLabelsAsync(string skipToken = null, bool? count = null, string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedDatabaseSensitivityLabelResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetCurrentManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseSensitivityLabelsRestClient.ListCurrentAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedDatabaseSensitivityLabelResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetCurrentManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseSensitivityLabelsRestClient.ListCurrentNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/currentSensitivityLabels
        /// Operation Id: ManagedDatabaseSensitivityLabels_ListCurrent
        /// </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="count"> The Boolean to use. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseSensitivityLabelResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ManagedDatabaseSensitivityLabelResource> GetCurrentManagedDatabaseSensitivityLabels(string skipToken = null, bool? count = null, string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedDatabaseSensitivityLabelResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetCurrentManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _managedDatabaseSensitivityLabelsRestClient.ListCurrent(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedDatabaseSensitivityLabelResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetCurrentManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _managedDatabaseSensitivityLabelsRestClient.ListCurrentNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/recommendedSensitivityLabels
        /// Operation Id: ManagedDatabaseSensitivityLabels_ListRecommended
        /// </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="includeDisabledRecommendations"> Specifies whether to include disabled recommendations or not. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedDatabaseSensitivityLabelResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ManagedDatabaseSensitivityLabelResource> GetRecommendedManagedDatabaseSensitivityLabelsAsync(string skipToken = null, bool? includeDisabledRecommendations = null, string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedDatabaseSensitivityLabelResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetRecommendedManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseSensitivityLabelsRestClient.ListRecommendedAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedDatabaseSensitivityLabelResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetRecommendedManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseSensitivityLabelsRestClient.ListRecommendedNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/recommendedSensitivityLabels
        /// Operation Id: ManagedDatabaseSensitivityLabels_ListRecommended
        /// </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="includeDisabledRecommendations"> Specifies whether to include disabled recommendations or not. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseSensitivityLabelResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ManagedDatabaseSensitivityLabelResource> GetRecommendedManagedDatabaseSensitivityLabels(string skipToken = null, bool? includeDisabledRecommendations = null, string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedDatabaseSensitivityLabelResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetRecommendedManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _managedDatabaseSensitivityLabelsRestClient.ListRecommended(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedDatabaseSensitivityLabelResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetRecommendedManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _managedDatabaseSensitivityLabelsRestClient.ListRecommendedNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedDatabaseSensitivityLabelResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
