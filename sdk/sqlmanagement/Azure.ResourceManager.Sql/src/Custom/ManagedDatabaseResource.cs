// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("GetCurrentManagedDatabaseSensitivityLabelsAsync", typeof(string), typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCurrentManagedDatabaseSensitivityLabels", typeof(string), typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetManagedDatabaseColumnsByDatabaseAsync", typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetManagedDatabaseColumnsByDatabase", typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetManagedDatabaseSensitivityLabelsByDatabaseAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetManagedDatabaseSensitivityLabelsByDatabase", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetRecommendedManagedDatabaseSensitivityLabelsAsync", typeof(string), typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetRecommendedManagedDatabaseSensitivityLabels", typeof(string), typeof(bool?), typeof(string), typeof(CancellationToken))]
    public partial class ManagedDatabaseResource
    {
        // NOTE: v1.4.0 GetManagedDatabaseColumnsByDatabase / GetCurrentManagedDatabaseSensitivityLabels /
        // GetManagedDatabaseSensitivityLabelsByDatabase / GetRecommendedManagedDatabaseSensitivityLabels returned
        // Pageable<{Resource}>. Generated now returns Pageable<{Data}>. Same parameter list, different return type -
        // cannot be overloaded. Tracked as design-level breakage; would require [CodeGenSuppress] + regeneration.

        /// <summary> Gets security events of a managed database. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SecurityEvent> GetManagedDatabaseSecurityEventsByDatabase(string filter, int? skip, int? top, string skiptoken, CancellationToken cancellationToken)
            => GetManagedDatabaseSecurityEventsByDatabase(filter, (long?)skip, (long?)top, skiptoken, cancellationToken);

        /// <summary> Gets security events of a managed database. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SecurityEvent> GetManagedDatabaseSecurityEventsByDatabaseAsync(string filter, int? skip, int? top, string skiptoken, CancellationToken cancellationToken)
            => GetManagedDatabaseSecurityEventsByDatabaseAsync(filter, (long?)skip, (long?)top, skiptoken, cancellationToken);

        /// <summary> Gets query statistics for the specified query. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<QueryStatistics> GetQueryStatistics(string queryId, string startTime = null, string endTime = null, QueryTimeGrainType? interval = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("GetQueryStatistics is no longer supported on this resource. Use ManagedInstanceQueryResource.GetQueryStatistics instead.");
        }

        /// <summary> Gets query statistics for the specified query. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<QueryStatistics> GetQueryStatisticsAsync(string queryId, string startTime = null, string endTime = null, QueryTimeGrainType? interval = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("GetQueryStatisticsAsync is no longer supported on this resource. Use ManagedInstanceQueryResource.GetQueryStatisticsAsync instead.");
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/currentSensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ManagedDatabases_ListCurrentByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ManagedDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"></param>
        /// <param name="count"></param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedDatabaseSensitivityLabelResource> GetCurrentManagedDatabaseSensitivityLabelsAsync(string skipToken = default, bool? count = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new ManagedDatabaseSensitivityLabelsGetCurrentManagedDatabaseSensitivityLabelsAsyncCollectionResultOfT(
                _managedDatabaseSensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                skipToken,
                count,
                filter,
                context,
                "ManagedDatabaseResource.GetCurrentManagedDatabaseSensitivityLabels");

            return new AsyncPageableWrapper<SensitivityLabelData, ManagedDatabaseSensitivityLabelResource>(
                source,
                data => new ManagedDatabaseSensitivityLabelResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/currentSensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ManagedDatabases_ListCurrentByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ManagedDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"></param>
        /// <param name="count"></param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedDatabaseSensitivityLabelResource> GetCurrentManagedDatabaseSensitivityLabels(string skipToken = default, bool? count = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new ManagedDatabaseSensitivityLabelsGetCurrentManagedDatabaseSensitivityLabelsCollectionResultOfT(
                _managedDatabaseSensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                skipToken,
                count,
                filter,
                context,
                "ManagedDatabaseResource.GetCurrentManagedDatabaseSensitivityLabels");

            return new PageableWrapper<SensitivityLabelData, ManagedDatabaseSensitivityLabelResource>(
                source,
                data => new ManagedDatabaseSensitivityLabelResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// List managed database columns
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/columns. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ManagedDatabases_ListByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ManagedDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="orderBy"></param>
        /// <param name="skiptoken"> An opaque token that identifies a starting point in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseColumnResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedDatabaseColumnResource> GetManagedDatabaseColumnsByDatabaseAsync(IEnumerable<string> schema = default, IEnumerable<string> table = default, IEnumerable<string> column = default, IEnumerable<string> orderBy = default, string skiptoken = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new ManagedDatabaseColumnsGetManagedDatabaseColumnsByDatabaseAsyncCollectionResultOfT(
                _managedDatabaseColumnsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                schema,
                table,
                column,
                orderBy,
                skiptoken,
                context,
                "ManagedDatabaseResource.GetManagedDatabaseColumnsByDatabase");

            return new AsyncPageableWrapper<DatabaseColumnData, ManagedDatabaseColumnResource>(
                source,
                data => new ManagedDatabaseColumnResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// List managed database columns
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/columns. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ManagedDatabases_ListByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ManagedDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="orderBy"></param>
        /// <param name="skiptoken"> An opaque token that identifies a starting point in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseColumnResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedDatabaseColumnResource> GetManagedDatabaseColumnsByDatabase(IEnumerable<string> schema = default, IEnumerable<string> table = default, IEnumerable<string> column = default, IEnumerable<string> orderBy = default, string skiptoken = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new ManagedDatabaseColumnsGetManagedDatabaseColumnsByDatabaseCollectionResultOfT(
                _managedDatabaseColumnsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                schema,
                table,
                column,
                orderBy,
                skiptoken,
                context,
                "ManagedDatabaseResource.GetManagedDatabaseColumnsByDatabase");

            return new PageableWrapper<DatabaseColumnData, ManagedDatabaseColumnResource>(
                source,
                data => new ManagedDatabaseColumnResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/sensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ManagedDatabases_ManagedDatabaseSensitivityLabelsListByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ManagedDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedDatabaseSensitivityLabelResource> GetManagedDatabaseSensitivityLabelsByDatabaseAsync(string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new ManagedDatabaseSensitivityLabelsGetManagedDatabaseSensitivityLabelsByDatabaseAsyncCollectionResultOfT(
                _managedDatabaseSensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                filter,
                context,
                "ManagedDatabaseResource.GetManagedDatabaseSensitivityLabelsByDatabase");

            return new AsyncPageableWrapper<SensitivityLabelData, ManagedDatabaseSensitivityLabelResource>(
                source,
                data => new ManagedDatabaseSensitivityLabelResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/sensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ManagedDatabases_ManagedDatabaseSensitivityLabelsListByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ManagedDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedDatabaseSensitivityLabelResource> GetManagedDatabaseSensitivityLabelsByDatabase(string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new ManagedDatabaseSensitivityLabelsGetManagedDatabaseSensitivityLabelsByDatabaseCollectionResultOfT(
                _managedDatabaseSensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                filter,
                context,
                "ManagedDatabaseResource.GetManagedDatabaseSensitivityLabelsByDatabase");

            return new PageableWrapper<SensitivityLabelData, ManagedDatabaseSensitivityLabelResource>(
                source,
                data => new ManagedDatabaseSensitivityLabelResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/recommendedSensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ManagedDatabases_ListRecommendedByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ManagedDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"></param>
        /// <param name="includeDisabledRecommendations"> Specifies whether to include disabled recommendations or not. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedDatabaseSensitivityLabelResource> GetRecommendedManagedDatabaseSensitivityLabelsAsync(string skipToken = default, bool? includeDisabledRecommendations = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new ManagedDatabaseSensitivityLabelsGetRecommendedManagedDatabaseSensitivityLabelsAsyncCollectionResultOfT(
                _managedDatabaseSensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                skipToken,
                includeDisabledRecommendations,
                filter,
                context,
                "ManagedDatabaseResource.GetRecommendedManagedDatabaseSensitivityLabels");

            return new AsyncPageableWrapper<SensitivityLabelData, ManagedDatabaseSensitivityLabelResource>(
                source,
                data => new ManagedDatabaseSensitivityLabelResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/recommendedSensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ManagedDatabases_ListRecommendedByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ManagedDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"></param>
        /// <param name="includeDisabledRecommendations"> Specifies whether to include disabled recommendations or not. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedDatabaseSensitivityLabelResource> GetRecommendedManagedDatabaseSensitivityLabels(string skipToken = default, bool? includeDisabledRecommendations = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new ManagedDatabaseSensitivityLabelsGetRecommendedManagedDatabaseSensitivityLabelsCollectionResultOfT(
                _managedDatabaseSensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                skipToken,
                includeDisabledRecommendations,
                filter,
                context,
                "ManagedDatabaseResource.GetRecommendedManagedDatabaseSensitivityLabels");

            return new PageableWrapper<SensitivityLabelData, ManagedDatabaseSensitivityLabelResource>(
                source,
                data => new ManagedDatabaseSensitivityLabelResource(Client, data));
        }

        /// <summary> Gets a single managed database query. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ManagedInstanceQuery> GetManagedDatabaseQuery(string queryId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Use GetManagedInstanceQueries() instead to obtain a collection of ManagedInstanceQueryResource.");
        }

        /// <summary> Gets a single managed database query. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Response<ManagedInstanceQuery>> GetManagedDatabaseQueryAsync(string queryId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported. Use GetManagedInstanceQueriesAsync() instead.");
        }
    }
}
