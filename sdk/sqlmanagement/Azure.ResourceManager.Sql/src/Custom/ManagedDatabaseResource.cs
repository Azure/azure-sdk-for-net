// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
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
