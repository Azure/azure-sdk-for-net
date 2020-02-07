// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Storage.Tables.Models
{
    /// <summary> Storage Service Properties. </summary>
    public partial class StorageServiceProperties
    {
        /// <summary> Azure Analytics Logging settings. </summary>
        public Logging Logging { get; set; }
        public Metrics HourMetrics { get; set; }
        public Metrics MinuteMetrics { get; set; }
        /// <summary> The set of CORS rules. </summary>
        public ICollection<CorsRule> Cors { get; set; }
    }
}
