// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Storage.Tables.Models
{
    /// <summary> The Metrics. </summary>
    public partial class Metrics
    {
        /// <summary> The version of Storage Analytics to configure. </summary>
        public string Version { get; set; }
        /// <summary> Indicates whether metrics are enabled for the Queue service. </summary>
        public bool Enabled { get; set; }
        /// <summary> Indicates whether metrics should generate summary statistics for called API operations. </summary>
        public bool? IncludeAPIs { get; set; }
        /// <summary> the retention policy. </summary>
        public RetentionPolicy RetentionPolicy { get; set; }
    }
}
