// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class DataFeedRollupSettings
    {
        private IList<string> _autoRollupGroupByColumnNames;

        /// <summary>
        /// Creates a new instance of the <see cref="DataFeedRollupSettings"/> class.
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
        /// </summary>
        public string AlreadyRollupIdentificationValue { get; set; }

        /// <summary>
        /// </summary>
        public DataFeedRollupType? RollupType { get; set; }

        /// <summary>
        /// </summary>
        public DataFeedAutoRollupMethod? RollupMethod { get; set; }

        /// <summary>
        /// </summary>
        public IList<string> AutoRollupGroupByColumnNames
        {
            get => _autoRollupGroupByColumnNames;
            set
            {
                Argument.AssertNotNull(value, nameof(AutoRollupGroupByColumnNames));
                _autoRollupGroupByColumnNames = value;
            }
        }
    }
}
