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
        /// Initializes a new instance of the <see cref="DataFeedOptions"/> class.
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
            Description = dataFeedDetail.DataFeedDescription;
            AccessMode = dataFeedDetail.ViewMode;
            RollupSettings = new DataFeedRollupSettings(dataFeedDetail);
            MissingDataPointFillSettings = new DataFeedMissingDataPointFillSettings(dataFeedDetail);
            ActionLinkTemplate = dataFeedDetail.ActionLinkTemplate;
        }

        /// <summary>
        /// A description of the <see cref="DataFeed"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Defines actionable HTTP URLs, which consist of the placeholders %datafeed, %metric, %timestamp, %detect_config, and %tagset.
        /// You can use the template to redirect from an anomaly or an incident to a specific URL to drill down.
        /// See the <see href="https://docs.microsoft.com/azure/cognitive-services/metrics-advisor/how-tos/manage-data-feeds#action-link-template">documentation</see> for details.
        /// </summary>
        public string ActionLinkTemplate { get; set; }

        /// <summary>
        /// The access mode for the <see cref="DataFeed"/>.
        /// </summary>
        public DataFeedAccessMode? AccessMode { get; set; }

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
