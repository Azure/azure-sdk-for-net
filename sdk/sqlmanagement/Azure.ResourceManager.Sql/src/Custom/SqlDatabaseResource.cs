// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;

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
            var input = new SqlDatabaseResourceGetDatabaseColumnsOptions
            {
                Skiptoken = skiptoken
            };
            foreach (var item in schema)
            {
                input.Schema.Add(item);
            }
            foreach (var item in table)
            {
                input.Table.Add(item);
            }
            foreach (var item in column)
            {
                input.Column.Add(item);
            }
            foreach (var item in orderBy)
            {
                input.OrderBy.Add(item);
            }
            return GetDatabaseColumnsAsync(input, cancellationToken);
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
            var input = new SqlDatabaseResourceGetDatabaseColumnsOptions
            {
                Skiptoken = skiptoken
            };
            foreach (var item in schema)
            {
                input.Schema.Add(item);
            }
            foreach (var item in table)
            {
                input.Table.Add(item);
            }
            foreach (var item in column)
            {
                input.Column.Add(item);
            }
            foreach (var item in orderBy)
            {
                input.OrderBy.Add(item);
            }
            return GetDatabaseColumns(input, cancellationToken);
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
        public virtual AsyncPageable<SqlDatabaseSensitivityLabelResource> GetCurrentSensitivityLabelsAsync(string skipToken = null, bool? count = null, string filter = null, CancellationToken cancellationToken = default) =>
            GetCurrentSensitivityLabelsAsync(new SqlDatabaseResourceGetCurrentSensitivityLabelsOptions
            {
                SkipToken = skipToken,
                Count = count,
                Filter = filter
            }, cancellationToken);

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
        public virtual Pageable<SqlDatabaseSensitivityLabelResource> GetCurrentSensitivityLabels(string skipToken = null, bool? count = null, string filter = null, CancellationToken cancellationToken = default) =>
            GetCurrentSensitivityLabels(new SqlDatabaseResourceGetCurrentSensitivityLabelsOptions
            {
                SkipToken = skipToken,
                Count = count,
                Filter = filter
            }, cancellationToken);

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
        public virtual AsyncPageable<SqlDatabaseSensitivityLabelResource> GetRecommendedSensitivityLabelsAsync(string skipToken = null, bool? includeDisabledRecommendations = null, string filter = null, CancellationToken cancellationToken = default) =>
            GetRecommendedSensitivityLabelsAsync(new SqlDatabaseResourceGetRecommendedSensitivityLabelsOptions
            {
                SkipToken = skipToken,
                IncludeDisabledRecommendations = includeDisabledRecommendations,
                Filter = filter
            }, cancellationToken);

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
        public virtual Pageable<SqlDatabaseSensitivityLabelResource> GetRecommendedSensitivityLabels(string skipToken = null, bool? includeDisabledRecommendations = null, string filter = null, CancellationToken cancellationToken = default) =>
            GetRecommendedSensitivityLabels(new SqlDatabaseResourceGetRecommendedSensitivityLabelsOptions
            {
                SkipToken = skipToken,
                IncludeDisabledRecommendations = includeDisabledRecommendations,
                Filter = filter
            }, cancellationToken);
    }
}
