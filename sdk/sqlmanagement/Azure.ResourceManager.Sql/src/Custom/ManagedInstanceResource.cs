// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedInstanceResource
    {
#pragma warning disable CS0618 // obsolete types used for back-compat overloads
        /// <summary> Gets top resource consuming queries. </summary>
        [Obsolete("This overload is obsolete and will be removed in a future release. Use the explicit parameter overload instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<TopQueries> GetTopQueries(ManagedInstanceResourceGetTopQueriesOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new ManagedInstanceResourceGetTopQueriesOptions();
            return GetTopQueries(options.NumberOfQueries, options.Databases, options.StartTime, options.EndTime, options.Interval, options.AggregationFunction, options.ObservationMetric, cancellationToken);
        }

        /// <summary> Gets top resource consuming queries. </summary>
        [Obsolete("This overload is obsolete and will be removed in a future release. Use the explicit parameter overload instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<TopQueries> GetTopQueriesAsync(ManagedInstanceResourceGetTopQueriesOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new ManagedInstanceResourceGetTopQueriesOptions();
            return GetTopQueriesAsync(options.NumberOfQueries, options.Databases, options.StartTime, options.EndTime, options.Interval, options.AggregationFunction, options.ObservationMetric, cancellationToken);
        }
#pragma warning restore CS0618

        /// <summary> Gets a collection of <see cref="DistributedAvailabilityGroupResource"/>. </summary>
        [Obsolete("Use GetSqlDistributedAvailabilityGroups instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DistributedAvailabilityGroupCollection GetDistributedAvailabilityGroups()
        {
            return new DistributedAvailabilityGroupCollection(Client, Id);
        }

        /// <summary> Gets a single distributed availability group. </summary>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetSqlDistributedAvailabilityGroup instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DistributedAvailabilityGroupResource> GetDistributedAvailabilityGroup(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            return GetDistributedAvailabilityGroups().Get(distributedAvailabilityGroupName, cancellationToken);
        }

        /// <summary> Gets a single distributed availability group. </summary>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetSqlDistributedAvailabilityGroupAsync instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DistributedAvailabilityGroupResource>> GetDistributedAvailabilityGroupAsync(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            return await GetDistributedAvailabilityGroups().GetAsync(distributedAvailabilityGroupName, cancellationToken).ConfigureAwait(false);
        }
    }
}
