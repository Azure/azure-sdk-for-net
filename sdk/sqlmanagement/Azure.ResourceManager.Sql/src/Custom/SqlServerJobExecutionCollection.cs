// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobExecutionCollection
    {
        /// <summary> Backward-compatible overload accepting an options bag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlServerJobExecutionResource> GetAllAsync(SqlServerJobExecutionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new SqlServerJobExecutionCollectionGetAllOptions();
            long? skip = options.Skip;
            long? top = options.Top;
            return GetAllAsync(options.CreateTimeMin, options.CreateTimeMax, options.EndTimeMin, options.EndTimeMax, options.IsActive, skip, top, cancellationToken);
        }

        /// <summary> Backward-compatible overload accepting an options bag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlServerJobExecutionResource> GetAll(SqlServerJobExecutionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new SqlServerJobExecutionCollectionGetAllOptions();
            long? skip = options.Skip;
            long? top = options.Top;
            return GetAll(options.CreateTimeMin, options.CreateTimeMax, options.EndTimeMin, options.EndTimeMax, options.IsActive, skip, top, cancellationToken);
        }

        /// <summary> Backward-compatible overload retained from v1.4.0 (skip/top were int?). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlServerJobExecutionResource> GetAllAsync(DateTimeOffset? createTimeMin, DateTimeOffset? createTimeMax, DateTimeOffset? endTimeMin, DateTimeOffset? endTimeMax, bool? isActive, int? skip, int? top, CancellationToken cancellationToken)
        {
            var opts = new SqlServerJobExecutionCollectionGetAllOptions
            {
                CreateTimeMin = createTimeMin,
                CreateTimeMax = createTimeMax,
                EndTimeMin = endTimeMin,
                EndTimeMax = endTimeMax,
                IsActive = isActive,
                Skip = skip,
                Top = top,
            };
            return GetAllAsync(opts, cancellationToken);
        }

        /// <summary> Backward-compatible overload retained from v1.4.0 (skip/top were int?). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlServerJobExecutionResource> GetAll(DateTimeOffset? createTimeMin, DateTimeOffset? createTimeMax, DateTimeOffset? endTimeMin, DateTimeOffset? endTimeMax, bool? isActive, int? skip, int? top, CancellationToken cancellationToken)
        {
            var opts = new SqlServerJobExecutionCollectionGetAllOptions
            {
                CreateTimeMin = createTimeMin,
                CreateTimeMax = createTimeMax,
                EndTimeMin = endTimeMin,
                EndTimeMax = endTimeMax,
                IsActive = isActive,
                Skip = skip,
                Top = top,
            };
            return GetAll(opts, cancellationToken);
        }

        /// <summary> Not supported in v2.0.0. </summary>
        [Obsolete("This API has been retired in version 2.0.0. Use SqlServerJobExecutionResource.GetJobTargetExecutionsAsync instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlServerJobExecutionStepTargetResource> GetJobTargetExecutionsAsync(SqlServerJobExecutionCollectionGetJobTargetExecutionsOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This API has been retired. Use SqlServerJobExecutionResource.GetJobTargetExecutionsAsync instead.");
        }

        /// <summary> Not supported in v2.0.0. </summary>
        [Obsolete("This API has been retired in version 2.0.0. Use SqlServerJobExecutionResource.GetJobTargetExecutions instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlServerJobExecutionStepTargetResource> GetJobTargetExecutions(SqlServerJobExecutionCollectionGetJobTargetExecutionsOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This API has been retired. Use SqlServerJobExecutionResource.GetJobTargetExecutions instead.");
        }

        /// <summary> Not supported in v2.0.0. </summary>
        [Obsolete("This API has been retired in version 2.0.0. Use SqlServerJobExecutionResource.GetJobTargetExecutionsAsync instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlServerJobExecutionStepTargetResource> GetJobTargetExecutionsAsync(Guid jobExecutionId, DateTimeOffset? createTimeMin, DateTimeOffset? createTimeMax, DateTimeOffset? endTimeMin, DateTimeOffset? endTimeMax, bool? isActive, int? skip, int? top, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This API has been retired. Use SqlServerJobExecutionResource.GetJobTargetExecutionsAsync instead.");
        }

        /// <summary> Not supported in v2.0.0. </summary>
        [Obsolete("This API has been retired in version 2.0.0. Use SqlServerJobExecutionResource.GetJobTargetExecutions instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlServerJobExecutionStepTargetResource> GetJobTargetExecutions(Guid jobExecutionId, DateTimeOffset? createTimeMin, DateTimeOffset? createTimeMax, DateTimeOffset? endTimeMin, DateTimeOffset? endTimeMax, bool? isActive, int? skip, int? top, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This API has been retired. Use SqlServerJobExecutionResource.GetJobTargetExecutions instead.");
        }
    }
}
