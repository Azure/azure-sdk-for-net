// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobAgentResource
    {
        /// <summary> Backward-compatible overload accepting an options bag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlServerJobExecutionResource> GetJobExecutionsByAgentAsync(SqlServerJobAgentResourceGetJobExecutionsByAgentOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new SqlServerJobAgentResourceGetJobExecutionsByAgentOptions();
            long? skip = options.Skip;
            long? top = options.Top;
            AsyncPageable<SqlServerJobExecutionData> source = GetByAgentAsync(options.CreateTimeMin, options.CreateTimeMax, options.EndTimeMin, options.EndTimeMax, options.IsActive, skip, top, cancellationToken);
            return PageableHelpers.WrapAsync(source, data => new SqlServerJobExecutionResource(Client, data));
        }

        /// <summary> Backward-compatible overload accepting an options bag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlServerJobExecutionResource> GetJobExecutionsByAgent(SqlServerJobAgentResourceGetJobExecutionsByAgentOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new SqlServerJobAgentResourceGetJobExecutionsByAgentOptions();
            long? skip = options.Skip;
            long? top = options.Top;
            Pageable<SqlServerJobExecutionData> source = GetByAgent(options.CreateTimeMin, options.CreateTimeMax, options.EndTimeMin, options.EndTimeMax, options.IsActive, skip, top, cancellationToken);
            return PageableHelpers.Wrap(source, data => new SqlServerJobExecutionResource(Client, data));
        }

        /// <summary> Backward-compatible overload retained from v1.4.0; wraps the generated <see cref="GetByAgentAsync"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlServerJobExecutionResource> GetJobExecutionsByAgentAsync(DateTimeOffset? createTimeMin = default, DateTimeOffset? createTimeMax = default, DateTimeOffset? endTimeMin = default, DateTimeOffset? endTimeMax = default, bool? isActive = default, int? skip = default, int? top = default, CancellationToken cancellationToken = default)
        {
            long? skipLong = skip;
            long? topLong = top;
            AsyncPageable<SqlServerJobExecutionData> source = GetByAgentAsync(createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skipLong, topLong, cancellationToken);
            return PageableHelpers.WrapAsync(source, data => new SqlServerJobExecutionResource(Client, data));
        }

        /// <summary> Backward-compatible overload retained from v1.4.0; wraps the generated <see cref="GetByAgent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlServerJobExecutionResource> GetJobExecutionsByAgent(DateTimeOffset? createTimeMin = default, DateTimeOffset? createTimeMax = default, DateTimeOffset? endTimeMin = default, DateTimeOffset? endTimeMax = default, bool? isActive = default, int? skip = default, int? top = default, CancellationToken cancellationToken = default)
        {
            long? skipLong = skip;
            long? topLong = top;
            Pageable<SqlServerJobExecutionData> source = GetByAgent(createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skipLong, topLong, cancellationToken);
            return PageableHelpers.Wrap(source, data => new SqlServerJobExecutionResource(Client, data));
        }
    }
}
