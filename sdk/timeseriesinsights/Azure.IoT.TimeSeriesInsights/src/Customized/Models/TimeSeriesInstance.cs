// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Time series instances are the time series themselves. In most cases, the deviceId or assetId is the
    /// unique identifier of the asset in the environment. Instances have descriptive information associated
    /// with them called instance fields. At a minimum, instance fields include hierarchy information. They
    /// can also include useful, descriptive data like the manufacturer, operator, or the last service date.
    /// </summary>
    [CodeGenModel("TimeSeriesInstance")]
    [CodeGenSuppress("TimeSeriesInstance", typeof(IEnumerable<object>), typeof(string))]
    [CodeGenSuppress(
        "TimeSeriesInstance",
        typeof(IList<object>),
        typeof(string),
        typeof(string),
        typeof(string),
        typeof(IList<string>),
        typeof(IDictionary<string, object>))]
    public partial class TimeSeriesInstance
    {
        // Autorest does not support changing type for properties. In order to turn TimeSeriesId
        // from a list of objects to a strongly typed object, TimeSeriesId has been renamed to
        // TimeSeriesIdInternal and a new property, TimeSeriesId, has been created with the proper type.

        [CodeGenMember("TimeSeriesId")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "CodeQuality",
            "IDE0051:Remove unused private members",
            Justification = "Autorest does not support changing type for properties. In order to turn TimeSeriesId from" +
            "a list of objects to a strongly typed object, TimeSeriesId has been renamed to TimeSeriesIdInternal and a" +
            "new property, TimeSeriesId, has been created with the proper type.")]
        private IList<object> TimeSeriesIdInternal { get; }

        /// <summary>
        /// Time Series Id that uniquely identifies the instance. It matches Time Series Id properties in an environment.
        /// </summary>
        public TimeSeriesId TimeSeriesId { get; }

        /// <summary>
        /// Initializes a new instance of TimeSeriesInstance.
        /// </summary>
        /// <param name="timeSeriesId">
        /// Time Series Id that uniquely identifies the instance. It matches Time Series Id properties in
        /// an environment. Immutable, never null.
        /// </param>
        /// <param name="typeId">
        /// This represents the type that this instance belongs to. Never null.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="timeSeriesId"/> or <paramref name="typeId"/> is null.
        /// </exception>
        public TimeSeriesInstance(TimeSeriesId timeSeriesId, string typeId)
        {
            TimeSeriesId = timeSeriesId ?? throw new ArgumentNullException(nameof(timeSeriesId));
            TypeId = typeId ?? throw new ArgumentNullException(nameof(typeId));
            HierarchyIds = new ChangeTrackingList<string>();
            InstanceFields = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of TimeSeriesInstance.
        /// </summary>
        /// <param name="timeSeriesId">
        /// Time Series Id that uniquely identifies the instance. It matches Time Series Id properties in
        /// an environment. Immutable, never null.
        /// </param>
        /// <param name="typeId">This represents the type that this instance belongs to. Never null. </param>
        /// <param name="name">
        /// Optional name of the instance which is unique in an environment. Names acts as a mutable alias
        /// or display name of the time series instance. Mutable, may be null.
        /// </param>
        /// <param name="description">This optional field contains description about the instance. </param>
        /// <param name="hierarchyIds">Set of time series hierarchy Ids that the instance belong to. May be null. </param>
        /// <param name="instanceFields">
        /// Set of key-value pairs that contain user-defined instance properties.
        /// It may be null. Supported property value types are: bool, string, long, double and it cannot be nested or null.
        /// </param>
        internal TimeSeriesInstance(
            TimeSeriesId timeSeriesId,
            string typeId,
            string name,
            string description,
            IList<string> hierarchyIds,
            IDictionary<string, object> instanceFields)
        {
            TimeSeriesId = timeSeriesId;
            TypeId = typeId;
            Name = name;
            Description = description;
            HierarchyIds = hierarchyIds;
            InstanceFields = instanceFields;
        }
    }
}
