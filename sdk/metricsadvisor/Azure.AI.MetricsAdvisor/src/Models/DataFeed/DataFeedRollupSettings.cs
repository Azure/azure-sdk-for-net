// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Configures the behavior of a <see cref="DataFeed"/> when handling rolled-up ingested
    /// data before detecting anomalies.
    /// </summary>
    public class DataFeedRollupSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedRollupSettings"/> class.
        /// </summary>
        public DataFeedRollupSettings()
        {
            AutoRollupGroupByColumnNames = new ChangeTrackingList<string>();
        }

        internal DataFeedRollupSettings(DataFeedDetail dataFeedDetail)
        {
            AutoRollupGroupByColumnNames = dataFeedDetail.RollUpColumns;
            RollupIdentificationValue = dataFeedDetail.AllUpIdentification;
            RollupType = dataFeedDetail.NeedRollup;
            AutoRollupMethod = dataFeedDetail.RollUpMethod;
        }

        /// <summary>
        /// The value a dimension assumes when it represents a rolled-up value. Must be set when <see cref="RollupType"/>
        /// is <see cref="DataFeedRollupType.AlreadyRolledUp"/> or <see cref="DataFeedRollupType.RollupNeeded"/>.
        /// </summary>
        public string RollupIdentificationValue { get; set; }

        /// <summary>
        /// The strategy used by this <see cref="DataFeed"/> when rolling-up the ingested data before detecting
        /// anomalies. Defaults to <see cref="DataFeedRollupType.NoRollupNeeded"/>. If the type is set to
        /// <see cref="DataFeedRollupType.RollupNeeded"/>, both <see cref="AutoRollupMethod"/> and
        /// <see cref="RollupIdentificationValue"/> must be set. If the type is <see cref="DataFeedRollupType.AlreadyRolledUp"/>,
        /// only <see cref="RollupIdentificationValue"/> must be set.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public DataFeedRollupType? RollupType { get; set; }

        /// <summary>
        /// The roll-up method the service should apply to the ingested data for anomaly detection. This property
        /// must be set if <see cref="RollupType"/> is <see cref="DataFeedRollupType.RollupNeeded"/>. Defaults to
        /// <see cref="DataFeedAutoRollupMethod.None"/>.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public DataFeedAutoRollupMethod? AutoRollupMethod { get; set; }

        /// <summary>
        /// Can be used when <see cref="RollupType"/> is <see cref="DataFeedRollupType.RollupNeeded"/>.
        /// Specifies which dimensions should be rolled-up by the service. If no dimensions are specified,
        /// all of them will be used. Be aware that you must specify the dimensions' display names, otherwise
        /// operation will fail.
        /// </summary>
        public IList<string> AutoRollupGroupByColumnNames { get; }
    }
}
