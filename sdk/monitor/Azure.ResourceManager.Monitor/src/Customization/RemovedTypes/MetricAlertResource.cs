// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Monitor
{
    public partial class MetricAlertResource
    {
        /// <summary> Gets all metric alert status values. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of metric alert status values. </returns>
        public virtual Pageable<MetricAlertStatus> GetAllMetricAlertsStatus(CancellationToken cancellationToken = default)
        {
            Response<MetricAlertStatusCollection> response = GetAll(cancellationToken);
            return Pageable<MetricAlertStatus>.FromPages(new[] { Page<MetricAlertStatus>.FromValues(new List<MetricAlertStatus>(response.Value.Value), null, response.GetRawResponse()) });
        }

        /// <summary> Gets all metric alert status values. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of metric alert status values. </returns>
        public virtual AsyncPageable<MetricAlertStatus> GetAllMetricAlertsStatusAsync(CancellationToken cancellationToken = default)
            => AsyncPageable<MetricAlertStatus>.FromPages(GetAllMetricAlertsStatus(cancellationToken).AsPages());

        /// <summary> Gets metric alert status values by status name. </summary>
        /// <param name="statusName"> The status name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of metric alert status values. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual Pageable<MetricAlertStatus> GetAllMetricAlertsStatusByName(string statusName, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metric alert status values by status name. </summary>
        /// <param name="statusName"> The status name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of metric alert status values. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual AsyncPageable<MetricAlertStatus> GetAllMetricAlertsStatusByNameAsync(string statusName, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported.");
    }
}
