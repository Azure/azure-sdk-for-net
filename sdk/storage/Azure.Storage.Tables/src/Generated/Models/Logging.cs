// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Storage.Tables.Models
{
    /// <summary> Azure Analytics Logging settings. </summary>
    public partial class Logging
    {
        /// <summary> The version of Storage Analytics to configure. </summary>
        public string Version { get; set; }
        /// <summary> Indicates whether all delete requests should be logged. </summary>
        public bool Delete { get; set; }
        /// <summary> Indicates whether all read requests should be logged. </summary>
        public bool Read { get; set; }
        /// <summary> Indicates whether all write requests should be logged. </summary>
        public bool Write { get; set; }
        /// <summary> the retention policy. </summary>
        public RetentionPolicy RetentionPolicy { get; set; } = new RetentionPolicy();
    }
}
