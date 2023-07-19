// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// A summary of request statistics grouped by API in hour or minute aggregates for Data Lake.
    /// </summary>
    public class DataLakeMetrics
    {
        /// <summary>
        /// The version of Storage Analytics to configure.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Indicates whether metrics are enabled for the Data Lake service.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The retention policy which determines how long the associated data should persist.
        /// </summary>
        public DataLakeRetentionPolicy RetentionPolicy { get; set; }

        /// <summary>
        /// Indicates whether metrics should generate summary statistics for called API operations.
        /// </summary>
        public bool? IncludeApis { get; set; }
    }
}
