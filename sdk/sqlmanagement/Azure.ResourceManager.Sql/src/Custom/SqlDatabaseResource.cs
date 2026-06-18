// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sql
{
    [CodeGenSuppress("GetDatabaseColumnsAsync", typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetDatabaseColumns", typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCurrentSensitivityLabelsAsync", typeof(string), typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCurrentSensitivityLabels", typeof(string), typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetRecommendedSensitivityLabelsAsync", typeof(string), typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetRecommendedSensitivityLabels", typeof(string), typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSensitivityLabelsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSensitivityLabels", typeof(string), typeof(CancellationToken))]
    public partial class SqlDatabaseResource
    {
        /// <summary>
        /// Gets a database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SqlDatabaseResource>> GetAsync(CancellationToken cancellationToken)
        {
            return await GetAsync(null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SqlDatabaseResource> Get(CancellationToken cancellationToken)
        {
            return Get(null, null, cancellationToken);
        }

        /// <summary> Gets an object representing a DataMaskingPolicyResource along with the instance operations that can be performed on it in the SqlDatabase. </summary>
        /// <returns> Returns a <see cref="DataMaskingPolicyResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DataMaskingPolicyResource GetDataMaskingPolicy()
        {
            return new DataMaskingPolicyResource(Client, Id.AppendChildResource("dataMaskingPolicies", "Default"));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// List database columns
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/columns. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Databases_ListByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SqlDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="orderBy"></param>
        /// <param name="skiptoken"> An opaque token that identifies a starting point in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseColumnResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlDatabaseColumnResource> GetDatabaseColumnsAsync(IEnumerable<string> schema = default, IEnumerable<string> table = default, IEnumerable<string> column = default, IEnumerable<string> orderBy = default, string skiptoken = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new DatabaseColumnsGetDatabaseColumnsAsyncCollectionResultOfT(
                _databaseColumnsRestClient,
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
                "SqlDatabaseResource.GetDatabaseColumns");

            return new AsyncPageableWrapper<DatabaseColumnData, SqlDatabaseColumnResource>(
                source,
                data => new SqlDatabaseColumnResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// List database columns
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/columns. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Databases_ListByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SqlDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="orderBy"></param>
        /// <param name="skiptoken"> An opaque token that identifies a starting point in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseColumnResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlDatabaseColumnResource> GetDatabaseColumns(IEnumerable<string> schema = default, IEnumerable<string> table = default, IEnumerable<string> column = default, IEnumerable<string> orderBy = default, string skiptoken = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new DatabaseColumnsGetDatabaseColumnsCollectionResultOfT(
                _databaseColumnsRestClient,
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
                "SqlDatabaseResource.GetDatabaseColumns");

            return new PageableWrapper<DatabaseColumnData, SqlDatabaseColumnResource>(
                source,
                data => new SqlDatabaseColumnResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/currentSensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Databases_ListCurrentByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SqlDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"></param>
        /// <param name="count"></param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlDatabaseSensitivityLabelResource> GetCurrentSensitivityLabelsAsync(string skipToken = default, bool? count = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new SensitivityLabelsGetCurrentSensitivityLabelsAsyncCollectionResultOfT(
                _sensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                skipToken,
                count,
                filter,
                context,
                "SqlDatabaseResource.GetCurrentSensitivityLabels");

            return new AsyncPageableWrapper<SensitivityLabelData, SqlDatabaseSensitivityLabelResource>(
                source,
                data => new SqlDatabaseSensitivityLabelResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/currentSensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Databases_ListCurrentByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SqlDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"></param>
        /// <param name="count"></param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlDatabaseSensitivityLabelResource> GetCurrentSensitivityLabels(string skipToken = default, bool? count = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new SensitivityLabelsGetCurrentSensitivityLabelsCollectionResultOfT(
                _sensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                skipToken,
                count,
                filter,
                context,
                "SqlDatabaseResource.GetCurrentSensitivityLabels");

            return new PageableWrapper<SensitivityLabelData, SqlDatabaseSensitivityLabelResource>(
                source,
                data => new SqlDatabaseSensitivityLabelResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/recommendedSensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Databases_ListRecommendedByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SqlDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"></param>
        /// <param name="includeDisabledRecommendations"> Specifies whether to include disabled recommendations or not. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlDatabaseSensitivityLabelResource> GetRecommendedSensitivityLabelsAsync(string skipToken = default, bool? includeDisabledRecommendations = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new SensitivityLabelsGetRecommendedSensitivityLabelsAsyncCollectionResultOfT(
                _sensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                skipToken,
                includeDisabledRecommendations,
                filter,
                context,
                "SqlDatabaseResource.GetRecommendedSensitivityLabels");

            return new AsyncPageableWrapper<SensitivityLabelData, SqlDatabaseSensitivityLabelResource>(
                source,
                data => new SqlDatabaseSensitivityLabelResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/recommendedSensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Databases_ListRecommendedByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SqlDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"></param>
        /// <param name="includeDisabledRecommendations"> Specifies whether to include disabled recommendations or not. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlDatabaseSensitivityLabelResource> GetRecommendedSensitivityLabels(string skipToken = default, bool? includeDisabledRecommendations = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new SensitivityLabelsGetRecommendedSensitivityLabelsCollectionResultOfT(
                _sensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                skipToken,
                includeDisabledRecommendations,
                filter,
                context,
                "SqlDatabaseResource.GetRecommendedSensitivityLabels");

            return new PageableWrapper<SensitivityLabelData, SqlDatabaseSensitivityLabelResource>(
                source,
                data => new SqlDatabaseSensitivityLabelResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Databases_SensitivityLabelsListByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SqlDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlDatabaseSensitivityLabelResource> GetSensitivityLabelsAsync(string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new SensitivityLabelsGetSensitivityLabelsAsyncCollectionResultOfT(
                _sensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                filter,
                context,
                "SqlDatabaseResource.GetSensitivityLabels");

            return new AsyncPageableWrapper<SensitivityLabelData, SqlDatabaseSensitivityLabelResource>(
                source,
                data => new SqlDatabaseSensitivityLabelResource(Client, data));
        }

        // This customization is to avoid this issue https://github.com/Azure/azure-sdk-for-net/issues/59990, the code will be removed once the issue is fixed.
        /// <summary>
        /// Gets the sensitivity labels of a given database
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sensitivityLabels. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Databases_SensitivityLabelsListByDatabase. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="SqlDatabaseResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseSensitivityLabelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlDatabaseSensitivityLabelResource> GetSensitivityLabels(string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            var source = new SensitivityLabelsGetSensitivityLabelsCollectionResultOfT(
                _sensitivityLabelsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                filter,
                context,
                "SqlDatabaseResource.GetSensitivityLabels");

            return new PageableWrapper<SensitivityLabelData, SqlDatabaseSensitivityLabelResource>(
                source,
                data => new SqlDatabaseSensitivityLabelResource(Client, data));
        }
    }
}
