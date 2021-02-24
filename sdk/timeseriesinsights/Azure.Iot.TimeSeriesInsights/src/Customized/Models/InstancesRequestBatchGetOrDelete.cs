// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// Request to get or delete instances by time series Ids or time series names.
    /// Exactly one of &quot;timeSeriesIds&quot; or &quot;names&quot; must be set.
    /// </summary>
    [CodeGenModel("InstancesRequestBatchGetOrDelete")]
    public partial class InstancesRequestBatchGetOrDelete
    {
        [CodeGenMember("TimeSeriesIds")]
        private IList<IList<object>> TimeSeriesIdsInternal { get; }

        /// <summary>
        /// The list of Time Series Ids used to make the request.
        /// </summary>
        public IList<ITimeSeriesId> TimeSeriesIds { get; }

        /// <summary>
        /// Initializes a new instance of InstancesRequestBatchGetOrDelete.
        /// </summary>
        public InstancesRequestBatchGetOrDelete()
        {
            TimeSeriesIds = new ChangeTrackingList<ITimeSeriesId>();
            Names = new ChangeTrackingList<string>();
        }
    }
}
