// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Request to get or delete instances by time series Ids or time series names.
    /// Exactly one of &quot;timeSeriesIds&quot; or &quot;names&quot; must be set.
    /// </summary>
    [CodeGenModel("InstancesRequestBatchGetOrDelete")]
    public partial class InstancesRequestBatchGetOrDelete
    {
        // Autorest does not support changing type for properties. In order to turn TimeSeriesId
        // from a list of objects to a strongly typed object, TimeSeriesId has been renamed to
        // TimeSeriesIdInternal and a new property, TimeSeriesId, has been created with the proper type.

        [CodeGenMember("TimeSeriesIds")]
        private IList<IList<object>> TimeSeriesIdsInternal { get; }

        /// <summary>
        /// The list of Time Series Ids used to make the request.
        /// </summary>
        public IList<TimeSeriesId> TimeSeriesIds { get; }

        /// <summary>
        /// Initializes a new instance of InstancesRequestBatchGetOrDelete.
        /// </summary>
        public InstancesRequestBatchGetOrDelete()
        {
            TimeSeriesIds = new ChangeTrackingList<TimeSeriesId>();
            Names = new ChangeTrackingList<string>();
        }
    }
}
