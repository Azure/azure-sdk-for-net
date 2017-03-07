// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using Protocol.Models;

    /// <summary>
    /// Controls the amount of detail requested from the Azure Batch service when listing or
    /// retrieving resources, using OData query clauses.
    /// </summary>
    /// <remarks>
    /// <para>Azure Batch supports OData queries, which allow the client to gain finer control over query
    /// performance by controlling which resources are returned in List operations (<see cref="FilterClause"/>),
    /// and which properties of each resource are returned in List, Get or Refresh operations
    /// (<see cref="SelectClause"/> and <see cref="ExpandClause"/>).</para>
    /// <para>By default, if you do not pass a <see cref="DetailLevel"/> to a List, Get or Refresh operation,
    /// the Batch client specifies no filter (all records are returned), no select clause (all simple properties are
    /// returned) and no expand clause (associated entities are not returned).  Consequently, by default, associated entity
    /// properties are null, rather than being populated like other properties.  Refer to individual class
    /// documentation to find out which properties are considered associated entities and need to be expanded
    /// to be populated.</para>
    /// <para>Because the OData queries are passed directly to the REST API, clause strings must use the JSON attribute
    /// names from the REST API, which are not always the same as .NET property names.  For example, the
    /// .NET <see cref="CloudPool.VirtualMachineSize">CloudPool.VirtualMachineSize</see> property corresponds to
    /// the vmSize attribute in the REST API; therefore, to filter a pool list operations by VM size, you would
    /// need to write vmSize rather than VirtualMachineSize in your filter string.  Refer to the REST API
    /// documentation to find out the JSON attribute name corresponding to a .NET property.</para>
    /// <para>For additional information about using OData to efficiently query the Azure Batch service, see
    /// <a href="https://azure.microsoft.com/en-us/documentation/articles/batch-efficient-list-queries/">Efficient List Queries</a> on MSDN.</para>
    /// </remarks>
    /// <example>
    /// This sample shows how to specify an ODataDetailLevel that lists only active <see cref="CloudPool">CloudPools</see>,
    /// and retrieves only the <see cref="CloudPool.Id"/>, <see cref="CloudPool.DisplayName"/> and <see cref="CloudPool.Statistics"/>
    /// for each pool (for example, for display in a reporting user interface).
    /// <code>
    /// var detailLevel = new ODATADetailLevel(
    ///     filterClause: "state eq 'active'",
    ///     selectClause: "id,displayName,stats",
    ///     expandClause: "stats"
    /// );
    ///
    /// var pools = batchClient.PoolOperations.ListPools(detailLevel);
    /// </code>
    /// </example>
    public class ODATADetailLevel : DetailLevel
    {
        /// <summary>
        /// Gets or sets the OData filter clause. Used to restrict a list operation to items that match specified criteria.
        /// </summary>
        /// <remarks>
        /// <para>This is an optional OData $filter expression string
        /// <a href="http://docs.oasis-open.org/odata/odata/v4.0/errata02/os/complete/part2-url-conventions/odata-v4.0-errata02-os-part2-url-conventions-complete.html#_Toc406398094">(see the OData specification)</a>.
        /// For example, you can restrict a <see cref="PoolOperations.ListPools(DetailLevel, IEnumerable{BatchClientBehavior})"/> operation to return
        /// only active pools with the expression <c>state eq 'active'</c>.</para>
        /// <para>Filters must be specified using REST API attribute names, not .NET property names.</para>
        /// <para>The default is no filter expression, which means all resources are returned.</para>
        /// </remarks>
        public string FilterClause { get; set; }

        /// <summary>
        /// Gets or sets the OData select clause. Used to retrieve only specific properties instead of all object properties.
        /// </summary>
        /// <remarks>
        /// <para>This is an optional OData $select expression string
        /// <a href="http://docs.oasis-open.org/odata/odata/v4.0/errata02/os/complete/part2-url-conventions/odata-v4.0-errata02-os-part2-url-conventions-complete.html#_Toc406398163">(see the OData specification)</a>.
        /// If you provide a SelectClause, then <b>only</b> the properties listed in that clause are populated; other properties
        /// have their default values (typically null).  For example, if you perform a <see cref="PoolOperations.ListPools(DetailLevel, IEnumerable{BatchClientBehavior})"/>
        /// operation with a SelectClause of <c>id,displayName</c>, then each <see cref="CloudPool"/> will have its
        /// <see cref="CloudPool.Id"/> and <see cref="CloudPool.DisplayName"/> properties
        /// populated, but other properties such as <see cref="CloudPool.State"/> will not be retrieved and therefore
        /// will have their default values (typically null).</para>
        /// <para>If, when an entity was retrieved (via a List, Get or Refresh), you specifed a SelectClause which did not include
        /// the property or properties that uniquely identify the object
        /// (usually the Id property, but for <see cref="Certificate"/> the Thumbprint and ThumbprintAlgorithm properties,
        /// then any methods that access the Batch service to retrieve data or perform operations will fail.
        /// This includes most methods on the object, including <see cref="IRefreshable.Refresh"/> and <see cref="IRefreshable.RefreshAsync"/>.
        /// You can still access properties (though only properties included in the SelectClause will be populated).</para>
        /// <para>Selections must be specified using REST API attribute names, not .NET property names.</para>
        /// <para>The default is no select expression, which means all properties are returned.</para>
        /// </remarks>
        public string SelectClause { get; set; }

        /// <summary>
        /// Gets or sets the OData expand clause. Used to retrieve associated entities of the main entity being retrieved.
        /// </summary>
        /// <remarks>
        /// <para>This is an optional OData $expand expression string
        /// <a href="http://docs.oasis-open.org/odata/odata/v4.0/errata02/os/complete/part2-url-conventions/odata-v4.0-errata02-os-part2-url-conventions-complete.html#_Toc406398162">(see the OData specification)</a>.
        /// Properties containing associated entities will be null unless included in an ExpandClause.
        /// Specifically, if you perform a List, Get or Refresh and do not specify an ExpandClause, then all associated
        /// entity properties will be null.  For example, if you perform a <see cref="PoolOperations.ListPools(DetailLevel, IEnumerable{BatchClientBehavior})"/>
        /// operation without an ExpandClause then the <see cref="CloudPool.Statistics"/> property will be null.  To populate
        /// the Statistics property you must supply an ExpandClause of <c>stats</c>.  Refer to individual class
        /// documentation to find out which properties are considered associated entities.</para>
        /// <para>If you specify both an ExpandClause and a <see cref="SelectClause"/>, then properties listed in the
        /// ExpandClause must be repeated in the SelectClause (because only properties listed in the SelectClause are
        /// included in the service response).  (This requirement does not arise if you do not specify a SelectClause, because that
        /// means 'include all properties in the response.')</para>
        /// <para>Expansions must be specified using REST API attribute names, not .NET property names.</para>
        /// <para>The default is no expand expression, which means no associated objects are returned (and the
        /// corresponding properties are null).</para>
        /// </remarks>
        public string ExpandClause { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ODATADetailLevel"/> class with the specified clauses.
        /// </summary>
        /// <param name="filterClause">The filter clause.</param>
        /// <param name="selectClause">The select clause.</param>
        /// <param name="expandClause">The expand clause.</param>
        public ODATADetailLevel(string filterClause = null, string selectClause = null, string expandClause = null)
        {
            this.FilterClause = filterClause;
            this.SelectClause = selectClause;
            this.ExpandClause = expandClause;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ODATADetailLevel"/> class with empty clauses.
        /// </summary>
        public ODATADetailLevel()
        {
        }
    }

    internal class ODATADetailLevelIntercept : Protocol.RequestInterceptor
    {
        private readonly ODATADetailLevel _details;

        private ODATADetailLevelIntercept()
        {
        }

        public ODATADetailLevelIntercept(ODATADetailLevel odataDetaillevel)
        {
            // remember the values that need to be set
            _details = odataDetaillevel;

            // this is the code that will set the odata predicates
            base.ModificationInterceptHandler = SetODATAPredicates;
        }

        private void SetODATAPredicates(Protocol.IBatchRequest request)
        {
            IODataFilter filterOptions = request.Options as IODataFilter;
            IODataExpand expandOptions = request.Options as IODataExpand;
            IODataSelect selectOptions = request.Options as IODataSelect;

            if (filterOptions != null)
            {
                filterOptions.Filter = this._details.FilterClause;
            }
            else if (!string.IsNullOrEmpty(this._details.FilterClause))
            {
                //Note: We explicitly set this to be "detailLevel" for clarity for the customer even though at this scope there is no detailLevel param
                throw new ArgumentException(string.Format(BatchErrorMessages.TypeDoesNotSupportFilterClause, request.GetType()), "detailLevel");
            }

            if (expandOptions != null)
            {
                expandOptions.Expand = this._details.ExpandClause;
            }
            else if (!string.IsNullOrEmpty(this._details.ExpandClause))
            {
                //Note: We explicitly set this to be "detailLevel" for clarity for the customer even though at this scope there is no detailLevel param
                throw new ArgumentException(string.Format(BatchErrorMessages.TypeDoesNotSupportExpandClause, request.GetType()), "detailLevel");
            }

            if (selectOptions != null)
            {
                selectOptions.Select = this._details.SelectClause;
            }
            else if (!string.IsNullOrEmpty(this._details.SelectClause))
            {
                //Note: We explicitly set this to be "detailLevel" for clarity for the customer even though at this scope there is no detailLevel param
                throw new ArgumentException(string.Format(BatchErrorMessages.TypeDoesNotSupportSelectClause, request.GetType()), "detailLevel");
            }
        }
    }
}
