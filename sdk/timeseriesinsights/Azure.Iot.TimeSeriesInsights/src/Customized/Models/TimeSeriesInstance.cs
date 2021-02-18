// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// Time series instances are the time series themselves. In most cases, the deviceId or assetId is the
    /// unique identifier of the asset in the environment. Instances have descriptive information associated
    /// with them called instance fields. At a minimum, instance fields include hierarchy information. They
    /// can also include useful, descriptive data like the manufacturer, operator, or the last service date.
    /// </summary>
    [CodeGenModel("TimeSeriesInstance")]
    public partial class TimeSeriesInstance
    {
        /// <summary>Initializes a new instance of TimeSeriesInstance.</summary>
        /// <param name="timeSeriesId">
        /// Time Series Id that uniquely identifies the instance.It matches Time Series Id properties in
        /// an environment. Immutable, never null.
        /// </param>
        /// <param name="typeId">
        /// This represents the type that this instance belongs to. Never null.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="timeSeriesId"/> or <paramref name="typeId"/> is null.
        /// </exception>
        public TimeSeriesInstance(ITimeSeriesId timeSeriesId, string typeId)
        {
            if (timeSeriesId == null)
            {
                throw new ArgumentNullException(nameof(timeSeriesId));
            }
            if (typeId == null)
            {
                throw new ArgumentNullException(nameof(typeId));
            }

            TimeSeriesId = timeSeriesId.ToArray();
            TypeId = typeId;
            HierarchyIds = new ChangeTrackingList<string>();
            InstanceFields = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary>Initializes a new instance of TimeSeriesInstance.</summary>
        /// <param name="timeSeriesId">
        /// Time Series ID that uniquely identifies the instance. It matches Time Series ID properties in
        /// an environment. Immutable, never null.
        /// </param>
        /// <param name="typeId">This represents the type that this instance belongs to. Never null. </param>
        /// <param name="name">
        /// Optional name of the instance which is unique in an environment. Names acts as a mutable alias
        /// or display name of the time series instance. Mutable, may be null.
        /// </param>
        /// <param name="description">This optional field contains description about the instance. </param>
        /// <param name="hierarchyIds">Set of time series hierarchy IDs that the instance belong to. May be null. </param>
        /// <param name="instanceFields">Set of key-value pairs that contain user-defined instance properties.
        /// It may be null. Supported property value types are: bool, string, long, double and it cannot be nested or null.
        /// </param>
        internal TimeSeriesInstance(
            ITimeSeriesId timeSeriesId,
            string typeId,
            string name,
            string description,
            IList<string> hierarchyIds,
            IDictionary<string, object> instanceFields)
        {
            TimeSeriesId = timeSeriesId.ToArray();
            TypeId = typeId;
            Name = name;
            Description = description;
            HierarchyIds = hierarchyIds;
            InstanceFields = instanceFields;
        }
    }
}
