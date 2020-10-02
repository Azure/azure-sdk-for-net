// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class DataFeedOptions
    {
        private IList<string> _administrators;

        private IList<string> _viewers;

        /// <summary>
        /// Creates a new instance of the <see cref="DataFeedOptions"/> class.
        /// </summary>
        public DataFeedOptions()
        {
            Administrators = new ChangeTrackingList<string>();
            Viewers = new ChangeTrackingList<string>();
        }

        internal DataFeedOptions(DataFeedDetail dataFeedDetail)
        {
            Administrators = dataFeedDetail.Admins;
            Viewers = dataFeedDetail.Viewers;
            FeedDescription = dataFeedDetail.DataFeedDescription;
            AccessMode = dataFeedDetail.ViewMode;
            RollupSettings = new DataFeedRollupSettings(dataFeedDetail);
            MissingDataPointFillSettings = new DataFeedMissingDataPointFillSettings(dataFeedDetail);
            Creator = dataFeedDetail.Creator;
        }

        /// <summary>
        /// </summary>
        public string FeedDescription { get; set; }

        /// <summary>
        /// </summary>
        public AccessMode? AccessMode { get; set; }

        /// <summary>
        /// </summary>
        public DataFeedRollupSettings RollupSettings { get; set; }

        /// <summary>
        /// </summary>
        public DataFeedMissingDataPointFillSettings MissingDataPointFillSettings { get; set; }

        /// <summary>
        /// </summary>
        public string Creator { get; }

        /// <summary>
        /// </summary>
        public IList<string> Administrators
        {
            get => _administrators;
            set
            {
                Argument.AssertNotNull(value, nameof(Administrators));
                _administrators = value;
            }
        }

        /// <summary>
        /// </summary>
        public IList<string> Viewers
        {
            get => _viewers;
            set
            {
                Argument.AssertNotNull(value, nameof(Viewers));
                _viewers = value;
            }
        }
    }
}
