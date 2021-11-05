// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Azure Analytics Logging settings.
    /// </summary>
    public class DataLakeAnalyticsLogging
    {
        /// <summary>
        /// The version of Storage Analytics to configure.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Indicates whether all delete requests should be logged.
        /// </summary>
        public bool Delete { get; set; }

        /// <summary>
        /// Indicates whether all read requests should be logged.
        /// </summary>
        public bool Read { get; set; }

        /// <summary>
        /// Indicates whether all write requests should be logged.
        /// </summary>
        public bool Write { get; set; }

        /// <summary>
        /// The retention policy which determines how long the associated data should persist.
        /// </summary>
        public DataLakeRetentionPolicy RetentionPolicy { get; set; }
    }
}
