// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Data Lake Service Properties.
    /// Note that HNS-enabled storage accounts do not support static website.
    /// </summary>
    public class DataLakeServiceProperties
    {
        /// <summary>
        /// Azure Analytics Logging settings.
        /// </summary>
        public DataLakeAnalyticsLogging Logging { get; set; }

        /// <summary>
        /// A summary of request statistics grouped by API in hour or minute aggregates for Data Lake.
        /// </summary>
        public DataLakeMetrics HourMetrics { get; set; }

        /// <summary>
        /// A summary of request statistics grouped by API in hour or minute aggregates for Data Lake.
        /// </summary>
        public DataLakeMetrics MinuteMetrics { get; set; }

        /// <summary>
        /// The set of CORS rules.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<DataLakeCorsRule> Cors { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// The default version to use for requests to the Data Lake service if an incoming request's version is not specified.
        /// Possible values include version 2008-10-27 and all more recent versions.
        /// </summary>
        public string DefaultServiceVersion { get; set; }

        /// <summary>
        /// The retention policy which determines how long the associated data should persist.
        /// </summary>
        public DataLakeRetentionPolicy DeleteRetentionPolicy { get; set; }
    }
}
