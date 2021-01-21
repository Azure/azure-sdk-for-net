// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Configures the behavior of a <see cref="DataFeed"/> for rolling-up the ingested
    /// data before detecting anomalies.
    /// </summary>
    public class DataFeedRollupSettings
    {
        private IList<string> _autoRollupGroupByColumnNames;

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
            AlreadyRollupIdentificationValue = dataFeedDetail.AllUpIdentification;
            RollupType = dataFeedDetail.NeedRollup;
            RollupMethod = dataFeedDetail.RollUpMethod;
        }

        /// <summary>
        /// The value a dimension assumes when it represents a rolled-up value in the original data source.
        /// </summary>
        public string AlreadyRollupIdentificationValue { get; set; }

        /// <summary>
        /// The strategy used by this <see cref="DataFeed"/> when rolling-up the ingested data before detecting
        /// anomalies.
        /// </summary>
        public DataFeedRollupType? RollupType { get; set; }

        /// <summary>
        /// The roll-up method the service should apply to the ingested data for anomaly detection. This property
        /// must be set if <see cref="RollupType"/> is <see cref="DataFeedRollupType.NeedRollup"/>.
        /// </summary>
        public DataFeedAutoRollupMethod? RollupMethod { get; set; }

        /// <summary>
        /// Defines the column names to which these <see cref="DataFeedRollupSettings"/> will apply.
        /// </summary>
        /// <exception cref="ArgumentNullException"><see cref="AutoRollupGroupByColumnNames"/> is null.</exception>
#pragma warning disable CA2227 // Collection properties should be readonly
        public IList<string> AutoRollupGroupByColumnNames
        {
            get => _autoRollupGroupByColumnNames;
            set
            {
                Argument.AssertNotNull(value, nameof(AutoRollupGroupByColumnNames));
                _autoRollupGroupByColumnNames = value;
            }
        }
#pragma warning restore CA2227 // Collection properties should be readonly
    }
}
