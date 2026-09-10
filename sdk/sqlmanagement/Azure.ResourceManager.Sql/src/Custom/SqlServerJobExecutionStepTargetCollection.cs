// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobExecutionStepTargetCollection
    {
        /// <summary> Backward-compatible overload accepting an options bag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlServerJobExecutionStepTargetResource> GetAllAsync(SqlServerJobExecutionStepTargetCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new SqlServerJobExecutionStepTargetCollectionGetAllOptions();
            long? skip = options.Skip;
            long? top = options.Top;
            return GetAllAsync(options.CreateTimeMin, options.CreateTimeMax, options.EndTimeMin, options.EndTimeMax, options.IsActive, skip, top, cancellationToken);
        }

        /// <summary> Backward-compatible overload accepting an options bag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlServerJobExecutionStepTargetResource> GetAll(SqlServerJobExecutionStepTargetCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new SqlServerJobExecutionStepTargetCollectionGetAllOptions();
            long? skip = options.Skip;
            long? top = options.Top;
            return GetAll(options.CreateTimeMin, options.CreateTimeMax, options.EndTimeMin, options.EndTimeMax, options.IsActive, skip, top, cancellationToken);
        }

        /// <summary> Backward-compatible overload retained from v1.4.0 (skip/top were int?). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlServerJobExecutionStepTargetResource> GetAllAsync(DateTimeOffset? createTimeMin, DateTimeOffset? createTimeMax, DateTimeOffset? endTimeMin, DateTimeOffset? endTimeMax, bool? isActive, int? skip, int? top, CancellationToken cancellationToken)
        {
            long? skipLong = skip;
            long? topLong = top;
            return GetAllAsync(createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skipLong, topLong, cancellationToken);
        }

        /// <summary> Backward-compatible overload retained from v1.4.0 (skip/top were int?). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlServerJobExecutionStepTargetResource> GetAll(DateTimeOffset? createTimeMin, DateTimeOffset? createTimeMax, DateTimeOffset? endTimeMin, DateTimeOffset? endTimeMax, bool? isActive, int? skip, int? top, CancellationToken cancellationToken)
        {
            long? skipLong = skip;
            long? topLong = top;
            return GetAll(createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skipLong, topLong, cancellationToken);
        }
    }
}
