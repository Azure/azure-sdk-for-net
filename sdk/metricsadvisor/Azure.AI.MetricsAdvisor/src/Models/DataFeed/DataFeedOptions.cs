// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A set of options configuring the behavior of a <see cref="DataFeed"/>. Options include administrators,
    /// roll-up settings, access mode, and others.
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
        /// A description of the <see cref="DataFeed"/>.
        /// </summary>
        public string FeedDescription { get; set; }

        // TODODOCS.
        /// <summary>
        /// </summary>
        public AccessMode? AccessMode { get; set; }

        /// <summary>
        /// Configures the behavior of this <see cref="DataFeed"/> for rolling-up the ingested data
        /// before detecting anomalies.
        /// </summary>
        public DataFeedRollupSettings RollupSettings { get; set; }

        /// <summary>
        /// Configures the behavior of this <see cref="DataFeed"/> when dealing with missing points
        /// in the data ingested from the data source.
        /// </summary>
        public DataFeedMissingDataPointFillSettings MissingDataPointFillSettings { get; set; }

        // TODODOCS.
        /// <summary>
        /// </summary>
        public string Creator { get; }

        /// <summary>
        /// The emails of this data feed's administrators. Administrators have total control over a
        /// data feed, being allowed to update, delete or pause them. They also have access to the
        /// credentials used to authenticate to the data source.
        /// </summary>
        /// <exception cref="ArgumentNullException"><see cref="Administrators"/> is null.</exception>
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
        /// The emails of this data feed's viewers. Viewers have read-only access to a data feed, and
        /// do not have access to the credentials used to authenticate to the data source.
        /// </summary>
        /// <exception cref="ArgumentNullException"><see cref="Viewers"/> is null.</exception>
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
