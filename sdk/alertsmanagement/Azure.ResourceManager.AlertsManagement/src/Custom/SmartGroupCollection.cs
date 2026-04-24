// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AlertsManagement.Models;

namespace Azure.ResourceManager.AlertsManagement
{
    /// <summary> Backward compatibility stub. The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release. </summary>
    [Obsolete("The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SmartGroupCollection : ArmCollection, IEnumerable<SmartGroupResource>, IAsyncEnumerable<SmartGroupResource>
    {
        /// <summary> Initializes a new instance for mocking. </summary>
        protected SmartGroupCollection() { }

        /// <summary> Checks if exists. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<bool> Exists(Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Checks if exists async. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<bool>> ExistsAsync(Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a resource. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<SmartGroupResource> Get(Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets a resource async. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<SmartGroupResource>> GetAsync(Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets all with options. </summary>
        /// <param name="options"> The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Pageable<SmartGroupResource> GetAll(SmartGroupCollectionGetAllOptions options, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets all with parameters. </summary>
        /// <param name="targetResource"> Target resource. </param>
        /// <param name="targetResourceGroup"> Target resource group. </param>
        /// <param name="targetResourceType"> Target resource type. </param>
        /// <param name="monitorService"> Monitor service. </param>
        /// <param name="monitorCondition"> Monitor condition. </param>
        /// <param name="severity"> Severity. </param>
        /// <param name="smartGroupState"> Smart group state. </param>
        /// <param name="timeRange"> Time range. </param>
        /// <param name="pageCount"> Page count. </param>
        /// <param name="sortBy"> Sort by. </param>
        /// <param name="sortOrder"> Sort order. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Pageable<SmartGroupResource> GetAll(string targetResource = null, string targetResourceGroup = null, string targetResourceType = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? smartGroupState = null, TimeRangeFilter? timeRange = null, long? pageCount = null, SmartGroupsSortByField? sortBy = null, AlertsManagementQuerySortOrder? sortOrder = null, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets all with options async. </summary>
        /// <param name="options"> The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual AsyncPageable<SmartGroupResource> GetAllAsync(SmartGroupCollectionGetAllOptions options, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets all with parameters async. </summary>
        /// <param name="targetResource"> Target resource. </param>
        /// <param name="targetResourceGroup"> Target resource group. </param>
        /// <param name="targetResourceType"> Target resource type. </param>
        /// <param name="monitorService"> Monitor service. </param>
        /// <param name="monitorCondition"> Monitor condition. </param>
        /// <param name="severity"> Severity. </param>
        /// <param name="smartGroupState"> Smart group state. </param>
        /// <param name="timeRange"> Time range. </param>
        /// <param name="pageCount"> Page count. </param>
        /// <param name="sortBy"> Sort by. </param>
        /// <param name="sortOrder"> Sort order. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual AsyncPageable<SmartGroupResource> GetAllAsync(string targetResource = null, string targetResourceGroup = null, string targetResourceType = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? smartGroupState = null, TimeRangeFilter? timeRange = null, long? pageCount = null, SmartGroupsSortByField? sortBy = null, AlertsManagementQuerySortOrder? sortOrder = null, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets if exists. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual NullableResponse<SmartGroupResource> GetIfExists(Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets if exists async. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<NullableResponse<SmartGroupResource>> GetIfExistsAsync(Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the async enumerator. </summary>
        IAsyncEnumerator<SmartGroupResource> IAsyncEnumerable<SmartGroupResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { throw new NotSupportedException(); }
        /// <summary> Gets the enumerator. </summary>
        IEnumerator<SmartGroupResource> IEnumerable<SmartGroupResource>.GetEnumerator() { throw new NotSupportedException(); }
        /// <summary> Gets the enumerator. </summary>
        IEnumerator IEnumerable.GetEnumerator() { throw new NotSupportedException(); }
    }
}
