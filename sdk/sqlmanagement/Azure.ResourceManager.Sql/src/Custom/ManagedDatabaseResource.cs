// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A Class representing a ManagedDatabase along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ManagedDatabaseResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetManagedDatabaseResource method.
    /// Otherwise you can get one from its parent resource <see cref="ManagedInstanceResource" /> using the GetManagedDatabase method.
    /// </summary>
    public partial class ManagedDatabaseResource : ArmResource
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
        public virtual AsyncPageable<ManagedDatabaseColumnResource> GetManagedDatabaseColumnsByDatabaseAsync(IEnumerable<string> schema = null, IEnumerable<string> table = null, IEnumerable<string> column = null, IEnumerable<string> orderBy = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedDatabaseColumnResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseColumnClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseColumnsByDatabase");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseColumnRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _managedDatabaseColumnClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseColumnsByDatabase");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseColumnRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Pageable<ManagedDatabaseColumnResource> GetManagedDatabaseColumnsByDatabase(IEnumerable<string> schema = null, IEnumerable<string> table = null, IEnumerable<string> column = null, IEnumerable<string> orderBy = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedDatabaseColumnResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseColumnClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseColumnsByDatabase");
                scope.Start();
                try
                {
                    var response = _managedDatabaseColumnRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken);
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
                using var scope = _managedDatabaseColumnClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseColumnsByDatabase");
                scope.Start();
                try
                {
                    var response = _managedDatabaseColumnRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schema, table, column, orderBy, skiptoken, cancellationToken: cancellationToken);
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
        /// Get query execution statistics by query id.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/queries/{queryId}/statistics
        /// Operation Id: ManagedDatabaseQueries_ListByQuery
        /// </summary>
        /// <param name="queryId"> The String to use. </param>
        /// <param name="startTime"> Start time for observed period. </param>
        /// <param name="endTime"> End time for observed period. </param>
        /// <param name="interval"> The time step to be used to summarize the metric values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="queryId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queryId"/> is null. </exception>
        /// <returns> An async collection of <see cref="QueryStatistics" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<QueryStatistics> GetQueryStatisticsAsync(string queryId, string startTime = null, string endTime = null, QueryTimeGrainType? interval = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(queryId, nameof(queryId));

            async Task<Page<QueryStatistics>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseQueriesClientDiagnostics.CreateScope("ManagedDatabaseResource.GetQueryStatistics");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseQueriesRestClient.ListByQueryAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, queryId, startTime, endTime, interval, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<QueryStatistics>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedDatabaseQueriesClientDiagnostics.CreateScope("ManagedDatabaseResource.GetQueryStatistics");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseQueriesRestClient.ListByQueryNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, queryId, startTime, endTime, interval, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        /// Get query execution statistics by query id.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/queries/{queryId}/statistics
        /// Operation Id: ManagedDatabaseQueries_ListByQuery
        /// </summary>
        /// <param name="queryId"> The String to use. </param>
        /// <param name="startTime"> Start time for observed period. </param>
        /// <param name="endTime"> End time for observed period. </param>
        /// <param name="interval"> The time step to be used to summarize the metric values. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="queryId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queryId"/> is null. </exception>
        /// <returns> A collection of <see cref="QueryStatistics" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<QueryStatistics> GetQueryStatistics(string queryId, string startTime = null, string endTime = null, QueryTimeGrainType? interval = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(queryId, nameof(queryId));

            Page<QueryStatistics> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseQueriesClientDiagnostics.CreateScope("ManagedDatabaseResource.GetQueryStatistics");
                scope.Start();
                try
                {
                    var response = _managedDatabaseQueriesRestClient.ListByQuery(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, queryId, startTime, endTime, interval, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<QueryStatistics> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedDatabaseQueriesClientDiagnostics.CreateScope("ManagedDatabaseResource.GetQueryStatistics");
                scope.Start();
                try
                {
                    var response = _managedDatabaseQueriesRestClient.ListByQueryNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, queryId, startTime, endTime, interval, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of security events.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/securityEvents
        /// Operation Id: ManagedDatabaseSecurityEvents_ListByDatabase
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="skip"> The number of elements in the collection to skip. </param>
        /// <param name="top"> The number of elements to return from the collection. </param>
        /// <param name="skiptoken"> An opaque token that identifies a starting point in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityEvent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityEvent> GetManagedDatabaseSecurityEventsByDatabaseAsync(string filter = null, int? skip = null, int? top = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SecurityEvent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseSecurityEventsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseSecurityEventsByDatabase");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseSecurityEventsRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, skip, top, skiptoken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SecurityEvent>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedDatabaseSecurityEventsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseSecurityEventsByDatabase");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseSecurityEventsRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, skip, top, skiptoken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of security events.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/securityEvents
        /// Operation Id: ManagedDatabaseSecurityEvents_ListByDatabase
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="skip"> The number of elements in the collection to skip. </param>
        /// <param name="top"> The number of elements to return from the collection. </param>
        /// <param name="skiptoken"> An opaque token that identifies a starting point in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityEvent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityEvent> GetManagedDatabaseSecurityEventsByDatabase(string filter = null, int? skip = null, int? top = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            Page<SecurityEvent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseSecurityEventsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseSecurityEventsByDatabase");
                scope.Start();
                try
                {
                    var response = _managedDatabaseSecurityEventsRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, skip, top, skiptoken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SecurityEvent> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedDatabaseSecurityEventsClientDiagnostics.CreateScope("ManagedDatabaseResource.GetManagedDatabaseSecurityEventsByDatabase");
                scope.Start();
                try
                {
                    var response = _managedDatabaseSecurityEventsRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, skip, top, skiptoken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        public virtual AsyncPageable<ManagedDatabaseSensitivityLabelResource> GetCurrentManagedDatabaseSensitivityLabelsAsync(string skipToken = null, bool? count = null, string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedDatabaseSensitivityLabelResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelClientDiagnostics.CreateScope("ManagedDatabaseResource.GetCurrentManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseSensitivityLabelRestClient.ListCurrentAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _managedDatabaseSensitivityLabelClientDiagnostics.CreateScope("ManagedDatabaseResource.GetCurrentManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseSensitivityLabelRestClient.ListCurrentNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Pageable<ManagedDatabaseSensitivityLabelResource> GetCurrentManagedDatabaseSensitivityLabels(string skipToken = null, bool? count = null, string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedDatabaseSensitivityLabelResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelClientDiagnostics.CreateScope("ManagedDatabaseResource.GetCurrentManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _managedDatabaseSensitivityLabelRestClient.ListCurrent(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken);
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
                using var scope = _managedDatabaseSensitivityLabelClientDiagnostics.CreateScope("ManagedDatabaseResource.GetCurrentManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _managedDatabaseSensitivityLabelRestClient.ListCurrentNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, count, filter, cancellationToken: cancellationToken);
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
        public virtual AsyncPageable<ManagedDatabaseSensitivityLabelResource> GetRecommendedManagedDatabaseSensitivityLabelsAsync(string skipToken = null, bool? includeDisabledRecommendations = null, string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedDatabaseSensitivityLabelResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelClientDiagnostics.CreateScope("ManagedDatabaseResource.GetRecommendedManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseSensitivityLabelRestClient.ListRecommendedAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _managedDatabaseSensitivityLabelClientDiagnostics.CreateScope("ManagedDatabaseResource.GetRecommendedManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = await _managedDatabaseSensitivityLabelRestClient.ListRecommendedNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Pageable<ManagedDatabaseSensitivityLabelResource> GetRecommendedManagedDatabaseSensitivityLabels(string skipToken = null, bool? includeDisabledRecommendations = null, string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedDatabaseSensitivityLabelResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedDatabaseSensitivityLabelClientDiagnostics.CreateScope("ManagedDatabaseResource.GetRecommendedManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _managedDatabaseSensitivityLabelRestClient.ListRecommended(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken);
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
                using var scope = _managedDatabaseSensitivityLabelClientDiagnostics.CreateScope("ManagedDatabaseResource.GetRecommendedManagedDatabaseSensitivityLabels");
                scope.Start();
                try
                {
                    var response = _managedDatabaseSensitivityLabelRestClient.ListRecommendedNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, includeDisabledRecommendations, filter, cancellationToken: cancellationToken);
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
